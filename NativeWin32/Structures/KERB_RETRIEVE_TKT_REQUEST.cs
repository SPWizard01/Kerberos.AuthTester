namespace Kerb.AuthTester.NativeWin32.Structures
{
    public struct KERB_RETRIEVE_TKT_REQUEST
    {
        public KERB_PROTOCOL_MESSAGE_TYPE MessageType;
        public long LogonId;
        public UNICODE_STRING TargetName;
        public ulong TicketFlags;
        public ulong CacheOptions;
        public long EncryptionType;
        public SEC_HANDLE SecHandle;
    }
}
