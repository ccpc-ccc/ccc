using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BWeightQcMap:ClassMap<BWeightQc>
    {
        public BWeightQcMap() 
        {
            Table("B_WeightQc");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.QcNo);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.BrokenRate);
            Map(m => m.BrownRate);
            Map(m => m.RowState);
            Map(m => m.CarId);
            Map(m => m.CarNo);
            Map(m => m.UpdaterId);
            Map(m => m.ColorOdor);
            Map(m => m.WeightId);
            Map(m => m.WeightNo);
            Map(m => m.ReceiverId);
            Map(m => m.DeliveryId);
            Map(m => m.FattyAcid);
            Map(m => m.HeavyMetal);
            Map(m => m.ImperfectGrain);
            Map(m => m.Impurity);
            Map(m => m.Inspector);
            Map(m => m.Judgement);
            Map(m => m.MaterialId);
            Map(m => m.MeasureType);
            Map(m => m.MilledRice);
            Map(m => m.MutualRate);
            Map(m => m.PowderRate);
            Map(m => m.PrimaryAmount);
            Map(m => m.ProductFlow);
            Map(m => m.Remark);
            Map(m => m.SmallBrokenRate);
            Map(m => m.Water);
            Map(m => m.YellowRate);
            Map(m => m.PackageType);
            Map(m => m.QcDate);
        }
    }
}
