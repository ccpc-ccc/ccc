using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace YF.MWS.Metadata
{
    public enum AuthType
    {
        ModifyCorp,
        ResetPassword,
        ResetVersionSetting
    }

    /// <summary>
    /// 控件类别
    /// </summary>
    public enum ControlType
    {
        /// <summary>
        /// 标准
        /// </summary>
        Standard,
        /// <summary>
        /// 扩展
        /// </summary>
        Extend
    }

    /// <summary>
    /// 默认页面
    /// </summary>
    public enum DefaultPageType
    {
        /// <summary>
        /// 公司简介
        /// </summary>
        Corp,
        /// <summary>
        /// 新建磅单
        /// </summary>
        Weight
    }

    /// <summary>
    /// 日期类别
    /// </summary>
    public enum DateType 
    {
        /// <summary>
        /// 财务结算
        /// </summary>
        FinanceSettle=1,
        /// <summary>
        /// 过磅
        /// </summary>
        Weight=0
    }

    /// <summary>
    /// 搜索输入控件类别
    /// </summary>
    public enum SearchControlType 
    {
        SearchLookup,
        Text
    }

    /// <summary>
    /// 字段类别
    /// </summary>
    public enum SearchFieldType 
    {
        /// <summary>
        /// 标准
        /// </summary>
        Standard,
        /// <summary>
        /// 扩展
        /// </summary>
        Extend
    }

    /// <summary>
    /// 磅单流程触发方式
    /// </summary>
    public enum WeightProcessTriggerType 
    {
        /// <summary>
        /// 车牌识别
        /// </summary>
        CarRecognition,
        /// <summary>
        /// 刷卡
        /// </summary>
        Card,
        /// <summary>
        /// 刷身份证
        /// </summary>
        IdCard,
        /// <summary>
        /// 先车牌识别后刷卡
        /// </summary>
        CarRecognitionCard,
        /// <summary>
        /// 车牌识别或刷卡
        /// </summary>
        CarRecognitionOrCard,
        /// <summary>
        /// 重量稳定
        /// </summary>
        WeightStable,
        /// <summary>
        /// 触摸屏
        /// </summary>
        Pad
    }

    /// <summary>
    /// 通讯模式
    /// </summary>
    public enum CommunicationModelType
    {
        /// <summary>
        /// 网络
        /// </summary>
        Network,
        /// <summary>
        /// 串口
        /// </summary>
        SerlPort
    }

    public enum ViewType 
    {
        /// <summary>
        /// 称重
        /// </summary>
        [Description("称重界面")]
        Weight,
        /// <summary>
        /// 计量
        /// </summary>
        [Description("其它界面")]
        Measure,
        /// <summary>
        /// 车辆套表
        /// </summary>
        [Description("车辆套表")]
        Car
    }

    /// <summary>
    /// 读卡类别
    /// </summary>
    public enum ReadCardType
    {
        Short = 0,
        Remote = 1
    }

    public enum PrintCfgType
    {
        Finance,
        Weight,
        Qc
    }

    /// <summary>
    /// 任务类别
    /// </summary>
    public enum TaskType 
    {
        None,
        /// <summary>
        /// 抓拍
        /// </summary>
        Capture,
        /// <summary>
        /// 打水印
        /// </summary>
        PrintWatermark,
        /// <summary>
        /// 开始录制视频
        /// </summary>
        StartRecordVideo,
        /// <summary>
        /// 停止录制视频
        /// </summary>
        StopRecordVideo,
        /// <summary>
        /// 自动打印
        /// </summary>
        AutoPrint,
        /// <summary>
        /// 自动打印临时磅单
        /// </summary>
        AutoPrintTemp
    }

    /// <summary>
    /// 磅单统计报表
    /// </summary>
    public enum WeightReportType 
    {
        Today,
        Day,
        Month,
        Year,
        Search
    }

    /// <summary>
    /// 地磅道闸类型
    /// </summary>
    public enum BoundGateType
    {
        /// <summary>
        /// 单道闸
        /// </summary>
        SingleGate = 0,
        /// <summary>
        /// 双道闸
        /// </summary>
        DoubleGate = 1
    }

    /// <summary>
    /// 触发收费条件
    /// </summary>
    public enum ChargeTriggerCondtionType
    {
        /// <summary>
        /// 完成称重
        /// </summary>
        FinishWeight,
        /// <summary>
        /// 新开磅单
        /// </summary>
        NewWeight
    }

    /// <summary>
    /// 收费模式
    /// </summary>
    public enum ChargeMode 
    {
        /// <summary>
        /// 控件公式
        /// </summary>
        ControlFormula,
        /// <summary>
        /// 收费配置
        /// </summary>
        ChargeCfg
    }

    /// <summary>
    /// 收费规则
    /// </summary>
    public enum ChargeRuleType
    {
        /// <summary>
        /// 按毛重
        /// </summary>
        GrossWeight = 0,
        /// <summary>
        /// 按皮重
        /// </summary>
        TareWeight = 1,
        /// <summary>
        /// 按净重
        /// </summary>
        SuttleWeight = 2,
        /// <summary>
        /// 按皮重+毛重
        /// </summary>
        SummaryWeight = 3,
        /// <summary>
        /// 自定义
        /// </summary>
        Custom = 4,
        /// <summary>
        /// 按物资数量
        /// </summary>
        MaterialAmount = 5,
        /// <summary>
        /// 按物资包数
        /// </summary>
        MaterialPackages=6
    }


    /// <summary>
    /// 人民币单位
    /// </summary>
    public enum CurrencyUnit
    {
        /// <summary>
        /// 十元
        /// </summary>
        TenYuan,
        /// <summary>
        /// 元
        /// </summary>
        Yuan,
        /// <summary>
        /// 角
        /// </summary>
        Jiao,
        /// <summary>
        /// 分
        /// </summary>
        Fen
    }

    public enum RefuseType 
    {
        Accepted,
        Refused
    }

    /// <summary>
    /// 加载未完成磅单的方式
    /// </summary>
    public enum LoadUnfinishWeightType 
    {
        /// <summary>
        /// 不加载
        /// </summary>
        None,
        /// <summary>
        /// 车牌号
        /// </summary>
        CarNo,
        /// <summary>
        /// 卡号
        /// </summary>
        CardNo,
        /// <summary>
        /// 车牌号或卡号
        /// </summary>
        CarNoOrCardNo
    }

    /// <summary>
    /// 磅单命令
    /// </summary>
    public enum WeightCommand
    {
        /// <summary>
        /// 计算汇总
        /// </summary>
        Calculate,
        /// <summary>
        /// 新建磅单
        /// </summary>
        New,
        /// <summary>
        /// 作废磅单
        /// </summary>
        Invalid,
        /// <summary>
        /// 视频监控
        /// </summary>
        Video,
        /// <summary>
        /// 抓拍图片
        /// </summary>
        Photo,
        /// <summary>
        /// 打印临时磅单
        /// </summary>
        PrintTemp,
        /// <summary>
        /// 打印磅单
        /// </summary>
        Print,
        /// <summary>
        /// 保存磅单
        /// </summary>
        Save,
        /// <summary>
        /// 保存皮重
        /// </summary>
        SaveGross,
        /// <summary>
        /// 保存毛重
        /// </summary>
        SaveTare
    }


    public enum PlatformType
    {
        /// <summary>
        /// Windows 客户端
        /// </summary>
        Client,
        Web,
        Mobile
    }

    public enum WeightDirection
    {
        Left,
        Right
    }

    /// <summary>
    /// 换页方向
    /// </summary>
    public enum PageDirection 
    {
        /// <summary>
        /// 第一页
        /// </summary>
        First,
        /// <summary>
        /// 最后一页
        /// </summary>
        Last,
        /// <summary>
        /// 下一页
        /// </summary>
        Next,
        /// <summary>
        /// 上一页
        /// </summary>
        Prev
    }

    /// <summary>
    /// 结算种类
    /// </summary>
    public enum SettleType
    {
        /// <summary>
        /// 财务
        /// </summary>
        Finance,
        /// <summary>
        /// 运费
        /// </summary>
        Freight,
        /// <summary>
        /// 货款
        /// </summary>
        Payment
    }

    /// <summary>
    /// 打印方式
    /// </summary>
    public enum PrintMode
    {
        /// <summary>
        /// 手动打印
        /// </summary>
        Manual,
        /// <summary>
        /// 自动打印
        /// </summary>
        Auto
    }

    /// <summary>
    /// 打印磅单类别
    /// </summary>
    public enum PrintWeightType 
    {
        /// <summary>
        /// 批量磅单打印
        /// </summary>
        Batch,
        /// <summary>
        /// 单个磅单
        /// </summary>
        Single
    }

    public enum MessageType
    {
        Info,
        Warn,
        Error
    }

    /// <summary>
    /// 杂质计算类型
    /// </summary>
    public enum ImpurityMeaType
    {
        /// <summary>
        /// 净值
        /// </summary>
        NetValue,
        /// <summary>
        /// 百分比
        /// </summary>
        Percent
    }

    /// <summary>
    /// 系统编码类别
    /// </summary>
    public enum SysCode
    {
        /// <summary>
        /// 轴数重量
        /// </summary>
        AxleWeight,
        /// <summary>
        /// 车牌识别一体机
        /// </summary>
        CarNoRecognition,
        /// <summary>
        /// 车辆类型
        /// </summary>
        CarType,
        /// <summary>
        /// 收费方式
        /// </summary>
        ChargeType,
        /// <summary>
        /// 控件类型
        /// </summary>
        ControlType,
        /// <summary>
        /// 自定义编码
        /// </summary>
        CustomCode,
        /// <summary>
        /// 波特率
        /// </summary>
        BaundRate,
        /// <summary>
        /// 客户类别
        /// </summary>
        CustomerType,
        /// <summary>
        /// 数据位
        /// </summary>
        DataBit,
        /// <summary>
        /// 日期格式
        /// </summary>
        DateFomart,
        /// <summary>
        /// 部门类型
        /// </summary>
        DeptType,
        /// <summary>
        /// 仪表型号
        /// </summary>
        Device,
        /// <summary>
        /// 仪表分度值
        /// </summary>
        DivisionValue,
        /// <summary>
        /// 单据类别
        /// </summary>
        DocumentType,
        /// <summary>
        /// 完成状态
        /// </summary>
        FinishState,
        /// <summary>
        /// 财务结算
        /// </summary>
        FinaSettlement,
        /// <summary>
        /// 综合判定
        /// </summary>
        Judgement,
        /// <summary>
        /// 产品流向
        /// </summary>
        ProductFlow,
        /// <summary>
        /// 性别
        /// </summary>
        Gender,
        /// <summary>
        /// 位置类型
        /// </summary>
        LocationType,
        /// <summary>
        /// 物资类别
        /// </summary>
        MaterialType,
        /// <summary>
        /// 计量单位
        /// </summary>
        MeasureUnit,
        /// <summary>
        /// 仓库业务类别
        /// </summary>
        WarehBizType,
        /// <summary>
        /// 计量类型
        /// </summary>
        MeasureType,
        /// <summary>
        /// 杂质计算类型
        /// </summary>
        ImpurityMeaType,
        OperatorType,
        /// <summary>
        /// 奇偶校验位
        /// </summary>
        ParityVerifyBit,
        /// <summary>
        /// 数据顺序
        /// </summary>
        Sequence,
        /// <summary>
        /// 序列号
        /// </summary>
        SeqCode,
        /// <summary>
        /// 显示格式
        /// </summary>
        ShowFormat,
        /// <summary>
        /// 状态
        /// </summary>
        State,
        /// <summary>
        /// 统计报表类别
        /// </summary>
        SummaryReportType,
        /// <summary>
        /// 停止位
        /// </summary>
        StopBit,
        /// <summary>
        /// 摄像机品牌
        /// </summary>
        VideoCamera,
        /// <summary>
        /// 称重控件
        /// </summary>
        WeightControl,
        /// <summary>
        /// 称重扩展控件
        /// </summary>
        WeightExtendControl,

        PackageType,
        PayType,
        OrderSource,
        ViewType
    }

    /// <summary>
    /// 磅单时间类别
    /// </summary>
    public enum WeightTimeType 
    {
        /// <summary>
        /// 磅单开始时间
        /// </summary>
        StartTime,
        /// <summary>
        /// 磅单完成时间
        /// </summary>
        FinishTime
    }

    /// <summary>
    /// 称重查询的项目
    /// </summary>
    public enum WeightSearchKey
    {
        /// <summary>
        /// 不可知的查询项目
        /// </summary>
        None,
        /// <summary>
        /// 车牌ID
        /// </summary>
        CarId,
        /// <summary>
        /// 卡号
        /// </summary>
        CardNo,
        /// <summary>
        /// 司机
        /// </summary>
        DriverName,
        /// <summary>
        /// 物资
        /// </summary>
        MaterialId,
        /// <summary>
        /// 送货单位
        /// </summary>
        DeliveryId,
        /// <summary>
        /// 收货单位
        /// </summary>
        ReceiverId,
        /// <summary>
        /// 承运单位
        /// </summary>
        TransferId,
        /// <summary>
        /// 客户ID
        /// </summary>
        CustomerId,
        /// <summary>
        /// 司磅员ID
        /// </summary>
        WeighterId,
        /// <summary>
        /// 业务类型
        /// </summary>
        MeasureType,
        /// <summary>
        /// 生产商
        /// </summary>
        ManufacturerId,
        /// <summary>
        /// 司磅员
        /// </summary>
        WeighterName,
        /// <summary>
        /// 磅单来源
        /// </summary>
        OrderSource,
        /// <summary>
        /// 供应商
        /// </summary>
        SupplierId,
        /// <summary>
        /// 运费结算
        /// </summary>
        FreightSettleState,
        /// <summary>
        /// 货款结算
        /// </summary>
        PaymentSettleState,
        /// <summary>
        /// 财务审核状态
        /// </summary>
        SettleState,
        /// <summary>
        /// 卸货类别
        /// </summary>
        UnloadType,
        /// <summary>
        /// 仓库业务类型
        /// </summary>
        WarehBizType,
        /// <summary>
        /// 支付方式
        /// </summary>
        PayType,
        WarehId,
        CustomCharge,
        SuttleWeight,
        TareWeight,
        CustomerAddress,
        UnitPrice,
        CustomerIdCard,
        GrossWeight,
        CustomerBalance,
        UnitCharge,
        MaterialModel,
        Remark
    }

    /// <summary>
    /// 磅单号前缀类型
    /// </summary>
    public enum WeightNoPrefixFormat
    {
        /// <summary>
        /// 日期
        /// </summary>
        Date,
        /// <summary>
        /// 自定义
        /// </summary>
        Custom
    }

    /// <summary>
    /// 称重计量类型
    /// </summary>
    public enum WeightProcess
    {
        /// <summary>
        /// 一次称重(只需要称毛重)
        /// </summary>
        /// 
        [Description("一次称重")]
        One = 0,
        /// <summary>
        /// 二次称重
        /// </summary>
        /// 
        [Description("二次称重")]
        Two = 1
    }

    /// <summary>
    /// 单据类别
    /// </summary>
    public enum DocumentType
    {
        /// <summary>
        /// 收费单
        /// </summary>
        [Description("收费单")]
        Charge = 1,
        /// <summary>
        /// 正式磅单
        /// </summary>
        [Description("正式磅单")]
        Weight = 2,
        /// <summary>
        /// 临时磅单
        /// </summary>
        [Description("临时磅单")]
        TemporaryWeight = 3,
        /// <summary>
        /// 财务结算
        /// </summary>
        [Description("财务结算")]
        FinanceSettle = 4,
        /// <summary>
        /// 计量方
        /// </summary>
        [Description("计量方")]
        Measure=5,
        /// <summary>
        /// 重印磅单
        /// </summary>
        [Description("重印磅单")]
        ReWeight=6,
        /// <summary>
        /// 充值单
        /// </summary>
        [Description("充值单")]
        Recharge = 7,
    }

    /// <summary>
    /// 序列号编码
    /// </summary>
    public enum SeqCode
    {
        /// <summary>
        /// IC卡
        /// </summary>
        Card,
        /// <summary>
        /// 客户
        /// </summary>
        Customer,
        /// <summary>
        /// 计划单
        /// </summary>
        Plan,
        /// <summary>
        /// 任务
        /// </summary>
        Task,
        /// <summary>
        /// 称重
        /// </summary>
        Weight,
        /// <summary>
        /// 临时称重
        /// </summary>
        WeightTemp,
        /// <summary>
        /// 支付
        /// </summary>
        Pay,
        /// <summary>
        /// 质检单
        /// </summary>
        Qc,
        /// <summary>
        /// 充值
        /// </summary>
        Recharge,
        /// <summary>
        /// 财务结算
        /// </summary>
        Settle
    }

    /// <summary>
    /// 称重类别
    /// </summary>
    public enum WeightType
    {
        /// <summary>
        /// 皮重
        /// </summary>
        Tare = 1,
        /// <summary>
        /// 毛重
        /// </summary>
        Gross = 2
    }

    /// <summary>
    /// 称重方式
    /// </summary>
    public enum WeightWay 
    {
        /// <summary>
        /// 人工称重
        /// </summary>
        People,
        /// <summary>
        /// 无人值守
        /// </summary>
        Nobody,
        /// <summary>
        /// 模拟称重
        /// </summary>
        SimulateWeight,
        SimpleAuto
    }

    /// <summary>
    /// 系统配置
    /// </summary>
    public enum SysConfig
    {
        /// <summary>
        /// 视频通道
        /// </summary>
        VideoChannel
    }

    /// <summary>
    /// 日期类别
    /// </summary>
    public enum DateSummaryType
    {
        /// <summary>
        /// 日
        /// </summary>
        Day = 0,
        /// <summary>
        /// 周
        /// </summary>
        Week = 1,
        /// <summary>
        /// 月
        /// </summary>
        Month = 2,
        /// <summary>
        /// 季度
        /// </summary>
        Quanter = 3,
        /// <summary>
        /// 年
        /// </summary>
        Year = 4,
        /// <summary>
        /// 自定义
        /// </summary>
        Custom = 5
    }

    public enum DateTypeNew {
        day,
        week, 
        month, 
        year   
    }
    /// <summary>
    /// 停止位
    /// </summary>
    public enum StopBits {
        [Description("无")]
        None,
        [Description("1")]
        One,
        [Description("2")]
        Two,
        [Description("1.5")]
        OnePointFive
    }
    /// <summary>
    /// 校验位
    /// </summary>
    public enum Parity {
        [Description("无")]
        None,
        [Description("奇校验")]
        Odd,
        [Description("偶校验")]
        Even,
        [Description("奇偶校验")]
        Mark,
        [Description("外校验")]
        Space
    }
    public enum LedVersionType {
        [Description("T3")]
        T3,
        [Description("T4")]
        T4,
        [Description("龙旗")]
        LQ
    }
    public enum CheckDateType {
        [Description("开始时间")]
        CreateTime,
        [Description("毛重时间")]
        GrossTime,
        [Description("皮重时间")]
        TareTime,
        [Description("结束时间")]
        FinishTime
    }
    public enum CheckDate {
        [Description("今天")]
        ToDay,
        [Description("昨天")]
        Yesterday,
        [Description("7天")]
        Week, 
        [Description("30天")]
        Month
    }
    public static class EnumExtensions {
        public static string toDescription(this System.Enum value) {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}

