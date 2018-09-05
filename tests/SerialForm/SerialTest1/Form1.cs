using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;

namespace SerialTest1
{
    public partial class Form1 : Form
    {
        private Audio audio;
        private Timer streamListener;

        public Form1()
        {
            InitializeComponent();

            audio = new Audio();
            streamListener = new Timer
            {
                Interval = 100
            };
            streamListener.Tick += new EventHandler(ListenStream);
            streamListener.Enabled = true;

            KeyPreview = true;
            KeyPress += new KeyPressEventHandler(Form1_KeyPress);
        }

        private void SendMessage(String s)
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                    serialPort1.Write(s);
                    serialPort1.Close();
                }
                catch (Exception exc)
                {
                    viewWindow.Text += ("Err: Check that serial port is open\r\n" + exc.Message) +
                        Environment.NewLine;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            audio.Speek("Hello world");
        }

        private void ListenStream(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();

                    if (serialPort1.BytesToRead == 0)
                    {
                        serialPort1.Close();
                        return;
                    }

                    string msg = serialPort1.ReadLine();

                    viewWindow.Text += msg + Environment.NewLine;
                    audio.Speek(msg);
                    serialPort1.Close();

                    //audio.Speek(read);
                }
                catch
                {
                    viewWindow.Text += "Unable to read from Arduino" + 
                        Environment.NewLine;
                }
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n' || e.KeyChar == '\r')
            {
                SendMessage(commandLine.Text);
                commandLine.Text = "";
            } else if (e.KeyChar == (char) Keys.Back && commandLine.Text.Length > 0)
            {
                commandLine.Text = commandLine.Text.Substring(0, commandLine.Text.Length - 1);
            }
        }
    }
}
