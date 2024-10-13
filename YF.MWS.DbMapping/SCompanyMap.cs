using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SCompanyMap : ClassMap<SCompany>
    {
        public SCompanyMap()
        {
            Table("S_Company");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CompanyName);
            Map(m => m.CompanyCode);
            Map(m => m.ParentId);
            Map(m => m.Address);
            Map(m => m.Contracter);
            Map(m => m.Email);
            Map(m => m.Mobile);
            Map(m => m.Tel);
            Map(m => m.Fax);
            Map(m => m.LogoUrl);
            Map(m => m.Logo);
            Map(m => m.StartLogo);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.UpdateTime);
            Map(m => m.Infor);
            Map(m => m.UpdaterId);
            Map(m => m.RowState);
            Map(m => m.ChargeType);
            Map(m => m.OverNumber);
            Map(m => m.OverTime);

        }
    }
}
