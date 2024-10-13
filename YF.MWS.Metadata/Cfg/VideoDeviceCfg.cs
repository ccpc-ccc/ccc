using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 视频设置
    /// </summary>
    public class VideoDeviceCfg {
        /// <summary>
        /// 是否使用
        /// </summary>
        public bool isUse { get; set; }
        public string ip { get; set; }
        public int port { get; set; }
        public int ChannelNo { get;set; }
        public string userName { get; set; }
        public string password { get; set; }
        /// <summary>
        /// 摄像机品牌
        /// </summary>
        public string VideoCamera { get; set; }
        /// <summary>
        /// 叠加内容X坐标
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// 叠加内容Y坐标
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// 是否叠加重量
        /// </summary>
        public bool IsSuper { get; set; }
        /// <summary>
        /// 视频叠加的初始内容
        /// </summary>
        public string Text { get; set; }

    }
}
