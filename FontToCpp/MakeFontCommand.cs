using DotMake.CommandLine;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Text;

namespace FontToCpp;

[CliCommand]
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
        if (!SystemFonts.TryGet(Font, out var family)) {
            if (!File.Exists(Font)) {
                throw new FileNotFoundException("Could not find Font", Font);
            }
            FontCollection collection = new();
            family = collection.Add(Font);
        }
        var font = family.CreateFont(Size, Style);
        TextOptions options = new(font) {
            KerningMode = KerningMode.None,
        };

        FontRectangle maxSize = FontRectangle.Empty;
        foreach (var c in Alphabet) {
            var cs = TextMeasurer.MeasureAdvance(c.ToString(), options);
            maxSize = FontRectangle.Union(maxSize, cs);
        }
        Console.WriteLine($"Font '{font.Name}' with Style '{Style}' of Size '{Size}' has the Dimensions: ({maxSize.Width}, {maxSize.Height})");

        string fontName = FontSourceName ?? $"{font.Name.Replace(" ", "")}{Size}";

        StringBuilder sb = new();

        sb.AppendLine("#include \"fonts.h\"");
        sb.AppendLine();
        sb.AppendLine($"const uint8_t {fontName}_Table[] = ");
        sb.AppendLine("{");

        Console.Write("Processing: ");
        Image<L8> img = new((int)maxSize.Width, (int)maxSize.Height);
        int index = 0;
        foreach (var c in Alphabet) {
            var str = c.ToString();
            Console.Write(str);
            var cs = TextMeasurer.MeasureAdvance(str, options);
            img.Mutate((context) => {
                context.Clear(Color.Black);
                context.DrawText(str, font, Color.White, new(0, 0));
            });
            
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

    private byte[] EncodeToBits(Image<L8> img) {
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
                byte pixel_value = img[x, y].PackedValue;

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