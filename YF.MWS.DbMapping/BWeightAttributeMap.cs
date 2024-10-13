using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BWeightAttributeMap:ClassMap<BWeightAttribute>
    {
        public BWeightAttributeMap() 
        {
            Table("B_WeightAttribute");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.AttributeId);
            Map(m => m.AttributeName);
            Map(m => m.AttributeValue);
            Map(m => m.AutoCalcNo);
            Map(m => m.CreaterId);
            Map(m => m.CreateTime);
            Map(m => m.Expression);
            Map(m => m.FieldName);
            Map(m => m.RowState);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
            Map(m => m.WeightId); 
        }
    }
}
