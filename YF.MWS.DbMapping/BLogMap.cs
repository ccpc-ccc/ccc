using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BLogMap : ClassMap<BLog>
    {
        public BLogMap()
        {
            Table("B_Log");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.RecId);
            Map(m => m.RecNo);
            Map(m => m.TableName);
            Map(m => m.FieldName);
            Map(m => m.ActionType);
            Map(m => m.OldValue);
            Map(m => m.NewValue);
            Map(m => m.LogDesc);
            Map(m => m.UserId);
            Map(m => m.LogTime);
            Map(m => m.CreaterId);
            Map(m => m.UpdaterId);
            Map(m => m.CreateTime);
            Map(m => m.UpdateTime);
            Map(m => m.RowState);
        }
    }
}













