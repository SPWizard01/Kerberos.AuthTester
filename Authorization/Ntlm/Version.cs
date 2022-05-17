using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Ntlm
{
    public class Version
    {
        public byte ProductMajorVersion { get; set; }

        public byte ProductMinorVersion { get; set; }

        public ushort ProductBuild { get; set; }

        public byte NTLMRevisionCurrent { get; set; }
    }
}
