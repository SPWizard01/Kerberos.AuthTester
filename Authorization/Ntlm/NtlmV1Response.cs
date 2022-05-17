using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Ntlm
{
    public class NtlmV1Response : NtlmResponse
    {

        public NtlmV1Response(byte[] ResponseBuffer)
            : base(ResponseBuffer)
        {
            Response = ResponseBuffer;
        }
    }

}
