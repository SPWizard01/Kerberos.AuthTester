using Kerb.AuthTester.Utilities.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Models
{
    public class TicketCacheResponse<T>
    {
        public T Response { get; set; }
        public IntPtr ResponsePointer { get; set; } = IntPtr.Zero;
    }
}
