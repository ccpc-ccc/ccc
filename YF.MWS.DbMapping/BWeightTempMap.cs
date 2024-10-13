using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BWeightTempMap : ClassMap<BWeightTemp>
    {
        public BWeightTempMap() 
        {
            Table("B_WeightTemp");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CreaterId);
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.RowState);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
            Map(m => m.Weight);
            Map(m => m.WeightTime);
            Map(m => m.WeightNo);
            Map(m => m.CompanyId);
            Map(m => m.MachineCode);
            Map(m => m.Unit);
            Map(m => m.WeighterName);
            Map(m => m.WeighterId);
        }
    }
}
