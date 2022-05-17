namespace Kerb.AuthTester.NativeWin32.Structures
{
    public struct KERB_PURGE_TKT_CACHE_REQUEST
    {
        public KERB_PROTOCOL_MESSAGE_TYPE MessageType;

        public LUID LogonId;

        public UNICODE_STRING ServerName;

        public UNICODE_STRING RealmName;
    }

    public struct KERB_PURGE_TKT_CACHE_REQUEST_GG
    {
        public KERB_PROTOCOL_MESSAGE_TYPE MessageType;

        public LUID LogonId;

        public UNICODE_STRING_GG ServerName;

        public UNICODE_STRING_GG RealmName;
    }
}
