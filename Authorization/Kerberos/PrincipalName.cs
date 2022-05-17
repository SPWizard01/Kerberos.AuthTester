using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Kerberos
{
    public class PrincipalName
    {
        public PrincipalNameType NameType { get; set; }

        public List<string> NameString { get; set; }

        public override string ToString()
        {
            if (NameString.Count == 2)
            {
                return $"{NameString[0]}/{NameString[1]}";
            }
            if (NameString.Count == 3)
            {
                return $"{NameString[0]}/{NameString[1]}:{NameString[2]}";
            }
            return "";
        }
    }
}
