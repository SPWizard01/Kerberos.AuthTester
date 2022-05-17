namespace Kerb.AuthTester
{
    partial class Start
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.lblSPN = new System.Windows.Forms.Label();
            this.lblDomain = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblAuthType = new System.Windows.Forms.Label();
            this.lblHttpResult = new System.Windows.Forms.Label();
            this.lblRequestDate = new System.Windows.Forms.Label();
            this.txtHttpHeaders = new System.Windows.Forms.TextBox();
            this.lblHttpHeaders = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlProxy = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.proxyCreds = new Kerb.AuthTester.CredentialsControl();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProxyUrl = new System.Windows.Forms.TextBox();
            this.cbxProxy = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.requestCreds = new Kerb.AuthTester.CredentialsControl();
            this.tabTickets = new System.Windows.Forms.TabPage();
            this.btnPurge = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tvTickets = new System.Windows.Forms.TreeView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.txtDecode = new System.Windows.Forms.TextBox();
            this.lblDecodeInfo = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpResult.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlProxy.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabTickets.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabTickets);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(708, 479);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnTest);
            this.tabPage1.Controls.Add(this.txtUrl);
            this.tabPage1.Controls.Add(this.grpResult);
            this.tabPage1.Controls.Add(this.lblUrl);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(700, 446);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Test";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(600, 5);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(94, 29);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(46, 6);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(548, 27);
            this.txtUrl.TabIndex = 0;
            // 
            // grpResult
            // 
            this.grpResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResult.Controls.Add(this.lblSPN);
            this.grpResult.Controls.Add(this.lblDomain);
            this.grpResult.Controls.Add(this.lblUser);
            this.grpResult.Controls.Add(this.lblAuthType);
            this.grpResult.Controls.Add(this.lblHttpResult);
            this.grpResult.Controls.Add(this.lblRequestDate);
            this.grpResult.Controls.Add(this.txtHttpHeaders);
            this.grpResult.Controls.Add(this.lblHttpHeaders);
            this.grpResult.Controls.Add(this.label13);
            this.grpResult.Controls.Add(this.label12);
            this.grpResult.Controls.Add(this.label11);
            this.grpResult.Controls.Add(this.label10);
            this.grpResult.Controls.Add(this.label9);
            this.grpResult.Controls.Add(this.label8);
            this.grpResult.Location = new System.Drawing.Point(6, 39);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(688, 401);
            this.grpResult.TabIndex = 1;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "Result";
            // 
            // lblSPN
            // 
            this.lblSPN.AutoSize = true;
            this.lblSPN.Location = new System.Drawing.Point(47, 133);
            this.lblSPN.Name = "lblSPN";
            this.lblSPN.Size = new System.Drawing.Size(15, 20);
            this.lblSPN.TabIndex = 13;
            this.lblSPN.Text = "-";
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Location = new System.Drawing.Point(77, 111);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(15, 20);
            this.lblDomain.TabIndex = 12;
            this.lblDomain.Text = "-";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(53, 89);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(15, 20);
            this.lblUser.TabIndex = 11;
            this.lblUser.Text = "-";
            // 
            // lblAuthType
            // 
            this.lblAuthType.AutoSize = true;
            this.lblAuthType.Location = new System.Drawing.Point(154, 67);
            this.lblAuthType.Name = "lblAuthType";
            this.lblAuthType.Size = new System.Drawing.Size(15, 20);
            this.lblAuthType.TabIndex = 10;
            this.lblAuthType.Text = "-";
            // 
            // lblHttpResult
            // 
            this.lblHttpResult.AutoSize = true;
            this.lblHttpResult.Location = new System.Drawing.Point(103, 45);
            this.lblHttpResult.Name = "lblHttpResult";
            this.lblHttpResult.Size = new System.Drawing.Size(15, 20);
            this.lblHttpResult.TabIndex = 9;
            this.lblHttpResult.Text = "-";
            // 
            // lblRequestDate
            // 
            this.lblRequestDate.AutoSize = true;
            this.lblRequestDate.Location = new System.Drawing.Point(113, 23);
            this.lblRequestDate.Name = "lblRequestDate";
            this.lblRequestDate.Size = new System.Drawing.Size(15, 20);
            this.lblRequestDate.TabIndex = 8;
            this.lblRequestDate.Text = "-";
            // 
            // txtHttpHeaders
            // 
            this.txtHttpHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHttpHeaders.Location = new System.Drawing.Point(6, 178);
            this.txtHttpHeaders.Multiline = true;
            this.txtHttpHeaders.Name = "txtHttpHeaders";
            this.txtHttpHeaders.ReadOnly = true;
            this.txtHttpHeaders.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHttpHeaders.Size = new System.Drawing.Size(676, 217);
            this.txtHttpHeaders.TabIndex = 7;
            // 
            // lblHttpHeaders
            // 
            this.lblHttpHeaders.AutoSize = true;
            this.lblHttpHeaders.Location = new System.Drawing.Point(6, 155);
            this.lblHttpHeaders.Name = "lblHttpHeaders";
            this.lblHttpHeaders.Size = new System.Drawing.Size(106, 20);
            this.lblHttpHeaders.TabIndex = 6;
            this.lblHttpHeaders.Text = "HTTP Headers:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 133);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 20);
            this.label13.TabIndex = 5;
            this.label13.Text = "SPN:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "Domain:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "User:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Authentication type:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "HTTP Result:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Request Date:";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(12, 9);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(28, 20);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "Url";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(700, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.pnlProxy);
            this.groupBox2.Controls.Add(this.cbxProxy);
            this.groupBox2.Location = new System.Drawing.Point(353, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 434);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Proxy Settings";
            // 
            // pnlProxy
            // 
            this.pnlProxy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProxy.Controls.Add(this.groupBox3);
            this.pnlProxy.Controls.Add(this.label6);
            this.pnlProxy.Controls.Add(this.txtProxyUrl);
            this.pnlProxy.Enabled = false;
            this.pnlProxy.Location = new System.Drawing.Point(6, 56);
            this.pnlProxy.Name = "pnlProxy";
            this.pnlProxy.Size = new System.Drawing.Size(329, 372);
            this.pnlProxy.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.proxyCreds);
            this.groupBox3.Location = new System.Drawing.Point(4, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(322, 306);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Proxy Credentials:";
            // 
            // proxyCreds
            // 
            this.proxyCreds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.proxyCreds.Location = new System.Drawing.Point(6, 26);
            this.proxyCreds.Name = "proxyCreds";
            this.proxyCreds.Size = new System.Drawing.Size(310, 274);
            this.proxyCreds.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Proxy Url:";
            // 
            // txtProxyUrl
            // 
            this.txtProxyUrl.Location = new System.Drawing.Point(3, 30);
            this.txtProxyUrl.Name = "txtProxyUrl";
            this.txtProxyUrl.Size = new System.Drawing.Size(323, 27);
            this.txtProxyUrl.TabIndex = 2;
            // 
            // cbxProxy
            // 
            this.cbxProxy.AutoSize = true;
            this.cbxProxy.Location = new System.Drawing.Point(6, 26);
            this.cbxProxy.Name = "cbxProxy";
            this.cbxProxy.Size = new System.Drawing.Size(95, 24);
            this.cbxProxy.TabIndex = 0;
            this.cbxProxy.Text = "Use Proxy";
            this.cbxProxy.UseVisualStyleBackColor = true;
            this.cbxProxy.CheckedChanged += new System.EventHandler(this.cbxProxy_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.requestCreds);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 434);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Web request credentials";
            // 
            // requestCreds
            // 
            this.requestCreds.Location = new System.Drawing.Point(6, 26);
            this.requestCreds.Name = "requestCreds";
            this.requestCreds.Size = new System.Drawing.Size(307, 275);
            this.requestCreds.TabIndex = 0;
            // 
            // tabTickets
            // 
            this.tabTickets.Controls.Add(this.btnPurge);
            this.tabTickets.Controls.Add(this.btnDelete);
            this.tabTickets.Controls.Add(this.btnRefresh);
            this.tabTickets.Controls.Add(this.tvTickets);
            this.tabTickets.Location = new System.Drawing.Point(4, 29);
            this.tabTickets.Name = "tabTickets";
            this.tabTickets.Padding = new System.Windows.Forms.Padding(3);
            this.tabTickets.Size = new System.Drawing.Size(700, 446);
            this.tabTickets.TabIndex = 2;
            this.tabTickets.Text = "Tickets";
            this.tabTickets.UseVisualStyleBackColor = true;
            this.tabTickets.Enter += new System.EventHandler(this.tabTickets_Enter);
            // 
            // btnPurge
            // 
            this.btnPurge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPurge.Location = new System.Drawing.Point(600, 411);
            this.btnPurge.Name = "btnPurge";
            this.btnPurge.Size = new System.Drawing.Size(94, 29);
            this.btnPurge.TabIndex = 3;
            this.btnPurge.Text = "Purge!";
            this.btnPurge.UseVisualStyleBackColor = true;
            this.btnPurge.Click += new System.EventHandler(this.btnPurge_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(500, 411);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 29);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(6, 411);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 29);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tvTickets
            // 
            this.tvTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvTickets.Location = new System.Drawing.Point(6, 6);
            this.tvTickets.Name = "tvTickets";
            this.tvTickets.Size = new System.Drawing.Size(688, 371);
            this.tvTickets.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnClear);
            this.tabPage4.Controls.Add(this.btnDecode);
            this.tabPage4.Controls.Add(this.txtDecode);
            this.tabPage4.Controls.Add(this.lblDecodeInfo);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(700, 446);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Decode";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(600, 411);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 29);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecode.Location = new System.Drawing.Point(500, 411);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(94, 29);
            this.btnDecode.TabIndex = 2;
            this.btnDecode.Text = "Decode";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // txtDecode
            // 
            this.txtDecode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecode.Location = new System.Drawing.Point(6, 26);
            this.txtDecode.Multiline = true;
            this.txtDecode.Name = "txtDecode";
            this.txtDecode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDecode.Size = new System.Drawing.Size(688, 379);
            this.txtDecode.TabIndex = 1;
            // 
            // lblDecodeInfo
            // 
            this.lblDecodeInfo.AutoSize = true;
            this.lblDecodeInfo.Location = new System.Drawing.Point(6, 3);
            this.lblDecodeInfo.Name = "lblDecodeInfo";
            this.lblDecodeInfo.Size = new System.Drawing.Size(472, 20);
            this.lblDecodeInfo.TabIndex = 0;
            this.lblDecodeInfo.Text = "Paste ticket from HTTP header (i.e. Authorization: Negotiate YIINgg.....)";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.linkLabel2);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.label2);
            this.tabPage5.Controls.Add(this.label1);
            this.tabPage5.Controls.Add(this.linkLabel1);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(700, 446);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "About";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(154, 164);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(213, 20);
            this.linkLabel2.TabIndex = 6;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://github.com/spwizard01";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ported by: SPWizard";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Website:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Originally Created by: Michel Barneveld";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Version 0.9.4 beta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kerberos Authentication Tester";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(77, 111);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(210, 20);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://blog.michelbarneveld.nl";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 503);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(750, 550);
            this.Name = "Start";
            this.Text = "Kerb. Auth. Tester";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpResult.ResumeLayout(false);
            this.grpResult.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlProxy.ResumeLayout(false);
            this.pnlProxy.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabTickets.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabTickets;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private LinkLabel linkLabel1;
        private Label label5;
        private GroupBox groupBox1;
        private CredentialsControl requestCreds;
        private GroupBox groupBox2;
        private TextBox txtProxyUrl;
        private Label label6;
        private CheckBox cbxProxy;
        private Panel pnlProxy;
        private GroupBox groupBox3;
        private CredentialsControl proxyCreds;
        private TreeView tvTickets;
        private Button btnRefresh;
        private Button btnPurge;
        private Button btnDelete;
        private Button btnClear;
        private Button btnDecode;
        private TextBox txtDecode;
        private Label lblDecodeInfo;
        private Button btnTest;
        private TextBox txtUrl;
        private GroupBox grpResult;
        private TextBox txtHttpHeaders;
        private Label lblHttpHeaders;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label lblUrl;
        private Label lblUser;
        private Label lblAuthType;
        private Label lblHttpResult;
        private Label lblRequestDate;
        private Label lblDomain;
        private Label lblSPN;
        private LinkLabel linkLabel2;
    }
}