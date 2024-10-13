using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BPlanCardMap:ClassMap<BPlanCard>
    {
        public BPlanCardMap() 
        {
            Table("B_PlanCard");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CardNo);
            Map(m => m.CarNo);
            Map(m => m.CarId);
            Map(m => m.CreaterId);
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.CustomerId);
            Map(m => m.DeliveryId);
            Map(m => m.DriverName);
            Map(m => m.FinishState);
            Map(m => m.MachineCode);
            Map(m => m.MaterialId);
            Map(m => m.MaterialModel); 
            Map(m => m.MeasureType);
            Map(m => m.PlanNo);
            Map(m => m.PlanWeight);
            Map(m => m.TareWeight);
            Map(m => m.ReceiverId); 
            Map(m => m.Remark);
            Map(m => m.RowState);
            Map(m => m.TaskNo); 
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
            Map(m => m.WarehBizType);
            Map(m => m.WarehId);
        }
    }
}
