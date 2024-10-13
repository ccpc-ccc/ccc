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
        /// <summary>
        /// 计重方式：People 人工计重  Nobody 无人职守
        /// </summary>
        public string MeasureFun { get; set; }
        /// <summary>
        /// 身份证识别器设置
        /// </summary>
        public IdCardCfg IdCard { get; set; }
        /// <summary>
        /// 无人职守称重设置
        /// </summary>
        public NobodyWeightCfg NobodyWeight { get; set; }
        /// <summary>
        /// 1号仪表配置
        /// </summary>
        public DeviceCfg Device1 { get; set; }
        /// <summary>
        /// 2号仪表配置
        /// </summary>
        public DeviceCfg Device2 { get; set; }
        public PeopleWeightCfg PeopleWeight { get; set; }
        /// <summary>
        /// 二维码设置
        /// </summary>
        public QrCodeCfg QrCode { get; set; }
        /// <summary>
        /// 启用读卡器
        /// </summary>
        public bool StartReadCard { get; set; }

        /// <summary>
        /// 读卡周期
        /// </summary>
        public decimal ReadCardCycle { get; set; }

        /// <summary>
        /// 启用车牌识别
        /// </summary>
        public bool StartCarNoRecognition { get; set; }

        /// <summary>
        /// 启用视频
        /// </summary>
        public bool StartVideo { get; set; }
        
        public CarNoRecognitionCfg CarNoRecognition { get; set; }
        public PrintCfg Print { get; set; }
        public CarNoCfg CarNo { get; set; }
        public TransferCfg Transfer { get; set; }
        //public WeightNoCfg WeightNo { get; set; }
        public WeightCfg Weight { get; set; } 
        public OverWeightCfg OverWeight { get; set; }
        public FinanceSettleCfg FinanceSettle { get; set; }
        public List<ReadCardCfg> LstReadCard { get; set; }
        public WeightSearchCfg WeightSearch { get; set; }
        public WeightControlCfg WeightControl { get; set; }
        public LaunchCfg Launch { get; set; }
        public PageCfg Page { get; set; }
        public VideoCfg Video { get; set; }
        public VideoDeviceCfg[] VideoDevices { get; set; }
        public WriteCardCfg WriteCard { get; set; }
        /// <summary>
        /// 邮件设置
        /// </summary>
        public EmailCfg emailCfg { get; set; }
        /// <summary>
        /// 重量稳定规则设置
        /// </summary>
        public WeightStableCfg WeightStable { get; set; }
        public SysCfg()
        {
            IdCard = new IdCardCfg();
            Print = new PrintCfg();
            CarNo = new CarNoCfg();
            Transfer = new TransferCfg();
            QrCode = new QrCodeCfg();
            Device1=new DeviceCfg();
            Device2=new DeviceCfg();
            LstReadCard = new List<ReadCardCfg>();
            CarNoRecognition = new CarNoRecognitionCfg(); 
            OverWeight = new OverWeightCfg();
            NobodyWeight = new NobodyWeightCfg();
            PeopleWeight = new PeopleWeightCfg();
            Weight = new WeightCfg();
            FinanceSettle = new FinanceSettleCfg();
            WeightSearch = new WeightSearchCfg();
            Launch = new LaunchCfg();
            Page = new PageCfg();
            WeightControl = new WeightControlCfg();
            Video = new VideoCfg();
            WeightStable = new WeightStableCfg();
            WriteCard = new WriteCardCfg();
            VideoDevices=new VideoDeviceCfg[4] {new VideoDeviceCfg(), new VideoDeviceCfg(), new VideoDeviceCfg(), new VideoDeviceCfg() };
            emailCfg=new EmailCfg();
        }
    }
}
