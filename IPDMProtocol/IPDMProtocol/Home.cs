using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.OleDb;
using wpfUC = WebCam1Lib;

namespace IPDMProtocol
{
    public partial class Home : Form
    {
        string dataIN;
        string[] values;

        OleDbConnection con = Connection.GetConnection();

        TimeSpan time;
        int Hours;
        int Minutes;
        int Seconds;
        wpfUC.UserControl1 control;
        public Home()
        {
            InitializeComponent();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM6";
            serialPort1.BaudRate = 9600;
            Hours = Minutes = Seconds = 0;
            serialPort1.DtrEnable = false;
            serialPort1.RtsEnable = false;
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void showBtn_Click(object sender, EventArgs e)
        {
            control = recordingHost.Child as wpfUC.UserControl1;
            if (con != null)
            {
                try
                {
                    control.startRecClick();
                    serialPort1.Open();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error! " + ex);
                }
                
                TimeController.Start();
            }
            else
            {
                MessageBox.Show("Error Connecting Database!");
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Final Time
            //Time = String.Format(hr + " : " + min + " : " + sec);
            time = new TimeSpan(Hours, Minutes, Seconds);
            //SqlException Insert command
            string cmd1 = "INSERT INTO SensorData ([Time], Value1, Value2, Value3, Value4, Value5, Value6) VALUES (@tm, @val1, @val2, @val3, @val4, @val5, @val6)";
            OleDbCommand cmd = new OleDbCommand(cmd1, con);
            dataIN = serialPort1.ReadExisting();
            values = dataIN.Split(' ');
            cmd.Parameters.AddWithValue("@tm", time);
            cmd.Parameters.AddWithValue("@val1", values[0]);
            cmd.Parameters.AddWithValue("@val2", values[1]);
            cmd.Parameters.AddWithValue("@val3", values[2]);
            cmd.Parameters.AddWithValue("@val4", 0);
            cmd.Parameters.AddWithValue("@val5", 0);
            cmd.Parameters.AddWithValue("@val6", 0);
            try
            {
                if(cmd.ExecuteNonQuery() < 0)
                {
                    serialPort1.Close();
                    TimeController.Stop();
                    MessageBox.Show("Insertion Error");
                }
            }
            catch(OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Invoke(new EventHandler(showData));
        }
        private void showData(object sender, EventArgs e)
        {
            serialValue.Text += dataIN + "\n";
        }
        private void stopBtn_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            TimeController.Stop();
            control.stopRecClick();
        }
        private void serialValue_TextChanged(object sender, EventArgs e)
        {

        }
        private void TimeController_Tick(object sender, EventArgs e)
        {
            Seconds++;
            if (Seconds > 59)
            {
                Minutes++;
                Seconds = 0;
            }
            if (Minutes > 59)
            {
                Hours++;
                Minutes = 0;
            }
        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            
            //MessageBox.Show(control.start.Content.ToString());
            
            //var elementHost = this.recordingHost;
            //var wpfButton = (System.Windows.Controls.TextBox) elementHost.Child;
            //var text = wpfButton.Text;
            //MessageBox.Show(text);
        }
    }
}