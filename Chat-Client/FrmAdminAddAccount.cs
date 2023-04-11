using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Runtime.InteropServices;

namespace Chat_Client
{
    public partial class FrmAdminAddAccount : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public FrmAdminAddAccount()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public FrmAdminAddAccount(TcpClient server, FrmClientAccount frmClientAccount, StreamWriter sw) : this()
        {
            _server = server;
            _frmClientAccount = frmClientAccount;
            _sw = sw;
        }

        TcpClient _server;
        StreamWriter _sw;
        FrmClientAccount _frmClientAccount;

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text != "" && tbAccountName.Text != "" && tbPassword.Text != "" &&
                tbConfirmPassword.Text != "" && tbFirstName.Text != "" && tbLastName.Text != "" &&
                cbGender.Text != "" && tbPhoneNumber.Text != "")
            {
                if (tbPassword.Text == tbConfirmPassword.Text)
                {
                    _sw.WriteLine("Admin Add Account!!!");
                    _sw.Flush();
                    _sw.WriteLine(tbUsername.Text.Trim());
                    _sw.WriteLine(tbAccountName.Text.Trim());
                    _sw.WriteLine(tbPassword.Text.Trim());
                    _sw.WriteLine(tbFirstName.Text.Trim());
                    _sw.WriteLine(tbLastName.Text.Trim());
                    _sw.WriteLine(cbDay.Text.Trim() + "/" + cbMonth.Text.Trim() + "/" + cbYear.Text.Trim());
                    _sw.WriteLine(tbPhoneNumber.Text.Trim());
                    _sw.WriteLine(cbGender.Text.Trim());
                    _sw.Flush();
                    string receive = _frmClientAccount.GetAdminAddAccountData();
                    if (receive == "Username has been existed")
                    {
                        lbNofication.Text = "Username has been existed, try another username!";
                        lbNofication.Visible = true;
                    }
                    else if (receive == "Success")
                    {
                        lbNofication.Text = "Add account successed!";
                        lbNofication.Visible = true;
                    }
                }
                else
                {
                    lbNofication.Text = "Confirm password wrong!";
                    lbNofication.Visible = true;
                    tbConfirmPassword.Clear();
                }
            }
            else
            {
                lbNofication.Text = "Fill full the information!";
                lbNofication.Visible = true;
            }
        }

        private void FrmAdminAddAccount_Load(object sender, EventArgs e)
        {

        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
