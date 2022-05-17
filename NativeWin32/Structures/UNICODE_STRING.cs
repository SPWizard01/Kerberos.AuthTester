using System.Runtime.InteropServices;
using System.Text;

namespace Kerb.AuthTester.NativeWin32.Structures
{
    public struct UNICODE_STRING_GG
    {
        public ushort Length;

        public ushort MaximumLength;

        public IntPtr Buffer;
    }

    public struct UNICODE_STRING : IDisposable
    {
        public ushort Length;
        public ushort MaximumLength;
        private IntPtr Buffer;

        public UNICODE_STRING(string s)
        {
            //1char=2bytes in string
            Length = (ushort)(s.Length * 2);
            MaximumLength = (ushort)(Length + 2);
            Buffer = Marshal.StringToHGlobalUni(s);
        }

        public UNICODE_STRING(string s, IntPtr copyToPtr)
        {
            var bytes = Encoding.Unicode.GetBytes(s);
            Length = (ushort)bytes.Length;
            MaximumLength = (ushort)(Length + 2);
            Marshal.Copy(bytes, 0, copyToPtr, bytes.Length);
            Buffer = copyToPtr;
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(Buffer);
            Buffer = IntPtr.Zero;
        }

        public override string ToString()
        {
            return Marshal.PtrToStringUni(Buffer, Length / 2);
        }
    }
}
