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
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;

namespace YF.MWS.Win.View.Extend
{
    public partial class FrmWeightAddDetail : BaseForm
    {
        private ISeqNoService seqNoService = new SeqNoService();
        private IMasterService masterService = new MasterService();
        private IMaterialService materialService = new MaterialService();
        private ICarService carService = new CarService();
        private ICardService cardService = new CardService();
        private IWeightService weightService = new WeightService();
        private IWeightViewService viewService = new WeightViewService();
        private IAttributeService attributeService = new AttributeService();
        private IWeightExtService weightExtService = new WeightExtService();
        private IFileService fileService = new FileService();
        private SyncObject syncObj = new SyncObject();

        private WNumbericEdit weTareWeight;
        private WNumbericEdit weGrossWeight;
        private WNumbericEdit weSuttleWeight;
        private WNumbericEdit weNetWeight;
        private WComboBoxEdit wbChargeType;
        private WNumbericEdit weRegularCharge;
        private WNumbericEdit weUnitCharge;
        private WNumbericEdit weMaterialAmount;
        private WMaterialEdit wMaterialId;
        private WTextEdit weMaterialModel;
        private WNumbericEdit wnUnitPrice;
        private WTextEdit weDriverName;
        private WTextEdit weWeighterName;
        private WLookupSearchEdit wlookupDelivery;
        private WLookupSearchEdit wlookupReceiver;
        private WLookupSearchEdit wlookupMaterial;
        private WLookupSearchEdit wlookupCustomer;
        private WLookupSearchEdit wlookupManufacturer;
        private WLookupSearchEdit wlookupSupplier;
        private WCarLookup wlookCar;
        private string softOneUnit;

        /// <summary>
        /// 毛重详情
        /// </summary>
        private BWeightDetail tareDetail;
        /// <summary>
        /// 皮重详情
        /// </summary>
        private BWeightDetail grossDetail;

        private bool isSearchEdit = false;
        /// <summary>
        /// 是否为磅单搜索
        /// </summary>
        public bool IsSearchEdit
        {
            get { return isSearchEdit; }
            set { isSearchEdit = value; }
        }

        public FrmWeightAddDetail()
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
            wMaterialId = mainWeight.FindControl<WMaterialEdit>("MaterialId");
            weMaterialModel = mainWeight.FindControl<WTextEdit>("MaterialModel");
            wnUnitPrice = mainWeight.FindControl<WNumbericEdit>("UnitPrice");
            wlookupCustomer = mainWeight.FindControl<WLookupSearchEdit>("CustomerId");
            wlookupReceiver = mainWeight.FindControl<WLookupSearchEdit>("ReceiverId");
            wlookupMaterial = mainWeight.FindControl<WLookupSearchEdit>("MaterialId");
            wlookupDelivery = mainWeight.FindControl<WLookupSearchEdit>("DeliveryId");
            wlookupManufacturer = mainWeight.FindControl<WLookupSearchEdit>("ManufacturerId");
            wlookupSupplier = mainWeight.FindControl<WLookupSearchEdit>("SupplierId");
            wlookCar = mainWeight.FindControl<WCarLookup>("CarId");
            weWeighterName = mainWeight.FindControl<WTextEdit>("WeighterName");
        }

        private void InitData()
        {
            softOneUnit = IniUtility.GetIniKeyValue("Device1", "SUnit", "KG");
            deFinishTime.DateTime = DateTime.Now;
            deGrossTime.DateTime = DateTime.Now;
            deTareTime.DateTime = DateTime.Now;
        }

        private void Init()
        {
            syncObj.FileService = fileService;
            syncObj.MasterService = masterService;
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
            if (wMaterialId != null)
            {
                wMaterialId.EditValueChanged += wMaterialId_EditValueChanged;
            }
        }

