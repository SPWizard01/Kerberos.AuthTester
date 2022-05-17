using Kerb.AuthTester.Models;
using Kerb.AuthTester.Utilities.Kerberos;
using System.Diagnostics;
using System.Net;

namespace Kerb.AuthTester
{
    public partial class Start : Form
    {
        private TicketsManager _ticketManager = new TicketsManager();

        public Start()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { UseShellExecute = true, FileName = "http://mbar.nl/default.aspx?kat0.9.3" });
        }

        private void cbxProxy_CheckedChanged(object sender, EventArgs e)
        {
            pnlProxy.Enabled = cbxProxy.Checked;
        }

        private void RefreshTicketList()
        {
            var tickets = _ticketManager.GetExtendedTickets();
            tvTickets.Nodes.Clear();
            foreach (var item in tickets)
            {
                AddTicketNode(tvTickets, item);
            }
        }
        private void AddTicketNode(TreeView tree, ExtendedTreeViewTicket ticket)
        {
            tree.Nodes.Add(new ExtendedTicketTreeNode(ticket));
        }

        private void tabTickets_Enter(object sender, EventArgs e)
        {
            RefreshTicketList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tvTickets.SelectedNode != null)
            {
                var node = (TicketTreeNode)tvTickets.SelectedNode;
                _ticketManager.RemoveTicketFromCache(node.Ticket);
                RefreshTicketList();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTicketList();
        }

        private void btnPurge_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure?", "Purge all user tickets", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            _ticketManager.PurgeAllTickets();
            RefreshTicketList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDecode.Text = string.Empty;
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            var authorizationDetails = new AuthorizationDetails(txtDecode.Text);
            authorizationDetails.ShowDialog();
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                return;
            }
            InitializeLabels();
            var creds = requestCreds.GetCredentials();
            WebProxy? pxy = null;
            if (cbxProxy.Checked && !string.IsNullOrWhiteSpace(txtProxyUrl.Text))
            {
                pxy = new WebProxy(txtProxyUrl.Text);
                pxy.Credentials = proxyCreds.GetCredentials();
            }

            var wr = new AuthTestRequest(txtUrl.Text, creds, pxy);
            btnTest.Text = "Wait...";
            btnTest.Enabled = false;
            txtUrl.Enabled = false;
            await wr.DoRequest();
            PopulateControls(wr);
            btnTest.Text = "Test";
            btnTest.Enabled = true;
            txtUrl.Enabled = true;
        }

        private void PopulateControls(AuthTestRequest wr)
        {
            if (!string.IsNullOrWhiteSpace(wr.ErrorMessage))
            {
                txtHttpHeaders.Text = wr.ErrorMessage;
                return;
            }
            lblAuthType.Text = $"{wr.AuthorizationType}";
            lblRequestDate.Text = $"{wr.RequestDate}";
            lblHttpResult.Text = $"{wr.HttpResult}";
            lblUser.Text = $"{wr.UserName}";
            lblDomain.Text = $"{wr.Domain}";
            lblSPN.Text = $"{wr.SPN}";
            txtHttpHeaders.Text = "----Request Headers----" + Environment.NewLine;
            foreach (var reqHdr in wr.RequestHeaders)
            {
                txtHttpHeaders.Text += reqHdr.ToString() + Environment.NewLine;
            }
            txtHttpHeaders.Text += Environment.NewLine + Environment.NewLine;
            txtHttpHeaders.Text += "----Response Headers----" + Environment.NewLine;
            foreach (var respHeader in wr.ResponseHeaders)
            {
                txtHttpHeaders.Text += respHeader.ToString() + Environment.NewLine;
            }
        }

        private void InitializeLabels()
        {
            var defaulLabel = "-";
            lblRequestDate.Text = defaulLabel;
            lblHttpResult.Text = defaulLabel;
            lblAuthType.Text = defaulLabel;
            lblUser.Text = defaulLabel;
            lblDomain.Text = defaulLabel;
            lblSPN.Text = defaulLabel;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { UseShellExecute = true, FileName = "https://github.com/spwizard01" });
        }
    }
}