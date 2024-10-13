using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SClientMap:ClassMap<SClient>
    {
        public SClientMap() 
        {
            Table("S_Client");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.ActiveState);
            Map(m => m.ClientName).Not.Update();
            Map(m => m.CompanyId);
            Map(m => m.DeptId);
            Map(m => m.ViewId);
            Map(m => m.ExpireDate);
            Map(m => m.UsedTimes);
            Map(m => m.TotalTimes);
            Map(m => m.CurrentDate);
            Map(m => m.ExpireCode);
            Map(m => m.AuthCode);
            Map(m => m.MachineCode);
            Map(m => m.RegisterType);
            Map(m => m.RegisterCode);
            Map(m => m.RegisterDate).Not.Update();
            Map(m => m.VerifyCode);
            Map(m => m.RowState);
            Map(m => m.CreaterId);
            Map(m => m.CreateTime);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
        }
    }
}
