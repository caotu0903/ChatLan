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
using System.Collections;

namespace Chat_Client
{
    public partial class FrmClientAccount : Form
    {
        //UI--------------------------------------------------------------------------------------------------------------
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
        public FrmClientAccount()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //----------------------------------------------------------------------------------------------------------------

        //khai báo--------------------------------------------------------------------------------------------------------
        FrmClientLogin _frmParent;
        TcpClient _server;
        StreamWriter _sw;
        StreamReader _sr;
        string _username, _accountname, _currentchatroom;
        bool _status = false;
        bool _isadmin = false;
        Thread StartListenThread;
        FrmClientMyAccount _frmClientMyAccount;
        Queue<string> _myAccountData = new Queue<string>();
        Queue<string> _adminManageData = new Queue<string>();
        Queue<string> _adminAddData = new Queue<string>();
        Queue<string> _createChatRoomData = new Queue<string>();
        Hashtable _historyChat = new Hashtable();
        Hashtable _chatRoom = new Hashtable();
        List<string> _onlineFriend = new List<string>();
        List<string> _userInCurrentRoom = new List<string>();
        //----------------------------------------------------------------------------------------------------------------
        public FrmClientAccount(TcpClient server, FrmClientLogin frmClientLogin, string username, string accountname, bool isadmin) : this()
        {
            _frmParent = frmClientLogin;
            _server = server;
            _accountname = accountname;
            _username = username;
            _currentchatroom = "All";
            _historyChat.Add("All", "");
            tscbChatRoom.Text = "All";
            _isadmin = isadmin;
            if (_isadmin == true)
            {
                tsManageAccount.Enabled = true;
                tsManageAccount.Visible = true;
            }
            lbUsername.Text = "Welcome, " + _accountname + "!";
            _status = true;
            _sw = new StreamWriter(_server.GetStream());
            StartListenThread = new Thread(new ThreadStart(ListenThread));
            StartListenThread.Start();
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (tbChat.Text != "")
            {
                _sw.WriteLine("SendMessage:");
                _sw.WriteLine(_currentchatroom);
                _sw.WriteLine(tbChat.Text.Trim());
                _sw.Flush();
                tbChat.Clear();
            }
        }
        void ListenThread()
        {
            _sr = new StreamReader(_server.GetStream());
            string data;
            while (_status == true)
            {
                try
                {
                    if (((data = _sr.ReadLine()) != ""))
                    {
                        if (data != null)
                        {
                            if (data.Contains("UpdateAllStatus:"))
                            {
                                data = data.Replace("UpdateAllStatus:", "");
                                string[] splitData = data.Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries);
                                ClearlvStatus();
                                _onlineFriend.Clear();
                                foreach (var s in splitData)
                                {
                                    if (s != _username)
                                    {
                                        _onlineFriend.Add(s);
                                        InfolvStatus(s, 1);
                                    }
                                }
                            }
                            else if (data.Contains("UpdateUserStatusOnl:"))
                            {
                                data = data.Replace("UpdateUserStatusOnl:", "");
                                _onlineFriend.Add(data);
                                InfolvStatus(data, 1);
                            }
                            else if (data.Contains("MyAccount:"))
                            {
                                data = data.Replace("MyAccount:", "");
                                _myAccountData.Enqueue(data);
                            }
                            else if (data.Contains("AdminManageAccount:"))
                            {
                                data = data.Replace("AdminManageAccount:", "");
                                _adminManageData.Enqueue(data);
                            }
                            else if (data.Contains("AdminAddAccount:"))
                            {
                                data = data.Replace("AdminAddAccount:", "");
                                _adminAddData.Enqueue(data);
                            }
                            else if (data.Contains("CreateChatRoom:"))
                            {
                                data = data.Replace("CreateChatRoom:", "");
                                _createChatRoomData.Enqueue(data);
                            }
                            else if (data.Contains("NewChatRoom:"))
                            {
                                NewChatRoom();
                            }
                            else if (data.Contains("Message:"))
                            {
                                ProcessMessageCommand();
                            }
                        }
                    }
                }
                catch
                {
                    StartListenThread.Abort();
                }

            }
        }

        public void ProcessMessageCommand()
        {
            string chatroom = _sr.ReadLine();
            string message = _sr.ReadLine();
            ForwardMessageTo(chatroom, message);
            if (_currentchatroom == chatroom)
            {
                InfoChatAssignMessage(_historyChat[chatroom].ToString());
            }
            else
            {
                AddNotification("New messages in: " + chatroom);
            }
        }

        public void ForwardMessageTo(string chatroom, string data)
        {
            if (_historyChat.ContainsKey(chatroom))
            {
                _historyChat[chatroom] += data + "\r\n";
            }
            else
            {
                _historyChat.Add(chatroom, data + "\r\n");
                AddItemCbChatRoom(chatroom);
            }
        }

