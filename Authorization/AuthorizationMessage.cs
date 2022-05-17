using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization
{
    public abstract class AuthorizationMessage
    {
        public abstract AuthorizationType AuthorizationType { get; }

        public AuthorizationMessage()
        {
        }
        public AuthorizationMessage(string base64EncodedMessage)
        {
            byte[] data = Convert.FromBase64String(base64EncodedMessage);
            InitMessageFromData(data);
        }

        protected abstract void InitMessageFromData(byte[] data);
    }
}
