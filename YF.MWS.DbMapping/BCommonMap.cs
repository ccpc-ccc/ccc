using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BCommonMap : ClassMap<BCommon>
    {
        public BCommonMap()
        {
            Table("B_Common");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.Caption);
            Map(m => m.Value);
        }
    }
}













