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
//using ZedGraphView;

namespace TCPTest
{
    public partial class Form1 : Form
    {
        CClientSocket soc;
        ZedGraphView zedview;
        double volt, volt1, volt2;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
                    {
                        //Format receive: $$,11.1444,6.2323,13.4445,$$  (Hercules - TCP Server)
                        //string strdata = soc.ReceivedText;
                        byte [] bytes = soc.ReceivedBytes;
                        string strdata = Encoding.Default.GetString(bytes);
                        //txbData.AppendText(string.Format("Receive {0}:: Data: {1}", _soc.ToString(), strdata));
                        txbData.AppendText(strdata + "  \r\n");
                        string[] subdata = strdata.Split(',');
                        int index = 0;
                        for (index = 0; index < subdata.Length; index++)
                        {
                            if (subdata[index] == "#")
                            {
                                break;
                            }
                        }
                    //
                    if ((index > 0) && (subdata.Length > index + 3))
                        {
                            double.TryParse(subdata[index+1], out volt); //Volt 1
                            double.TryParse(subdata[index+2], out volt1); //Volt 2
                            double.TryParse(subdata[index+3], out volt2); //Volt 3
                            zedview.Draw(volt, volt1, volt2);
                        }
                    });
               } 


        public Form1()
        {
            InitializeComponent();

            zedview = new ZedGraphView(ref zedGraphControl1); //init
            zedview.Init();

            //Events ----
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
                        timer1.Enabled = true;
                    });
                    
                };
                //soc.OnRead += (_soc) =>
                //{
                //    Invoke((MethodInvoker)delegate
                //    {
                //        //Format receive: $$,11.1444,6.2323,13.4445,$$  (Hercules - TCP Server)
                //        string strdata = soc.ReceivedText;
                //        //txbData.AppendText(string.Format("Receive {0}:: Data: {1}", _soc.ToString(), strdata));
                //        txbData.AppendText(strdata + "  \r\n");
                //        string[] subdata = strdata.Split(',');
                //        //
                //        if (subdata[0] == "$")
                //        {
                //            if (subdata.Length >= 3)
                //            {
                //                if (subdata[1] != null)
                //                {
                //                    double.TryParse(subdata[1], out volt); //Volt 1
                //                    double.TryParse(subdata[2], out volt1); //Volt 2
                //                    double.TryParse(subdata[3], out volt2); //Volt 3
                //                    zedview.Draw(volt, volt1, volt2);
                //                }
                //            }

                            
                //        }
                //    });
                //};
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

            btnDisconnect.Click += (o, e) =>
            {
                soc.Disconnect();
            };
            //
            btnSend.Click += (o, e) =>
            {
                soc.SendText(txbSend.Text);
            };
            //
            btnClear.Click += (o, e) => zedview.Init();
        }
    }
}
