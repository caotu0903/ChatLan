
namespace Chat_Client
{
    partial class FrmAdminManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdminManage));
            this.lvAccountInfo = new System.Windows.Forms.ListView();
            this.chNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPassword = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAccountName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDateOfBirth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPhoneNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCreateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsAdminManage = new System.Windows.Forms.ToolStrip();
            this.tsbtAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tslbNofication = new System.Windows.Forms.ToolStripLabel();
            this.tsAdminManage.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvAccountInfo
            // 
            this.lvAccountInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.lvAccountInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvAccountInfo.CheckBoxes = true;
            this.lvAccountInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNumber,
            this.chUserName,
            this.chPassword,
            this.chAccountName,
            this.chFirstName,
            this.chLastName,
            this.chDateOfBirth,
            this.chPhoneNumber,
            this.chGender,
            this.chStatus,
            this.chCreateTime});
            this.lvAccountInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvAccountInfo.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAccountInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lvAccountInfo.HideSelection = false;
            this.lvAccountInfo.Location = new System.Drawing.Point(0, 55);
            this.lvAccountInfo.Name = "lvAccountInfo";
            this.lvAccountInfo.Size = new System.Drawing.Size(1264, 306);
            this.lvAccountInfo.TabIndex = 0;
            this.lvAccountInfo.UseCompatibleStateImageBehavior = false;
            this.lvAccountInfo.View = System.Windows.Forms.View.Details;
            // 
            // chNumber
            // 
            this.chNumber.Text = "";
            this.chNumber.Width = 35;
            // 
            // chUserName
            // 
            this.chUserName.Text = "USERNAME";
            this.chUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chUserName.Width = 122;
            // 
            // chPassword
            // 
            this.chPassword.Text = "PASSWORD";
            this.chPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chPassword.Width = 126;
            // 
            // chAccountName
            // 
            this.chAccountName.Text = "ACCOUNTNAME";
            this.chAccountName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chAccountName.Width = 133;
            // 
            // chFirstName
            // 
            this.chFirstName.Text = "FIRSTNAME";
            this.chFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chFirstName.Width = 96;
            // 
            // chLastName
            // 
            this.chLastName.Text = "LASTNAME";
            this.chLastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chLastName.Width = 96;
            // 
            // chDateOfBirth
            // 
            this.chDateOfBirth.Text = "DATEOFBIRTH";
            this.chDateOfBirth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chDateOfBirth.Width = 143;
            // 
            // chPhoneNumber
            // 
            this.chPhoneNumber.Text = "PHONENUMBER";
            this.chPhoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chPhoneNumber.Width = 133;
            // 
            // chGender
            // 
            this.chGender.Text = "GENDER";
            this.chGender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chGender.Width = 86;
            // 
            // chStatus
            // 
            this.chStatus.Text = "STATUS";
            this.chStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chStatus.Width = 78;
            // 
            // chCreateTime
            // 
            this.chCreateTime.Text = "CREATETIME";
            this.chCreateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chCreateTime.Width = 212;
            // 
            // tsAdminManage
            // 
            this.tsAdminManage.AutoSize = false;
            this.tsAdminManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.tsAdminManage.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsAdminManage.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsAdminManage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtAdd,
            this.toolStripSeparator1,
            this.tsbtDelete,
            this.toolStripSeparator2,
            this.tsbtRefresh,
            this.toolStripSeparator4,
            this.tsbtClose,
            this.toolStripSeparator3,
            this.tslbNofication});
            this.tsAdminManage.Location = new System.Drawing.Point(0, 0);
            this.tsAdminManage.Name = "tsAdminManage";
            this.tsAdminManage.Size = new System.Drawing.Size(1264, 52);
            this.tsAdminManage.TabIndex = 1;
            this.tsAdminManage.Text = "Admin Manage";
            this.tsAdminManage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsAdminManage_MouseDown);
            // 
            // tsbtAdd
            // 
            this.tsbtAdd.AutoSize = false;
            this.tsbtAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.tsbtAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtAdd.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbtAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tsbtAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtAdd.Image")));
            this.tsbtAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtAdd.Name = "tsbtAdd";
            this.tsbtAdd.Size = new System.Drawing.Size(100, 42);
            this.tsbtAdd.Text = "ADD";
            this.tsbtAdd.ToolTipText = "Add";
            this.tsbtAdd.Click += new System.EventHandler(this.tsbtAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // tsbtDelete
            // 
            this.tsbtDelete.AutoSize = false;
            this.tsbtDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtDelete.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbtDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(0)))), ((int)(((byte)(126)))));
            this.tsbtDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbtDelete.Image")));
            this.tsbtDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtDelete.Name = "tsbtDelete";
            this.tsbtDelete.Size = new System.Drawing.Size(100, 42);
            this.tsbtDelete.Text = "DELETE";
            this.tsbtDelete.Click += new System.EventHandler(this.tsbtDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 52);
            // 
            // tsbtRefresh
            // 
            this.tsbtRefresh.AutoSize = false;
            this.tsbtRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtRefresh.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbtRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tsbtRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbtRefresh.Image")));
            this.tsbtRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtRefresh.Name = "tsbtRefresh";
            this.tsbtRefresh.Size = new System.Drawing.Size(100, 42);
            this.tsbtRefresh.Text = "REFRESH";
            this.tsbtRefresh.Click += new System.EventHandler(this.tsbtRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 52);
            // 
            // tsbtClose
            // 
            this.tsbtClose.AutoSize = false;
            this.tsbtClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtClose.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbtClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.tsbtClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbtClose.Image")));
            this.tsbtClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtClose.Name = "tsbtClose";
            this.tsbtClose.Size = new System.Drawing.Size(100, 42);
            this.tsbtClose.Text = "CLOSE";
            this.tsbtClose.Click += new System.EventHandler(this.tsbtClose_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 52);
            // 
            // tslbNofication
            // 
            this.tslbNofication.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslbNofication.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tslbNofication.Name = "tslbNofication";
            this.tslbNofication.Size = new System.Drawing.Size(120, 49);
            this.tslbNofication.Text = "NOTIFICATION";
            this.tslbNofication.Visible = false;
            // 
            // FrmAdminManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1264, 361);
            this.Controls.Add(this.tsAdminManage);
            this.Controls.Add(this.lvAccountInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAdminManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat App - Admin Manage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAdminManage_FormClosing);
            this.Load += new System.EventHandler(this.FrmAdminManage_Load);
            this.tsAdminManage.ResumeLayout(false);
            this.tsAdminManage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvAccountInfo;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.ColumnHeader chUserName;
        private System.Windows.Forms.ColumnHeader chPassword;
        private System.Windows.Forms.ColumnHeader chAccountName;
        private System.Windows.Forms.ColumnHeader chFirstName;
        private System.Windows.Forms.ColumnHeader chLastName;
        private System.Windows.Forms.ColumnHeader chDateOfBirth;
        private System.Windows.Forms.ColumnHeader chPhoneNumber;
        private System.Windows.Forms.ColumnHeader chGender;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.ColumnHeader chCreateTime;
        private System.Windows.Forms.ToolStrip tsAdminManage;
        private System.Windows.Forms.ToolStripButton tsbtAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel tslbNofication;
        private System.Windows.Forms.ToolStripButton tsbtRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}