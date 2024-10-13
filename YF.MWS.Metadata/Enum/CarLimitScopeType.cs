using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 黑白车牌限制范围
    /// </summary>
    public enum CarLimitScopeType
    {
        /// <summary>
        /// 不限制
        /// </summary>
        None,
        /// <summary>
        /// 只限制黑名单
        /// </summary>
        OnlyLimitBlackList,
        /// <summary>
        /// 白名单以外的都限制
        /// </summary>
        ExcludeWhiteList
    }
}
