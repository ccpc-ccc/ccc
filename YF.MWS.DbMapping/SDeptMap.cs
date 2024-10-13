using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SDeptMap : ClassMap<SDept>
    {
        public SDeptMap()
        {
            Table("S_Dept");
            Id(m => m.Id);
            Map(m => m.ParentId);
            Map(m => m.CompanyId);
            Map(m => m.DeptName);
            Map(m => m.DeptType);
            Map(m => m.DeptCode);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.UpdateTime);
            Map(m => m.UpdaterId);
            Map(m => m.RowState);
        }
    }
}
