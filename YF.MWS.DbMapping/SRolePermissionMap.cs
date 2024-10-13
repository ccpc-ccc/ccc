using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SRolePermissionMap : ClassMap<SRolePermission>
    {
        public SRolePermissionMap()
        {
            Table("S_RolePermission");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.UpdateTime);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.UpdaterId);
            Map(m => m.RowState);
            Map(m => m.ModuleId);
            Map(m => m.RoleId);
        }
    }
}
