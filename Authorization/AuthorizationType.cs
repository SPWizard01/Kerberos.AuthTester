using System.Text.Json.Serialization;

namespace Kerb.AuthTester.Authorization
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AuthorizationType
    {
        None,
        Basic,
        Ntlm,
        Kerberos,
        Unknown
    }
}
