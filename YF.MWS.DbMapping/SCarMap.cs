using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SCarMap:ClassMap<SCar>
    {
        public SCarMap() 
        {
            Table("S_Car");
            Id(m => m.Id).GeneratedBy.Assigned(); 
            Map(m => m.CarNo);
            Map(m => m.CarType);
            Map(m => m.CreaterId);
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.DriverName);
            Map(m => m.LimitWeight);
            Map(m => m.RowState); 
            Map(m => m.TareWeight);
            Map(m => m.Unit);
            Map(m => m.LimitState);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime); 
        }
    }
}
