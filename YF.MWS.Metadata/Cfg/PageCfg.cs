using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 分页设置
    /// </summary>
    public class PageCfg
    {
        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 启用分页查询
        /// </summary>
        public bool Start { get; set; }

    }
}
