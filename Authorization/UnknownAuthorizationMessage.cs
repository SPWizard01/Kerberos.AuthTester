using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization
{
    public class UnknownAuthorizationMessage : AuthorizationMessage
    {
        private AuthorizationType _authorizationType;

        public override AuthorizationType AuthorizationType => _authorizationType;


        public UnknownAuthorizationMessage(string base64EncodedMessage, AuthorizationType authorizationType)
            : base(base64EncodedMessage)
        {
            _authorizationType = authorizationType;
        }

        protected override void InitMessageFromData(byte[] data)
        {
        }
    }

}
