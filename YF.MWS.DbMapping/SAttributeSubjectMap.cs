using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SAttributeSubjectMap:ClassMap<SAttributeSubject>
    {
        public SAttributeSubjectMap() 
        {
            Table("S_AttributeSubject");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.RowState);
            Map(m => m.SyncState);
            Map(m => m.SubjectName);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
        }
    }
}
