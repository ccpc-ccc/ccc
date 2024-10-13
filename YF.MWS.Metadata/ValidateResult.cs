using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    public class ValidateResult
    {
        /// <summary>
        /// 可用次数
        /// </summary>
        public int AvailableTimes { get; set; }
        /// <summary>
        /// 是否过期
        /// </summary>
        public bool IsExpired { get; set; }
        /// <summary>
        /// 是否注册
        /// </summary>
        public bool IsRegistered { get; set; }
    }
}
