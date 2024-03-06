using DotMake.CommandLine;
using HellEngine.Mathematics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.Versioning;
using System.Text;

namespace FontToCpp;

[CliCommand]
[SupportedOSPlatform("windows")]
public class MakeFontCommand {
    private const string Indent = "    ";

    [CliArgument(Description = "Font Name or Path to Font")]
    public string Font { get; set; } = "Arial";

    [CliArgument(Description = "Path for the Output", ValidationRules = CliValidationRules.LegalPath)]
    public string Output { get; set; } = "font.c";

    [CliOption(Description = "Font Height")]
    public int Size { get; set; } = 16;

    [CliOption(Description = "Font Style")]
    public FontStyle Style { get; set; } = FontStyle.Regular;

    [CliOption(Description = "Pixel Threshold")]
    public byte Threshold { get; set; } = 127;

    [CliOption(Description = "Font Name inside the Source File. [default: FontName + Size]")]
    public string? FontSourceName { get; set; } = null;

    [CliOption(Description = "Alphabet")]
    public string Alphabet { get; set; } = """ !"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~""";

    private record struct CharInfo(int2 Size, int2 Offset, uint MemOffset);

    public void Run() {
        var fontfam = FontFamily.Families
                     .Where(c => c.Name == Font)
                     .FirstOrDefault();

        Font font;

        if (fontfam is null) {
            if (!File.Exists(Font)) {
                throw new FileNotFoundException("Could not find Font", Font);
            }

            var myFonts = new PrivateFontCollection();
            myFonts.AddFontFile(Font);
            font = new Font(myFonts.Families[0], Size, Style, GraphicsUnit.Pixel);
        } else {
            font = new Font(fontfam, Size, Style, GraphicsUnit.Pixel);
        }

        StringFormat format = StringFormat.GenericDefault;

        Console.WriteLine($"Font '{font.Name}' with Style '{Style}' of Size '{Size}' has the max Dimensions: ()");

        string fontName = FontSourceName ?? $"{font.Name.Replace(" ", "")}{Size}";

        Console.Write("Processing: ");

        StringBuilder sb = new();
        sb.AppendLine("#include \"fonts.h\"");
        sb.AppendLine();
        sb.AppendLine($"const uint8_t {fontName}_Table[] = ");
        sb.AppendLine("{");

        CharInfo[] charInfos = new CharInfo[Alphabet.Length];

        uint bytes = 0;
        for (int i = 0; i < Alphabet.Length; i++) {
            var c = Alphabet[i];
            var str = c.ToString();
            int2 size = (int2)math.ceil(tmpg.MeasureString(str, font, 0, format));
            using Bitmap b = new(size.x, size.y);
            using Graphics g = MakePixelGraphics(b);

            g.Clear(Color.Black);
            g.DrawString(str, font, Brushes.White, PointF.Empty, format);
            g.Flush();

            var hasBounds = TryFindPixelBounds(b, out var cb);
            // no solid pixel found. use a workaround for the workaround...
            if (!hasBounds) {
                cb = new(int2.zero, (int2)math.ceil(g.MeasureString(str, font, 0, format)));
                cb.v1.y = cb.v0.x + 1; // make it 1px high
            }

            var bits = EncodeToBits(b, cb);

            CharInfo ci = new(cb.v1 - cb.v0, cb.v0, bytes);
            charInfos[i] = ci;

            sb.AppendLine($"{Indent}// @{bytes} '{c}' ({ci.Size} pixels )");
            sb.Append(Indent);
            foreach (byte bt in bits)
                sb.Append($"0x{bt:x2}, ");
            sb.AppendLine();

            bytes += (uint)bits.Length;
        }
        Console.WriteLine();
        sb.AppendLine("};");
        sb.AppendLine();

        sb.AppendLine($"const sCharInfo {fontName}_Info[] = ");
        sb.AppendLine("{");
        for (int i = 0; i < Alphabet.Length; i++) {
            var ci = charInfos[i];
            sb.AppendLine($"{Indent}{{ {ci.MemOffset}, {ci.Size.x}, {ci.Size.y}, {ci.Offset.x}, {ci.Offset.y} }},");

        }
        sb.AppendLine("};");

        sb.AppendLine($"sFONT {fontName} = {{");
        sb.AppendLine($"{Indent}{fontName}_Table,");
        sb.AppendLine($"{Indent}{fontName}_Info,");
        sb.AppendLine("};");

        File.WriteAllText(Output, sb.ToString());
        Console.WriteLine("Done.");
    }

    private bool TryFindPixelBounds(Bitmap b, out int2x2 bounds) {
        bool pixel = false;
        bounds = new(new(b.Width, b.Height), int2.zero);
        for (int x = 0; x < b.Width; x++) {
            for (int y = 0; y < b.Height; y++) {
                if (b.GetPixel(x, y).R > Threshold) {
                    pixel = true;
                    int2 p = new(x, y);
                    bounds.v0 = math.min(bounds.v0, p);
                    bounds.v1 = math.max(bounds.v1, p + 1);
                }
            }
        }
        return pixel;
    }

    private static Graphics MakePixelGraphics(Bitmap bmp) {
        Graphics g = Graphics.FromImage(bmp);
        g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
        g.InterpolationMode = InterpolationMode.High;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.SmoothingMode = SmoothingMode.None;
        return g;
    }

    private static Graphics tmpg = MakePixelGraphics(new Bitmap(1, 1));

    private byte[] EncodeToBits(Bitmap img, int2x2 bounds) {
        // Calculate image dimensions
        int2 size = bounds.v1 - bounds.v0;

        // Initialize output buffer
        int stride = (size.x + 7) / 8; // Bytes per row (rounded up)
        int byteCount = stride * size.y;

        byte[] data = new byte[byteCount];

        // Loop through each pixel in the image
        for (int y = 0; y < size.y; y++) {
            for (int x = 0; x < size.x; x++) {
                // Calculate target byte and bit position in the font table
                int target_byte_index = y * ((size.x + 7) / 8) + x / 8;
                int bit_position = 7 - (x % 8);

                // Extract pixel value from the glyph data
                byte pixel_value = img.GetPixel(x + bounds.v0.x, y + bounds.v0.y).R;

                // Set or clear the corresponding bit in the font table byte
                if (pixel_value > Threshold) {
                    data[target_byte_index] |= (byte)(1 << bit_position);
                } else {
                    data[target_byte_index] &= (byte)~(1 << bit_position);
                }
            }
        }

        return data;
    }

    private void WriteImage(Bitmap img) {
        // Calculate image dimensions
        int width = img.Width;
        int height = img.Height;

        // Loop through each pixel in the image
        for (int y = 0; y < height; y++) {
            StringBuilder s = new(width);
            for (int x = 0; x < width; x++) {
                s.Append(img.GetPixel(x, y).R > Threshold ? ' ' : 'X');
            }
            Console.WriteLine(s);
        }
    }
}