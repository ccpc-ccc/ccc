using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 远程登录用户相关的配置信息
    /// </summary>
    public class RemoteLoginCfg
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

    }
}
