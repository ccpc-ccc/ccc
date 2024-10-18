using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SWeightViewDtlMap:ClassMap<SWeightViewDtl>
    {
        public SWeightViewDtlMap() 
        {
            Table("S_WeightViewDtl");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.ActionName);
            Map(m => m.AttributeId);
            Map(m => m.AutoCalcNo);
            Map(m => m.Caption);
            Map(m => m.ControlId);
            Map(m => m.ControlName);
            Map(m => m.ControlType);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.DecimalDigits);
            Map(m => m.ErrorText);
            Map(m => m.Expression);
            Map(m => m.FieldName);
            Map(m => m.FullName);
            Map(m => m.IsRequired);
            Map(m => m.Readonly);
            Map(m => m.OrderNo);
            Map(m => m.AutoSaveState).CustomType(typeof(BoolValueType));
            Map(m => m.StayState).CustomType(typeof(BoolValueType));
            Map(m => m.RowState);
            Map(m => m.SyncState);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
            Map(m => m.ViewId); 
            Map(m => m.Show1); 
            Map(m => m.Show2); 
            Map(m => m.Show3); 
            Map(m => m.t1); 
            Map(m => m.ColIndex); 
            Map(m => m.RowIndex); 
        }
    }
}
