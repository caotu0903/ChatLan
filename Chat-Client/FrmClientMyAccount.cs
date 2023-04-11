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
    public partial class FrmClientMyAccount : Form
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
        public FrmClientMyAccount()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        TcpClient _server;
        string _username;
        StreamWriter _sw;
        FrmClientAccount _frmParent;
        
        public FrmClientMyAccount(TcpClient server, string username, FrmClientAccount frmParent, StreamWriter sw) : this()
        {
            _server = server;
            _username = username;
            _frmParent = frmParent;
            _sw = sw;

            string accountname = _frmParent.GetMyAccountData();
            tbAccountName.Text = accountname;
            tbFirstName.Text = _frmParent.GetMyAccountData();
            tbLastName.Text = _frmParent.GetMyAccountData();
            string[] date = _frmParent.GetMyAccountData().Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (date.Length != 0)
            {
                cbDay.Text = date[0];
                cbMonth.Text = date[1];
                cbYear.Text = date[2];
            }
            tbPhoneNumber.Text = _frmParent.GetMyAccountData();
            cbGender.Text = _frmParent.GetMyAccountData(); 
            tbUsername.Text = _username;
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            _sw.WriteLine("Change infomation!!!");
            _sw.WriteLine(tbConfirmPassword.Text.Trim());
            _sw.Flush();
            string receiveData = _frmParent.GetMyAccountData();
            if (receiveData == "PASSWORD CONFIRMED")
            {
                _sw.WriteLine(tbFirstName.Text.Trim());
                _sw.WriteLine(tbLastName.Text.Trim());
                _sw.WriteLine(cbDay.Text.Trim() + "/" + cbMonth.Text.Trim() + "/" + cbYear.Text.Trim());
                _sw.WriteLine(tbPhoneNumber.Text.Trim());
                _sw.WriteLine(cbGender.Text.Trim());
                _sw.WriteLine(tbAccountName.Text.Trim());
                _sw.Flush();
                receiveData = _frmParent.GetMyAccountData();
                if (receiveData == "UPDATE SUCCESS")
                {
                    lbNofication.Text = "Update infomation success";
                    lbNofication.Visible = true;
                }
            }
            else
            {
                lbNofication.Text = "Confirm password wrong";
                lbNofication.Visible = true;
            }

        }

        private void FrmClientMyAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmParent.Show();
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
