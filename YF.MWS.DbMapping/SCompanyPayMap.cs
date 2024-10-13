using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SCompanyPayMap : ClassMap<SCompanyPay>
    {
        public SCompanyPayMap()
        {
            Table("S_CompanyPay");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CompanyId);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
            Map(m => m.Quantity);
            Map(m => m.Amount);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();

        }
    }
}
