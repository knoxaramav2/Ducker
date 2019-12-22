using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArduinoDriver;
using ArduinoUploader.Hardware;

namespace SerialForm
{
    public partial class Form1 : Form
    {
        public delegate void AddDataDelegate(String msg);
        public AddDataDelegate dataDelegate;
        public delegate void AddDataDelegateButton(String msg);
        public AddDataDelegateButton delegateButton;
        bool status = false;

        ArduinoDriver.ArduinoDriver driver = new ArduinoDriver.ArduinoDriver(ArduinoModel.UnoR3, true);

        public Form1()
        {
            InitializeComponent();
        }

        /*

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
            dataDelegate = new AddDataDelegate(AddDataMethod);
            delegateButton = new AddDataDelegateButton(AddDataMethodButton);
            serialPort1.WriteLine("STATE");
        }

        public void AddDataMethodButton(String msg)
        {
            button1.Text = msg;
        }

        public void AddDataMethod(String msg)
        {
            richTextBox1.Text += msg + Environment.NewLine;
        }

        private void SerialPort1DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string s = serialPort1.ReadExisting();
            if (s.Contains("state="))
            {
                s = s.Trim();
                string ds = s.Replace("state=", "");
                if (ds.Contains("0"))
                {
                    status = false;
                    button1.Invoke(delegateButton, new Object[] { "ON" });
                } else
                {
                    status = true;
                    button1.Invoke(delegateButton, new Object[] { "OFF" });
                }
            } else
            {
                richTextBox1.Invoke(dataDelegate, new Object[] { s });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Contains("ON"))
            {
                serialPort1.WriteLine("OFF");
                button1.Text = "OFF";
                status = false;
            } else
            {
                serialPort1.WriteLine("ON");
                button1.Text = "ON";
                status = true;
            }
        }
        */
    }
}
