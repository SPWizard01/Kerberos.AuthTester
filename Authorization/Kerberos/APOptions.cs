using System.Text.Json.Serialization;

namespace Kerb.AuthTester.Authorization.Kerberos
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Flags]
    public enum APOptions : uint
    {
        USE_SESSION_KEY = 0x40000000u,
        MUTUAL_REQUIRED = 0x20000000u
    }
}
