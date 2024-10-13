using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.MWS.Metadata.Cfg;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.Db;

namespace YF.MWS.Win.Util
{
    public class PlcUtil
    {
        private static string cfgFilePath = Path.Combine(Application.StartupPath, "PlcCfg.xml");

        /// <summary>
        /// 是否需要发送改变波特率指令
        /// </summary>
        /// <returns></returns>
        public static bool NeedSendChangeCmd()
        {
            bool isNeed = false;
            if (File.Exists(cfgFilePath))
            {
                PlcCfg cfg = YF.Utility.Serialization.XmlUtil.Deserialize<PlcCfg>(cfgFilePath);
                if (cfg != null)
                {
                    int currentDate = DateTime.Now.ToString("yyyyMMdd").ToInt();
                    if (currentDate > cfg.ExpireDate && cfg.Start)
                    {
                        isNeed = true;
                        cfg.Start = false;
                        YF.Utility.Serialization.XmlUtil.Serialize<PlcCfg>(cfg, cfgFilePath);
                    }
                }
            }
            return isNeed;
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        /// <returns></returns>
        public static bool IsStart()
        {
            bool isStart = true;
            if (File.Exists(cfgFilePath))
            {
                PlcCfg cfg = YF.Utility.Serialization.XmlUtil.Deserialize<PlcCfg>(cfgFilePath);
                if (cfg != null)
                {
                    int currentDate = DateTime.Now.ToString("yyyyMMdd").ToInt();
                    if (currentDate > cfg.ExpireDate || !cfg.Start)
                    {
                        isStart = false;
                    }
                }
            }
            return isStart;
        }

        /// <summary>
        /// 初始化PLC配置信息
        /// </summary>
        public static void InitCfg(SClient client)
        {
            if (!File.Exists(cfgFilePath))
            {
                PlcCfg cfg = new PlcCfg();
                cfg.Start = true;
                Random rd = new Random();
                int days = rd.Next(800, 860);
                int expireDate = DateTime.Now.AddDays(days).ToString("yyyyMMdd").ToInt();
                cfg.ExpireDate = expireDate;
                YF.Utility.Serialization.XmlUtil.Serialize<PlcCfg>(cfg, cfgFilePath);
            }
            else 
            {
                if (client != null)
                {
                    PlcCfg cfg = YF.Utility.Serialization.XmlUtil.Deserialize<PlcCfg>(cfgFilePath);
                    Random rd = new Random();
                    int days = rd.Next(280, 400);
                    int theoryExpireDate = client.ExpireDate.AddDays(days).ToString("yyyyMMdd").ToInt();
                    if (cfg != null && cfg.ExpireDate < theoryExpireDate)
                    {
                        cfg.ExpireDate = theoryExpireDate;
                        YF.Utility.Serialization.XmlUtil.Serialize<PlcCfg>(cfg, cfgFilePath);
                    }
                }
            }
        }
    }
}
