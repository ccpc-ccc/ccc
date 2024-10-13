using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using YF.MWS.Metadata;
using YF.Utility.Log;

namespace YF.MWS.Win.Util
{
    public class ScreenUtil
    {
        /// <summary>
        /// 大屏幕编号
        /// </summary>
        private int screenNo;

        /// <summary>
        /// 串口
        /// </summary>
        private SerialPort serlPort;

        public SerialPort SerlPort
        {
            get { return serlPort; }
            set { serlPort = value; }
        }

        /// <summary>
        /// 线程同步锁
        /// </summary>
        private static object lockObj = new object();

        /// <summary>
        /// 显示数据委托
        /// </summary>
        /// <param name="screenNo">大屏幕编号</param>
        /// <param name="byteData">显示的数据</param>
        public delegate void ShowData(int screenNo, byte[] byteData);

        public ShowData OnShowData;

        /// <summary>
        /// 显示接收数据委托
        /// </summary>
        /// <param name="byteData">接收到的数据</param>
        public delegate void DataReceived(byte[] byteData);

        public DataReceived OnDataReceived;

        public ScreenUtil(int screenNo)
        {
            this.screenNo = screenNo;
            this.InitPort();
        }

        /// <summary>
        /// 初始化串口
        /// </summary>
        private void InitPort()
        {
            //大屏幕小节名称
            string section = string.Format("Screen{0}", this.screenNo);

            this.serlPort = new SerialPort();
            this.serlPort.PortName = IniUtility.GetIniKeyValue(section, "Port", "COM1");
            this.serlPort.BaudRate = Convert.ToInt32(IniUtility.GetIniKeyValue(section, "BaundRate", "9600"));
            this.serlPort.DataBits = Convert.ToInt32(IniUtility.GetIniKeyValue(section, "DataBit", "8"));
            this.serlPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), IniUtility.GetIniKeyValue(section, "StopBit", "One"), true);
            this.serlPort.Parity = (Parity)Enum.Parse(typeof(Parity), IniUtility.GetIniKeyValue(section, "Parity", "None"), true);

            this.serlPort.DataReceived += new SerialDataReceivedEventHandler(this.SerlPort_DataReceived);
        }

        /// <summary>
        /// 设置串口
        /// </summary>
        /// <param name="portName">串口名称</param>
        public void SetPortName(string portName)
        {
            if (this.serlPort != null)
                this.serlPort.PortName = portName;
        }

        /// <summary>
        /// 设置波特率
        /// </summary>
        /// <param name="baudRate">波特率</param>
        public void SetBaudRate(string baudRate)
        {
            if (this.serlPort != null)
                this.serlPort.BaudRate = Convert.ToInt32(baudRate);
        }

        /// <summary>
        /// 设置数据位
        /// </summary>
        /// <param name="dataBits">数据位</param>
        public void SetDataBits(string dataBits)
        {
            if (this.serlPort != null)
                this.serlPort.DataBits = Convert.ToInt32(dataBits);
        }

        /// <summary>
        /// 设置停止位
        /// </summary>
        /// <param name="stopBits">停止位</param>
        public void SetStopBits(string stopBits)
        {
            if (this.serlPort != null)
                this.serlPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits, true);
        }

        /// <summary>
        /// 设置奇偶校验
        /// </summary>
        /// <param name="parity">奇偶校验</param>
        public void SetParity(string parity)
        {
            if (this.serlPort != null)
                this.serlPort.Parity = (Parity)Enum.Parse(typeof(Parity), parity, true);
        }

        /// <summary>
        /// 串口数据读取事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerlPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                lock (lockObj)
                {
                    if (this.serlPort != null && this.serlPort.IsOpen)
                    {
                        //接收数据
                        int count = this.serlPort.BytesToRead;
                        byte[] byteRead = new byte[count];
                        this.serlPort.Read(byteRead, 0, count);

                        //显示数据到屏幕
                        if (this.OnShowData != null)
                        {
                            this.OnShowData(this.screenNo, byteRead);
                        }
                        //显示接收到的数据
                        if (this.OnDataReceived != null)
                        {
                            this.OnDataReceived(byteRead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        public bool OpenPort()
        {
            try
            {
                if (this.serlPort != null && !this.serlPort.IsOpen)
                {
                    this.serlPort.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                return false;
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public bool ClosePort()
        {
            try
            {
                if (this.serlPort != null && this.serlPort.IsOpen)
                {
                    this.serlPort.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                return false;
            }
        }
    }
}
