using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 系统配置总入口类
    /// </summary>
    /// 
    [Serializable]
    public class SysCfg
    {
        
        //public WeightNoCfg WeightNo { get; set; }
        public WeightCfg Weight { get; set; } 
        public string ModbusIP { get; set; }
        public int ModbusPort { get; set; }
        /// <summary>
        /// 是否自动运行
        /// </summary>
        public bool AutoOption { get; set; }
        public int IntervalTime { get; set; } = 5;
        public SysCfg()
        {
            Weight = new WeightCfg();
        }
    }
}
