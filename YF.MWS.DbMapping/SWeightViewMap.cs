using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SWeightViewMap:ClassMap<SWeightView>
    {
        public SWeightViewMap() 
        {
            Table("S_WeightView");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.ColumnsCount);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.IsDefault);
            Map(m => m.RowState);
            Map(m => m.SubjectId);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
            Map(m => m.ViewName);
            Map(m => m.ViewType);
        }
    }
}
