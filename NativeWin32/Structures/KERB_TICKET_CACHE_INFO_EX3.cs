namespace Kerb.AuthTester.NativeWin32.Structures
{
    public struct KERB_TICKET_CACHE_INFO_EX3
    {
        public UNICODE_STRING ClientName;
        public UNICODE_STRING ClientRealm;
        public UNICODE_STRING ServerName;
        public UNICODE_STRING ServerRealm;
        public long StartTime;
        public long EndTime;
        public long RenewTime;
        public int EncryptionType;
        public int TicketFlags;
        public int SessionKeyType;
        public int BranchId;
        public int CacheFlags;
        public UNICODE_STRING KdcCalled;
    }
}