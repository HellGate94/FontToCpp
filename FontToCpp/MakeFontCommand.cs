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
    [CliArgument(Description = "Font Name or Path to Font")]
    public string Font { get; set; }

    [CliArgument(Description = "Path for the Output", ValidationRules = CliValidationRules.LegalPath)]
    public string Output { get; set; }

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

        SizeF maxSizeF = SizeF.Empty;

        using (var image = new Bitmap(1, 1)) {
            using var g = Graphics.FromImage(image);
            foreach (var c in Alphabet) {
                var cs = g.MeasureString(c.ToString(), font);
                maxSizeF = new(Math.Max(maxSizeF.Width, cs.Width), Math.Max(maxSizeF.Height, cs.Height));
            }
        }
        Size maxSize = new((int)maxSizeF.Width, (int)maxSizeF.Height);
        Console.WriteLine($"Font '{font.Name}' with Style '{Style}' of Size '{Size}' has the Dimensions: ({maxSize.Width}, {maxSize.Height})");

        string fontName = FontSourceName ?? $"{font.Name.Replace(" ", "")}{Size}";

        StringBuilder sb = new();

        sb.AppendLine("#include \"fonts.h\"");
        sb.AppendLine();
        sb.AppendLine($"const uint8_t {fontName}_Table[] = ");
        sb.AppendLine("{");

        Console.Write("Processing: ");
        using Bitmap img = new((int)maxSize.Width, (int)maxSize.Height);
        using Graphics context = Graphics.FromImage(img);
        context.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
        int index = 0;
        foreach (var c in Alphabet) {
            var str = c.ToString();
            Console.Write(str);
            var cs = context.MeasureString(c.ToString(), font);
            context.Clear(Color.Black);
            context.DrawString(str, font, Brushes.White, 0, 0);

            var bits = EncodeToBits(img);

            sb.AppendLine($"    // @{bits.Length * index} '{c}' ({img.Width} pixels wide)");
            sb.Append("    ");
            foreach (byte b in bits)
                sb.Append($"0x{b:x2}, ");
            sb.AppendLine();
            index++;
        }
        Console.WriteLine();

        sb.AppendLine("};");
        sb.AppendLine();
        sb.AppendLine($"sFONT {fontName} = {{");
        sb.AppendLine($"    {fontName}_Table,");
        sb.AppendLine($"    {maxSize.Width}, // Width");
        sb.AppendLine($"    {maxSize.Height}, // Height");
        sb.AppendLine("};");

        File.WriteAllText(Output, sb.ToString());
        Console.WriteLine("Done.");
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