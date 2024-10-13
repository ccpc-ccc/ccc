using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 验证磅单输入项模式
    /// </summary>
    public enum ValidateInputMode
    {
        /// <summary>
        /// 不验证
        /// </summary>
        /// 
        [Description("不验证")]
        UnValidate = 0,
        /// <summary>
        /// 验证新磅单
        /// </summary>
        /// 
        [Description("验证新磅单")]
        ValidateNew = 1,
        /// <summary>
        /// 完成时验证
        /// </summary>
        /// 
        [Description("完成时验证")]
        ValidateFinish = 2,
        /// <summary>
        /// 每次都验证
        /// </summary>
        /// 
        [Description("每次都验证")]
        ValidateAny = 3
    }
}
