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

        public SignalController()
        {
            state = COM_STATE.COM_STATE_IDLE;
            
            streamListener = new Timer
            {
                Interval = 100
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

            serialPort.ReadTimeout = 1000;

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

                    string msg = serialPort.ReadLine();

                    viewWindow.Text += msg + Environment.NewLine;
                    serialPort.Close();
                } catch (TimeoutException ex)
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

        public bool SendData(String data)
        {
            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();
                    serialPort.Write(data);
                    serialPort.Close();
                    Console.WriteLine(data);
                }
                catch (Exception exc)
                {
                    viewWindow.Text += ("Err: Check that serial port is open\r\n" + exc.Message) +
                        Environment.NewLine;
                    return false;
                }
            }

            return true;
        }
    }
}
