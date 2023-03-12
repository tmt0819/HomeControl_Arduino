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

namespace HomeControl_Arduino
{
    public partial class Form1 : Form
    {
        SerialPort mySerial = new SerialPort();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboxSelectPort.Text = "포트선택";
        }

        private void cboxSelectPort_Click(object sender, EventArgs e)
        {
            cboxSelectPort.Items.Clear();
            foreach (var item in SerialPort.GetPortNames())
            {
                cboxSelectPort.Items.Add(item);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cboxSelectPort.Text == "") return;
            try
            {
                if (mySerial.IsOpen)
                {
                    mySerial.Close();
                }
                else
                {
                    mySerial.PortName = cboxSelectPort.SelectedIndex.ToString();
                    mySerial.BaudRate = 9600;
                    mySerial.DataBits = 8;
                    mySerial.StopBits = StopBits.One;
                    mySerial.Parity = Parity.None;
                    mySerial.Open();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("연결에러", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnConnect.Text = mySerial.IsOpen ? "연결해제" : "연결하기";
            cboxSelectPort.Enabled = !mySerial.IsOpen;
        }

        private void btnON_Click(object sender, EventArgs e)
        {
            if (mySerial.IsOpen) return;
            mySerial.Write("1");
        }

        private void btnOFF_Click(object sender, EventArgs e)
        {
            if (mySerial.IsOpen) return;
            mySerial.Write("0");
        }
    }
}
