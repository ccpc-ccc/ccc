using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;

namespace YF.MWS.Client.DataService.Interface
{
    public interface ILogService
    {
        bool Add(BLog log);
        bool Add(LogActionType type,string recId,string recNo,string logDesc);
        bool Delete(List<string> lstLogId);
        PageList<QLog> GetList(LogQuery query);
        List<QLog> GetList(string recId);
    }
}
