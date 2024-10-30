using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 车牌设置
    /// </summary>
    public class DeviceCfg {
        /// <summary>
        /// 启用仪表
        /// </summary>
        public bool StartDevice { get; set; } = false;
        /// <summary>
        /// 仪表型号
        /// </summary>
        public string Version { get; set; } = "XK3190-A6";
        /// <summary>
        /// 仪表计量单位
        /// </summary>
        public string DUnit { get; set; } = "KG";
        /// <summary>
        /// 软件计量单位
        /// </summary>
        public string SUnit { get; set; } = "KG";
        /// <summary>
        /// 显示格式
        /// </summary>
        public string ShowFormat { get; set; } = "0.00";
        /// <summary>
        /// 仪表分度值
        /// </summary>
        public string Division { get; set; } = "1";
        /// <summary>
        /// 串口通讯方式
        /// </summary>
        public string ComFun { get; set; } = "0";
        /// <summary>
        /// 自定义仪表编码
        /// </summary>
        public string CustomCode { get; set; } = "ASCII";
        /// <summary>
        /// 自定义仪表起始位
        /// </summary>
        public string DataStart { get; set; } = " ";
        /// <summary>
        /// 自定义仪表截取位
        /// </summary>
        public string Intercept { get; set; } = "1";
        /// <summary>
        /// 自定义仪表数据长度
        /// </summary>
        public string DataLength { get; set; } = "7";
        /// <summary>
        /// 自定义仪表小数点位
        /// </summary>
        public string Point { get; set; } = "0";
        /// <summary>
        /// 自定义仪表数据顺序
        /// </summary>
        public string Sequence { get; set; } = "SX";
        /// <summary>
        /// 串口编号
        /// </summary>
        public string Port { get; set; } = "COM1";
        /// <summary>
        /// 波特率
        /// </summary>
        public string BaundRate { get; set; } = "9600";
        /// <summary>
        /// 数据位
        /// </summary>
        public string DataBit { get; set; } = "8";
        /// <summary>
        /// 停止位
        /// </summary>
        public string StopBit { get; set; } = "One";
        /// <summary>
        /// 校验位
        /// </summary>
        public string Parity { get; set; } = "None";
        /// <summary>
        /// 数据显示格式（10，16位）
        /// </summary>
        public string DataFormat { get; set; } = "DEC";
        /// <summary>
        /// 自动归零
        /// </summary>
        public bool StartReturnZero { get; set; } = false;
        /// <summary>
        /// 归零指令
        /// </summary>
        public string ReturnZeroCommand { get; set; }
    }
}
