using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 视频文件类型
    /// </summary>
    public enum VideoFileType
    {
        /// <summary>
        /// Mp4格式视频
        /// </summary>
        /// 
        [Description("Mp4格式视频")]
        Mp4,
        /// <summary>
        /// AVI格式视频
        /// </summary>
        /// 
        [Description("AVI格式视频")]
        Avi,
        /// <summary>
        /// 海康视频文件
        /// </summary>
        /// 
        [Description("海康视频文件")]
        Hk
    }
}
