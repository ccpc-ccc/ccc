using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 用户类别
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// 管理员
        /// </summary>
        /// 
        [Description("管理员")]
        Admin,
        /// <summary>
        /// 司磅员
        /// </summary>
        /// 
        [Description("司磅员")]
        Weighter,
        /// <summary>
        /// 仓管
        /// </summary>
        /// 
        [Description("仓管")]
        WarehManager,
        /// <summary>
        /// 财务
        /// </summary>
        /// 
        [Description("财务")]
        FinanceManager,
        /// <summary>
        /// 公司客户
        /// </summary>
        /// 
        [Description("公司客户")]
        CorpCustomer,
        /// <summary>
        /// 公司客户对应的司机
        /// </summary>
        /// 
        [Description("公司客户对应的司机")]
        CustomerDriver,
        /// <summary>
        /// 其他
        /// </summary>
        /// 
        [Description("其他")]
        Other
    }
}
