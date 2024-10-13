using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    /// <summary>
    /// 用户信息
    /// Author:闫孝感
    /// Date:2024-08-31
    /// </summary>
    public class SUser : BaseEntity
    {
        /// <summary>
        /// 所属公司
        /// </summary>
        public virtual string CompanyId { get; set; }
        public virtual string DeptId { get; set; }
        public virtual string MachineCode { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual string UserName { get; set; }
        public virtual string UserPwd { get; set; }
        public virtual string FullName { get; set; }
        public virtual string Gender { get; set; }
        public virtual string ContactPhone { get; set; }
        public virtual string MobilePhone { get; set; }
        public virtual string Email { get; set; }
        /// <summary>
        /// 激活状态 0、未激活 1、已激活
        /// </summary>
        public virtual int Active { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public virtual int IsAdmin { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        public virtual string RoleId { get; set; }
        public virtual string Platform { get; set; }
        /// <summary>
        /// 登录类别：
        /// 1:WEB 登录
        /// 2:手机登录
        /// 3:两个平台都可以登录
        /// </summary>
        public virtual int LoginType { get; set; }
        public virtual int SyncState { get; set; }
        public virtual string UserType { get; set; }
        public virtual string ClientId { get; set; }
        public virtual string Powers { get; set; }
    }
}
