namespace AfterFormat
{
    partial class frmAfterFormat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tbRegistry = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegRecommended = new System.Windows.Forms.Button();
            this.grpStart = new System.Windows.Forms.GroupBox();
            this.cbRegStaCPan = new System.Windows.Forms.CheckBox();
            this.cbRegStaNetw = new System.Windows.Forms.CheckBox();
            this.cbRegStaComp = new System.Windows.Forms.CheckBox();
            this.cbRegStaFavo = new System.Windows.Forms.CheckBox();
            this.cbRegStaDocs = new System.Windows.Forms.CheckBox();
            this.cbRegStaUser = new System.Windows.Forms.CheckBox();
            this.btnRegDefault = new System.Windows.Forms.Button();
            this.btnRegReset = new System.Windows.Forms.Button();
            this.grpExplorer = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.grpUAC = new System.Windows.Forms.GroupBox();
            this.cbUACPrompt = new System.Windows.Forms.CheckBox();
            this.cbUAC = new System.Windows.Forms.CheckBox();
            this.tbFolders = new System.Windows.Forms.TabPage();
            this.tbApplicationDownload = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbInstalled = new System.Windows.Forms.ListBox();
            this.lblRec = new System.Windows.Forms.Label();
            this.lbRecommended = new System.Windows.Forms.ListBox();
            this.tbApplicationsInstall = new System.Windows.Forms.TabPage();
            this.btnInstall = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDownloaded = new System.Windows.Forms.ListBox();
            this.lblSelectedAppName = new System.Windows.Forms.Label();
            this.lblSelectedAppVersion = new System.Windows.Forms.Label();
            this.tbMain.SuspendLayout();
            this.tbRegistry.SuspendLayout();
            this.grpStart.SuspendLayout();
            this.grpExplorer.SuspendLayout();
            this.grpUAC.SuspendLayout();
            this.tbApplicationDownload.SuspendLayout();
            this.tbApplicationsInstall.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tbRegistry);
            this.tbMain.Controls.Add(this.tbFolders);
            this.tbMain.Controls.Add(this.tbApplicationDownload);
            this.tbMain.Controls.Add(this.tbApplicationsInstall);
            this.tbMain.Location = new System.Drawing.Point(12, 12);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(560, 338);
            this.tbMain.TabIndex = 0;
            this.tbMain.TabIndexChanged += new System.EventHandler(this.tbMain_TabIndexChanged);
            // 
            // tbRegistry
            // 
            this.tbRegistry.Controls.Add(this.label3);
            this.tbRegistry.Controls.Add(this.btnRegRecommended);
            this.tbRegistry.Controls.Add(this.grpStart);
            this.tbRegistry.Controls.Add(this.btnRegDefault);
            this.tbRegistry.Controls.Add(this.btnRegReset);
            this.tbRegistry.Controls.Add(this.grpExplorer);
            this.tbRegistry.Controls.Add(this.grpUAC);
            this.tbRegistry.Location = new System.Drawing.Point(4, 22);
            this.tbRegistry.Name = "tbRegistry";
            this.tbRegistry.Padding = new System.Windows.Forms.Padding(3);
            this.tbRegistry.Size = new System.Drawing.Size(552, 312);
            this.tbRegistry.TabIndex = 0;
            this.tbRegistry.Text = "Registry Setup";
            this.tbRegistry.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(418, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 113);
            this.label3.TabIndex = 7;
            this.label3.Text = "Once ready from setting changes use the \'Reboot Explorer\' button. This will let y" +
    "ou see the changes made. Some options may need a system restart to take effect.";
            // 
            // btnRegRecommended
            // 
            this.btnRegRecommended.Location = new System.Drawing.Point(418, 254);
            this.btnRegRecommended.Name = "btnRegRecommended";
            this.btnRegRecommended.Size = new System.Drawing.Size(128, 23);
            this.btnRegRecommended.TabIndex = 6;
            this.btnRegRecommended.Text = "Set to Recommended";
            this.btnRegRecommended.UseVisualStyleBackColor = true;
            this.btnRegRecommended.Click += new System.EventHandler(this.btnRegRecommended_Click);
            // 
            // grpStart
            // 
            this.grpStart.Controls.Add(this.cbRegStaCPan);
            this.grpStart.Controls.Add(this.cbRegStaNetw);
            this.grpStart.Controls.Add(this.cbRegStaComp);
            this.grpStart.Controls.Add(this.cbRegStaFavo);
            this.grpStart.Controls.Add(this.cbRegStaDocs);
            this.grpStart.Controls.Add(this.cbRegStaUser);
            this.grpStart.Location = new System.Drawing.Point(6, 86);
            this.grpStart.Name = "grpStart";
            this.grpStart.Size = new System.Drawing.Size(200, 220);
            this.grpStart.TabIndex = 5;
            this.grpStart.TabStop = false;
            this.grpStart.Text = "Start Menu Settings";
            // 
            // cbRegStaCPan
            // 
            this.cbRegStaCPan.AutoSize = true;
            this.cbRegStaCPan.Location = new System.Drawing.Point(6, 134);
            this.cbRegStaCPan.Name = "cbRegStaCPan";
            this.cbRegStaCPan.Size = new System.Drawing.Size(119, 17);
            this.cbRegStaCPan.TabIndex = 1;
            this.cbRegStaCPan.Text = "Show Control Panel";
            this.cbRegStaCPan.UseVisualStyleBackColor = true;
            this.cbRegStaCPan.CheckedChanged += new System.EventHandler(this.cb_Start_CheckedChanged);
            // 
            // cbRegStaNetw
            // 
            this.cbRegStaNetw.AutoSize = true;
            this.cbRegStaNetw.Location = new System.Drawing.Point(6, 111);
            this.cbRegStaNetw.Name = "cbRegStaNetw";
            this.cbRegStaNetw.Size = new System.Drawing.Size(96, 17);
            this.cbRegStaNetw.TabIndex = 1;
            this.cbRegStaNetw.Text = "Show Network";
            this.cbRegStaNetw.UseVisualStyleBackColor = true;
            this.cbRegStaNetw.CheckedChanged += new System.EventHandler(this.cb_Start_CheckedChanged);
            // 
            // cbRegStaComp
            // 
            this.cbRegStaComp.AutoSize = true;
            this.cbRegStaComp.Location = new System.Drawing.Point(6, 88);
            this.cbRegStaComp.Name = "cbRegStaComp";
            this.cbRegStaComp.Size = new System.Drawing.Size(101, 17);
            this.cbRegStaComp.TabIndex = 1;
            this.cbRegStaComp.Text = "Show Computer";
            this.cbRegStaComp.UseVisualStyleBackColor = true;
            this.cbRegStaComp.CheckedChanged += new System.EventHandler(this.cb_Start_CheckedChanged);
            // 
            // cbRegStaFavo
            // 
            this.cbRegStaFavo.AutoSize = true;
            this.cbRegStaFavo.Location = new System.Drawing.Point(6, 65);
            this.cbRegStaFavo.Name = "cbRegStaFavo";
            this.cbRegStaFavo.Size = new System.Drawing.Size(99, 17);
            this.cbRegStaFavo.TabIndex = 1;
            this.cbRegStaFavo.Text = "Show Favorites";
            this.cbRegStaFavo.UseVisualStyleBackColor = true;
            this.cbRegStaFavo.CheckedChanged += new System.EventHandler(this.cb_Start_CheckedChanged);
            // 
            // cbRegStaDocs
            // 
            this.cbRegStaDocs.AutoSize = true;
            this.cbRegStaDocs.Location = new System.Drawing.Point(6, 42);
            this.cbRegStaDocs.Name = "cbRegStaDocs";
            this.cbRegStaDocs.Size = new System.Drawing.Size(110, 17);
            this.cbRegStaDocs.TabIndex = 1;
            this.cbRegStaDocs.Text = "Show Documents";
            this.cbRegStaDocs.UseVisualStyleBackColor = true;
            this.cbRegStaDocs.CheckedChanged += new System.EventHandler(this.cb_Start_CheckedChanged);
            // 
            // cbRegStaUser
            // 
            this.cbRegStaUser.AutoSize = true;
            this.cbRegStaUser.Location = new System.Drawing.Point(6, 19);
            this.cbRegStaUser.Name = "cbRegStaUser";
            this.cbRegStaUser.Size = new System.Drawing.Size(78, 17);
            this.cbRegStaUser.TabIndex = 1;
            this.cbRegStaUser.Text = "Show User";
            this.cbRegStaUser.UseVisualStyleBackColor = true;
            this.cbRegStaUser.CheckedChanged += new System.EventHandler(this.cb_Start_CheckedChanged);
            // 
            // btnRegDefault
            // 
            this.btnRegDefault.Location = new System.Drawing.Point(418, 283);
            this.btnRegDefault.Name = "btnRegDefault";
            this.btnRegDefault.Size = new System.Drawing.Size(128, 23);
            this.btnRegDefault.TabIndex = 4;
            this.btnRegDefault.Text = "Set to Default";
            this.btnRegDefault.UseVisualStyleBackColor = true;
            // 
            // btnRegReset
            // 
            this.btnRegReset.Location = new System.Drawing.Point(418, 6);
            this.btnRegReset.Name = "btnRegReset";
            this.btnRegReset.Size = new System.Drawing.Size(128, 23);
            this.btnRegReset.TabIndex = 3;
            this.btnRegReset.Text = "Reboot Explorer";
            this.btnRegReset.UseVisualStyleBackColor = true;
            this.btnRegReset.Click += new System.EventHandler(this.btnRegReset_Click);
            // 
            // grpExplorer
            // 
            this.grpExplorer.BackColor = System.Drawing.Color.Transparent;
            this.grpExplorer.Controls.Add(this.checkBox4);
            this.grpExplorer.Controls.Add(this.checkBox3);
            this.grpExplorer.Controls.Add(this.checkBox2);
            this.grpExplorer.Controls.Add(this.checkBox1);
            this.grpExplorer.Location = new System.Drawing.Point(212, 6);
            this.grpExplorer.Name = "grpExplorer";
            this.grpExplorer.Size = new System.Drawing.Size(200, 300);
            this.grpExplorer.TabIndex = 2;
            this.grpExplorer.TabStop = false;
            this.grpExplorer.Text = "Explorer Settings";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(6, 88);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(80, 17);
            this.checkBox4.TabIndex = 1;
            this.checkBox4.Text = "checkBox2";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 65);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(80, 17);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "checkBox2";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 42);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(101, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Hide Tray Icons";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Hide File Extentions";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // grpUAC
            // 
            this.grpUAC.Controls.Add(this.cbUACPrompt);
            this.grpUAC.Controls.Add(this.cbUAC);
            this.grpUAC.Location = new System.Drawing.Point(6, 6);
            this.grpUAC.Name = "grpUAC";
            this.grpUAC.Size = new System.Drawing.Size(200, 74);
            this.grpUAC.TabIndex = 1;
            this.grpUAC.TabStop = false;
            this.grpUAC.Text = "User Account Control Settings";
            // 
            // cbUACPrompt
            // 
            this.cbUACPrompt.AutoSize = true;
            this.cbUACPrompt.Location = new System.Drawing.Point(6, 42);
            this.cbUACPrompt.Name = "cbUACPrompt";
            this.cbUACPrompt.Size = new System.Drawing.Size(120, 17);
            this.cbUACPrompt.TabIndex = 1;
            this.cbUACPrompt.Text = "Enable UAC Prompt";
            this.cbUACPrompt.UseVisualStyleBackColor = true;
            this.cbUACPrompt.CheckedChanged += new System.EventHandler(this.cb_UAC_CheckedChanged);
            // 
            // cbUAC
            // 
            this.cbUAC.AutoSize = true;
            this.cbUAC.Location = new System.Drawing.Point(6, 19);
            this.cbUAC.Name = "cbUAC";
            this.cbUAC.Size = new System.Drawing.Size(84, 17);
            this.cbUAC.TabIndex = 0;
            this.cbUAC.Text = "Enable UAC";
            this.cbUAC.UseVisualStyleBackColor = true;
            this.cbUAC.CheckedChanged += new System.EventHandler(this.cb_UAC_CheckedChanged);
            // 
            // tbFolders
            // 
            this.tbFolders.Location = new System.Drawing.Point(4, 22);
            this.tbFolders.Name = "tbFolders";
            this.tbFolders.Padding = new System.Windows.Forms.Padding(3);
            this.tbFolders.Size = new System.Drawing.Size(552, 312);
            this.tbFolders.TabIndex = 3;
            this.tbFolders.Text = "Folders Setup";
            this.tbFolders.UseVisualStyleBackColor = true;
            // 
            // tbApplicationDownload
            // 
            this.tbApplicationDownload.Controls.Add(this.lblSelectedAppVersion);
            this.tbApplicationDownload.Controls.Add(this.lblSelectedAppName);
            this.tbApplicationDownload.Controls.Add(this.button2);
            this.tbApplicationDownload.Controls.Add(this.button1);
            this.tbApplicationDownload.Controls.Add(this.label1);
            this.tbApplicationDownload.Controls.Add(this.lbInstalled);
            this.tbApplicationDownload.Controls.Add(this.lblRec);
            this.tbApplicationDownload.Controls.Add(this.lbRecommended);
            this.tbApplicationDownload.Location = new System.Drawing.Point(4, 22);
            this.tbApplicationDownload.Name = "tbApplicationDownload";
            this.tbApplicationDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tbApplicationDownload.Size = new System.Drawing.Size(552, 312);
            this.tbApplicationDownload.TabIndex = 1;
            this.tbApplicationDownload.Text = "Applications Download";
            this.tbApplicationDownload.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(192, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Check For Updates";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Download Selected";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Currently Installed";
            // 
            // lbInstalled
            // 
            this.lbInstalled.FormattingEnabled = true;
            this.lbInstalled.Location = new System.Drawing.Point(369, 19);
            this.lbInstalled.Name = "lbInstalled";
            this.lbInstalled.Size = new System.Drawing.Size(180, 290);
            this.lbInstalled.TabIndex = 2;
            this.lbInstalled.SelectedIndexChanged += new System.EventHandler(this.lbInstalled_SelectedIndexChanged);
            // 
            // lblRec
            // 
            this.lblRec.AutoSize = true;
            this.lblRec.Location = new System.Drawing.Point(6, 3);
            this.lblRec.Name = "lblRec";
            this.lblRec.Size = new System.Drawing.Size(139, 13);
            this.lblRec.TabIndex = 1;
            this.lblRec.Text = "Recommended Applications";
            // 
            // lbRecommended
            // 
            this.lbRecommended.FormattingEnabled = true;
            this.lbRecommended.Location = new System.Drawing.Point(6, 19);
            this.lbRecommended.Name = "lbRecommended";
            this.lbRecommended.Size = new System.Drawing.Size(180, 290);
            this.lbRecommended.TabIndex = 0;
            // 
            // tbApplicationsInstall
            // 
            this.tbApplicationsInstall.Controls.Add(this.btnInstall);
            this.tbApplicationsInstall.Controls.Add(this.label2);
            this.tbApplicationsInstall.Controls.Add(this.lbDownloaded);
            this.tbApplicationsInstall.Location = new System.Drawing.Point(4, 22);
            this.tbApplicationsInstall.Name = "tbApplicationsInstall";
            this.tbApplicationsInstall.Padding = new System.Windows.Forms.Padding(3);
            this.tbApplicationsInstall.Size = new System.Drawing.Size(552, 312);
            this.tbApplicationsInstall.TabIndex = 2;
            this.tbApplicationsInstall.Text = "Applications Install";
            this.tbApplicationsInstall.UseVisualStyleBackColor = true;
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(173, 19);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(120, 23);
            this.btnInstall.TabIndex = 7;
            this.btnInstall.Text = "Install Selected";
            this.btnInstall.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Downloaded Applications";
            // 
            // lbDownloaded
            // 
            this.lbDownloaded.FormattingEnabled = true;
            this.lbDownloaded.Location = new System.Drawing.Point(6, 19);
            this.lbDownloaded.Name = "lbDownloaded";
            this.lbDownloaded.Size = new System.Drawing.Size(161, 290);
            this.lbDownloaded.TabIndex = 5;
            // 
            // lblSelectedAppName
            // 
            this.lblSelectedAppName.AutoSize = true;
            this.lblSelectedAppName.Location = new System.Drawing.Point(192, 111);
            this.lblSelectedAppName.Name = "lblSelectedAppName";
            this.lblSelectedAppName.Size = new System.Drawing.Size(0, 13);
            this.lblSelectedAppName.TabIndex = 6;
            // 
            // lblSelectedAppVersion
            // 
            this.lblSelectedAppVersion.AutoSize = true;
            this.lblSelectedAppVersion.Location = new System.Drawing.Point(192, 124);
            this.lblSelectedAppVersion.Name = "lblSelectedAppVersion";
            this.lblSelectedAppVersion.Size = new System.Drawing.Size(0, 13);
            this.lblSelectedAppVersion.TabIndex = 6;
            // 
            // frmAfterFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.tbMain);
            this.Name = "frmAfterFormat";
            this.Text = "After Format";
            this.Load += new System.EventHandler(this.frmAfterFormat_Load);
            this.tbMain.ResumeLayout(false);
            this.tbRegistry.ResumeLayout(false);
            this.grpStart.ResumeLayout(false);
            this.grpStart.PerformLayout();
            this.grpExplorer.ResumeLayout(false);
            this.grpExplorer.PerformLayout();
            this.grpUAC.ResumeLayout(false);
            this.grpUAC.PerformLayout();
            this.tbApplicationDownload.ResumeLayout(false);
            this.tbApplicationDownload.PerformLayout();
            this.tbApplicationsInstall.ResumeLayout(false);
            this.tbApplicationsInstall.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tbRegistry;
        private System.Windows.Forms.TabPage tbFolders;
        private System.Windows.Forms.TabPage tbApplicationDownload;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbInstalled;
        private System.Windows.Forms.Label lblRec;
        private System.Windows.Forms.ListBox lbRecommended;
        private System.Windows.Forms.TabPage tbApplicationsInstall;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbDownloaded;
        private System.Windows.Forms.GroupBox grpStart;
        private System.Windows.Forms.Button btnRegDefault;
        private System.Windows.Forms.Button btnRegReset;
        private System.Windows.Forms.GroupBox grpExplorer;
        private System.Windows.Forms.CheckBox cbRegStaUser;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox grpUAC;
        private System.Windows.Forms.CheckBox cbUACPrompt;
        private System.Windows.Forms.CheckBox cbUAC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegRecommended;
        private System.Windows.Forms.CheckBox cbRegStaCPan;
        private System.Windows.Forms.CheckBox cbRegStaNetw;
        private System.Windows.Forms.CheckBox cbRegStaComp;
        private System.Windows.Forms.CheckBox cbRegStaFavo;
        private System.Windows.Forms.CheckBox cbRegStaDocs;
        private System.Windows.Forms.Label lblSelectedAppVersion;
        private System.Windows.Forms.Label lblSelectedAppName;
    }
}

