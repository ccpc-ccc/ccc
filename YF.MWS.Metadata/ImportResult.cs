using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 导入数据执行后的结果
    /// </summary>
    public class ImportResult
    {
       public bool Success { get; set; }
       public string Remark { get; set; }
    }
}
