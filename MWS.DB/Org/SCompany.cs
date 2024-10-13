using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.Utility.Metadata;

namespace YF.ECS.Db
{
    /// <summary>
    /// 公司信息：指的是使用该称重系统的公司
    /// Author:仇军
    /// Date:2014-08-31
    /// </summary>
    public class SCompany : BaseEntity
    {
        public virtual string CompanyId { get; set; }
        /// <summary>
        /// 支付开启状态
        /// </summary>
        public virtual PayStateType PayState { get; set; }
        public virtual string ParentId { get; set; }

        public virtual string ParentName { get; set; }
        public virtual string CompanyName { get; set; }
        [Field(IsSqliteIgnore=true)]
        public virtual string CompanyNo { get; set; }
        public virtual string CompanyCode { get; set; }
        public virtual string LogoUrl { get; set; }
        public virtual byte[] Logo { get; set; }
        public virtual string Contracter { get; set; }
        public virtual string Address { get; set; }
        public virtual string Tel { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Email { get; set; }
        public virtual string StartLogoUrl { get; set; }
        public virtual byte[] StartLogo { get; set; }
        public virtual string Infor { get; set; }
        public override string ToString()
        {
            return CompanyName;
        }
    }
}
