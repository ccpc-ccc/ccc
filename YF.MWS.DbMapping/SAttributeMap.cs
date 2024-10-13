using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SAttributeMap:ClassMap<SAttribute>
    {
        public SAttributeMap() 
        {
            Table("S_Attribute");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.AttributeName);
            Map(m => m.AutoCalcNo);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.DataType);
            Map(m => m.Expression);
            Map(m => m.FieldName);
            Map(m => m.FullName);
            Map(m => m.RowState);
            Map(m => m.SubjectId);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
        }
    }
}
