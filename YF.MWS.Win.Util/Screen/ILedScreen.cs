using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Screen;

namespace YF.MWS.Win.Util.Screen
{
    public interface ILedScreen
    {
        bool SendAd(bool isFirst);
        bool SendInfo(WeightFlowType showType, string info);
    }
}
