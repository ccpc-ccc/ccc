using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    /// <summary>
    /// 收费配置
    /// </summary>
    public class SCharge : BaseEntity
    {
        public virtual string Operator { get; set; }
        public virtual decimal MinWeight { get; set; }
        public virtual decimal MaxWeight { get; set; }
        public virtual decimal Charge { get; set; }
    }
}
