namespace Kerb.AuthTester.NativeWin32.Structures
{
    public struct KERB_QUERY_TKT_CACHE_RESPONSE
    {
        public KERB_PROTOCOL_MESSAGE_TYPE MessageType;
        public uint CountOfTickets;
        public KERB_TICKET_CACHE_INFO Tickets;
    }

    public struct KERB_QUERY_TKT_CACHE_RESPONSE_E
    {
        public KERB_PROTOCOL_MESSAGE_TYPE MessageType;
        public uint CountOfTickets;
    }
}
