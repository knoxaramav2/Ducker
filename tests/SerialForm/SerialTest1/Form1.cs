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
        
        SignalController signalController;

        public Form1()
        {
            InitializeComponent();

            signalController = new SignalController();
            signalController.SetResultView(viewWindow);
            signalController.SetSerialPort(serialPort1);

            audio = new Audio();

            KeyPreview = true;
            KeyPress += new KeyPressEventHandler(Form1_KeyPress);

            signalController.Start();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //var stream = audio.TextToAudioStream("hello maggots");
            char[] stream = new char[4];
            stream[0] = 'T';//SignalCodes.YELL_8;
            stream[1] = 'H';
            stream[2] = 'I';
            stream[3] = '\0';

            /*byte[] tStream = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                tStream[i] = stream[i];
            }*/

            signalController.SendData(new string(stream));
            //SendMessage(tStream.ToString());
            //Console.WriteLine(tStream.ToString());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            audio.Speek("Hello world");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n' || e.KeyChar == '\r')
            {
                signalController.SendData(commandLine.Text);
                commandLine.Text = "";
            } else if (e.KeyChar == (char) Keys.Back && commandLine.Text.Length > 0)
            {
                commandLine.Text = commandLine.Text.Substring(0, commandLine.Text.Length - 1);
            }
        }

        private void viewWindow_TextChanged(object sender, EventArgs e)
        {
            viewWindow.SelectionStart = viewWindow.Text.Length;
            viewWindow.ScrollToCaret();
        }
    }
}
