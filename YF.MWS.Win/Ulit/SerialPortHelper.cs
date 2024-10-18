using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using YF.MWS.Metadata;
using YF.Utility.Log;
using YF.Utility;
using System.Windows.Forms;
using YF.MWS.Metadata.Cfg;
using System.Threading.Tasks;

namespace YF.MWS.Win
{
    public class SerialPortHelper : IDisposable {
        private bool isOpen = false;
        /// <summary>
        /// 串口
        /// </summary>
        private SerialPort serlPort;

        public SerialPort SerlPort {
            get { return serlPort; }
            set { serlPort = value; }
        }
        /// <summary>
        /// 设备配置
        /// </summary>
        public DeviceCfg DeviceCfg {get;set;}
        /// <summary>
        /// 设备编号
        /// </summary>
        public int DeviceNo { get; set; }
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
        /// Ini节点
        /// </summary>
        string section;
        /// <summary>
        /// 设备版本
        /// </summary>
        string deviceVersion;
        /// <summary>
        /// 串行通讯方式
        /// </summary>
        string deviceComFun;

        /// <summary>
        /// 显示重量数据委托
        /// </summary>
        /// <param name="deviceNo">仪器编号</param>
        /// <param name="value">重量值</param>
        public delegate Task ShowWeight(int deviceNo, double value);

        public ShowWeight OnShowWeight;

        /// <summary>
        /// 指示灯状态转换委托
        /// </summary>
        /// <param name="deviceNo">仪器编号</param>
        /// <param name="stateOn">是否点亮指示灯</param>
        public delegate void StateChanged(int deviceNo, bool stateOn);

        public StateChanged OnStateChanged;

        /// <summary>
        /// 显示接收数据委托
        /// </summary>
        /// <param name="byteData">接收到的数据</param>
        public delegate void DataReceived(byte[] byteData);

        public DataReceived OnDataReceived;
        private DateTime lastReceiveTime = DateTime.Now;
        /// <summary>
        /// 仪表发送数据超时时间(秒)
        /// </summary>
        private int timeOut = 1;

        public SerialPortHelper(int deviceNo,DeviceCfg deviceCfg)
        {
            this.DeviceNo = deviceNo;
            this.section = string.Format("Device{0}", this.DeviceNo);
            this.deviceVersion = deviceCfg.Version;
            this.deviceComFun = deviceCfg.ComFun;
            this.DeviceCfg = deviceCfg;
            //初始化数据信息
            this.deviceProtocol = this.GetDeviceInfo();
            this.maxLength = this.deviceProtocol.FrameLength * 2;
            this.listByte = new List<byte>();
            this.InitPort(deviceCfg);
        }

        /// <summary>
        /// 初始化串口
        /// </summary>
        private void InitPort(DeviceCfg deviceCfg)
        {
            string section = string.Format("SerialPort{0}", this.DeviceNo);
            this.serlPort = new SerialPort();
            if(!string.IsNullOrEmpty(deviceCfg.Port)) this.serlPort.PortName = deviceCfg.Port ?? "COM1";
            if (!string.IsNullOrEmpty(deviceCfg.BaundRate)) this.serlPort.BaudRate = Convert.ToInt32(deviceCfg.BaundRate);
            if (!string.IsNullOrEmpty(deviceCfg.DataBit)) this.serlPort.DataBits = Convert.ToInt32(deviceCfg.DataBit);
            if (!string.IsNullOrEmpty(deviceCfg.StopBit)) {
                StopBits bits = StopBits.One;
                Enum.TryParse(deviceCfg.StopBit, out bits);
                if (bits == StopBits.None) bits = StopBits.One;
                this.serlPort.StopBits = bits;
            }
            if (!string.IsNullOrEmpty(deviceCfg.Parity)) {
                Parity bits = Parity.None;
                Enum.TryParse(deviceCfg.Parity, out bits);
                this.serlPort.Parity = bits;
            }
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
        public void SetParity(Parity parity)
        {
            if (this.serlPort != null)
                this.serlPort.Parity = parity;
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
                    if (this.serlPort != null && this.serlPort.IsOpen && isOpen)
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
                        if (count > 0)
                            lastReceiveTime = DateTime.Now;
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
                GetWithTP(byteReceived);
                return;
                if (deviceVersion == "XK3196B")
                {
                    GetWithXK3196B(byteReceived);
                    return;
                }
                if (deviceVersion == "XK3102DS")
                {
                    GetWithXK3102DS(byteReceived);
                    return;
                }
                if (deviceVersion == "HT2000")
                {
                    GetWithHT2000(byteReceived);
                    return;
                }
                if (deviceVersion == "JWI4E") 
                {
                    GetWithJWI4E(byteReceived);
                    return;
                }
                if (deviceVersion == "KL3101")
                {
                    //GetWithJWI4E(byteReceived);
                    this.GetWithKL3101(byteReceived);
                    return;
                }

                //缓存串口数据
                 this.AddByte(byteReceived);
                //获取一帧数据
                byte[] byteFrame = this.GetFrameData();
                int length = 0;
                if (byteFrame != null)
                    length = byteFrame.Length;
                if (byteFrame != null && byteFrame.Length > 0)
                {
                    if (this.deviceVersion != "Custom")
                    {
                        switch (this.deviceComFun)
                        {
                            case "0":
                                this.GetDataByTF0(byteFrame);
                                break;
                            case "2":
                                this.GetDataByTF2(byteFrame);
                                break;
                            case "3":
                                this.GetDataByTF3(byteFrame);
                                break;
                        }
                    }
                    else
                    {
                        this.GetDataByCustom(byteFrame);
                    }
                }
            }
        }

