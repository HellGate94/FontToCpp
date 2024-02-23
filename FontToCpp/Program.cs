using DotMake.CommandLine;

namespace FontToCpp;

internal class Program {
    static void Main(string[] args) {
        Cli.Run<MakeFontCommand>(args);
    }
}
