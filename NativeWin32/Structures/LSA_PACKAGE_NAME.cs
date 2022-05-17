namespace Kerb.AuthTester.NativeWin32.Structures
{
    //https://docs.microsoft.com/en-us/windows/win32/api/ntsecapi/nf-ntsecapi-lsalookupauthenticationpackage

    public enum LSA_PACKAGE_NAME
    {
        MSV1_0_PACKAGE_NAME,
        MICROSOFT_KERBEROS_NAME_A,
        NEGOSSP_NAME_A,
        NTLMSP_NAME_A

        //MSV1_0_PACKAGE_NAME
        //ANSI version of the MSV1_0 authentication package name.
        //MICROSOFT_KERBEROS_NAME_A
        //ANSI version of the Kerberos authentication package name.
        //NEGOSSP_NAME_A
        //ANSI version of the Negotiate authentication package name.
    }
}