        /// <summary>
        /// 串行通讯方式0
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetDataByTF0(byte[] byteFrame)
        {
            switch (this.deviceVersion)
            {
                case "HBM":
                    GetWithHBM(byteFrame);
                    break;
                case "QHQDI":
                    GetWithQHQDI(byteFrame);
                    break;
                case "SDLS":
                    GetWithSDLS(byteFrame);
                    break;
                case "A27":
                    this.GetWithA27(byteFrame);
                    break;
                case "XK3102D":
                    this.GetWithXK3102D0(byteFrame);
                    break;
                case "XK3102S":
                    this.GetWithXK3102S(byteFrame);
                    break;
                case "XK319A":
                    this.GetWithXK(byteFrame);
                    break;
                case "XK3196G":
                    GetWithXK3196(byteFrame);
                    break;
                case "KY3000":
                    GetWithKY3000(byteFrame);
                    break;
                case "XK3190-A6":
                case "XK3190-A9":
                case "KLD2008":
                    this.GetWithYHTF0(byteFrame);
                    break;
                case "XK3190-CS6":
                    GetWithCS6(byteFrame);
                    break;
                case "KLD2002":
                    this.GetWithD2002(byteFrame);
                    break;
                case "HT9800":
                    this.GetWithHTTF0(byteFrame);
                    break;
                case "XMDH":
                    GetWithXMDH(byteFrame);
                    break;
                case "XK8142-07":
                    this.GetWithNFTLD(byteFrame);
                    break;
                case "DS822-D6":
                    this.GetWithDSTF0(byteFrame);
                    break;
                case "TOLEDO":
                    this.GetWithTOLEDO(byteFrame);
                    break;
                case "TOLEDO-Unchk":
                    this.GetWithTOLEDO(byteFrame);
                    break;
                case "KL3101":
                    this.GetWithKL3101(byteFrame);
                    break;
            }
        }

