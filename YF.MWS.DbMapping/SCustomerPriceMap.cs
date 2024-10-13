using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SCustomerPriceMap : ClassMap<SCustomerPrice>
    {
        public SCustomerPriceMap()
        {
            Table("S_CustomerPrice");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.CustomerId);
            Map(m => m.CustomerName);
            Map(m => m.MaterialId);
            Map(m => m.MaterialName);
            Map(m => m.Price);
            Map(m => m.RowState);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
        }
    }
}
