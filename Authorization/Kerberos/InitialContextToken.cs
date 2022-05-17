namespace Kerb.AuthTester.Authorization.Kerberos
{
    public class InitialContextToken
    {
        public MechType? ThisMech { get; set; }

        public KrbApReq? InnerContextToken { get; set; }
    }
}
