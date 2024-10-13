using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SWarehMap : ClassMap<SWareh>
    {
        public SWarehMap()
        {
            Table("S_Wareh");
            Id(m => m.Id);
            Map(m => m.Location);
            Map(m => m.CreaterId);
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.RowState);
            Map(m => m.WarehCode);
            Map(m => m.WarehName);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
        }
    }
}
