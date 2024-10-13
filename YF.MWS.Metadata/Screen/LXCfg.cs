using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Screen
{
    public class LXCfg
    {
        /// <summary>
        /// 广告语
        /// </summary>
        public string AdContent { get; set; }
        /// <summary>
        /// 卡型号
        /// </summary>
        public int CardModel { get; set; }

        /// <summary>
        /// 通讯模式
        /// </summary>
        public CommunicationModelType CommunicationModel { get; set; }

        /// <summary>
        /// 播放速度
        /// </summary>
        public int PlaySpeed { get; set; }

        public int Delay { get; set; }

        /// <summary>
        /// 屏号
        /// </summary>
        public int ScreenNo { get; set; }

        /// <summary>
        /// COM端口名称
        /// </summary>
        public string PortName { get; set; }

        /// <summary>
        /// COM端口编号
        /// </summary>
        public int PortNo { get; set; }

        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddr { get; set; }

        /// <summary>
        /// 屏幕颜色
        /// </summary>
        public int ScreenColor { get; set; }

        /// <summary>
        /// 屏幕宽度
        /// </summary>
        public int ScreenWidth { get; set; }

        /// <summary>
        /// 广告字体大小
        /// </summary>
        public int AdFontSize { get; set; }
        /// <summary>
        /// 屏幕高度
        /// </summary>
        public int ScreenHeight { get; set; }

        /// <summary>
        /// 磅单字体大小
        /// </summary>
        public int WeightFontSize { get; set; }

        public bool Start { get; set; }

        public LedVersionType VersionType { get; set; }

        public LedShowCfg LedShow { get; set; }


        public LXCfg()
        {
            CardModel = 2;
            ScreenWidth = 64;
            ScreenHeight = 48;
            PlaySpeed = 35;
            Delay = 15;
            AdFontSize = 12;
            WeightFontSize = 12;
            LedShow = new LedShowCfg();
        }
    }
}
