using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BPayMap : ClassMap<BPay>
    {
        public BPayMap() 
        {
            Table("B_Pay");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.CustomerId);
            Map(m => m.CustomerName);
            Map(m => m.CarNo);
            Map(m=>m.CompanyId);
            Map(m => m.DrawerId);
            Map(m => m.DrawerName);
            Map(m => m.PayAmount);
            Map(m => m.BalanceAmount);
            Map(m => m.PayBizType);
            Map(m => m.PayType);
            Map(m => m.MaterialId);
            Map(m => m.PayNo);
            Map(m => m.RowState);
            Map(m => m.PayTime);
            Map(m => m.RefId);
            Map(m => m.PayState);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime); 
        }
    }
}
