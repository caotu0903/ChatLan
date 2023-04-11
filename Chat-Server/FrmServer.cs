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
using System.Threading;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using System.Runtime.InteropServices;

namespace Chat_Server
{
    public partial class FrmServer : Form
    {
        public SqlConnection _sqlConnection;
        public string sql;
        public DataSet dataSet;
        public SqlDataAdapter sqlDataAdapter;
        Thread StartListen;

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
        public FrmServer()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //---------------------------------------------------------------------------------------------------------------
        
        public bool IsListen;
        public static Hashtable htClient = new Hashtable(30);
        public static Hashtable htChatRoom = new Hashtable();

        private void btListen_Click(object sender, EventArgs e)
        {
            if (btListen.Text == "Listen")
            {
                IsListen = true;
                btListen.Enabled = false;
                tbIP.ReadOnly = true;
                tbPort.ReadOnly = true;
                StartListen = new Thread(new ThreadStart(ListenThread));
                StartListen.Start();
                _sqlConnection = new SqlConnection(@"Data Source=DESKTOP-S5SHTAR\SQLEXPRESS;Initial Catalog=CHAT;Integrated Security=True");
                _sqlConnection.Open();
            }
        }
        void ListenThread()
        {
            IPEndPoint ipEndpoint = new IPEndPoint(IPAddress.Parse(tbIP.Text), int.Parse(tbPort.Text));
            TcpListener tcpListener = new TcpListener(ipEndpoint);
            tcpListener.Start();
            TcpClient tcpClient = new TcpClient();
            while (IsListen)
            {
                tcpClient = tcpListener.AcceptTcpClient();
                Connection connection = new Connection(tcpClient, this);
            }    
        }

        //send tin nhắn---------------------------------------------------------------------------------------
        public static void SendMessageToAll(string fromusername, string message)
        {
            StreamWriter serverWriter;
            TcpClient[] tcpClients = new TcpClient[htClient.Count];
            htClient.Values.CopyTo(tcpClients, 0);
            foreach (var client in tcpClients)
            {
                if (message.Trim() == "" || client == null)
                {
                    continue;
                }

                serverWriter = new StreamWriter(client.GetStream());
                serverWriter.WriteLine("Message:");
                serverWriter.WriteLine("All");
                serverWriter.WriteLine(fromusername + ": " + message);
                serverWriter.Flush();
                serverWriter = null;
            }
        }
        public static void SendMessage(string username, string message)
        {
            StreamWriter serverWriter;
            TcpClient[] tcpClients = new TcpClient[htClient.Count];
            htClient.Values.CopyTo(tcpClients, 0);
            foreach (var client in tcpClients)
            {
                if (message.Trim() == "" || client == null)
                {
                    continue;
                }

                serverWriter = new StreamWriter(client.GetStream());
                serverWriter.WriteLine("Message:" + username + ": " + message);
                serverWriter.Flush();
                serverWriter = null;
            }
        }
        public static void SendMessageFromServer(string message)
        {
            StreamWriter serverWriter;
            TcpClient[] tcpClients = new TcpClient[htClient.Count];
            htClient.Values.CopyTo(tcpClients, 0);
            foreach (var client in tcpClients)
            {
                if (message.Trim() == "" || client == null)
                {
                    continue;
                }

                serverWriter = new StreamWriter(client.GetStream());
                serverWriter.WriteLine(message);
                serverWriter.Flush();
                serverWriter = null;
            }
        }
        public static void SendMessageFromServerExceptUser(string message, TcpClient username)
        {
            StreamWriter serverWriter;
            TcpClient[] tcpClients = new TcpClient[htClient.Count];
            htClient.Values.CopyTo(tcpClients, 0);
            foreach (var client in tcpClients)
            {
                if (message.Trim() == "" || client == null || username == client)
                {
                    continue;
                }

                serverWriter = new StreamWriter(client.GetStream());
                serverWriter.WriteLine(message);
                serverWriter.Flush();
                serverWriter = null;
            }
        }

