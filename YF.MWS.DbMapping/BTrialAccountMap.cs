using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BTrialAccountMap:ClassMap<BTrialAccount>
    {
        public BTrialAccountMap() 
        {
            Table("B_TrialAccount");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.Addr);
            Map(m => m.CorpName);
            Map(m => m.Email);
            Map(m => m.FullName);
            Map(m => m.Mobile);
            Map(m => m.RegisiterTime);
            Map(m => m.Tel);
            Map(m => m.VersionCode);
        }
    }
}
