using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YF.MWS.BaseMetadata;
using YF.MWS.CacheService;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata.CarPlate;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Event;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata;
using YF.MWS.SQliteService.Remote;
using YF.MWS.SQliteService;
using YF.MWS.Util;
using YF.MWS.Win.Core;
using YF.MWS.Win.Uc;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using YF.MWS.Win.Uc.Weight;
using YF.MWS.Win.Util.CarPlate;
using YF.MWS.Win.Util.Video;
using YF.MWS.Win.Util;
using YF.MWS.Win.View.Customer;
using YF.MWS.Win.View.Report;
using YF.MWS.Win.View.UI;
using YF.Utility.Language;
using YF.Utility.Log;
using YF.Utility;
using System.Collections;
using System.Diagnostics;
using YF.Utility.Data;
using com.google.zxing;

namespace YF.MWS.Win.View.Weight {
    public partial class FrmWeight : BaseForm {
        public delegate object MyDelegate(FrmWeight frm);
        private ISeqNoService seqNoService = new SeqNoService();
        private IReportService reportService = new ReportService();
        private IWeightQueryService weightQueryService = new WeightQueryService();
        private IAttributeService attributeService = new AttributeService();
        private IFileService fileService = new FileService();
        private IWebFileService webFileService = new WebFileService();
        private IWebPayService webPayService = new WebPayService();
        private IWeightViewService viewService=new WeightViewService();
        private ICompanyService companyService = new CompanyService();
        private SyncObject syncObj = new SyncObject();
        private bool refusePay = false;
        private int currentDate = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
        private LoginCfg loginCfg = null;
        private string loginCfgXml = Path.Combine(Application.StartupPath, "LoginCfg.xml");
        private BWeight tempWeight = null;
        /// <summary>
        /// 抓拍图片和视频文件信息
        /// </summary>
        private List<BFile> lstTempFile = new List<BFile>();
        /// <summary>
        /// 模拟称重
        /// </summary>
        private SimulateWeight simulateWeight= new SimulateWeight();
        private DevExpress.XtraEditors.LabelControl currentlblWeight;
        /// <summary>
        /// 是否显示验证提示消息
        /// </summary>
        private bool showValidateMessage = false;

        /// <summary>
        /// 称重界面的数据是否保留
        /// </summary>
        private bool saveFormData = false;

        /// <summary>
        /// 当前的磅单ID
        /// </summary>
        private string currentWeightId = YF.MWS.Util.Utility.GetGuid();
        private string currentPayRefId = string.Empty;
        private string currentViewId = CurrentClient.Instance.ViewId;
        /// <summary>
        /// 无人职守控制器
        /// 单道闸控制说明：1#输入信号检测入方向红外对射状态、2#输入信号检测出方向红外对射状态；1#输出信号控制红灯、2#输出信号控制绿灯、3#输出信号控制道闸抬杠、4#输出信号控制道闸落杠
        /// 双道闸控制说明：1#输入信号检测红外对射状态、1#输出信号控制红灯、2#输出信号控制绿灯、3#输出信号控制道闸抬杠、4#输出信号控制道闸落杠 --> 对应1#读卡器或车牌识别仪；
        ///                 2#输入信号检测红外对射状态、5#输出信号控制红灯、6#输出信号控制绿灯、7#输出信号控制道闸抬杠、8#输出信号控制道闸落杠 --> 对应2#读卡器或车牌识别仪。
        /// </summary>
        private ModbusUtil modbusLeft;

        /// <summary>
        /// 无人值守单道闸模式是否已经通知读卡
        /// </summary>
        private volatile bool isNoteReadCard = false;

        /// <summary>
        /// 无人职守模式是否已经通知检查车辆位置
        /// </summary>
        private volatile bool isNoteCheckCar = false;

        /// <summary>
        /// 是否获取车牌号
        /// </summary>
        private bool hasGetCarNo = false;

        /// <summary>
        /// 无人值守单道闸模式是否正在称重
        /// </summary>
        private volatile bool isBounding = false;

        /// <summary>
        /// 无人值守模式最小称重值
        /// </summary>
        private decimal minWeightValue = 0;

        /// <summary>
        /// 无人职守模式最大落杆重量值
        /// </summary>
        private decimal outWeightValue = 0;

        /// <summary>
        /// 无人职守模式检测车辆驶出地磅
        /// </summary>
        private System.Timers.Timer timerOut;

        /// <summary>
        /// 无人职守模式检测车辆是否完全驶入地磅计数
        /// </summary>
        private volatile int checkCarCount = 0;

        /// <summary>
        /// 上次皮重
        /// </summary>
        private decimal oldTareWeight = 0;
        /// <summary>
        /// 当前皮重
        /// </summary>
        private decimal currentTareWeight = 0;
        private DateTime tareWeightTime = DateTime.Now;
        /// <summary>
        /// 当前毛重
        /// </summary>
        private decimal currentGrossWeight = 0;
        /// <summary>
        /// 上次毛重
        /// </summary>
        private decimal oldGrossWeight = 0;
        private DateTime grossWeightTime = DateTime.Now;

        /// <summary>
        /// 窗体是否加载完
        /// </summary>
        private bool hasLoaded = false;

        /// <summary>
        /// 是否是新磅单
        /// </summary>
        private bool isNewWeight = true;
        private bool startOverWeight = false;
        private decimal maxWeight = 0;
        private decimal overWeight = 0;

        /// <summary>
        /// 启用补打磅单模板
        /// </summary>
        private bool startReWeightTemplate = false;

        /// <summary>
        /// 朗读的语音提示
        /// </summary>
        private VoiceCfg voiceCfg = null;

        /// <summary>
        /// 声音朗读器
        /// </summary>
        private SpeechUtil speecher = null;

        /// <summary>
        /// 当前称重仪器编号,默认为1#称重仪
        /// </summary>
        private int currentDeviceNo = 1;

        /// <summary>
        /// 称重仪器
        /// </summary>
        private SerialPortHelper serialPort1;
        private SerialPortHelper serialPort2;
        private SerialPortHelper currentPort;//当前使用的仪表
        private DeviceCfg currentDeviceCfg;
        /// <summary>
        /// 左边称重仪器重量
        /// </summary>
        private decimal leftWeightValue = 0;

        /// <summary>
        /// 最小差值
        /// </summary>
        private double minDValue = 0.1;

        /// <summary>
        /// 采样重量，用于判断重量是否稳定
        /// </summary>
        private List<double> lstWeightValue = new List<double>();

        /// <summary>
        /// 线程同步锁
        /// </summary>
        private static object lockObj = new object();
        private bool m_bRecord = false;

        /// <summary>
        /// 1#近距离读卡器通讯设备标识符
        /// </summary>
        private int icdevLeft = 0;
        /// <summary>
        /// 2#近距离读卡器通讯设备标识符
        /// </summary>
        private int icdevRight = 0;
        /// <summary>
        /// 1#远距离读卡器
        /// </summary>
        private UHFReader18Util remoteReaderLeft = null;
        /// <summary>
        /// 2#远距离读卡器
        /// </summary>
        private UHFReader18Util remoteReaderRight = null;
        /// <summary>
        /// 刷卡的读卡器或车牌识别仪编号
        /// </summary>
        private int readerNo = 0;

        #region 车牌识别一体机
        /// <summary>
        /// 1#大华车牌识别仪
        /// </summary>
        private DHCarPlateUtil dhRecognizerLeft;
        /// <summary>
        /// 2#大华车牌识别仪
        /// </summary>
        private DHCarPlateUtil dhRecognizerRight;
        /// <summary>
        /// 1#海康车牌识别仪
        /// </summary>
        private HKCarPlateRecognizer hkRecognizerLeft;
        /// <summary>
        /// 2#海康车牌识别仪
        /// </summary>
        private HKCarPlateRecognizer hkRecognizerRight;
        /// <summary>
        /// 1#华夏车牌识别仪
        /// </summary>
        private HXPlateRecognizer hxRecognizerLeft;
        /// <summary>
        /// 2#华夏车牌识别仪
        /// </summary>
        private HXPlateRecognizer hxRecognizerRight;
        /// <summary>
        /// 1#芊熠车牌识别仪
        /// </summary>
        private QianYiPlateRecognizer qyRecognizerLeft;
        /// <summary>
        /// 2#芊熠车牌识别仪
        /// </summary>
        private QianYiPlateRecognizer qyRecognizerRight;
        /// <summary>
        /// 1#快号通车牌识别仪
        /// </summary>
        private KHTUtil khtRecognizerLeft;

        /// <summary>
        /// 2#快号通车牌识别仪
        /// </summary>
        private KHTUtil khtRecognizerRight;

        /// <summary>
        /// 新版快号通车牌识别仪
        /// </summary>
        private KHTNewUtil khtNewRecognizer;

        /// <summary>
        /// 1#高清车牌识别仪
        /// </summary>
        private GQUtil gqRecognizerLeft;

        /// <summary>
        /// 2#高清车牌识别仪
        /// </summary>
        private GQUtil gqRecognizerRight;
        /// <summary>
        /// 1#臻识车牌识别仪
        /// </summary>
        private VzCarPlateRecognizer vzRecognizerLeft;
        /// <summary>
        /// 2#臻识车牌识别仪
        /// </summary>
        private VzCarPlateRecognizer vzRecognizerRight;

        #endregion


        private List<BarItem> lstItem = new List<BarItem>();
        private IMasterService masterService = new MasterService();
        private ICarService carService = new CarService();
        private IWeightService weightService = new WeightService();
        private IWeightExtService weightExtService = new WeightExtService();
        private WNumbericEdit weTareWeight;
        private WNumbericEdit weGrossWeight;
        private WNumbericEdit weSuttleWeight;
        private WNumbericEdit weNetWeight;
        private WComboBoxEdit wbChargeType;
        private WComboBoxEdit wePayType;
        private WNumbericEdit weRegularCharge;
        private WNumbericEdit weImpurityWeight;
        /// <summary>
        /// 物资单价
        /// </summary>
        private WNumbericEdit weUnitPrice;
        private WNumbericEdit weUnitMoney;
        private WNumbericEdit weMaterialAmount;
        private WNumbericEdit wePickQty;
        private WTextEdit weWaybillNo;
        private WTextEdit weDriverName;
        private WTextEdit weWeighterName;
        private WCustomerEdit weDeliver;
        private WCustomerEdit wlookupReceiver;
        private WComboBoxEdit wbWarehBizType;
        private WLookupSearchEdit weWareh;
        /// <summary>
        /// 物资
        /// </summary>
        private WMaterialEdit weMaterial;
        private WTextEdit weMaterialModel;
        /// <summary>
        /// 客户
        /// </summary>
        private WCustomerEdit wlookupCustomer;
        private WCustomerEdit wlookupManufacturer;
        private WCustomerEdit wlookupSupplier;
        private WCustomerEdit wlookupTransfer;
        private WCarLookup wlookCar;
        private WCardEdit wCardNo;
        private WComboBoxTextEdit wRefuseType;
        private WNumbericEdit wKougan;
        private WTextEdit weBillNo;
        private WNumbericEdit wnRealWater;
        private WNumbericEdit wCustomerBalance;
        private WNumbericEdit weRealCharge;
        private WNumbericEdit weD1;
        private WNumbericEdit weD2;
        /// <summary>
        /// 是否正在过磅
        /// </summary>
        private bool hasLoadUnFinishWeight = false;

