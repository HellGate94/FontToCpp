using DotMake.CommandLine;
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
    public int Size { get; set; } = 24;

    [CliOption(Description = "Font Style")]
    public FontStyle Style { get; set; } = FontStyle.Regular;

    [CliOption(Description = "Pixel Threshold")]
    public byte Threshold { get; set; } = 127;

    [CliOption(Description = "Font Name inside the Source File. [default: FontName + Size]")]
    public string? FontSourceName { get; set; } = null;

    [CliOption(Description = "Alphabet")]
    public string Alphabet { get; set; } = """ !"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~""";

    [CliOption(Description = "If Kernings Table should be generated")]
    public bool Kernings { get; set; } = false;

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

        SizeF maxSizeF = SizeF.Empty;
        foreach (var c in Alphabet) {
            var cs = MeasureCharacter(c, font, format);
            maxSizeF = new(MathF.Max(maxSizeF.Width, cs.Width), MathF.Max(maxSizeF.Height, cs.Height));
        }

        Size maxSize = new((int)MathF.Ceiling(maxSizeF.Width), (int)MathF.Ceiling(maxSizeF.Height));

        Point min = new(int.MaxValue, int.MaxValue);
        Point max = new(0, 0);
        // Refine Bounds for current Alphabet
        using (Bitmap b = new(maxSize.Width, maxSize.Height)) {
            using Graphics tg = MakePixelGraphics(b);

            foreach (var c in Alphabet) {
                tg.Clear(Color.Black);
                tg.DrawString(c.ToString(), font, Brushes.White, PointF.Empty, format);
                tg.Flush();
                for (int x = 0; x < b.Width; x++) {
                    for (int y = 0; y < b.Height; y++) {
                        if (b.GetPixel(x, y).R > Threshold) {
                            min.X = Math.Min(min.X, x);
                            min.Y = Math.Min(min.Y, y);
                            max.X = Math.Max(max.X, x);
                            max.Y = Math.Max(max.Y, y);
                        }
                    }
                }
            }
        }

        maxSize = new((max.X - min.X) + 1, (max.Y - min.Y) + 1);

        Console.WriteLine($"Font '{font.Name}' with Style '{Style}' of Size '{Size}' has the max Dimensions: ({maxSize})");

        string fontName = FontSourceName ?? $"{font.Name.Replace(" ", "")}{Size}";

        StringBuilder sb = new();

        sb.AppendLine("#include \"fonts.h\"");
        sb.AppendLine();
        sb.AppendLine($"const uint8_t {fontName}_Table[] = ");
        sb.AppendLine("{");

        Console.Write("Processing: ");
        using Bitmap img = new(maxSize.Width, maxSize.Height);
        using Graphics g = MakePixelGraphics(img);
        int index = 0;

        foreach (var c in Alphabet) {
            var str = c.ToString();
            g.Clear(Color.Black);
            g.DrawString(str, font, Brushes.White, new PointF(-min.X, -min.Y), format);
            g.Flush();

            var bits = EncodeToBits(img);

            sb.AppendLine($"{Indent}// @{bits.Length * index} '{c}' ({img.Width} pixels wide)");
            sb.Append(Indent);
            foreach (byte b in bits)
                sb.Append($"0x{b:x2}, ");
            sb.AppendLine();
            index++;
        }
        Console.WriteLine();
        sb.AppendLine("};");
        sb.AppendLine();

        if (Kernings) {
            for (int i = 0; i < Alphabet.Length; i++) {
                for (int j = 0; j < Alphabet.Length; j++) {
                    char char1 = Alphabet[i];
                    char char2 = Alphabet[j];
                    float k = GetApproximateKerning(font, char1, char2, StringFormat.GenericDefault);
                    Console.WriteLine(k);
                }
            }
        }

        sb.AppendLine($"sFONT {fontName} = {{");
        sb.AppendLine($"{Indent}{fontName}_Table,");
        sb.AppendLine($"{Indent}{maxSize.Width}, // Width");
        sb.AppendLine($"{Indent}{maxSize.Height}, // Height");
        sb.AppendLine("};");

        File.WriteAllText(Output, sb.ToString());
        Console.WriteLine("Done.");
    }

    public static float GetApproximateKerning(Font font, char char1, char char2, StringFormat format) {
        // Measure the width of each character individually
        float char1Width = tmpg.MeasureString(char1.ToString(), font, 0, format).Width;
        float char2Width = tmpg.MeasureString(char2.ToString(), font, 0, format).Width;

        // Measure the combined width of both characters
        string combinedString = char1.ToString() + char2.ToString();
        float combinedWidth = tmpg.MeasureString(combinedString, font, 0, format).Width;

        // Approximate kerning as the difference between combined and individual widths
        return combinedWidth - (char1Width + char2Width);
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
    private static SizeF MeasureCharacter(char c, Font font, StringFormat format) {
        return tmpg.MeasureString(c.ToString(), font, 0, format);
    }

    private void WriteImgae(Bitmap img) {
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

    private byte[] EncodeToBits(Bitmap img) {
        // Calculate image dimensions
        int width = img.Width;
        int height = img.Height;

        // Initialize output buffer
        int stride = (img.Width + 7) / 8; // Bytes per row (rounded up)
        int byteCount = stride * img.Height;

        byte[] data = new byte[byteCount];

        // Loop through each pixel in the image
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                // Calculate target byte and bit position in the font table
                int target_byte_index = y * ((img.Width + 7) / 8) + x / 8;
                int bit_position = 7 - (x % 8);

                // Extract pixel value from the glyph data
                byte pixel_value = img.GetPixel(x, y).R;

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
}