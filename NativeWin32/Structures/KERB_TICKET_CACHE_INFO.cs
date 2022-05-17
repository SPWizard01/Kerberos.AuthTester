namespace Kerb.AuthTester.NativeWin32.Structures
{
    public struct KERB_TICKET_CACHE_INFO
    {
        public UNICODE_STRING ServerName;

        public UNICODE_STRING RealmName;

        public ulong StartTime;

        public ulong EndTime;

        public ulong RenewTime;

        public uint EncryptionType;

        public uint TicketFlags;
    }
}
