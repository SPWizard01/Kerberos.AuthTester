using Kerb.AuthTester.NativeWin32.Structures;

namespace Kerb.AuthTester.Models
{
    public class TreeViewTicket
    {

        public string ServerName { get; set; } = string.Empty;
        public string ServerRealm { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime RenewTime { get; set; }
        public KERB_ENC_TYPE EncryptionType { get; set; }
        public KERB_TICKET_FLAGS TicketFlags { get; set; }
    }
}
