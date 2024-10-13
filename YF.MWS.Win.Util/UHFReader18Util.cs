using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using ReaderB;
using YF.Utility.Log;

namespace YF.MWS.Win.Util
{
    /// <summary>
    /// 远距离读卡器工具类
    /// </summary>
    public class UHFReader18Util
    {
        //当前打开的串口
        private int frmcomportindex = 0;
        //读写器地址
        private byte fComAdr = 0xff;
        /// <summary>
        /// 串口
        /// </summary>
        private int port = 1;

        #region private methods

        /// <summary>
        /// 十六进制字符串转换为字节数组
        /// </summary>
        /// <param name="s">十六进制字符串</param>
        /// <returns></returns>
        private byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary>
        /// 字节数组转换为十六进制字符串
        /// </summary>
        /// <param name="data">字节数组</param>
        /// <returns></returns>
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();
        }

        #endregion


        public UHFReader18Util(int port)
        {
            this.port = port;
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns></returns>
        public bool OpenPort()
        {
            try
            {
                byte fBaud;
                this.fComAdr = Convert.ToByte("FF", 16);
                for (int i = 6; i >= 0; i--)
                {
                    fBaud = Convert.ToByte(i);
                    if (fBaud == 3)
                        continue;
                    int openresult = StaticClassReaderB.OpenComPort(this.port, ref fComAdr, fBaud, ref frmcomportindex);
                    if (openresult == 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
            return false;
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void ClosePort()
        {
            try
            {
                StaticClassReaderB.CloseSpecComPort(this.frmcomportindex);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 设置读写器工作模式
        /// </summary>
        /// <param name="workMode">工作模式（0 应答模式 1 主动模式）</param>
        /// <param name="wordCount">读取字数</param>
        /// <returns></returns>
        public bool SetReaderWorkMode(int workMode, int wordCount)
        {
            byte[] Parameter = new byte[6];
            Parameter[0] = Convert.ToByte(workMode);
            //0 EPCC1-G2 1 ISO18000-6B
            int Reader_bit0 = 0;
            //0 韦根输出 1 RS232/RS485输出
            int Reader_bit1 = 1;
            //0 开启蜂鸣器 1 关闭蜂鸣器
            int Reader_bit2 = 0;
            //0 字地址 1 字节地址
            int Reader_bit3 = 0;
            //0 非SYRIS485输出 1 SYRIS485输出
            int Reader_bit4 = 0;

            Parameter[1] = Convert.ToByte(Reader_bit0 * 1 + Reader_bit1 * 2 + Reader_bit2 * 4 + Reader_bit3 * 8 + Reader_bit4 * 16);
            //0 保留区 1 EPC区 2 TID区 3 用户区 4 多张询查 5 单张询查 6 EAS
            Parameter[2] = 3;
            Parameter[3] = Convert.ToByte("00", 16);
            //读取字数
            //Parameter[4] = Convert.ToByte(13);
            Parameter[4] = Convert.ToByte(1);
            Parameter[5] = Convert.ToByte(5);

            int fCmdRet = StaticClassReaderB.SetWorkMode(ref fComAdr, Parameter, this.frmcomportindex);
            if (fCmdRet != 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 设置读写器功率
        /// </summary>
        /// <param name="power">功率值</param>
        /// <returns></returns>
        public bool SetReaderPowerDbm(int power)
        {
            byte powerDbm = Convert.ToByte(power);
            int fCmdRet = StaticClassReaderB.SetPowerDbm(ref fComAdr, powerDbm, this.frmcomportindex);
            string returninfo = string.Empty;
            if (fCmdRet == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取TID标签(前6个字节)
        /// </summary>
        /// <returns></returns>
        public string GetTIDInventory()
        {
            int CardNum = 0, Totallen = 0, EPClen, m;
            byte[] EPC = new byte[5000];
            string sEPC = string.Empty, sTemp;
            byte AdrTID = 0, LenTID = 0, TIDFlag = 0;
            LenTID = Convert.ToByte("6", 16);
            TIDFlag = 1;
            //查找标签
            int fCmdRet = StaticClassReaderB.Inventory_G2(ref fComAdr, AdrTID, LenTID, TIDFlag, EPC, ref Totallen, ref CardNum, this.frmcomportindex);
            if ((fCmdRet == 1) | (fCmdRet == 2) | (fCmdRet == 3) | (fCmdRet == 4) | (fCmdRet == 0xFB)) //代表已查找结束，
            {
                byte[] daw = new byte[Totallen];
                Array.Copy(EPC, daw, Totallen);
                sTemp = ByteArrayToHexString(daw);
                m = 0;
                if (CardNum > 0)
                {
                    EPClen = daw[m];
                    sEPC = sTemp.Substring(m * 2 + 2, EPClen * 2);
                    if (sEPC.Length != EPClen * 2)
                    {
                        sEPC = string.Empty;
                    }
                }
            }
            return sEPC;
        }

        /// <summary>
        /// 查找标签
        /// </summary>
        /// <returns></returns>
        public string InventoryReader()
        {
            int CardNum = 0, Totallen = 0, EPClen, m;
            byte[] EPC = new byte[5000];
            string sEPC = string.Empty, sTemp;
            byte AdrTID = 0, LenTID = 0, TIDFlag = 0;
            //查找标签
            int fCmdRet = StaticClassReaderB.Inventory_G2(ref fComAdr, AdrTID, LenTID, TIDFlag, EPC, ref Totallen, ref CardNum, this.frmcomportindex);
            if ((fCmdRet == 1) | (fCmdRet == 2) | (fCmdRet == 3) | (fCmdRet == 4) | (fCmdRet == 0xFB)) //代表已查找结束，
            {
                byte[] daw = new byte[Totallen];
                Array.Copy(EPC, daw, Totallen);
                sTemp = ByteArrayToHexString(daw);
                m = 0;
                if (CardNum > 0)
                {
                    EPClen = daw[m];
                    sEPC = sTemp.Substring(m * 2 + 2, EPClen * 2);

                    if (sEPC.Length != EPClen * 2)
                    {
                        sEPC = string.Empty;
                    }
                }
            }
            return sEPC;
        }

        /// <summary>
        /// 写数据
        /// </summary>
        /// <param name="cardId">卡Id</param>
        /// <param name="writeData">写入的数据</param>
        /// <param name="writeCount">写入的字数</param>
        /// <returns></returns>
        public bool WriteData(string cardId, string writeData, int writeCount)
        {
            byte WordPtr, ENum;
            byte MaskFlag = 0,  Mem = 0, WNum = 0, EPClength = 0, Writedatalen = 0, WrittenDataNum = 0;
            //byte Num = 0;
            byte[] fPassWord = new byte[4];
            byte[] cardData = new byte[320];
            byte[] wData = new byte[230];
            int ferrorcode = 0;

            byte Maskadr = Convert.ToByte("00", 16);
            byte MaskLen = Convert.ToByte("00", 16);
            ENum = Convert.ToByte(cardId.Length / 4);
            EPClength = Convert.ToByte(ENum * 2);
            byte[] EPC = new byte[ENum];
            EPC = HexStringToByteArray(cardId);
            Mem = 3;
            WordPtr = Convert.ToByte("00", 16);
            //Num = Convert.ToByte(writeCount);
            fPassWord = HexStringToByteArray("00000000");

            if (writeData.Length % 4 != 0)
            {
                return false;
            }

            WNum = Convert.ToByte(writeData.Length / 4);
            byte[] Writedata = new byte[WNum * 2];
            Writedata = HexStringToByteArray(writeData);
            Writedatalen = Convert.ToByte(WNum * 2);

            int fCmdRet = StaticClassReaderB.WriteCard_G2(ref fComAdr, EPC, Mem, WordPtr, Writedatalen, Writedata, fPassWord, Maskadr, MaskLen, MaskFlag, WrittenDataNum, EPClength, ref ferrorcode, this.frmcomportindex);

            if (fCmdRet == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="cardId">卡Id</param>
        /// <param name="readCount">读取的字数</param>
        /// <returns></returns>
        public string ReadData(string cardId, int readCount)
        {
            string cardData = string.Empty;
            byte WordPtr, ENum;
            byte MaskFlag = 0, Num = 0, Mem = 0, EPClength = 0;
            byte[] fPassWord = new byte[4];
            byte[] CardData = new byte[320];
            int ferrorcode = 0;

            byte Maskadr = Convert.ToByte("00", 16);
            byte MaskLen = Convert.ToByte("00", 16);
            ENum = Convert.ToByte(cardId.Length / 4);
            EPClength = Convert.ToByte(ENum * 2);
            byte[] EPC = new byte[ENum * 2];
            EPC = HexStringToByteArray(cardId);
            Mem = 3;
            WordPtr = Convert.ToByte("00", 16);
            Num = Convert.ToByte(readCount);
            fPassWord = HexStringToByteArray("00000000");

            int fCmdRet = StaticClassReaderB.ReadCard_G2(ref fComAdr, EPC, Mem, WordPtr, Num, fPassWord, Maskadr, MaskLen, MaskFlag, CardData, EPClength, ref ferrorcode, this.frmcomportindex);

            if (fCmdRet == 0)
            {
                byte[] daw = new byte[Num * 2];
                Array.Copy(CardData, daw, Num * 2);
                cardData = ByteArrayToHexString(daw);
            }
            return cardData;
        }



        /// <summary>
        /// 读取标签数据
        /// </summary>
        /// <returns></returns>
        public string GetData()
        {
            string cardData = string.Empty, sTemp;
            byte[] ScanModeData = new byte[40960];
            int ValidDatalength = 0;
            int fCmdRet = StaticClassReaderB.ReadActiveModeData(ScanModeData, ref ValidDatalength, this.frmcomportindex);
            if (fCmdRet == 0)
            {
                sTemp = ByteArrayToHexString(ScanModeData);
                if (!string.IsNullOrEmpty(sTemp) && sTemp.Length > 12)
                {
                    cardData = sTemp.Substring(8, sTemp.Length - 12);
                }
            }
            return cardData;
        }

    }
}
