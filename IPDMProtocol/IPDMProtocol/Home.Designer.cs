namespace IPDMProtocol
{
    partial class Home
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.serialValue = new System.Windows.Forms.TextBox();
            this.showBtn = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.stopBtn = new System.Windows.Forms.Button();
            this.TimeController = new System.Windows.Forms.Timer(this.components);
            this.sensorlb = new System.Windows.Forms.Label();
            this.cameralb = new System.Windows.Forms.Label();
            this.recordingHost = new System.Windows.Forms.Integration.ElementHost();
            this.userControl11 = new WebCam1Lib.UserControl1();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.White;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.closeBtn.Location = new System.Drawing.Point(557, 378);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(98, 40);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // serialValue
            // 
            this.serialValue.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.serialValue.Location = new System.Drawing.Point(12, 43);
            this.serialValue.Multiline = true;
            this.serialValue.Name = "serialValue";
            this.serialValue.ReadOnly = true;
            this.serialValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serialValue.Size = new System.Drawing.Size(358, 305);
            this.serialValue.TabIndex = 2;
            this.serialValue.TextChanged += new System.EventHandler(this.serialValue_TextChanged);
            // 
            // showBtn
            // 
            this.showBtn.BackColor = System.Drawing.Color.White;
            this.showBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.showBtn.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showBtn.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.showBtn.Location = new System.Drawing.Point(349, 378);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(98, 40);
            this.showBtn.TabIndex = 3;
            this.showBtn.Text = "Show";
            this.showBtn.UseVisualStyleBackColor = false;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // stopBtn
            // 
            this.stopBtn.BackColor = System.Drawing.Color.White;
            this.stopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stopBtn.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopBtn.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.stopBtn.Location = new System.Drawing.Point(453, 378);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(98, 40);
            this.stopBtn.TabIndex = 4;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = false;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // TimeController
            // 
            this.TimeController.Interval = 1000;
            this.TimeController.Tick += new System.EventHandler(this.TimeController_Tick);
            // 
            // sensorlb
            // 
            this.sensorlb.AutoSize = true;
            this.sensorlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sensorlb.ForeColor = System.Drawing.SystemColors.Info;
            this.sensorlb.Location = new System.Drawing.Point(12, 15);
            this.sensorlb.Name = "sensorlb";
            this.sensorlb.Size = new System.Drawing.Size(181, 25);
            this.sensorlb.TabIndex = 6;
            this.sensorlb.Text = "Data From Sensors";
            // 
            // cameralb
            // 
            this.cameralb.AutoSize = true;
            this.cameralb.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameralb.ForeColor = System.Drawing.SystemColors.Info;
            this.cameralb.Location = new System.Drawing.Point(400, 15);
            this.cameralb.Name = "cameralb";
            this.cameralb.Size = new System.Drawing.Size(156, 25);
            this.cameralb.TabIndex = 7;
            this.cameralb.Text = "Video Recording";
            // 
            // recordingHost
            // 
            this.recordingHost.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.recordingHost.Location = new System.Drawing.Point(417, 43);
            this.recordingHost.Name = "recordingHost";
            this.recordingHost.Size = new System.Drawing.Size(474, 305);
            this.recordingHost.TabIndex = 5;
            this.recordingHost.Text = "elementHost1";
            this.recordingHost.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.elementHost1_ChildChanged);
            this.recordingHost.Child = this.userControl11;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(929, 430);
            this.Controls.Add(this.cameralb);
            this.Controls.Add(this.sensorlb);
            this.Controls.Add(this.recordingHost);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.serialValue);
            this.Controls.Add(this.closeBtn);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IPDM Control Form";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.TextBox serialValue;
        private System.Windows.Forms.Button showBtn;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Timer TimeController;
        private System.Windows.Forms.Integration.ElementHost recordingHost;
        private WebCam1Lib.UserControl1 userControl11;
        private System.Windows.Forms.Label sensorlb;
        private System.Windows.Forms.Label cameralb;
    }
}

