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
using YF.MWS.Win.Uc;
using YF.MWS.Win.Uc.Weight;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.Utility.Log;

namespace YF.MWS.Win.View.Extend
{
    public partial class FrmWeightSettle : BaseForm
    {
        private ISeqNoService seqNoService = new SeqNoService();
        private IMasterService masterService = new MasterService();
        private ICarService carService = new CarService();
        private ICardService cardService = new CardService();
        private IWeightService weightService = new WeightService();
        private IWeightViewService viewService = new WeightViewService();
        private IAttributeService attributeService = new AttributeService();
        private IWeightExtService weightExtService = new WeightExtService();
        List<BWeightAttribute> lstAttr=new List<BWeightAttribute>();
        private BWeightExt weightExt;

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
        private WLookupSearchEdit wlookupDelivery;
        private WLookupSearchEdit wlookupReceiver;
        private WLookupSearchEdit wlookupMaterial;
        private WLookupSearchEdit wlookupCustomer;
        private WLookupSearchEdit wlookupManufacturer;
        private WLookupSearchEdit wlookupSupplier;
        private WCarLookup wlookCar;

        private WNumbericEdit weExtPayAmount;
        private WNumbericEdit weExtDeducCharge;
        private WNumbericEdit weExtRealCharge;
        private WNumbericEdit weExtTransportPrice;
        private WNumbericEdit weExtTransportCharge;
        private WNumbericEdit weExtDebit;
        private WNumbericEdit weExtDebitWeight;
        private WNumbericEdit weExtDeduction;
        private WNumbericEdit weExtRealTransportCharge;
        private WNumbericEdit weExtSettlementAmount;
        private WNumbericEdit weExtPrimaryAmount;
        private List<BarItem> lstItem = new List<BarItem>();
        private string softOneUnit;

        /// <summary>
        /// 毛重详情
        /// </summary>
        private BWeightDetail tareDetail;
        /// <summary>
        /// 皮重详情
        /// </summary>
        private BWeightDetail grossDetail;

        public FrmWeightSettle()
        {
            InitializeComponent();
        }

        private void InitControl()
        {
            lstAttr = attributeService.GetWeightAttributeList(RecId);

            weTareWeight = mainWeight.FindControl<WNumbericEdit>("TareWeight");
            weGrossWeight = mainWeight.FindControl<WNumbericEdit>("GrossWeight");
            weSuttleWeight = mainWeight.FindControl<WNumbericEdit>("SuttleWeight");
            weNetWeight = mainWeight.FindControl<WNumbericEdit>("NetWeight");
            wbChargeType = mainWeight.FindControl<WComboBoxEdit>("ChargeType");
            weRegularCharge = mainWeight.FindControl<WNumbericEdit>("RegularCharge");
            weMaterialAmount = mainWeight.FindControl<WNumbericEdit>("MaterialAmount");
            weUnitCharge = mainWeight.FindControl<WNumbericEdit>("UnitCharge");
            weDriverName = mainWeight.FindControl<WTextEdit>("DriverName");
            wlookupCustomer = mainWeight.FindControl<WLookupSearchEdit>("CustomerId");
            wlookupReceiver = mainWeight.FindControl<WLookupSearchEdit>("ReceiverId");
            wlookupMaterial = mainWeight.FindControl<WLookupSearchEdit>("MaterialId");
            wlookupDelivery = mainWeight.FindControl<WLookupSearchEdit>("DeliveryId");
            wlookupManufacturer = mainWeight.FindControl<WLookupSearchEdit>("ManufacturerId");
            wlookupSupplier = mainWeight.FindControl<WLookupSearchEdit>("SupplierId");
            wlookCar = mainWeight.FindControl<WCarLookup>("CarId");
            weWeighterName = mainWeight.FindControl<WTextEdit>("WeighterName");

            weExtPayAmount = mainWeight.FindExtendControl<WNumbericEdit>("PayAmount", lstAttr);
            weExtDeducCharge = mainWeight.FindExtendControl<WNumbericEdit>("DeducCharge", lstAttr);
            weExtRealCharge = mainWeight.FindExtendControl<WNumbericEdit>("RealCharge", lstAttr);
            weExtTransportPrice = mainWeight.FindExtendControl<WNumbericEdit>("TransportPrice", lstAttr);
            weExtTransportCharge = mainWeight.FindExtendControl<WNumbericEdit>("TransportCharge", lstAttr);
            weExtDebit = mainWeight.FindExtendControl<WNumbericEdit>("Debit", lstAttr);
            weExtDebitWeight = mainWeight.FindExtendControl<WNumbericEdit>("DebitWeight", lstAttr);
            weExtDeduction = mainWeight.FindExtendControl<WNumbericEdit>("Deduction", lstAttr);
            weExtRealTransportCharge = mainWeight.FindExtendControl<WNumbericEdit>("RealTransportCharge", lstAttr);
            weExtSettlementAmount = mainWeight.FindExtendControl<WNumbericEdit>("SettlementAmount", lstAttr);
            weExtPrimaryAmount = mainWeight.FindExtendControl<WNumbericEdit>("PrimaryAmount", lstAttr);
        }

