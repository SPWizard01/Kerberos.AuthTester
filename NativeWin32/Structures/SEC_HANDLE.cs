using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.NativeWin32.Structures
{
    public struct SEC_HANDLE
    {
        public IntPtr dwLower;
        public IntPtr dwUpper;
    }
}
