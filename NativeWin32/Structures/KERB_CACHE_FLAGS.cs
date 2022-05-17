namespace Kerb.AuthTester.NativeWin32.Structures
{
    [Flags]
    public enum KERB_CACHE_FLAGS
    {
        Unknown = 0,
        Primary = 0x1,
        Delegation = 0x2,
    }
}
