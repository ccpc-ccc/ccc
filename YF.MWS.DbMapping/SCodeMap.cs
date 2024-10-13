using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    /// <summary>
    /// 系统编码表映射关系
    /// Author:仇军
    /// Date:2014-08-31
    /// </summary>
    public class SCodeMap : ClassMap<SCode>
    {
        public SCodeMap()
        {
            Table("S_Code");
            Id(m => m.Id).GeneratedBy.Assigned();
            Map(m => m.ParentId);
            Map(m => m.ItemCode);
            Map(m => m.ItemCaption);
            Map(m => m.SystemFlag);
            Map(m => m.OrderNo);
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.UpdateTime);
            Map(m => m.RowState);
            Map(m => m.ItemValue);
        }
    }
}
