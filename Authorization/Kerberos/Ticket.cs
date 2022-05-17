using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Kerberos
{
    public class Ticket
    {
        public int TicketVersionNumber { get; set; }

        public string Realm { get; set; }

        public PrincipalName ServiceName { get; set; }

        public EncryptedData EncPart { get; set; }
    }
}
