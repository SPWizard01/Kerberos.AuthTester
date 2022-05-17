using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Models
{
    public class HeaderValue
    {
        public string Header { get; set; } = string.Empty;
        public string? Value { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"{Header}: {Value}";
        }
    }
}
