using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Ntlm
{
    public class NtlmV2ClientChallenge
    {
        private byte[] _buffer;

        private int _index;

        public byte ResponseType { get; set; }

        public byte HiResponseType { get; set; }

        public ushort Reserved1 { get; set; }

        public uint Reserved2 { get; set; }

        public DateTime TimeStamp { get; set; }

        public byte[] ChallengeFromClient { get; set; }

        public uint Reserved3 { get; set; }

        public AvPairs AvPairs { get; set; }

        public NtlmV2ClientChallenge(byte[] Buffer, int Index)
        {
            _buffer = Buffer;
            _index = Index;
            SetValues();
        }

        private void SetValues()
        {
            ResponseType = _buffer[_index];
            HiResponseType = _buffer[_index + 1];
            Reserved1 = BitConverter.ToUInt16(_buffer, _index + 2);
            Reserved2 = BitConverter.ToUInt32(_buffer, _index + 4);
            SetTimeStamp();
            SetChallengeFromClient();
            Reserved3 = BitConverter.ToUInt32(_buffer, _index + 24);
            AvPairs = new AvPairs(_buffer, _index + 28);
        }

        private void SetTimeStamp()
        {
            long fileTime = BitConverter.ToInt64(_buffer, _index + 8);
            TimeStamp = DateTime.FromFileTime(fileTime);
        }

        private void SetChallengeFromClient()
        {
            ChallengeFromClient = new byte[8];
            Buffer.BlockCopy(_buffer, _index + 16, ChallengeFromClient, 0, 8);
        }
    }

}
