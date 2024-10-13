using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Db;
using YF.Utility;
using YF.Utility.Configuration;
using YF.Utility.Net;

namespace YF.MWS.SQliteService.Remote
{
    public class WebPayService : IWebPayService
    {
        public bool AddPay(BPay pay)
        {
            string url = string.Format("{0}/api/sf/pay/addpay", AppSetting.GetValue("EcsServer"));
            string jsonData=pay.JsonSerialize();
            return WebApiUtil.Post(url, jsonData);
        }

        public bool AddPayFull(BPay pay)
        {
            string url = string.Format("{0}/api/sf/pay/AddPayFull", AppSetting.GetValue("EcsServer"));
            string jsonData = pay.JsonSerialize();
            return WebApiUtil.Post(url, jsonData);
        }

        public bool UpdateRowState(RowState rowState, string refId) 
        {
            string url = string.Format("{0}/api/sf/pay/UpdateRowState?rowState={1}&refId={1}", 
                                                      AppSetting.GetValue("EcsServer"),(int)rowState,refId);
            return WebApiUtil.Get(url);
        }
    }
}