        public MainWeight WeightCtrl {
            get {
                return mainWeight;
            }
        }

        private void InitControl() {
            mainWeight.FrmWeight = this;
            weWaybillNo = mainWeight.FindControl<WTextEdit>("WaybillNo");
            wePayType = mainWeight.FindControl<WComboBoxEdit>("PayType");
            weImpurityWeight = mainWeight.FindControl<WNumbericEdit>("ImpurityWeight");
            weWareh = mainWeight.FindControl<WLookupSearchEdit>("WarehId");
            weTareWeight = mainWeight.FindControl<WNumbericEdit>("TareWeight");
            weGrossWeight = mainWeight.FindControl<WNumbericEdit>("GrossWeight");
            weSuttleWeight = mainWeight.FindControl<WNumbericEdit>("SuttleWeight");
            weNetWeight = mainWeight.FindControl<WNumbericEdit>("NetWeight");
            wbChargeType = mainWeight.FindControl<WComboBoxEdit>("ChargeType");
            wbPayBizType = mainWeight.FindControl<WComboBoxEdit>("PayBizType");
            weRegularCharge = mainWeight.FindControl<WNumbericEdit>("RegularCharge");
            weMaterialAmount = mainWeight.FindControl<WNumbericEdit>("MaterialAmount");
            weUnitPrice = mainWeight.FindControl<WNumbericEdit>("UnitPrice");
            weUnitMoney = mainWeight.FindControl<WNumbericEdit>("UnitMoney");
            weDriverName = mainWeight.FindControl<WTextEdit>("DriverName");
            wbWarehBizType = mainWeight.FindControl<WComboBoxEdit>("WarehBizType");
            wlookupCustomer = mainWeight.FindControl<WCustomerEdit>("CustomerId");
            wlookupReceiver = mainWeight.FindControl<WCustomerEdit>("ReceiverId");
            weMaterial = mainWeight.FindControl<WMaterialEdit>("MaterialId");
            weMaterialModel = mainWeight.FindControl<WTextEdit>("MaterialModel");
            weDeliver = mainWeight.FindControl<WCustomerEdit>("DeliveryId");
            wlookupManufacturer = mainWeight.FindControl<WCustomerEdit>("ManufacturerId");
            wlookupSupplier = mainWeight.FindControl<WCustomerEdit>("SupplierId");
            wlookupTransfer = mainWeight.FindControl<WCustomerEdit>("TransferId");
            wlookCar = mainWeight.FindControl<WCarLookup>("CarId");
            weWeighterName = mainWeight.FindControl<WTextEdit>("WeighterName");
            wCardNo = mainWeight.FindControl<WCardEdit>("CardNo");
            wKougan = mainWeight.FindControl<WNumbericEdit>("Kougan");
            wRefuseType = mainWeight.FindControl<WComboBoxTextEdit>("RefuseType");
            weBillNo = mainWeight.FindControl<WTextEdit>("BillNo");
            wnRealWater = mainWeight.FindControl<WNumbericEdit>("RealWater");
            wePickQty = mainWeight.FindControl<WNumbericEdit>("PickQty");
            wCustomerBalance = mainWeight.FindControl<WNumbericEdit>("CustomerBalance");
            weRealCharge = mainWeight.FindControl<WNumbericEdit>("RealCharge");
            weD1 = mainWeight.FindControl<WNumbericEdit>("d1");
            weD2 = mainWeight.FindControl<WNumbericEdit>("d2");
            if (wRefuseType != null) {
                wRefuseType.SelectedItem = wRefuseType.Properties.Items.Cast<SCode>().FirstOrDefault(c => c.ItemCode == RefuseType.Accepted.ToString());
            }
            if (!CurrentUser.Instance.IsAdministrator) {
                mainWeight.SetRole(LstModule);
            }
            SetEvent();
            SetControl();
        }

        private void InitRoleControl() {
            List<SimpleButton> buttons = new List<SimpleButton>();
            //buttons.Add(btnWeight);
            buttons.Add(btnOpenFirstGate);
            buttons.Add(btnOpenSecondGate);
            buttons.Add(btnCloseFirstGate);
            buttons.Add(btnCloseSecondGate);
            List<BarSubItem> subItems = new List<BarSubItem>();
            RoleUtil.SetButton(buttons, LstModule);
            RoleUtil.SetBarItem(lstItem, LstModule);
            RoleUtil.SetBarSubItem(subItems, LstModule);
            canManualPrint = RoleUtil.HasPermission(btnPrint, LstModule);
            if (!canManualPrint)
                btnPrint.Enabled = false;
        }

        private void Init() {
            syncObj.FileService = fileService;
            syncObj.MasterService = masterService;
            syncObj.PayService = payService;
            syncObj.WeightService = weightService;
            syncObj.WeightExtService = weightExtService;
            syncObj.SyncService = sysncService;
            syncObj.WebFileService = webFileService;
            if (Cfg != null && Cfg.Transfer != null)
                syncObj.Transfer = Cfg.Transfer;
        }

        private void SetControl() {
            if (Cfg != null && Cfg.OverWeight != null) {
                startOverWeight = Cfg.OverWeight.Start;
            }
            if (weWeighterName != null) {
                weWeighterName.Text = CurrentUser.Instance.FullName;
            }
            if (CurrentUser.Instance.IsAdministrator) {
                if (weTareWeight != null) {
                    weTareWeight.Enabled = true;
                    weTareWeight.Properties.ReadOnly = false;
                }
                if (weGrossWeight != null) {
                    weGrossWeight.Enabled = true;
                    weGrossWeight.Properties.ReadOnly = false;
                }
                if (weSuttleWeight != null) {
                    weSuttleWeight.Enabled = true;
                    weSuttleWeight.Properties.ReadOnly = false;
                }
                if (weNetWeight != null) {
                    weNetWeight.Enabled = true;
                    weNetWeight.Properties.ReadOnly = false;
                }
                if (wlookCar != null) {
                    wlookCar.Enabled = true;
                    wlookCar.Properties.ReadOnly = false;
                }
            }
                Font f = CfgUtil.GetFont();
            if (wlookCar != null) {
                wlookCar.Properties.AppearanceDropDown.Font = f;
            }
            if (wlookupCustomer != null) {
                wlookupCustomer.Properties.AppearanceDropDown.Font = f;
            }
            if (wlookupManufacturer != null) {
                wlookupManufacturer.Properties.AppearanceDropDown.Font = f;
            }
            if (wlookupSupplier != null) {
                wlookupSupplier.Properties.AppearanceDropDown.Font = f;
            }
            if (wlookupTransfer != null) {
                wlookupTransfer.Properties.AppearanceDropDown.Font = f;
            }
            if (weMaterial != null) {
                weMaterial.Properties.AppearanceDropDown.Font = f;
            }
        }

        void weDeliver_EditValueChanged(object sender, EventArgs e) {
            try {
            if (weDeliver.CurrentValue.ToObjectString().Length == 0) {
                return;
            }
                return;
            CustomerUtil.LoadCustomer(weDeliver.CurrentValue.ToObjectString(), CustomerType.Delivery, masterService, mainWeight);
            }catch(Exception ex) {
                Logger.WriteException(ex);
            }
        }

        private void SetEvent() {
            if (searchList != null) {
                searchList.WeightDoubleClick += SearchList_WeightDoubleClick;
            }
            if (weSuttleWeight != null) {
                weSuttleWeight.TextChanged += Weight_TextChanged;
            }
            if (weTareWeight != null) {
                weTareWeight.LostFocus += TareWeight_LostFocus;
                weTareWeight.TextChanged += Weight_TextChanged;
            }
            if (weGrossWeight != null) {
                weGrossWeight.TextChanged += GrossWeight_Changed;
                weGrossWeight.LostFocus += GrossWeight_LostFocus;
            }
            if (wlookCar != null) {
                wlookCar.TextChanged += wlookCar_TextChanged;
                wlookCar.ManualCarRecognizeTrigger += wlookCar_ManualCarRecognizeTrigger;
            }
            if (wCardNo != null) {
                wCardNo.TextChanged += wCardNo_TextChanged;
            }
            if (weMaterial != null) {
                weMaterial.EditValueChanged += wMaterialId_EditValueChanged;
            }
            if (weBillNo != null) {
                weBillNo.TextChanged += weBillNo_TextChanged;
            }
            if (wlookupCustomer != null) {
                wlookupCustomer.EditValueChanged += wlookupCustomer_EditValueChanged;
            }
            if (weDeliver != null) {
                weDeliver.EditValueChanged += weDeliver_EditValueChanged;
            }
            if (weUnitPrice != null) {
                weUnitPrice.EditValueChanged += weUnitPrice_EditValueChanged;
            }
            if (weMaterialAmount != null) {
                weMaterialAmount.EditValueChanged += WeMaterialAmount_EditValueChanged;
            }
            if (weD1!= null) {
                weD1.EditValueChanged += WeD1_EditValueChanged;
            }
        }

        private void WeMaterialAmount_EditValueChanged(object sender, EventArgs e) {
            if (weD1 != null&&weD2 != null) weD2.CurrentValue = weMaterialAmount.CurrentValue.ToInt() * weD1.CurrentValue.ToInt();
        }
        private void WeD1_EditValueChanged(object sender, EventArgs e) {
            if (weMaterialAmount != null && weD2 != null) weD2.CurrentValue = weMaterialAmount.CurrentValue.ToInt() * weD1.CurrentValue.ToInt();
        }

        void wlookCar_ManualCarRecognizeTrigger(object sender, ManualCarRecognizeTriggerEventArgs e) {
            bool isSuccess = false;
            if (vzRecognizerLeft != null) {
                isSuccess = vzRecognizerLeft.ManualTrigger();
                ShowWeightStateTip(string.Format("手动触发1#车牌识别{0}", isSuccess ? "成功" : "失败"));
            }
            if (vzRecognizerRight != null) {
                isSuccess = vzRecognizerRight.ManualTrigger();
                ShowWeightStateTip(string.Format("手动触发2#车牌识别{0}", isSuccess ? "成功" : "失败"));
            }
            if (hxRecognizerLeft != null) {
                isSuccess = hxRecognizerLeft.ManualTrigger();
                ShowWeightStateTip(string.Format("手动触发1#车牌识别{0}", isSuccess ? "成功" : "失败"));
            }
            if (hxRecognizerRight != null) {
                isSuccess = hxRecognizerRight.ManualTrigger();
                ShowWeightStateTip(string.Format("手动触发2#车牌识别{0}", isSuccess ? "成功" : "失败"));
            }
        }

