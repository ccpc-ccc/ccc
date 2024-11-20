using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Screen;
using YF.MWS.Metadata.Transfer;
using YF.MWS.Util;
using YF.MWS.Win.Core;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.MWS.Win.Util.Screen;
using YF.Utility.Log;
using YF.Utility;
using System.Windows.Forms;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Win.Util.CarPlate;
using YF.MWS.Win.View.Extend;
using System.IO;
using YF.MWS.Metadata.CarPlate;
using YF.MWS.Metadata.Query;
using System.Threading.Tasks;
using YF.MWS.BaseMetadata;
using YF.MWS.Win.Uc.Weight;
using YF.MWS.CacheService;
using YF.MWS.Metadata.Event;
using YF.Utility.Data;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using System.Drawing;
using YF.MWS.Db.Server;
using DevExpress.XtraRichEdit.Model;

namespace YF.MWS.Win.View.Weight
{
    /// <summary>
    /// 刷卡称重
    /// </summary>
    public partial class FrmWeight
    {
        private ICustomerService customerService = new CustomerService();
        private IStatementService statementSerivice = new StatementService();
        private ITaskService taskService = new TaskService();
        private ILogService logService = new LogService();
        private IPlanService planService = new PlanService();
        private IWebWeightService webWeightService = new WebWeightService("");
        private IWebWeightProcessService webWeightProcessService = new WebWeightProcessService();
        private IWeightProcessService weightProcessService = new WeightProcessService();
        private BWeight currentWeight = null;
        /// <summary>
        /// 当前的称重方式
        /// </summary>
        private WeightWay currentWeighWay = WeightWay.People;
        /// <summary>
        /// 重量归零
        /// </summary>
        private bool returnZero = true;
        private decimal returnZeroWeightValue = 0;
        private IPayService payService = new PayService();
        private ISyncService sysncService = new SyncService();
        private ICardService cardService = new CardService();
        private bool isNewAutoSimpleWeight = true;
        private bool startScreen = false;
        private bool isSendingAd = false;
        private LXCfg lxCfg = null;
        private LXLedUtil lxLedUtil = null;
        private bool startVideo = false;
        private bool startReadCard=false;
        private bool startWeightProcessCfg = false;
        private WeightProcess currentWeightProcess = WeightProcess.Two;
        private string sysCfgPath = Path.Combine(Application.StartupPath, "SysCfg.xml");
        private bool startPad = false;
        private bool finishPadInput = false;
        private bool hasReadCard = false;
        private string currentWaterMark = string.Empty;
        private WComboBoxEdit wbPayBizType;
        private WeightProcessTriggerType weightProcessTrigger = WeightProcessTriggerType.CarRecognition;
        /// <summary>
        /// 道闸控制方式 modbus控制箱 car 车牌识别控制
        /// </summary>
        private string currentGateControl = "Modbus";
        //private Db.Server.ServerEntity serverWeight = null;

