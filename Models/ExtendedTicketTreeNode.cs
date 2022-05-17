using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Models
{
    public class ExtendedTicketTreeNode : TicketTreeNode
    {
        public ExtendedTreeViewTicket ExTicket { get; set; }

        public ExtendedTicketTreeNode(ExtendedTreeViewTicket ticket) : base(ticket)
        {
            ExTicket = ticket;
            Nodes.Add($"Cache Flags: {ExTicket.CacheFlags}");
            Nodes.Add($"Session Key Type: {ExTicket.SessionKeyType}");
            Nodes.Add($"Client Name: {ExTicket.ClientName}");
            Nodes.Add($"Client Realm: {ExTicket.ClientRealm}");
            Nodes.Add($"Branch Id: {ExTicket.BranchId}");
            Nodes.Add($"Kdc Called: {ExTicket.KdcCalled}");
        }
    }
}
