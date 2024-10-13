using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    public enum VersionCodeType
    {
        /// <summary>
        /// 安徽九华金峰矿业
        /// </summary>
        [Description("安徽九华金峰矿业")]
        AHJHJF = 1,
        /// <summary>
        /// 南昌版本
        /// </summary>
        /// 
        [Description("南昌版本")]
        NC = 2,
        /// <summary>
        /// 四川省资阳市安岳县
        /// </summary>
        /// 
        [Description("四川省资阳市安岳县")]
        ZYAY,
        /// <summary>
        /// 标准版
        /// </summary>
        /// 
        [Description("标准版")]
        YC,
        /// <summary>
        /// 包头市凯胜农副产品物流有限公司版
        /// </summary>
        /// 
        [Description("包头市凯胜农副产品物流有限公司版")]
        KSNCP
    }
}
