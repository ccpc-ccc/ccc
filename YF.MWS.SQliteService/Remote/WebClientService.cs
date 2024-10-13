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
    public class WebClientService : IWebClientService
    {
        public bool AddConsult(BConsult consult) 
        {
            string url = string.Format("{0}/api/sf/client/AddConsult", AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, consult.JsonSerialize());
        }

        public SClient Get(string machineCode)
        {
            string url = string.Format("{0}/api/sf/client/GetClient?machineCode={1}", AppSetting.GetValue("EcsServer"), machineCode);
            return WebApiUtil.Get<SClient>(url);
        }

        public List<SClient> GetClientList(string companyId) 
        {
            string url = string.Format("{0}/api/sf/client/GetClientList?companyId={1}", AppSetting.GetValue("EcsServer"), companyId);
            return WebApiUtil.Get<List<SClient>>(url);
        }

        public bool Save(SClient client)
        {
            bool isSaved = false;
            if (!CurrentClient.Instance.StartSyncMaster)
                return isSaved;
            string url = string.Format("{0}/api/sf/client/save",AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url,client.JsonSerialize());
        }

        public bool SaveLocation(SLocation location)
        {
            bool isSaved = false;
            if (!CurrentClient.Instance.StartSyncMaster)
                return isSaved;
            string url = string.Format("{0}/api/sf/master/SaveLocation", AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, location.JsonSerialize());
        }
    }
}
