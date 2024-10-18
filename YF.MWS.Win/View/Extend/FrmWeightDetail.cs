using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Util;
using YF.MWS.Win.Core;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Uc.Weight;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.Utility.Log;
using YF.MWS.CacheService;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Win.View.Weight;
using DevExpress.Utils.MVVM.Services;
using System.Collections;

namespace YF.MWS.Win.View.Extend
{
    public partial class FrmWeightDetail : BaseForm
    {
        private IMaterialService materialService = new MaterialService();
        private IReportService reportService = new SQliteService.ReportService();
        private ICarService carService = new CarService();
        private ICardService cardService = new CardService();
        private ICustomerService customerService = new CustomerService();
        private IWeightService weightService = new WeightService();
        private IWeightViewService viewService = new WeightViewService();
        private IAttributeService attributeService = new AttributeService();
        private IWeightExtService weightExtService = new WeightExtService();
        private ISeqNoService seqNoService = new SeqNoService();
        private IPlanService planService = new PlanService();
        private IFileService fileService = new FileService();
        private IWebPayService webPayService = new WebPayService();
        private ILogService logService = new LogService();
        private SyncObject syncObj = new SyncObject();
        private WNumbericEdit weTareWeight;
        private WNumbericEdit weGrossWeight;
        private WNumbericEdit weSuttleWeight;
        private WNumbericEdit weNetWeight;
        private WComboBoxEdit wbChargeType;
        private WNumbericEdit weRegularCharge;
        private WNumbericEdit weUnitCharge;
        private WNumbericEdit weMaterialAmount;
        private WTextEdit weDriverName;
        private WTextEdit weWeighterName;
        private WMaterialEdit weMaterial;
        private WTextEdit weMaterialModel;
        private WNumbericEdit wnUnitPrice;
        private WCustomerEdit wlookupDelivery;
        private WCustomerEdit wlookupReceiver;
        private WCustomerEdit wlookupCustomer;
        private WCustomerEdit wlookupManufacturer;
        private WCustomerEdit wlookupSupplier;
        private WCarLookup wlookCar;
        private WNumbericEdit wCustomerBalance;
        private WComboBoxValueEdit wePayType;
        /// <summary>
        /// 物资单价
        /// </summary>
        private WNumbericEdit weUnitPrice;
        private string softOneUnit;

        private bool isSearchEdit = false;
        /// <summary>
        /// 是否开启磅单输入项自动保存(不存在对应的基础数据项的前提下)
        /// </summary>
        private bool startInputItemAutoSave;
        private WeightProcess currentWeightProcess = WeightProcess.Two;
        private bool startAutoUpload = false;
        /// <summary>
        /// 启用计划单限制功能
        /// </summary>
        private bool startPlan = false;
        /// <summary>
        /// 是否为磅单搜索
        /// </summary>
        public bool IsSearchEdit
        {
            get { return isSearchEdit; }
            set { isSearchEdit = value; }
        }

        public FrmWeightDetail()
        {
            InitializeComponent();
            Init();
        }

