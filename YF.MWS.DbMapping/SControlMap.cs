using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SControlMap:ClassMap<SControl>
    {
        public SControlMap() 
        {
            Table("S_Control");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.ActionName);
            Map(m => m.AutoCalcNo);
            Map(m => m.Caption);
            Map(m => m.ControlName);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.ErrorText);
            Map(m => m.Expression);
            Map(m => m.FieldName);
            Map(m => m.FullName); 
            Map(m => m.IsRequired);
            Map(m => m.RowState);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime); 
            Map(m => m.IsViewShow); 
        }
    }
}
