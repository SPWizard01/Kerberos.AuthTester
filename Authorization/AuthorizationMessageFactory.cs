
using Kerb.AuthTester.Authorization.Basic;
using Kerb.AuthTester.Authorization.Kerberos;
using Kerb.AuthTester.Authorization.Ntlm;
using System.Text;

namespace Kerb.AuthTester.Authorization
{
    public static class AuthorizationMessageFactory
    {
        public static AuthorizationMessage Build(string AuthorizationHeader)
        {
            string[] array = AuthorizationHeader.Split(' ');
            if (array.Length != 2)
            {
                throw new Exception("Unexpected Authorization Header");
            }
            AuthorizationType authorizationType = AuthorizationType.Unknown;
            try
            {
                switch (array[0].ToLower())
                {
                    case "ntlm":
                        authorizationType = AuthorizationType.Ntlm;
                        return new NtlmAuthorizeMessage(array[1]);
                    case "basic":
                        authorizationType = AuthorizationType.Basic;
                        return new BasicAuthorizationMessage(array[1]);
                    case "negotiate":
                        {
                            byte[] bytes = Convert.FromBase64String(array[1]);
                            if (Encoding.ASCII.GetString(bytes, 0, 4) == "NTLM")
                            {
                                authorizationType = AuthorizationType.Ntlm;
                                return new NtlmAuthorizeMessage(array[1]);
                            }
                            authorizationType = AuthorizationType.Kerberos;
                            return new KerberosAuthorizeMessage(array[1]);
                        }
                    default:
                        throw new Exception($"Unknown Authorization mechanism: {array[0]}");
                }
            }
            catch (Exception)
            {
                return new UnknownAuthorizationMessage(array[1], authorizationType);
            }
        }
    }
}