        private void wMaterialId_EditValueChanged(object sender, EventArgs e)
        {
            if (wMaterialId.CurrentValue.ToObjectString().Length == 0)
            {
                return;
            }
            SMaterial material = materialService.GetMaterial(wMaterialId.CurrentValue.ToObjectString());
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

        private void Weight_EditValueChanged(object sender, EventArgs e)
        {
            SummaryWeightAndCharge();
        }

        /// <summary>
        /// 计算重量和费用
        /// </summary>
        private void SummaryWeightAndCharge()
        {
            decimal suttleWeight = weGrossWeight.Text.ToDecimal() - weTareWeight.Text.ToDecimal();
            string selfUnit = "Ton";
            if (weSuttleWeight != null)
            {
                weSuttleWeight.Text = suttleWeight.ToString();
            }
            ChargeRuleType type = ChargeRuleType.GrossWeight;
            double regularCharge = 0;
            double unitPrice = 0;
            /*if (weUnitCharge != null && weUnitCharge.Text.ToDecimal() > 0) 
            {
                unitPrice = (double)weUnitCharge.Text.ToDecimal();
            }*/
            switch (type)
            {
                case ChargeRuleType.GrossWeight:
                    if (weGrossWeight != null)
                    {
                        regularCharge = (double)UnitUtil.GetValue(this.softOneUnit, selfUnit, weGrossWeight.Text.ToDecimal()) * unitPrice;
                        //weRegularCharge.Text = (UnitUtil.GetValue(this.SoftOneUnit,selfUnit,weGrossWeight.Text.ToDecimal()) * weUnitCharge.Text.ToDecimal()).ToString(); 
                    }
                    break;
                case ChargeRuleType.TareWeight:
                    if (weTareWeight != null)
                    {
                        regularCharge = (double)UnitUtil.GetValue(this.softOneUnit, selfUnit, weTareWeight.Text.ToDecimal()) * unitPrice;
                        //weRegularCharge.Text = (UnitUtil.GetValue(this.SoftOneUnit,selfUnit,weTareWeight.Text.ToDecimal()) * weUnitCharge.Text.ToDecimal()).ToString(); 
                    }
                    break;
                case ChargeRuleType.SuttleWeight:
                    if (weSuttleWeight != null)
                    {
                        regularCharge = (double)UnitUtil.GetValue(this.softOneUnit, selfUnit, weSuttleWeight.Text.ToDecimal()) * unitPrice;
                        //weRegularCharge.Text = (UnitUtil.GetValue(this.SoftOneUnit,selfUnit,weSuttleWeight.Text.ToDecimal()) * weUnitCharge.Text.ToDecimal()).ToString();

                    }
                    break;
                case ChargeRuleType.SummaryWeight:
                    if (weGrossWeight != null && weTareWeight != null)
                    {
                        regularCharge = (double)UnitUtil.GetValue(this.softOneUnit, selfUnit, weGrossWeight.Text.ToDecimal() + weTareWeight.Text.ToDecimal()) * unitPrice;
                        //weRegularCharge.Text = (UnitUtil.GetValue(this.SoftOneUnit,selfUnit,weGrossWeight.Text.ToDecimal() + weTareWeight.Text.ToDecimal())* weUnitCharge.Text.ToDecimal()).ToString();
                    }
                    break;
                case ChargeRuleType.Custom:
                    if (weRegularCharge != null)
                    {
                        regularCharge = (double)weRegularCharge.Text.ToDecimal();
                    }
                    break;
                case ChargeRuleType.MaterialAmount:
                    if (weMaterialAmount != null)
                    {
                        regularCharge = unitPrice * (double)weMaterialAmount.Text.ToDecimal();
                    }
                    break;
            }
            if (weRegularCharge != null)
            {
                weRegularCharge.Text = regularCharge.ToString();
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
                BWeightDetail grossDetail = weightService.GetDetail(weight.Id, WeightType.Gross);
                if (grossDetail != null && grossDetail.WeightTime != DateTime.MinValue) 
                {
                    deGrossTime.DateTime = grossDetail.WeightTime;
                }
                BWeightDetail tareDetail = weightService.GetDetail(weight.Id, WeightType.Tare);
                if (tareDetail != null && tareDetail.WeightTime != DateTime.MinValue)
                {
                    deTareTime.DateTime = tareDetail.WeightTime;
                }
                if (isSearchEdit)
                {
                    OrderSource boundSource = weight.OrderSource.ToEnum<OrderSource>();
                    if (boundSource == OrderSource.Weight)
                    {
                        plHeader.Enabled = false;
                    }
                    mainWeight.BoundSource = boundSource;
                }
                mainWeight.BindControl<BWeight>(weight);
                deFinishTime.DateTime = weight.FinishTime;
                if (wlookCar != null)
                {
                    wlookCar.Text = weight.CarNo;
                    wlookCar.CurrentValue = weight.CarId;
                }
            }
        }

        private bool ValidateForm()
        {
            bool isValidate = true;
            decimal tareWeight = weTareWeight.Text.ToDecimal();
            decimal grossWeight = weGrossWeight.Text.ToDecimal();
            if (deFinishTime.DateTime == DateTime.MinValue)
            {
                MessageDxUtil.ShowWarning("请选择过磅日期.");
                isValidate = false;
                return isValidate;
            }
            if (tareWeight <= 0)
            {
                MessageDxUtil.ShowWarning("皮重必须大于0.");
                isValidate = false;
                return isValidate;
            }
            if (tareWeight <= 0)
            {
                MessageDxUtil.ShowWarning("毛重必须大于0.");
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

        private void Save()
        {
            try
            {
                BWeight weight = null;
                if (!string.IsNullOrEmpty(RecId))
                {
                    weight = weightService.Get(RecId);
                }
                if (weight == null)
                {
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
                }
                weight.MachineCode = CurrentClient.Instance.MachineCode;
                mainWeight.ControlToEntity<BWeight>(ref weight); 
                weight.WeighterId = CurrentUser.Instance.Id;
                if (wlookCar != null)
                {
                    weight.CarNo = wlookCar.Text;
                }

                tareDetail = weightService.GetDetail(weight.Id, WeightType.Tare);
                if (tareDetail == null)
                {
                    tareDetail = new BWeightDetail(); 
                    tareDetail.Id = YF.MWS.Util.Utility.GetGuid();
                }
                tareDetail.WeightTime = deTareTime.DateTime;
                tareDetail.WeightId = weight.Id;
                tareDetail.OrderSource = OrderSource.Weight.ToString();
                tareDetail.WeightType = (int)WeightType.Tare;

                tareDetail.WeighterId = CurrentUser.Instance.Id;
                if (string.IsNullOrEmpty(weight.WeighterName))
                {
                    weight.WeighterName = CurrentUser.Instance.FullName;
                }
                if (weTareWeight != null)
                {
                    tareDetail.TareWeight = weTareWeight.Text.ToDecimal();
                }

                grossDetail = weightService.GetDetail(weight.Id, WeightType.Gross);
                if (grossDetail == null)
                {
                    grossDetail = new BWeightDetail();
                    grossDetail.Id = YF.MWS.Util.Utility.GetGuid();
                    
                }
                grossDetail.WeightTime = deGrossTime.DateTime;
                grossDetail.WeightId = weight.Id;
                grossDetail.OrderSource = OrderSource.Weight.ToString();
                grossDetail.WeightType = (int)WeightType.Gross;
                grossDetail.WeighterId = CurrentUser.Instance.Id;
                if (weGrossWeight != null)
                {
                    grossDetail.GrossWeight = weGrossWeight.Text.ToDecimal();
                }
                FinishState state = FinishState.Unfinished;
                state = FinishState.Finished;
                weight.OrderSource = OrderSource.Additional.ToString();
                weight.FinishState = (int)state;
                weight.MeasureUnit = softOneUnit;
                weight.WeightProcess = (int)WeightProcess.Two;
                
                weight.FinishTime = deFinishTime.DateTime;
                weight.ViewId = CurrentClient.Instance.ViewId;
                weightService.Save(weight, tareDetail, grossDetail);
                MessageDxUtil.ShowTips("成功保存磅单信息.");

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存磅单信息时发生未知错误,请重试.");
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

        private void FrmWeightGrainAdd_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
            SetEvent();
            BindData();
        }
    }
}