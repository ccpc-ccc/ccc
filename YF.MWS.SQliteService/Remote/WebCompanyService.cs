using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Dto;
using YF.MWS.Util;
using YF.Utility;
using YF.Utility.Configuration;
using YF.Utility.Net;

namespace YF.MWS.SQliteService.Remote
{
    public class WebCompanyService : IWebCompanyService
    {
        public bool DeleteDept(string deptId)
        {
            string url = string.Format("{0}/api/sf/company/DeleteDept?deptId={1}", AppSetting.GetValue("EcsServer"), deptId);
            return WebApiUtil.Get(url);
        }

        public bool DeleteWareh(string warehId)
        {
            string url = string.Format("{0}/api/sf/master/DeleteWareh?warehId={1}", AppSetting.GetValue("EcsServer"), warehId);
            return WebApiUtil.Get(url);
        }

        public List<DCompany> GetList() 
        {
            List<DCompany> result = new List<DCompany>();
            string serverUrl = CurrentClient.Instance.RemoteServerUrl;
            string url = string.Format("{0}/api/webcompany/list", serverUrl);
            string res = HttpClient.DoGetJson(url);
            if (!string.IsNullOrWhiteSpace(res) && res.Length > 0)
            {
                result = res.JsonDeserialize<List<DCompany>>();
            }
            return result;
        }

        public SCompanyPayCfgFull GetPayCfg(string companyId, PayPluginType type)
        {
            string url = string.Format("{0}/api/sf/company/getpaycfg?companyId={1}&type={2}", 
                                                          AppSetting.GetValue("EcsServer"),companyId,(int)type);
            return WebApiUtil.Get<SCompanyPayCfgFull>(url);
        }

        public SCompany GetWithNo(string companyNo)
        {
            string url = string.Format("{0}/api/sf/company/getwithno?companyNo={1}",
                                                 AppSetting.GetValue("EcsServer"), companyNo);
            return WebApiUtil.Get<SCompany>(url);
        }

        public bool SaveDept(SDept dept)
        {
            string url = string.Format("{0}/api/sf/company/SaveDept", AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, dept.JsonSerialize());
        }

        public bool SavePayCfg(SCompanyPayCfgFull companyPayCfg)
        {
            string url = string.Format("{0}/api/sf/company/savepaycfg",AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, companyPayCfg.JsonSerialize());
        }

        public bool SaveWareh(SWareh wareh)
        {
            bool isSaved = false;
            if (!CurrentClient.Instance.StartSyncMaster)
                return isSaved;
            string url = string.Format("{0}/api/sf/master/SaveWareh", AppSetting.GetValue("EcsServer"));
            return WebApiUtil.Post(url, wareh.JsonSerialize());
        }
    }
}