        /// <summary>
        /// 启用车牌识别
        /// </summary>
        private bool startCarRecognition = false;
        /// <summary>
        /// 1#ASB(New)识别仪
        /// </summary>
        private ASBNewUtil asbNewRecognizerLeft;
        /// <summary>
        /// 2#ASB(New)识别仪
        /// </summary>
        private ASBNewUtil asbNewRecognizerRight;
        private LoadUnfinishWeightType loadUnfinishWeight = LoadUnfinishWeightType.None;
        /// <summary>
        /// 识别时间间隔(分钟)
        /// </summary>
        private int recognitionTimeSpan=0;
        /// <summary>
        /// 启用同一车牌号识别控制
        /// </summary>
        private bool startSameCarNoControl = false;
        /// <summary>
        /// 车牌识别结果集合
        /// </summary>
        private List<RecognitionResult> lstRecognitionResult = new List<RecognitionResult>();
        /// <summary>
        /// 启用磅单收费
        /// </summary>
        private bool startWeightPay = false;
        /// <summary>
        /// 当前收费规则
        /// </summary>
        private ChargeRuleType currentChargeRule = ChargeRuleType.Custom;
        /// <summary>
        /// 当前触发收费条件
        /// </summary>
        private ChargeTriggerCondtionType currentChargeTriggerCondtion = ChargeTriggerCondtionType.NewWeight;
        /// <summary>
        /// 当前收费模式
        /// </summary>
        private ChargeMode currentChargeMode = ChargeMode.ControlFormula;
        //是否启用语音
        private bool startVoice = false;
        /// <summary>
        /// 启用红绿灯
        /// </summary>
        private bool startTrafficLight = false;
        private CarLimitScopeType currentLimitScope = CarLimitScopeType.None;
        private string currentCarNo = string.Empty;
        private bool isCarRecognitionOutputVideo = false;
        /// <summary>
        /// 最低可信重量
        /// </summary>
        private decimal minCredibleWeight = 0;
        /// <summary>
        /// 重量稳定偏差(Kg)
        /// </summary>
        public decimal weightDeviation = 0;
        /// <summary>
        /// 采样重量个数
        /// </summary>
        public int samplingCount = 0;
        /// <summary>
        /// 是否正在自动保存磅单
        /// </summary>
        private bool isAutoSaving = false;
        private List<ILedScreen> lstScreen = new List<ILedScreen>();
        private int startScreenCount = 2;
        /// <summary>
        /// 空闲多少分钟后显示广告
        /// </summary>
        private int idleMinutesShowAd = 0;
        private DateTime lastIdleTime = DateTime.Now;
        /// <summary>
        /// 是否显示广告
        /// </summary>
        private bool showAd = false;
        /// <summary>
        /// 车牌是否输出到大屏幕
        /// </summary>
        private bool isCarNoOutputScreen = false;
        /// <summary>
        /// 启用道闸
        /// </summary>
        private bool startBoundGate = false;
        private string lastSyncWeightId = string.Empty;
        /// <summary>
        /// 是否正在执行同步操作
        /// </summary>
        private bool isSyncing = false;
        /// <summary>
        /// 是否正在执行自动任务
        /// </summary>
        private bool isAutoTaskRuning = false;
        private object lockAutoObj = new object();
        /// <summary>
        /// IC卡号生成方式
        /// </summary>
        private CardIdGenerateMode generateMode;
        /// <summary>
        /// 读卡器类别
        /// </summary>
        private ReadCardType cardType = ReadCardType.Short;
        /// <summary>
        /// 是否开启磅单输入项自动保存(不存在对应的基础数据项的前提下)
        /// </summary>
        private bool startInputItemAutoSave;
        /// <summary>
        /// 重量稳定时LED显示设置
        /// </summary>
        private ShowWeightStableCfg showWeightStableCfg = null;
        /// <summary>
        /// 是否启用在线支付
        /// </summary>
        private bool startOnlinePay = false;
        private bool paySuccess = true;
        private CarNoOutMode carNoOutMode = CarNoOutMode.Whole;
        private int carNoOutLength = 0;
        /// <summary>
        /// 当前稳定重量
        /// </summary>
        private decimal currentStableWeight = 0;
        private object autoSaveLockObj = new object();
        /// <summary>
        /// 自动打印PDF
        /// </summary>
        private bool printPhoto = false;
        private bool autoPrintWeight = false;
        /// <summary>
        /// 启用磅单打印次数限制
        /// </summary>
        public bool startPrintCountLimit = false;
        /// <summary>
        /// 每个磅单最多打印次数
        /// </summary>
        public int maxPrintCount = 0;
        private string currentCardNo = string.Empty;
        private QPlanCard currentCard = null;
        /// <summary>
        /// 车牌识别条件
        /// </summary>
        private CarNoRecCondition currentRecCondition = CarNoRecCondition.WeightGeZero;
        /// <summary>
        /// 启用车牌识别校准
        /// </summary>
        private bool startCarRecAdjust = false;
        /// <summary>
        /// 是否启用控制箱
        /// </summary>
        private bool startModBus = false;
        //private SendReturnZeroProcessType sendReturnZeroProcess = SendReturnZeroProcessType.CarRecognized;
        //private bool startSendReturnZero = false;
        //private byte[] byteReturnZeroCmd = null;
        private bool isReadingCard = false;
        private bool startCustomerBalanceLimit = false;
        /// <summary>
        /// 启用IC卡验证车牌
        /// </summary>
        private bool startValidateCarWithCard = false;
        /// <summary>
        /// 当前识别仪类型
        /// </summary>
        private CarPlateRecognizerType currentCarPlateRecognizer = CarPlateRecognizerType.None;
        private string companyId = string.Empty;
        /// <summary>
        /// 是否启用毛皮重转换
        /// </summary>
        private bool startGrossTareTransform = false;
        /// <summary>
        /// 毛皮是否已转换
        /// </summary>
        private bool grossTareTransformed = false;
        /// <summary>
        /// 是否能手动打印磅单
        /// </summary>
        private bool canManualPrint = false;
        private bool canPreview = false;
        /// <summary>
        /// 当前支付方式
        /// </summary>
        private PayPluginType currentPayType = PayPluginType.WeiXinPayNative;
        private bool startInfrared = false;
        private object lockDeviceState = new object();
        private bool isRunningState = false;
        /// <summary>
        /// 开启首次过磅存皮重
        /// </summary>
        private bool autoSaveTareWeight = false;
        /// <summary>
        /// 开启自动加载皮重
        /// </summary>
        private bool autoLoadTareWeight = false;
        /// <summary>
        /// 一次过磅是否启用手动保存
        /// </summary>
        private bool startSaveWithManualFirst = false;
        /// <summary>
        /// 二次过磅是否启用手动保存
        /// </summary>
        private bool startSaveWithManualSecond = false;
        /// <summary>
        /// 是否启用自动重置
        /// </summary>
        private bool startAutoReset = false;
        /// <summary>
        /// 空闲分钟数
        /// </summary>
        private decimal idleMinutes = 0;
        /// <summary>
        /// 计量流程方式
        /// </summary>
        private MeasureProcessMode processMode = MeasureProcessMode.FirstGross;
        private MeasureProcessMode oldProcessMode = MeasureProcessMode.FirstGross;
        /// <summary>
        /// 上次磅单流程开始时间
        /// </summary>
        private DateTime lastWeightStartTime = DateTime.Now;
        /// <summary>
        /// 正式磅单打印机名称
        /// </summary>
        private string weightPrinterName = null;
        /// <summary>
        /// 临时磅单打印机名称
        /// </summary>
        private string weightTempPrinterName = null;
        /// <summary>
        /// 是否启用附加打印临时磅单
        /// </summary>
        private bool appendPrintTemp = false;
        /// <summary>
        /// 开启自动作废未完成磅单
        /// </summary>
        private bool startAutoInvalid = false;
        /// <summary>
        /// 未完成磅单的过期时间(小时)
        /// </summary>
        private int unfinishedTimeOut = 0;
        /// <summary>
        /// 磅单号生成方式
        /// </summary>
        private BaseMetadata.FinishState weightNoGenerateMode = BaseMetadata.FinishState.Unfinished;
        /// <summary>
        /// 启用同一IC卡读卡限制
        /// </summary>
        private bool startSameCardNoControl = false;
        /// <summary>
        /// 同一IC卡读卡时间间隔(分钟)
        /// </summary>
        private int readCardTimeSpan = 0;
        /// <summary>
        /// IC卡读卡结果集合
        /// </summary>
        private List<ReadCardResult> lstReadCardResult = new List<ReadCardResult>();
        /// <summary>
        /// 优先使用余额支付
        /// </summary>
        private bool balancePayFirst = false;
        /// <summary>
        /// 付款二维码类型
        /// </summary>
        private PayCodeType payCode = PayCodeType.Dynamic;
        private bool needGetPayState = false;
        /// <summary>
        /// 开启身份证识别
        /// </summary>
        private bool startIdCardReader = false;
        /// <summary>
        /// 身份证识别器
        /// </summary>
        private IdCardReader idCardReader = null;
        private bool openCardReader = false;
        /// <summary>
        /// 是否获取到身份证号
        /// </summary>
        private bool hasGetIdCardNo = false;
        /// <summary>
        /// 第1组红灯是否亮
        /// </summary>
        private bool firstLightGroupRed = true;
        /// <summary>
        /// 第2组红灯是否亮
        /// </summary>
        private bool secondLightGroupRed = true;
        /// <summary>
        /// 启用计划单限制功能
        /// </summary>
        private bool startPlan = false;
        /// <summary>
        /// 启用双击加载未完成磅单
        /// </summary>
        private bool startDoubleClickUnfinished = false;
        private BPlan currentPlan = null;
        /// <summary>
        /// 启用身份证信息生成客户单位
        /// </summary>
        private bool startGenerateCustomer = false;
        /// <summary>
        /// 读卡周期(秒)
        /// </summary>
        private decimal readCardCycle = 0;

        private void AddPrintWaterMarkTask(string watermark) 
        {
            BTask task = new BTask();
            task.TaskContent = watermark;
            task.TaskType = TaskType.PrintWatermark.ToString();
            task.TaskState = 0;
            task.Id = YF.MWS.Util.Utility.GetGuid();
            taskService.AddTask(task);
        }

