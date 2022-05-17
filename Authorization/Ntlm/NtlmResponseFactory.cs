using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Ntlm
{
    internal static class NtlmResponseFactory
    {
        public static NtlmResponse CreateNtlmResponse(byte[] Buffer)
        {
            if (Buffer.Length == 24)
            {
                return new NtlmV1Response(Buffer);
            }
            return new NtlmV2Response(Buffer);
        }
    }
}
