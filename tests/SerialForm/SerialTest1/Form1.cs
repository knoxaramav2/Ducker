using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                    serialPort1.Write("T");
                    serialPort1.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Err: Check that serial port is open\r\n"+exc.Message);
                }
            }

            System.Threading.Thread.Sleep(100);

            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                    string read = serialPort1.ReadLine();
                    MessageBox.Show("Message: " + read);
                    serialPort1.Close();
                } catch
                {
                    MessageBox.Show("Unabled to read from arduino");
                }
            }


        }
    }
}
