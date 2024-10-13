using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BCardPresetMap:ClassMap<BCardPreset>
    {
        public BCardPresetMap() 
        {
            Table("B_CardPreset");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CardId);
            Map(m => m.ControlId);
            Map(m => m.CreaterId);
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.CvDetailId);
            Map(m => m.PresetValue);
            Map(m => m.RowState);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
        }
    }
}
