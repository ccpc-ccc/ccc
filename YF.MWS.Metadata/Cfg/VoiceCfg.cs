using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    public class VoiceCfg
    {
        /// <summary>
        /// 超载提示语言
        /// </summary>
        public string OverWeight { get; set; }

        /// <summary>
        /// 车牌识别提示音
        /// </summary>
        public string CarRecognition { get; set; }

        /// <summary>
        /// 车未停好提示音
        /// </summary>
        public string CarStopFail { get; set; }

        /// <summary>
        /// 红外被遮挡
        /// </summary>
        public string InfraredCovered { get; set; }
        /// <summary>
        /// 开始刷卡
        /// </summary>
        public string StartReadCard { get; set; }

        /// <summary>
        /// 刷卡成功提示音
        /// </summary>
        public string ReadCardSuccess { get; set; }

        /// <summary>
        /// 刷卡失败提示音
        /// </summary>
        public string ReadCardFail { get; set; }

        /// <summary>
        /// 开始上磅提示音
        /// </summary>
        public string StartWeight { get; set; }

        /// <summary>
        /// 称重未稳定
        /// </summary>
        public string WeightUnStable { get; set; }

        /// <summary>
        /// 下磅提示音
        /// </summary>
        public string UnloadWeight { get; set; }
        /// <summary>
        /// 第一次完成称重
        /// </summary>
        public string FirstWeight { get; set; }

        /// <summary>
        /// 超时
        /// </summary>
        public string TimeOut { get; set; }

        /// <summary>
        /// 第二次完成称重
        /// </summary>
        public string SecondWeight { get; set; }

        public BroadcastWeightType BroadcastWeight { get; set; }
    }
}
