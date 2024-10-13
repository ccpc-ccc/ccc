using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;

namespace YF.MWS.Client.DataService.Interface.Remote
{
    public interface IWebFileService
    {
        List<BFile> GetUnSyncList(string companyId, FileBusinessType type);
        bool UploadPhoto(BFile file, string apiUrl);
    }
}
