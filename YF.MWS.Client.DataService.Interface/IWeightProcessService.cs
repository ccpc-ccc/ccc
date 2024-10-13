using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata.Dto;

namespace YF.MWS.Client.DataService.Interface
{
    public interface IWeightProcessService
    {
        bool Delete(string weightId);
        BWeightConfirm GetConfirm(string weightId);
        List<BWeightConfirm> GetUnSyncConfirmList();
        bool SaveConfirm(BWeightConfirm confirm);
        bool UpdateFinishState(string weightId, FinishState state);
        bool UpdateRowState(string weightId, RowState state);
        bool UpdateConfirmSyncState(BatchUpdate batchUpdate);
    }
}
