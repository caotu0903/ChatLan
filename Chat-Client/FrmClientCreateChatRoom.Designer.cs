namespace Chat_Client
{
    partial class FrmClientCreateChatRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientCreateChatRoom));
            this.lbNotification = new System.Windows.Forms.Label();
            this.btCreateRoom = new System.Windows.Forms.Button();
            this.lvOnlineUser = new System.Windows.Forms.ListView();
            this.lbSelectUserToAdd = new System.Windows.Forms.Label();
            this.lbRoomName = new System.Windows.Forms.Label();
            this.tbRoomName = new System.Windows.Forms.TextBox();
            this.btReturn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbNotification
            // 
            this.lbNotification.AutoSize = true;
            this.lbNotification.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbNotification.ForeColor = System.Drawing.Color.Red;
            this.lbNotification.Location = new System.Drawing.Point(0, 408);
            this.lbNotification.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbNotification.Name = "lbNotification";
            this.lbNotification.Size = new System.Drawing.Size(111, 25);
            this.lbNotification.TabIndex = 17;
            this.lbNotification.Text = "Notification";
            this.lbNotification.Visible = false;
            // 
            // btCreateRoom
            // 
            this.btCreateRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btCreateRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCreateRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btCreateRoom.Location = new System.Drawing.Point(398, 63);
            this.btCreateRoom.Margin = new System.Windows.Forms.Padding(6);
            this.btCreateRoom.Name = "btCreateRoom";
            this.btCreateRoom.Size = new System.Drawing.Size(98, 44);
            this.btCreateRoom.TabIndex = 16;
            this.btCreateRoom.Text = "CREATE";
            this.btCreateRoom.UseVisualStyleBackColor = false;
            this.btCreateRoom.Click += new System.EventHandler(this.btCreateRoom_Click_1);
            // 
            // lvOnlineUser
            // 
            this.lvOnlineUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.lvOnlineUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvOnlineUser.CheckBoxes = true;
            this.lvOnlineUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lvOnlineUser.HideSelection = false;
            this.lvOnlineUser.Location = new System.Drawing.Point(20, 119);
            this.lvOnlineUser.Margin = new System.Windows.Forms.Padding(6);
            this.lvOnlineUser.Name = "lvOnlineUser";
            this.lvOnlineUser.Size = new System.Drawing.Size(476, 283);
            this.lvOnlineUser.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvOnlineUser.TabIndex = 15;
            this.lvOnlineUser.UseCompatibleStateImageBehavior = false;
            this.lvOnlineUser.View = System.Windows.Forms.View.List;
            // 
            // lbSelectUserToAdd
            // 
            this.lbSelectUserToAdd.AutoSize = true;
            this.lbSelectUserToAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lbSelectUserToAdd.Location = new System.Drawing.Point(15, 73);
            this.lbSelectUserToAdd.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbSelectUserToAdd.Name = "lbSelectUserToAdd";
            this.lbSelectUserToAdd.Size = new System.Drawing.Size(162, 25);
            this.lbSelectUserToAdd.TabIndex = 14;
            this.lbSelectUserToAdd.Text = "Select user to add";
            // 
            // lbRoomName
            // 
            this.lbRoomName.AutoSize = true;
            this.lbRoomName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbRoomName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lbRoomName.Location = new System.Drawing.Point(15, 16);
            this.lbRoomName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbRoomName.Name = "lbRoomName";
            this.lbRoomName.Size = new System.Drawing.Size(112, 25);
            this.lbRoomName.TabIndex = 7;
            this.lbRoomName.Text = "Room name";
            this.lbRoomName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbRoomName
            // 
            this.tbRoomName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.tbRoomName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbRoomName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tbRoomName.Location = new System.Drawing.Point(139, 16);
            this.tbRoomName.Margin = new System.Windows.Forms.Padding(6);
            this.tbRoomName.Name = "tbRoomName";
            this.tbRoomName.Size = new System.Drawing.Size(357, 26);
            this.tbRoomName.TabIndex = 6;
            // 
            // btReturn
            // 
            this.btReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(0)))), ((int)(((byte)(126)))));
            this.btReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btReturn.Location = new System.Drawing.Point(288, 63);
            this.btReturn.Margin = new System.Windows.Forms.Padding(6);
            this.btReturn.Name = "btReturn";
            this.btReturn.Size = new System.Drawing.Size(98, 44);
            this.btReturn.TabIndex = 19;
            this.btReturn.Text = "RETURN";
            this.btReturn.UseVisualStyleBackColor = false;
            this.btReturn.Click += new System.EventHandler(this.btReturn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.panel1.Controls.Add(this.lbRoomName);
            this.panel1.Controls.Add(this.tbRoomName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 54);
            this.panel1.TabIndex = 18;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // FrmClientCreateChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(516, 433);
            this.Controls.Add(this.lbNotification);
            this.Controls.Add(this.btCreateRoom);
            this.Controls.Add(this.lvOnlineUser);
            this.Controls.Add(this.lbSelectUserToAdd);
            this.Controls.Add(this.btReturn);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmClientCreateChatRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create a Chat Room";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmClientCreateChatRoom_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNotification;
        private System.Windows.Forms.Button btCreateRoom;
        private System.Windows.Forms.ListView lvOnlineUser;
        private System.Windows.Forms.Label lbSelectUserToAdd;
        private System.Windows.Forms.Label lbRoomName;
        private System.Windows.Forms.TextBox tbRoomName;
        private System.Windows.Forms.Button btReturn;
        private System.Windows.Forms.Panel panel1;
    }
}