        /// <summary>
        /// 鸿泰HT2000-K5P仪表
        /// </summary>
        /// <param name="byteFrame"></param>
        private void GetWithHT2000(byte[] byteFrame) 
        {
            //Aa+00007530000000b
            try
            {
                if (byteFrame == null || byteFrame.Length < 9)
                    return;
                string data = System.Text.Encoding.ASCII.GetString(byteFrame);
                int startIndex = data.IndexOf('+');
                string weightData = data.Substring(startIndex + 1, 6);
                double weight = Convert.ToDouble(weightData);
                if (this.OnShowWeight != null)
                    this.OnShowWeight(DeviceNo, weight);
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }

        public void GetWithXK3102DS(byte[] byteFrame) 
        {
            //ST,GS,+ 000080kg
             //ST,GS,+ 000080kg
            try
            {
                if (byteFrame == null || byteFrame.Length < 9)
                    return;
                string data = System.Text.Encoding.ASCII.GetString(byteFrame).ToLower();
                //Logger.Write("GetWithJWI4E:" + data);
                int startIndex = data.IndexOf("+");
                int endIndex = data.IndexOf('k', startIndex);
                int length = endIndex - startIndex;
                if (length < 0)
                    return;
                string weightData = data.Substring(startIndex + 2, length - 2);
                weightData = weightData.Replace(" ", "").Replace("kg", "").Replace("+", "").Replace("\r\n", "");
                //Logger.Write("GetWithXK3102DS:" + weightData);
                double weight = Convert.ToDouble(weightData);
                if (this.OnShowWeight != null)
                    this.OnShowWeight(DeviceNo, weight);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }
        public void GetWithTP(byte[] byteFrame) 
        {
            try
            {
                if (byteFrame == null || byteFrame.Length < 9)
                    return;
                string data = System.Text.Encoding.ASCII.GetString(byteFrame).ToLower().Replace(" ","");
                string weightData = "";
                string[] ds= data.Split('\r');
                foreach (string s in ds) {
                    if (s.Length > 2) {
                        weightData = s;
                        break;
                    }
                }
                if (string.IsNullOrEmpty(weightData)) return;
                weightData=weightData.Replace("k", "").Replace("g", "");
                double weight = (double)(weightData.ToDecimal());
                if (this.OnShowWeight != null)
                    this.OnShowWeight(DeviceNo, weight);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 钰恒电子JWI-4ECSB仪表
        /// </summary>
        /// <param name="byteFrame"></param>
        private void GetWithJWI4E(byte[] byteFrame)
        {
            //Aa+00007530000000b
            try
            {
                if (byteFrame == null || byteFrame.Length < 9)
                    return;
                string data = System.Text.Encoding.ASCII.GetString(byteFrame).ToLower();
                //Logger.Write("GetWithJWI4E:" + data);
                int startIndex = data.IndexOf("g.w.:");
                int endIndex = data.IndexOf('k', startIndex);
                int length = endIndex - startIndex;
                if (length < 0)
                    return;
                string weightData = data.Substring(startIndex + 5, length - 1);
                weightData = weightData.Replace(" ", "").Replace("kg", "").Replace("+", "").Replace("\r\n", "");
                
                double weight = Convert.ToDouble(weightData);
                if (this.OnShowWeight != null)
                    this.OnShowWeight(DeviceNo, weight);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 杭州四方电子XK3196B仪表
        /// </summary>
        /// <param name="byteFrame"></param>
        private void GetWithXK3196B(byte[] byteFrame)
        {
            if (byteFrame == null || byteFrame.Length < 5)
                return;
            List<byte> datas = byteFrame.ToList().Take(5).ToList();
            byte h1 = 0x00, h2 = 0x00, h3 = 0x00;
            if (datas[0] < 128)
            {
                h1 = datas[0];
                h2 = datas[1];
                h3 = datas[2];
            }
            if (datas[1] < 128)
            {
                h1 = datas[1];
                h2 = datas[2];
                h3 = datas[3];
            }
            if (datas[2] < 128)
            {
                h1 = datas[2];
                h2 = datas[3];
                h3 = datas[4];
            }
            if (datas[3] < 128)
            {
                h1 = datas[3];
                h2 = datas[4];
                h3 = datas[0];
            }
            if (datas[0] < 128)
            {
                h1 = datas[0];
                h2 = datas[1];
                h3 = datas[2];
            }
            if (datas[4] < 128)
            {
                h1 = datas[4];
                h2 = datas[0];
                h3 = datas[1];
            }
            double weight = Convert.ToInt32(h1) + (Convert.ToInt32(h2) & 127) * 128 + (Convert.ToInt32(h3) & 63) * 128;
            if (weight > 524287)  //处理负数的情况
                weight = weight - 1048576;
            if (this.OnShowWeight != null)
                this.OnShowWeight(DeviceNo, weight);
        }

        /// <summary>
        /// 四方D3
        /// </summary>
        /// <param name="byteFrame"></param>
        private void GetWithKY3000(byte[] byteFrame)
        {
            try
            {
                decimal weight = 0;
                if (byteFrame != null && byteFrame.Length >= 8)
                {
                    StringBuilder sb = new StringBuilder();
                    int startIndex = 2;
                    for (int i = startIndex; i < 7; i++)
                    {
                        if (byteFrame[i] >= 0x00 && byteFrame[i] <= 0x09)
                        {
                            sb.Append(((int)byteFrame[i]).ToString());
                        }
                        if (byteFrame[i] == 0x0B)
                        {
                            sb.Append("-");
                        }
                        if (byteFrame[i] >= 0x80 && byteFrame[i] <= 0x89)
                        {
                            sb.Append((byteFrame[i] - 0x80).ToString());
                            sb.Append(".");
                        }
                    }
                    if (sb.Length > 0)
                    {
                        //Logger.Info("KY3000-Weight-Data:" + sb.ToString());
                        weight = sb.ToString().ToDecimal();
                    }
                    if (this.OnShowWeight != null)
                        this.OnShowWeight(this.DeviceNo, (double)weight);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }
        /// <summary>
        /// 杭州四方电子G仪表
        /// </summary>
        /// <param name="byteFrame"></param>
        private void GetWithXK3196(byte[] byteFrame)
        {
            try
            {
                List<byte> lstDigit = new List<byte>() { (byte)0x00, (byte)0x01, (byte)0x02, (byte)0x03, (byte)0x04, (byte)0x05, (byte)0x06, (byte)0x07, (byte)0x08, (byte)0x09 };
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i < 7; i++)
                {
                    if (byteFrame[i] == 0x0B && sb.Length == 0)
                    {
                        sb.Append("-");
                    }
                    if (lstDigit.Contains(byteFrame[i]))
                    {
                        sb.Append(byteFrame[i] - 0x00);
                    }
                }
                double weightValue = Convert.ToInt32(sb.ToString());
                if (this.OnShowWeight != null)
                    this.OnShowWeight(this.DeviceNo, weightValue);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 串行通讯方式2
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetDataByTF2(byte[] byteFrame)
        {
            switch (this.deviceVersion)
            {
                case "XK3190-A6":
                case "XK3190-A9":
                case "KLD2008":
                    this.GetWithOldD2(byteFrame);
                    break;
                case "HT9800":
                    this.GetWithHTTLD(byteFrame);
                    break;
                case "XK8142-07":
                    this.GetWithNFTLD(byteFrame);
                    break;
                case "DS822-D6":
                    this.GetWithDSTF2(byteFrame);
                    break;
                case "TOLEDO":
                    this.GetWithTOLEDO(byteFrame);
                    break;
                case "TOLEDO-Unchk":
                    this.GetWithTOLEDO(byteFrame);
                    break;
            }
        }

        /// <summary>
        /// 串行通讯方式3
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetDataByTF3(byte[] byteFrame)
        {
            switch (this.deviceVersion)
            {
                case "XK3190-A6":
                case "XK3190-A9":
                case "KLD2008":
                    this.GetWithNewD2(byteFrame);
                    break;
                case "HT9800":
                    this.GetWithYHTF0(byteFrame);
                    break;
                case "XK8142-07":
                    this.GetWithNFTLD(byteFrame);
                    break;
                case "DS822-D6":
                    this.GetWithDSTF3(byteFrame);
                    break;
                case "TOLEDO":
                    this.GetWithTOLEDO(byteFrame);
                    break;
                case "TOLEDO-Unchk":
                    this.GetWithTOLEDO(byteFrame);
                    break;
            }
        }

        /// <summary>
        /// 处理耀华XK3190-CS6仪表数据
        /// </summary>
        /// <param name="byteFrame"></param>
        private void GetWithCS6(byte[] byteFrame) 
        {
            try
            {
                if (byteFrame == null || byteFrame.Length < 10)
                {
                    return;
                }
                List<byte> listDigit = new List<byte>() { (byte)0x30, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x39 };

                StringBuilder sbDigit = new StringBuilder();
                //获取称重数据
                for (int i = 1; i < 7; i++)
                {
                    if (listDigit.Contains(byteFrame[i]))
                    {
                        sbDigit.Append(byteFrame[i] - 0x30);
                    }
                }
                double weightValue = Convert.ToDouble(sbDigit.ToString())*0.01;
                if (this.OnShowWeight != null)
                    this.OnShowWeight(this.DeviceNo, weightValue);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 处理KLD2008称重数据
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetWithYHTF0(byte[] byteFrame)
        {
            if (byteFrame == null || byteFrame.Length==0) 
            {
                return;
            }
            //对接收到的数据进行校验
            byte byteVerif = (byte)(byteFrame[1] ^ byteFrame[2] ^ byteFrame[3] ^ byteFrame[4] ^ byteFrame[5] ^ byteFrame[6] ^ byteFrame[7] ^ byteFrame[8]);
            //校验高位
            byte verifHigh = (byte)((byteVerif & 0xf0) >> 4);
            //校验低位
            byte verifLow = (byte)(byteVerif & 0x0f);
            if (verifHigh > 9)
                verifHigh = (byte)(verifHigh + 0x37);
            else
                verifHigh = (byte)(verifHigh + 0x30);
            if (verifLow > 9)
                verifLow = (byte)(verifLow + 0x37);
            else
                verifLow = (byte)(verifLow + 0x30);
            if (byteFrame[9] == verifHigh && byteFrame[10] == verifLow)
            {
                List<byte> listDigit = new List<byte>() { (byte)0x30, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x39 };

                StringBuilder sbDigit = new StringBuilder();
                //获取称重数据
                for (int i = 2; i < 8; i++)
                {
                    if (!listDigit.Contains(byteFrame[i]))
                        byteFrame[i] = (byte)0x30;
                    sbDigit.Append(byteFrame[i] - 0x30);
                }
                //小数点位置
                int dotPos = byteFrame[8] - 0x30;
                int exponent = -dotPos;
                double weightValue = Convert.ToInt32(sbDigit.ToString()) * Math.Pow(10, exponent);
                //负数处理
                if (byteFrame[1] == 0x2D)
                    weightValue = -weightValue;
                //注册外部事件
                if (this.OnShowWeight != null)
                    this.OnShowWeight(this.DeviceNo, weightValue);
            }
        }

        /// <summary>
        /// 处理GetWithKL3101称重数据
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetWithKL3101(byte[] byteFrame)
        {
            try
            {
                if (byteFrame == null || byteFrame.Length == 0)
                {
                    return;
                }

                if (byteFrame[0] != '=')
                {
                    return;
                }

                byte[] bytesData = new byte[6];
                bytesData[0] = byteFrame[2];
                bytesData[1] = byteFrame[3];
                bytesData[2] = byteFrame[4];
                bytesData[3] = byteFrame[5];
                bytesData[4] = byteFrame[6];
                bytesData[5] = byteFrame[7];
                String sWeight = System.Text.Encoding.ASCII.GetString(bytesData);
                byte byteSymbal = byteFrame[1];
                double weightValue = 0;
                Double.TryParse(sWeight, out weightValue);
                if (byteSymbal == '-')
                {
                    weightValue = -1 * weightValue;
                }

                if (this.OnShowWeight != null)
                    this.OnShowWeight(this.DeviceNo, weightValue);
            }
            catch (Exception EX) {
                Logger.Write(EX.Message);
                Logger.Write(EX.StackTrace);
            }
        }
            /// <summary>
            /// 金钟XK3102D称重数据
            /// </summary>
            /// <param name="byteFrame">帧数据</param>
            private void GetWithXK3102D0(byte[] byteFrame)
        {
            try
            {
                List<byte> listDigit = new List<byte>() { (byte)0x30, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x39 };

                StringBuilder sbDigit = new StringBuilder();
                //获取称重数据
                for (int i = 7; i < 13; i++)
                {
                    if (listDigit.Contains(byteFrame[i]))
                    {
                        sbDigit.Append(byteFrame[i] - 0x30);
                    }
                    if (byteFrame[i] == 0x2E)
                    {
                        sbDigit.Append(".");
                    }
                }
                double weightValue = Convert.ToDouble(sbDigit.ToString());
                if (this.OnShowWeight != null)
                    this.OnShowWeight(this.DeviceNo, weightValue);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 金钟XK3102S称重数据
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetWithXK3102S(byte[] byteFrame)
        {
            try
            {
                List<byte> listDigit = new List<byte>() { (byte)0x30, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x39 };
                StringBuilder sbDigit = new StringBuilder();
                //获取称重数据
                for (int i = 8; i <= 14; i++)
                {
                    if (listDigit.Contains(byteFrame[i]))
                    {
                        sbDigit.Append(byteFrame[i] - 0x30);
                    }
                    if (byteFrame[i] == 0x2E)
                    {
                        sbDigit.Append(".");
                    }
                }
                //Logger.Info("GetWithXK3102S-Data:" + sbDigit.ToString());
                double weightValue = Convert.ToDouble(sbDigit.ToString());
                if (this.OnShowWeight != null)
                    this.OnShowWeight(this.DeviceNo, weightValue);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 科力D2002称重数据
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetWithD2002(byte[] byteFrame)
        {
            string weightData = Encoding.ASCII.GetString(byteFrame, 1, 7);
            //Logger.Write("KLD2002 data:" + weightData);
            char[] dataArr = weightData.ToCharArray();
            Array.Reverse(dataArr);
            weightData = string.Concat(dataArr);

            double weightValue = Convert.ToDouble(weightData);
            if (this.OnShowWeight != null)
                this.OnShowWeight(this.DeviceNo, weightValue);
        }

        /// <summary>
        /// 旧D2称重数据
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetWithOldD2(byte[] byteFrame)
        {
            string weightData = Encoding.ASCII.GetString(byteFrame, 1, 7);

            char[] dataArr = weightData.ToCharArray();
            Array.Reverse(dataArr);
            weightData = string.Concat(dataArr);

            double weightValue = Convert.ToDouble(weightData);

            if (this.OnShowWeight != null)
                this.OnShowWeight(this.DeviceNo, weightValue);
        }

        /// <summary>
        /// 新D2称重数据
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetWithNewD2(byte[] byteFrame)
        {
            string weightData = Encoding.ASCII.GetString(byteFrame, 1, 8);

            char[] dataArr = weightData.ToCharArray();
            Array.Reverse(dataArr);
            weightData = string.Concat(dataArr);

            double weightValue = Convert.ToDouble(weightData);

            if (this.OnShowWeight != null)
                this.OnShowWeight(this.DeviceNo, weightValue);
        }

        /// <summary>
        /// 获取厦门大华称重仪表数据
        /// </summary>
        /// <param name="byteFrame"></param>
        private void GetWithXMDH(byte[] byteFrame)
        {
            try
            {
                if (byteFrame == null || byteFrame.Length < 14)
                    return;
                List<byte> listDigit = new List<byte>() { (byte)0x30, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x39 };
                StringBuilder sbDigit = new StringBuilder();
                //获取称重数据
                for (int i = 3; i < 10; i++)
                {
                    if (listDigit.Contains(byteFrame[i]))
                    {
                        sbDigit.Append(byteFrame[i] - 0x30);
                    }
                    if (byteFrame[i] == 0x2E)
                    {
                        sbDigit.Append(".");
                    }
                }
                Logger.Info("GetWithXMDH-Data:" + sbDigit.ToString());
                double weightValue = Convert.ToDouble(sbDigit.ToString());
                if (this.OnShowWeight != null)
                    this.OnShowWeight(this.DeviceNo, weightValue);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 衡天TF0称重数据
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetWithHTTF0(byte[] byteFrame)
        {
            //获取称重数据
            int num0 = this.BCDToInt(byteFrame[2]);
            int num1 = this.BCDToInt(byteFrame[3]);
            int num2 = this.BCDToInt(byteFrame[4]);

            double weightValue = num2 * 10000 + num1 * 100 + num0;

            byte byteState = (byte)(byteFrame[1] & 0x07);
            switch (byteState)
            {
                case 2:
                    weightValue /= 10;
                    break;
                case 3:
                    weightValue /= 100;
                    break;
                case 4:
                    weightValue /= 1000;
                    break;
                case 5:
                    weightValue /= 10000;
                    break;
            }

            byte byteValue = (byte)(byteFrame[1] & 0x20);
            if (byteValue == 0x20)
                weightValue = -weightValue;

            if (this.OnShowWeight != null)
                this.OnShowWeight(this.DeviceNo, weightValue);
        }

        /// <summary>
        /// 衡天TLD称重数据
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetWithHTTLD(byte[] byteFrame)
        {
            List<byte> listDigit = new List<byte>() { (byte)0x30, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x39 };

            StringBuilder sbDigit = new StringBuilder();
            //获取称重数据
            for (int i = 4; i < 10; i++)
            {
                if (!listDigit.Contains(byteFrame[i]))
                    byteFrame[i] = (byte)0x30;

                sbDigit.Append(byteFrame[i] - 0x30);
            }

            double weightValue = Convert.ToDouble(sbDigit.ToString());
            byte byteState = (byte)(byteFrame[1] & 0x07);
            switch (byteState)
            {
                case 3:
                    weightValue /= 10;
                    break;
                case 4:
                    weightValue /= 100;
                    break;
                case 5:
                    weightValue /= 1000;
                    break;
                case 6:
                    weightValue /= 10000;
                    break;
                case 7:
                    weightValue /= 100000;
                    break;
            }

            byte byteValue = (byte)(byteFrame[2] & 0x02);
            if (byteValue == 0x02)
                weightValue = -weightValue;

            if (this.OnShowWeight != null)
                this.OnShowWeight(this.DeviceNo, weightValue);
        }

        /// <summary>
        /// 南方衡器TLD称重数据
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetWithNFTLD(byte[] byteFrame)
        {
            List<byte> listDigit = new List<byte>() { (byte)0x30, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x39 };

            StringBuilder sbDigit = new StringBuilder();
            //获取称重数据
            for (int i = 4; i < 10; i++)
            {
                switch (byteFrame[i])
                {
                    case 0xB0:
                        byteFrame[i] = 0x30;
                        break;
                    case 0xB1:
                        byteFrame[i] = 0x31;
                        break;
                    case 0xB2:
                        byteFrame[i] = 0x32;
                        break;
                    case 0xB3:
                        byteFrame[i] = 0x33;
                        break;
                    case 0xB4:
                        byteFrame[i] = 0x34;
                        break;
                    case 0xB5:
                        byteFrame[i] = 0x35;
                        break;
                    case 0xB6:
                        byteFrame[i] = 0x36;
                        break;
                    case 0xB7:
                        byteFrame[i] = 0x37;
                        break;
                    case 0xB8:
                        byteFrame[i] = 0x38;
                        break;
                    case 0xB9:
                        byteFrame[i] = 0x39;
                        break;
                }

                if (!listDigit.Contains(byteFrame[i]))
                    byteFrame[i] = (byte)0x30;

                sbDigit.Append(byteFrame[i] - 0x30);
            }

            double weightValue = Convert.ToDouble(sbDigit.ToString());
            byte byteState = (byte)(byteFrame[1] & 0x07);
            switch (byteState)
            {
                //case 0:
                //    weightValue *= 100;
                //    break;
                //case 1:
                //    weightValue *= 10;
                //    break;
                case 3:
                    weightValue /= 10;
                    break;
                case 4:
                    weightValue /= 100;
                    break;
                case 5:
                    weightValue /= 1000;
                    break;
                case 6:
                    weightValue /= 10000;
                    break;
                case 7:
                    weightValue /= 100000;
                    break;
            }

            byte byteValue = (byte)(byteFrame[2] & 0x02);
            if (byteValue == 0x02)
                weightValue = -weightValue;

            if (this.OnShowWeight != null)
                this.OnShowWeight(this.DeviceNo, weightValue);
        }

        /// <summary>
        /// 顶松TF0称重数据
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetWithDSTF0(byte[] byteFrame)
        {
            List<byte> listDigit = new List<byte>() { (byte)0x30, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x39 };

            StringBuilder sbDigit = new StringBuilder();
            //获取称重数据
            for (int i = 4; i < 10; i++)
            {
                if (!listDigit.Contains(byteFrame[i]))
                    byteFrame[i] = (byte)0x30;

                sbDigit.Append(byteFrame[i] - 0x30);
            }

            //小数点位置
            int dotPos = byteFrame[10] - 0x30;
            int exponent = -dotPos;
            double weightValue = Convert.ToInt32(sbDigit.ToString()) * Math.Pow(10, exponent);

            if (byteFrame[2] == 0x2D)
                weightValue = -weightValue;

            if (this.OnShowWeight != null)
                this.OnShowWeight(this.DeviceNo, weightValue);
        }

        /// <summary>
        /// 德国赛多利斯仪表
        /// </summary>
        /// <param name="byteFrame"></param>
        private void GetWithSDLS(byte[] byteFrame)
        {
            try
            {
                string weightData = Encoding.ASCII.GetString(byteFrame);
                //Logger.Info("SDLS-Data1:" + weightData);
                if (byteFrame.Length < 13)
                    return;
                weightData = Encoding.ASCII.GetString(byteFrame,3, 9);
                if (!string.IsNullOrEmpty(weightData))
                {
                    weightData = weightData.Trim();
                }
                //Logger.Info("SDLS-Data2:"+weightData);
                double weightValue = Convert.ToDouble(weightData);
                if (this.OnShowWeight != null)
                    this.OnShowWeight(this.DeviceNo, weightValue);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 处理秋毫QDI-11称重数据
        /// </summary>
        /// <param name="byteFrame"></param>
        private void GetWithQHQDI(byte[] byteFrame)
        {

        }

        private void GetWithHBM(byte[] byteFrame) 
        {
            try
            {
                if (byteFrame.Length < 11)
                    return;
                string weightData = Encoding.ASCII.GetString(byteFrame,11, this.deviceProtocol.FrameLength-11);
                if (!string.IsNullOrEmpty(weightData))
                {
                    weightData = weightData.Trim();
                    weightData = weightData.Replace(" ", "");
                    weightData = weightData.ToLower().Replace("kgnet", "");
                }
                double weightValue = Convert.ToDouble(weightData);
                if (this.OnShowWeight != null)
                    this.OnShowWeight(this.DeviceNo, weightValue);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }
        /// <summary>
        /// A27称重数据
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetWithA27(byte[] byteFrame)
        {
            StringBuilder sbWeight = new StringBuilder();
            StringBuilder sbWeightTest = new StringBuilder();
            string weightDataSource = Encoding.ASCII.GetString(byteFrame);
            string weightData=Encoding.ASCII.GetString(byteFrame, 2, 8);
            //Logger.Write("GetWithA27-Data:" + weightData);
            int length = byteFrame.Length;
            for (int i = 2; i <= length - 2; i++) 
            {
                //sbWeight.Append(byteFrame[i]);
                //sbWeightTest.Append(byteFrame[i]+";");
            }
            try
            {
                double weightValue = double.Parse(weightData);
                if (this.OnShowWeight != null)
                    this.OnShowWeight(this.DeviceNo, weightValue);
            }
            catch (Exception e) 
            {
                Logger.WriteException(e);
            }
        }

        /// <summary>
        /// XK319A称重数据
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetWithXK(byte[] byteFrame)
        {
            List<byte> listDigit = new List<byte>() { (byte)0x30, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x39 };

            StringBuilder sbDigit = new StringBuilder();
            StringBuilder sbTest=new StringBuilder();
            //获取称重数据
            for (int i = 4; i < 10; i++)
            {
                sbTest.Append(byteFrame[i]+"|");
                sbDigit.Append(byteFrame[i] - 0x30);
            }
            //小数点位置
            int dotPos = byteFrame[1] - 0x22;
            int exponent = -dotPos;
           
            double weightValue = Convert.ToInt32(sbDigit.ToString()) * Math.Pow(10, exponent);
           // if (byteFrame[2] == 0x2D)
          //      weightValue = -weightValue;

            if (this.OnShowWeight != null)
                this.OnShowWeight(this.DeviceNo, weightValue);
        }

        /// <summary>
        /// 顶松TF2称重数据
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetWithDSTF2(byte[] byteFrame)
        {
            string weightData = Encoding.ASCII.GetString(byteFrame, 1, 8);

            char[] dataArr = weightData.ToCharArray();
            Array.Reverse(dataArr);
            weightData = string.Concat(dataArr);

            double weightValue = Convert.ToDouble(weightData);

            if (this.OnShowWeight != null)
                this.OnShowWeight(this.DeviceNo, weightValue);
        }

        /// <summary>
        /// 顶松TF3称重数据
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetWithDSTF3(byte[] byteFrame)
        {
            List<byte> listDigit = new List<byte>() { (byte)0x30, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x39 };

            //数据部分
            byte[] byteData = new byte[6];
            //小数点
            byte[] bytePoint = new byte[6];
            //索引
            int index = 0;

            for (int i = 3; i < 15; i += 2)
            {
                bytePoint[index] = byteFrame[i];
                byteData[index] = byteFrame[i + 1];
                index++;
            }

            StringBuilder sbDigit = new StringBuilder();
            //获取称重数据
            for (int i = 0; i < 6; i++)
            {
                if (!listDigit.Contains(bytePoint[i]))
                    bytePoint[i] = (byte)0x30;

                if (!listDigit.Contains(byteData[i]))
                    byteData[i] = (byte)0x30;

                sbDigit.Append(byteData[i] - 0x30);
            }

            double weightValue = Convert.ToDouble(sbDigit.ToString());

            Array.Reverse(bytePoint);
            if (bytePoint[1] == 0x31 || bytePoint[1] == 0x33)
            {
                weightValue /= 10;
            }
            else if (bytePoint[2] == 0x31 || bytePoint[2] == 0x33)
            {
                weightValue /= 100;
            }
            else if (bytePoint[3] == 0x31 || bytePoint[3] == 0x33)
            {
                weightValue /= 1000;
            }
            else if (bytePoint[4] == 0x31 || bytePoint[4] == 0x33)
            {
                weightValue /= 10000;
            }
            else if (bytePoint[5] == 0x31 || bytePoint[5] == 0x33)
            {
                weightValue /= 100000;
            }

            if (this.OnShowWeight != null)
                this.OnShowWeight(this.DeviceNo, weightValue);
        }

        /// <summary>
        /// 梅特勒托利多称重数据
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetWithTOLEDO(byte[] byteFrame)
        {
            List<byte> listDigit = new List<byte>() { (byte)0x30, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x39 };

            StringBuilder sbDigit = new StringBuilder();
            //获取称重数据
            for (int i = 4; i < 10; i++)
            {
                if (!listDigit.Contains(byteFrame[i]))
                    byteFrame[i] = (byte)0x30;

                sbDigit.Append(byteFrame[i] - 0x30);
            }

            double weightValue = Convert.ToDouble(sbDigit.ToString());
            byte byteState = (byte)(byteFrame[1] & 0x07);
            switch (byteState)
            {
                case 3:
                    weightValue /= 10;
                    break;
                case 4:
                    weightValue /= 100;
                    break;
                case 5:
                    weightValue /= 1000;
                    break;
                case 6:
                    weightValue /= 10000;
                    break;
                case 7:
                    weightValue /= 100000;
                    break;
            }

            byte byteValue = (byte)(byteFrame[2] & 0x02);
            if (byteValue == 0x02)
                weightValue = -weightValue;

            if (this.OnShowWeight != null)
                this.OnShowWeight(this.DeviceNo, weightValue);
        }

        /// <summary>
        /// 自定义串行通讯方式
        /// </summary>
        /// <param name="byteFrame">帧数据</param>
        private void GetDataByCustom(byte[] byteFrame)
        {
            try
            {
                string weightData = Encoding.ASCII.GetString(byteFrame, this.deviceProtocol.InterceptBit, this.deviceProtocol.FrameLength - this.deviceProtocol.InterceptBit - 1);
                if (!string.IsNullOrEmpty(weightData))
                {
                    weightData = weightData.Trim();
                    weightData = weightData.Replace(" ", "");
                    weightData = weightData.ToLower().Replace("w", "");
                    weightData = weightData.ToLower().Replace("kg", "");
                    weightData = weightData.ToLower().Replace("kgnet", "");
                    Logger.Info("GetDataByCustom-WeightData:" + weightData);
                }
                if (this.deviceProtocol.Sequence == "DX")
                {
                    char[] dataArr = weightData.ToCharArray();
                    Array.Reverse(dataArr);
                    weightData = string.Concat(dataArr);
                }

                double weightValue = Convert.ToDouble(weightData);

                if (this.OnShowWeight != null)
                    this.OnShowWeight(this.DeviceNo, weightValue);
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 获取仪表协议
        /// </summary>
        /// <returns></returns>
        private DeviceProtocol GetDeviceInfo()
        {
            DeviceProtocol protocol = new DeviceProtocol();

            switch (this.deviceVersion)
            {
                case "A27":
                case "HBM":
                case "QHQDI":
                case "XK3196G":
                case "SDLS":
                case "XK3102D":
                case "XK3102S":
                case "XK319A":
                case "KY3000":
                case "XK3190-A6":
                case "XK3190-A9":
                case "XK3190-CS6":
                case "HT9800":
                case "XMDH":
                case "XK8142-07":
                case "DS822-D6":
                case "KLD2008":
                case "TOLEDO":
                case "TOLEDO-Unchk":
                    protocol = this.GetDeviceProtocol(this.deviceComFun);
                    break;
                case "JM-Format1":
                    break;
                case "JM-Format2":
                    break;
                case "JM-Format3":
                    break;
                case "Custom":
                    protocol = this.GetCustomProtocol();
                    break;
            }

            return protocol;
        }

        /// <summary>
        /// 获取设备串行通讯方式
        /// </summary>
        /// <param name="comFun">串行通讯方式</param>
        /// <returns></returns>
        private DeviceProtocol GetDeviceProtocol(string comFun)
        {
            DeviceProtocol protocol = new DeviceProtocol();
            switch (comFun)
            {
                case "0":
                    protocol = this.GetProtocolByTF0();
                    break;
                case "2":
                    protocol = this.GetProtocolByTF2();
                    break;
                case "3":
                    protocol = this.GetProtocolByTF3();
                    break;
                default:
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x03;
                    protocol.FrameLength = 12;
                    break;
            }

            return protocol;
        }

        /// <summary>
        /// 获取连续发送数据方式TF=0的协议
        /// </summary>
        /// <returns></returns>
        private DeviceProtocol GetProtocolByTF0()
        {
            DeviceProtocol protocol = new DeviceProtocol();
            switch (this.deviceVersion)
            {
                case "A27":
                    protocol.BeginBit = Convert.ToByte("w".ToCharArray()[0]);
                    protocol.EndBit = Convert.ToByte("g".ToCharArray()[0]);
                    protocol.FrameLength = 12;
                    break;
                case "KY3000":
                    protocol.BeginBit = 0xCD;
                    protocol.EndBit = 0xCD;
                    protocol.FrameLength = 9;
                    break;
                case "HBM":
                    protocol.BeginBit = 0x6B;
                    protocol.EndBit = 0x20;
                    protocol.FrameLength = 21;
                    break;
                case "QHQDI":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x02;
                    protocol.FrameLength = 19;
                    break;
                case "XK3102D":
                    protocol.BeginBit = 0x4F;
                    protocol.EndBit = 0x0A;
                    protocol.FrameLength = 18;
                    break;
                case "XMDH":
                    protocol.BeginBit = 0x0A;
                    protocol.EndBit = 0x0D;
                    protocol.FrameLength = 14;
                    break;
                case "XK3102S":
                    protocol.BeginBit = 0x0A;
                    protocol.EndBit = 0x0A;
                    protocol.FrameLength = 19;
                    break;
                case "XK319A":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x0A;
                    protocol.FrameLength = 12;
                    break;
                case "XK3196G":
                    protocol.BeginBit = 0xCD;
                    protocol.EndBit = 0xCD;
                    protocol.FrameLength = 12;
                    break;
                case "KLD2002":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x03;
                    protocol.FrameLength = 10;
                    break;
                case "XK3190-A6":
                case "XK3190-A9":
                case "KLD2008":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x03;
                    protocol.FrameLength = 12;
                    break;
                case "XK3190-CS6":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x03;
                    protocol.FrameLength = 10;
                    break;
                case "HT9800":
                    protocol.BeginBit = 0xFF;
                    protocol.EndBit = 0xFF;
                    protocol.FrameLength = 6;
                    break;
                case "XK8142-07":
                    protocol.BeginBit = 0x82;
                    protocol.EndBit = 0x8D;
                    protocol.FrameLength = 17;
                    break;
                case "DS822-D6":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x03;
                    protocol.FrameLength = 22;
                    break;
                case "TOLEDO":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x02;
                    protocol.FrameLength = 19;
                    break;
                case "TOLEDO-Unchk":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x0D;
                    protocol.FrameLength = 17;
                    break;
                case "SDLS":
                    protocol.BeginBit = 0x0A;
                    protocol.EndBit = 0x0A;
                    protocol.FrameLength = 17;
                    break;
            }

            return protocol;
        }

        /// <summary>
        /// 获取连续发送数据方式TF=2的协议
        /// </summary>
        /// <returns></returns>
        private DeviceProtocol GetProtocolByTF2()
        {
            DeviceProtocol protocol = new DeviceProtocol();

            switch (this.deviceVersion)
            {
                case "XK3190-A6":
                case "XK3190-A9":
                case "KLD2008":
                    protocol.BeginBit = 0x3D;
                    protocol.EndBit = 0x3D;
                    protocol.FrameLength = 9;
                    break;
                case "HT9800":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x0A;
                    protocol.FrameLength = 12;
                    break;
                case "XK8142-07":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x02;
                    protocol.FrameLength = 19;
                    break;
                case "DS822-D6":
                    protocol.BeginBit = 0x3D;
                    protocol.EndBit = 0x3D;
                    protocol.FrameLength = 10;
                    break;
                case "TOLEDO":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x02;
                    protocol.FrameLength = 19;
                    break;
                case "TOLEDO-Unchk":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x0D;
                    protocol.FrameLength = 17;
                    break;
            }

            return protocol;
        }

        /// <summary>
        /// 获取连续发送数据方式TF=3的协议
        /// </summary>
        /// <returns></returns>
        private DeviceProtocol GetProtocolByTF3()
        {
            DeviceProtocol protocol = new DeviceProtocol();

            switch (this.deviceVersion)
            {
                case "XK3190-A6":
                case "XK3190-A9":
                case "KLD2008":
                    protocol.BeginBit = 0x3D;
                    protocol.EndBit = 0x3D;
                    protocol.FrameLength = 10;
                    break;
                case "HT9800":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x03;
                    protocol.FrameLength = 12;
                    break;
                case "XK8142-07":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x02;
                    protocol.FrameLength = 19;
                    break;
                case "DS822-D6":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x03;
                    protocol.FrameLength = 17;
                    break;
                case "TOLEDO":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x02;
                    protocol.FrameLength = 19;
                    break;
                case "TOLEDO-Unchk":
                    protocol.BeginBit = 0x02;
                    protocol.EndBit = 0x0D;
                    protocol.FrameLength = 17;
                    break;
            }

            return protocol;
        }

        /// <summary>
        /// 获取设备自定义串行通讯方式
        /// </summary>
        /// <returns></returns>
        private DeviceProtocol GetCustomProtocol()
        {
            DeviceProtocol protocol = new DeviceProtocol();

            string code = IniUtility.GetIniKeyValue(this.section, "CustomCode", "ASCII");
            string startBit = IniUtility.GetIniKeyValue(this.section, "DataStart", "=");
            if (string.IsNullOrEmpty(startBit))
                startBit = " ";
            int interceptBit = Convert.ToInt32(IniUtility.GetIniKeyValue(this.section, "Intercept", "1"));
            int dataBits = Convert.ToInt32(IniUtility.GetIniKeyValue(this.section, "DataLength", "7"));
            int point = Convert.ToInt32(IniUtility.GetIniKeyValue(this.section, "Point", "0"));
            string sequence = IniUtility.GetIniKeyValue(this.section, "Sequence", "SX");
            if (code == "ASCII")
            {
                byte byteStart = Convert.ToByte(startBit.ToCharArray()[0]);
                protocol.BeginBit = byteStart;
                protocol.EndBit = byteStart;
            }
            else if (code == "HEX")
            {
                byte byteStart = Convert.ToByte("0x" + startBit, 16);
                protocol.BeginBit = byteStart;
                protocol.EndBit = byteStart;
            }
            protocol.FrameLength = interceptBit + dataBits + 1;
            protocol.InterceptBit = interceptBit;
            protocol.Point = point;
            protocol.Sequence = sequence;

            return protocol;
        }

        /// <summary>
        /// 缓存接收到的串口数据
        /// </summary>
        /// <param name="bytes">串口数据</param>
        private void AddByte(byte[] bytes)
        {
            this.listByte = new List<byte>();
            if (bytes != null && bytes.Length > 0)
            {
                this.listByte.AddRange(bytes);

                //移除缓存中多余字节，只保留maxLength字节
                if (this.listByte.Count > this.maxLength)
                {
                    this.listByte.RemoveRange(this.maxLength, this.listByte.Count - this.maxLength);
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

            if (listByte.Count < deviceProtocol.FrameLength)
                return byteFrame;

            int count = listByte.Count;
            int index = count;
            //Logger.Write("listbytecount:" + index+";deviceProtocol.FrameLength"+deviceProtocol.FrameLength);
            //判断count是否大于1
            //11.07修改
            index = this.listByte.IndexOf(this.deviceProtocol.BeginBit);
           /*  if (count >= 1) 
            {
                count -= 1;
            }
          while ((index = this.listByte.LastIndexOf(this.deviceProtocol.BeginBit, index - 1)) != -1)
            //while ((index = this.listByte.LastIndexOf(this.deviceProtocol.BeginBit, count)) != -1)
            {
                if (listByte.Count >= index + deviceProtocol.FrameLength)
                {
                    if (listByte[index + deviceProtocol.FrameLength - 1] == this.deviceProtocol.EndBit)
                        break;
                }
            } */

            if (index != -1)
            {
                byteFrame = new byte[deviceProtocol.FrameLength];
                listByte.CopyTo(index, byteFrame, 0, this.deviceProtocol.FrameLength);
            }
            return byteFrame;
        }

        /// <summary>
        /// BCD码转换为十进制数
        /// </summary>
        /// <param name="data">要转换的BCD码</param>
        /// <returns></returns>
        private int BCDToInt(byte data)
        {
            //取低四位数
            byte num = (byte)(data & 0x0f);
            //取高四位
            data >>= 4;
            data &= 0x0f;
            //转为十位
            data *= 10;
            //得到一个十位数
            num += data;

            return num;
        }

        /// <summary>
        /// 指示灯状态切换
        /// </summary>
        private void StateThread()
        {
            while (true)
            {
                try
                {
                    if (this.serlPort != null && this.serlPort.IsOpen)
                    {
                        //判断串口是否有未读数据
                        int count = this.serlPort.BytesToRead;
                        if (count > 0)
                        {
                            if (this.OnStateChanged != null)
                            {
                                //指示灯亮
                                this.OnStateChanged(this.DeviceNo, true);
                                Thread.Sleep(500);
                                //指示灯灭
                                this.OnStateChanged(this.DeviceNo, false);
                                Thread.Sleep(500);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteException(ex);
                }
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
                    isOpen = true;
                    //指示灯亮
                    if (this.OnStateChanged != null)
                        this.OnStateChanged(this.DeviceNo, true);
                   this.serlPort.DataReceived += new SerialDataReceivedEventHandler(this.SerlPort_DataReceived);
                    //Logger.Write(string.Format("open port:{0} successed.", deviceNo));
                    //开启串口接收数据监听线程
                    //this.threadLightState = new Thread(new ThreadStart(this.StateThread));
                    //this.threadLightState.Start();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                //Logger.Write(string.Format("open port:{0} failed.", deviceNo));
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
                    isOpen = false;
                    this.serlPort.DataReceived -= new SerialDataReceivedEventHandler(this.SerlPort_DataReceived);
                    this.serlPort.Close();
                    serlPort.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                return false;
            }
        }

        public void Dispose()
        {
            if (serlPort != null)
            {
                serlPort.Dispose();
            }
        }
    }
}
