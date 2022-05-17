using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Kerberos
{
    public class KrbApReq
    {
        public int ProtocolVersionNumber { get; set; }
        public MessageType MessageType { get; set; }

        public APOptions APOptions { get; set; }

        public Ticket Ticket { get; set; }

        public EncryptedData Authenticator { get; set; }
    }
}
