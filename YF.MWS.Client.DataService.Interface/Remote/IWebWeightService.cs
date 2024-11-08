using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Db.Server;
using YF.MWS.Metadata.Dto;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata.Transfer;

namespace YF.MWS.Client.DataService.Interface.Remote
{
    public interface IWebWeightService
    {
        BWeight Get(string carNo);
        bool UpdateState(string weightId, RowState state);
        bool Save(SyncWeight syncWeight);
        bool doneWeight(BWeight weight,string url);
    }
}
