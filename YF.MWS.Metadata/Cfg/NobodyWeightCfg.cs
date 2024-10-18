using System;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Metadata.Cfg
{
    public class NobodyWeightCfg
    {

        /// <summary>
        /// 是否启用道闸
        /// </summary>
        public bool StartBoundGate { get; set; }

        /// <summary>
        /// 是否启用红外对射
        /// </summary>
        public bool StartInfrared { get; set; }
        /// <summary>
        /// 超过重量后启用道闸
        /// </summary>
        public decimal InfraredWeight { get; set; }

        /// <summary>
        /// 最小称重值
        /// </summary>
        public decimal MinWeightValue { get; set; }

        /// <summary>
        /// 重量稳定几秒后自动保存重量
        /// </summary>
        public decimal AutoSaveTime { get; set; }

        /// <summary>
        /// 最大驶出重量值
        /// </summary>
        public decimal OutWeightValue { get; set; }

        /// <summary>
        /// 重量小于最大驶出重量值几秒后道闸自动落杆
        /// </summary>
        public decimal AutoOutTime { get; set; }

        /// <summary>
        /// 最大重量归零值
        /// </summary>
        public decimal MaxReturnZeroWeightValue { get { return OutWeightValue; } }

        /// <summary>
        /// 功能码6闭合时间
        /// </summary>
        public int FunSixCloseTime { get; set; }

        /// <summary>
        /// 道闸控制方式 Modbus 控制箱控制 Car 车牌识别控制
        /// </summary>
        public string GateControl { get; set; }

        /// <summary>
        /// 启用红绿灯
        /// </summary>
        public bool StartTrafficLight { get; set; }
        /// <summary>
        /// 一次过磅启用手动保存磅单
        /// </summary>
        public bool StartSaveWithManualFirst { get; set; }
        /// <summary>
        /// 二次过磅启用手动保存磅单
        /// </summary>
        public bool StartSaveWithManualSecond { get; set; }
        /// <summary>
        /// 网络控制箱  IP
        /// </summary>
        public string ModbusIP { get; set; }
        /// <summary>
        /// 网络控制箱 端口
        /// </summary>
        public int ModbusPort { get; set; }
    }
}
