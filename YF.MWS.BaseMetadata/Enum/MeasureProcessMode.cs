using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 计量流程方式
    /// </summary>
    public enum MeasureProcessMode
    {
        /// <summary>
        /// 第一次称毛重
        /// </summary>
        FirstGross = 0,
        /// <summary>
        /// 第一次称皮重
        /// </summary>
        FirstTare = 1
    }
}
