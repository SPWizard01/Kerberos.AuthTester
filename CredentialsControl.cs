using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kerb.AuthTester
{
    public partial class CredentialsControl : UserControl
    {
        public CredentialsControl()
        {
            InitializeComponent();
        }

        private void rbCustom_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = rbCustom.Checked;
        }

        public ICredentials? GetCredentials()
        {
            if (rbDefault.Checked)
            {
                return CredentialCache.DefaultNetworkCredentials;
            }
            if (rbCustom.Checked && string.IsNullOrWhiteSpace(txtDomain.Text))
            {
                return new NetworkCredential(txtUsername.Text, txtPassword.Text);
            }
            if (rbCustom.Checked)
            {
                return new NetworkCredential(txtUsername.Text, txtPassword.Text, txtDomain.Text);
            }
            return null;
        }
    }
}