        private void InitData() 
        {
            softOneUnit = IniUtility.GetIniKeyValue("Device1", "SUnit", "KG");
        }

        private void InitRoleControl()
        {
            lstItem.Add(barItemFreightSettle);
            lstItem.Add(barItemPaymentSettle);
            lstItem.Add(barItemSave);
            lstItem.Add(barItemAuth); 
            RoleUtil.SetBarItem(lstItem, LstModule);
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
            if (weExtPayAmount != null)
            {
                weExtPayAmount.EditValueChanged += Ext_EditValueChanged;
            }
            if (weExtDeducCharge != null)
            {
                weExtDeducCharge.EditValueChanged += Ext_EditValueChanged;
            }
            if (weExtRealCharge != null)
            {
                weExtRealCharge.EditValueChanged += Ext_EditValueChanged;
            }
            if (weExtTransportPrice != null)
            {
                weExtTransportPrice.EditValueChanged += Ext_EditValueChanged;
            }
            if (weExtTransportCharge != null)
            {
                weExtTransportCharge.EditValueChanged += Ext_EditValueChanged;
            }
            if (weExtDebit != null)
            {
                weExtDebit.EditValueChanged += Ext_EditValueChanged;
            }
            if (weExtDebitWeight != null)
            {
                weExtDebitWeight.EditValueChanged += Ext_EditValueChanged;
            }
            if (weExtDeduction != null)
            {
                weExtDeduction.EditValueChanged += Ext_EditValueChanged;
            }
            if (weExtRealTransportCharge != null)
            {
                weExtRealTransportCharge.EditValueChanged += Ext_EditValueChanged;
            }
            if (weExtSettlementAmount != null)
            {
                weExtSettlementAmount.EditValueChanged += Ext_EditValueChanged;
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
        }

        private void Ext_EditValueChanged(object sender, EventArgs e)
        {
            Settle();
        }

        private void Settle() 
        {
            if (weExtTransportCharge != null) 
            {
                weExtTransportCharge.Text = (weExtPrimaryAmount.Text.ToDecimal() * weExtTransportPrice.Text.ToDecimal() / 1000).ToString();
            }
            if(weExtRealTransportCharge!=null)
            {
                weExtRealTransportCharge.Text =(weExtTransportCharge.Text.ToDecimal() - weExtDebit.Text.ToDecimal() - weExtDebitWeight.Text.ToDecimal() + weExtDeduction.Text.ToDecimal()).ToString();
            }
            if (weExtPayAmount != null) 
            {
                weExtPayAmount.Text = (weUnitCharge.Text.ToDecimal() * weExtSettlementAmount.Text.ToDecimal()).ToString();
            }
            if (weExtRealCharge != null) 
            {
                weExtRealCharge.Text = (weExtPayAmount.Text.ToDecimal() + weExtDeducCharge.Text.ToDecimal()).ToString();
            }
        }

        void Weight_EditValueChanged(object sender, EventArgs e)
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

        private void BindSettle() 
        {
            if (weightExt != null)
            {
                if (weightExt.SettleState == 1)
                {
                    lblAuthCaption.Text = "已审核";
                }
                else 
                {
                    lblAuthCaption.Text = "未审核";
                }
                if (weightExt.FreightSettleState == 1)
                {
                    lblFreightSettleCaption.Text = "已结算";
                }
                else 
                {
                    lblFreightSettleCaption.Text = "未结算";
                }
                if (weightExt.PaymentSettleState == 1)
                {
                    lblPaymentSettleCaption.Text = "已结算";
                }
                else 
                {
                    lblPaymentSettleCaption.Text = "未结算";
                }
            }
        }

        private void BindData()
        {
            #region
            if (!string.IsNullOrEmpty(RecId))
            {
                weightExt = weightExtService.Get(RecId);
                if (weightExt != null) 
                {
                    if (weightExt.SettleState == 1) 
                    {
                         barItemSave.Enabled = false; 
                    }
                }
                BWeight weight = weightService.Get(RecId);
                if (weight == null)
                {
                    MessageDxUtil.ShowWarning("加载磅单时发生未知错误,请重试.");
                    return;
                } 
                mainWeight.BindExtendControl(lstAttr,false);
                mainWeight.BindControl<BWeight>(weight,false);
                if (wlookCar != null)
                {
                    wlookCar.Text = weight.CarNo;
                    wlookCar.CurrentValue = weight.CarId;
                }
            #endregion
                if (weUnitCharge != null)
                {
                    weUnitCharge.Enabled = true;
                }
                if(weExtPayAmount!=null)
                {
                    weExtPayAmount.Enabled=true;
                }
                if(weExtDeducCharge!=null)
                {
                    weExtDeducCharge.Enabled=true;
                }
                if(weExtRealCharge!=null)
                {
                    weExtRealCharge.Enabled=true; 
                }  
                if(weExtTransportPrice!=null)
                {
                    weExtTransportPrice.Enabled=true;
                }  
               if(weExtTransportCharge!=null)
                {
                    weExtTransportCharge.Enabled=true;
                }  
                if(weExtDebit!=null)
                {
                    weExtDebit.Enabled=true;
                }  
                 if(weExtDebitWeight!=null)
                {
                    weExtDebitWeight.Enabled=true;
                }  
                  if(weExtDeduction!=null)
                {
                    weExtDeduction.Enabled=true;
                }  
               if(weExtRealTransportCharge!=null)
                {
                    weExtRealTransportCharge.Enabled=true;
                }  
                if(weExtSettlementAmount!=null)
                {
                    weExtSettlementAmount.Enabled=true;
                }   
            }
        }

        private bool ValidateSettle() 
        {
            bool isValidated = true;
            if (weightExt != null)
            {
                if (weightExt.FreightSettleState == 0)
                {
                    MessageDxUtil.ShowWarning("运费尚未结清,请先完成运费结算工作.");
                    isValidated = false;
                    return isValidated;
                }
                if (weightExt.PaymentSettleState == 0)
                {
                    MessageDxUtil.ShowWarning("货款尚未结清,请先完成货款结算工作.");
                    isValidated = false;
                    return isValidated;
                }
            }
            else 
            {
                MessageDxUtil.ShowWarning("运费、货款尚未结清,请先完成运费结算工作.");
                isValidated = false;
                return isValidated;
            }
            return isValidated;
        }

        private bool ValidateForm() 
        {
            bool isValidate = true;
            decimal tareWeight = weTareWeight.Text.ToDecimal();
            decimal grossWeight = weGrossWeight.Text.ToDecimal();
            if (tareWeight <= 0) 
            {
                MessageDxUtil.ShowWarning("毛重必须大于0.");
                isValidate = false;
                return isValidate;
            }
            if (tareWeight <= 0)
            {
                MessageDxUtil.ShowWarning("皮重必须大于0.");
                isValidate = false;
                return isValidate;
            }
            if (tareWeight >grossWeight)
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
                weight.FinishTime = DateTime.Now;
                weight.WeighterId = CurrentUser.Instance.Id;
                if (wlookCar != null)
                {
                    weight.CarNo = wlookCar.Text;
                }

                tareDetail = weightService.GetDetail(weight.Id, WeightType.Tare);
                if (tareDetail == null)
                {
                    tareDetail = new BWeightDetail();
                    tareDetail.WeightTime = DateTime.Now;
                    tareDetail.Id = YF.MWS.Util.Utility.GetGuid();
                }
                tareDetail.WeightId = weight.Id;
                tareDetail.OrderSource = OrderSource.Weight.ToString();
                tareDetail.WeightType = (int)WeightType.Tare;
                tareDetail.WeighterId = CurrentUser.Instance.Id;

                if (weTareWeight != null)
                {
                    tareDetail.TareWeight = weTareWeight.Text.ToDecimal();
                }

                grossDetail = weightService.GetDetail(weight.Id, WeightType.Gross);
                if (grossDetail == null)
                {
                    grossDetail = new BWeightDetail();
                    grossDetail.Id = YF.MWS.Util.Utility.GetGuid();
                    grossDetail.WeightTime = DateTime.Now;
                }
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
                weight.WeighterName = CurrentUser.Instance.FullName;
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

        private void SaveExt(int state,SettleType type) 
        {
            string message = string.Empty;
            try
            {
                if (weightExt == null)
                {
                    weightExt = new BWeightExt();
                    weightExt.Id = RecId;
                }
                switch (type)
                {
                    case SettleType.Finance:
                        weightExt.SettleState = state;
                        message = "已经成功结算财务信息.";
                        break;
                    case SettleType.Freight:
                        weightExt.FreightSettleState = state;
                        message = "已经成功结算运费信息.";
                        break;
                    case SettleType.Payment:
                        weightExt.PaymentSettleState = state;
                        message = "已经成功结算货款信息.";
                        break;
                }
                weightExtService.Save(weightExt);
                BindSettle();
                MessageDxUtil.ShowTips(message);
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存财务结算信息时发生未知错误,请重试.");
            }
        }

        private void barItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmWeightSettle_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
            SetControl();
            BindData();
            BindSettle();
            SetEvent();
            InitRoleControl();
        }

        private void barItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            Save();
        }

        private void btnItemSettle_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (ValidateSettle())
            {
                SaveExt(1, SettleType.Finance);
            }
        }

        private void btnItemPaymentSettle_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveExt(1, SettleType.Payment);
        }

        private void barItemFreightSettle_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveExt(1, SettleType.Freight);
        }
    }
}