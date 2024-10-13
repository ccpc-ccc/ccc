using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 设备通讯方式
    /// </summary>
    public enum DeviceCommMode
    {
        /// <summary>
        /// 串口
        /// </summary>
        /// 
        [Description("串口")]
        Com = 0,
        /// <summary>
        /// 网口
        /// </summary>
        /// 
        [Description("网口")]
        Network = 1
    }
}
