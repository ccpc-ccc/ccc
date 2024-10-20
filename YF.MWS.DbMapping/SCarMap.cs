using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SCarMap:ClassMap<SCar>
    {
        public SCarMap() 
        {
            Table("S_Car");
            Id(m => m.Id).GeneratedBy.Assigned(); 
            Map(m => m.CarNo);
            Map(m => m.CarType);
            Map(m => m.CreaterId);
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.DriverName);
            Map(m => m.LimitWeight);
            Map(m => m.RowState); 
            Map(m => m.TareWeight);
            Map(m => m.GrossWeight);
            Map(m => m.Unit);
            Map(m => m.SupplierId);
            Map(m => m.DeliveryId);
            Map(m => m.ReceiverId);
            Map(m => m.TransferId);
            Map(m => m.WarehId);
            Map(m => m.ManufacturerId);
            Map(m => m.MaterialId);
            Map(m => m.Balance);
            Map(m => m.Tell);
            Map(m => m.WorkId);
            Map(m => m.LimitWeight2);
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
            Map(m => m.LimitState);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime); 
        }
    }
}
