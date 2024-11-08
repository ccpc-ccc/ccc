using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata.Enum;
using YF.MWS.Db;
using System.Data;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Dto;
using YF.MWS.Metadata.Cfg;

namespace YF.MWS.Client.DataService.Interface
{
    public interface IWeightQueryService
    {
        WeightQueryResult GetTopList(TopWeightQuery query);
        WeightQueryResult Query(WeightQueryCondition qc, bool startPage);
        DataTable GetTopListTable(TopWeightQuery query);
    }
}
