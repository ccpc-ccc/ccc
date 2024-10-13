using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SModuleMap : ClassMap<SModule>
    {
        public SModuleMap()
        {
            Table("S_Module");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.UpdateTime); 
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.Platform);
            Map(m => m.ActionName);
            Map(m => m.UpdaterId);
            Map(m => m.RowState);
            Map(m => m.ParentId);
            Map(m => m.ModuleName);
            Map(m => m.FullName);
            Map(m => m.ShortName);
            Map(m => m.ModuleType);
            Map(m => m.LinkUrl);
            Map(m => m.OrderNo);
            Map(m => m.Icon);
            Map(m => m.SuperTipContent);
            Map(m => m.SuperTipState);
        }
    }
}
