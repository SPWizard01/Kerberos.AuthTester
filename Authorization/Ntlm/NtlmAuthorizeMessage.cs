using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Ntlm
{
    public class NtlmAuthorizeMessage : AuthorizationMessage
    {
        private byte[] _messageData;

        public override AuthorizationType AuthorizationType => AuthorizationType.Ntlm;
        public string Signature { get; set; }
        public int MessageType { get; set; }
        public byte[] LmChallengeResponse { get; set; }
        public NtlmResponse NtChallengeResponse { get; set; }
        public string DomainName { get; set; }
        public string UserName { get; set; }
        public string Workstation { get; set; }
        public byte[] EncryptedRandomSessionKey { get; set; }
        public NegotiateFlags NegotiateFlags { get; set; }
        public Version Version { get; set; }
        public byte[] Mic { get; set; }



        public NtlmAuthorizeMessage(string base64EncodedMessage)
            : base(base64EncodedMessage)
        {
        }

        protected override void InitMessageFromData(byte[] data)
        {
            _messageData = data;
            Signature = Encoding.ASCII.GetString(_messageData, 0, 7);
            MessageType = BitConverter.ToInt32(_messageData, 8);
            SetLmChallengeResponse();
            SetNtChallengeResponse();
            DomainName = ConvertNtlmMessageByteArrayToString(28);
            UserName = ConvertNtlmMessageByteArrayToString(36);
            Workstation = ConvertNtlmMessageByteArrayToString(44);
            SetEncryptedRandomSessionKey();
            NegotiateFlags = (NegotiateFlags)BitConverter.ToUInt32(_messageData, 60);
            SetVersion();
            SetMic();
        }

        private void SetLmChallengeResponse()
        {
            short num = BitConverter.ToInt16(_messageData, 12);
            int num2 = BitConverter.ToInt32(_messageData, 16);
            if (num > 0 && num2 > 0)
            {
                LmChallengeResponse = new byte[num];
                Buffer.BlockCopy(_messageData, num2, LmChallengeResponse, 0, num);
            }
            else
            {
                LmChallengeResponse = new byte[0];
            }
        }

        private void SetNtChallengeResponse()
        {
            short num = BitConverter.ToInt16(_messageData, 20);
            int srcOffset = BitConverter.ToInt32(_messageData, 24);
            if (num > 0)
            {
                byte[] array = new byte[num];
                Buffer.BlockCopy(_messageData, srcOffset, array, 0, num);
                NtChallengeResponse = NtlmResponseFactory.CreateNtlmResponse(array);
            }
            else
            {
                NtChallengeResponse = null;
            }
        }

        private string ConvertNtlmMessageByteArrayToString(int Index)
        {
            short num = BitConverter.ToInt16(_messageData, Index);
            int index = BitConverter.ToInt32(_messageData, Index + 4);
            if (num > 0)
            {
                return Encoding.Unicode.GetString(_messageData, index, num);
            }
            return "";
        }

        private void SetEncryptedRandomSessionKey()
        {
            short num = BitConverter.ToInt16(_messageData, 52);
            int srcOffset = BitConverter.ToInt32(_messageData, 56);
            if (num > 0)
            {
                EncryptedRandomSessionKey = new byte[num];
                Buffer.BlockCopy(_messageData, srcOffset, EncryptedRandomSessionKey, 0, num);
            }
            else
            {
                EncryptedRandomSessionKey = new byte[0];
            }
        }

        private void SetVersion()
        {
            Version = new Version();
            Version.ProductMajorVersion = _messageData[64];
            Version.ProductMinorVersion = _messageData[65];
            Version.ProductBuild = BitConverter.ToUInt16(_messageData, 66);
            Version.NTLMRevisionCurrent = _messageData[71];
        }

        private void SetMic()
        {
            Mic = new byte[16];
            Buffer.BlockCopy(_messageData, 72, Mic, 0, 16);
        }
    }
}
