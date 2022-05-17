using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.NativeWin32.Structures
{
    public struct KERB_EXTERNAL_TICKET
    {
        public IntPtr ServiceName;
        public IntPtr TargetName;
        public IntPtr ClientName;
        public UNICODE_STRING DomainName;
        public UNICODE_STRING TargetDomainName;
        public UNICODE_STRING AltTargetDomainName;
        public KERB_CRYPTO_KEY SessionKey;
        public uint TicketFlags;
        public uint Flags;
        public long KeyExpirationTime;
        public long StartTime;
        public long EndTime;
        public long RenewUntil;
        public long TimeSkew;
        public int EncodedTicketSize;
        public IntPtr EncodedTicket;
    }
}