        void weUnitPrice_EditValueChanged(object sender, EventArgs e) {
            if (saveFormData && firstInitedUnitPrice) {
                residentUnitPrice = weUnitPrice.Text.ToDecimal();
                firstInitedUnitPrice = false;
            }
        }

        private void weBillNo_TextChanged(object sender, EventArgs e) {
            if (weBillNo.Text.Length > 0 && !hasLoadUnFinishWeight) {
                string weightId = weightService.GetUnFinishedWeightId("票据编号", weBillNo.Text, CurrentClient.Instance.SubjectId);
                if (!string.IsNullOrEmpty(weightId)) {
                    if (MessageDxUtil.ShowYesNoAndTips("尚有未完成的磅单，是否需要继续完成该磅单？") == DialogResult.Yes) {
                        hasLoadUnFinishWeight = true;
                        List<string> lstExecutedField = new List<string>();
                        lstExecutedField.Add("BillNo");
                        LoadWeightWithExecutedControl(weightId, lstExecutedField);
                    }
                }
            }
        }

        private void wlookupCustomer_EditValueChanged(object sender, EventArgs e) {
            if (wlookupCustomer.CurrentValue == null || wlookupCustomer.CurrentValue.ToObjectString().Length == 0) {
                return;
            }
            return;
            CustomerUtil.LoadCustomer(wlookupCustomer.CurrentValue.ToObjectString(), CustomerType.Customer, masterService, mainWeight);
            SetUnitPrice();
        }

        private void SearchList_WeightDoubleClick(object sender, WeightDoubleClickEventArgs e) {
            if (startDoubleClickUnfinished) {
                LoadWeight(e.WeightId);
            }
        }

        private void GrossWeight_LostFocus(object sender, EventArgs e) {
            if (weGrossWeight != null) {
                currentGrossWeight = weGrossWeight.Text.ToDecimal();
            }
            //TareGrossTransform();
        }

        private void TareWeight_LostFocus(object sender, EventArgs e) {
            if (weTareWeight != null) {
                currentTareWeight = weTareWeight.Text.ToDecimal();
            }
            //TareGrossTransform();
        }

        private void wMaterialId_EditValueChanged(object sender, EventArgs e) {
            if (weMaterial.Text.Length == 0) {
                return;
            }
            SMaterial material = MaterialCacher.Get(weMaterial.CurrentValue.ToObjectString());
            if (material != null) {
                if (weMaterialModel != null) {
                    weMaterialModel.Text = material.SpecName;
                }
                if (weUnitPrice != null) {
                    weUnitPrice.Text = material.UnitPrice.ToString();
                }
            }
            //SetUnitPrice();
        }

        private void wCardNo_TextChanged(object sender, EventArgs e) {
            //避免在无人值守模式下，人工干预称重会覆盖上一次过磅数据的问题
            //CreateNewWeight();
            if (wCardNo.Text.Length > 0) {
                bool hasLoaded = LoadUnFinishWeightWithCardNo(wCardNo.Text);
                if (!hasLoaded) {
                    if (Cfg.Transfer.isOpen) {

                    }
                    BPlanCard card = CardCacher.GetWithCardNo(cardService, wCardNo.Text, false);
                    if (card != null) {
                        List<BCardPreset> lstPreset = CardCacher.GetPresetList(card.Id);
                        mainWeight.BindCardView(card, lstPreset, wCardNo);
                    }
                    if (wlookCar != null && wlookCar.Text.Length > 0) {
                        LoadCar(wlookCar.Text.Trim());
                    }
                }
            }
        }

        private void GrossWeight_Changed(object sender, EventArgs e) {

        }

        private bool IsOverWeight() {
            bool isOverWeight = false;
            if (startOverWeight && weGrossWeight != null) {
                string carNo = string.Empty;
                if (wlookCar != null) {
                    carNo = wlookCar.Text;
                }
                maxWeight = WeightUtil.GetMaxWeight(carNo);
                decimal gross = UnitUtil.GetValue(currentDeviceCfg, weGrossWeight.Text.ToDecimal());
                if (maxWeight < gross) {
                    isOverWeight = true;
                    overWeight = gross - maxWeight;
                }
            }
            return isOverWeight;
        }

        private void Weight_TextChanged(object sender, EventArgs e) {
            if (weSuttleWeight != null) {
                if (weSuttleWeight.Text.ToDecimal() < 0) {
                    weSuttleWeight.Text = "0";
                }
                if (weD2 != null && weUnitMoney != null) {
                    if (weD2.Text.ToDecimal() > 0) {
                        weUnitMoney.Text = (weD2.Text.ToDecimal() * weUnitPrice.Text.ToDecimal()).ToString();
                    } else if (weSuttleWeight != null && weUnitMoney != null) {
                        weUnitMoney.Text = (weSuttleWeight.Text.ToDecimal() * weUnitPrice.Text.ToDecimal()).ToString();
                    }
                } else if (weSuttleWeight != null && weUnitMoney != null) {
                    weUnitMoney.Text = (weSuttleWeight.Text.ToDecimal() * weUnitPrice.Text.ToDecimal()).ToString();
                }
            }
        }
        /// <summary>
        /// 毛皮互换
        /// </summary>
        /// <param name="manual"></param>
        private void TareGrossTransform() {
            if (startGrossTareTransform&&weGrossWeight!=null&&weTareWeight!=null) {
                decimal tare = currentTareWeight;
                if (oldGrossWeight > 0) //将毛重还原为上次过毛重的重量
                {
                        decimal currentWeight = weGrossWeight.Text.ToDecimal();
                        if (currentWeight != oldGrossWeight) {
                                this.BeginInvoke(new Action(() => {
                                    weGrossWeight.Text = oldGrossWeight.ToString();
                                }));
                        }
                }
                if (oldTareWeight > 0) //将皮重还原为上次过皮重的重量
                {
                        decimal currentWeight = weTareWeight.Text.ToDecimal();
                        if (currentWeight != oldTareWeight) {
                                this.BeginInvoke(new Action(() => {
                                    weTareWeight.Text = oldTareWeight.ToString();
                                }));
                        }
                }
                decimal gross = 0;
                if (processMode == MeasureProcessMode.FirstGross) {
                    gross = oldGrossWeight;
                } else {
                    gross = currentGrossWeight;
                    tare = oldTareWeight;
                }
                if (tare > 0 && gross > 0 && tare > gross) {
                    grossTareTransformed = true;
                    currentTareWeight = gross;
                    currentGrossWeight = tare;
                        this.Invoke(new Action(() => {
                            if (weTareWeight != null) {
                                weTareWeight.Text = gross.ToString();
                            }
                            if (weGrossWeight != null) {
                                weGrossWeight.Text = tare.ToString();
                            }
                        }));
                }
            }
        }

        private void wlookCar_TextChanged(object sender, EventArgs e) {
            //避免在无人值守模式下，人工干预称重会覆盖上一次过磅数据的问题
            //CreateNewWeight();
            if (wlookCar != null && wlookCar.Text.Length > 0) {
                LoadUnFinishWeightWithCarNo(wlookCar.Text.Trim());
            }
        }

        public FrmWeight() {
            //线程可以控制控件
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            //gpMainWeight.AutoScroll = true;
            searchList.WeightService = weightService;
            searchList.WeightQueryService = weightQueryService;
        }

