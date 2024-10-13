using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BWeightExtMap:ClassMap<BWeightExt>
    {
        public BWeightExtMap() 
        {
            Table("B_WeightExt");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.FreightSettleState);
            Map(m => m.PaymentSettleState);
            Map(m => m.CardNo);
            Map(m => m.SettleNo);
            Map(m => m.RowState);
            Map(m => m.SettleState);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime); 
        }
    }
}
