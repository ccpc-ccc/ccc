using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BPlanMap : ClassMap<BPlan>
    {
        public BPlanMap()
        {
            Table("B_Plan");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CompanyId);
            Map(m => m.CustomerId);
            Map(m => m.EndTime);
            Map(m => m.PlanType).CustomType(typeof(PlanType));
            Map(m => m.CarNo);
            Map(m => m.CreaterId);
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.FinishedCarCount);
            Map(m => m.FinishedWeight);
            Map(m => m.MaterialId);
            Map(m => m.DeliveryId);
            Map(m => m.ReceiverId);
            Map(m => m.PlanNo);
            Map(m => m.PlanState).CustomType(typeof(PlanStateType)).Not.Update();
            Map(m => m.LimitType).CustomType(typeof(PlanLimitType));
            Map(m => m.WarehBiz).CustomType(typeof(WarehBizType));
            Map(m => m.PlanWeight);
            Map(m => m.PlanCarCount);
            Map(m => m.DeptId);
            Map(m => m.StartTime);
            Map(m => m.RowState);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
            Map(m => m.Remark);
            Map(m => m.SyncState).CustomType(typeof(SyncState));
        }
    }
}
