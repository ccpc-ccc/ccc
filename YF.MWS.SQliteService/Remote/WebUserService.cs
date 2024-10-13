using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Dto;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata.Transfer;
using YF.MWS.Util;
using YF.Utility;
using YF.Utility.Configuration;
using YF.Utility.Metadata;
using YF.Utility.Net;

namespace YF.MWS.SQliteService.Remote
{
    public class WebUserService : IWebUserService
    {

        public bool ExistUserName(string userName) 
        {
            bool isExist = false;
            ResultMessage result = new ResultMessage();
            string serverUrl = CurrentClient.Instance.RemoteServerUrl;
            string url = string.Format("{0}/api/webuser/existusername?userName={1}", serverUrl, userName);
            string res = HttpClient.DoGetJson(url);
            if (!string.IsNullOrWhiteSpace(res) && res.Length > 0)
            {
                result = res.JsonDeserialize<ResultMessage>();
                if (result != null)
                {
                    if (result.Data.ToInt() == 1) 
                    {
                        isExist = true;
                    }
                }
            }
            return isExist;
        }

        public TLoginResult Login(string userName, string password)
        {
            TLoginResult result = new TLoginResult();
            string serverUrl = CurrentClient.Instance.RemoteServerUrl;
            string url = string.Format("{0}/api/webuser/login?userName={1}&password={2}", serverUrl, userName,password);
            string res = HttpClient.DoGetJson(url);
            if (!string.IsNullOrWhiteSpace(res) && res.Length > 0)
            {
                result = res.JsonDeserialize<TLoginResult>();
            }
            return result;
        }

        public SUser Get(string userId)
        {
            SUser result = new SUser();
            string serverUrl = CurrentClient.Instance.RemoteServerUrl;
            string url = string.Format("{0}/api/webuser/get?userId={1}", serverUrl,userId);
            string res = HttpClient.DoGetJson(url);
            if (!string.IsNullOrWhiteSpace(res) && res.Length > 0)
            {
                result = res.JsonDeserialize<SUser>();
            }
            return result;
        }

        public TPageResult GetList(PageQueryCondition qc)
        {
            TPageResult result = new TPageResult();
            string url = string.Format("{0}/api/webuser/list?condition={1}",
                    CurrentClient.Instance.RemoteServerUrl, qc.JsonSerialize());
            string res = HttpClient.DoGetJson(url);
            if (!string.IsNullOrWhiteSpace(res) && res.Length > 0)
            {
                result = res.JsonDeserialize<TPageResult>();
            }
            return result;
        }

        public List<DRole> GetUserRoleList(string userId) 
        {
            List<DRole> result = new List<DRole>();
            string serverUrl = CurrentClient.Instance.RemoteServerUrl;
            string url = string.Format("{0}/api/webuser/listuserrole?userId={1}", serverUrl,userId);
            string res = HttpClient.DoGetJson(url);
            if (!string.IsNullOrWhiteSpace(res) && res.Length > 0)
            {
                result = res.JsonDeserialize<List<DRole>>();
            }
            return result;
        }

        public List<SRole> GetRoleList()
        {
            List<SRole> result = new List<SRole>();
            string serverUrl = CurrentClient.Instance.RemoteServerUrl;
            string url = string.Format("{0}/api/webuser/listrole", serverUrl);
            string res = HttpClient.DoGetJson(url);
            if (!string.IsNullOrWhiteSpace(res) && res.Length > 0)
            {
                result = res.JsonDeserialize<List<SRole>>();
            }
            return result;
        }

        public bool SaveUser(SUser user)
        {
            bool isSaved = false;
            ResultMessage result = new ResultMessage();
            string url = string.Format("{0}/api/sf/user/Save", AppSetting.GetValue("EcsServer"));
            isSaved = WebApiUtil.Post(url, user.JsonSerialize());
            return isSaved;
        }
    }
}
