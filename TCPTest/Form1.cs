using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocketIP;

namespace TCPTest
{
    public partial class Form1 : Form
    {
        CClientSocket soc;
        public Form1()
        {
            InitializeComponent();

            btnConnect.Click += (o, e) =>
            {
                txbData.Text = string.Format("Connect to: {0}:{1}", txbAddress.Text, nmPort.Value);
                soc = new CClientSocket(txbAddress.Text, (int)nmPort.Value);
                soc.OnConnect += (_soc) =>
                {
                    Invoke((MethodInvoker)delegate
                    {
                        txbData.AppendText(string.Format("Socket {0} is connected", _soc.RemoteEndPoint.ToString()));
                        //btnConnect.Text = "Disconnect";
                    });
                };
                soc.OnRead += (_soc) =>
                {
                    Invoke((MethodInvoker)delegate
                    {
                        txbData.AppendText(string.Format("Receive {0}:: Data: {1}", _soc.ToString(), soc.ReceivedText));
                    });
                };
                soc.OnDisconnect += (_soc) =>
                {
                    Invoke((MethodInvoker)delegate
                    {
                        txbData.AppendText(string.Format("Disconnect {0}", _soc.ToString()));
                        //btnConnect.Text = "Connect";
                    });
                };
                soc.Connect();
            };

            btnSend.Click += (o, e) =>
            {
                soc.SendText(txbSend.Text);
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            soc.Disconnect();
        }
    }
}