        private void InitConfig()
        {
            loginCfg = YF.Utility.Serialization.XmlUtil.Deserialize<LoginCfg>(loginCfgXml);
            if (Cfg != null)
            {
                startVideo = Cfg.StartVideo;
                startReadCard = Cfg.StartReadCard;
                readCardCycle = Cfg.ReadCardCycle;
                startCarRecognition = Cfg.StartCarNoRecognition;
                if (Auth != null) 
                {
                    if (!Auth.StartVideo) 
                    {
                        startVideo = false;
                    }
                    if (!Auth.ReadCard)
                    {
                        startReadCard = false;
                    }
                    if (!Auth.CarNoRecognition) 
                    {
                        startCarRecognition = false;
                    }
                }
                if (Cfg.CarNo != null) 
                {
                    autoSaveTareWeight = Cfg.CarNo.AutoSaveTareWeight;
                    autoLoadTareWeight = Cfg.CarNo.AutoLoadTareWeight;
                }
                if (Cfg.Print != null)
                {
                    weightPrinterName = Cfg.Print.WeightPrinterName;
                    weightTempPrinterName = Cfg.Print.WeightTempPrinterName;
                    appendPrintTemp = Cfg.Print.AppendPrintTemp;
                }
                if (Cfg.CarNoRecognition != null) 
                {
                    recognitionTimeSpan = Cfg.CarNoRecognition.RecognitionTimeSpan;
                    startSameCarNoControl = Cfg.CarNoRecognition.StartSameCarNoControl;
                    isCarRecognitionOutputVideo = Cfg.CarNoRecognition.OutputVideo;
                    isCarNoOutputScreen = Cfg.CarNoRecognition.OutputScreen;
                    currentRecCondition = Cfg.CarNoRecognition.RecCondition;
                    startCarRecAdjust = Cfg.CarNoRecognition.StartCarRecAdjust;
                    if (startCarRecognition)
                    {
                        currentCarPlateRecognizer = Cfg.CarNoRecognition.Recognition.ToEnum<CarPlateRecognizerType>();
                    }
                }
                if (Cfg.IdCard != null)
                {
                    startGenerateCustomer = Cfg.IdCard.StartGenerateCustomer;
                    startIdCardReader = Cfg.IdCard.Start;
                    if (startIdCardReader)
                        idCardReader = new IdCardReader(Cfg.IdCard);
                    if (idCardReader != null)
                    {
                        openCardReader = idCardReader.OpenSuccess;
                        ShowWeightStateTip(string.Format("连接身份证读卡器{0}", idCardReader.OpenSuccess ? "成功" : "失败"));
                    }
                }
                if (Cfg.MeasureFun != null)
                {
                    currentWeighWay = Cfg.MeasureFun.ToEnum<WeightWay>();
                }
                if (Cfg.Print != null)
                {
                    if(Cfg.Print.Mode== PrintMode.Auto)
                    {
                        autoPrintWeight = true;
                    }
                    printPhoto = Cfg.Print.PrintPhoto;
                    startPrintCountLimit = Cfg.Print.StartPrintCountLimit;
                    maxPrintCount = Cfg.Print.MaxPrintCount;
                }
                if (Cfg.Weight != null)
                {
                    startDoubleClickUnfinished = Cfg.Weight.StartDoubleClickUnfinished;
                    startPlan = Cfg.Weight.StartPlan;
                    payCode = Cfg.Weight.PayCode;
                    weightNoGenerateMode = Cfg.Weight.WeightNoGenerateMode;
                    unfinishedTimeOut = Cfg.Weight.UnfinishedTimeOut;
                    startAutoInvalid = Cfg.Weight.StartAutoInvalid;
                    if (unfinishedTimeOut <= 0)
                        unfinishedTimeOut = 24;
                    startAutoReset = Cfg.Weight.StartAutoReset;
                    idleMinutes = Cfg.Weight.IdleMinutes;
                    if (idleMinutes <= 0)
                        idleMinutes = 2;
                    processMode = Cfg.Weight.ProcessMode;
                    oldProcessMode = Cfg.Weight.ProcessMode;
                    startInputItemAutoSave = Cfg.Weight.StartInputItemAutoSave;
                    loadUnfinishWeight = Cfg.Weight.LoadUnfinishWeight;
                    startWeightProcessCfg = Cfg.Weight.StartWeightProcessCfg;
                    currentWeightProcess = Cfg.Weight.Process;
                    weightProcessTrigger = Cfg.Weight.WeightProcessTrigger;
                    //if (weightProcessTrigger == WeightProcessTriggerType.Pad || weightProcessTrigger == WeightProcessTriggerType.WeightStable) 
                    {
                        returnZero = true;
                    }
                    startVoice = Cfg.Weight.StartVoicePrompt;
                    currentLimitScope = Cfg.Weight.LimitScope;
                    startOnlinePay = Cfg.Weight.StartOnlinePay;
                    startModBus = Cfg.Weight.StartModBus;
                    startCustomerBalanceLimit = Cfg.Weight.StartCustomerBalanceLimit;
                    startValidateCarWithCard = Cfg.Weight.StartValidateCarWithCard;
                    rgWeightProcess.EditValue = currentWeightProcess.ToString();
                    rgWeightProcess.Enabled = startWeightProcessCfg;
                    startGrossTareTransform = Cfg.Weight.GrossTareTransform;
                    currentPayType = Cfg.Weight.PayType;
                    readCardTimeSpan = Cfg.Weight.ReadCardTimeSpan;
                    if (readCardTimeSpan == 0)
                        readCardTimeSpan = 2;
                    startSameCardNoControl = Cfg.Weight.StartSameCardNoControl;
                }
                if (Cfg.WeightStable != null) 
                {
                    minCredibleWeight = Cfg.WeightStable.MinCredibleWeight;
                    minCredibleWeight = UnitUtil.GetValue(currentDeviceCfg.SUnit, "Kg", minCredibleWeight);
                    weightDeviation = Cfg.WeightStable.WeightDeviation;
                    weightDeviation = UnitUtil.GetValue(currentDeviceCfg.SUnit,"Kg",  weightDeviation);
                    samplingCount = Cfg.WeightStable.SamplingCount;
                }
                if (Cfg.CarNo != null) 
                {
                    carNoOutLength = Cfg.CarNo.Length;
                    carNoOutMode = Cfg.CarNo.OutMode;
                }
                if (Cfg.NobodyWeight != null)
                {
                    startSaveWithManualFirst = Cfg.NobodyWeight.StartSaveWithManualFirst;
                    startSaveWithManualSecond = Cfg.NobodyWeight.StartSaveWithManualSecond;
                    currentGateControl = Cfg.NobodyWeight.GateControl;
                    startTrafficLight = Cfg.NobodyWeight.StartTrafficLight;
                    startBoundGate = Cfg.NobodyWeight.StartBoundGate;
                    startInfrared = Cfg.NobodyWeight.StartInfrared;
                    returnZeroWeightValue = UnitUtil.GetValue("Ton", currentDeviceCfg.SUnit, Cfg.NobodyWeight.MaxReturnZeroWeightValue);
                }
                gpDeviceGate1.Visible = Cfg.NobodyWeight.StartBoundGate;
                gpDeviceGate2.Visible = Cfg.NobodyWeight.StartBoundGate;
                gpLight1.Visible = Cfg.NobodyWeight.StartTrafficLight;
                gpLight2.Visible = Cfg.NobodyWeight.StartTrafficLight;
            }
            /*if (CurrentClient.Instance.IsSimulateWeight)
            {
                currentWeighWay = WeightWay.SimulateWeight;
            }*/
            lblWeightType.Text = YF.MWS.Util.Utility.GetWeightWayCaption(currentWeighWay);
            if (currentWeighWay == WeightWay.People || currentWeighWay == WeightWay.SimulateWeight)
            {
                showValidateMessage = true;
            }
            for (int i = 0; i < startScreenCount; i++) 
            {
                LXCfg cfg = CfgUtil.GetLXCfg(i + 1);
                if (cfg != null && cfg.Start) 
                {
                    startScreen = true;
                    showWeightStableCfg = cfg.LedShow.ShowWeightStable;
                    if (cfg.LedShow != null) 
                    {
                        idleMinutesShowAd = cfg.LedShow.IdleMinutesShowAd;
                        if (idleMinutesShowAd == 0)
                            idleMinutesShowAd = 3;
                        showAd = cfg.LedShow.ShowAd;
                    }
                    ILedScreen screen = new LXScreen(cfg);
                    lstScreen.Add(screen);
                }
            }
        }

