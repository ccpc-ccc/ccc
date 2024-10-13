using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 单道闸开启时点
    /// </summary>
    public enum OpenSingleGateMode
    {
        /// <summary>
        /// 车牌识别时
        /// </summary>
        CarNoRecognize,
        /// <summary>
        /// 重量保存时
        /// </summary>
        WeightSave,
        /// <summary>
        /// IC卡读取成功时
        /// </summary>
        CardRead
    }
}
