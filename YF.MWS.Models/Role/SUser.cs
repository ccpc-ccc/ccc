using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models {
    /// <summary>
    /// 用户信息
    /// Author:闫孝感
    /// Date:2024-08-31
    /// </summary>
    public class S_User : BaseEntity
    {
        /// <summary>
        /// 所属公司
        /// </summary>
        public string? CompanyId { get; set; }
        public string? DeptId { get; set; }
        public string? MachineCode { get; set; }
        public string? CustomerId { get; set; }
        public string? UserName { get; set; }
        public string? UserPwd { get; set; }
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public string? ContactPhone { get; set; }
        public string? MobilePhone { get; set; }
        public string? Email { get; set; }
        /// <summary>
        /// 激活状态 0、未激活 1、已激活
        /// </summary>
        public int? Active { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public int? IsAdmin { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        public string? RoleId { get; set; }
        [Navigate(NavigateType.OneToOne, nameof(RoleId))]
        public S_Role? Role { get; set; }
        public string? Platform { get; set; }
        /// <summary>
        /// 登录类别：
        /// 1:WEB 登录
        /// 2:手机登录
        /// 3:两个平台都可以登录
        /// </summary>
        public int? LoginType { get; set; }
        public int? SyncState { get; set; }
        public string? UserType { get; set; }
        public string? ClientId { get; set; }
        public string? Powers { get; set; }
        /// <summary>
        /// 包含半选中项目
        /// </summary>
        public string? Permission2 { get; set; }
        public string? Permission { get; set; }
        [Navigate(NavigateType.OneToOne, nameof(CompanyId))]
        public S_Company? Company { get; set; }
    }
}
