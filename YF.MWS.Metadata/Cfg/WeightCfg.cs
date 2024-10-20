using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 称重设置
    /// </summary>
    public class WeightCfg
    {
        public WeightCfg() 
        { }

        /// <summary>
        /// 毛重与皮重转换
        /// </summary>
        public bool GrossTareTransform { get; set; }

        /// <summary>
        /// 启动计量方
        /// </summary>
        public bool StartMeasure { get; set; }

        /// <summary>
        /// 启用语音提示
        /// </summary>
        public bool StartVoicePrompt { get; set; }

        /// <summary>
        /// 是否驻留磅单信息
        /// </summary>
        public bool SaveFormData { get; set; }

        /// <summary>
        /// 开启远程加载图片
        /// </summary>
        public bool StartLoadImageWithRemote { get; set; }

        /// <summary>
        /// 加载未完成磅单方式
        /// </summary>
        public LoadUnfinishWeightType LoadUnfinishWeight { get; set; }

        /// <summary>
        /// 计量方式
        /// </summary>
        public WeightProcess Process { get; set; }

        /// <summary>
        /// 启用计重方式配置
        /// </summary>
        public bool StartWeightProcessCfg { get; set; }

        /// <summary>
        /// 启用车辆套表
        /// </summary>
        public bool CarTemp { get; set; }

        /// <summary>
        /// 无人值守磅单流程触发方式
        /// </summary>
        public WeightProcessTriggerType WeightProcessTrigger { get; set; }

        /// <summary>
        /// 车牌限制范围
        /// </summary>
        public CarLimitScopeType LimitScope { get; set; }

        /// <summary>
        /// 是否开启输入项目自动保存
        /// </summary>
        public bool StartInputItemAutoSave { get; set; }
        /// <summary>
        /// 是否启用在线支付
        /// </summary>
        public bool StartOnlinePay { get; set; }

        /// <summary>
        /// 是否启用控制箱
        /// </summary>
        public bool StartModBus { get; set; }
        /// <summary>
        /// 控制箱通讯方式
        /// </summary>
        public DeviceCommMode ModBusCommMode { get; set; }
        /// <summary>
        /// 启用客户余额限制
        /// </summary>
        public bool StartCustomerBalanceLimit { get; set; }
        /// <summary>
        /// 启用IC卡验证车牌
        /// </summary>
        public bool StartValidateCarWithCard { get; set; }
        /// <summary>
        /// 启用App磅单审核
        /// </summary>
        public bool StartAppWeightConfirm { get; set; }
        /// <summary>
        /// 启用数据库备份
        /// </summary>
        public bool StartBackupDb { get; set; }
        /// <summary>
        /// 数据库备份目录
        /// </summary>
        public string BackupDir { get; set; }
        /// <summary>
        /// 自动运行
        /// </summary>
        public bool AutoRun { get; set; }
        /// <summary>
        /// 自动运行的APP名称
        /// </summary>
        public string RunAppName { get; set; }
        /// <summary>
        /// 支付企业ID
        /// </summary>
        public string PayCompanyId { get; set; }
        /// <summary>
        /// 支付企业编号
        /// </summary>
        public string PayCompanyNo { get; set; }
        /// <summary>
        /// 支付企业名称
        /// </summary>
        public string PayCompanyName { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public PayPluginType PayType { get; set; }
        /// <summary>
        /// 付款二维码类型
        /// </summary>
        public PayCodeType PayCode { get; set; }
        /// <summary>
        /// 启动系统自动重置
        /// </summary>
        public bool StartAutoReset { get; set; }
        /// <summary>
        /// 空闲分钟数
        /// </summary>
        public decimal IdleMinutes { get; set; }
        /// <summary>
        /// 计量流程方式
        /// </summary>
        public MeasureProcessMode ProcessMode { get; set; }
        /// <summary>
        /// 启用自动作废未完成磅单
        /// </summary>
        public bool StartAutoInvalid { get; set; }
        /// <summary>
        /// 未完成磅单的过期时间(小时)
        /// </summary>
        public int UnfinishedTimeOut { get; set; }
        /// <summary>
        /// 连续称重时，前一次称重的重量
        /// </summary>
        public decimal oldWeight { get; set; }
        /// <summary>
        /// 磅单号生成方式
        /// </summary>
        public FinishState WeightNoGenerateMode { get; set; }
        /// <summary>
        /// 启用同一卡号读取控制
        /// </summary>
        public bool StartSameCardNoControl { get; set; }
        /// <summary>
        /// 允许一车多张卡
        /// </summary>
        public bool AllowOneCarMultipleCards { get; set; }
        /// <summary>
        /// 同一卡号读卡时间间隔(分钟)
        /// </summary>
        public int ReadCardTimeSpan { get; set; }
        /// <summary>
        /// 磅单号是否随机生成
        /// </summary>
        public bool GenerateWeightNoByRand { get; set; }
        /// <summary>
        /// 启用计划单限制功能
        /// </summary>
        public bool StartPlan { get; set; }
        /// <summary>
        /// 启用双击加载未完成磅单
        /// </summary>
        public bool StartDoubleClickUnfinished { get; set; }
        /// <summary>
        /// 司磅员启用磅单过滤
        /// </summary>
        public bool StartWeighterDataFilter { get; set; }
        /// <summary>
        /// 共享磅单
        /// </summary>
        public bool ShareWeight { get; set; }
    }
}
