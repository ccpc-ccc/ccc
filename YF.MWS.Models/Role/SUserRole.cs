using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models {
    /// <summary>
    /// 用户权限
    /// Author:闫孝感
    /// Date:2024-08-31
    /// </summary>
    public class S_UserRole : BaseEntity
    {
        public string? UserId { get; set; }
        public string? RoleId { get; set; }
    }
}
