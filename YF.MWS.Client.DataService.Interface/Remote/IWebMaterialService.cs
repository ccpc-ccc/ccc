using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.MWS.Metadata.Dto;

namespace YF.MWS.Client.DataService.Interface.Remote
{
    public interface IWebMaterialService
    {
        bool Delete(List<string> materialIds);
        List<SMaterial> GetUnSyncList();
        bool Save(SMaterial material);
        bool UpdateSyncState(BatchUpdate batchUpdate);
    }
}
