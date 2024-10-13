using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using YF.MWS.Metadata;
using YF.Utility.Log;

namespace YF.MWS.Win.Util
{
    /// <summary>
    /// 测试仪工具类
    /// </summary>
    public class VelocimeterUtil
    {
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
        /// 仪表协议
        /// </summary>
        private DeviceProtocol deviceProtocol;

        /// <summary>
        /// 串口接收数据缓存
        /// </summary>
        private List<byte> listByte;

        /// <summary>
        /// 缓存最大长度
        /// </summary>
        private int maxLength;

        /// <summary>
        /// 线程同步锁
        /// </summary>
        private static object lockObj = new object();

        /// <summary>
        /// 显示汽车速度
        /// </summary>
        /// <param name="value">速度值</param>
        public delegate void ShowSpeed(double value);

        public ShowSpeed OnShowSpeed;

        /// <summary>
        /// 显示接收数据委托
        /// </summary>
        /// <param name="byteData">接收到的数据</param>
        public delegate void DataReceived(byte[] byteData);

        public DataReceived OnDataReceived;

        public VelocimeterUtil()
        {
            //初始化数据信息
            this.deviceProtocol = this.GetDeviceInfo();
            this.maxLength = this.deviceProtocol.FrameLength * 2;
            this.listByte = new List<byte>();
            this.InitPort();
        }

        /// <summary>
        /// 初始化串口
        /// </summary>
        private void InitPort()
        {
            string section = "Velocimeter";

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
                        //等待接收数据
                        Thread.Sleep(300);

                        //接收数据
                        int count = this.serlPort.BytesToRead;
                        byte[] byteRead = new byte[count];
                        this.serlPort.Read(byteRead, 0, count);
                        this.ReceiveData(byteRead);

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
        /// 接收串口返回的数据
        /// </summary>
        /// <param name="byteReceived"></param>
        private void ReceiveData(byte[] byteReceived)
        {
            if (byteReceived != null && byteReceived.Length > 0)
            {
                //缓存串口数据
                this.AddByte(byteReceived);
                //获取一帧数据
                byte[] byteFrame = this.GetFrameData();
                if (byteFrame != null && byteFrame.Length > 0)
                {
                    string speedData = Encoding.ASCII.GetString(byteFrame, 1, 5);
                    double speedValue = Convert.ToDouble(speedData);

                    if (this.OnShowSpeed != null)
                        this.OnShowSpeed(speedValue);
                }
            }
        }

        /// <summary>
        /// 获取仪表协议
        /// </summary>
        /// <returns></returns>
        private DeviceProtocol GetDeviceInfo()
        {
            DeviceProtocol protocol = new DeviceProtocol();

            protocol.BeginBit = 0x0a;
            protocol.EndBit = 0x0a;
            protocol.FrameLength = 8;

            return protocol;
        }

        /// <summary>
        /// 缓存接收到的串口数据
        /// </summary>
        /// <param name="bytes">串口数据</param>
        private void AddByte(byte[] bytes)
        {
            if (bytes != null && bytes.Length > 0)
            {
                this.listByte.AddRange(bytes);

                //移除缓存中多余字节，只保留maxLength字节
                if (this.listByte.Count > this.maxLength)
                {
                    this.listByte.RemoveRange(0, this.listByte.Count - this.maxLength);
                }
            }
        }

        /// <summary>
        /// 返回一帧数据
        /// </summary>
        /// <returns></returns>
        private byte[] GetFrameData()
        {
            byte[] byteFrame = null;

            if (this.listByte.Count < this.deviceProtocol.FrameLength)
                return byteFrame;

            int index = this.listByte.Count;
            while ((index = this.listByte.LastIndexOf(this.deviceProtocol.BeginBit, index - 1)) != -1)
            {
                if (this.listByte.Count >= index + this.deviceProtocol.FrameLength)
                {
                    if (this.listByte[index + this.deviceProtocol.FrameLength - 1] == this.deviceProtocol.EndBit)
                        break;
                }
            }

            if (index != -1)
            {
                byteFrame = new byte[this.deviceProtocol.FrameLength];
                this.listByte.CopyTo(index, byteFrame, 0, this.deviceProtocol.FrameLength);
            }

            return byteFrame;
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