        private void InitControl()
        {
            weTareWeight = mainWeight.FindControl<WNumbericEdit>("TareWeight");
            weGrossWeight = mainWeight.FindControl<WNumbericEdit>("GrossWeight");
            weSuttleWeight = mainWeight.FindControl<WNumbericEdit>("SuttleWeight");
            weNetWeight = mainWeight.FindControl<WNumbericEdit>("NetWeight");
            wbChargeType = mainWeight.FindControl<WComboBoxEdit>("ChargeType");
            weRegularCharge = mainWeight.FindControl<WNumbericEdit>("RegularCharge");
            weMaterialAmount = mainWeight.FindControl<WNumbericEdit>("MaterialAmount");
            weUnitCharge = mainWeight.FindControl<WNumbericEdit>("UnitCharge");
            weDriverName = mainWeight.FindControl<WTextEdit>("DriverName");
            weMaterial = mainWeight.FindControl<WMaterialEdit>("MaterialId");
            weMaterialModel = mainWeight.FindControl<WTextEdit>("MaterialModel");
            wnUnitPrice = mainWeight.FindControl<WNumbericEdit>("UnitPrice");
            wlookupCustomer = mainWeight.FindControl<WCustomerEdit>("CustomerId");
            wlookupReceiver = mainWeight.FindControl<WCustomerEdit>("ReceiverId");
            wlookupDelivery = mainWeight.FindControl<WCustomerEdit>("DeliveryId");
            wlookupManufacturer = mainWeight.FindControl<WCustomerEdit>("ManufacturerId");
            wlookupSupplier = mainWeight.FindControl<WCustomerEdit>("SupplierId");
            wlookCar = mainWeight.FindControl<WCarLookup>("CarId");
            weWeighterName = mainWeight.FindControl<WTextEdit>("WeighterName");
            wCustomerBalance = mainWeight.FindControl<WNumbericEdit>("CustomerBalance");
            wePayType = mainWeight.FindControl<WComboBoxValueEdit>("PayType");
            weUnitPrice = mainWeight.FindControl<WNumbericEdit>("UnitPrice");
            deCreateTime.DateTime = DateTime.Now;
            deGrossTime.DateTime = DateTime.Now;
            deTareTime.DateTime = DateTime.Now;
        }

        private void InitConfig()
        {
            softOneUnit = IniUtility.GetIniKeyValue("Device1", "SUnit", "KG");
            if (Cfg != null)
            {
                if (Cfg.Weight != null)
                {
                    startPlan = Cfg.Weight.StartPlan;
                    startInputItemAutoSave = Cfg.Weight.StartInputItemAutoSave;
                    currentWeightProcess = Cfg.Weight.Process;
                }
            }
        }

        private void Init()
        {
            syncObj.FileService = fileService;
            syncObj.MaterialService = materialService;
            syncObj.WeightService = weightService;
            syncObj.WeightExtService = weightExtService;
            IWebFileService webFileService = new WebFileService();
            syncObj.WebFileService = webFileService;
            if (Cfg != null && Cfg.Transfer != null)
                syncObj.Transfer = Cfg.Transfer;
        }

        private void SetControl()
        {
            if (weWeighterName != null)
            {
                weWeighterName.Text = CurrentUser.Instance.FullName;
            }
            if (CurrentUser.Instance.IsAdministrator)
            {
                if (weTareWeight != null)
                {
                    weTareWeight.Enabled = true;
                    weTareWeight.Properties.ReadOnly = false;
                }
                if (weGrossWeight != null)
                {
                    weGrossWeight.Enabled = true;
                    weGrossWeight.Properties.ReadOnly = false;
                }
                if (weSuttleWeight != null)
                {
                    weSuttleWeight.Enabled = true;
                    weSuttleWeight.Properties.ReadOnly = false;
                }
                if (weNetWeight != null)
                {
                    weNetWeight.Enabled = true;
                    weNetWeight.Properties.ReadOnly = false;
                }
            }
        }

        private void SetEvent()
        {
            if (wbChargeType != null)
            {
                //wbChargeType.SelectedIndexChanged += wbChargeType_SelectedIndexChanged;
            }
            if (weUnitCharge != null)
            {
                weUnitCharge.EditValueChanged += Weight_EditValueChanged;
            }
            if (weTareWeight != null)
            {
                weTareWeight.EditValueChanged += Weight_EditValueChanged;
            }
            if (weGrossWeight != null)
            {
                weGrossWeight.EditValueChanged += Weight_EditValueChanged;
            }
            if (weMaterialAmount != null)
            {
                weMaterialAmount.EditValueChanged += Weight_EditValueChanged;
            }
            if (weMaterial != null)
            {
                weMaterial.EditValueChanged += wMaterialId_EditValueChanged;
            }
            if (wlookupCustomer != null)
            {
                wlookupCustomer.EditValueChanged += wlookupCustomer_EditValueChanged;
            }
        }

