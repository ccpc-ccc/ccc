using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 物质查询条件
    /// </summary>
    public class MaterialQueryCondition
    {
        public virtual string Type { get; set; }

        public virtual string Name { get; set; }

        //public virtual string SpecName { get; set; }

        //public virtual string Unit { get; set; }
    }
}
