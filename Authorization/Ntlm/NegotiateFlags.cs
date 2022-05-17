using System.Text.Json.Serialization;

namespace Kerb.AuthTester.Authorization.Ntlm
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Flags]
    public enum NegotiateFlags : uint
    {
        None = 0x0u,
        NTLMSSP_NEGOTIATE_56 = 0x80000000u,
        NTLMSSP_NEGOTIATE_KEY_EXCH = 0x40000000u,
        NTLMSSP_NEGOTIATE_128 = 0x20000000u,
        Reserved1 = 0x10000000u,
        Reserved2 = 0x8000000u,
        Reserved3 = 0x4000000u,
        NTLMSSP_NEGOTIATE_VERSION = 0x2000000u,
        Reserved4 = 0x1000000u,
        NTLMSSP_NEGOTIATE_TARGET_INFO = 0x800000u,
        NTLMSSP_REQUEST_NON_NT_SESSION_KEY = 0x400000u,
        Reserved5 = 0x200000u,
        NTLMSSP_NEGOTIATE_IDENTIFY = 0x100000u,
        NTLMSSP_NEGOTIATE_EXTENDED_SESSIONSECURITY = 0x80000u,
        NTLMSSP_TARGET_TYPE_SHARE = 0x40000u,
        NTLMSSP_TARGET_TYPE_SERVER = 0x20000u,
        NTLMSSP_TARGET_TYPE_DOMAIN = 0x10000u,
        NTLMSSP_NEGOTIATE_ALWAYS_SIGN = 0x8000u,
        Reserved6 = 0x4000u,
        NTLMSSP_NEGOTIATE_OEM_WORKSTATION_SUPPLIED = 0x2000u,
        NTLMSSP_NEGOTIATE_OEM_DOMAIN_SUPPLIED = 0x1000u,
        NTLMSSP_ANONYMOUS_CONNECTION = 0x800u,
        NTLMSSP_NEGOTIATE_NT_ONLY = 0x400u,
        NTLMSSP_NEGOTIATE_NTLM = 0x200u,
        Reserved8 = 0x100u,
        NTLMSSP_NEGOTIATE_LM_KEY = 0x80u,
        NTLMSSP_NEGOTIATE_DATAGRAM = 0x40u,
        NTLMSSP_NEGOTIATE_SEAL = 0x20u,
        NTLMSSP_NEGOTIATE_SIGN = 0x10u,
        Reserved9 = 0x8u,
        NTLMSSP_REQUEST_TARGET = 0x4u,
        NTLM_NEGOTIATE_OEM = 0x2u,
        NTLMSSP_NEGOTIATE_UNICODE = 0x1u
    }
}
