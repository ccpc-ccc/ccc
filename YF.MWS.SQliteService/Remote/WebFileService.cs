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
using YF.MWS.Metadata.Cfg;

namespace YF.MWS.SQliteService.Remote
{
    public class WebFileService : IWebFileService
    {
        public List<BFile> GetUnSyncList(string companyId, FileBusinessType type)
        {
            string url = string.Format("{0}/api/sf/file/GetUnSyncList?companyId={1}&type={2}", 
                                                       AppSetting.GetValue("EcsServer"), companyId, type.ToString());
            return WebApiUtil.Get<List<BFile>>(url);
        }

        public bool UploadPhoto(BFile file, string apiUrl)
        {
            bool isUploaded = false;
            string url = string.Format(@"{0}/api/webfile/UploadPhoto", apiUrl);
            isUploaded = WebApiUtil.Post(url, file.JsonSerialize());
            return isUploaded;
        }
    }
}
