using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 同步状态
    /// </summary>
    public enum SyncState
    {
        /// <summary>
        /// 未同步
        /// </summary>
        /// 
        [Description("未同步")]
        UnSynced = 0,
        /// <summary>
        /// 已同步
        /// </summary>
        /// 
        [Description("已同步")]
        Synced = 1
    }
}
