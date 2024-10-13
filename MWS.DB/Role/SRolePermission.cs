using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    /// <summary>
    /// 角色授权
    /// Author:仇军
    /// Date:2014-08-31
    /// </summary>
    public class SRolePermission : BaseEntity
    {
        public virtual string RoleId { get; set; }
        public virtual string ModuleId { get; set; }
    }
}
