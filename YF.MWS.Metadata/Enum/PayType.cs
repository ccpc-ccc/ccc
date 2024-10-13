using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 结算状态
    /// </summary>
    public enum PayType
    {

        [Description("未结算")]
        UnSettled = 0,

        [Description("已结算")]
        Settled = 1
    }
}
