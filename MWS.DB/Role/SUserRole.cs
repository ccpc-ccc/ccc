using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    /// <summary>
    /// 用户权限
    /// Author:闫孝感
    /// Date:2024-08-31
    /// </summary>
    public class SUserRole : BaseEntity
    {
        public virtual string UserId { get; set; }
        public virtual string RoleId { get; set; }
    }
}
