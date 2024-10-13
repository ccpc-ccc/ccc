using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Metadata.Dto
{
    /// <summary>
    /// 客户信息更新
    /// </summary>
    public class CustomerUpdate
    {
        public List<string> CustomerIds { get; set; }
        public RowState State { get; set; }
        public CustomerUpdate() 
        {
            CustomerIds = new List<string>();
        }
    }
}
