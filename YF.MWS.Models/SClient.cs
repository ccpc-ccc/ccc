using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using SqlSugar;

namespace YF.MWS.Models
{
    /// <summary>
    /// 客户端信息
    /// Author:仇军
    /// Date:2014-08-31
    /// </summary>
    public class S_Client:BaseEntity
    {
        public string? ClientName { get; set; }
        public string? ViewId { get; set; }
        /// <summary>
        /// 终端编号
        /// </summary>
        public string? MachineCode { get; set; }
        public string? AuthCode { get; set; }
        /// <summary>
        /// 链接码
        /// </summary>
        public string? RegisterCode { get; set; }
        public string? Address { get; set; }
        public string? RegisterType { get; set; }
        public string? CompanyId { get; set; }
        public string? DeptId { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime? RegisterDate { get; set; }

        /// <summary>
        /// 当前日期密文
        /// </summary>
        public string? CurrentDate { get; set; }

        /// <summary>
        /// 过期日期密文
        /// </summary>
        public string? ExpireCode { get; set; }

        /// <summary>
        /// 使用总次数密文
        /// </summary>
        /// 
        public string? TotalTimes { get; set; }

        /// <summary>
        /// 已用次数密文(每天累加一次)
        /// </summary>
        /// 
        public string? UsedTimes { get; set; }

        /// <summary>
        /// 注册码过期日期
        /// </summary>
        public DateTime? ExpireDate { get; set; }

        /// <summary>
        /// 验证授权文件
        /// </summary>
        public string? VerifyCode { get; set; }
        public int? ActiveState { get; set; }
        /// <summary>
        /// 远程状态
        /// </summary>
        /// 
        public string? RemoteState { get; set; }
        [Navigate(NavigateType.OneToOne, nameof(CompanyId))]
        public S_Company? Company { get; set; }
    }
}
