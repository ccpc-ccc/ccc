using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class VWeightQcMap:ClassMap<VWeightQc>
    {
        public VWeightQcMap() 
        {
            Table("V_WeightQc");
            Id(m => m.WeightId).GeneratedBy.Assigned();
            Map(m => m.CarNo);
            Map(m => m.CompanyId);
            //Map(m => m.CreaterId).Not.Update();
            //Map(m => m.CreateTime).Not.Update();
            Map(m => m.FinishState);
            Map(m => m.FinishTime);
            Map(m => m.NetWeight);
            //Map(m => m.RowState);
            Map(m => m.SuttleWeight);
            Map(m => m.TareWeight);
            //Map(m => m.UpdaterId);
            //Map(m => m.UpdateTime);
            Map(m => m.WeightNo);
            Map(m => m.UnitCharge);
            Map(m => m.RealCharge);

            Map(m => m.Weighter);
            Map(m => m.ReceiverName);
            Map(m => m.MaterialName);
            Map(m => m.DeliveryName);
            Map(m => m.CustomerName);

            Map(m => m.FreightSettleState);
            Map(m => m.PaymentSettleState);
            Map(m => m.SettleState);

            Map(m => m.QcId);
            Map(m => m.BrokenRate);
            Map(m => m.BrownRate);
            Map(m => m.ColorOdor);
            Map(m => m.FattyAcid);
            Map(m => m.HeavyMetal);

            Map(m => m.HeavyMetal);
            Map(m => m.ImperfectGrain);
            Map(m => m.Impurity);
            Map(m => m.Inspector);
            Map(m => m.Judgement);
            Map(m => m.MilledRice);
            Map(m => m.MutualRate);
            Map(m => m.PowderRate);
            Map(m => m.YellowRate);

        }
    }
}
