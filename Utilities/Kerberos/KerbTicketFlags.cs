using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Utilities.Kerberos
{
    [Flags]
    public enum KerbTicketFlags : ulong
    {
        Forwardable = 0x40000000u,
        Forwarded = 0x20000000u,
        HWAuthent = 0x100000u,
        Initial = 0x400000u,
        Invalid = 0x1000000u,
        MayPostdate = 0x4000000u,
        OkAsDelegate = 0x40000u,
        Postdated = 0x2000000u,
        PreAuthent = 0x200000u,
        Proxiable = 0x10000000u,
        Proxy = 0x8000000u,
        Renewable = 0x800000u,
        Reserved = 0x80000000u,
        Reserved1 = 0x1u,
        Unknown = 0x0
    }


}
