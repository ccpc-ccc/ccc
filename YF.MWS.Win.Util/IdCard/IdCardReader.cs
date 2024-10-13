using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.Utility.Log;

namespace YF.MWS.Win.Util
{
    /// <summary>
    /// 身份证识别器工具类
    /// </summary>
    public class IdCardReader
    {
        private int handle = 0;
        public bool OpenSuccess { get; set; }
        public IdCardReader(IdCardCfg cfg)
        {
            OpenSuccess = false;
            try
            {
                handle = IdCardSdk.OpenDevice(cfg.PortType, cfg.PortPara, cfg.ExtendPara);
                if (handle > 0)
                    OpenSuccess = true;
                Logger.Write("open id card reader " + OpenSuccess);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        public void Close()
        {
            int Handle = IdCardSdk.GetCurrentDevice();
            bool isSuccess = true;
            int ret = IdCardSdk.CloseDevice();
            if (ret != 0)
            {
                isSuccess = false;
            }
            Logger.Write("close id card reader " + isSuccess);
        }

        public IdCardInfo Read()
        {
            IdCardInfo info = null;
            StringBuilder sbInfo = new StringBuilder(409600);
            int ret = IdCardSdk.SdtReadCard(0, 1, sbInfo, 0);
            if (ret != 0)
            {
                return info;
            }
            info = new Metadata.IdCardInfo();
            string[] cardInfos = sbInfo.ToString().Split(':');
            info.FullName = cardInfos[1];
            info.IdNo = cardInfos[9];
            info.Address = cardInfos[8];
            return info;
        }
    }
}