        //Server's functions
        public static void AddClient(TcpClient tcpClient, string username)
        {
            htClient.Add(username, tcpClient);
        }
        public static void DeleteClient(TcpClient tcpClient, string username)
        {
            htClient.Remove(username);
        }

        //message
        public delegate void SafeCallInfoMessage(string message);
        public void InfoMessage(string mess)
        {
            if (this.tbNofication.InvokeRequired)
            {
                SafeCallInfoMessage delInfoMessage = new SafeCallInfoMessage(InfoMessage);
                this.tbNofication.Invoke(delInfoMessage, new object[] { mess });
            }
            else
            {
                this.tbNofication.AppendText(mess);
            }
        }

        //Password
        public static string EncryptPass(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        public string DecryptPass(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        //thực hiện kết nối
        public class Connection
        {
            public StreamReader _sr;
            public StreamWriter _sw;
            public TcpClient _client;
            public Thread _mess;
            public string _username;
            public string _accountname;
            public string _password;
            public string _stringmess;
            public FrmServer _frmServer;
            public string _sql;
            public DataTable _dataTable;
            public SqlDataAdapter _sqlDataAdapter;
            public int _row;
            public bool _login = false;
            public bool _isadmin = false;

            public Connection(TcpClient tcpClient, FrmServer frmServer)
            {
                _frmServer = frmServer;
                _client = tcpClient;
                _mess = new Thread(AcceptClient);
                _mess.Start();
            }
            public void CloseConnection()
            {
                _sw.Close();
                _sr.Close();
                _client.Close();
            }

            //sau khi kết nối thành công
            public void AcceptClient()
            {
                _sr = new StreamReader(_client.GetStream());
                _sw = new StreamWriter(_client.GetStream());
                //----------------------------------------------------------------------------------------------------
                while (_login == false)
                {
                    _username = _sr.ReadLine();
                    
                    if (_username != null)
                    {//trường hợp đăng nhập---------------------------------------------------------------------------
                        if (_username != "New account")
                        {
                            _sql = "select USERNAME from ACCOUNT where USERNAME = '" + _username + "'";
                            _dataTable = new DataTable();
                            _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                            _row = _sqlDataAdapter.Fill(_dataTable);
                            if (_row == 1)
                            {
                                _password = _sr.ReadLine();
                                _sql = "select PASSWORD from ACCOUNT where USERNAME = '" + _username + "'";
                                string DecryptPass;
                                _dataTable = new DataTable();
                                _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                                _sqlDataAdapter.Fill(_dataTable);
                                DecryptPass = _frmServer.DecryptPass(_dataTable.Rows[0].ItemArray[0].ToString());
                                if (_password == DecryptPass)
                                {
                                    if (htClient.ContainsKey(_username) == true)
                                    {
                                        _sw.WriteLine("User is online.");
                                        _sw.Flush();
                                    }
                                    else
                                    {//trường hợp user là admin
                                        _sql = "select ACCOUNTNAME,ISADMIN from ACCOUNT where USERNAME = '" + _username + "'";
                                        _dataTable = new DataTable();
                                        _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                                        _row = _sqlDataAdapter.Fill(_dataTable);
                                        _accountname = _dataTable.Rows[0].ItemArray[0].ToString();
                                        if (_dataTable.Rows[0].ItemArray[1].ToString() == "True")
                                        {
                                            _isadmin = true;
                                        }
                                        else
                                        {
                                            _isadmin = false;
                                        }
                                        AddClient(_client, _username);
                                        _sw.WriteLine(_accountname);
                                        _sw.WriteLine(_isadmin);
                                        _sw.Flush();
                                        UpdateStatus(_username, 1); //cập nhật status
                                        SendAllUserStatus(_username);
                                        SendMessageFromServerExceptUser("UpdateUserStatusOnl:" + _username,_client);
                                        _login = true;
                                    }
                                }
                                else
                                {
                                    _sw.WriteLine("Password is not correct.");
                                    _sw.Flush();
                                }
                            }
                            else
                            {
                                string password = _sr.ReadLine();
                                _sw.WriteLine("Username is not correct.");
                                _sw.Flush();
                            }
                        }
                        else //trường hợp đăng kí
                        {
                            string username = _sr.ReadLine();
                            string accountname = _sr.ReadLine();
                            string password = _sr.ReadLine();
                            string firstname = _sr.ReadLine();
                            string lastname = _sr.ReadLine();
                            string dateofbirth = _sr.ReadLine();
                            string phonenumber = _sr.ReadLine();
                            string gender = _sr.ReadLine();
                            
                            _sql = "select USERNAME from ACCOUNT where USERNAME = '" + username + "'";
                            _dataTable = new DataTable();
                            _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                            _row = _sqlDataAdapter.Fill(_dataTable);
                            if (_row == 1)
                            {
                                _sw.WriteLine("Username has existed");
                                _sw.Flush();
                            }
                            else
                            {
                                password = EncryptPass(password);
                                _sql = "set dateformat DMY ";
                                _sql += "insert into ACCOUNT (USERNAME, ACCOUNTNAME, PASSWORD, FIRSTNAME, "+
                                    "LASTNAME, DATEOFBIRTH, PHONENUMBER, GENDER,  STATUS, CREATETIME, ISADMIN) values (";
                                _sql += "'" + username + "','" + accountname + "','" + password + "', N'" + firstname + "' , N'" 
                                    + lastname + "', '" + dateofbirth + "', " + phonenumber + ",'" + gender + "'," + 0 + ", getdate()" +
                                    ", 0)";
                                SqlCommand cmd = new SqlCommand(_sql, _frmServer._sqlConnection);
                                cmd.ExecuteNonQuery();
                                _frmServer.InfoMessage("Account " + username + " has been created\r\n");
                                _sw.WriteLine("Success");
                                _sw.Flush();
                            }
                        }
                    }
                }
                
                try
                {
                    while (_login == true)
                    {
                        if ((_stringmess = _sr.ReadLine()) != "")
                        {
                            if (_stringmess == null)
                            {

                            }
                            else
                            {
                                if (_stringmess == "Quit") //trường hợp logout
                                {
                                    UpdateStatus(_username, 0);
                                    DeleteClient(_client, _username);
                                    string sendAll = SendAllUserStatus(_username);
                                    SendMessageFromServer("UpdateAllStatus:" + sendAll);
                                    _login = false;
                                }
                                else if (_stringmess == "Get my account infomation!!!") //trường hợp xem profile
                                {
                                    _sql = "select ACCOUNTNAME, FIRSTNAME, LASTNAME, CONVERT(varchar(10), DATEOFBIRTH ,103) as DATEOFBIRTH, " +
                                        "PHONENUMBER, GENDER from ACCOUNT where USERNAME = '" + _username + "'";
                                    _dataTable = new DataTable();
                                    _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                                    _row = _sqlDataAdapter.Fill(_dataTable);
                                    string accountname = _dataTable.Rows[0].ItemArray[0].ToString();
                                    string firstname = _dataTable.Rows[0].ItemArray[1].ToString();
                                    string lastname = _dataTable.Rows[0].ItemArray[2].ToString();
                                    string dateofbirth = _dataTable.Rows[0].ItemArray[3].ToString();
                                    string phonenumber = _dataTable.Rows[0].ItemArray[4].ToString();
                                    string gender = _dataTable.Rows[0].ItemArray[5].ToString();
                                    _sw.WriteLine("MyAccount:" + accountname);
                                    _sw.WriteLine("MyAccount:" + firstname);
                                    _sw.WriteLine("MyAccount:" + lastname);
                                    _sw.WriteLine("MyAccount:" + dateofbirth);
                                    _sw.WriteLine("MyAccount:" + phonenumber);
                                    _sw.WriteLine("MyAccount:" + gender);
                                    _sw.Flush();
                                }
                                else if (_stringmess == "Change infomation!!!") //trường hợp edit profile
                                {
                                    string password = _sr.ReadLine();
                                    _sql = "select PASSWORD from ACCOUNT where USERNAME = '" + _username + "'";
                                    _dataTable = new DataTable();
                                    _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                                    _sqlDataAdapter.Fill(_dataTable);
                                    string DecryptPass = _frmServer.DecryptPass(_dataTable.Rows[0].ItemArray[0].ToString());
                                    if (password == DecryptPass)
                                    {
                                        _sw.WriteLine("MyAccount:PASSWORD CONFIRMED");
                                        _sw.Flush();

                                        string firstname = _sr.ReadLine();
                                        string lastname = _sr.ReadLine();
                                        string dateofbirth = _sr.ReadLine();
                                        string phonenumber = _sr.ReadLine();
                                        string gender = _sr.ReadLine();
                                        string accountname = _sr.ReadLine();
                                        _sql = "set dateformat DMY ";
                                        _sql += "update ACCOUNT set FIRSTNAME = N'" + firstname + "', LASTNAME = N'" + lastname + "'," +
                                            " DATEOFBIRTH = '" + dateofbirth + "', PHONENUMBER = " + phonenumber + ", GENDER = '" +
                                            gender + "', ACCOUNTNAME = '" + accountname + "' where USERNAME = '" + _username + "'";
                                        SqlCommand cmd = new SqlCommand(_sql, _frmServer._sqlConnection);
                                        cmd.ExecuteNonQuery();

                                        _sw.WriteLine("MyAccount:UPDATE SUCCESS");
                                        _sw.Flush();
                                    }
                                    else
                                    {
                                        _sw.WriteLine("MyAccount:PASSWORD WRONG");
                                        _sw.Flush();
                                    }
                                }
                                else if (_stringmess == "Admin Manage Account!!!") //trường hợp admin quản lí account
                                {
                                    _sql = "select USERNAME, PASSWORD, ACCOUNTNAME, FIRSTNAME, LASTNAME, " +
                                        "CONVERT(varchar(10), DATEOFBIRTH ,103) as DATEOFBIRTH, " +
                                        "PHONENUMBER, GENDER, STATUS, CREATETIME from ACCOUNT where ISADMIN = 0";
                                    _dataTable = new DataTable();
                                    _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                                    _row = _sqlDataAdapter.Fill(_dataTable);
                                    _sw.WriteLine("AdminManageAccount:" + _row);
                                    if (_row > 0)
                                    {
                                        for (int i = 0; i < _row; i++)
                                        {
                                            string data = _dataTable.Rows[i].ItemArray[0].ToString() + "|" + _dataTable.Rows[i].ItemArray[1].ToString()
                                                + "|" + _dataTable.Rows[i].ItemArray[2].ToString() + "|" + _dataTable.Rows[i].ItemArray[3].ToString()
                                                + "|" + _dataTable.Rows[i].ItemArray[4].ToString() + "|" + _dataTable.Rows[i].ItemArray[5].ToString()
                                                + "|" + _dataTable.Rows[i].ItemArray[6].ToString() + "|" + _dataTable.Rows[i].ItemArray[7].ToString()
                                                + "|" + _dataTable.Rows[i].ItemArray[8].ToString() + "|" + _dataTable.Rows[i].ItemArray[9].ToString();
                                            _sw.WriteLine("AdminManageAccount:" + data);
                                        }
                                    }
                                    _sw.Flush();
                                }
                                else if (_stringmess == "Admin Add Account!!!") //trường hợp admin add account
                                {
                                    string username = _sr.ReadLine();
                                    string accountname = _sr.ReadLine();
                                    string password = _sr.ReadLine();
                                    string firstname = _sr.ReadLine();
                                    string lastname = _sr.ReadLine();
                                    string dateofbirth = _sr.ReadLine();
                                    string phonenumber = _sr.ReadLine();
                                    string gender = _sr.ReadLine();

                                    _sql = "select USERNAME from ACCOUNT where USERNAME = '" + username + "'";
                                    _dataTable = new DataTable();
                                    _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                                    _row = _sqlDataAdapter.Fill(_dataTable);
                                    if (_row == 1)
                                    {
                                        _sw.WriteLine("AdminAddAccount:Username has been existed");
                                        _sw.Flush();
                                    }
                                    else
                                    {
                                        password = EncryptPass(password);
                                        _sql = "set dateformat DMY ";
                                        _sql += "insert into ACCOUNT (USERNAME, ACCOUNTNAME, PASSWORD, FIRSTNAME, " +
                                            "LASTNAME, DATEOFBIRTH, PHONENUMBER, GENDER,  STATUS, CREATETIME, ISADMIN) values (";
                                        _sql += "'" + username + "','" + accountname + "','" + password + "', N'" + firstname + "' , N'"
                                            + lastname + "', '" + dateofbirth + "', " + phonenumber + ",'" + gender + "'," + 0 + ", getdate()" +
                                            ", 0)";
                                        SqlCommand cmd = new SqlCommand(_sql, _frmServer._sqlConnection);
                                        cmd.ExecuteNonQuery();
                                        _frmServer.InfoMessage("Account " + username + " has been added\r\n");
                                        _sw.WriteLine("AdminAddAccount:Success");
                                        _sw.Flush();
                                    }
                                }
                                else if (_stringmess.Contains("AdminManageCommand:")) //trường hợp admin delete acc, refresh dtb, close dtb
                                {
                                    try
                                    {
                                        _stringmess = _stringmess.Replace("AdminManageCommand:", "");
                                        _sql = _stringmess;
                                        SqlCommand cmd = new SqlCommand(_sql, _frmServer._sqlConnection);
                                        cmd.ExecuteNonQuery();
                                        _sw.WriteLine("AdminManageAccount:DeleteSuccess");
                                        _sw.Flush();
                                    }
                                    catch
                                    {
                                        _sw.WriteLine("AdminManageAccount:DeleteFail");
                                        _sw.Flush();
                                    }
                                }
                                else if (_stringmess.Contains("CreateChatRoom:")) //trường hợp tạo group chat
                                {
                                    CreateChatRoom();
                                }
                                else if (_stringmess.Contains("SendMessage:")) //trường hợp gửi tin nhắn
                                {
                                    ForwardMessage();
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }

            public void ForwardMessage()
            {
                string _destination = _sr.ReadLine();
                string _message = _sr.ReadLine();
                if (_destination == "All") //Gửi tin nhắn tới All
                {
                    SendMessageToAll(_accountname, _message);
                }
                else if (htClient.ContainsKey(_destination)) //Gửi tin nhắn private
                {
                    TcpClient destinationClient = (TcpClient)htClient[_destination];
                    StreamWriter destinationWriter = new StreamWriter(destinationClient.GetStream());
                    destinationWriter.WriteLine("Message:");
                    destinationWriter.WriteLine(_username);
                    destinationWriter.WriteLine(_accountname + ": " + _message);
                    destinationWriter.Flush();
                    _sw.WriteLine("Message:");
                    _sw.WriteLine(_destination);
                    _sw.WriteLine(_accountname + ": " + _message);
                    _sw.Flush();
                }
                else if (htChatRoom.ContainsKey(_destination)) //Gửi tin nhắn group
                {
                    string[] listUser = GetListUser(htChatRoom[_destination].ToString());
                    foreach (var user in listUser)
                    {
                        if (htClient.ContainsKey(user))
                        {
                            TcpClient destinationClient = (TcpClient)htClient[user];
                            StreamWriter destinationWriter = new StreamWriter(destinationClient.GetStream());
                            destinationWriter.WriteLine("Message:");
                            destinationWriter.WriteLine(_destination);
                            destinationWriter.WriteLine(_accountname + ": " + _message);
                            destinationWriter.Flush();
                        }
                    }
                }
            }
            public void CreateChatRoom()
            {
                try
                {
                    //Nhận dữ liệu room và user trong room
                    string _roomName = _sr.ReadLine();
                    int _numberUser = int.Parse(_sr.ReadLine());
                    List<string> _listUser = new List<string>(_numberUser);
                    for (int i = 0; i < _numberUser; i++)
                    {
                        _listUser.Add(_sr.ReadLine());
                    }

                    if (!htChatRoom.ContainsKey(_roomName))
                    {
                        //Thêm ChatRoom vào htChatRoom của Server
                        htChatRoom.Add(_roomName, "");
                        foreach (var user in _listUser)
                        {
                            htChatRoom[_roomName] += user + "?";
                        }
                        htChatRoom[_roomName] += _username;

                        //Gửi dữ liệu tạo room đến các user
                        for (int i = 0; i < _numberUser; i++)
                        {
                            if (htClient.ContainsKey(_listUser[i]))
                            {
                                TcpClient destinationClient = (TcpClient)htClient[_listUser[i]];
                                StreamWriter destinationWriter = new StreamWriter(destinationClient.GetStream());
                                destinationWriter.WriteLine("NewChatRoom:");
                                destinationWriter.WriteLine(_roomName);
                                string ListUser = "";
                                foreach (var user in _listUser)
                                {
                                    if (user != _listUser[i])
                                    {
                                        ListUser += user + "?";
                                    }
                                }
                                ListUser += _username;
                                destinationWriter.WriteLine(ListUser);
                                destinationWriter.Flush();
                            }
                        }

                        //Thông báo tạo room thành công
                        _sw.WriteLine("CreateChatRoom:Success");

                        //Gửi dữ liệu tạo room đến user tạo room
                        _sw.WriteLine("NewChatRoom:");
                        _sw.WriteLine(_roomName);
                        string ListUserName = "";
                        foreach (var user in _listUser)
                        {
                            ListUserName += user + "?";
                        }
                        _sw.WriteLine(ListUserName);
                        _sw.Flush();
                    }
                    else if (htChatRoom.ContainsKey(_roomName))
                    {
                        _sw.WriteLine("CreateChatRoom:RoomAlreadyExists");
                        _sw.Flush();
                    }
                }
                catch
                {
                    _sw.WriteLine("CreateChatRoom:Fail");
                    _sw.Flush();
                }
            }

            public string[] GetListUser(string list)
            {
                string[] temp = list.Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries);
                return temp;
            }
            //cập nhật status
            public void UpdateStatus(string username, int status)
            {
                _sql = "update ACCOUNT set STATUS = " + status + " where USERNAME = '" + username + "'";
                SqlCommand cmd = new SqlCommand(_sql, _frmServer._sqlConnection);
                cmd.ExecuteNonQuery();
                if (status == 0)
                {
                    _frmServer.InfoMessage("User: " + username + " is offline!\r\n");
                }
                else if (status == 1)
                {
                    _frmServer.InfoMessage("User: " + username + " is online!\r\n");
                }
            }
            //hiển thị status online cho user
            public string SendAllUserStatus(string username)
            {
                _sql = "select USERNAME from ACCOUNT where USERNAME != '" + username + "' and status = 1";
                DataTable _dataTable = new DataTable();
                _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                string getUserStatus = "";
                _row = _sqlDataAdapter.Fill(_dataTable);
                if (_row > 0)
                {
                    for (int i = 0; i < _row; i++)
                    {
                        if (_dataTable.Rows[i].ItemArray[0].ToString() != _username)
                        {
                            getUserStatus += _dataTable.Rows[i].ItemArray[0].ToString() + "?";
                        }
                    }
                    _sw.WriteLine("UpdateAllStatus:" + getUserStatus);
                    _sw.Flush();
                    return getUserStatus;
                }
                return getUserStatus;
            }
        }
        //đóng form
        private void FrmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            string _sql = "update ACCOUNT set STATUS = 0";
            SqlCommand cmd = new SqlCommand(_sql, _sqlConnection);
            cmd.ExecuteNonQuery();
        }
        //---------------------------------------------------------------
        private void FrmServer_Load(object sender, EventArgs e)
        {

        }
        private void FrmServer_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
