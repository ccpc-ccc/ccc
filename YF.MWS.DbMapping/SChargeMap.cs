using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SChargeMap : ClassMap<SCharge>
    {
        public SChargeMap()
        {
            Table("S_Charge");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.Charge);
            Map(m => m.MaxWeight);
            Map(m => m.MinWeight);
            Map(m => m.Operator);
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.UpdateTime);
            Map(m => m.RowState);
        }
    }
}
