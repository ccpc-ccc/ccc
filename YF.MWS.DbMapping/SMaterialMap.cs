using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SMaterialMap : ClassMap<SMaterial>
    {
        public SMaterialMap()
        {
            Table("S_Material");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.MaterialName);
            Map(m => m.PYMaterialName);
            Map(m => m.MaterialCode);
            Map(m => m.MaterialType);
            Map(m => m.SpecName);
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.UpdateTime);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.UpdaterId);
            Map(m => m.RowState);
            Map(m => m.State);
            Map(m => m.Unit);
            Map(m => m.UnitPrice);
            Map(m => m.Remark);
            Map(m => m.CompanyId);
            Map(m => m.Quantity);
        } 
    }
}