        public void NewChatRoom()
        {
            string _roomName = _sr.ReadLine();
            string _ListUser = _sr.ReadLine();
            _historyChat.Add(_roomName, "");
            _chatRoom.Add(_roomName, _ListUser);
            MessageBox.Show("You have been added to the chat room: " + _roomName, "Notification!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AddItemCbChatRoom(_roomName);
        }

        private delegate void SafeCallInfoMessage(string message);
        public void InfoChatAppendMessage(string mess)
        {
            if (tbChatScreen.InvokeRequired)
            {
                SafeCallInfoMessage delInfoMessage = new SafeCallInfoMessage(InfoChatAppendMessage);
                tbChatScreen.Invoke(delInfoMessage, new object[] { mess });
            }
            else
            {
                tbChatScreen.AppendText(mess);
            }
        }

        public void InfoChatAssignMessage(string mess)
        {
            if (tbChatScreen.InvokeRequired)
            {
                tbChatScreen.Invoke((MethodInvoker)(() => tbChatScreen.Text = mess));
            }
            else
            {
                tbChatScreen.Text = mess;
            }
        }

        public void AddNotification(string mess)
        {
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(mess);
            string temp = mess.Replace(" ", "");
            temp = temp.Replace(":", "");
            toolStripMenuItem.Name = temp;
            if (tsAccount.InvokeRequired)
            {
                tsAccount.Invoke((MethodInvoker)(() =>
                {
                    tsddbNotification.Image = Properties.Resources.notification_alert;
                    if (tsddbNotification.DropDownItems.ContainsKey(temp))
                    {
                        tsddbNotification.DropDownItems.RemoveByKey(temp);
                        tsddbNotification.DropDownItems.Add(toolStripMenuItem);
                    }
                    else
                    {
                        tsddbNotification.DropDownItems.Add(toolStripMenuItem);
                    }
                }
                ));
            }
            else
            {
                tsddbNotification.Image = Properties.Resources.notification_alert;
                if (tsddbNotification.DropDownItems.ContainsKey(temp))
                {
                    tsddbNotification.DropDownItems.RemoveByKey(temp);
                    tsddbNotification.DropDownItems.Add(toolStripMenuItem);
                }
                else
                {
                    tsddbNotification.DropDownItems.Add(toolStripMenuItem);
                }
            }
        }

        public void RemoveNotification(string mess)
        {
            string temp = mess.Replace(" ", "");
            temp = temp.Replace(":", "");
            if (tsAccount.InvokeRequired)
            {
                tsAccount.Invoke((MethodInvoker)(() =>
                {
                    if (tsddbNotification.DropDownItems.ContainsKey(mess))
                    {
                        tsddbNotification.DropDownItems.RemoveByKey(mess);
                    }
                    if (tsddbNotification.DropDownItems.Count == 0)
                    {
                        tsddbNotification.Image = Properties.Resources.notification;
                    }
                }
                ));
            }
            else
            {
                if (tsddbNotification.DropDownItems.ContainsKey(temp))
                {
                    tsddbNotification.DropDownItems.RemoveByKey(temp);
                }
                if (tsddbNotification.DropDownItems.Count == 0)
                {
                    tsddbNotification.Image = Properties.Resources.notification;
                }
            }
        }

        private delegate void SafeCallLVInfo(string message, int status);
        public void InfolvStatus(string mess, int status)
        {
            if (lvStatus.InvokeRequired)
            {
                SafeCallLVInfo delInfoMessage = new SafeCallLVInfo(InfolvStatus);
                if (status == 1)
                {
                    lvStatus.Invoke((MethodInvoker)(() => lvStatus.Items.Add(mess)));
                }
            }
            else
            {
                if (status == 1)
                {
                    lvStatus.Items.Add(mess);
                }
            }
        }

        public void ClearlvStatus()
        {
            if (lvStatus.InvokeRequired)
            {
                lvStatus.Invoke((MethodInvoker)(() => lvStatus.Items.Clear()));
            }
            else
            {
                lvStatus.Items.Clear();
            }
        }

        public void AddItemCbChatRoom(string chatroom)
        {
            if (tsAccount.InvokeRequired)
            {
                tsAccount.Invoke((MethodInvoker)(() => tscbChatRoom.Items.Add(chatroom)));
            }
            else
            {
                tscbChatRoom.Items.Add(chatroom);
            }
        }

        //user command
        public string GetMyAccountData()
        {
            while (_myAccountData.Count == 0)
            {
                Wait(100);
            }
            string temp = _myAccountData.Dequeue();
            return temp;
        }
        public string GetAdminManageAccountData()
        {
            while (_adminManageData.Count == 0)
            {
                Wait(100);
            }
            string temp = _adminManageData.Dequeue();
            return temp;
        }
        public string GetAdminAddAccountData()
        {
            while (_adminAddData.Count == 0)
            {
                Wait(100);
            }
            string temp = _adminAddData.Dequeue();
            return temp;
        }

        //show online user
        public List<string> GetOnlineUserList()
        {
            return _onlineFriend;
        }

        //create chat room command
        public string GetCreateChatRoomData()
        {
            while (_createChatRoomData.Count == 0)
            {
                Wait(100);
            }
            string temp = _createChatRoomData.Dequeue();
            return temp;
        }
        public void UpdateListUserInChatRoom(string nameroom)
        {
            string[] splitListUser = _chatRoom[nameroom].ToString().Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries);
            if (tsAccount.InvokeRequired)
            {
                tsAccount.Invoke((MethodInvoker)(() =>
                {
                    tsddbListUser.DropDownItems.Clear();
                    foreach (var user in splitListUser)
                    {
                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(user);
                        tsddbListUser.DropDownItems.Add(toolStripMenuItem);
                    }
                }
            ));
            }
            else
            {
                tsddbListUser.DropDownItems.Clear();
                foreach (var user in splitListUser)
                {
                    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(user);
                    tsddbListUser.DropDownItems.Add(toolStripMenuItem);
                }
            }
        }

