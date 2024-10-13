using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BPayDetailMap : ClassMap<BPayDetail>
    {
        public BPayDetailMap()
        {
            Table("B_PayDetail");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.PayId);
            Map(m => m.CustomerId);
            Map(m => m.WeightId);
        }
    }
}
