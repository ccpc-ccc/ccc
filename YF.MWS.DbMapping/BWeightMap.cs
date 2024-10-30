using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BWeightMap : ClassMap<BWeight>
    {
        public BWeightMap()
        {
            Table("B_Weight");
            Id(m => m.WarehId).GeneratedBy.Assigned();
            Map(m => m.AdditionalTime);
            Map(m => m.WeightNo);
            Map(m => m.DriverName);
            Map(m => m.CardNo);
            Map(m => m.QcNo);
            Map(m => m.MaterialId);
            Map(m => m.MaterialModel);
            Map(m => m.MaterialAmount);
            Map(m => m.ManufacturerId);
            Map(m => m.WarehBizType);
            Map(m => m.UnitPrice);
            Map(m => m.MeasureType);
            Map(m => m.MeasureUnit);
            Map(m => m.ImpurityMeaType);
            Map(m => m.OrderSource);
            Map(m => m.AxleCount);
            Map(m => m.CustomerBalance);
            Map(m => m.WaybillNo);
            Map(m => m.UnitCharge);
            Map(m => m.CustomCharge);
            Map(m => m.RegularCharge);
            Map(m => m.WeightProcess);
            Map(m => m.FinishState);
            Map(m => m.PrintCount);
            Map(m => m.FinishTime);
            Map(m => m.RealCharge);
            Map(m => m.ChargeType);
            Map(m => m.TareTime);
            Map(m => m.SyncState);
        }
    }
}
