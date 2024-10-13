using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BWeightDetailMap:ClassMap<BWeightDetail>
    {
        public BWeightDetailMap() 
        {
            Table("B_WeightDetail");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.AccessState);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.GrossWeight);
            Map(m => m.OrderSource);
            Map(m => m.WeightType);
            Map(m => m.RowState);
            Map(m => m.SuttleWeight);
            Map(m => m.TareWeight);
            Map(m => m.UpdaterId);
            Map(m => m.WeighterId).Not.Update();
            Map(m => m.WeighterName).Not.Update();
            Map(m => m.WeightId);
            Map(m => m.WeightNo);
            Map(m => m.WeightTime);
        }
    }
}
