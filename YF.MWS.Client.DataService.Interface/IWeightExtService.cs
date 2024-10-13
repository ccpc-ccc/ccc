using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;

namespace YF.MWS.Client.DataService.Interface
{
    public interface IWeightExtService
    {
        DataTable GetAddList(DateTime dtStart, DateTime dtEnd, OrderSource source,string viewId);
        DataSet GetMeasureSearch(string viewId, string condition, string conditionTareTime, string conditionGrossTime, List<QueryCondition> lstExtendCondition);
        List<BWeightAttribute> GetAttributeList(string weightId);
        BWeightExt Get(string weightId);
        bool Save(BWeightExt weightExt);
    }
}
