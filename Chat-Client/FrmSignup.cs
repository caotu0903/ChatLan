using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Runtime.InteropServices;

namespace Chat_Client
{
    //UI----------------------------------------------------------------------------------------------------------------
    public partial class FrmSignup : Form
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
        public FrmSignup()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //------------------------------------------------------------------------------------------------------------------
        TcpClient _server;
        FrmClientLogin _frmParent;
        StreamWriter _sw;
        StreamReader _sr;

        public FrmSignup(TcpClient server, FrmClientLogin parent) : this()
        {
            _server = server;
            _frmParent = parent;
            _sw = new StreamWriter(_server.GetStream());
            _sr = new StreamReader(_server.GetStream());
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text != "" && tbAccountName.Text != "" && tbPassword.Text != "" && 
                tbConfirmPassword.Text != "" && tbFirstName.Text != "" && tbLastName.Text != "" &&
                cbGender.Text != "" && tbPhoneNumber.Text != "")
            {
                if (tbPassword.Text == tbConfirmPassword.Text)
                {
                    if (CheckDate(cbDay.Text.Trim(), cbMonth.Text.Trim(), cbYear.Text.Trim()))
                    {
                        _sw.WriteLine("New account");
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
                        string receive = _sr.ReadLine();
                        if (receive == "Username has existed")
                        {
                            lbNofication.Text = "Username has existed, try another username!";
                            lbNofication.Visible = true;
                        }
                        else if (receive == "Success")
                        {
                            MessageBox.Show("Success");
                            this.Close();
                            _frmParent.Show();
                        }
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

        bool CheckDate(string day, string month, string year)
        {
            if (int.Parse(day) <= 31 && int.Parse(day) > 0)
            {
                if (int.Parse(month) <= 12 && int.Parse(month) > 0)
                {
                    if (int.Parse(year) <= 2010 && int.Parse(year) > 1990)
                    {
                        return true;
                    }
                    else
                    {
                        lbNofication.Text = "Choose right year!";
                        lbNofication.Visible = true;
                        return false;
                    }
                }
                else
                {
                    lbNofication.Text = "Choose right month!";
                    lbNofication.Visible = true;
                    return false;
                }
            }
            else
            {
                lbNofication.Text = "Choose right day!";
                lbNofication.Visible = true;
                return false;
            }
        }

        private void FrmSignup_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmParent.Show();
        }
        //--------------------------------------------------------------------------------------------------------------
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void lbNofication_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
