using Kerb.AuthTester.Win32.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Models
{
    public class ExtendedTreeViewTicket : TreeViewTicket
    {
        public string ClientName { get; set; } = string.Empty;
        public string ClientRealm { get; set; } = string.Empty;
        public KERB_CACHE_FLAGS CacheFlags { get; set; }
        public KERB_ENC_TYPE SessionKeyType { get; set; }
        public int BranchId { get; set; }
        public string KdcCalled { get; set; } = string.Empty;
    }
}
