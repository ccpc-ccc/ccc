using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// PLC配置信息
    /// </summary>
    public class FormCfg {
        /// <summary>
        /// 是否为最大化
        /// </summary>
        public int isMax { get; set; } = -1;
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
    public class AllFormCfg {
        public FormCfg mainFrm { get; set; }
        public FormCfg videoFrm { get; set; }
        public AllFormCfg() {
            mainFrm = new FormCfg();
            videoFrm = new FormCfg();
        }
    }
}
