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
    public partial class FrmClientCreateChatRoom : Form
    {
        // ---- UI ---- //
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
        public FrmClientCreateChatRoom()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        // ---- UI ---- //

        public FrmClientCreateChatRoom(TcpClient server, FrmClientAccount frmClientAccount) : this()
        {
            _server = server;
            _frmClientAccount = frmClientAccount;
            _sw = new StreamWriter(_server.GetStream());
            _listOnlineUser = _frmClientAccount.GetOnlineUserList();

            List<ListViewItem> arrListViewItems = new List<ListViewItem>();

            foreach (var user in _listOnlineUser)
            {
                ListViewItem lvi;
                lvi = new ListViewItem(user);

                arrListViewItems.Add(lvi);
            }
            InfolvUserOnline(ref arrListViewItems);
        }

        TcpClient _server;
        FrmClientAccount _frmClientAccount;
        StreamWriter _sw;
        List<string> _listOnlineUser;

        private void btCreateRoom_Click_1(object sender, EventArgs e)
        {
            if (tbRoomName.Text != "")
            {
                var listCheckUser = lvOnlineUser.CheckedItems;
                if (listCheckUser.Count != 0)
                {
                    _sw.WriteLine("CreateChatRoom:");
                    _sw.WriteLine(tbRoomName.Text.Trim());
                    _sw.WriteLine(listCheckUser.Count);
                    for (int i = 0; i < listCheckUser.Count; i++)
                    {
                        _sw.WriteLine(listCheckUser[i].Text);
                    }
                    _sw.Flush();
                    string receiveData = _frmClientAccount.GetCreateChatRoomData();
                    if (receiveData == "Success")
                    {
                        this.Close();
                    }
                    else if (receiveData == "RoomAlreadyExists")
                    {
                        lbNotification.Text = "Room name already exists, try another name";
                        lbNotification.Visible = true;
                    }
                    else if (receiveData == "Fail")
                    {
                        lbNotification.Text = "Create room fail, please try again";
                        lbNotification.Visible = true;
                    }
                }
                else
                {
                    lbNotification.Text = "Please select the user you want to add to the chat room";
                    lbNotification.Visible = true;
                }
            }
            else
            {
                lbNotification.Text = "Room name cannot be empty";
                lbNotification.Visible = true;
            }
        }

        private delegate void SafeCallLVUserOnl(ref List<ListViewItem> list);
        void InfolvUserOnline(ref List<ListViewItem> itemList)
        {
            if (lvOnlineUser.InvokeRequired)
            {
                SafeCallLVUserOnl delInfoMessage = new SafeCallLVUserOnl(InfolvUserOnline);
                lvOnlineUser.Invoke(delInfoMessage, new object[] { itemList });
            }
            else
            {
                ListViewItem[] list = new ListViewItem[itemList.Count];
                for (int i = 0; i < itemList.Count; i++)
                {
                    list[i] = itemList[i];
                }
                lvOnlineUser.Items.AddRange(list);
            }
        }

        private void tbRoomName_TextChanged(object sender, EventArgs e)
        {
            lbNotification.Visible = false;
        }

        private void lvOnlineUser_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            lbNotification.Visible = false;
        }

        private void FrmClientCreateChatRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmClientAccount.Show();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmClientCreateChatRoom_Load(object sender, EventArgs e)
        {

        }

        private void FrmClientCreateChatRoom_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
