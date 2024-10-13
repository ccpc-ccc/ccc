using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 车牌识别配置
    /// </summary>
    public class CarNoRecognitionCfg
    {
        public string Recognition { get; set; }
        /// <summary>
        /// 1#识别仪IP
        /// </summary>
        public string IP1 { get; set; }
        /// <summary>
        /// 1#识别仪端口
        /// </summary>
        public int Port1 { get; set; }

        public string UserName1 { get; set; }
        public string Password1 { get; set; }

        public string UserName2 { get; set; }
        public string Password2 { get; set; }

        public string UserName3 { get; set; }
        public string Password3 { get; set; }

        public string UserName4 { get; set; }
        public string Password4{ get; set; }

        /// <summary>
        /// 2#识别仪IP
        /// </summary>
        public string IP2 { get; set; }
        /// <summary>
        /// 2#识别仪端口
        /// </summary>
        public int Port2 { get; set; }
        /// <summary>
        /// 3#识别仪IP
        /// </summary>
        public string IP3 { get; set; }
        /// <summary>
        /// 3#识别仪端口
        /// </summary>
        public int Port3 { get; set; }
        /// <summary>
        /// 4#识别仪IP
        /// </summary>
        public string IP4 { get; set; }
        /// <summary>
        /// 4#识别仪端口
        /// </summary>
        public int Port4 { get; set; }

        /// <summary>
        /// 识别时间间隔(分钟)
        /// </summary>
        public int RecognitionTimeSpan { get; set; }

        /// <summary>
        /// 启用同一车牌号识别控制
        /// </summary>
        public bool StartSameCarNoControl { get; set; }
        /// <summary>
        /// 启用车牌识别校准
        /// </summary>
        public bool StartCarRecAdjust { get; set; }
        /// <summary>
        /// 输出到视频
        /// </summary>
        public bool OutputVideo { get; set; }
        /// <summary>
        /// 车牌号输出到大屏幕
        /// </summary>
        public bool OutputScreen { get; set; }
        /// <summary>
        /// 车牌识别条件
        /// </summary>
        public CarNoRecCondition RecCondition { get; set; }
    }
}
