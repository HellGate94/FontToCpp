using DotMake.CommandLine;
using System.Runtime.Versioning;

namespace FontToCpp;

internal class Program {
    [SupportedOSPlatform("windows")]
    static void Main(string[] args) {
        Cli.Run<MakeFontCommand>(args);
    }
}