        private void InitCarRecognition() 
        {
            if (startCarRecognition) //启用车牌识别一体机
            {
                if (Cfg.CarNoRecognition != null)
                {
                    try
                    {
                        ShowWeightStateTip("正在连接车牌识别仪");
                        if (Cfg.CarNoRecognition.Recognition == "DH")
                        {
                            string ip = Cfg.CarNoRecognition.IP1;
                            UInt16 port = (UInt16)Cfg.CarNoRecognition.Port1;
                            string userName = Cfg.CarNoRecognition.UserName1;
                            string password = Cfg.CarNoRecognition.Password1;
                            dhRecognizerLeft = new DHCarPlateUtil(ip, port, userName, password);
                            //dhRecognizerLeft.DeviceReconnected += Recognizer_DeviceReconnected;
                            dhRecognizerLeft.No = 1;
                            dhRecognizerLeft.RecognizePlate = new DHCarPlateUtil.RecognizePlateDelegate(DHRecognizePlate);
                            if (!string.IsNullOrEmpty(Cfg.CarNoRecognition.IP2))
                            {
                                ip = Cfg.CarNoRecognition.IP2;
                                port = (UInt16)Cfg.CarNoRecognition.Port2;
                                userName = Cfg.CarNoRecognition.UserName2;
                                password = Cfg.CarNoRecognition.Password2;
                                dhRecognizerRight = new DHCarPlateUtil(ip, port, userName, password);
                                dhRecognizerRight.RecognizePlate = new DHCarPlateUtil.RecognizePlateDelegate(DHRecognizePlate);
                                //dhRecognizerRight.DeviceReconnected += Recognizer_DeviceReconnected;
                                dhRecognizerRight.No = 2;
                            }
                        }
                        else if (Cfg.CarNoRecognition.Recognition == "HX")
                        {
                            string ip = Cfg.CarNoRecognition.IP1;
                            UInt16 port = (UInt16)Cfg.CarNoRecognition.Port1;
                            string userName = Cfg.CarNoRecognition.UserName1;
                            string password = Cfg.CarNoRecognition.Password1;

                            hxRecognizerLeft = new HXPlateRecognizer(ip, isCarRecognitionOutputVideo,null);
                            hxRecognizerLeft.RecognizePlate = new HXPlateRecognizer.RecognizePlateDelegate(CarRecognize);
                            if(hxRecognizerLeft.LoginSuccess)
                                ShowWeightStateTip("成功连接1#车牌识别仪");
                            else
                                ShowWeightStateTip("连接1#车牌识别仪失败");
                            if (!string.IsNullOrEmpty(Cfg.CarNoRecognition.IP2))
                            {
                                ip = Cfg.CarNoRecognition.IP2;
                                port = (UInt16)Cfg.CarNoRecognition.Port2;
                                userName = Cfg.CarNoRecognition.UserName2;
                                password = Cfg.CarNoRecognition.Password2;
                                hxRecognizerRight = new HXPlateRecognizer(ip, isCarRecognitionOutputVideo, null);
                                hxRecognizerRight.RecognizePlate = new HXPlateRecognizer.RecognizePlateDelegate(CarRecognize);
                                if (hxRecognizerRight.LoginSuccess)
                                    ShowWeightStateTip("成功连接2#车牌识别仪");
                                else
                                    ShowWeightStateTip("连接2#车牌识别仪失败");
                            }
                        }
                        else if (Cfg.CarNoRecognition.Recognition == "QY")
                        {
                            string ip = Cfg.CarNoRecognition.IP1;
                            UInt16 port = (UInt16)Cfg.CarNoRecognition.Port1;
                            string userName = Cfg.CarNoRecognition.UserName1;
                            string password = Cfg.CarNoRecognition.Password1;

                            qyRecognizerLeft = new QianYiPlateRecognizer(ip, null);
                            qyRecognizerLeft.RecognizePlate = new QianYiPlateRecognizer.RecognizePlateDelegate(CarRecognize);
                            if (qyRecognizerLeft.LoginSuccess)
                                ShowWeightStateTip("成功连接QY1#车牌识别仪");
                            else
                                ShowWeightStateTip("连接QY1#车牌识别仪失败");
                            if (!string.IsNullOrEmpty(Cfg.CarNoRecognition.IP2))
                            {
                                ip = Cfg.CarNoRecognition.IP2;
                                port = (UInt16)Cfg.CarNoRecognition.Port2;
                                userName = Cfg.CarNoRecognition.UserName2;
                                password = Cfg.CarNoRecognition.Password2;
                                qyRecognizerRight = new QianYiPlateRecognizer(ip, null);
                                qyRecognizerRight.RecognizePlate = new QianYiPlateRecognizer.RecognizePlateDelegate(CarRecognize);
                                if (qyRecognizerRight.LoginSuccess)
                                    ShowWeightStateTip("成功连接QY2#车牌识别仪");
                                else
                                    ShowWeightStateTip("连接QY2#车牌识别仪失败");
                            }
                        }
                        else if (Cfg.CarNoRecognition.Recognition == "VZ")
                        {
                            string ip = Cfg.CarNoRecognition.IP1;
                            UInt16 port = (UInt16)Cfg.CarNoRecognition.Port1;
                            string userName = Cfg.CarNoRecognition.UserName1;
                            string password = Cfg.CarNoRecognition.Password1;
                            vzRecognizerLeft = new VzCarPlateRecognizer(ip, port, userName, password, isCarRecognitionOutputVideo, null);
                            vzRecognizerLeft.RecognizePlate = new VzCarPlateRecognizer.RecognizePlateDelegate(CarRecognize);
                            if (vzRecognizerLeft.IsSuccess)
                            {
                                ShowWeightStateTip("成功连接1#车牌识别仪");
                            }
                            if (!string.IsNullOrEmpty(Cfg.CarNoRecognition.IP2))
                            {
                                ip = Cfg.CarNoRecognition.IP2;
                                port = (UInt16)Cfg.CarNoRecognition.Port2;
                                userName = Cfg.CarNoRecognition.UserName2;
                                password = Cfg.CarNoRecognition.Password2;
                                vzRecognizerRight = new VzCarPlateRecognizer(ip, port, userName, password, isCarRecognitionOutputVideo, null);
                                vzRecognizerRight.RecognizePlate = new VzCarPlateRecognizer.RecognizePlateDelegate(CarRecognize);
                                if (vzRecognizerRight.IsSuccess)
                                {
                                    ShowWeightStateTip("成功连接2#车牌识别仪");
                                }
                            }
                        }
                        else if (Cfg.CarNoRecognition.Recognition == "HK")
                        {
                            string ip = Cfg.CarNoRecognition.IP1;
                            UInt16 port = (UInt16)Cfg.CarNoRecognition.Port1;
                            string userName = Cfg.CarNoRecognition.UserName1;
                            string password = Cfg.CarNoRecognition.Password1;
                            hkRecognizerLeft = new HKCarPlateRecognizer(ip, 1, port, userName, password, isCarRecognitionOutputVideo, null);
                            hkRecognizerLeft.RecognizePlate = new HKCarPlateRecognizer.RecognizePlateDelegate(CarRecognize);
                            if (!string.IsNullOrEmpty(Cfg.CarNoRecognition.IP2))
                            {
                                ip = Cfg.CarNoRecognition.IP2;
                                port = (UInt16)Cfg.CarNoRecognition.Port2;
                                userName = Cfg.CarNoRecognition.UserName2;
                                password = Cfg.CarNoRecognition.Password2;
                                hkRecognizerRight = new HKCarPlateRecognizer(ip, 2, port, userName, password, isCarRecognitionOutputVideo, null);
                                hkRecognizerRight.RecognizePlate = new HKCarPlateRecognizer.RecognizePlateDelegate(CarRecognize);
                            }
                        }
                        else if (Cfg.CarNoRecognition.Recognition == "KHT")
                        {
                            string ip = Cfg.CarNoRecognition.IP1;
                            UInt16 port = (UInt16)Cfg.CarNoRecognition.Port1;
                            //初始化1#快号通车牌识别仪
                            this.khtRecognizerLeft = new KHTUtil(ip, port);
                            this.khtRecognizerLeft.RecognizePlate = new KHTUtil.RecognizePlateDelegate(CarRecognize);
                            if (!string.IsNullOrEmpty(Cfg.CarNoRecognition.IP2))
                            {
                                ip = Cfg.CarNoRecognition.IP2;
                                port = (UInt16)Cfg.CarNoRecognition.Port2;
                                //初始化2#快号通车牌识别仪
                                this.khtRecognizerRight = new KHTUtil(ip, port);
                                this.khtRecognizerRight.RecognizePlate = new KHTUtil.RecognizePlateDelegate(CarRecognize);
                            }
                        }
                        else if (Cfg.CarNoRecognition.Recognition == "KHTNew")
                        {
                            string ipFirst = Cfg.CarNoRecognition.IP1;
                            string ipSecond = Cfg.CarNoRecognition.IP2;
                            khtNewRecognizer = new KHTNewUtil(ipFirst, ipSecond);
                            khtNewRecognizer.RecognizePlate = new KHTNewUtil.RecognizePlateDelegate(CarRecognize);
                        }
                        else if (Cfg.CarNoRecognition.Recognition == "GQ")
                        {
                            Logger.Write("初始化GQ车牌识别仪");
                            //初始化1#高清车牌识别仪
                            this.gqRecognizerLeft = new GQUtil();
                            this.gqRecognizerLeft.RecognizePlate = new GQUtil.RecognizePlateDelegate(this.GQRecognizePlate);
                                //初始化2#高清车牌识别仪
                                this.gqRecognizerRight = new GQUtil();
                                this.gqRecognizerRight.RecognizePlate = new GQUtil.RecognizePlateDelegate(this.GQRecognizePlate);
                        }
                        else if (Cfg.CarNoRecognition.Recognition == "ASB_NEW")
                        {
                            Logger.Write("初始化ASB_NEW车牌识别仪");
                            //初始化1#高清车牌识别仪
                            string ip = Cfg.CarNoRecognition.IP1;
                            this.asbNewRecognizerLeft = new ASBNewUtil(ip);
                            this.asbNewRecognizerLeft.RecognizePlate = new ASBNewUtil.RecognizePlateDelegate(this.ASBRecognizePlate);
                                //初始化2#高清车牌识别仪
                                ip = Cfg.CarNoRecognition.IP2;
                                if (!string.IsNullOrEmpty(ip))
                                {
                                    this.asbNewRecognizerRight = new ASBNewUtil(ip);
                                    this.asbNewRecognizerRight.RecognizePlate = new ASBNewUtil.RecognizePlateDelegate(this.ASBRecognizePlate);
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteException(ex);
                    }
                }
            }
        }

        /// <summary>
        /// 车牌识别触发事件
        /// </summary>
        /// <param name="resInfo"></param>
        private void CarRecognize(PlateInfo resInfo)
        {
            try
            {
                if (hasGetCarNo&&GetCurrentWeight()>0)
                {
                    if (speecher != null) 
                    {
                        speecher.Speak("上个磅单流程尚未完成,不能识别新的车牌");
                    }
                    ShowWeightStateTip("上个磅单流程尚未完成,不能识别新的车牌");
                    return;
                }
                if (Cfg.Weight.CarAfter &&  GetCurrentWeight() <this.minWeightValue) { //转换成吨后再做比较
                    return;
                }
               /* if (currentRecCondition == CarNoRecCondition.WeightGeZero)
                {
                    if (leftWeightValue <= minWeightValue)
                    {
                        ShowWeightStateTip(string.Format("当前重量低于起磅重量{0},车牌未能识别", minWeightValue));
                        return;
                    }
                }
                if (currentRecCondition == CarNoRecCondition.WeightReturnZero)
                {
                    if (leftWeightValue > minWeightValue)
                    {
                        ShowWeightStateTip(string.Format("当前重量未归零车牌不能被识别"));
                        return;
                    }
                }*/
                string strIP = resInfo.IP;
                string strPlate = resInfo.Num.TrimEnd('\0');
                strPlate = GetCarNo(strPlate);
                txtCar.Text = strPlate;
                if (!string.IsNullOrEmpty(strPlate))
                {
                    ShowWeightStateTip("车牌("+strPlate+")已经识别");
                    hasGetCarNo = true;
                    if (weightProcessTrigger == WeightProcessTriggerType.CarRecognitionOrCard)
                    {
                        hasReadCard = true;
                    }
                    /*bool isValidated = ValidateCarNo(strPlate);
                    if (!isValidated)
                    {
                        hasGetCarNo = false;
                        if (weightProcessTrigger == WeightProcessTriggerType.CarRecognitionOrCard)
                        {
                            hasReadCard = false;
                        }
                        return;
                    }
                    if (currentLimitScope != CarLimitScopeType.None)
                    {
                        SCar currentCar = CarCacher.GetWithCarNo(strPlate);
                        bool canOpenEntrance = CanOpenEntranceGate(currentCar);
                        if (!canOpenEntrance)
                        {
                            hasGetCarNo = false;
                            if (weightProcessTrigger == WeightProcessTriggerType.CarRecognitionOrCard)
                            {
                                hasReadCard = false;
                            }
                            ShowWeightStateTip("车牌(" + strPlate + ")被限制称重");
                            return;
                        }
                    }*/
                    SendReturnZero(SendReturnZeroProcessType.CarRecognized);
                    //ClearWeightControl();
                    currentCarNo = strPlate;
                    returnZero = true;
                    lastWeightStartTime = DateTime.Now;
                    if (!string.IsNullOrEmpty(strIP))
                    {
                        if (strIP == Cfg.CarNoRecognition.IP1)
                        {
                            //1#车牌识别仪识别车牌
                            this.readerNo = 1;
                        }
                        if (strIP == Cfg.CarNoRecognition.IP2)
                        {
                            //2#车牌识别仪识别车牌
                            this.readerNo = 2;
                        }
                    }
                    //Logger.Write(string.Format("regeconize_result,ip:{0},no:{1},carNo:{2},hasGetCarNo:{3}", strIP, readerNo, strPlate,hasGetCarNo));
                    if (wlookCar != null)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            wlookCar.Text = strPlate;
                            wlookCar.CurrentValue = string.Empty;
                        }));
                    }
                    SendInfoToLed(WeightFlowType.CarNoRecognition,"车牌:"+strPlate);
                    if (startVoice)
                    {
                        speecher.Speak(voiceCfg.CarRecognition);
                    }
                    #region WeightWay.Nobody
                    if (currentWeighWay == WeightWay.Nobody)
                    {
                        //红灯灭绿灯亮
                        RedServerLight(readerNo);
                            //1#车牌识别仪识别车牌
                            this.OpenServerGate(this.readerNo);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        private void InitCardReader() 
        {
            //启用读卡器
            if (startReadCard)
            {
                ReadCardCfg cardCfg = Cfg.LstReadCard.Find(item => item.IsStart == true);
                if (cardCfg != null)
                {
                    cardType = cardCfg.Type;
                    if (cardCfg.Type == ReadCardType.Short)
                    {
                        InitShortReader();
                    }
                    else if (cardCfg.Type == ReadCardType.Remote)
                    {
                        InitRemoteReader();
                    }
                    generateMode = cardCfg.CardIdGenerate;
                }
            }
        }

        private void InitAllDevice()
        {
            InitScreen();
            InitPort();
            InitCardReader();
            InitCarRecognition();
        }

        private bool IsNeedOpenGateWhenSaved() 
        {
            bool isNeedOpen = true;
            //南昌版本采用的是单道闸替代双道闸,所以保存重量后不要开砸
            if (CurrentClient.Instance.VersionCode == VersionCodeType.NC) 
            {
                isNeedOpen = false;
            }
            return isNeedOpen;
        }

        private bool CanBalancePay(SCustomer customer, decimal amount)
        {
            bool canPay = false;
            if (customer != null && balancePayFirst)
            {
                decimal balance = customer.BalanceAmount - customer.MinBalanceAmount;
                if (balance >= amount)
                    canPay = true;
            }
            return canPay;
        }
        

        private BPay SavePay(string weightId, string carNo, string weightNo, decimal amount,decimal weight) 
        {
            currentPayRefId = weightId;
            bool needOnLinePay = true;
            string customerId = string.Empty;
            string customerName = string.Empty;
            int payType = 0;
            if (wePayType != null) 
            {
                payType = wePayType.CurrentValue.ToInt();
            }
            if (wlookupCustomer != null) 
            {
                customerId = wlookupCustomer.CurrentValue.ToObjectString();
                customerName = wlookupCustomer.Text;
            }
            BPay pay = null;
            pay = payService.GetPayWithRefId(weightId);
            if (pay == null)
            {
                pay = new BPay();
                pay.Id = YF.MWS.Util.Utility.GetGuid();
            }
            PayBizType bizType = PayBizType.Weight;
            if (wbPayBizType != null) 
            {
                bizType = wbPayBizType.CurrentValue.ToEnum<PayBizType>();
            }
            pay.PayBizType = bizType.ToString();
            pay.PayNo = seqNoService.GetSeqNo(SeqCode.Pay.ToString());
            pay.PayTime = DateTime.Now;
            pay.RefId = weightId;
            pay.PayAmount = amount;
            pay.CustomerId = customerId;
            pay.CustomerName = customerName;
            pay.CarNo = carNo;
            pay.DrawerId = CurrentUser.Instance.Id;
            pay.DrawerName = CurrentUser.Instance.FullName;
            pay.Remark = string.Format("仓舒磅单_{0}({1}{2})", weightNo, weight, lbLeftUnit.Text);
            pay.PayType = payType;
            pay.CompanyId = Cfg.Weight.PayCompanyId;
            SCustomer customer = masterService.GetCustomer(customerId);
            if (CanBalancePay(customer,amount))
            {
                HandleGateAfterSave();
                pay.PayType = (int)WeightPayType.Balance;
                needOnLinePay = false;
            }
            if(startOnlinePay && needOnLinePay)
                pay.PayType = (int)WeightPayType.OnLine;
            bool isSaved=payService.AddPay(pay);
            if (isSaved) 
            {
                if (!needOnLinePay)
                    paySuccess = true;
                CustomerCacher.UpdateCustomer(pay.CustomerId);
                if (startOnlinePay && needOnLinePay)
                {
                    if (payCode == PayCodeType.Static) 
                    {
                        pay.PayType = (int)currentPayType;
                        paySuccess = false;
                        ShowWeightStateTip("请用手机微信扫二维码完成支付");
                        needGetPayState = true;
                        webPayService.AddPayFull(pay);
                    }
                    if (payCode == PayCodeType.Dynamic)
                    {
                        pay.PayType = (int)currentPayType;
                        PreparePay(pay);
                    }
                }
                else 
                {}
            }
            return pay;
        }

        /// <summary>
        /// 初始化称重仪器
        /// </summary>
        private void InitPort()
        {
            InitPort(ref this.serialPort1,1, Cfg.Device1);
            InitPort(ref this.serialPort2,2, Cfg.Device2);
        }
        private void InitPort(ref SerialPortHelper serialPort,int deviceNo,DeviceCfg deviceCfg) {
            try {
                if (deviceCfg.StartDevice) {
                    serialPort = new SerialPortHelper(deviceNo, deviceCfg);
                    serialPort.OnShowWeight = new SerialPortHelper.ShowWeight(this.ShowWeightInfo);
                    bool isOpen = false;
                    if (serialPort != null) {
                        isOpen = serialPort.OpenPort();
                    }
                    if (isOpen)
                        ShowWeightStateTip(string.Format("成功连接{0}号称重仪",serialPort.DeviceNo));
                    else
                        ShowWeightStateTip(string.Format("连接{0}号称重仪失败", serialPort.DeviceNo));
                    ShowDeviceState(isOpen);
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }

        private void AddCarRecognitionPhoto(ASBPlateInfo resInfo) 
        {
            if (resInfo.File != null &&!string.IsNullOrEmpty(currentWeightId))
            {
                resInfo.File.RecId = currentWeightId;
                fileService.Add(resInfo.File);
            }
        }

        /// <summary>
        /// 抓拍图片
        /// </summary>
        /// <param name="obj"></param>
        public void CapturePhoto(object obj) 
        {
            try
            {
                if (startVideo && obj!=null)
                {
                    WeightCapture wc = (WeightCapture)obj;
                    List<BFile> files = new List<BFile>();
                    files = Program.frmViewVideoDevice.CapturePicture(wc.WeightId, wc.WaterMarkText);
                    if (files != null && files.Count > 0)
                    {
                        foreach (BFile file in files)
                        {
                            fileService.Add(file);
                        }
                    }
                    else
                    {
                        Logger.Write("capture picture failed!");
                    }
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }
        private void ModbusConnected(bool isOpen) {
            if (isOpen) ShowWeightStateTip("控制箱连接成功");
            else  ShowWeightStateTip("控制箱连接失败");
        }
        private async void InitModBus() 
        {
            if (!startModBus)
            {
                return; 
            }
            //初始化无人值守控制器
            this.modbusLeft = new ModbusUtil(1);
            ShowWeightStateTip("正在连接控制箱");
            if (Cfg.Weight.ModBusCommMode == DeviceCommMode.Network) {
                this.modbusLeft.Connected += ModbusConnected;
               await this.modbusLeft.InitServer(Cfg.NobodyWeight.ModbusIP,Cfg.NobodyWeight.ModbusPort);
            } else {
            bool isOpen = false;
            if (this.modbusLeft != null)
            {
                this.modbusLeft.OpenPort();
                if (this.modbusLeft.IsOpen)
                {
                    //if (PlcUtil.NeedSendChangeCmd())
                    //{
                    //    Logger.Write("Plc changed need repair");
                    //    modbusLeft.ChangeDevice(false);
                    //    startModBus = false;
                    //    modbusLeft.ClosePort();
                    //    modbusLeft = null;
                    //    return;
                    //}
                    isOpen = true;
                        if (startTrafficLight)
                        {
                            //绿灯亮、红灯灭
                            GreeServerLight(1);
                            GreeServerLight(2);
                        }
                    Logger.Write("打开控制器成功.");
                    ShowWeightStateTip("连接PLC控制箱成功");
                }
                else
                {
                    Logger.Write("打开控制器失败.");
                    ShowWeightStateTip("连接PLC控制箱失败");
                }
            }
                       /* if (Cfg.NobodyWeight.StartBoundGate)
                        {
                            //落杠
                            CloseServerGate(1);
                            CloseServerGate(2);
                        }*/
            ShowControlBoxState(isOpen);
            }
        }


        private bool CanOpenEntranceGate(SCar car)
        {
            bool canOpen = false;
            switch (currentLimitScope)
            {
                case CarLimitScopeType.None:
                    canOpen = true;
                    break;
                case CarLimitScopeType.ExcludeWhiteList:
                    if (car != null)
                    {
                        canOpen = true;
                        if (car.LimitState == 1)
                            canOpen = false;
                    }
                    else
                    {
                        canOpen = false;
                    }
                    break;
                case CarLimitScopeType.OnlyLimitBlackList:
                    canOpen = true;
                    if (car != null && car.LimitState == 1)
                    {
                        canOpen = false;
                    }
                    break;
            }
            return canOpen;
        }

        private void ReleaseModBus() 
        {
            //断开控制器串口连接
            if (this.modbusLeft != null)
            {
                if (this.modbusLeft.IsOpen)
                {
                        //红灯亮、绿灯灭
                        this.modbusLeft.SendControl(5, 0, 1);
                        this.modbusLeft.SendControl(5, 1, 0);
                        this.modbusLeft.SendControl(5, 4, 1);
                        this.modbusLeft.SendControl(5, 5, 0);
                        //落杠
                        if (Cfg.NobodyWeight.StartBoundGate)
                        {
                            /*this.modbusLeft.SendControl(5, 2, 0);
                            this.modbusLeft.SendControl(5, 3, 1);
                            this.modbusLeft.SendControl(5, 6, 0);
                            this.modbusLeft.SendControl(5, 7, 1);*/
                        }
                    this.modbusLeft.ClosePort();
                    this.modbusLeft.CloseServer();
                }
                this.modbusLeft = null;
            }
        }

        private void InitScreen()
        {
            try
            {
                if (startScreen)
                {
                    if (!isSendingAd && showAd)
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(SendAd), true);
                    }
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }

        private string GetLedInfo(BWeight weight)
        {
            //车牌  重量   限载顿位   轮轴  超载比例
            string carNo = weight.CarNo;
            decimal gross = weight.GrossWeight;
            decimal tare = weight.TareWeight;
            decimal suttle = weight.SuttleWeight;
            
            StringBuilder sb = new StringBuilder();
            string weightFormat = "F2";
            if (CurrentClient.Instance.VersionCode == VersionCodeType.ZYAY)
            {
                decimal payAmount = 0;
                if (weRegularCharge != null) 
                {
                    payAmount = weRegularCharge.Text.ToDecimal();
                }
                decimal balance=payService.GetBalanceAmount(weight.CustomerId);
                sb.AppendFormat("应收:{0}元\r\n", payAmount.ToString(weightFormat));
                sb.AppendFormat("余额:{0}元\r\n", balance.ToString(weightFormat));
                sb.AppendFormat("重量:{0}{1}\r\n", gross.ToString(weightFormat), lbLeftUnit.Text);
            }
            else 
            {
                if (showWeightStableCfg == null)
                    return sb.ToString();
                weightFormat = string.Format("F{0}", showWeightStableCfg.DecimalDigit);
                if (showWeightStableCfg.ShowCarNo)
                {
                    sb.AppendFormat("车号:{0}\r\n", carNo);
                }
                if (showWeightStableCfg.ShowCustomer &&!string.IsNullOrEmpty(weight.CustomerId)) 
                {
                    SCustomer customer = CustomerCacher.Get(weight.CustomerId);
                    if (customer != null)
                    {
                        sb.AppendFormat("客户单位:{0}\r\n", customer.CustomerName);
                    }
                }
                if (showWeightStableCfg.ShowCustomerBalance && !string.IsNullOrEmpty(weight.CustomerId)) 
                {
                    decimal balance = payService.GetBalanceAmount(weight.CustomerId);
                    sb.AppendFormat("余额:{0}元\r\n", balance.ToString("F2"));
                }
                if (showWeightStableCfg.ShowDeliver &&!string.IsNullOrEmpty(weight.DeliveryId)) 
                {
                    SCustomer customer = CustomerCacher.Get(weight.DeliveryId);
                    if (customer != null)
                    {
                        sb.AppendFormat("发货单位:{0}\r\n", customer.CustomerName);
                    }
                }
                if (showWeightStableCfg.ShowGrossWeight)
                {
                    sb.AppendFormat("毛重:{0}{1}\r\n", gross.ToString(weightFormat), lbLeftUnit.Text);
                }
                if (showWeightStableCfg.ShowTareWeight)
                {
                    sb.AppendFormat("皮重:{0}{1}\r\n", tare.ToString(weightFormat), lbLeftUnit.Text);
                }
                if (showWeightStableCfg.ShowSuttleWeight)
                {
                    sb.AppendFormat("净重:{0}{1}\r\n", suttle.ToString(weightFormat), lbLeftUnit.Text);
                }
                if (showWeightStableCfg.ShowMaterial &&!string.IsNullOrEmpty(weight.MaterialId)) 
                {
                    SMaterial material = MaterialCacher.Get(weight.MaterialId);
                    if (material != null) 
                    {
                        sb.AppendFormat("物资:{0}\r\n", material.MaterialName);
                    }
                }
                if(showWeightStableCfg.ShowPayAmount)
                {
                    decimal payAmount = 0;
                    if (weRegularCharge != null)
                    {
                        payAmount = weRegularCharge.Text.ToDecimal();
                    }
                    sb.AppendFormat("应收:{0}元\r\n", payAmount.ToString("F2"));
                }
                if(showWeightStableCfg.ShowReceiver &&!string.IsNullOrEmpty(weight.ReceiverId))
                {
                    SCustomer customer = CustomerCacher.Get(weight.ReceiverId);
                    if (customer != null)
                    {
                        sb.AppendFormat("收货单位:{0}\r\n", customer.CustomerName);
                    }
                }
                
            }
            return sb.ToString();
        }

        private void SendAd(object state)
        {
            bool isFirst = (bool)state;
            foreach(ILedScreen screen in lstScreen)
            {
                screen.SendAd(isFirst);
            }
            isSendingAd = true;
        }

        private void SendInfoToLed(WeightFlowType flowType,string info)
        {
            if (!string.IsNullOrEmpty(info))
            {
                foreach (ILedScreen screen in lstScreen)
                {
                    screen.SendInfo(flowType, info);
                }
            }
            lastIdleTime = DateTime.Now;
            isSendingAd = false;
        }

        private void LoadCar(string carNo)
        {
            SCar car = carService.GetByCarNo(carNo);
            if (car != null)
            {
          if(Cfg.Weight.CarTemp)  mainWeight.BindControl<SCar>(car);
                if (currentWeightProcess == WeightProcess.One || autoLoadTareWeight)
                {
                    if(weTareWeight != null)
                        weTareWeight.Text = UnitUtil.GetValue("ton", currentDeviceCfg.SUnit, car.TareWeight).ToString();
                }
            }
        }

        private void LoadCard(QPlanCard card)
        {
            if (card == null)
            {
                return;
            }
            currentCard = card;
            currentCardNo = card.CardNo;
            try
            {
                BeginInvoke(new Action(() =>
                {
                    if (wCardNo != null)
                    {
                        wCardNo.CurrentValue = card.CardNo;
                        wCardNo.Text = card.CardNo;
                    }
                }));
            }
            catch(Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 根据车牌号加载未完成磅单
        /// </summary>
        /// <param name="carNo"></param>
        /// <returns></returns>
        private bool LoadUnFinishWeightWithCarNo(string carNo) 
        {
            bool hasLoaded = false;
            hasLoadUnFinishWeight = true;
            if (loadUnfinishWeight == LoadUnfinishWeightType.CarNo || (loadUnfinishWeight== LoadUnfinishWeightType.CarNoOrCardNo && !hasLoadUnFinishWeight))
            {
                //获取磅单信息
                currentWeight = weightService.GetUnFinishedByCarNo(carNo);
                if (currentWeight != null)
                {
                    LoadWeight(currentWeight, false);
                    isNewWeight = false;
                    currentWeightId = currentWeight.Id;
                    hasLoaded = true;
                }else if (Cfg.Transfer.isOpen) {
                    currentWeight = webWeightService.Get(carNo);
                    if (currentWeight != null) {
                        currentWeight.ServiceId = currentWeight.Id;
                        currentWeight.Id = Guid.NewGuid().ToString("N");
                        currentWeightId=currentWeight.Id;
                        isNewWeight = true;
                        LoadWeight(currentWeight,false);
                        hasLoaded = true;
                    }
                }
            }
            if (!hasLoaded) 
            {
                LoadCar(carNo);
                /*BPlanCard card = cardService.GetByCarNo(carNo);
                if (card != null)
                {
                    List<BCardPreset> lstPreset = CardCacher.GetPresetList(card.Id);
                    mainWeight.BindCardView(card, lstPreset);
                }*/
            }
            isNewWeight = !hasLoaded;
            return hasLoaded;
        }

        /// <summary>
        /// 依据卡号加载未完成磅单
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        private bool LoadUnFinishWeightWithCardNo(string cardNo)
        {
            bool hasLoaded = false;
            if (loadUnfinishWeight == LoadUnfinishWeightType.CardNo || (loadUnfinishWeight == LoadUnfinishWeightType.CarNoOrCardNo && !hasLoadUnFinishWeight))
            {
                currentWeight = weightService.GetUnFinishedByCardNo(cardNo);
                if (currentWeight != null)
                {
                    hasLoadUnFinishWeight = true;
                    LoadWeight(currentWeight, false);
                    hasLoaded = true;
                }
            }
            return hasLoaded;
        }
        #region 道闸操作
        private async void OpenServerGate(int no) {
            bool isOk = false;
            if (Cfg.NobodyWeight.GateControl=="Modbus"&& this.modbusLeft != null && Cfg.Weight.ModBusCommMode == DeviceCommMode.Network) {
                int currentNo = no * 2 - 1;
                int time = Cfg.NobodyWeight.FunSixCloseTime <= 0 ? 3 : Cfg.NobodyWeight.FunSixCloseTime;
               await this.modbusLeft.SendData(currentNo, time);
                isOk = true;
            } else if (Cfg.NobodyWeight.GateControl == "Car") {
                if (no==1&&this.hxRecognizerLeft!=null) {
                 isOk = hxRecognizerLeft.OpenGate();
                }else if (no==2&&this.hxRecognizerRight!=null) {
                  isOk = hxRecognizerRight.OpenGate();
                }
            }
            if(isOk)ShowWeightStateTip(string.Format("正在开启{0}#道闸", no));
        }
        private async void CloseServerGate(int no) {
            bool isOk = false;
            if (Cfg.NobodyWeight.GateControl == "Modbus" && this.modbusLeft != null && Cfg.Weight.ModBusCommMode == DeviceCommMode.Network) {
                int currentNo = no * 2 - 1;
                int time = Cfg.NobodyWeight.FunSixCloseTime <= 0 ? 3 : Cfg.NobodyWeight.FunSixCloseTime;
                await this.modbusLeft.SendData(currentNo, time);
            } else if (Cfg.NobodyWeight.GateControl == "Car") {
                if (no == 1 && this.hxRecognizerLeft != null) {
                      isOk = hxRecognizerLeft.CloseGate();
                } else if (no == 2 && this.hxRecognizerRight != null) {
                     isOk = hxRecognizerRight.CloseGate();
                }
            } else { return; }
           if(isOk) ShowWeightStateTip(string.Format("正在关闭{0}#道闸", no));
        }
        #endregion
        #region 红绿灯
        #endregion
        private async void GreeServerLight(int no) {
            if (this.modbusLeft != null && Cfg.Weight.ModBusCommMode == DeviceCommMode.Network) {
                no = no * 2 + 1;
               await this.modbusLeft.SendData(no, -1);
                Thread.Sleep(100);
               await this.modbusLeft.SendData(no+1, 0);
            }
        }
        private async void RedServerLight(int no) {
            if (this.modbusLeft != null && Cfg.Weight.ModBusCommMode == DeviceCommMode.Network) {
                no = no * 2+1;
                await this.modbusLeft.SendData(no + 1, -1);
                Thread.Sleep(100);
                await this.modbusLeft.SendData(no, 0);
            }
        }

        private void AsyncCapturePhoto(WeightCapture wc)
        {
            try
            {
                if (!string.IsNullOrEmpty(wc.WeightId))
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(CapturePhoto), wc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        private void New(bool completelyClear = false)
        {
            ClearWeightControl();
            CreateNewWeight();
            mainWeight.Clear(completelyClear);
            if (weWaybillNo != null) weWaybillNo.Focus();
        }

        /// <summary>
        /// 验证卡号
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns></returns>
        private bool ValidateCard(string cardId)
        {
            bool isValidated = false;
            if (!string.IsNullOrEmpty(cardId))
            {
                currentCard = CardCacher.Get(cardId, cardService, false);
                if (currentCard != null)
                {
                    isValidated = true;
                }
                else 
                {
                    ShowWeightStateTip(string.Format("IC卡({0})未在系统登记",cardId));
                }
                if (startSameCardNoControl && isValidated)
                {
                    ReadCardResult result = new ReadCardResult();
                    result.CardId = currentCard.Id;
                    result.RecognitionTime = DateTime.Now;
                    lstReadCardResult = ReadCardUtil.RefreshResult(lstReadCardResult, readCardTimeSpan);
                    isValidated = ReadCardUtil.IsValidateCardNo(result, readCardTimeSpan, lstReadCardResult);
                    if (isValidated)
                    {
                        lstReadCardResult.Add(result);
                    }
                    else
                    {
                        if (isValidated)
                            ShowWeightStateTip(string.Format("卡号{0}验证成功", currentCard.CardNo));
                        else
                        {
                            ShowWeightStateTip(string.Format("刷卡时间未到请勿再刷卡"));
                        }
                    }
                }
                if (startValidateCarWithCard && isValidated)
               {
                   if (wlookCar != null && currentCard != null && wlookCar.Text.Length > 0
                        && !string.IsNullOrEmpty(currentCard.CarNo) && wlookCar.Text != currentCard.CarNo) 
                    {
                        isValidated = false;
                        if (speecher != null)
                        {
                            speecher.Speak("车卡不一致");
                        }
                        ShowWeightStateTip(string.Format("车牌({0})与IC卡号({1})登记的车牌号({2})", 
                                                     wlookCar.Text, currentCard.CardNo, currentCard.CarNo));
                        return isValidated;
                    }
                }
            }
            return isValidated;
        }

        /// <summary>
        /// 验证识别的车牌号
        /// </summary>
        /// <param name="carNo"></param>
        /// <returns></returns>
        private bool ValidateCarNo(string carNo) 
        {
            bool isValidated = false;
            if (string.IsNullOrEmpty(carNo)) return isValidated;
            if (!startSameCarNoControl)
            {
                if (!string.IsNullOrEmpty(carNo))
                {
                    isValidated = true;
                }
            }
            else 
            {
                RecognitionResult result = new RecognitionResult();
                result.CarNo = carNo;
                result.RecognitionTime = DateTime.Now;
                lstRecognitionResult=CarRecognitionUtil.RefreshResult(lstRecognitionResult, recognitionTimeSpan);
                isValidated = CarRecognitionUtil.IsValidateCarNo(result, recognitionTimeSpan, lstRecognitionResult);
                if (isValidated) 
                {
                    lstRecognitionResult.Add(result);
                }
            }
            if(isValidated)
                ShowWeightStateTip(string.Format("车牌{0}验证成功",carNo));
            else
                ShowWeightStateTip(string.Format("车牌{0}验证失败", carNo));
            return isValidated;
        }

        private void ReleaseIdCardReader()
        {
            if (idCardReader != null)
                idCardReader.Close();
        }

        private void ReleaseCarPlate() 
        {
            if (dhRecognizerLeft != null) 
            {
                dhRecognizerLeft.Realese();
            }
            if (dhRecognizerRight != null) 
            {
                dhRecognizerRight.Realese();
            }
            if (hkRecognizerRight != null) 
            {
                hkRecognizerRight.Logout();
            }
            if (hkRecognizerLeft != null) 
            {
                hkRecognizerLeft.Logout();
                hkRecognizerLeft.Realse();
            }
            if (hxRecognizerLeft!= null)
            {
                hxRecognizerLeft.Release();
            }
            if (hxRecognizerRight != null) 
            {
                hxRecognizerRight.Release();
            }
            if (vzRecognizerRight != null)
            {
                vzRecognizerRight.Logoff();
            }
            if (vzRecognizerLeft != null)
            {
                vzRecognizerLeft.Logoff();
                vzRecognizerLeft.Relase();
            }
            if (qyRecognizerRight != null)
            {
                qyRecognizerRight.Logoff();
            }
            if (qyRecognizerLeft != null)
            {
                qyRecognizerLeft.Logoff();
                qyRecognizerLeft.Relase();
            }
        }

        private void SetUnitPrice()
        {
            bool hasSetPrice = false;
            if (weUnitPrice != null && weMaterial != null && wlookupCustomer != null 
                && wlookupCustomer.CurrentValue != null && weMaterial.CurrentValue!=null) 
            {
                string customerId=wlookupCustomer.CurrentValue.ToObjectString();
                string materialId=weMaterial.CurrentValue.ToObjectString();
                SCustomerPrice price = customerService.Get(customerId, materialId);
                if (price != null && price.Price>0) 
                {
                    hasSetPrice = true;
                    weUnitPrice.Text = price.Price.ToString();
                }
            }
            if (!hasSetPrice && weMaterial != null && weMaterial.CurrentValue!=null)
            {
                SMaterial material = MaterialCacher.Get(weMaterial.CurrentValue.ToObjectString());
                if (material != null)
                {
                    if (weUnitPrice != null)
                    {
                        weUnitPrice.Text = material.UnitPrice.ToString();
                    }
                }
            }
        }
    }
}
