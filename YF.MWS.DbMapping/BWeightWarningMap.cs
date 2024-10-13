using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BWeightWarningMap : ClassMap<BWeightWarning>
    {
        public BWeightWarningMap()
        {
            Table("B_WeightWarning");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.WeightId);
            Map(m => m.WarningType);
            Map(m => m.WarnContent);
            Map(m => m.WarnTime);
            Map(m => m.ChargerId);
            Map(m => m.UserId);
            Map(m => m.ResolveState);
            Map(m => m.ResolveTime);
            Map(m => m.Solution);
            Map(m => m.CreaterId);
            Map(m => m.UpdaterId);
            Map(m => m.CreateTime);
            Map(m => m.UpdateTime);
            Map(m => m.RowState);
        }
    }
}
