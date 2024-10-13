using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 当前登录用户相关的配置信息
    /// </summary>
    public class LoginCfg
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 是否记住密码
        /// </summary>
        public bool RememberPwd { get; set; }
        /// <summary>
        /// 登录界面显示的用户名
        /// </summary>
        public List<string> UserNames { get; set; }
        /// <summary>
        /// 当前系统的皮肤名称
        /// </summary>
        public string SkinName { get; set; }
        public LoginCfg() {
            UserNames = new List<string>();
        }

    }
}
