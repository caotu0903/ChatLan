using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace Chat_Client
{
    public partial class FrmClientLogin : Form
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
        public FrmClientLogin()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            tbUser.Text = "";
            tbPass.Text = "";
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        TcpClient _server;
        StreamWriter _sw;
        StreamReader _sr;
        string _username;

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (btConnect.Text == "Connect")
            {
                IPAddress ipServer;
                int port;
                if (IPAddress.TryParse(tbIP.Text, out ipServer) == false)
                {
                    lbNofication.Text = "Wrong IP address!";
                    lbNofication.Visible = true;
                }
                else
                {
                    if (int.TryParse(tbPort.Text, out port) == false)
                    {
                        lbNofication.Text = "Wrong port number!";
                        lbNofication.Visible = true;
                    }
                    else
                    {
                        try
                        {
                            IPEndPoint iPEndPoint = new IPEndPoint(ipServer, port);
                            _server = new TcpClient();
                            _server.Connect(iPEndPoint);
                            _sw = new StreamWriter(_server.GetStream());
                            _sr = new StreamReader(_server.GetStream());
                            tbIP.Enabled = false;
                            tbPort.Enabled = false;
                            btConnect.Text = "Disconnect";
                            tbUser.Enabled = true;
                            tbPass.Enabled = true;
                            btLogin.Enabled = true;
                            btSignup.Enabled = true;
                            lbNofication.Text = "Connect server successfully!";
                            lbNofication.Visible = true;
                        }
                        catch
                        {
                            lbNofication.Text = "Server is not working!";
                            lbNofication.Visible = true;
                        }
                    }
                }
            }
            else if (btConnect.Text == "Disconnect")
            {
                tbIP.Enabled = true;
                tbPort.Enabled = true;
                btConnect.Text = "Connect";
                tbUser.Enabled = false;
                tbPass.Enabled = false;
                btLogin.Enabled = false;
                btSignup.Enabled = false;
                _server.Close();
                lbNofication.Text = "Disconnect server successfully!";
                lbNofication.Visible = true;
            }
        }
        private void btLogin_Click(object sender, EventArgs e)
        {
            _username = tbUser.Text.Trim();
            _sw.WriteLine(tbUser.Text.Trim());
            _sw.Flush();
            _sw.WriteLine(tbPass.Text.Trim());
            _sw.Flush();
            string statusReturn = _sr.ReadLine();
            if (statusReturn == "User is online.")
            {
                lbNofication.Text = "User is online.";
                lbNofication.Visible = true;
            }
            else if (statusReturn == "Password is not correct.")
            {
                lbNofication.Text = "Password is not correct.";
                lbNofication.Visible = true;
            }
            else if (statusReturn == "Username is not correct.")
            {
                lbNofication.Text = "Username is not correct.";
                lbNofication.Visible = true;
            }
            else 
            {
                string isadmin = _sr.ReadLine();
                FrmClientAccount frmClientAccount = new FrmClientAccount(_server, this, _username, statusReturn, bool.Parse(isadmin));
                frmClientAccount.Show();
                this.Hide();
            }    
        }

        private void btSignup_Click(object sender, EventArgs e)
        {
            FrmSignup frmSignup = new FrmSignup(_server, this);
            frmSignup.Show();
            this.Hide();
        }

        public void ClickbtConnect()
        {
            btConnect.PerformClick();
        }

        public void HidelbNofication()
        {
            lbNofication.Visible = false;
        }

        private void tbIP_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }

        private void tbPort_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }

        private void tbUser_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }

        private void tbPass_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }

        private void FrmClientLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            _server.Close();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

