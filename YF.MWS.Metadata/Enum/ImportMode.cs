using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 数据导入方式
    /// </summary>
    public enum ImportMode
    {
        /// <summary>
        /// 增量导入
        /// </summary>
        Increment,
        /// <summary>
        /// 全新导入(删除原有数据)
        /// </summary>
        New
    }
}
