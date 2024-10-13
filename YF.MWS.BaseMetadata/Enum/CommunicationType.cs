using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 通讯方式
    /// </summary>
    public enum CommunicationType
    {
        /// <summary>
        /// 串口
        /// </summary>
        Com,
        /// <summary>
        /// USB
        /// </summary>
        Usb,
        /// <summary>
        /// 蓝牙
        /// </summary>
        Ble,
        /// <summary>
        /// 网口
        /// </summary>
        NetWork
    }
}
