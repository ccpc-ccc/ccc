using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    public class AuthCfg
    {
        /// <summary>
        /// 读卡器
        /// </summary>
        public bool ReadCard { get; set; } 

        /// <summary>
        /// 车牌识别
        /// </summary>
        public bool CarNoRecognition { get; set; }

        /// <summary>
        /// 无人值守称重
        /// </summary>
        public bool AutoWeight { get; set; }

        /// <summary>
        /// 启用视频
        /// </summary>
        public bool StartVideo { get; set; }

        /// <summary>
        /// 启用网络版
        /// </summary>
        public bool StartOnline { get; set; }

        /// <summary>
        /// 启用大屏幕
        /// </summary>
        public bool StartScreen { get; set; }

        /// <summary>
        /// 启用财务模块
        /// </summary>
        public bool StartFinance { get; set; }

        /// <summary>
        /// 启用触摸屏
        /// </summary>
        public bool StartPad { get; set; }

    }
}
