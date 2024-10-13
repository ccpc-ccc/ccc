using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 数据库类别
    /// </summary>
    public enum DataBaseType
    {
        /// <summary>
        /// 本地数据库
        /// </summary>
        /// 
        [Description("本地数据库")]
        Sqlite,
        /// <summary>
        /// SqlServer数据库
        /// </summary>
        /// 
        [Description("SqlServer数据库")]
        Sqlserver,
        /// <summary>
        /// MySql数据库
        /// </summary>
        /// 
        [Description("MySql数据库")]
        MySql
    }
}