        //wait for adding to queue
        public void Wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

        //button Edit account
        private void tsEditAccount_Click(object sender, EventArgs e)
        {
            _sw.WriteLine("Get my account infomation!!!");
            _sw.Flush();
            _frmClientMyAccount = new FrmClientMyAccount(_server, _username, this, _sw);
            _frmClientMyAccount.Show();
            this.Hide();
        }

        //button Manage account if admin
        private void tsManageAccount_Click(object sender, EventArgs e)
        {
            _sw.WriteLine("Admin Manage Account!!!");
            _sw.Flush();
            FrmAdminManage _frmAdminManage = new FrmAdminManage(_server, _username, this, _sw);
            _frmAdminManage.Show();
            this.Hide();
        }

        //button create chat room
        private void tsbtCreateChatRoom_Click_1(object sender, EventArgs e)
        {
            FrmClientCreateChatRoom frmClientCreateChatRoom = new FrmClientCreateChatRoom(_server, this);
            frmClientCreateChatRoom.Show();
        }

        private void tscbChatRoom_DropDownClosed(object sender, EventArgs e)
        {
            if (_currentchatroom != tscbChatRoom.Text)
            {
                _currentchatroom = tscbChatRoom.Text;
                InfoChatAssignMessage(_historyChat[_currentchatroom].ToString());
                RemoveNotification("New messages in: " + _currentchatroom);
                if (_chatRoom.ContainsKey(_currentchatroom))
                {
                    tsddbListUser.Enabled = true;
                    tsddbListUser.Visible = true;
                    UpdateListUserInChatRoom(_currentchatroom);
                }
                else
                {
                    tsddbListUser.Enabled = false;
                    tsddbListUser.Visible = false;
                }
            }
        }

        private void tsddbNotification_DropDownOpened(object sender, EventArgs e)
        {
            if (tsAccount.InvokeRequired)
            {
                tsAccount.Invoke((MethodInvoker)(() =>
                {
                    tsddbNotification.Image = Properties.Resources.notification;
                }
                ));
            }
            else
            {
                tsddbNotification.Image = Properties.Resources.notification;
            }
        }

        private void lvStatus_DoubleClick(object sender, EventArgs e)
        {
            _currentchatroom = lvStatus.SelectedItems[0].Text;
            if (_historyChat.ContainsKey(_currentchatroom))
            {
                InfoChatAssignMessage(_historyChat[_currentchatroom].ToString());
                tscbChatRoom.Text = _currentchatroom;
            }
            else
            {
                _historyChat.Add(_currentchatroom, "");
                InfoChatAssignMessage(_historyChat[_currentchatroom].ToString());
                tscbChatRoom.Items.Add(_currentchatroom);
                tscbChatRoom.Text = _currentchatroom;
            }
        }

        //enter to send
        private void tbChat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btSend.PerformClick();
            }
        }
        
        //button Logout
        private void tsLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Close form
        private void FrmClientAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sw.WriteLine("Quit");
            _sw.Flush();
            _status = false;
            _frmParent.Show();
            _frmParent.ClickbtConnect();
            _frmParent.ClickbtConnect();
            _frmParent.HidelbNofication();
        }

        //---------------------------------------------------------------------------
        private void FrmClientAccount_Load(object sender, EventArgs e)
        {

        }
        //UI
        private void tsAccount_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lbUsername_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
