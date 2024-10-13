using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 文件业务类型
    /// </summary>
    public enum FileBusinessType
    {
        /// <summary>
        /// 磅单图片
        /// </summary>
        /// 
        [Description("磅单图片")]
        Graphic = 1,
        /// <summary>
        /// 磅单视频
        /// </summary>
        /// 
        [Description("磅单视频")]
        Video = 2,
        /// <summary>
        /// 运单
        /// </summary>
        /// 
        [Description("运单")]
        Waybill = 3,
        /// <summary>
        /// 磅单审核图片
        /// </summary>
        /// 
        [Description("磅单审核图片")]
        Confirm = 4,
        /// <summary>
        /// 车牌识别图片
        /// </summary>
        /// 
        [Description("车牌识别图片")]
        CarRecognition=5
    }
}
