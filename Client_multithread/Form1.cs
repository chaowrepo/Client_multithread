using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client_multithread {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void bt_send_Click(object sender, EventArgs e) {
            OperatingSystem os = Environment.OSVersion;
            exception ex = new exception();
            ex.DateTime = DateTime.Now.ToString();
            ex.UserName = System.Windows.Forms.SystemInformation.UserName;
            ex.OperatingSystem = os.Platform.ToString();
            ex.Title = "Critical";
            ex.StackTrace = "StackTrace";
            SendException("127.0.0.1", 3000, ex);
        }

        private void SendException(string host, int port, exception e) {
            try {
                TcpClient client = new TcpClient();
                client.Connect(host, port);
                NetworkStream stream = client.GetStream();
                byte[] data = e.GetData();
                stream.Write(data, 0, data.Length);
                stream.Close();
                client.Client.Close();
            }
            catch (Exception) {
                MessageBox.Show("Cannot connect to server.");
            }
        }
    }
}