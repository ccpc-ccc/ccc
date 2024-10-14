using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Metadata;
using Newtonsoft.Json;

namespace YF.MWS.Db
{
    /// <summary>
    /// 客户端信息
    /// Author:仇军
    /// Date:2014-08-31
    /// </summary>
    public class SClient:BaseEntity
    {
        public virtual string ClientName { get; set; }
        public virtual string ViewId { get; set; }
        /// <summary>
        /// 机器码
        /// </summary>
        public virtual string MachineCode { get; set; }
        /// <summary>
        /// 版本权限
        /// </summary>
        public virtual string AuthCode { get; set; }
        /// <summary>
        /// 注册码
        /// </summary>
        public virtual string RegisterCode { get; set; }
        /// <summary>
        /// 注册方式 none 未注册  file 文件注册 dong 加密狗注册
        /// </summary>
        public virtual string RegisterType { get; set; }
        public virtual string CompanyId { get; set; }
        public virtual string DeptId { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        public virtual DateTime RegisterDate { get; set; }

        /// <summary>
        /// 第一次使用时的密文
        /// </summary>
        public virtual string CurrentDate { get; set; }

        /// <summary>
        /// 过期日期密文
        /// </summary>
        public virtual string ExpireCode { get; set; }

        /// <summary>
        /// 使用总次数密文
        /// </summary>
        /// 
        [JsonIgnore]
        public virtual string TotalTimes { get; set; }

        /// <summary>
        /// 已用次数密文(每天累加一次)
        /// </summary>
        /// 
        [JsonIgnore]
        public virtual string UsedTimes { get; set; }

        /// <summary>
        /// 注册码过期日期
        /// </summary>
        public virtual DateTime ExpireDate { get; set; }

        /// <summary>
        /// 验证授权文件
        /// </summary>
        public virtual string VerifyCode { get; set; }
        public virtual int ActiveState { get; set; }
        /// <summary>
        /// 远程状态
        /// </summary>
        /// 
        [Field(IsSqliteIgnore=true)]
        public virtual string RemoteState { get; set; }
    }
}
