using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Util;
using YF.Utility.Log;
using YF.Utility;
using YF.Utility.Net;
using YF.Utility.Metadata;

namespace YF.MWS.Win.Util
{
    public class NetworkUtil
    {
        /// <summary>
        /// 检测是否能够连接到服务器
        /// </summary>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public static bool IsConnectedServer(SysCfg cfg) 
        {
            bool isConnected = false;
            try
            {
                if (cfg != null && !string.IsNullOrEmpty(cfg.Transfer.ServerUrl))
                {
                    string url = cfg.Transfer.ServerUrl + "/api/webuser/netstatus";
                    string res = HttpClient.DoGetJson(url);
                    if (!string.IsNullOrEmpty(res))
                    {
                        ResultMessage message = res.JsonDeserialize<ResultMessage>();
                        if (message != null && message.Code == ResultCode.Success)
                        {
                            isConnected = true;
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
            return isConnected;
        }
    }
}
