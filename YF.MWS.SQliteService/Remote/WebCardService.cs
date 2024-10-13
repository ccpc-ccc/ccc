using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Db;
using YF.Utility.Configuration;
using YF.Utility.Net;
using YF.Utility;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;

namespace YF.MWS.SQliteService.Remote
{
    public class WebCardService : IWebCardService
    {
        public bool Save(BPlanCard card)
        {
            bool isSaved = false;
            if (!CurrentClient.Instance.StartSyncMaster)
                return isSaved;
            string url = string.Format("{0}/api/sf/card/save",AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, card.JsonSerialize());
        }
    }
}
