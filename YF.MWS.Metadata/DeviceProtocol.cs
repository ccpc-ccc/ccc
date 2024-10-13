using System;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 仪表协议
    /// </summary>
    public class DeviceProtocol
    {
        /// <summary>
        /// 开始位
        /// </summary>
        public byte BeginBit { get; set; }
        /// <summary>
        /// 结束位
        /// </summary>
        public byte EndBit { get; set; }

        /// <summary>
        /// 帧长度
        /// </summary>
        public int FrameLength { get; set; }

        /// <summary>
        /// 开始截取位
        /// </summary>
        public int InterceptBit { get; set; }

        /// <summary>
        /// 小数点
        /// </summary>
        public int Point { get; set; }

        /// <summary>
        /// 数据顺序
        /// </summary>
        public string Sequence { get; set; }
    }
}
