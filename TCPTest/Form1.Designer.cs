namespace TCPTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txbAddress = new System.Windows.Forms.TextBox();
            this.nmPort = new System.Windows.Forms.NumericUpDown();
            this.txbData = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txbSend = new System.Windows.Forms.TextBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.btnClear = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nmPort)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(296, 9);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // txbAddress
            // 
            this.txbAddress.Location = new System.Drawing.Point(12, 12);
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.Size = new System.Drawing.Size(161, 20);
            this.txbAddress.TabIndex = 1;
            this.txbAddress.Text = "192.168.4.1";
            // 
            // nmPort
            // 
            this.nmPort.Location = new System.Drawing.Point(190, 11);
            this.nmPort.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.nmPort.Name = "nmPort";
            this.nmPort.Size = new System.Drawing.Size(82, 20);
            this.nmPort.TabIndex = 2;
            this.nmPort.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // txbData
            // 
            this.txbData.Location = new System.Drawing.Point(12, 39);
            this.txbData.Multiline = true;
            this.txbData.Name = "txbData";
            this.txbData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbData.Size = new System.Drawing.Size(458, 433);
            this.txbData.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(397, 487);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // txbSend
            // 
            this.txbSend.Location = new System.Drawing.Point(12, 488);
            this.txbSend.Name = "txbSend";
            this.txbSend.Size = new System.Drawing.Size(379, 20);
            this.txbSend.TabIndex = 1;
            this.txbSend.Text = "$$,11.1444,6.2323,13.4445,$$       ";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(395, 10);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 4;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(476, 11);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(656, 497);
            this.zedGraphControl1.TabIndex = 5;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(481, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 522);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.txbData);
            this.Controls.Add(this.nmPort);
            this.Controls.Add(this.txbSend);
            this.Controls.Add(this.txbAddress);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Check Voltage for System Nitfy";
            ((System.ComponentModel.ISupportInitialize)(this.nmPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txbAddress;
        private System.Windows.Forms.NumericUpDown nmPort;
        private System.Windows.Forms.TextBox txbData;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txbSend;
        private System.Windows.Forms.Button btnDisconnect;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Timer timer1;
        //private ZedGraphView.ZedGraphControl zedGraphControl1;
    }
}

