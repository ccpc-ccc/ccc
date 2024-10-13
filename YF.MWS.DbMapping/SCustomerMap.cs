using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SCustomerMap : ClassMap<SCustomer>
    {
        public SCustomerMap()
        {
            Table("S_Customer");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CustomerName);
            Map(m=>m.PYCustomerName);
            Map(m => m.CustomerType);
            Map(m => m.CompanyId);
            Map(m => m.MachineCode);
            Map(m => m.Contracter);
            Map(m => m.RechargeAmount);
            Map(m => m.PayAmount);
            Map(m => m.BalanceAmount);
            Map(m => m.MinBalanceAmount);
            Map(m => m.Addr);
            Map(m => m.Account);
            Map(m => m.Bank);
            Map(m => m.Email);
            Map(m => m.Mobile);
            Map(m => m.Tel);
            Map(m => m.Fax);
            Map(m => m.LogoUrl);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.UpdateTime);
            Map(m => m.UpdaterId);
            Map(m => m.RowState);
            Map(m => m.Remark);
            Map(m => m.CustomerCode);
            Map(m => m.SyncState);
            Map(m => m.IdCard);
        }
    }
}
