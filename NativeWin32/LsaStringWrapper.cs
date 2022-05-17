using Kerb.AuthTester.NativeWin32.Structures;
using System.Runtime.InteropServices;

namespace Kerb.AuthTester.NativeWin32
{
    public class LsaStringWrapper : IDisposable
    {
        public LSA_STRING _string;

        public LsaStringWrapper(string value)
        {
            _string = new LSA_STRING
            {
                Length = (ushort)value.Length,
                MaximumLength = (ushort)value.Length,
                Buffer = Marshal.StringToHGlobalAnsi(value)
            };

        }

        ~LsaStringWrapper()
        {
            Dispose(disposing: false);
        }

        private void Dispose(bool disposing)
        {
            if (_string.Buffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_string.Buffer);
                _string.Buffer = IntPtr.Zero;
            }
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }
    }
}
