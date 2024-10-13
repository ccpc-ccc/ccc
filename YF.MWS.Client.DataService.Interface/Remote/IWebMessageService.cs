using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Metadata.Dto;

namespace YF.MWS.Client.DataService.Interface.Remote
{
    public interface IWebMessageService
    {
        SmsAuthCode SendAuthCode(SmsAuthCode authCode);
        /// <summary>
        /// 发送消费结果通知
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        bool SendConsumeResultNotice(ConsumeResultNotice notice);

        /// <summary>
        /// 发送充值结果通知
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        bool SendRechargeResultNotice(RechargeResultNotice notice);
    }
}
