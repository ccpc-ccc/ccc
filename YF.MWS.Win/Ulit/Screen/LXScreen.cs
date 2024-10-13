using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Screen;

namespace YF.MWS.Win.Util.Screen
{
    public class LXScreen : ILedScreen
    {
        private LXCfg cfg;
        private LXLedUtil lxLedUtil = null;
        private bool start = false;

        public LXScreen(LXCfg mCfg) 
        {
            start = mCfg.Start;
            if (!start)
                return;
            cfg = mCfg;
            if (cfg.VersionType == Metadata.LedVersionType.T3)
            {
                lxLedUtil = new LXLedUtil(mCfg);
                lxLedUtil.Setting();
                lxLedUtil.SetScreenParameter();
            }
            else 
            {
                LXNewLedUtil.SetScreenParameter(mCfg);
            }
        }

        public bool SendAd(bool isFirst)
        {
            bool isSuccessed = false;
            if (!start)
                return isSuccessed;
            if (cfg.VersionType == Metadata.LedVersionType.T3)
            {
                if (!isFirst)
                {
                    lxLedUtil.Setting();
                }
                lxLedUtil.SendAd(cfg.AdFontSize);
            }
            else
            {
                isSuccessed = LXNewLedUtil.SendInfo(cfg, cfg.AdContent, cfg.AdFontSize);
            }
            return isSuccessed;
        }

        public bool SendInfo(WeightFlowType showType, string info)
        {
            bool isSuccessed = false;
            if (!start)
                return isSuccessed;
            bool canShow = false;
            switch (showType) 
            {
                case WeightFlowType.CarNoRecognition:
                    if (cfg.LedShow != null && cfg.LedShow.ShowInCarNoRecognition)
                        canShow = true;
                    break;
                case WeightFlowType.WeightStable:
                    if (cfg.LedShow != null && cfg.LedShow.ShowInWeightStable)
                        canShow = true;
                    break;
            }
            if (!canShow)
                return isSuccessed;
            if (cfg.VersionType == Metadata.LedVersionType.T3)
            {
                lxLedUtil.Setting();
                lxLedUtil.SendText(info, cfg.WeightFontSize);
            }
            else 
            {
                isSuccessed = LXNewLedUtil.SendInfo(cfg, info, cfg.WeightFontSize);
            }
            return isSuccessed;
        }
    }
}
