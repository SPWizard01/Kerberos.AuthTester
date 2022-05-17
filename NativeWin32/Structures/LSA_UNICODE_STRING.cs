using System.Runtime.InteropServices;

namespace Kerb.AuthTester.NativeWin32.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LSA_UNICODE_STRING
    {
        public ushort Length;
        public ushort MaximumLength;
        public IntPtr Buffer;
    }
}
