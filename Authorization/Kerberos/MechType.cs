using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Kerberos
{
    public class MechType
    {
        public string OID { get; private set; }

        public string Mechanism { get; private set; }

        public MechType(string strOID)
        {
            OID = strOID;
            Mechanism = LookupMechanism(OID);
        }

        private static string LookupMechanism(string OID)
        {
            return OID switch
            {
                "1.3.6.1.5.5.2" => "SPNEGO pseudo-mechanism (RFC2478)",
                "1.2.840.48018.1.2.2" => "Kerberos v5 Legacy",
                "1.2.840.113554.1.2.2" => "Kerberos v5",
                "1.3.6.1.4.1.311.2.2.10" => "NTLMSSP - Microsoft NTLM Security Support Provider",
                "1.3.6.1.4.1.311.2.2.30" => "NEGOEX - check MS-NEGOEX and MS-SPNG",
                _ => "Unknown",
            };
        }
    }
}
