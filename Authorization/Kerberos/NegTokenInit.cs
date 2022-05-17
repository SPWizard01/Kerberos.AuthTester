using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Kerberos
{
    public class NegTokenInit : NegotiationToken
    {
        public List<MechType>? MechTypes { get; set; }

        public InitialContextToken? MechToken { get; set; }
    }
}
