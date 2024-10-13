using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SUserRoleMap : ClassMap<SUserRole>
    {
        public SUserRoleMap()
        {
            Table("S_UserRole");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.UpdateTime);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.UpdaterId);
            Map(m => m.RowState);
            Map(m => m.RoleId);
            Map(m => m.UserId);
        }
    }
}
