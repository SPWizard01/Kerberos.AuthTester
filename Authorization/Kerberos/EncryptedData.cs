using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Kerberos
{
    public class EncryptedData
    {
        public EncryptionType EncryptionType { get; set; }

        public uint? KeyVersionNumber { get; set; }

        public byte[] Cipher { get; set; }
    }
}
