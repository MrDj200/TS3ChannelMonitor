namespace TS3ChannelMonitor
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.channelList = new System.Windows.Forms.ListView();
            this.listChannelName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listChannelSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.searchInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.playlistListbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(34, 26);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(192, 31);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Not Connected";
            // 
            // channelList
            // 
            this.channelList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listChannelName,
            this.listChannelSize});
            this.channelList.FullRowSelect = true;
            this.channelList.HideSelection = false;
            this.channelList.Location = new System.Drawing.Point(34, 90);
            this.channelList.MultiSelect = false;
            this.channelList.Name = "channelList";
            this.channelList.Size = new System.Drawing.Size(677, 306);
            this.channelList.TabIndex = 19;
            this.channelList.UseCompatibleStateImageBehavior = false;
            this.channelList.View = System.Windows.Forms.View.Details;
            // 
            // listChannelName
            // 
            this.listChannelName.Text = "ChannelName";
            this.listChannelName.Width = 240;
            // 
            // listChannelSize
            // 
            this.listChannelSize.Text = "Clients";
            this.listChannelSize.Width = 59;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(636, 62);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 22);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // searchInput
            // 
            this.searchInput.Location = new System.Drawing.Point(34, 63);
            this.searchInput.Name = "searchInput";
            this.searchInput.Size = new System.Drawing.Size(587, 20);
            this.searchInput.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Subscribed Channels:";
            // 
            // playlistListbox
            // 
            this.playlistListbox.DisplayMember = "Name";
            this.playlistListbox.FormattingEnabled = true;
            this.playlistListbox.Location = new System.Drawing.Point(34, 424);
            this.playlistListbox.Name = "playlistListbox";
            this.playlistListbox.Size = new System.Drawing.Size(677, 147);
            this.playlistListbox.TabIndex = 15;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 636);
            this.Controls.Add(this.channelList);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.searchInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playlistListbox);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "TS3 Channel Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListView channelList;
        private System.Windows.Forms.ColumnHeader listChannelName;
        private System.Windows.Forms.ColumnHeader listChannelSize;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox searchInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox playlistListbox;
    }
}

