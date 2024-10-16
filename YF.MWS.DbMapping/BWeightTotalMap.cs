using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BWeightTotalMap : ClassMap<BWeightTotal>
    {
        public BWeightTotalMap()
        {
            Table("B_WeightTotal");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.Date);
            Map(m => m.MaterialId);
            Map(m => m.Weight);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.RowState);
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
            Map(m => m.CompanyId);
        }
    }
}
