using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Models
{
    /// <summary>
    /// 公司信息：指的是使用该称重系统的公司
    /// Author:闫孝感
    /// Date:2024-08-31
    /// </summary>
    public class S_Company : BaseEntity
    {
        /// <summary>
        /// 支付开启状态
        /// </summary>
        public string? ParentId { get; set; }

        public string? CompanyName { get; set; }
        public string? CompanyCode { get; set; }
        public string? LogoUrl { get; set; }
        public byte[]? Logo { get; set; }
        public string? Contracter { get; set; }
        public string? Address { get; set; }
        public string? Tel { get; set; }
        public string? Fax { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public byte[]? StartLogo { get; set; }
        public string? Infor { get; set; }
        [Navigate(NavigateType.OneToOne, nameof(ParentId))]
        public S_Company? Parent { get; set; }
    }
}
