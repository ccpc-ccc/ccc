using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Dto;
using YF.MWS.Metadata.Query;

namespace YF.MWS.Client.DataService.Interface
{
    public interface IPlanService
    {
        bool BatchRefresh(string planId);
        bool Delete(string planId);
        BPlan Get(string planId);
        BPlan Get(string customerId, PlanStateType stateType);
        BPlan GetByCar(string carNo, PlanStateType stateType);
        List<BPlan> GetList();
        List<BPlan> GetList(List<string> planNos);
        bool IsExistsPlanByCarNo(string strCarNo);
        PageList<PlanFull> GetList(PlanQuery query);
        bool Update(BWeight weight);
        bool UpdateState(string planId, PlanStateType type);
        bool Save(BPlan plan);
    }
}
