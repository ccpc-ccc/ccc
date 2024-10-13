using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 运行设置
    /// </summary>
    public class LaunchCfg
    {
        public DefaultPageType DefaultPage { get; set; }

        /// <summary>
        /// 是否自动维护
        /// </summary>
        public bool StartAutoMaintain { get; set; }
        public bool RunMoreApps { get; set; }
        /// <summary>
        /// 自动启动时间间隔类型
        /// </summary>
        public ReStartTimeSpanType ReStartTimeSpan { get; set; }

        /// <summary>
        /// 相隔小时数
        /// </summary>
        public int Hours { get; set; }

        /// <summary>
        /// 固定时间集合
        /// </summary>
        public List<DateTime> FixedTimes { get; set; }
        /// <summary>
        /// 当前程序运行版本类型
        /// </summary>
        public AppRunVersion RunVersion { get; set; }
    }
}
