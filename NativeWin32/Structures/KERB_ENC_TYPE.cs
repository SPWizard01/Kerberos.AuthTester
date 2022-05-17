namespace Kerb.AuthTester.NativeWin32.Structures
{
    //https://www.iana.org/assignments/kerberos_parameters/kerberos_parameters.xhtml
    //https://www.opencore.com/blog/2017/3/kerberos_encryption_types/
    public enum KERB_ENC_TYPE
    {
        Reserved_or_Unknown = 0,
        des_cbc_crc_deprecated = 1,
        des_cbc_md4_deprecated = 2,
        des_cbc_md5_deprecated = 3,
        des3_cbc_md5_deprecated = 5,
        des3_cbc_sha1_deprecated = 7,
        dsaWithSHA1_CmsOID = 9,
        md5WithRSAEncryption_CmsOID = 10,
        sha1WithRSAEncryption_CmsOID = 11,
        rc2CBC_EnvOID = 12,
        rsaEncryption_EnvOID = 13,
        rsaES_OAEP_ENV_OID = 14,
        des_ede3_cbc_Env_OID = 15,
        des3_cbc_sha1_kd_deprecated = 16,
        aes128_cts_hmac_sha1_96 = 17,
        aes256_cts_hmac_sha1_96 = 18,
        aes128_cts_hmac_sha256_128 = 19,
        aes256_cts_hmac_sha384_192 = 20,
        rc4_hmac_deprecated = 23,
        rc4_hmac_exp_deprecated = 24,
        camellia128_cts_cmac = 25,
        camellia256_cts_cmac = 26,
        subkey_keymaterial = 65
    }
}
