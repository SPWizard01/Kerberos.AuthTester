using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Kerberos
{
    public class KerberosAuthorizeMessage : AuthorizationMessage
    {
        public override AuthorizationType AuthorizationType => AuthorizationType.Kerberos;
        public int TicketLength { get; set; }
        public MechType? MechType { get; set; }
        public NegTokenInit? NegotiationToken { get; set; }

        public KerberosAuthorizeMessage(string base64EncodedMessage)
            : base(base64EncodedMessage)
        {
            TicketLength = base64EncodedMessage.Length;
        }

        protected override void InitMessageFromData(byte[] data)
        {
            KerberosAuthorizeMessageBuilder.Build(this, data);
        }
    }
}
