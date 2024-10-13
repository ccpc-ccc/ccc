using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Screen
{
    public class LedShowCfg
    {
        public bool ShowInCarNoRecognition { get; set; }
        public bool ShowInWeightStable { get; set; }
        /// <summary>
        /// 是否显示广告语
        /// </summary>
        public bool ShowAd { get; set; }
        /// <summary>
        /// 空闲多少分钟后显示广告
        /// </summary>
        public int IdleMinutesShowAd { get; set; }
        public ShowWeightStableCfg ShowWeightStable { get; set; }
        public LedShowCfg() 
        {
            ShowWeightStable = new ShowWeightStableCfg();
        }
    }
}
