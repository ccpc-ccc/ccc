using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.Utility.Log;

namespace YF.MWS.Win
{
    public class ModbusUtil
    {
        public string ServerIP { get; set; }
        public int ServerPort { get; set; }
        private Socket _socket;
        public delegate void PacketHandler(bool isOpen);
        public PacketHandler Connected;
        /// <summary>
        /// 通讯方式
        /// </summary>
        private DeviceCommMode commMode = DeviceCommMode.Com;
        /// <summary>
        /// 控制器编号
        /// </summary>
        private int modbusNo;
        private int funSixCloseTime = 0;
        /// <summary>
        /// 红外启动重量
        /// </summary>
        private decimal blockCondition = 0;
        /// <summary>
        /// 控制器串口状态
        /// </summary>
        public bool IsOpen
        {
            get
            {
                if (this.serlPort != null && this.serlPort.IsOpen)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 串口
        /// </summary>
        private SerialPort serlPort;

        public ModbusUtil(int modbusNo)
        {
            SysCfg cfg = CfgUtil.GetCfg();
            if (cfg != null && cfg.NobodyWeight != null)
            {
                funSixCloseTime = cfg.NobodyWeight.FunSixCloseTime;
                blockCondition = cfg.NobodyWeight.InfraredWeight;
                commMode = cfg.Weight.ModBusCommMode;
                ServerIP=cfg.NobodyWeight.ModbusIP;
                ServerPort = cfg.NobodyWeight.ModbusPort;
            }
            this.modbusNo = modbusNo;
            if(commMode== DeviceCommMode.Com)
                 InitPort();
        }

        /// <summary>
        /// 初始化串口
        /// </summary>
        private void InitPort()
        {
            //控制器小节名称
            string section = string.Format("Modbus{0}", this.modbusNo);

            this.serlPort = new SerialPort();
            this.serlPort.PortName = IniUtility.GetIniKeyValue(section, "Port", "COM1");
            this.serlPort.BaudRate = Convert.ToInt32(IniUtility.GetIniKeyValue(section, "BaundRate", "9600"));
            this.serlPort.DataBits = Convert.ToInt32(IniUtility.GetIniKeyValue(section, "DataBit", "8"));
            this.serlPort.StopBits = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), IniUtility.GetIniKeyValue(section, "StopBit", "One"), true);
            this.serlPort.Parity = (System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity), IniUtility.GetIniKeyValue(section, "Parity", "None"), true);
            //设置串口读写超时时间
            this.serlPort.ReadTimeout = 15000;
            this.serlPort.WriteTimeout = 15000;
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
        public void CloseServer() {
            if(this._socket!=null&&this._socket.Connected) this._socket.Close();
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

        private string GetByteString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString() + ";");
            }
            return sb.ToString();
        }

        private bool SendStocket(byte[] byteSend)
        {
            bool isSuccess = false;
            try
            {
                Thread.Sleep(500);
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//定义一个Socket
                client.Connect(new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort));
                client.Send(byteSend);
                isSuccess = true;
                client.Close();
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                isSuccess = false;
            }
            return isSuccess;
        }
        /// <summary>
        /// 以指定功能码发送控制命令（注：06功能码的起始地址为01）
        /// </summary>
        /// <param name="funCode">功能码</param>
        /// <param name="address">寄存器地址</param>
        /// <param name="value">写入的值或读取的数量</param>
        /// <returns></returns>
        public bool SendControl(short funCode, short address, short value)
        {
            bool isSuccess = false;
            byte[] byteSend = new byte[8];
            byteSend[0] = 0x01;
            byteSend[1] = (byte)funCode;
            //06功能码的起始地址为01
            if (funCode == 6 && address == 0)
            {
                address = 1;
            }
            byteSend[2] = 0x00;
            byteSend[3] = (byte)address;

            if (funCode != 5)
            {
                byteSend[4] = 0x00;
                if (funCode == 6)
                {
                    if (funSixCloseTime > 0)
                    {
                        byteSend[5] = (byte)funSixCloseTime;
                    }
                    else
                    {
                        byteSend[5] = 0x05;
                    }
                }
                else
                {
                    byteSend[5] = (byte)value;
                }
            }
            else
            {
                //05功能码命令特殊处理
                if (value == 0)
                {
                    byteSend[4] = 0x00;
                }
                else
                {
                    byteSend[4] = 0xff;
                }
                byteSend[5] = 0x00;
            }

            //获取CRC校验码
            byte[] CRC = new byte[2];
            this.GetCRC(byteSend, ref CRC);

            byteSend[6] = CRC[0];
            byteSend[7] = CRC[1];
            if (commMode == DeviceCommMode.Com)
            {
                if (this.serlPort != null && this.serlPort.IsOpen)
                {
                    //Logger.Write("connected com port success");
                    try
                    {
                        Thread.Sleep(500);
                        //清除输入输出缓存

                        this.serlPort.DiscardInBuffer();
                        this.serlPort.DiscardOutBuffer();

                        this.serlPort.Write(byteSend, 0, byteSend.Length);
                        if (funCode == 6)
                        {
                            //Logger.Write(string.Format("address:{0};funcode:{1}", address, GetByteString(byteSend)));
                        }
                        //获取控制器返回的数据
                        byte[] byteResponse;
                        switch (funCode)
                        {
                            case 1:
                            case 2:
                                byteResponse = new byte[6];
                                break;
                            case 3:
                                byteResponse = new byte[7];
                                break;
                            default:
                                byteResponse = new byte[8];
                                break;
                        }
                        //this.GetResponse(ref byteResponse);

                        //验证返回的数据是否正确
                        //isSuccess = CheckCRC(byteResponse);
                        isSuccess = true;
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteException(ex);
                        isSuccess = false;
                    }
                }
            }
            else
            {
                isSuccess= SendStocket(byteSend);
            }
            return isSuccess;
        }
        /// <summary>
        /// 网口设备发送指令 time -1断开 0闭合 >0 闭合后断开
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SendData(int address,int time) {
            if (_socket == null || !_socket.Connected) return  false;
            byte[] bs =new  byte[]{ 0x48, 0x3A, 0x01, 0x70, 0x02, 0x00, 0x00, 0x00, 0x45, 0x44 };
            try {
                bs[4] = (byte)address;
                if (time < 0) bs[5] = 0;
                else bs[5] = (byte)1;
                _socket.Send(bs);
                if (time > 0) {
                    await Task.Delay(time * 1000);
                    bs[5] = 0;
                    _socket.Send(bs);
                }
                return true;
            } catch (Exception ex) {
                Logger.Write("发送数据到网口数据失败 "+ex.Message);
                return false;
            }
        }
        public async Task InitServer(string ip,int port) {
            try {
                this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                await this._socket.ConnectAsync(ip, port);
                if (this.Connected != null) this.Connected(true);
            } catch (Exception ex) {
                Logger.WriteException(ex);
                if (this.Connected != null) this.Connected(false);
            }
        }
        /// <summary>
        /// 改变PLC波特率
        /// </summary>
        /// <param name="isEnable">true:改为9600 flase:改为19200</param>
        public void ChangeDevice(bool isEnable) 
        {
            List<byte> byteSend = new List<byte>();
            if (isEnable)
            {
                byteSend = new List<byte>() { 0x01, 0x06, 0x01, 0x00, 0x00, 0x02, 0x09, 0xF7 };
            }
            else
            {
                byteSend = new List<byte>() { 0x01, 0x06, 0x01, 0x00, 0x00, 0x03, 0xC8, 0x37 };
            }
            if (this.serlPort != null && this.serlPort.IsOpen)
            {
                try
                {
                    //清除输入输出缓存
                    this.serlPort.DiscardInBuffer();
                    this.serlPort.DiscardOutBuffer();
                    serlPort.Write(byteSend.ToArray(), 0, byteSend.Count);
                }
                catch (Exception ex)
                {
                    Logger.WriteException(ex);
                }
            }
        }

        /// <summary>
        /// 以指定功能码发送控制命令（注：06功能码的起始地址为01）
        /// </summary>
        /// <param name="funCode">功能码</param>
        /// <param name="address">寄存器地址</param>
        /// <param name="value">写入的值或读取的数量</param>
        /// <param name="byteFun">发送的命令</param>
        /// <param name="byteRet">返回值</param>
        /// <returns></returns>
        public bool SendControl(short funCode, short address, short value, out byte[] byteFun, out byte[] byteRet, int type)
        {
            byteFun = null;
            byteRet = null;
            byte[] byteSend = new byte[8];
            byteSend[0] = 0x01;
            byteSend[1] = (byte)funCode;
            //06功能码的起始地址为01
            if (funCode == 6 && address == 0)
            {
                address = 1;
            }
            byteSend[2] = 0x00;
            byteSend[3] = (byte)address;

            if (funCode != 5)
            {
                byteSend[4] = 0x00;
                byteSend[5] = (byte)value;
            }
            else
            {
                //05功能码命令特殊处理
                if (value == 0)
                {
                    byteSend[4] = 0x00;
                }
                else
                {
                    byteSend[4] = 0xff;
                }
                byteSend[5] = 0x00;
            }

            //获取CRC校验码
            byte[] CRC = new byte[2];
            this.GetCRC(byteSend, ref CRC);

            byteSend[6] = CRC[0];
            byteSend[7] = CRC[1];

            byteFun = byteSend;
            if (type == 0)
            {
                if (this.serlPort != null && this.serlPort.IsOpen)
                {
                    try
                    {
                        //清除输入输出缓存
                        this.serlPort.DiscardInBuffer();
                        this.serlPort.DiscardOutBuffer();
                        this.serlPort.Write(byteSend, 0, byteSend.Length);
                        //获取控制器返回的数据
                        byte[] byteResponse;
                        switch (funCode)
                        {
                            case 1:
                            case 2:
                                byteResponse = new byte[6];
                                break;
                            case 3:
                                byteResponse = new byte[7];
                                break;
                            default:
                                byteResponse = new byte[8];
                                break;
                        }
                        this.GetResponse(ref byteResponse);
                        byteRet = byteResponse;

                        //验证返回的数据是否正确
                        if (CheckCRC(byteResponse))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteException(ex);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return SendStocket(byteSend);
            }
        }

        /// <summary>
        /// 检测红外对射被档状态
        /// </summary>
        /// <returns></returns>
        public bool ValidateInfrared()
        {
            bool isValidated = true;
            byte result = GetState();
            /*if(blockCondition== InfraredBlockCondition.Zero)
            {
                if ((result & 0x01) == 0x00 || (result >> 1 & 0x01) == 0x00) //X1或者X2被挡住
                {
                    isValidated = false;
                }
            }
            else
            {
                if ((result & 0x01) == 0x01 || (result >> 1 & 0x01) == 0x01) //X1或者X2被挡住
                {
                    isValidated = false;
                }
            }*/
            return isValidated;
        }

        /// <summary>
        /// 以02功能码发送读取输入状态命令
        /// </summary>
        /// <param name="address">寄存器地址</param>
        /// <param name="value">读取输入控制数量</param>
        /// <returns>输入控制的状态 0：断开、1：闭合</returns>
        public byte GetState()
        {
            byte result = 0x00;
            if (this.serlPort != null && this.serlPort.IsOpen)
            {
                try
                {
                    //清除输入输出缓存
                    this.serlPort.DiscardInBuffer();
                    this.serlPort.DiscardOutBuffer();
                    //01 02 00 00 00 10 79 C6 
                    byte[] byteSend = new byte[8];
                    byteSend[0] = 01;
                    byteSend[1] = 0x02;
                    byteSend[2] = 0x00;
                    byteSend[3] = 0x00;
                    byteSend[4] = 0x00;
                    byteSend[5] = 0x10;

                    //获取CRC校验码
                    byte[] CRC = new byte[2];
                    this.GetCRC(byteSend, ref CRC);

                    byteSend[6] = 0x79;
                    byteSend[7] = 0xC6;

                    this.serlPort.Write(byteSend, 0, byteSend.Length);
                    //获取控制器返回的数据
                    byte[] byteResponse = new Byte[6];
                    this.GetResponse(ref byteResponse);
                    //Logger.Write("GetState:" + byteResponse.ToHexStr());
                    result = byteResponse[3];
                }
                catch (Exception ex)
                {
                    Logger.WriteException(ex);
                }
            }
            return result;
        }

        /// <summary>
        /// 以02功能码发送读取输入状态命令
        /// </summary>
        /// <param name="address">寄存器地址</param>
        /// <param name="value">读取输入控制数量</param>
        /// <returns>输入控制的状态 0：断开、1：闭合</returns>
        public int GetState(short address, short count)
        {
            if (this.serlPort != null && this.serlPort.IsOpen)
            {
                try
                {
                    //清除输入输出缓存
                    this.serlPort.DiscardInBuffer();
                    this.serlPort.DiscardOutBuffer();
                    //01 02 00 00 00 10 79 C6 
                    byte[] byteSend = new byte[8];
                    byteSend[0] = (byte)address;
                    byteSend[1] = 0x02;
                    byteSend[2] = 0x00;
                    byteSend[3] = 0x00;
                    byteSend[4] = 0x00;
                    byteSend[5] = (byte)count;

                    //获取CRC校验码
                    byte[] CRC = new byte[2];
                    this.GetCRC(byteSend, ref CRC);

                    byteSend[6] = CRC[0];
                    byteSend[7] = CRC[1];

                    this.serlPort.Write(byteSend, 0, byteSend.Length);
                    //获取控制器返回的数据
                    byte[] byteResponse = new Byte[6];
                    this.GetResponse(ref byteResponse);

                    //验证返回的数据是否正确
                    //if (CheckCRC(byteResponse))
                    //{
                    //    if (byteResponse[3] == 0)
                    //    {
                    //        return 1;
                    //    }
                    //    else
                    //    {
                    //        return 0;
                    //    }
                    //}
                    //else
                    //{
                    //    return 0;
                    //}
                    //Logger.Write(byteResponse.to
                    if ((byteResponse[3] & 0x01) == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteException(ex);
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 获取控制器返回的数据
        /// </summary>
        /// <param name="response">二进制数组</param>
        private void GetResponse(ref byte[] response)
        {
            for (int i = 0; i < response.Length; i++)
            {
                response[i] = (byte)(this.serlPort.ReadByte());
            }
        }

        /// <summary>
        /// 计算CRC校验码
        /// </summary>
        /// <param name="message">要计算的二进制数组</param>
        /// <param name="CRC">CRC校验码</param>
        private void GetCRC(byte[] byteData, ref byte[] CRC)
        {
            ushort CRCFull = 0xFFFF;
            byte CRCHigh = 0xFF, CRCLow = 0xFF;
            char CRCLSB;

            for (int i = 0; i < byteData.Length - 2; i++)
            {
                CRCFull = (ushort)(CRCFull ^ byteData[i]);

                for (int j = 0; j < 8; j++)
                {
                    CRCLSB = (char)(CRCFull & 0x0001);
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

                    if (CRCLSB == 1)
                        CRCFull = (ushort)(CRCFull ^ 0xA001);
                }
            }
            CRC[1] = CRCHigh = (byte)((CRCFull >> 8) & 0xFF);
            CRC[0] = CRCLow = (byte)(CRCFull & 0xFF);
        }

        /// <summary>
        /// 检测CRC校验码
        /// </summary>
        /// <param name="byteData">要检测的二进制数组</param>
        /// <returns></returns>
        private bool CheckCRC(byte[] byteData)
        {
            byte[] CRC = new byte[2];
            GetCRC(byteData, ref CRC);

            if (CRC[0] == byteData[byteData.Length - 2] && CRC[1] == byteData[byteData.Length - 1])
                return true;
            else
                return false;
        }
    }
}
