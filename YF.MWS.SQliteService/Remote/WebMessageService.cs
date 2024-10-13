using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Metadata.Dto;
using YF.Utility.Configuration;
using YF.Utility.Net;
using YF.Utility;

namespace YF.MWS.SQliteService.Remote
{
    public class WebMessageService : IWebMessageService
    {
        public SmsAuthCode SendAuthCode(SmsAuthCode authCode)
        {
            string url = string.Format("{0}/api/sf/message/SendAuthCode", AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post<SmsAuthCode>(url, authCode.JsonSerialize());
        }

        public bool SendConsumeResultNotice(ConsumeResultNotice notice)
        {
            string url = string.Format("{0}/api/sf/message/SendConsumeResultNotice", AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, notice.JsonSerialize());
        }

        public bool SendRechargeResultNotice(RechargeResultNotice notice)
        {
            string url = string.Format("{0}/api/sf/message/SendRechargeResultNotice", AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, notice.JsonSerialize());
        }
    }
}
