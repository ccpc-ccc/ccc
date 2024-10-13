using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    /// <summary>
    /// 角色
    /// Author:仇军
    /// Date:2014-08-31
    /// </summary>
    public class SRole : BaseEntity
    {
        public virtual string RoleName { get; set; }
        public virtual string Remarks { get; set; }
        public virtual string Platform { get; set; }
        public override string ToString()
        {
            return RoleName;
        }
    }
}
