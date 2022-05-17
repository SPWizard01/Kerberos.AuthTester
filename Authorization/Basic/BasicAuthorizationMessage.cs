using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Basic
{
    public class BasicAuthorizationMessage : AuthorizationMessage
    {
        public override AuthorizationType AuthorizationType => AuthorizationType.Basic;
        public string UserName { get; set; }
        public string Password { get; set; }



        public BasicAuthorizationMessage(string base64EncodedMessage)
            : base(base64EncodedMessage)
        {
        }

        protected override void InitMessageFromData(byte[] data)
        {
            string encStr = Encoding.ASCII.GetString(data);
            int num = encStr.IndexOf(':');
            UserName = encStr.Substring(0, num);
            Password = encStr.Substring(num + 1);
        }
    }
}
