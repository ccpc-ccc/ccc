using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    /// <summary>
    /// 系统编码实体类
    /// Author:仇军
    /// Date:2014-08-31
    /// </summary>
    public class SCode : BaseEntity
    {
        public virtual string ParentId { get; set; }
        public virtual string ItemCode { get; set; }
        public virtual string ItemCaption { get; set; }
        public virtual string ItemValue { get; set; }
        public virtual int SystemFlag { get; set; }
        public virtual int OrderNo { get; set; }

        public override string ToString()
        {
            return ItemCaption;
        }
    }
}
