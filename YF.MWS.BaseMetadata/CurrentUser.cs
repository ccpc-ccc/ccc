using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Mode;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 当前系统登录用户
    /// Author:仇军
    /// Date:2014-10-07
    /// </summary>
    public class CurrentUser : Singleton<CurrentUser>
    {
        public string Id { get; set; }
        /// <summary>
        /// 当前客户端Id
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// 当前客户端名称
        /// </summary>
        public string ClientName { get; set; }
        public string DeptId { get; set; }
        public string CustomerId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string UserGroup { get; set; }
        public UserType UserType { get; set; }
        public string ThemeName { get; set; }
        /// <summary>
        /// 远程服务器Url
        /// </summary>
        public string ServerUrl { get; set; }
        /// <summary>
        /// 登录服务器凭证
        /// </summary>
        public string ServerToken { get; set; }
        public int FontSize { get; set; }
        public string FontFamily { get; set; } 
        /// <summary>
        /// 是否系统管理员
        /// </summary>
        public bool IsAdministrator { get; set; }
        /// <summary>
        /// 当前用户所属公司及下属公司
        /// </summary>
        public string[] CompanyIds { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        public string CompanyId { get; set; }

        #region Remote Info
        /// <summary>
        /// Company ID
        /// </summary>
        public string RemoteCompanyId { get; set; }
        public string RemoteViewId { get; set; }
        public bool HasLoginedServer { get; set; }
        public UserType RemoteUserType { get; set; }
        public bool RemoteIsAdmin { get; set; }
        /// <summary>
        /// 权限列表
        /// </summary>
        public string[] Powers { get; set; }
        #endregion
    }
}