        private void wlookupCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if (wlookupCustomer.CurrentValue == null || wlookupCustomer.CurrentValue.ToObjectString().Length == 0)
            {
                return;
            }
            //CustomerUtil.LoadCustomer(wlookupCustomer.CurrentValue.ToObjectString(), CustomerType.Customer, masterService, mainWeight, lstAttr);
            SetUnitPrice();
            if (wCustomerBalance != null && wlookupCustomer != null)
            {
                string customerId = wlookupCustomer.CurrentValue.ToObjectString();
                SCustomer customer = CustomerCacher.Get(customerId);
                if (customer != null && !string.IsNullOrEmpty(customer.Id))
                {
                    wCustomerBalance.Text = customer.BalanceAmount.ToString();
                    if (customer.BalanceAmount < customer.MinBalanceAmount)
                    {
                        wCustomerBalance.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void SetUnitPrice()
        {
            bool hasSetPrice = false;
            if (weUnitPrice != null && weMaterial != null && wlookupCustomer != null
                && wlookupCustomer.CurrentValue != null && weMaterial.CurrentValue != null)
            {
                string customerId = wlookupCustomer.CurrentValue.ToObjectString();
                string materialId = weMaterial.CurrentValue.ToObjectString();
                SCustomerPrice price = customerService.Get(customerId, materialId);
                if (price != null && price.Price > 0)
                {
                    hasSetPrice = true;
                    weUnitPrice.Text = price.Price.ToString();
                }
            }
            if (!hasSetPrice && weMaterial != null && weMaterial.CurrentValue != null)
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

        void Weight_EditValueChanged(object sender, EventArgs e)
        {
            if (weSuttleWeight != null)
            {
                if (weSuttleWeight.Text.ToDecimal() < 0)
                {
                    weSuttleWeight.Text = "0";
                }
            }
        }

        private void wMaterialId_EditValueChanged(object sender, EventArgs e)
        {
            if (weMaterial.CurrentValue.ToObjectString().Length == 0)
            {
                return;
            }
            SMaterial material = materialService.GetMaterial(weMaterial.CurrentValue.ToObjectString());
            if (material != null)
            {
                if (wnUnitPrice != null)
                {
                    wnUnitPrice.Text = material.UnitPrice.ToString();
                }
                if (weMaterialModel != null)
                {
                    weMaterialModel.Text = material.SpecName;
                }
            }
        }

        private void BindData()
        {
            if (!string.IsNullOrEmpty(RecId))
            {
                BWeight weight = weightService.Get(RecId);
                if (weight == null)
                {
                    MessageDxUtil.ShowWarning("加载磅单时发生未知错误,请重试.");
                    return;
                }
                mainWeight.BindControl<BWeight>(weight);
                if (isSearchEdit)
                {
                    mainWeight.BoundSource = weight.OrderSource.ToEnum<OrderSource>();
                }
                deCreateTime.DateTime = weight.CreateTime;
                deGrossTime.DateTime = weight.GrossTime;
                deTareTime.DateTime = weight.TareTime;
                deFinishTime.DateTime = weight.FinishTime;
                if (wlookCar != null)
                {
                    wlookCar.Text = weight.CarNo;
                    wlookCar.CurrentValue = weight.CarId;
                }
            }
        }

        private string GetLogDesc(BWeight oldWeight, BWeight newWeight)
        {
            StringBuilder sb = new StringBuilder();
            if (oldWeight != null && newWeight != null)
            {
                if (oldWeight.CardNo != newWeight.CardNo)
                {
                    sb.AppendFormat("修改IC卡号(修改前的值:{0},修改后的值:{1})", oldWeight.CardNo, newWeight.CardNo);
                }
                if (oldWeight.CarNo != newWeight.CarNo)
                {
                    sb.AppendFormat("修改车牌号(修改前的值:{0},修改后的值:{1})", oldWeight.CarNo, newWeight.CarNo);
                }
                if (oldWeight.CustomerId != newWeight.CustomerId)
                {
                    sb.AppendFormat("修改客户(修改前的值:{0},修改后的值:{1})", CustomerCacher.GetCustomerName(oldWeight.CustomerId),
                                                                                                                          CustomerCacher.GetCustomerName(newWeight.CustomerId));
                }
                if (oldWeight.MaterialId != newWeight.MaterialId)
                {
                    sb.AppendFormat("修改物料(修改前的值:{0},修改后的值:{1})", MaterialCacher.GetMaterialName(oldWeight.MaterialId),
                                                                                                                          MaterialCacher.GetMaterialName(newWeight.MaterialId));
                }
                if (oldWeight.GrossWeight != newWeight.GrossWeight)
                {
                    sb.AppendFormat("修改毛重(修改前的值:{0},修改后的值:{1});", oldWeight.GrossWeight, newWeight.GrossWeight);
                }
                if (oldWeight.TareWeight != newWeight.TareWeight)
                {
                    sb.AppendFormat("修改皮重(修改前的值:{0},修改后的值:{1});", oldWeight.TareWeight, newWeight.TareWeight);
                }
                if (oldWeight.SuttleWeight != newWeight.SuttleWeight)
                {
                    sb.AppendFormat("修改净重(修改前的值:{0},修改后的值:{1});", oldWeight.SuttleWeight, newWeight.SuttleWeight);
                }
                if (oldWeight.CreateTime != newWeight.CreateTime)
                {
                    sb.AppendFormat("修改一次过磅时间(修改前的值:{0},修改后的值:{1});", oldWeight.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"), newWeight.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                if (oldWeight.FinishTime != newWeight.FinishTime)
                {
                    sb.AppendFormat("修改二次过磅时间(修改前的值:{0},修改后的值:{1});", oldWeight.FinishTime.ToString("yyyy-MM-dd HH:mm:ss"), newWeight.FinishTime.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                if (oldWeight.Remark != newWeight.Remark)
                {
                    sb.AppendFormat("修改备注(修改前的值:{0},修改后的值:{1});", oldWeight.Remark, newWeight.Remark);
                }
            }
            else
            {
                if (newWeight != null)
                {
                    sb.AppendFormat("卡号(新建的值:{0});", newWeight.CardNo);
                    sb.AppendFormat("车牌号(新建的值:{0});", newWeight.CarNo);
                    sb.AppendFormat("客户(新建的值:{0});", CustomerCacher.GetCustomerName(newWeight.CustomerId));
                    sb.AppendFormat("物料(新建的值:{0});", MaterialCacher.GetMaterialName(newWeight.MaterialId));
                    sb.AppendFormat("毛重(新建的值:{0});", newWeight.GrossWeight);
                    sb.AppendFormat("皮重(新建的值:{0});", newWeight.TareWeight);
                    sb.AppendFormat("净重(新建的值:{0});", newWeight.SuttleWeight);
                    if (!string.IsNullOrEmpty(newWeight.Remark))
                    {
                        sb.AppendFormat("备注(新建的值:{0});", newWeight.Remark);
                    }
                }
            }
            return sb.ToString();
        }

        private bool ValidateForm()
        {
            bool isValidate = true;
            decimal tareWeight = 0;
            if (weTareWeight != null)
                tareWeight = weTareWeight.Text.ToDecimal();
            decimal grossWeight = 0;
            if (weGrossWeight != null)
                grossWeight = weGrossWeight.Text.ToDecimal();
            if (deCreateTime.DateTime == DateTime.MinValue)
            {
                MessageDxUtil.ShowWarning("请选择过磅日期.");
                isValidate = false;
                return isValidate;
            }
            if (tareWeight <= 0 && grossWeight <= 0)
            {
                MessageDxUtil.ShowWarning("毛重或皮重必须有一个大于0.");
                isValidate = false;
                return isValidate;
            }
            if (tareWeight > grossWeight)
            {
                MessageDxUtil.ShowWarning("毛重必须大于皮重.");
                isValidate = false;
                return isValidate;
            }
            return isValidate;
        }

        private void SaveCustomer(WCustomerEdit we)
        {
            if (we != null)
                we.SetCustomer();
        }

        private void SaveWeightInputItem()
        {
            if (!startInputItemAutoSave)
                return;
            //SaveCode(weDriverName, WeightSysCode.DriverName);
            MasterCacher.Refresh();
            SaveCustomer(wlookupCustomer);
            SaveCustomer(wlookupDelivery);
            SaveCustomer(wlookupReceiver);
            SaveCustomer(wlookupSupplier);
            SaveCustomer(wlookupCustomer);
            CustomerCacher.Remove();
            if (wlookCar != null)
            {
                wlookCar.SetCarNo();
                CarCacher.Remove();
            }
            if (weMaterial != null)
            {
                weMaterial.SetMaterial();
                MaterialCacher.Refresh();
            }
        }

        private void Save()
        {
            if (sendData()) {
                MessageDxUtil.ShowTips("成功保存磅单信息.");
                this.DialogResult = DialogResult.OK;
            } else {
                MessageDxUtil.ShowError("保存磅单信息时发生未知错误,请重试.");
            }
        }

        private bool sendData()
        {
            try
            {
                SaveWeightInputItem();
                BWeight weight = null;
                BWeight oldWeight=null;
                bool isNewWeight = false;
                if (!string.IsNullOrEmpty(RecId))
                {
                    weight = weightService.Get(RecId);
                    oldWeight=weightService.Get(RecId);
                }
                if (weight == null)
                {
                    isNewWeight = true;
                    weight = new BWeight();
                    if (!string.IsNullOrEmpty(RecId))
                    {
                        weight.Id = RecId;
                    }
                    else
                    {
                        weight.Id = YF.MWS.Util.Utility.GetGuid();
                    }
                    weight.WeightNo = seqNoService.GetSeqNo(SeqCode.Weight.ToString());
                    weight.OrderSource = OrderSource.Additional.ToString();
                }
                weight.MachineCode = CurrentClient.Instance.MachineCode;
                mainWeight.ControlToEntity<BWeight>(ref weight); 
                weight.WeighterId = CurrentUser.Instance.Id;
                if (wlookCar != null)
                {
                    weight.CarNo = wlookCar.Text;
                } 
                FinishState state = FinishState.Unfinished;
                    if (weight.TareWeight > 0 && weight.GrossWeight > 0)
                    {
                        state = FinishState.Finished;
                    }
                weight.FinishState = (int)state;
                weight.MeasureUnit = softOneUnit;
                weight.WeightProcess = (int)WeightProcess.Two;
                
                weight.FinishTime = deCreateTime.DateTime;
                weight.ViewId = CurrentClient.Instance.ViewId;
                weight.AdditionalTime = DateTime.Now;
                weight.SyncState = (int)SyncState.UnSynced;
                bool isSaved=weightService.Save(weight);
                if (isSaved)
                {
                    if (startPlan)
                    {
                        if (oldWeight != null && !string.IsNullOrEmpty(oldWeight.RefId) && oldWeight.RefId != weight.RefId)
                        {
                            planService.Update(oldWeight);
                        }
                        planService.Update(weight);
                    }
                    string desc = string.Empty;
                    if (isNewWeight)
                    {
                        desc = string.Format("新建磅单号:{0},修改详情:{1}", weight.WeightNo, GetLogDesc(oldWeight, weight));
                    }
                    else
                    {
                        desc = string.Format("修改磅单号:{0},修改详情:{1}", weight.WeightNo, GetLogDesc(oldWeight, weight));
                    }
                    logService.Add(LogActionType.Weight,weight.Id,weight.WeightNo,desc);
                }
                this.RecId = weight.Id;
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存磅单信息时发生未知错误,请重试.");
                return false;
            }
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidateForm())
            {
                Save();
            }
        }

        private void barItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmWeightDetail_Load(object sender, EventArgs e)
        {
            InitConfig();
            InitControl();
            SetEvent();
            SetControl();
            BindData();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e) {
            if (ValidateForm()) {
               if(sendData()) {
                    MessageBox.Show("磅单保存成功！");
                    PrintUtil.PrintWeightReport(CurrentClient.Instance.ViewId, this.RecId, reportService, Cfg.Print.WeightPrinterName);
                }
            }
        }
    }
}