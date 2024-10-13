using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 车牌识别仪类型
    /// </summary>
    public enum CarPlateRecognizerType
    {
        /// <summary>
        /// 无车牌识别仪
        /// </summary>
        None,
        /// <summary>
        /// 大华
        /// </summary>
        DH,
        /// <summary>
        /// 海康
        /// </summary>
        HK,
        /// <summary>
        /// 华夏
        /// </summary>
        HX,
        /// <summary>
        /// 文通
        /// </summary>
        KHT,
        /// <summary>
        /// 文通(新)
        /// </summary>
        KHTNew,
        /// <summary>
        /// 高清通
        /// </summary>
        GQ,
        /// <summary>
        /// 安视宝
        /// </summary>
        ASB,
        /// <summary>
        /// 安视宝(新)
        /// </summary>
        ASB_NEW,
        /// <summary>
        /// 臻识车牌识别仪
        /// </summary>
        VZ
    }
}
