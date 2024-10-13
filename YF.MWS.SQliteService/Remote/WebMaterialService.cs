using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Db;
using YF.Utility.Configuration;
using YF.Utility.Net;
using YF.Utility;
using YF.MWS.Metadata.Dto;
using YF.MWS.Metadata;

namespace YF.MWS.SQliteService.Remote
{
    public class WebMaterialService : IWebMaterialService
    {
        public bool Delete(List<string> materialIds)
        {
            string url = string.Format("{0}/api/sf/material/Delete?materialIds={1}", 
                                                          AppSetting.GetValue("EcsServer"), string.Join(",",materialIds));
            return WebApiUtil.Get(url);
        }

        public List<SMaterial> GetUnSyncList()
        {
            string companyId = "";// CurrentUser.Instance.RJCompanyId;
            string url = string.Format("{0}/api/sf/material/GetUnSyncList?companyId={1}",
                                                          AppSetting.GetValue("EcsServer"), companyId);
            return WebApiUtil.Get<List<SMaterial>>(url);
        }

        public bool Save(SMaterial material)
        {
            bool isSaved = false;
            if (!CurrentClient.Instance.StartSyncMaster)
                return isSaved;
            string url = string.Format("{0}/api/sf/material/save", AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, material.JsonSerialize());
        }

        public bool UpdateSyncState(BatchUpdate batchUpdate)
        {
            string url = string.Format("{0}/api/sf/material/UpdateSyncState", AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, batchUpdate.JsonSerialize());
        }
    }
}
