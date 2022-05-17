using Kerb.AuthTester.NativeWin32.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Models
{
    public class LsaPackage
    {
        //[Parameter(Mandatory = $true)]
        //[ValidateSet('MSV1_0_PACKAGE_NAME', 'MICROSOFT_KERBEROS_NAME_A', 'NEGOSSP_NAME_A', 'NTLMSP_NAME_A')]
        //[string]
        //$PackageName

        //    switch($PackageName)
        //    {
        //          MSV1_0_PACKAGE_NAME {$authPackageName = 'NTLM'; break}
        //          MICROSOFT_KERBEROS_NAME_A {$authPackageName = 'Kerberos'; break}
        //          NEGOSSP_NAME_A {$authPackageName = 'Negotiate'; break}
        //          NTLMSP_NAME_A {$authPackageName = 'NTLM'; break}
        //    }
        public string Name { get; private set; } = "Unknown";
        public LSA_STRING PLSA_STRING;
        public LsaPackage(LSA_PACKAGE_NAME packageName)
        {
            switch (packageName)
            {
                case LSA_PACKAGE_NAME.MSV1_0_PACKAGE_NAME:
                    Name = "NTLM";
                    break;
                case LSA_PACKAGE_NAME.MICROSOFT_KERBEROS_NAME_A:
                    Name = "Kerberos";
                    break;
                case LSA_PACKAGE_NAME.NEGOSSP_NAME_A:
                    Name = "Negotiate";
                    break;
                case LSA_PACKAGE_NAME.NTLMSP_NAME_A:
                    Name = "NTLM";
                    break;
                default:
                    Name = "Kerberos";
                    break;
            }
            PLSA_STRING = new LSA_STRING(Name);

        }
    }
}
