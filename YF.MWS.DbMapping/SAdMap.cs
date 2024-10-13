using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SAdMap : ClassMap<SAd>
    {
        public SAdMap()
        {
            Table("S_Ad");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.AdContent).CustomType("StringClob");
            Map(m => m.AdTitle);
            Map(m => m.AdUrl);
            Map(m => m.CompanyId);
            Map(m => m.CreaterId);
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.Hours);
            Map(m => m.RowState);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
            Map(m => m.Weeks);
        }
    }
}
