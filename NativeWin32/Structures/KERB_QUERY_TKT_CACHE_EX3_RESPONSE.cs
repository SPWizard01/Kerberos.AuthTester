namespace Kerb.AuthTester.NativeWin32.Structures
{
    public struct KERB_QUERY_TKT_CACHE_EX3_RESPONSE
    {
        public KERB_PROTOCOL_MESSAGE_TYPE MessageType;
        public int CountOfTickets;
        public KERB_TICKET_CACHE_INFO_EX3 Tickets;
    }
}
