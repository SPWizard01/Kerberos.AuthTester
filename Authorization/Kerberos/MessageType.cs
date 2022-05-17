using System.Text.Json.Serialization;

namespace Kerb.AuthTester.Authorization.Kerberos
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MessageType
    {
        KRB_AS_REQ = 10,
        KRB_AS_REP = 11,
        KRB_TGS_REQ = 12,
        KRB_TGS_REP = 13,
        KRB_AP_REQ = 14,
        KRB_AP_REP = 0xF,
        KRB_RESERVED16 = 0x10,
        KRB_RESERVED17 = 17,
        KRB_SAFE = 20,
        KRB_PRIV = 21,
        KRB_CRED = 22,
        KRB_ERROR = 30
    }
}
