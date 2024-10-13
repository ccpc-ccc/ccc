using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SLocationMap : ClassMap<SLocation>
    {
        public SLocationMap()
        {
            Table("S_Location");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.LocationCode);
            Map(m => m.LocationName);
            Map(m => m.CompanyId);
            Map(m => m.LocationType).CustomType(typeof(LocationType));
            Map(m => m.ValidateInput).CustomType(typeof(ValidateInputMode));
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.RowState);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
        }
    }
}
