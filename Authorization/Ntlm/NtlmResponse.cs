using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Ntlm
{
    public abstract class NtlmResponse
    {
        protected byte[] _buffer;

        public int Version { get; set; }

        public byte[] Response { get; set; }

        public NtlmResponse(byte[] ResponseBuffer)
        {
            _buffer = ResponseBuffer;
        }
    }
}
