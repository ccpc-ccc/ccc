using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 注册方式
    /// </summary>
    public enum RegisterMode
    {
        /// <summary>
        /// 文件注册
        /// </summary>
        /// 
        [Description("文件注册")]
        File,
        /// <summary>
        /// 加密狗带文件
        /// </summary>
        /// 
        [Description("加密狗带验证文件")]
        Softdog,
        /// <summary>
        /// 仅仅加密狗
        /// </summary>
        /// 
        [Description("加密狗")]
        SoftdogOnly
    }
}
