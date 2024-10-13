using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Metadata;

namespace YF.MWS.Metadata.Cfg
{
    public class ReadCardCfg
    {
        public ReadCardType Type { get; set; }
        public bool IsStart { get; set; }
        /// <summary>
        /// 1#串口
        /// </summary>
        public string SerialPort1 { get; set; }
        /// <summary>
        /// 2#串口
        /// </summary>
        public string SerialPort2 { get; set; }
        /// <summary>
        /// 3#串口
        /// </summary>
        public string SerialPort3 { get; set; }
        /// <summary>
        /// 4#串口
        /// </summary>
        public string SerialPort4 { get; set; }
        /// <summary>
        /// 远程读卡器功率
        /// </summary>
        public int PowerDbm { get; set; }
        /// <summary>
        /// 是否应用参数
        /// </summary>
        public bool ApplyParameter { get; set; }

        /// <summary>
        /// 卡号生成方式
        /// </summary>
        public CardIdGenerateMode CardIdGenerate { get; set; }
    }
}
