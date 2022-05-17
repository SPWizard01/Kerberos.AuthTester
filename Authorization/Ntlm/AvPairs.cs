using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Ntlm
{
    public class AvPairs
    {
        private byte[] _buffer;

        private int _index;

        public string MsvAvNbComputerName;

        public string MsvAvNbDomainName;

        public string MsvAvDnsComputerName;

        public string MsvAvDnsDomainName;

        public string MsvAvDnsTreeName;

        public uint? MsvAvFlags;

        public DateTime? MsvAvTimestamp;

        public RestrictionEncoding MsAvRestrictions;

        public string MsvAvTargetName;

        public byte[] MsvChannelBindings;

        public AvPairs()
        {
        }

        public AvPairs(byte[] Buffer)
        {
            _buffer = Buffer;
            SetAvFields();
        }

        public AvPairs(byte[] Buffer, int Index)
        {
            _buffer = Buffer;
            _index = Index;
            SetAvFields();
        }

        private void SetAvFields()
        {
            AvType avType = AvType.MsvAvEOL;
            do
            {
                avType = (AvType)BitConverter.ToInt16(_buffer, _index);
                ushort num = BitConverter.ToUInt16(_buffer, _index + 2);
                _index += 4;
                switch (avType)
                {
                    case AvType.MsAvRestrictions:
                        {
                            byte[] array2 = new byte[num];
                            Buffer.BlockCopy(_buffer, _index, array2, 0, num);
                            MsAvRestrictions = new RestrictionEncoding(array2);
                            break;
                        }
                    case AvType.MsvAvDnsComputerName:
                        MsvAvDnsComputerName = Encoding.Unicode.GetString(_buffer, _index, num);
                        break;
                    case AvType.MsvAvDnsDomainName:
                        MsvAvDnsDomainName = Encoding.Unicode.GetString(_buffer, _index, num);
                        break;
                    case AvType.MsvAvDnsTreeName:
                        MsvAvDnsTreeName = Encoding.Unicode.GetString(_buffer, _index, num);
                        break;
                    case AvType.MsvAvFlags:
                        MsvAvFlags = BitConverter.ToUInt32(_buffer, _index);
                        break;
                    case AvType.MsvAvNbComputerName:
                        MsvAvNbComputerName = Encoding.Unicode.GetString(_buffer, _index, num);
                        break;
                    case AvType.MsvAvNbDomainName:
                        MsvAvNbDomainName = Encoding.Unicode.GetString(_buffer, _index, num);
                        break;
                    case AvType.MsvAvTargetName:
                        MsvAvTargetName = Encoding.Unicode.GetString(_buffer, _index, num);
                        break;
                    case AvType.MsvAvTimestamp:
                        if (num == 8)
                        {
                            long fileTime = BitConverter.ToInt64(_buffer, _index);
                            MsvAvTimestamp = DateTime.FromFileTime(fileTime);
                        }
                        break;
                    case AvType.MsvChannelBindings:
                        {
                            byte[] array = new byte[num];
                            Buffer.BlockCopy(_buffer, _index, array, 0, num);
                            MsvChannelBindings = array;
                            break;
                        }
                }
                _index += num;
            }
            while (avType != 0);
        }
    }
}
