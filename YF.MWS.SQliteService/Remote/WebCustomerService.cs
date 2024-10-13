using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Dto;
using YF.MWS.Util;
using YF.Utility;
using YF.Utility.Configuration;
using YF.Utility.Net;

namespace YF.MWS.SQliteService.Remote
{
    public class WebCustomerService : IWebCustomerService
    {
        public bool BatchDeletePhysics(BatchUpdate batchUpdate) 
        {
            string url = string.Format("{0}/api/sf/customer/BatchDeletePhysics", AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, batchUpdate.JsonSerialize());
        }
        public bool Delete(List<string> customerIds)
        {
            string url = string.Format("{0}/api/sf/customer/Delete?customerIds={1}", 
                                                        AppSetting.GetValue("EcsServer"), string.Join(",", customerIds));
            return WebApiUtil.Get(url);
        }

        public bool DeletePhysics(string customerId)
        {
            string url = string.Format("{0}/api/sf/customer/DeletePhysics?customerId={1}",
                                                        AppSetting.GetValue("EcsServer"), customerId);
            return WebApiUtil.Get(url);
        }

        public List<DCustomer> GetList(string companyId)
        {
            List<DCustomer> result = new List<DCustomer>();
            string serverUrl = CurrentClient.Instance.RemoteServerUrl;
            string url = string.Format("{0}/api/webcustomer/listwithcompany?companyId={1}", serverUrl,companyId);
            string res = HttpClient.DoGetJson(url);
            if (!string.IsNullOrWhiteSpace(res) && res.Length > 0)
            {
                result = res.JsonDeserialize<List<DCustomer>>();
            }
            return result;
        }

        public bool Save(SCustomer customer)
        {
            bool isSaved = false;
            if (!CurrentClient.Instance.StartSyncMaster)
                return isSaved;
            string url = string.Format("{0}/api/sf/customer/save", AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, customer.JsonSerialize());
        }

        public bool UpdateState(CustomerUpdate update)
        {
            string url = string.Format("{0}/api/sf/customer/UpateState", AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, update.JsonSerialize());
        }

        public bool UpdateSyncStateNew(BatchUpdate update)
        {
            string url = string.Format("{0}/api/sf/customer/UpdateSyncStateNew", AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, update.JsonSerialize());
        }
    }
}
