namespace Kerb.AuthTester.NativeWin32.Structures
{
    public struct LUID
    {
        public uint LowPart;
        public int HighPart;

        public static implicit operator ulong(LUID luid)
        {
            ulong val = (ulong)luid.HighPart << 32;

            return val + luid.LowPart;
        }

        public static implicit operator LUID(long luid)
        {
            return new LUID
            {
                LowPart = (uint)(luid & 0xffffffffL),
                HighPart = (int)(luid >> 32)
            };
        }
    }
}
