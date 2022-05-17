using System.Text.Json.Serialization;

namespace Kerb.AuthTester.Authorization.Kerberos
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EncryptionType
    {
        UNKNOWN = -1,
        NULL = 0,
        DES_CBC_CRC = 1,
        DES_CBC_MD4 = 2,
        DES_CBC_MD5 = 3,
        RESERVED4 = 4,
        DES3_CBC_MD5 = 5,
        RESERVED6 = 6,
        DES3_CBC_SHA1 = 7,
        DSAWITHSHA1_CMSOID = 9,
        MD5WITHRSAENCRYPTION_CMSOID = 10,
        SHA1WITHRSAENCRYPTION_CMSOID = 11,
        RC2CBC_ENVOID = 12,
        RSAENCRYPTION_ENVOID = 13,
        RSAES_OAEP_ENV_OID = 14,
        DES_EDE3_CBC_ENV_OID = 0xF,
        DES3_CBC_SHA1_KD = 0x10,
        AES128_CTS_HMAC_SHA1_96 = 17,
        AES256_CTS_HMAC_SHA1_96 = 18,
        RC4_HMAC = 23,
        RC4_HMAC_EXP = 24,
        SUBKEY_KEYMATERIAL = 65,
        RC4_MD4 = -128,
        RC4_HMAC_OLD = -133,
        RC4_HMAC_OLD_EXP = -135
    }
}
