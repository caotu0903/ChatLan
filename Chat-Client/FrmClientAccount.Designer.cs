namespace Chat_Client
{
    partial class FrmClientAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientAccount));
            this.tsAccount = new System.Windows.Forms.ToolStrip();
            this.tsbtMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsEditAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsManageAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbChatRoom = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtCreateChatRoom = new System.Windows.Forms.ToolStripButton();
            this.tsddbNotification = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsddbListUser = new System.Windows.Forms.ToolStripDropDownButton();
            this.lvStatus = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbChatScreen = new System.Windows.Forms.TextBox();
            this.lbUsername = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbChat = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tsAccount.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsAccount
            // 
            this.tsAccount.AutoSize = false;
            this.tsAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.tsAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsAccount.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsAccount.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsAccount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtMenu,
            this.tscbChatRoom,
            this.tsbtCreateChatRoom,
            this.tsddbNotification,
            this.tsddbListUser});
            this.tsAccount.Location = new System.Drawing.Point(0, 0);
            this.tsAccount.Name = "tsAccount";
            this.tsAccount.Padding = new System.Windows.Forms.Padding(0);
            this.tsAccount.Size = new System.Drawing.Size(52, 460);
            this.tsAccount.TabIndex = 0;
            this.tsAccount.Text = "toolStrip1";
            this.tsAccount.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsAccount_MouseDown);
            // 
            // tsbtMenu
            // 
            this.tsbtMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.tsbtMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEditAccount,
            this.tsManageAccount,
            this.tsLogOut});
            this.tsbtMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbtMenu.ForeColor = System.Drawing.Color.Black;
            this.tsbtMenu.Image = global::Chat_Client.Properties.Resources.general___office_30_512_77974;
            this.tsbtMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtMenu.Name = "tsbtMenu";
            this.tsbtMenu.Size = new System.Drawing.Size(51, 20);
            this.tsbtMenu.Text = "Menu";
            // 
            // tsEditAccount
            // 
            this.tsEditAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.tsEditAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsEditAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tsEditAccount.Name = "tsEditAccount";
            this.tsEditAccount.Size = new System.Drawing.Size(223, 28);
            this.tsEditAccount.Text = "My Account";
            this.tsEditAccount.Click += new System.EventHandler(this.tsEditAccount_Click);
            // 
            // tsManageAccount
            // 
            this.tsManageAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.tsManageAccount.Enabled = false;
            this.tsManageAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsManageAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tsManageAccount.Name = "tsManageAccount";
            this.tsManageAccount.Size = new System.Drawing.Size(223, 28);
            this.tsManageAccount.Text = "Manage Account";
            this.tsManageAccount.Visible = false;
            this.tsManageAccount.Click += new System.EventHandler(this.tsManageAccount_Click);
            // 
            // tsLogOut
            // 
            this.tsLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.tsLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsLogOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tsLogOut.Name = "tsLogOut";
            this.tsLogOut.Size = new System.Drawing.Size(223, 28);
            this.tsLogOut.Text = "Log out";
            this.tsLogOut.Click += new System.EventHandler(this.tsLogOut_Click);
            // 
            // tscbChatRoom
            // 
            this.tscbChatRoom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tscbChatRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tscbChatRoom.DropDownHeight = 100;
            this.tscbChatRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbChatRoom.DropDownWidth = 100;
            this.tscbChatRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tscbChatRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tscbChatRoom.IntegralHeight = false;
            this.tscbChatRoom.Items.AddRange(new object[] {
            "All"});
            this.tscbChatRoom.Name = "tscbChatRoom";
            this.tscbChatRoom.Size = new System.Drawing.Size(49, 24);
            this.tscbChatRoom.DropDownClosed += new System.EventHandler(this.tscbChatRoom_DropDownClosed);
            // 
            // tsbtCreateChatRoom
            // 
            this.tsbtCreateChatRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tsbtCreateChatRoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtCreateChatRoom.Image = global::Chat_Client.Properties.Resources._2009825_200;
            this.tsbtCreateChatRoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtCreateChatRoom.Name = "tsbtCreateChatRoom";
            this.tsbtCreateChatRoom.Size = new System.Drawing.Size(51, 20);
            this.tsbtCreateChatRoom.Text = "Create Chat Room";
            this.tsbtCreateChatRoom.Click += new System.EventHandler(this.tsbtCreateChatRoom_Click_1);
            // 
            // tsddbNotification
            // 
            this.tsddbNotification.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsddbNotification.BackColor = System.Drawing.Color.White;
            this.tsddbNotification.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddbNotification.Image = global::Chat_Client.Properties.Resources.notification;
            this.tsddbNotification.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbNotification.Name = "tsddbNotification";
            this.tsddbNotification.Size = new System.Drawing.Size(51, 20);
            this.tsddbNotification.Text = "Notification";
            this.tsddbNotification.DropDownOpened += new System.EventHandler(this.tsddbNotification_DropDownOpened);
            // 
            // tsddbListUser
            // 
            this.tsddbListUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tsddbListUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddbListUser.Enabled = false;
            this.tsddbListUser.Image = global::Chat_Client.Properties.Resources.user;
            this.tsddbListUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbListUser.Name = "tsddbListUser";
            this.tsddbListUser.Size = new System.Drawing.Size(51, 20);
            this.tsddbListUser.Text = "List User";
            this.tsddbListUser.Visible = false;
            // 
            // lvStatus
            // 
            this.lvStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.lvStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lvStatus.HideSelection = false;
            this.lvStatus.Location = new System.Drawing.Point(0, 47);
            this.lvStatus.Name = "lvStatus";
            this.lvStatus.Size = new System.Drawing.Size(221, 413);
            this.lvStatus.TabIndex = 1;
            this.lvStatus.UseCompatibleStateImageBehavior = false;
            this.lvStatus.View = System.Windows.Forms.View.List;
            this.lvStatus.DoubleClick += new System.EventHandler(this.lvStatus_DoubleClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "Active Users Now:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.lvStatus);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(72, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 460);
            this.panel1.TabIndex = 7;
            // 
            // tbChatScreen
            // 
            this.tbChatScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.tbChatScreen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbChatScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChatScreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tbChatScreen.Location = new System.Drawing.Point(0, 47);
            this.tbChatScreen.Multiline = true;
            this.tbChatScreen.Name = "tbChatScreen";
            this.tbChatScreen.ReadOnly = true;
            this.tbChatScreen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbChatScreen.Size = new System.Drawing.Size(488, 339);
            this.tbChatScreen.TabIndex = 3;
            // 
            // lbUsername
            // 
            this.lbUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.lbUsername.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lbUsername.Location = new System.Drawing.Point(0, 0);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(488, 47);
            this.lbUsername.TabIndex = 6;
            this.lbUsername.Text = "Chat Feed:";
            this.lbUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbUsername.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbUsername_MouseDown);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tbChat);
            this.panel5.Controls.Add(this.btSend);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 392);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(488, 68);
            this.panel5.TabIndex = 7;
            // 
            // tbChat
            // 
            this.tbChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.tbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbChat.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tbChat.Location = new System.Drawing.Point(0, 0);
            this.tbChat.Multiline = true;
            this.tbChat.Name = "tbChat";
            this.tbChat.Size = new System.Drawing.Size(414, 68);
            this.tbChat.TabIndex = 5;
            // 
            // btSend
            // 
            this.btSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btSend.BackgroundImage = global::Chat_Client.Properties.Resources.send_4008;
            this.btSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSend.ForeColor = System.Drawing.Color.Black;
            this.btSend.Location = new System.Drawing.Point(420, 0);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(68, 68);
            this.btSend.TabIndex = 4;
            this.btSend.UseVisualStyleBackColor = false;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.lbUsername);
            this.panel4.Controls.Add(this.tbChatScreen);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(314, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(488, 460);
            this.panel4.TabIndex = 8;
            // 
            // FrmClientAccount
            // 
            this.AcceptButton = this.btSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(802, 460);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tsAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmClientAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat App - Account";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmClientAccount_FormClosing);
            this.Load += new System.EventHandler(this.FrmClientAccount_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.tsAccount.ResumeLayout(false);
            this.tsAccount.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsAccount;
        private System.Windows.Forms.ToolStripDropDownButton tsbtMenu;
        private System.Windows.Forms.ToolStripMenuItem tsEditAccount;
        private System.Windows.Forms.ToolStripMenuItem tsLogOut;
        private System.Windows.Forms.ListView lvStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem tsManageAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripComboBox tscbChatRoom;
        private System.Windows.Forms.ToolStripButton tsbtCreateChatRoom;
        private System.Windows.Forms.ToolStripDropDownButton tsddbNotification;
        private System.Windows.Forms.ToolStripDropDownButton tsddbListUser;
        private System.Windows.Forms.TextBox tbChatScreen;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tbChat;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Panel panel4;
    }
}