        private void FrmWeight_Load(object sender, EventArgs e) {
            try {
                this.FrmMain=GetMain();
                if(FrmMain!=null)Program.frmViewVideoDevice = Program.frmViewVideoDevice;
                currentPort = this.serialPort1;
                currentlblWeight = this.lblWeight1;
                currentDeviceCfg = this.Cfg.Device1;
                using (Utility.GetWaitForm(this)) {
                this.searchList.frmWeight = this;
                    InitCommandBar();
                    InitConfig();
                    InitData();
                    InitAllDevice();
                    Init();
                    if (startAppWeightConfirm) {
                        timerSync.Start();
                    }
                    timerStateSync.Start();
                    if (startReadCard || startIdCardReader) {
                        int interval = 1000;
                        if (readCardCycle > 0)
                            interval = (int)(readCardCycle * 1000);
                        timerReader.Interval = interval;
                        timerReader.Start();
                    }
                    if (startVoice) {
                        //初始化语音朗读器
                        speecher = new SpeechUtil();
                        voiceCfg = CfgUtil.GetVoiceCfg();
                    }
                    InitModBus();
                    //无人职守
                    if (Cfg.MeasureFun == "Nobody") {
                        //判断车辆是否完全驶出地磅
                        this.timerOut = new System.Timers.Timer();
                        decimal autoOutTime = 1;
                        if (Cfg != null && Cfg.NobodyWeight != null && Cfg.NobodyWeight.AutoOutTime > 0) {
                            autoOutTime = Cfg.NobodyWeight.AutoOutTime;
                        }
                        timerOut.Interval = (int)(1000 * autoOutTime);
                        timerOut.Elapsed += TimerOut_Elapsed;
                    }
                    plAutoWeight.Visible = Cfg.StartCarNoRecognition;
                    this.plDevice2.Visible = Cfg.Device2.StartDevice;
                    InitControl();

                    InitRoleControl();

                    //LoadWeight();
                    InitDeviceNo();

                    if ((printPhoto && autoPrintWeight) || startAutoReset || payCode == PayCodeType.Static) {
                        timerAutoTask.Start();
                    }

                    if (wlookCar != null)
                        this.ActiveControl = wlookCar;
                    else {
                        if (weMaterial != null)
                            this.ActiveControl = weMaterial;
                    }
                }
                hasLoaded = true;
                New(true);
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
            if (wlookCar != null) {
                Font f =  CfgUtil.GetFont();
                wlookCar.Properties.AppearanceDropDown.Font = f;
            }

        }

        private void TimerOut_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            if (currentWeighWay == WeightWay.Nobody && CanCarOut()) {
                this.timerOut.Stop();
                isBounding = false;
                isNoteReadCard = false;
                //称重完成,红灯亮,绿灯灭
                RedServerLight(1);
                if (startBoundGate) {
                    if (readerNo == 1) {
                        //关闭2#道闸
                        CloseServerGate(2);
                    } else {
                        //关闭1#道闸
                        CloseServerGate(1);
                    }
                }
                FinishWeightProcess();
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData() {
            try {
                this.lblWeight1.Text = this.Cfg.Device1.ShowFormat;
                this.lblWeight2.Text = this.Cfg.Device2.ShowFormat;
                if (Cfg != null) {
                    if (Cfg.Weight != null && Cfg.Weight.SaveFormData) {
                        saveFormData = true;
                    }
                    if (Cfg.Print != null) {
                        startReWeightTemplate = Cfg.Print.StartReWeightTemplate;
                    }
                }
                if (Cfg != null) {
                    if (Cfg.MeasureFun == "Nobody") {
                        if (this.currentDeviceCfg.SUnit == "GJ" || this.currentDeviceCfg.SUnit == "KG" || this.currentDeviceCfg.SUnit == "kg") {
                            this.minWeightValue = Cfg.NobodyWeight.MinWeightValue * 1000;
                            this.outWeightValue = Cfg.NobodyWeight.OutWeightValue * 1000;
                        } else {
                            this.minWeightValue = Cfg.NobodyWeight.MinWeightValue;
                            this.outWeightValue = Cfg.NobodyWeight.OutWeightValue;
                        }
                    }
                }
                var lstMeasureUnit = masterService.GetSubList(SysCode.MeasureUnit.ToString());
                SCode code = lstMeasureUnit.Find(c => c.ItemCode == currentDeviceCfg.SUnit);
                if (code != null) {
                    lbLeftUnit.Text = code.ItemCaption;
                } else {
                    lbLeftUnit.Text = currentDeviceCfg.SUnit;
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 向仪器发送归零指令
        /// </summary>
        private void SendReturnZero(SendReturnZeroProcessType process) {
            try {
                if (currentDeviceCfg.StartReturnZero && process == currentDeviceCfg.SendReturnZeroProcess&& currentDeviceCfg.ReturnZeroCommand!="") {
                   byte[] byteReturnZeroCmd = ScaleConverter.HexToByte(currentDeviceCfg.ReturnZeroCommand);
                    if (currentPort != null && byteReturnZeroCmd != null) {
                        ShowWeightStateTip("正在向仪表发送归零指令");
                        currentPort.SerlPort.Write(byteReturnZeroCmd, 0, byteReturnZeroCmd.Length);
                    }
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 完成磅单流程
        /// </summary>
        private void FinishWeightProcess() {
            ShowWeightStateTip("本次流程已经结束,下次过磅准备");
            returnZero = true;//重量要归零，后面的磅单才能保存
            hasReadCard = false;
            hasGetCarNo = false;
            isReadingCard = false;
            paySuccess = true;
            isAutoSaving = false;
            needGetPayState = false;
            New(!Cfg.Weight.SaveFormData);
        }


        private bool CanAutoSave() {
            bool canSave = true;
            if (isNewWeight && startSaveWithManualFirst) {
                ShowWeightStateTip("请手动保存重量");
                canSave = false;
            }
            if (!isNewWeight && startSaveWithManualSecond) {
                ShowWeightStateTip("请手动保存重量");
                canSave = false;
            }
            return canSave;
        }
        private DateTime? stableTime = null;
        /// <summary>
        /// 比较返回的重量数据，判断是否稳定
        /// </summary>
        private void CompareWeightValue() {
            bool isStartWeightTimer = StartWeightWeightTimer();
            bool isWeightStable = IsWeightStable();
            //Logger.Info(string.Format("isWeightStable:{0},isStartTimer:{1},isFinished:{2},returnZero:{3},isAutoSaving:{4}",
            //                                             isWeightStable, isStartTimer, isFinished, returnZero, isAutoSaving));
            if (isAutoSaving) return;
            if (isWeightStable) {
                if (stableTime == null) ShowWeightStateTip($"当前重量稳定为{currentStableWeight}");
                stableTime = DateTime.Now;
            } else {
                stableTime = null;
            }
                bool isValidateInfrared = ValidateInfrared();//检查红外遮挡情况
            if (isWeightStable && currentStableWeight > minCredibleWeight&& isStartWeightTimer&& isValidateInfrared) {
                    if (isNewWeight) {
                        if (processMode == MeasureProcessMode.FirstGross) {
                            AutoSetWeight(WeightType.Gross, currentStableWeight);
                        } else {
                            AutoSetWeight(WeightType.Tare, currentStableWeight);
                        }
                    } else {
                        if (processMode == MeasureProcessMode.FirstGross) {
                            AutoSetWeight(WeightType.Tare, currentStableWeight);
                        } else {
                            AutoSetWeight(WeightType.Gross, currentStableWeight);
                        }
                    }
                    isAutoSaving = true;
                    bool isValidated = ValidateForm() && mainWeight.ValidateChildren();
                bool canSave = CanAutoSave();
                if (canSave && isValidated) {
                        AutoWeightSave();
                    }
            }
        }

        /// <summary>
        /// 显示称重数据
        /// </summary>
        private Task ShowWeightInfo(int deviceNo, double value) {
            if (deviceNo == 1) return ShowWeightInfo1(value);
            else if (deviceNo == 2) return ShowWeightInfo2(value);
            return Task.CompletedTask;
        }
        private Task ShowWeightInfo1(double value) {
                value=WeightUtil.GetMinWeight(value, Cfg.Device1);
            string unit = RetCode.UnitFile(Cfg.Device1.SUnit);
                string waterMark = string.Format("{0}重量：{1}{2}", this.wlookCar == null || string.IsNullOrEmpty(this.wlookCar.Text) ? "" : "车牌：" + this.wlookCar.Text + " ", value.ToString(this.Cfg.Device1.ShowFormat), unit);
                if (startVideo) {
                    if (string.IsNullOrEmpty(currentWaterMark)) {
                        currentWaterMark = waterMark;
                        //AddPrintWaterMarkTask(currentWaterMark);
                    } else {
                        if (currentWaterMark != waterMark) {
                            currentWaterMark = waterMark;
                            //AddPrintWaterMarkTask(currentWaterMark);
                        }
                    }
           if(Program.frmViewVideoDevice!=null) Program.frmViewVideoDevice.SetWatermark(currentWaterMark);
            }
            if (lblWeight1 != null && lblWeight1.IsHandleCreated) {
                    this.BeginInvoke(new Action(() => {
                        this.lblWeight1.Text = value.ToString(this.Cfg.Device1.ShowFormat);
                    }));
                }
                this.leftWeightValue = Convert.ToDecimal(value);
                if (value <= 0) {
                    ShowWeightStableState(false, stateWeightStable1);
                }
                if (value <= (double)outWeightValue) {
                    ShowWeightStableState(false, stateWeightStable1);
                    //自动简单称重模式下检测到重量低于归零重量就设置为归零状态
                    if (IsSimpleAuto() && !returnZero) {
                        returnZero = true;
                    }
                    if (!isSendingAd && DateTime.Now.Subtract(lastIdleTime).TotalMinutes >= idleMinutesShowAd && showAd) {
                        bool isStartWeight = StartWeightWeightTimer();
                        if (!isStartWeight) {
                            ThreadPool.QueueUserWorkItem(new WaitCallback(SendAd), false);
                        }
                    }
                }

                //无人职守
                if (Cfg.MeasureFun == "Nobody"&&currentDeviceCfg==Cfg.Device1) {
                    if (value > 0&& value.ToDecimal() >= minCredibleWeight) {
                            //新的判断重量稳定的方法
                            if (lstWeightValue.Count >= samplingCount) {
                                        lstWeightValue.RemoveAt(0);
                                }
                                    lstWeightValue.Add(value);
                            CompareWeightValue();
                    }

            }
            return Task.CompletedTask;
        }
        private Task ShowWeightInfo2(double value) {
                value=WeightUtil.GetMinWeight(value, Cfg.Device2);
                string unit = RetCode.UnitFile(Cfg.Device2.SUnit);
            string waterMark = string.Format("{0}重量：{1}{2}", this.wlookCar == null || string.IsNullOrEmpty(this.wlookCar.Text) ? "" : "车牌：" + this.wlookCar.Text + " ", value.ToString(this.Cfg.Device2.ShowFormat), unit);
                if (startVideo) {
                    if (string.IsNullOrEmpty(currentWaterMark)) {
                        currentWaterMark = waterMark;
                        //AddPrintWaterMarkTask(currentWaterMark);
                    } else {
                        if (currentWaterMark != waterMark) {
                            currentWaterMark = waterMark;
                            //AddPrintWaterMarkTask(currentWaterMark);
                        }
                    }
            }
            if (Program.frmViewVideoDevice != null) Program.frmViewVideoDevice.SetWatermark(currentWaterMark);
            if (lblWeight2 != null && lblWeight2.IsHandleCreated) {
                    this.BeginInvoke(new Action(() => {
                        this.lblWeight2.Text = value.ToString(this.Cfg.Device2.ShowFormat);
                    }));
                }
                this.leftWeightValue = Convert.ToDecimal(value);
                if (value <= 0) {
                    ShowWeightStableState(false, stateWeightStable2);
                }
                if (value <= (double)outWeightValue) {
                    ShowWeightStableState(false, stateWeightStable2);
                    //自动简单称重模式下检测到重量低于归零重量就设置为归零状态
                    if (IsSimpleAuto() && !returnZero) {
                        returnZero = true;
                    }
                    if (!isSendingAd && DateTime.Now.Subtract(lastIdleTime).TotalMinutes >= idleMinutesShowAd && showAd) {
                        bool isStartWeight = StartWeightWeightTimer();
                        if (!isStartWeight) {
                            ThreadPool.QueueUserWorkItem(new WaitCallback(SendAd), false);
                        }
                    }
                }

            //无人职守
            if (Cfg.MeasureFun == "Nobody" && currentDeviceCfg == Cfg.Device2) {
                if (value > 0 && value.ToDecimal() >= minCredibleWeight) {
                    if (lstWeightValue.Count >= samplingCount) {
                        lstWeightValue.RemoveAt(0);
                    }
                    lstWeightValue.Add(value);
                    CompareWeightValue();
                }
            }
            return Task.CompletedTask;
        }

        private void SaveCfg() {
            //searchList.SaveLayout();
            if (loginCfg != null) {
                XmlUtil.Serialize<LoginCfg>(loginCfg, loginCfgXml);
            }
        }

        /// <summary>
        /// 关闭称重仪器串口连接
        /// </summary>
        public void ClosePort() {
            try {
                if (this.serialPort1 != null) {
                    this.serialPort1.ClosePort();
                    this.serialPort1 = null;
                }
                if (this.serialPort2 != null) {
                    this.serialPort2.ClosePort();
                    this.serialPort2 = null;
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 是否需要确认
        /// </summary>
        /// <returns></returns>
        public bool NeedConfirmExit() {
            bool needConfirm = false;
            if (hasGetCarNo)
                needConfirm = true;
            if (hasReadCard)
                needConfirm = true;
            return needConfirm;
        }

        private void FrmWeight_FormClosing(object sender, FormClosingEventArgs e) {
            bool canExit = true;
            bool needConfirm = NeedConfirmExit();
            if (needConfirm) {
                canExit = false;
                string message = "系统正在过磅,如果此刻退出则数据不会保存,确定要退出系统吗?";
                if (MessageDxUtil.ShowYesNoAndTips(message) == DialogResult.Yes) {
                    canExit = true;
                }
            }
            if (!canExit)
                e.Cancel = true;
        }

        private void FrmWeight_FormClosed(object sender, FormClosedEventArgs e) {
            if (timerAutoTask != null && timerAutoTask.Enabled) {
                timerAutoTask.Stop();
                timerAutoTask.Dispose();
            }
            SaveCfg();
            ClosePort();

            //关闭语音朗读器
            if (Cfg != null && Cfg.Weight.StartVoicePrompt && this.speecher != null) {
                this.speecher = null;
            }

            //启用读卡器
            if (Cfg != null && Cfg.StartReadCard) {
                //断开1#RF35读卡器串口连接
                if (this.icdevLeft > 0)
                    RF35Util.rf_exit(this.icdevLeft);
                //断开2#RF35读卡器串口连接
                if (this.icdevRight > 0)
                    RF35Util.rf_exit(this.icdevRight);
                //断开1#远程读卡器串口连接
                if (remoteReaderLeft != null) {
                    remoteReaderLeft.ClosePort();
                    remoteReaderLeft = null;
                }
                //断开2#远程读卡器串口连接
                if (remoteReaderRight != null) {
                    remoteReaderRight.ClosePort();
                    remoteReaderRight = null;
                }
                //关闭定时器
                if (timerReader != null && timerReader.Enabled) {
                    timerReader.Stop();
                    timerReader = null;
                }
            }
            if (Cfg != null && Cfg.StartCarNoRecognition) //启用车牌识别一体机
            {
                if (Cfg.CarNoRecognition != null) {
                    if (Cfg.CarNoRecognition.Recognition == "KHT" && ((this.khtRecognizerLeft != null && this.khtRecognizerLeft.IsRecoRan) || (this.khtRecognizerRight != null && this.khtRecognizerRight.IsRecoRan))) {
                        if (this.khtRecognizerLeft != null) {
                            this.khtRecognizerLeft = null;
                        }
                        if (this.khtRecognizerRight != null) {
                            this.khtRecognizerRight = null;
                        }
                        //关闭快号通车牌识别一体机
                        KHTUtil.Release();
                    } else if (Cfg.CarNoRecognition.Recognition == "KHTNew" && khtNewRecognizer != null) {
                        khtNewRecognizer.Release();
                    } else if (Cfg.CarNoRecognition.Recognition == "GQ" && ((this.gqRecognizerLeft != null && this.gqRecognizerLeft.IsRecoRan) || (this.gqRecognizerRight != null && this.gqRecognizerRight.IsRecoRan))) {
                        if (this.gqRecognizerLeft != null) {
                            this.gqRecognizerLeft = null;
                        }
                        if (this.gqRecognizerRight != null) {
                            this.gqRecognizerRight = null;
                        }
                        //关闭高清车牌识别一体机
                        GQUtil.GQ_Release();
                    } else if (Cfg.CarNoRecognition.Recognition == "ASB_NEW") {
                        if (asbNewRecognizerLeft != null) {
                            asbNewRecognizerLeft.Release();
                            asbNewRecognizerLeft = null;
                        }
                        if (asbNewRecognizerRight != null) {
                            asbNewRecognizerRight.Release();
                            asbNewRecognizerRight = null;
                        }
                    }
                }
            }
            //无人职守
            if (Cfg != null && Cfg.MeasureFun == "Nobody") {
                ReleaseModBus();
                //关闭无人值守车辆驶出检测定时器
                if (this.timerOut != null && this.timerOut.Enabled) {
                    this.timerOut.Stop();
                    this.timerOut = null;
                }
            }
            ReleaseIdCardReader();
            ReleaseCarPlate();
        }


        private void PrintView() {
            if (string.IsNullOrEmpty(searchList.CurrentWeightId)) {
                MessageDxUtil.ShowWarning("请选择要预览的磅单");
            } else {
                DataSet dsReport = new DataSet();
                SReportTemplate template = reportService.GetDefaultTemplate(DocumentType.Weight);
                dsReport = reportService.GetWeight(searchList.CurrentViewId, searchList.CurrentWeightId);
                FrmXReport frmReport = new FrmXReport();
                if (template != null) {
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                        if (!string.IsNullOrEmpty(template.TemplateUrl)) {
                            frmReport.ReportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                        }
                    } else {
                        SReportTemplate templateFind = reportService.Get(template.Id);
                        frmReport.ReportFilePath = Utility.GetReportTemplate(templateFind);
                    }
                } else {
                    frmReport.ReportFilePath = Application.StartupPath + "\\Report\\Weight\\rptDefault.repx";
                }
                frmReport.Parameters=new System.Collections.Hashtable();
                frmReport.Parameters.Add("当前时间",DateTime.Now);
                frmReport.DataSource = dsReport;
                frmReport.DisplayName = "磅单报表";
                frmReport.Text = "磅单报表";
                frmReport.WindowState = FormWindowState.Maximized;
                frmReport.StartPosition = FormStartPosition.CenterScreen;
                frmReport.ShowDialog();
            }
        }

        public void Print(string weightId) {
            Hashtable parameters = new Hashtable {
                { "当前时间", DateTime.Now }
            };
            PrintUtil.PrintWeightReport(searchList.CurrentViewId, weightId, reportService, weightPrinterName);
            if (appendPrintTemp) {
                PrintUtil.PrintWeightReport(searchList.CurrentViewId, weightId, DocumentType.TemporaryWeight, reportService, parameters, weightTempPrinterName);
            }
            weightService.UpdatePrint(weightId);
        }

        /// <summary>
        /// 打印临时磅单
        /// </summary>
        private void PrintTemp() {
            if (string.IsNullOrEmpty(searchList.CurrentWeightId)) {
                MessageDxUtil.ShowWarning("请选择要打印的磅单");
                searchList.Focus();
            } else {
                PrintUtil.PrintWeightReport(searchList.CurrentViewId, searchList.CurrentWeightId, DocumentType.TemporaryWeight, reportService, null, weightTempPrinterName);
            }
        }

        /// <summary>
        /// 废除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemInvalid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (searchList.InvalidWeight()) {
                searchList.LoadData();
            }
        }

        /// <summary>
        /// 初始化近距离读卡器
        /// </summary>
        private void InitShortReader() {
            bool isOpenFirst = false;
            bool isOpenSecond = false;
            try {
                ReadCardCfg cardCfg = Cfg.LstReadCard.Find(item => item.Type == ReadCardType.Short);
                if (cardCfg != null) {
                    short port = 0;
                    if (!string.IsNullOrEmpty(cardCfg.SerialPort1)) {
                        port = Convert.ToInt16(Convert.ToInt32(cardCfg.SerialPort1.Substring(3, cardCfg.SerialPort1.Length - 3)) - 1);
                        if (this.icdevLeft == 0) {
                            //初始化1#读卡器
                            this.icdevLeft = RF35Util.rf_init(port, 9600);
                            if (this.icdevLeft > 0) {
                                byte[] key = { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
                                //装载初始密码
                                if (RF35Util.rf_load_key(this.icdevLeft, 0, 0, key) != 0 || RF35Util.rf_load_key(this.icdevLeft, 0, 1, key) != 0) {
                                    this.icdevLeft = 0;
                                    Logger.Write("1#近距离读卡器装载初始密码失败，请重试！");
                                    ShowWeightStateTip("1#近距离读卡器装载初始密码失败");
                                } else {
                                    isOpenFirst = true;
                                    Logger.Write("1#RF35读卡器初始化成功！");
                                    ShowWeightStateTip("1#近距离读卡器连接成功");
                                }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(cardCfg.SerialPort2)) {
                        port = Convert.ToInt16(Convert.ToInt32(cardCfg.SerialPort2.Substring(3, cardCfg.SerialPort2.Length - 3)) - 1);
                        if (this.icdevRight == 0) {
                            //初始化2#读卡器
                            this.icdevRight = RF35Util.rf_init(port, 9600);
                            if (this.icdevRight > 0) {
                                byte[] key = { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
                                //装载初始密码
                                if (RF35Util.rf_load_key(this.icdevRight, 0, 0, key) != 0 || RF35Util.rf_load_key(this.icdevRight, 0, 1, key) != 0) {
                                    this.icdevRight = 0;
                                    Logger.Write("2#RF35读卡器装载初始密码失败，请重试！");
                                    ShowWeightStateTip("2#近距离读卡器装载初始密码失败");
                                } else {
                                    isOpenSecond = true;
                                    Logger.Write("2#RF35读卡器初始化成功！");
                                    ShowWeightStateTip("2#近距离读卡器连接成功");
                                }
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 初始化远程读卡器
        /// </summary>
        private void InitRemoteReader() {
            bool isOpenFirst = false;
            bool isOpenSecond = false;
            try {
                ReadCardCfg cardCfg = Cfg.LstReadCard.Find(item => item.Type == ReadCardType.Remote);
                if (cardCfg != null) {
                    int port = 0;
                    if (!string.IsNullOrEmpty(cardCfg.SerialPort1)) {
                        port = Convert.ToInt32(cardCfg.SerialPort1.Substring(3, cardCfg.SerialPort1.Length - 3));
                        if (this.remoteReaderLeft == null) {
                            //初始化1#读卡器
                            this.remoteReaderLeft = new UHFReader18Util(port);
                            //打开串口
                            isOpenFirst = this.remoteReaderLeft.OpenPort();
                            if (isOpenFirst) {
                                Logger.Write("成功开启1#远距离读卡器");
                                ShowWeightStateTip("成功开启1#远距离读卡器");
                                //设置1#读卡器工作模式
                                isOpenFirst = this.remoteReaderLeft.SetReaderWorkMode(0, 16);
                                if (isOpenFirst && cardCfg.ApplyParameter && cardCfg.PowerDbm > 0) {
                                    //设置1#读卡器功率
                                    isOpenFirst = this.remoteReaderLeft.SetReaderPowerDbm(cardCfg.PowerDbm);
                                }
                            } else {
                                this.remoteReaderLeft.ClosePort();
                                this.remoteReaderLeft = null;
                                Logger.Write("1#远程读卡器连接串口失败！");
                                ShowWeightStateTip("1#远程读卡器连接失败");
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(cardCfg.SerialPort2)) {
                        port = Convert.ToInt32(cardCfg.SerialPort2.Substring(3, cardCfg.SerialPort2.Length - 3));
                        if (this.remoteReaderRight == null) {
                            //初始化2#读卡器
                            this.remoteReaderRight = new UHFReader18Util(port);
                            //打开串口
                            isOpenSecond = this.remoteReaderRight.OpenPort();
                            if (isOpenSecond) {
                                Logger.Write("成功开启2#远距离读卡器");
                                ShowWeightStateTip("成功开启2#远距离读卡器");
                                //设置2#读卡器工作模式
                                isOpenSecond = this.remoteReaderRight.SetReaderWorkMode(0, 16);
                                if (isOpenSecond && cardCfg.ApplyParameter && cardCfg.PowerDbm > 0) {
                                    //设置2#读卡器功率
                                    this.remoteReaderRight.SetReaderPowerDbm(cardCfg.PowerDbm);
                                }
                            } else {
                                this.remoteReaderRight.ClosePort();
                                this.remoteReaderRight = null;
                                Logger.Write("2#远程读卡器连接串口失败！");
                                ShowWeightStateTip("2#远程读卡器连接失败");
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }

        private bool CanEnterReadCard {
            get { return !hasReadCard; }
        }

        private bool CanOpenDoubleGate() {
            bool canOpen = false;
            if (startBoundGate
                && (weightProcessTrigger == WeightProcessTriggerType.Card || weightProcessTrigger == WeightProcessTriggerType.CarRecognitionOrCard))//双道闸方式
            {
                canOpen = true;
            }
            return canOpen;
        }

        /// <summary>
        /// 读取卡号
        /// </summary>
        private void ReadCard() {
            try {
                bool isValidated = false;
                string cardId = string.Empty;
                string cardNo = string.Empty;
                bool isSuccess = false;
                if (cardType == ReadCardType.Short) {
                    isSuccess = ReadeShortCardSN(icdevLeft, ref cardId);
                    isValidated = ValidateCard(cardId);
                    //if (isSuccess && isValidated && weightProcessTrigger == WeightProcessTriggerType.Card)
                    if (isSuccess && isValidated) {
                            this.readerNo = 1;
                        //1#道闸红灯灭、绿灯亮
                        GreeServerLight(readerNo);
                        OpenServerGate(this.readerNo);
                    }
                    //无人值守双道闸模式,1号IC卡读取失败情况下
                    if (!isSuccess) {
                        isSuccess = ReadeShortCardSN(icdevRight, ref cardId);
                        //if (isSuccess && isValidated && weightProcessTrigger == WeightProcessTriggerType.Card)
                        if (isSuccess && isValidated) {
                            this.readerNo = 2;
                        }
                    }
                    if (isSuccess) {
                        isValidated = ValidateCard(cardId);

                    }
                }
                if (cardType == ReadCardType.Remote) {
                    isSuccess = ReadRemoteCardSN(remoteReaderLeft, ref cardId);
                    if (Cfg.MeasureFun == "Nobody") {
                        isValidated = ValidateCard(cardId);
                        //if (isSuccess && isValidated && weightProcessTrigger == WeightProcessTriggerType.Card)
                        if (isSuccess && isValidated) {
                            this.readerNo = 1;
                            if (CanOpenDoubleGate()) {
                                //1#道闸红灯灭、绿灯亮
                                GreeServerLight(1);
                                //开启道闸
                                OpenServerGate(1);
                            }
                        }
                        //无人值守双道闸模式,1号IC卡读取失败情况下
                        if (!isSuccess) {
                            isSuccess = ReadRemoteCardSN(remoteReaderRight, ref cardId);
                            isValidated = ValidateCard(cardId);
                            //if (isSuccess && isValidated && weightProcessTrigger == WeightProcessTriggerType.Card)
                            if (isSuccess && isValidated && CanOpenDoubleGate()) {
                                this.readerNo = 2;
                                //2#道闸红灯灭、绿灯亮
                                GreeServerLight(2);
                                //开启道闸
                                CloseServerGate(2);
                            }
                        }
                    }
                }
                //识别到有效的卡号
                //Logger.Write(string.Format("CardId:{0},IsValidated:{1}",cardId,isValidated));
                if (!string.IsNullOrWhiteSpace(cardId) && cardId.Length > 0 && isValidated) {
                    lastWeightStartTime = DateTime.Now;
                    ShowWeightStateTip(string.Format("读取到有效的IC卡({0})", cardId));
                    returnZero = true;
                    hasReadCard = true;
                    if (weightProcessTrigger == WeightProcessTriggerType.CarRecognitionOrCard) {
                        hasGetCarNo = true;
                    }
                    if (!hasLoadUnFinishWeight && weightProcessTrigger == WeightProcessTriggerType.Card) {
                        //CreateNewWeight();
                    }
                    //读卡，判断卡是否存在
                    if (currentCard == null) {
                        currentCard = CardCacher.Get(cardId, cardService, false);
                    }
                    LoadCard(currentCard);
                    if (startVoice) {
                        //语音提示车辆上磅称重
                        this.speecher.Speak(this.voiceCfg.ReadCardSuccess);
                    }
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 读取身份证信息
        /// </summary>
        private void ReadIdCard() {
            try {
                if (!hasGetIdCardNo && idCardReader != null) {
                    IdCardInfo info = idCardReader.Read();
                    if (info != null) {
                        ShowWeightStateTip(string.Format("已经读取到身份证:{0}", info.IdNo));
                        hasGetIdCardNo = true;
                        if (startGenerateCustomer) {
                            SCustomer customer = masterService.GetCustomerByIdCard(CustomerType.Customer, info.IdNo);
                            if (customer == null) {
                                customer = new SCustomer();
                                customer.CustomerType = CustomerType.Customer.ToString();
                                customer.CustomerName = info.FullName;
                                customer.IdCard = info.IdNo;
                                customer.Id = YF.MWS.Util.Utility.GetGuid();
                                customer.PYCustomerName = PinYinUtil.GetInitial(customer.CustomerName);
                                customer.CustomerCode = seqNoService.GetSeqNo(SeqCode.Customer.ToString());
                                customer.Addr = info.Address;
                                masterService.SaveCustomer(customer);
                                CustomerCacher.Remove();
                            }
                            if (customer != null) {
                                if (wlookupCustomer != null)
                                    wlookupCustomer.CurrentValue = customer.Id;
                            }
                        }
                        BeginInvoke(new Action(() => {
                            if (weWaybillNo != null)
                                weWaybillNo.CurrentValue = info.IdNo;
                            if (weDriverName != null)
                                weDriverName.CurrentValue = info.FullName;
                        }));
                    }
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }

        private void timerReader_Tick(object sender, EventArgs e) {
            lock (lockObj) {
                if (!isReadingCard) {
                    isReadingCard = true;
                    if (CanEnterReadCard) {
                        ReadCard();
                    }
                    if (startIdCardReader && openCardReader) {
                        ReadIdCard();
                    }
                    isReadingCard = false;
                }
            }
        }

        /// <summary>
        /// 安视宝车牌识别结果处理函数
        /// </summary>
        /// <param name="recResult">识别结果</param>
        private void ASBRecognizePlate(ASBPlateInfo resInfo) {
            try {
                if (hasGetCarNo) {
                    return;
                }
                if (leftWeightValue > minCredibleWeight) {
                    return;
                }
                string strIP = resInfo.IP.TrimEnd('\0');
                if (!string.IsNullOrEmpty(strIP)) {
                    if (strIP == Cfg.CarNoRecognition.IP1) {
                        //1#车牌识别仪识别车牌
                        this.readerNo = 1;
                    } else if (strIP == Cfg.CarNoRecognition.IP2) {
                        //2#车牌识别仪识别车牌
                        this.readerNo = 2;
                    }
                }


                string strPlate = resInfo.Num.TrimEnd('\0');
                if (!string.IsNullOrEmpty(strPlate)) {
                    hasGetCarNo = true;
                    this.BeginInvoke(new Action(() => {
                        //SendReturnZero("car recognize asb");
                        Logger.Write(string.Format("ASB car no:{0}", strPlate));
                        wlookCar.Text = strPlate;
                        wlookCar.CurrentValue = string.Empty;
                        AddCarRecognitionPhoto(resInfo);
                    }));
                        //1#车牌识别仪识别车牌
                        if (this.readerNo == 1) {
                            //红灯灭、绿灯亮
                            this.modbusLeft.SendControl(5, 0, 0);
                            this.modbusLeft.SendControl(5, 1, 1);
                        } else {
                            //红灯灭、绿灯亮
                            this.modbusLeft.SendControl(5, 4, 0);
                            this.modbusLeft.SendControl(5, 5, 1);
                        }
                            //开启道闸
                        CloseServerGate(this.readerNo);

                        if (Cfg.Weight.StartVoicePrompt) {
                            //语音提示车辆上磅称重
                            //MediaUtil.PlayAsync("./Sound/RECARNO.WAV");
                            this.speecher.Speak(this.voiceCfg.CarRecognition);
                        }
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }


        /// <summary>
        /// 大华车牌识别结果处理函数
        /// </summary>
        /// <param name="recResult">识别结果</param>
        private void DHRecognizePlate(PlateInfo resInfo) {
            CarRecognize(resInfo);
        }

        /// <summary>
        /// 高清车牌识别结果处理函数
        /// </summary>
        /// <param name="recResult">识别结果</param>
        private void GQRecognizePlate(PlateInfo resInfo) {
            CarRecognize(resInfo);
        }

        /// <summary>
        /// 新建一个磅单
        /// </summary>
        private void CreateNewWeight() {
            isNewWeight = true;
            currentWeightId = YF.MWS.Util.Utility.GetGuid();
            currentWeight = null;
            currentTareWeight = 0;
            oldTareWeight = 0;
            oldGrossWeight = 0;
            tempWeight = null;
            currentGrossWeight = 0;
        }

        private void LoadWeight(string weightId) {
            BWeight weight = weightService.Get(weightId);
            if (weight == null)
                return;
            if (weight.FinishState == (int)FinishState.Finished)
                return;
            LoadWeight(weight, true);
        }

        private void LoadWeight(BWeight weight, bool loadCar) {
            if (weight == null) {
                if (Cfg.MeasureFun == "People") {
                    MessageDxUtil.ShowWarning("加载磅单时发生未知错误,请重试.");
                } else {
                    Logger.Write("加载磅单时发生未知错误！");
                }
                return;
            }
            isNewWeight = false;
            mainWeight.BindControl<BWeight>(weight);
            if (wlookCar != null && loadCar) {
                wlookCar.Text = weight.CarNo;
                wlookCar.CurrentValue = weight.CarId;
            }
            if (string.IsNullOrEmpty(weight.CarId) && !string.IsNullOrEmpty(weight.CarNo)) {
                if (wlookCar != null)
                    wlookCar.Text = weight.CarNo;
            }
            if (oldTareWeight > 0)
                processMode = MeasureProcessMode.FirstTare;
            else
                processMode = MeasureProcessMode.FirstGross;
            if (weGrossWeight != null && weight.GrossWeight > 0) {
                weGrossWeight.Text = weight.GrossWeight.ToString();
            }
            if (saveFormData && weight.UnitPrice == 0 && weUnitPrice != null)
                weUnitPrice.Text = residentUnitPrice.ToString();
        }

        private void LoadWeightWithExecutedControl(string weightId, List<string> lstExecutedField) {
            currentWeight = weightService.Get(weightId);
            if (currentWeight == null) {
                if (Cfg.MeasureFun == "People") {
                    MessageDxUtil.ShowWarning("加载磅单时发生未知错误,请重试.");
                } else {
                    Logger.Write("加载磅单时发生未知错误！");
                }
                return;
            }
            mainWeight.BindControl<BWeight>(currentWeight);
        }
        /// <summary>
        /// 获取当前称重重量
        /// </summary>
        private decimal GetCurrentWeight() {
            return currentlblWeight.Text.ToDecimal();
        }

        /// <summary>
        /// 将重量信息显示在称重控件中
        /// </summary>
        /// <param name="weightType"></param>
        /// <param name="weight"></param>
        private void AutoSetWeight(WeightType weightType, decimal weight) {
            if (weight <= 0)
                return;
            ShowWeightStateTip("自动读取稳定重量:" + weight);
            if (weightType == WeightType.Tare) {
                currentTareWeight = weight;
                    this.Invoke(new Action(() => {
                        if (weTareWeight != null) {
                            weTareWeight.Text = weight.ToString();
                        }
                    }));
            } else {
                currentGrossWeight = weight;
                    this.Invoke(new Action(() => {
                        if (weGrossWeight != null) {
                            weGrossWeight.Text = weight.ToString();
                        }
                    }));
            }
            TareGrossTransform();
        }

        private void ClearWeightControl() {      
            this.lstWeightValue.Clear();
            this.isNoteCheckCar = false;
            this.checkCarCount = 0;
            currentPlan = null;
            currentWeight = null;
            overWeight = 0;
            refusePay = false;
            finishPadInput = false;
            hasLoadUnFinishWeight = false;
            grossTareTransformed = false;
            hasGetIdCardNo = false;
            processMode = oldProcessMode;
        }

        /// <summary>
        /// 保存视频、图片文件
        /// </summary>
        private void SaveFile() {
            try {
                if (lstTempFile != null && lstTempFile.Count > 0) {
                    foreach (BFile file in lstTempFile) {
                        if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver) {
                            //file.FileContent = File.ReadAllBytes(Path.Combine(Application.StartupPath, file.FileUrl));
                        }
                        fileService.Add(file);
                    }
                    lstTempFile.Clear();
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }

        private bool CurrentDateChanged() {
            bool isChanged = false;
            if (Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd")) > currentDate) {
                currentDate = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
                isChanged = true;
            }
            return isChanged;
        }

        public bool Save() {
            bool isSaved = false;
            try {
                bool isNew = false;
                decimal weight = GetCurrentWeight();
                OrderSource source = OrderSource.Weight;
                SaveWeightInputItem();
                if (CurrentClient.Instance.IsSimulateWeight) {
                    source = OrderSource.SimulateWeight;
                }
                if (currentWeight == null) {
                    isNew = true;
                    currentWeight = new BWeight();
                    currentWeight.MachineCode = CurrentClient.Instance.MachineCode;
                } else {
                    if (!grossTareTransformed) {
                        currentWeight.TareMachineCode = currentWeight.MachineCode;
                        currentWeight.MachineCode = CurrentClient.Instance.MachineCode;
                    } else {
                        currentWeight.TareMachineCode = CurrentClient.Instance.MachineCode;
                    }
                }
                currentWeight.Id = currentWeightId;
                mainWeight.ControlToEntity(ref currentWeight);
                currentWeight.FinishTime = DateTime.Now;
                currentWeight.WeighterId = CurrentUser.Instance.Id;
                if (wlookCar != null) {
                    if (wlookCar.CurrentValue != null && wlookCar.CurrentValue.ToObjectString().Length > 0) {
                        currentWeight.CarId = wlookCar.CurrentValue.ToObjectString();
                    }
                    currentWeight.CarNo = wlookCar.Text;
                }
                if (wCardNo != null) {
                    currentWeight.CardNo = wCardNo.Text;
                }
                FinishState state = FinishState.Unfinished;
                    if (currentWeight.TareWeight > 0 && currentWeight.GrossWeight > 0) {
                        state = FinishState.Finished;
                    }
                currentWeight.OrderSource = source.ToString();
                currentWeight.FinishState = (int)state;
                currentWeight.MeasureUnit = currentDeviceCfg.SUnit;
                currentWeight.WeightProcess = (int)currentWeightProcess;
                currentWeight.ViewId = CurrentClient.Instance.ViewId;
                currentWeight.WeighterName = CurrentUser.Instance.FullName;
                currentWeight.SuttleWeight = Math.Abs(currentWeight.GrossWeight - currentWeight.TareWeight);
                currentWeight.WarehBizType = radWarehBizType.EditValue.ToString();
                currentWeight.CompanyId = CurrentUser.Instance.CompanyId;
                if (refusePay && currentWeight.FinishState == (int)FinishState.Finished) {
                    currentWeight.SuttleWeight = 0;
                }
                if (startOverWeight) {
                    currentWeight.MaxWeight = maxWeight;
                    currentWeight.OverWeight = overWeight;
                    if (overWeight > 0) {
                        currentWeight.OverWeightState = 1;
                    } else {
                        currentWeight.OverWeightState = 0;
                    }
                } else {
                    currentWeight.OverWeightState = 0;
                }
                currentWeight.SyncState = (int)SyncState.UnSynced;
                if (string.IsNullOrEmpty(currentWeight.WeightNo)  //生成磅单号
                    &&((weightNoGenerateMode == FinishState.Finished&& currentWeight.FinishState==1)  //如果是完成榜单时生成磅单并且当前磅单是完成状态
                    || weightNoGenerateMode == FinishState.Unfinished)) //如果是开始过磅时就生成磅单
                        currentWeight.WeightNo = seqNoService.GetSeqNo(SeqCode.Weight.ToString());
                if (startWeightPay && currentChargeTriggerCondtion == ChargeTriggerCondtionType.FinishWeight) {
                    if (currentWeight.FinishState == (int)FinishState.Unfinished)
                        currentWeight.RegularCharge = 0;
                }
                if (isNew && startPlan) {
                    if (currentPlan != null)
                        currentWeight.RefId = currentPlan.Id;
                }
                isSaved = weightService.Save(currentWeight);
                if (!isSaved) {
                    isSaved = weightService.Save(currentWeight);
                }
                if (isSaved && startPlan && !string.IsNullOrEmpty(currentWeight.RefId)) {
                    planService.Update(currentWeight);
                }
                if (isSaved&&Cfg.Transfer.isOpen&&currentWeight.FinishState == 1) {//
                    Thread thread = new Thread(new ParameterizedThreadStart(sendWeight));
                    thread.Start(currentWeight);
                }
                if (isNew && !isSaved) {
                    seqNoService.Cancel(SeqCode.Weight.ToString());
                }
                if (autoSaveTareWeight) {
                    SaveCarWithTareWeight(currentWeight);
                }
                //无人值守模式下保存重量后，将是否归零设为False，是为了反正重复保存
                if (isSaved && currentWeighWay == WeightWay.Nobody) {
                    returnZero = false;
                }
                BPay pay = null;
                if (isSaved && startWeightPay) {
                    if (currentWeight.RegularCharge <= 0) {
                        paySuccess = true;
                    } else {
                        if (currentChargeTriggerCondtion == ChargeTriggerCondtionType.NewWeight) {
                            if (isNew)
                                pay = SavePay(currentWeight.Id, currentWeight.CarNo, currentWeight.WeightNo, currentWeight.RegularCharge, currentWeight.GrossWeight);
                            else
                                paySuccess = true;
                        }
                        if (currentChargeTriggerCondtion == ChargeTriggerCondtionType.FinishWeight) {
                            if (isNew)
                                paySuccess = true;
                            if (currentWeight.FinishState == (int)FinishState.Finished)
                                pay = SavePay(currentWeight.Id, currentWeight.CarNo, currentWeight.WeightNo, currentWeight.RegularCharge, currentWeight.GrossWeight);
                        }
                    }
                }
                SendReturnZero(SendReturnZeroProcessType.WeightSaved);
                if (isSaved) {
                  FrmMain.CapturePicture(currentWeight.Id,string.Format("当前时间：{0}，称重重量：{1}",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),currentWeight.TareWeight),FileType.CarLeft);
                }
                this.SaveFile();
                if (isSaved && isNew && startAppWeightConfirm) {
                    AddWeightConfirm(currentWeight);
                }
                //如果设置了自动打印，则开启自动打印磅单功能
                if (autoPrintWeight&& (CurrentUser.Instance.Powers != null &&CurrentUser.Instance.Powers.Contains("p2_5"))) {
                    Print(currentWeight.Id);
                }
                if (printPhoto&& CurrentUser.Instance.Powers != null && CurrentUser.Instance.Powers.Contains("p2_5")) {
                    PrintUtil.PrintWeightReportPdf(currentViewId, currentWeight, reportService, null, weightPrinterName);
                }
                if (startScreen) {
                    string info = GetLedInfo(currentWeight);
                    SendInfoToLed(WeightFlowType.WeightStable, info);
                }
                if (isSaved) {
                    RefreshWeightControl();
                    ShowWeightStateTip(string.Format("磅单({0})已经成功保存", currentWeight.WeightNo));
                } else {
                    ShowWeightStateTip("磅单保存失败");
                }
                if (CurrentDateChanged()) {
                    searchList.InitWeightDate();
                }

                Task.Factory.StartNew(new Action(() => {
                    searchList.LoadData();
                }));

                //人工称重
                if (Cfg.MeasureFun == "People") {
                    //MessageDxUtil.ShowTips("成功保存磅单信息.");
                    readerNo = 0;
                }
            } catch (Exception ex) {
                isSaved = false;
                Logger.WriteException(ex);
                //人工称重
                if (Cfg.MeasureFun == "People") {
                    MessageDxUtil.ShowError("保存磅单信息时发生未知错误,请重试.");
                }
            } finally {
                New(!Cfg.Weight.SaveFormData);
            }
            return isSaved;
        }
        private void sendWeight(object obj) {
            BWeight weight=obj as BWeight;
            if (obj == null) return;
            webWeightService.doneWeight(currentWeight);
        }

        private void btnPrint_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(searchList.CurrentWeightId)) {
                MessageDxUtil.ShowWarning("请选择要打印的磅单");
                return;
            }
            BWeight weight = weightService.Get(searchList.CurrentWeightId);
            bool canPrint = CanPrint(weight);
            if (canPrint) {
                Print(searchList.CurrentWeightId);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            ManualSave();
        }

        private void btnWeight_Click(object sender, EventArgs e) {
            decimal weight = GetCurrentWeight();
            setMainWeight(weight);
        }
        private void setMainWeight(decimal weight) {
            if (tempWeight == null) tempWeight = new BWeight();
            //第一次毛重
            if (Cfg.Weight.ProcessMode == 0) {
                if (weGrossWeight != null && weGrossWeight.Text.ToDecimal() <= 0) {
                    weGrossWeight.Text = weight.ToString();
                    tempWeight.GrossTime = DateTime.Now;
                    tempWeight.GrossWeight = weight;
                    tempWeight.FinishState = 0;
                    tempWeight.MeasureType = "gross";
                } else if (weTareWeight != null) {
                    weTareWeight.Text = weight.ToString();
                    tempWeight.TareTime = DateTime.Now;
                    tempWeight.TareWeight = weight;
                    tempWeight.FinishState = 1;
                    tempWeight.MeasureType = "tare";
                }
            } else if (Cfg.Weight.ProcessMode ==MeasureProcessMode.FirstTare) { //第一次皮重时
                if (weTareWeight != null&&weTareWeight.Text.ToDecimal() <= 0) {
                    weTareWeight.Text = weight.ToString();
                    tempWeight.TareTime = DateTime.Now;
                    tempWeight.TareWeight = weight;
                    tempWeight.FinishState = 0;
                    tempWeight.MeasureType = "tare";
                } else if(weGrossWeight!=null){
                    weGrossWeight.Text = weight.ToString();
                    tempWeight.GrossTime = DateTime.Now;
                    tempWeight.GrossWeight = weight;
                    tempWeight.FinishState = 1;
                    tempWeight.MeasureType = "gross";
                }
            }
        }
        private void FrmWeight_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control) {
                if (e.KeyCode == Keys.D) {
                    e.Handled = true;
                    if (btnWeight.Visible) {
                        btnWeight.PerformClick();
                    }
                }
            }
        }

        private void InitDeviceNo() {
            WTextEdit wDeviceNo = mainWeight.FindControl<WTextEdit>("DeviceNo");
            if (wDeviceNo != null) {
                wDeviceNo.Text = string.Format("{0}号", currentDeviceNo);
            }
        }

        private void btnPrintView_Click(object sender, EventArgs e) {
            PrintView();
        }
        #region 模拟称重
        /// <summary>
        /// 虚拟称重
        /// </summary>
        private void timerSimulate_Tick(object sender, EventArgs e) {
            if (!CurrentClient.Instance.IsSimulateWeight) return;
            double weight = simulateWeight.run();
            Console.WriteLine("weight:"+weight);
            ShowWeightInfo(currentDeviceNo, weight);
        }
        #endregion

        private void timerAutoTask_Tick(object sender, EventArgs e) {
            lock (lockAutoObj) {
                if (!isAutoTaskRuning) {
                    isAutoTaskRuning = true;
                    if (needGetPayState) {
                        ShowWeightStateTip("正在获取支付状态");
                        int payState = payService.GetPayState(currentPayRefId);
                        if (payState == (int)PayState.PaySuccess) {
                            ShowWeightStateTip("恭喜您支付成功");
                            paySuccess = true;
                            needGetPayState = false;
                            HandleGateAfterSave();
                        }
                    }
                    if (startAutoReset) {
                        if (CanEnterReset()) {
                            FinishWeightProcess();
                            lastWeightStartTime = DateTime.Now;
                        }
                    }
                    if (startAutoInvalid) {
                        AutoInvalidWeight();
                    }
                    if (printPhoto && autoPrintWeight) {
                        List<BTask> tasks = taskService.GetAutoPrintList();
                        if (tasks != null && tasks.Count > 0) {
                            foreach (BTask task in tasks) {
                                this.BeginInvoke(new Action(() => {
                                    if (task.TaskType == TaskType.AutoPrintTemp.ToString()) {
                                        AutoPrint(task.RefId, DocumentType.TemporaryWeight);
                                    } else {
                                        AutoPrint(task.RefId, DocumentType.Weight);
                                    }
                                }));
                                taskService.DeleteTask(task.Id);
                            }
                        }
                    }
                    isAutoTaskRuning = false;
                }
            }
        }
        private void timerSync_Tick(object sender, EventArgs e) {
            if (!isSyncing) {
                isSyncing = true;
                if (startAppWeightConfirm) {
                    SyncWeightConfirm();
                }
                isSyncing = false;
            }
        }

        private void rgWeightProcess_SelectedIndexChanged(object sender, EventArgs e) {
            currentWeightProcess = rgWeightProcess.EditValue.ToEnum<WeightProcess>();
        }

        private void btnOpenFirstGate_Click(object sender, EventArgs e) {
            OpenServerGate(1);
        }

        private void btnCloseFirstGate_Click(object sender, EventArgs e) {
            CloseServerGate(1);
        }

        private void btnOpenSecondGate_Click(object sender, EventArgs e) {
            OpenServerGate(2);
        }

        private void btnCloseSecondGate_Click(object sender, EventArgs e) {
            CloseServerGate(2);
        }

        private void timerStateSync_Tick(object sender, EventArgs e) {
            lock (lockDeviceState) {
                if (!isRunningState) {
                    isRunningState = true;
                    CheckDeviceState1();
                    CheckDeviceState2();
                    isRunningState = false;
                }
            }
        }

        private void CheckDeviceState1() {
            if (serialPort1 != null) {
                bool isReceive = serialPort1.HasReceiveData();
                if (!isReceive&&!CurrentClient.Instance.IsSimulateWeight) {
                    ShowWeightInfo(1, 0);
                }
                bool isNormal = serialPort1.IsNormal();
                ShowDeviceState(isNormal);
                if (!isNormal) {
                    ShowWeightStableState(false, stateWeightStable1);
                }
            }
        }
        private void CheckDeviceState2() {
            if (serialPort2 != null) {
                bool isReceive = serialPort2.HasReceiveData();
                if (!isReceive&&!CurrentClient.Instance.IsSimulateWeight) {
                    ShowWeightInfo(2, 0);
                }
                bool isNormal = serialPort2.IsNormal();
                ShowDeviceState(isNormal);
                if (!isNormal) {
                    ShowWeightStableState(false, stateWeightStable2);
                }
            }
        }

        private void btnSaveTare_Click(object sender, EventArgs e) {
            if (wlookCar == null)
                return;
            decimal tareWeight = GetCurrentWeight();
            tareWeight = UnitUtil.GetValue(currentDeviceCfg, tareWeight);
            if (tareWeight == 0) {
                MessageDxUtil.ShowWarning("当前重量为0不能存皮");
                return;
            }
            string carNo = wlookCar.Text.Trim();
            SCar car = carService.GetByCarNo(carNo);
            bool isSaved = false;
            if (car != null) {
                if (MessageDxUtil.ShowYesNoAndTips(string.Format("当前车辆已有皮重,确实要替换为{0}吨吗?", tareWeight)) == DialogResult.Yes) {
                    car.TareWeight = tareWeight;
                    isSaved = carService.Save(car);
                }
            } else {
                car = new SCar();
                car.Id = YF.MWS.Util.Utility.GetGuid();
                car.CarNo = carNo;
                car.TareWeight = tareWeight;
                car.CarType = CarType.Out.ToString();
                isSaved = carService.Save(car);
            }
            CarCacher.Remove();
        }

        private void btnContinuous_Click(object sender, EventArgs e) {
            Cfg= CfgUtil.GetCfg();
            Cfg.Weight.oldWeight = 0;
            CfgUtil.SaveCfg(Cfg);
            MessageBox.Show("清理成功！");
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            decimal weight = GetCurrentWeight();
            if (weTareWeight != null) {
                weTareWeight.Text = weight.ToString();
            }
        }

        private void lblWeight_Click(object sender, EventArgs e) {
            this.lblWeight2.BackColor= Color.White;
            this.lblWeight1.BackColor = Color.FromArgb(1,84,164);
            currentPort = serialPort1;
            currentlblWeight = lblWeight1;
            currentDeviceCfg = Cfg.Device1;
            this.currentDeviceNo = 1;
            setWeightDeviation();
        }

        private void lblWeight2_Click(object sender, EventArgs e) {
            this.lblWeight1.BackColor= Color.White;
            this.lblWeight2.BackColor = Color.FromArgb(1,84,164);
            currentPort = serialPort2;
            currentlblWeight = lblWeight2;
            currentDeviceCfg = Cfg.Device2;
            this.currentDeviceNo =2;
            setWeightDeviation();
        }
        private void setWeightDeviation() {
            minCredibleWeight = UnitUtil.GetValue("Kg", currentDeviceCfg.SUnit, minCredibleWeight);
            weightDeviation = Cfg.WeightStable.WeightDeviation;
            weightDeviation = UnitUtil.GetValue("Kg", currentDeviceCfg.SUnit, weightDeviation);
            samplingCount = Cfg.WeightStable.SamplingCount;
            returnZeroWeightValue = UnitUtil.GetValue("Ton", currentDeviceCfg.SUnit, Cfg.NobodyWeight.MaxReturnZeroWeightValue);
        }
        public void setDevice2(bool start) {
            SysCfg cfg = CfgUtil.GetCfg();
            cfg.Device2.StartDevice = start;
            CfgUtil.SaveCfg(cfg);
            plDevice2.Visible = start;
            if (!start) {
                lblWeight_Click(null,null);
            }
        }

        private void FrmWeight_SizeChanged(object sender, EventArgs e) {
            //gpWeightDetail.Height = this.Height - gpWeightDetail.Location.Y;
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            returnZero = true;//重量要归零，后面的磅单才能保存
            hasReadCard = false;
            hasGetCarNo = false;
            isReadingCard = false;
            isAutoSaving = false;
            paySuccess = true;
            needGetPayState = false;
            New(true);
        }

        private void radWarehBizType_SelectedIndexChanged(object sender, EventArgs e) {
            if (weRegularCharge != null) {
                    weRegularCharge.Enabled = radWarehBizType.EditValue.ToString() == "9";
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e) {
            GreeServerLight(1);
        }

        private void simpleButton3_Click(object sender, EventArgs e) {
            RedServerLight(1);
        }

        private void simpleButton6_Click(object sender, EventArgs e) {
            GreeServerLight(2);
        }

        private void simpleButton5_Click(object sender, EventArgs e) {
            RedServerLight(2);
        }

        private void simpleButton1_Click_1(object sender, EventArgs e) {
            this.readerNo = 1;
            if (string.IsNullOrEmpty(txtCar.Text)) {
                bool isSuccess = false;
                if (vzRecognizerLeft != null) {
                    isSuccess = vzRecognizerLeft.ManualTrigger();
                    ShowWeightStateTip(string.Format("手动触发1#车牌识别{0}", isSuccess ? "成功" : "失败"));
                }
                if (hxRecognizerLeft != null) {
                    isSuccess = hxRecognizerLeft.ManualTrigger();
                    ShowWeightStateTip(string.Format("手动触发1#车牌识别{0}", isSuccess ? "成功" : "失败"));
                }
            } else {
            CarRecognize(new PlateInfo() {
                Num=txtCar.Text.Trim()
            });
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e) {
            this.readerNo = 2;
            if (string.IsNullOrEmpty(txtCar.Text)) {
                bool isSuccess = false;
                if (vzRecognizerRight != null) {
                    isSuccess = vzRecognizerRight.ManualTrigger();
                    ShowWeightStateTip(string.Format("手动触发2#车牌识别{0}", isSuccess ? "成功" : "失败"));
                }
                if (hxRecognizerRight != null) {
                    isSuccess = hxRecognizerRight.ManualTrigger();
                    ShowWeightStateTip(string.Format("手动触发2#车牌识别{0}", isSuccess ? "成功" : "失败"));
                }
            } else {
            CarRecognize(new PlateInfo() {
                Num=txtCar.Text.Trim()
            });
            }
        }
    }
}
