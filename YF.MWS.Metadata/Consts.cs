using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 公共变量
    /// </summary>
    public class Consts
    {
        public const string CookieName_LoginAccountList = "MWSLOGINACCOUNTLISTCookie";
        /// <summary>
        /// 缓存过期时间(30分钟)
        /// </summary>
        public const int CACHE_TIME = 30;
        /// <summary>
        /// 缓存过期时间(30分钟)
        /// </summary>
        public const int CACHE_TIME_OUT_LONG = 30;
        /// <summary>
        /// 缓存过期时间(2小时)
        /// </summary>
        public const int CACHE_TIME_OUT_TWO_HOURS = 30;
        /// <summary>
        /// 计量类型列名
        /// </summary>
        public const string COLUMN_MEASURE_TYPE_NAME = "MeasureType";
        /// <summary>
        /// 默认客户端名称
        /// </summary>
        public const string DEFAULT_CLIENT_NAME = "CS智能称重客户端";
        /// <summary>
        /// 仓舒云磅服务器地址
        /// </summary>
        public const string RJWEIGHT_SERVER_URL = "http://120.25.157.251:81";
    }
}
