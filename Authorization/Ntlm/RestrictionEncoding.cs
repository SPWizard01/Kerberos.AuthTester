using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Ntlm
{
    public class RestrictionEncoding
    {
        private byte[] _buffer;

        public uint Size { get; set; }

        public uint Z4 { get; set; }

        public uint IntegrityLevel { get; set; }

        public uint SubjectIntegrityLevel { get; set; }

        public byte[] MachineID { get; set; }

        public RestrictionEncoding(byte[] Buffer)
        {
            _buffer = Buffer;
            SetValues();
        }

        private void SetValues()
        {
            Size = BitConverter.ToUInt32(_buffer, 0);
            Z4 = BitConverter.ToUInt32(_buffer, 4);
            IntegrityLevel = BitConverter.ToUInt32(_buffer, 8);
            SubjectIntegrityLevel = BitConverter.ToUInt32(_buffer, 12);
            SetMachineID();
        }

        private void SetMachineID()
        {
            MachineID = new byte[32];
            Buffer.BlockCopy(_buffer, 16, MachineID, 0, 32);
        }
    }
}
