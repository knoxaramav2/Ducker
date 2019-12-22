using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialTest1
{
    class SignalController
    {
        private Timer streamListener;
        private COM_STATE state;
        SerialPort serialPort;
        RichTextBox viewWindow;

        string lastResponse = "";

        private char[] signalBuffer = new char[256];
        int bufferIndex = 0;

        public SignalController()
        {
            state = COM_STATE.COM_STATE_IDLE;
            
            streamListener = new Timer
            {
                Interval = 10
            };
            streamListener.Tick += new EventHandler(ListenStream);
        }

        public bool Start()
        {
            if (serialPort == null ||
                viewWindow == null)
            {
                return false;
            }

            streamListener.Enabled = true;

            serialPort.ReadTimeout = 2000;

            return true;
        }

        public bool SetResultView(RichTextBox view)
        {
            viewWindow = view;
            return true;
        }

        public bool SetSerialPort(SerialPort port)
        {
            serialPort = port;
            return true;
        }

        private void ListenStream(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();

                    if (serialPort.BytesToRead == 0)
                    {
                        serialPort.Close();
                        return;
                    }

                    string msg = serialPort.ReadExisting();//serialPort.ReadLine();
                    msg = msg;
                    lastResponse = msg;
                    serialPort.Close();

                    viewWindow.AppendText(msg);
                    viewWindow.AppendText(Environment.NewLine);

                    foreach(char c in lastResponse)
                    {
                        Console.Write(((int)c).ToString("X") + " ");
                       
                    }

                    Console.WriteLine();
                }
                catch (TimeoutException ex)
                {
                    viewWindow.Text += ex +
                        Environment.NewLine;
                    serialPort.DiscardInBuffer();
                    serialPort.Close();
                } catch 
                {
                    viewWindow.Text += "Unable to read from Arduino" +
                        Environment.NewLine;
                    serialPort.Close();
                }
            }
        }

        private void ClearBuffer()
        {
            bufferIndex = 0;
            Array.Clear(signalBuffer, 0, 256);
        }

        public bool AppendToBuffer(String data)
        {
            foreach (char c in data)
            {
                if (bufferIndex == 255) { return false; }
                signalBuffer[bufferIndex++] = c;
            }

            return true;
        }

        public bool AppendToBuffer(char[] data)
        {
            foreach (char c in data)
            {
                if (bufferIndex == 255) { return false; }
                signalBuffer[bufferIndex++] = c;
            }

            return true;
        }

        public bool AppendToBuffer(byte[] data)
        {
            foreach (byte c in data)
            {
                if (bufferIndex == 255) { return false; }
                signalBuffer[bufferIndex++] = (char) c;
            }

            return true;
        }

        public bool SendData()
        {
            signalBuffer[bufferIndex] = '\n';

            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();
                    serialPort.Write(signalBuffer, 0, bufferIndex);
                    serialPort.Close();
                }
                catch (Exception exc)
                {
                    viewWindow.Text += ("Err: Check that serial port is open\r\n" + exc.Message) +
                        Environment.NewLine;
                    return false;
                }
            }

            ClearBuffer();

            return true;
        }
    }
}
