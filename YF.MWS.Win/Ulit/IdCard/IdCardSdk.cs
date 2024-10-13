using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YF.MWS.Win.Util
{
    /// <summary>
    /// 身份证识别器SDK
    /// </summary>
    public class IdCardSdk
    {
        public static string PortType = "1";
        public static string PortPara = "115200";
        public static string ExtendPara;

        //******************************************************
        //					  神思标准化接口
        //******************************************************
        [DllImport("CommonInterface.dll")]
        public static extern int OpenDevice(string PortType, string PortPara, string ExtendPara);

        [DllImport("CommonInterface.dll")]
        public static extern int SetCurrentDevice(int DevHandle);

        [DllImport("CommonInterface.dll")]
        public static extern int GetCurrentDevice();

        [DllImport("CommonInterface.dll")]
        public static extern int CloseDevice();

        [DllImport("CommonInterface.dll")]
        public static extern int TerminalGetModel(StringBuilder TerminalModel);

        [DllImport("CommonInterface.dll")]
        public static extern int TerminalHeartBeat();


        [DllImport("CommonInterface.dll")]
        public static extern int SamGetStatus();

        [DllImport("CommonInterface.dll")]
        public static extern int SamGetIdStr(StringBuilder SamIdStr);

        [DllImport("CommonInterface.dll")]
        public static extern int IdReadCard(byte CardType, byte InfoEncoding, StringBuilder IdCardInfo, int TimeOutMs);

        [DllImport("CommonInterface.dll")]
        public static extern int IdReadSn(byte[] SN, ref int SNLen);

        [DllImport("CommonInterface.dll")]
        public static extern int SdtReadCard(byte CardType, byte InfoEncoding, StringBuilder IdCardInfo, int TimeOutMs);

        [DllImport("CommonInterface.dll")]
        public static extern int IdReadNewAddress(StringBuilder NewAddress);

        [DllImport("CommonInterface.dll")]
        public static extern int SdtReadNewAddress(StringBuilder NewAddress);

        [DllImport("CommonInterface.dll")]
        public static extern int MagRead(byte Tracks, StringBuilder TrackData1, StringBuilder TrackData2, StringBuilder TrackData3, byte TimeOutSec);

        [DllImport("CommonInterface.dll")]
        public static extern int MagWrite(byte Tracks, string TrackData1, string TrackData2, string TrackData3, byte TimeOutSec);

        [DllImport("CommonInterface.dll")]
        public static extern int CpuPowerOn(byte Slot, byte[] ATRS, ref int ATRSLen);

        [DllImport("CommonInterface.dll")]
        public static extern int CpuApdu(byte Slot, int SendApduLen, byte[] SendApdu, byte[] RecvApdu, ref int RecvApduLen);

        [DllImport("CommonInterface.dll")]
        public static extern int CpuPowerOff(byte Slot);

        [DllImport("CommonInterface.dll")]
        public static extern int M1FindCard(byte[] UID, ref int UIDLen);

        [DllImport("CommonInterface.dll")]
        public static extern int M1Authentication(byte KeyType, byte SecAddr, byte[] Key, byte[] UID);

        [DllImport("CommonInterface.dll")]
        public static extern int M1ReadBlock(byte BlockAddr, byte[] BlockData, ref int BlockDataLen);

        [DllImport("CommonInterface.dll")]
        public static extern int M1WriteBlock(byte BlockAddr, int BlockDataLen, byte[] BlockData);

        [DllImport("CommonInterface.dll")]
        public static extern int M1Halt();


        [DllImport("CommonInterface.dll")]
        public static extern int SsseReadCard(int iType, StringBuilder SSCardInfo, StringBuilder SSErrorInfo);

        [DllImport("CommonInterface.dll")]
        public static extern int IccGetCardInfo(int ICtype, string AIDList, string TagList, StringBuilder IcCardInfo);

        [DllImport("CommonInterface.dll")]
        public static extern int IccGetARQC(int ICtype, string trData, string AIDList, StringBuilder ARQC, StringBuilder trAppData);

        [DllImport("CommonInterface.dll")]
        public static extern int IccARPCExeScript(int ICtype, string trData, string ARPC, string trAppData, StringBuilder ScriptResult, StringBuilder TC);

        [DllImport("CommonInterface.dll")]
        public static extern int IccGetTrDetail(int ICtype, string AIDList, StringBuilder TrDetail);

        [DllImport("CommonInterface.dll")]
        public static extern int IccGetLoadDetail(int ICtype, string AIDList, StringBuilder LoadDetail);

        //******************************************************
        //					  常用工具接口
        //******************************************************

        [DllImport("CommonInterface.dll")]
        public static extern int HexToAsc(byte[] Hex, int HexLength, StringBuilder Asc);

        [DllImport("CommonInterface.dll")]
        public static extern int AscToHex(string Asc, int HexLength, byte[] Hex);
    }
}
