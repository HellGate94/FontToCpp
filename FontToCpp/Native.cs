using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace FontToCpp;
public static partial class KerningHelper {
    [LibraryImport("gdi32.dll")]
    public static partial int GetKerningPairsW(
        IntPtr hdc,
        uint cPairs,
        [In, Out] KERNINGPAIR[] lpKernPair
    );

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct KERNINGPAIR {
        public uint first;
        public uint second;
        public int kernAmount;
    }

    [SupportedOSPlatform("windows")]
    public static int GetKerning(char char1, char char2, Graphics g) {
        nint hdc = g.GetHdc();

        const uint cPairs = 1;
        KERNINGPAIR[] lpKernPair = new KERNINGPAIR[cPairs];
        lpKernPair[0].first = char1;
        lpKernPair[0].second = char2;

        int result = GetKerningPairsW(hdc, cPairs, lpKernPair);

        g.ReleaseHdc(hdc);

        if (result > 0) {
            return lpKernPair[0].kernAmount;
        } else {
            return 0;
        }
    }
}