using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 视频设置
    /// </summary>
    public class VideoCfg
    {
        /// <summary>
        /// 视频程序名称
        /// </summary>
        public string VideoAppName { get; set; }
        public CaptureMode CaptureMode { get; set; }
        /// <summary>
        /// 摄像头品牌
        /// </summary>
        public string VideoCamera { get; set; }
        private int width;

        public int Width
        {
            get
            {
                if (width <= 0)
                    width = 640;
                return width;
            }
            set { width = value; }
        }
        private int height;

        public int Height
        {
            get
            {
                if (height <= 0)
                    height = 320;
                return height;
            }
            set { height = value; }
        }
        /// <summary>
        /// 排列方式
        /// </summary>
        public int WidthNum { get; set; }
        public int HeightNum { get; set; }
    }
}
