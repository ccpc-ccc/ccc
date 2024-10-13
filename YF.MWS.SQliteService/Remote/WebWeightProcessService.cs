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

namespace YF.MWS.SQliteService.Remote
{
    public class WebWeightProcessService : IWebWeightProcessService
    {
        public bool DeleteWeightConfirm(string weightId)
        {
            string url = string.Format("{0}/api/sf/WeightProcess/DeleteWeightConfirm?weightId={1}",
                                           AppSetting.GetValue("EcsServer"), weightId);
            return WebApiUtil.Get(url);
        }
        public List<BWeightConfirm> GetUnSyncConfirmList()
        {
            string url = string.Format("{0}/api/sf/WeightProcess/UnSyncConfirmListNew?companyId={1}",
                                                       AppSetting.GetValue("EcsServer"), "");
            return WebApiUtil.Get<List<BWeightConfirm>>(url);
        }

        public bool SaveConfirm(BWeightConfirm confirm)
        {
            confirm.SyncState = SyncState.Synced;
            string url = string.Format("{0}/api/sf/WeightProcess/SaveConfirm", AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, confirm.JsonSerialize());
        }

        public bool UpdateConfirmSyncState(BatchUpdate batchUpdate)
        {
            string url = string.Format("{0}/api/sf/WeightProcess/UpdateConfirmSyncStateNew", AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, batchUpdate.JsonSerialize());
        }
    }
}
