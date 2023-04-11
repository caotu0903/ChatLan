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
    public partial class FrmAdminManage : Form
    {
        //UI-------------------------------------------------------------------------------------------------
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
        public FrmAdminManage()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //---------------------------------------------------------------------------------------------------
        public FrmAdminManage(TcpClient server, string username, FrmClientAccount frmParent, StreamWriter sw) : this()
        {
            _server = server;
            _username = username;
            _frmParent = frmParent;
            _sw = sw;

            int _countAccount = int.Parse(_frmParent.GetAdminManageAccountData());
            if (_countAccount > 0)
            {
                List<ListViewItem> arrListViewItems = new List<ListViewItem>();

                for (int i = 0; i < _countAccount; i++)
                {
                    string AccountInfo = _frmParent.GetAdminManageAccountData();
                    string[] splitInfo = AccountInfo.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    string[] data = new string[11];
                    for (int j = 0; j < 10; j++)
                    {
                        data[j + 1] = splitInfo[j];
                    }
                    ListViewItem lvi;
                    lvi = new ListViewItem(data);

                    arrListViewItems.Add(lvi);
                }
                InfoMessage(ref arrListViewItems);
            }
        }

        TcpClient _server;
        string _username;
        StreamWriter _sw;
        FrmClientAccount _frmParent;

        private delegate void SafeCallLVInfo(ref List<ListViewItem> list);
        void InfoMessage(ref List<ListViewItem> itemList)
        {
            if (lvAccountInfo.InvokeRequired)
            {
                SafeCallLVInfo delInfoMessage = new SafeCallLVInfo(InfoMessage);
                lvAccountInfo.Invoke(delInfoMessage, new object[] { itemList });
            }
            else
            {
                ListViewItem[] list = new ListViewItem[itemList.Count];
                for (int i = 0; i < itemList.Count; i++)
                {
                    list[i] = itemList[i];
                }
                lvAccountInfo.Items.AddRange(list);
            }
        }

        private void tsbtAdd_Click(object sender, EventArgs e)
        {
            FrmAdminAddAccount frmAdminAddAccount = new FrmAdminAddAccount(_server, _frmParent, _sw);
            frmAdminAddAccount.Show();
        }

        //button Delete acc
        private void tsbtDelete_Click(object sender, EventArgs e)
        {
            var listCheckAccount = lvAccountInfo.CheckedItems;
            if (listCheckAccount.Count > 0)
            {
                DialogResult dlr = MessageBox.Show("Confirm delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    string sql = "delete from ACCOUNT where USERNAME in (";
                    for (int i = 0; i < listCheckAccount.Count; i++)
                    {
                        if (i == 0)
                        {
                            sql += "'" + listCheckAccount[i].SubItems[1].Text + "'";
                        }
                        else
                        {
                            sql += ", '" + listCheckAccount[i].SubItems[1].Text + "'";
                        }
                    }
                    sql += ")";
                    _sw.WriteLine("AdminManageCommand:" + sql);
                    _sw.Flush();
                    string receive = _frmParent.GetAdminManageAccountData();
                    if (receive == "DeleteSuccess")
                    {
                        tsbtRefresh.PerformClick();
                        tslbNofication.Text = "Delete successfully";
                        tslbNofication.Visible = true;
                    }
                    else if (receive == "DeleteFail")
                    {
                        tslbNofication.Text = "Delete failed";
                        tslbNofication.Visible = true;
                    }
                }
            }
        }

        //button Refresh
        private void tsbtRefresh_Click(object sender, EventArgs e)
        {
            _sw.WriteLine("Admin Manage Account!!!");
            _sw.Flush();

            int _countAccount = int.Parse(_frmParent.GetAdminManageAccountData());
            if (_countAccount > 0)
            {
                List<ListViewItem> arrListViewItems = new List<ListViewItem>();

                for (int i = 0; i < _countAccount; i++)
                {
                    string AccountInfo = _frmParent.GetAdminManageAccountData();
                    string[] splitInfo = AccountInfo.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    string[] data = new string[11];
                    data[0] = "";
                    for (int j = 0; j < 10; j++)
                    {
                        data[j + 1] = splitInfo[j];
                    }
                    ListViewItem lvi;
                    lvi = new ListViewItem(data);

                    arrListViewItems.Add(lvi);
                }
                lvAccountInfo.Items.Clear();
                InfoMessage(ref arrListViewItems);
                tslbNofication.Text = "Refresh successfully";
                tslbNofication.Visible = true;
            }
            else
            {
                lvAccountInfo.Items.Clear();
            }
        }

        //button Close
        private void tsbtClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //---------------------------------------------------------------------------------------------------
        private void FrmAdminManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmParent.Show();
        }
        private void FrmAdminManage_Load(object sender, EventArgs e)
        {

        }
        private void tsAdminManage_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
