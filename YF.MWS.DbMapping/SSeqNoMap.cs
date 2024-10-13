using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SSeqNoMap:ClassMap<SSeqNo>
    {
        public SSeqNoMap()
        {
            Table("S_SeqNo");
            Id(m => m.Id);
            Map(m => m.CurrentDate);
            Map(m => m.DateFomart);
            Map(m => m.FixedLen);
            Map(m => m.Prefix);
            Map(m => m.RuningNo);
            Map(m => m.SeqCode);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.UpdateTime);
            Map(m => m.UpdaterId);
            Map(m => m.RowState);
        }
    }
}
