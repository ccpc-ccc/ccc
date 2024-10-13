using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models {
    /// <summary>
    /// 角色
    /// Author:闫孝感
    /// Date:2014-08-31
    /// </summary>
    public class S_Role : BaseEntity
    {
        public string? RoleName { get; set; }
        public string? Remarks { get; set; }
        public string? Platform { get; set; }
        public string? Permission { get; set; }
        /// <summary>
        /// 包含半选中项目
        /// </summary>
        public string? Permission2 { get; set; }
        public string? CompanyId { get; set; }
    }
}
