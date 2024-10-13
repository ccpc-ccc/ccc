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
        DataTable Export(WeightQueryCondition query);
        List<BWeight> GetList(int year);
        WeightQueryResult GetTopList(TopWeightQuery query);
        List<BWeight> GetNotQcList(int year);
        DataTable GetFinanceList(List<string> lstWeightId,string viewId);
        DataTable GetFinanceList(DateTime dtStart, DateTime dtEnd, FinaSettlement settleState,DateType type);
        DataTable GetQcList(DateTime dtStart, DateTime dtEnd, int qcState);
        WeightQueryResult Query(WeightQueryCondition qc, bool startPage);
        DataTable GetTopListTable(TopWeightQuery query);
    }
}
