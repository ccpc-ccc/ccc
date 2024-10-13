using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.MWS.Metadata.Dto;

namespace YF.MWS.Client.DataService.Interface.Remote
{
    public interface IWebWeightProcessService
    {
        bool DeleteWeightConfirm(string weightId);
        List<BWeightConfirm> GetUnSyncConfirmList();
        bool SaveConfirm(BWeightConfirm confirm);
        bool UpdateConfirmSyncState(BatchUpdate batchUpdate);
    }
}
