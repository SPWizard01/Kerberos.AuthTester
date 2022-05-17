namespace Kerb.AuthTester.NativeWin32.Structures
{
    public struct KERB_PURGE_TKT_CACHE_EX_REQUEST
    {
        public KERB_PROTOCOL_MESSAGE_TYPE MessageType;
        public LUID LogonId;
        public int Flags;
        public KERB_TICKET_CACHE_INFO_EX TicketTemplate;
    }
}
