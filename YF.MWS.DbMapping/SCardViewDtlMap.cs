using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SCardViewDtlMap:ClassMap<SCardViewDtl>
    {
        public SCardViewDtlMap() 
        {
            Table("S_CardViewDtl");
            Id(m => m.Id).GeneratedBy.Assigned(); 
            Map(m => m.ControlId);
            Map(m => m.DetailId);
            Map(m => m.CreaterId);
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.OrderNo);
            Map(m => m.RowState); 
            Map(m => m.ViewId);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime); 
        }
    }
}
