using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BWeightConfirmMap : ClassMap<BWeightConfirm>
    {
        public BWeightConfirmMap()
        {
            Table("B_WeightConfirm");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CarNo);
            Map(m => m.CardId);
            Map(m => m.CardNo);
            Map(m => m.ClientId);
            Map(m => m.CompanyId);
            Map(m => m.ConfirmTime);
            Map(m => m.WeightNo);
            Map(m => m.GrossWeight);
            Map(m => m.TareWeight);
            Map(m => m.DeductWeight);
            Map(m => m.MaterialId);
            Map(m => m.SyncState).CustomType(typeof(SyncState));
            Map(m => m.FinishState).CustomType(typeof(FinishState));
            Map(m => m.RowState).CustomType(typeof(RowState));
            Map(m => m.UnitType).CustomType(typeof(MeasureUnitType));
            Map(m => m.AuditorId);
            Map(m => m.Remark);
            Map(m => m.CreateTime);
        }
    }
}
