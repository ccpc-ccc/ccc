using System;

namespace YF.MWS.Metadata
{
    public class VideoChannel
    {
        /// <summary>
        /// 通道IP地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 通道端口号
        /// </summary>
        public int PortNumber { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 通道号
        /// </summary>
        public int ChannelNo { get; set; }
    }
}
