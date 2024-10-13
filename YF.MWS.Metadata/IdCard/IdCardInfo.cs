using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 身份证信息
    /// </summary>
    public class IdCardInfo
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string FullName { get; set; }
    }
}
