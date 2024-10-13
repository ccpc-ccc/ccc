using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Metadata.Screen;
using YF.Utility.Log;

namespace YF.MWS.Win.Util.Screen
{
    /// <summary>
    /// 灵信LED工具类
    /// </summary>
    public class LXLedUtil
    {
        private int hLed = 0;
        private LXCfg lxCfg = null;

        public int HLed
        {
            get { return hLed; }
            set { hLed = value; }
        }

        public LXLedUtil(LXCfg mLxCfg)
        {
            lxCfg = mLxCfg;
        }

        private bool isInited = false;

        /// <summary>
        /// 发送广告信息
        /// </summary>
        /// <returns></returns>
        public bool SendAd(int fontSize)
        {
            bool isSended = false;
            if (!isInited)
            {
                return isSended;
            }
            string info = lxCfg.AdContent;
            isSended = SendText(info, fontSize);
            /*try
            {
                
                int ret = 0;
                string message = null;
                int playSpeed = lxCfg.PlaySpeed;
                LXSDK.AddControl(hLed, lxCfg.ScreenNo, lxCfg.ScreenColor);
                LXSDK.AddProgram(hLed, 1, 0);
                LXSDK.AddLnTxtString(hLed, 1, 1, 0, 0, lxCfg.ScreenWidth, lxCfg.ScreenHeight, info, "宋体", 12, 255, false, false, false, 32, playSpeed, 0);
                if (lxCfg.CommunicationModel == Metadata.CommunicationModelType.SerlPort)
                {
                    LXSDK.SearchController2(hLed, "", false, 2);
                }
                ret = LXSDK.SendControl(hLed, 1, IntPtr.Zero);
                switch (ret)
                {
                    case 1:
                        isSended = true;
                        message = "LX_LED send successfully";
                        break;
                    case 2:
                        message = "LX_LED communication failed";
                        break;
                    case 3:
                        message = "LX_LED send failed";
                        break;
                }
                Logger.Write(message);
            }
            catch (Exception e) 
            {
                Logger.WriteException(e);
            }*/
            return isSended;
        }

        /// <summary>
        /// 发送多行文字信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool SendText(string info, int fontSize)
        {
            bool isSended = false;
            if (!isInited)
            {
                return isSended;
            }
            try
            {
                int ret = 0;
                string message = null;
                int playSpeed = lxCfg.PlaySpeed;
                int delay = lxCfg.Delay;
                /*LXSDK.AddControl(hLed, lxCfg.ScreenNo, lxCfg.ScreenColor);
                LXSDK.AddProgram(hLed, 1, 0);
                LXSDK.AddLnTxtString(hLed, 1, 1, 0, 0, lxCfg.ScreenWidth, lxCfg.ScreenHeight, info, "宋体", 12, 255, false, false, false, 32, playSpeed, 0);
                */
                LXSDK.AddControl(hLed, lxCfg.ScreenNo, lxCfg.ScreenColor);
                LXSDK.AddProgram(hLed, 1, 0);
                LXSDK.AddFileArea(hLed, 1, 1, 0, 0, lxCfg.ScreenWidth, lxCfg.ScreenHeight, 1);
                LXSDK.AddFileString(hLed, 1, 1, 1, info, "宋体", fontSize, 255, false, false, false, 1, lxCfg.ScreenWidth, lxCfg.ScreenHeight / 2, 1, 255, playSpeed, delay, 1);
                if (lxCfg.CommunicationModel == Metadata.CommunicationModelType.SerlPort)
                {
                    LXSDK.SearchController2(hLed, "", false, 2);
                }
                ret = LXSDK.SendControl(hLed, 1, IntPtr.Zero);
                switch (ret)
                {
                    case 1:
                        isSended = true;
                        message = "LX_LED send successfully";
                        break;
                    case 2:
                        message = "LX_LED communication failed";
                        break;
                    case 3:
                        message = "LX_LED send failed";
                        break;
                }
                Logger.Write(message + ";info:" + info);
            }
            catch (Exception e)
            {
                Logger.WriteException(e);
            }
            return isSended;
        }

        public bool Setting()
        {
            bool isSettinged = false;
            if (lxCfg == null)
            {
                return isSettinged;
            }
            if (hLed != 0)
            {
                LXSDK.EndSend(hLed);
                hLed = 0;
            }
            hLed = LXSDK.StartSend();
            string message = null;
            int transModel = 1;
            if (lxCfg.CommunicationModel == Metadata.CommunicationModelType.SerlPort)
            {
                transModel = 2;
            }
            LXSDK.SetTransMode(hLed, transModel, 0, lxCfg.CardModel, lxCfg.ScreenNo);
            message = string.Format("SetTransMode:{0},{1},{2},{3},{4}", hLed, transModel, 0, lxCfg.CardModel, lxCfg.ScreenNo);
            Logger.Write(message);
            if (lxCfg.CommunicationModel == Metadata.CommunicationModelType.Network)
            {
                LXSDK.SetNetworkPara(hLed, lxCfg.ScreenNo, lxCfg.IPAddr);
                message = string.Format("SetNetworkPara:{0},{1},{2}", hLed, lxCfg.ScreenNo, lxCfg.IPAddr);
                Logger.Write(message);
            }
            else
            {
                LXSDK.SetSerialPortPara(hLed, lxCfg.ScreenNo, lxCfg.PortNo, lxCfg.BaudRate);
                message = string.Format("SetSerialPortPara:{0},{1},{2},{3}", hLed, lxCfg.ScreenNo, lxCfg.PortNo, lxCfg.BaudRate);
                Logger.Write(message);
            }
            if (hLed != 0)
            {
                isSettinged = true;
            }
            return isSettinged;
        }

        public bool SetScreenParameter()
        {
            bool isSettinged = false;
            string message = null;
            int ret = 0;
            if (lxCfg.CardModel == 2)
            {
                ret = LXSDK.SendScreenPara(hLed, lxCfg.ScreenColor, lxCfg.ScreenWidth, lxCfg.ScreenHeight);
                message = string.Format("SendScreenPara:{0},{1},{2},{3}", hLed, lxCfg.ScreenColor, lxCfg.ScreenWidth, lxCfg.ScreenHeight);
                Logger.Write(message);
            }
            else
            {
                ScreenInfo si = new ScreenInfo();
                si.screenwidth = lxCfg.ScreenWidth;
                si.screenheight = lxCfg.ScreenHeight;
                si.dbcolor = lxCfg.ScreenColor;
                si.baud = lxCfg.BaudRate;
                ret = LXSDK.SetScreenInfo(hLed, si);
                message = string.Format("SetScreenInfo:{0},{1},{2},{3},{4}", hLed, si.screenwidth, si.screenheight, si.dbcolor, si.baud);
                Logger.Write(message);
            }
            if (ret == 1)
            {
                isSettinged = true;
                isInited = true;
                message = "LX_LED config screen parameter sucessfully";
            }
            else
            {
                message = "LX_LED config screen parameter failed";
            }
            Logger.Write(message + ";isInited:" + isInited);
            return isSettinged;
        }
    }
}
