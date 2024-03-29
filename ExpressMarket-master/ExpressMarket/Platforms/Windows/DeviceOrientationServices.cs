﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMarket.Services
{
    public partial class DeviceOrientationServices
    {
        SerialPort mySerialPort;
       

        public partial void ConfigureScanner()
        {
            this.mySerialPort = new SerialPort();
            this.SerialBuffer = new QueueBuffer();

            mySerialPort.PortName = "COM3";
            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.DataBits = 8;
            mySerialPort.StopBits = StopBits.One;

            mySerialPort.ReadTimeout = 1000;
            mySerialPort.WriteTimeout = 1000;

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataHandler);

            try
            {
                mySerialPort.Open();
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }

        }

        private void DataHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;

            string data = "";

            data = sp.ReadTo("\r");
            SerialBuffer.Enqueue(data);
           

           



        }


      
    }

   
}
