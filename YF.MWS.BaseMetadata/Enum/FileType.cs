using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 文件类型
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// 进场图片
        /// </summary>
        /// 
        [Description("进场图片")]
        Enter = 0,
        /// <summary>
        /// 出场图片
        /// </summary>
        /// 
        [Description("出场图片")]
        Exit = 1,
        /// <summary>
        /// 进场车头图片
        /// </summary>
        /// 
        [Description("进场车头图片")]
        CarHead = 2,
        /// <summary>
        /// 进场车尾图片
        /// </summary>
        /// 
        [Description("进场车尾图片")]
        CarRear = 3,
        /// <summary>
        /// 进场左侧图片
        /// </summary>
        /// 
        [Description("进场左侧图片")]
        CarLeft = 4,
        /// <summary>
        /// 进场右侧图片
        /// </summary>
        /// 
        [Description("进场右侧图片")]
        CarRight = 5
    }
}
