using System.Runtime.InteropServices;

namespace Kerb.AuthTester.NativeWin32.Structures
{
    public struct LSA_STRING : IDisposable
    {
        public ushort Length;
        public ushort MaximumLength;
        public IntPtr Buffer;

        public LSA_STRING(string str)
        {
            Length = (ushort)str.Length;
            MaximumLength = (ushort)str.Length;
            Buffer = Marshal.StringToHGlobalAnsi(str);
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(Buffer);
            Buffer = IntPtr.Zero;
        }
    }
}
