using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Ntlm
{
    public class NtlmV2Response : NtlmResponse
    {
        public NtlmV2ClientChallenge NtlmV2ClientChallenge { get; set; }


        public NtlmV2Response(byte[] ResponseBuffer)
            : base(ResponseBuffer)
        {
            SetValues();
        }

        private void SetValues()
        {
            Version = 2;
            SetResponse();
            NtlmV2ClientChallenge = new NtlmV2ClientChallenge(_buffer, 16);
        }

        private void SetResponse()
        {
            Response = new byte[16];
            Buffer.BlockCopy(_buffer, 0, Response, 0, 16);
        }
    }
}
