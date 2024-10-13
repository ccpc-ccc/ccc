using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SUserMap : ClassMap<SUser>
    {
        public SUserMap()
        {
            Table("S_User");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CompanyId);
            Map(m => m.CustomerId);
            Map(m => m.ContactPhone);
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.UpdateTime);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.UpdaterId);
            Map(m => m.RowState);
            Map(m => m.Email);
            Map(m => m.FullName);
            Map(m => m.RoleId);
            Map(m => m.Gender);
            Map(m => m.MobilePhone);
            Map(m => m.IsAdmin);
            Map(m => m.Platform);
            Map(m => m.LoginType);
            Map(m => m.UserName).Not.Update();
            Map(m => m.UserPwd).Not.Update(); 
            Map(m => m.Active);
            Map(m => m.MachineCode);
            Map(m => m.UserType);
            Map(m => m.ClientId);
            Map(m => m.Powers);
        } 
    }
}
