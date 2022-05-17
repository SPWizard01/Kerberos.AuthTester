using Kerb.AuthTester.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Kerb.AuthTester
{
    public partial class AuthorizationDetails : Form
    {
        private const string AUTH_START = "Authorization: ";
        private string auth;
        private AuthorizationMessage? AuthMsg;
        public AuthorizationDetails(string authHeader)
        {
            auth = authHeader;
            InitializeComponent();
            Cursor = Cursors.WaitCursor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AuthorizationDetails_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(auth) || !auth.StartsWith(AUTH_START))
            {
                MessageBox.Show($"Message should be in correct format, ({AUTH_START}) is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Close();
            }
            AuthMsg = AuthorizationMessageFactory.Build(auth.Split(AUTH_START)[1]);
            try
            {
                var ty = AuthMsg.GetType();
                var b = JsonSerializer.SerializeToDocument(AuthMsg, ty);
                FillTree(b);
                treeDetails.SelectedNode = treeDetails.Nodes[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing ticket. Details window will be closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Close();
            }

            Cursor = Cursors.Default;
        }

        private void EnumerateJson(TreeNodeCollection targetTree, JsonElement jsonElement)
        {
            if (jsonElement.ValueKind != JsonValueKind.Array && jsonElement.ValueKind != JsonValueKind.Object)
            {
                targetTree.Add(new TreeNode($"Value: {jsonElement}"));
                return;
            }
            if (jsonElement.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in jsonElement.EnumerateArray())
                {
                    var newTree = new TreeNode("Values");
                    targetTree.Add(newTree);
                    EnumerateJson(newTree.Nodes, item);
                }
                return;
            }

            foreach (var item in jsonElement.EnumerateObject())
            {
                var newTree = new TreeNode($"{item.Name}");
                targetTree.Add(newTree);
                EnumerateJson(newTree.Nodes, item.Value);
            }
        }

        private void FillTree(JsonDocument doc)
        {
            treeDetails.Nodes.Clear();
            EnumerateJson(treeDetails.Nodes, doc.RootElement);
            treeDetails.ExpandAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AuthMsg == null)
            {
                return;
            }

            try
            {
                var saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FileName = string.Format("{1}_{0}.json", AuthMsg.AuthorizationType.ToString(), DateTime.Now.ToString("yyyymmddhhmmss"));
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using StreamWriter streamWriter = File.CreateText(saveFileDialog1.FileName);
                    var ty = AuthMsg.GetType();
                    var a = JsonSerializer.Serialize(AuthMsg, ty);
                    streamWriter.Write(a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Saving file failed.\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }
    }
}
