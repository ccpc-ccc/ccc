using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models {
    /// <summary>
    /// 角色授权
    /// Author:闫孝感
    /// Date:2024-08-31
    /// </summary>
    public class S_RolePermission : BaseEntity
    {
        public string? RoleId { get; set; }
        public string? ModuleId { get; set; }
    }
}
