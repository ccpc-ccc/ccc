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
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.AdditionalTime);
            Map(m => m.WeightNo);
            Map(m => m.CompanyId);
            Map(m => m.ViewId);
            Map(m => m.DeptId);
            Map(m => m.MachineCode);
            Map(m => m.TareMachineCode);
            Map(m => m.SupplierId);
            Map(m => m.CustomerId);
            Map(m => m.DriverName);
            Map(m => m.DeliveryId);
            Map(m => m.ReceiverId);
            Map(m => m.TransferId);
            Map(m => m.CarId);
            Map(m => m.CardNo);
            Map(m => m.CarNo);
            Map(m => m.QcNo);
            Map(m => m.WarehId);
            Map(m => m.MaterialId);
            Map(m => m.MaterialModel);
            Map(m => m.MaterialAmount);
            Map(m => m.ManufacturerId);
            Map(m => m.WarehBizType);
            Map(m => m.UnitPrice);
            Map(m => m.MeasureType);
            Map(m => m.MeasureUnit);
            Map(m => m.ImpurityMeaType);
            Map(m => m.ImpurityWeight);
            Map(m => m.TareWeight);
            Map(m => m.GrossWeight);
            Map(m => m.SuttleWeight);
            Map(m => m.OrderSource);
            Map(m => m.AxleCount);
            Map(m => m.MaxWeight);
            Map(m => m.OverWeight);
            Map(m => m.OverWeightState);
            Map(m => m.NetWeight);
            Map(m => m.CustomerBalance);
            Map(m => m.WaybillNo);
            Map(m => m.UnitCharge);
            Map(m => m.CustomCharge);
            Map(m => m.RegularCharge);
            Map(m => m.WeighterId);
            Map(m => m.WeighterName);
            Map(m => m.Remark);
            Map(m => m.WeightProcess);
            Map(m => m.FinishState);
            Map(m => m.PrintCount);
            Map(m => m.FinishTime);
            Map(m => m.RealCharge);
            Map(m => m.ChargeType);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.RowState);
            Map(m => m.CreateTime);
            Map(m => m.TareTime);
            Map(m => m.GrossTime);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
            Map(m => m.SyncState);
            Map(m => m.RefId);
            Map(m => m.PayType);
            Map(m => m.UnitMoney);
            Map(m => m.d1);
            Map(m => m.d2);
            Map(m => m.d3);
            Map(m => m.t1);
            Map(m => m.t2);
            Map(m => m.t3);
            Map(m => m.t4);
            Map(m => m.t5);
            Map(m => m.t6);
            Map(m => m.t7);
            Map(m => m.t8);
            Map(m => m.t9);
            Map(m => m.t10);
            Map(m => m.ServiceId);
        }
    }
}
