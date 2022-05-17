using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Models
{
    public class TicketTreeNode : TreeNode
    {
        public TreeViewTicket Ticket { get; private set; }

        public TicketTreeNode(TreeViewTicket ticket)
        {
            Ticket = ticket;
            Text = Ticket.ServerName + "@" + Ticket.ServerRealm;
            Nodes.Add($"Server Name: {Ticket.ServerName}");
            Nodes.Add($"Server Realm: {Ticket.ServerRealm}");
            Nodes.Add($"Start Time: {Ticket.StartTime}");
            Nodes.Add($"End Time: {Ticket.EndTime}");
            Nodes.Add($"Renew Time: {Ticket.RenewTime}");
            Nodes.Add($"Encryption Type: {Ticket.EncryptionType}");
            Nodes.Add($"Ticket Flags: {Ticket.TicketFlags}");
        }

        public override string ToString()
        {
            return Ticket.ServerName + "@" + Ticket.ServerRealm;
        }
    }
}
