using System;
using System.Collections.Generic;
using System.Text;
using ArduinoDriver;
using ArduinoUploader.Hardware;

namespace Ducker
{
    class Transmission
    {
        public delegate void AddDataDelegate(String msg);
        public AddDataDelegate dataDelegate;
        public delegate void AddDataDelegateButton(String msg);
        public AddDataDelegateButton delegateButton;
        bool status = false;

        ArduinoDriver.ArduinoDriver driver = new ArduinoDriver.ArduinoDriver(ArduinoModel.UnoR3, true);

        private System.ComponentModel.IContainer components = null;
        private System.IO.Ports.SerialPort serialPort1;

        public void OpenPort()
        {
            
        }

        protected void Cleanup()
        {

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM3";

        }

    }
}
