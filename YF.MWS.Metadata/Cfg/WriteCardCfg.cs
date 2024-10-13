using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    public class WriteCardCfg
    {
        public CardIdGenerateMode CardIdGenerate { get; set; }
        public ReadCardType CardType { get; set; }
        /// <summary>
        /// 远程读卡器功率
        /// </summary>
        public int PowerDbm { get; set; }
        /// <summary>
        /// 是否应用参数
        /// </summary>
        public bool ApplyParameter { get; set; }
        public string PortName { get; set; }
    }
}
