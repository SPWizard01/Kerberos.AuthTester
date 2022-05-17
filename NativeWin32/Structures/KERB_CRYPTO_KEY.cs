namespace Kerb.AuthTester.NativeWin32.Structures
{
    //https://www.csharpcodi.com/vs2/1007/TraceLab/Main/external/ikvm/src/runtime/openjdk/sun.security.krb5.cs/
    public struct KERB_CRYPTO_KEY
    {
        public int KeyType;
        public int Length;
        public IntPtr Value;
    }
}
