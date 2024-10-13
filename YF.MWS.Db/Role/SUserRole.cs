using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    /// <summary>
    /// 用户权限
    /// Author:仇军
    /// Date:2014-08-31
    /// </summary>
    public class SUserRole : BaseEntity
    {
        public virtual string UserId { get; set; }
        public virtual string RoleId { get; set; }
    }
}
