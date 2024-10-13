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
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.MWS.Win.View.Report;
using YF.Utility;
using YF.Utility.Log;
using YF.MWS.CacheService;

namespace YF.MWS.Win.View.Extend
{
    public partial class FrmWeightQc : BaseForm
    {
        private string weightId; 
        private BWeightQc weightQc = null;
        private ISeqNoService seqNoService = new SeqNoService();
        private IWeightQcService weightQcService = new WeightQcService();
        private IWeightQueryService weightQueryService = new WeightQueryService();
        private IWeightExtService weightExtService = new WeightExtService();
        private IMasterService masterService = new MasterService();
        private IWeightService weightService = new WeightService();

        public string WeightId
        {
            get { return weightId; }
            set { weightId = value; }
        }

        public FrmWeightQc()
        {
            InitializeComponent();
        }

        private void barItemPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            Print();
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidateForm())
            {
                Save();
            }
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmWeightQc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BindWeight(BWeight weight) 
        {
            List<BWeightAttribute> lstAttr = weightExtService.GetAttributeList(weightId);
            BWeightAttribute attr = lstAttr.Find(c => c.FieldName == "PackageType");
            if (attr != null)
            {
                DxHelper.BindComboBoxEdit(combPackageType, "PackageType", attr.AttributeValue);
            }
            FormHelper.BindControl<BWeight>(this, weight);
            lookupCar.CurrentValue = weight.CarId;
            lookupCar.Text = weight.CarNo;
            weMaterial.CurrentValue = weight.MaterialId;
            weReceiverId.CurrentValue = weight.ReceiverId;
            weDeliveryId.CurrentValue = weight.DeliveryId;
            DxHelper.BindComboBoxEdit(combMeasureType, SysCode.MeasureType, weight.MeasureType);
        }

        private void BindWeightQc(BWeightQc weightQc) 
        {
            FormHelper.BindControl<BWeightQc>(this, weightQc);
            DxHelper.BindComboBoxEdit(combMeasureType, SysCode.MeasureType, weightQc.MeasureType);
            DxHelper.BindComboBoxEdit(combPackageType, "PackageType", weightQc.PackageType);
            DxHelper.BindComboBoxEdit(combJudgement, "Judgement", weightQc.Judgement);
            DxHelper.BindComboBoxEdit(combProductFlow, "ProductFlow", weightQc.ProductFlow);
            lookupCar.CurrentValue = weightQc.CarId;
            lookupCar.Text = weightQc.CarNo;
            weMaterial.CurrentValue = weightQc.MaterialId;
            weReceiverId.CurrentValue = weightQc.ReceiverId;
            weDeliveryId.CurrentValue = weightQc.DeliveryId;
            //weWeightNo.CurrentValue = weightQc.WeightId;
        }

        private void BindPrimaryAmount() 
        {
            string weightId = weWeightNo.CurrentValue.ToObjectString();
            List<BWeightAttribute> lstWeightAttr = weightExtService.GetAttributeList(weightId);
            if (lstWeightAttr == null || lstWeightAttr.Count == 0) 
            {
                return;
            }
            BWeightAttribute attr = lstWeightAttr.Find(c => !string.IsNullOrEmpty(c.FieldName) && c.FieldName.ToUpper() == "PrimaryAmount".ToUpper());
            if (attr != null) 
            {
                tePrimaryAmount.Text = attr.AttributeValue;
            }
        }

        private void LoadData() 
        {
            List<LookupField> lstField = new List<LookupField>();
            lstField.Add(new LookupField() { FieldName = "MaterialName", Caption = "物资" });
            List<SMaterial> lstMaterial = MaterialCacher.GetMaterialList();
            SearchLookupUtil.BindData(weMaterial, lstMaterial, "MaterialId", "MaterialName", lstField);
            lstField.Clear();
            lstField.Add(new LookupField() { FieldName = "CustomerName", Caption = "名称" });
            List<SCustomer> lstCustomer = CustomerCacher.GetCustomerList(CustomerType.Receiver);
            SearchLookupUtil.BindData(weReceiverId, lstCustomer, "CustomerId", "CustomerName", lstField);
            lstCustomer = CustomerCacher.GetCustomerList(CustomerType.Delivery);
            SearchLookupUtil.BindData(weDeliveryId, lstCustomer, "CustomerId", "CustomerName", lstField);
            lstField.Clear();
            lstField.Add(new LookupField() { FieldName = "QcNo", Caption = "质检单号" });
            lstField.Add(new LookupField() { FieldName = "WeightNo", Caption = "磅单号" });
            List<BWeightQc> lstQc = new List<BWeightQc>();
            lstQc = weightQcService.GetList();
            SearchLookupUtil.BindData(wLookupQcNo, lstQc, "QcNo", "QcNo", lstField);
            lstField.Clear();
            lstField.Add(new LookupField() { FieldName = "WeightNo", Caption = "磅单号" });
            lstField.Add(new LookupField() { FieldName = "CarNo", Caption = "车牌号" });
            
            List<BWeight> lstWeight;
            weightQc = weightQcService.Get(RecId);
            if (weightQc == null)
            {
                lstWeight = weightQueryService.GetNotQcList(DateTime.Now.Year);
                SearchLookupUtil.BindData(weWeightNo, lstWeight, "WeightId", "WeightNo", lstField);
                DxHelper.BindComboBoxEdit(combMeasureType, SysCode.MeasureType, null);
                DxHelper.BindComboBoxEdit(combPackageType, "PackageType", null);
                DxHelper.BindComboBoxEdit(combJudgement, "Judgement", null);
                DxHelper.BindComboBoxEdit(combProductFlow, "ProductFlow", null);
                BWeight weight = weightService.Get(weightId);
                teInspector.Text = CurrentUser.Instance.FullName;
                if (weight != null) 
                {
                    BindWeight(weight);
                    weWeightNo.CurrentValue = weight.Id;
                    weWeightNo.Enabled = false;
                }
            }
            else 
            {
                lstWeight = weightQueryService.GetList(DateTime.Now.Year);
                SearchLookupUtil.BindData(weWeightNo, lstWeight, "WeightId", "WeightNo", lstField);
                FormHelper.BindControl<BWeightQc>(this, weightQc);
                DxHelper.BindComboBoxEdit(combMeasureType, SysCode.MeasureType, weightQc.MeasureType);
                DxHelper.BindComboBoxEdit(combPackageType, "PackageType", weightQc.PackageType);
                DxHelper.BindComboBoxEdit(combJudgement, "Judgement", weightQc.Judgement);
                DxHelper.BindComboBoxEdit(combProductFlow, "ProductFlow", weightQc.ProductFlow);
                lookupCar.CurrentValue = weightQc.CarId;
                lookupCar.Text = weightQc.CarNo;
                weMaterial.CurrentValue = weightQc.MaterialId;
                weReceiverId.CurrentValue = weightQc.ReceiverId;
                weDeliveryId.CurrentValue = weightQc.DeliveryId;
                weWeightNo.CurrentValue = weightQc.WeightId;
                wLookupQcNo.CurrentValue = weightQc.QcNo;
                RecId = weightQc.Id;
                wLookupQcNo.Enabled = false;
                weWeightNo.Enabled = false;
            }
            BindPrimaryAmount();
        }

        private void Print() 
        {
           /* if (string.IsNullOrEmpty(RecId))
            {
                MessageDxUtil.ShowWarning("请先保存质检单."); 
                return;
            }
            DataSet dsReport = new DataSet();
            dsReport = weightQcService.GetReport(RecId);
            FrmXReport frmReport = new FrmXReport();
            frmReport.ReportFilePath = Application.StartupPath + "\\Report\\Weight\\rptWeightQc.repx";
            frmReport.DataSource = dsReport;
            frmReport.DisplayName = "质检报告";
            frmReport.Text = "质检报告";
            frmReport.WindowState = FormWindowState.Maximized;
            frmReport.StartPosition = FormStartPosition.CenterScreen;
            frmReport.ShowDialog();*/
        }

        private bool ValidateForm() 
        {
            bool isValidated = true;
            if (weWeightNo.EditValue == null && weWeightNo.EditValue.ToObjectString().Length==0) 
            {
                isValidated = false;
                MessageDxUtil.ShowWarning("请选择关联的磅单号.");
            }
            if (deQcDate.DateTime == DateTime.MinValue) 
            {
                isValidated = false;
                MessageDxUtil.ShowWarning("请选择质检日期.");
            }
            return isValidated;
        }

        private void Save() 
        {
            try
            {
                if (weightQc == null)
                {
                    weightQc = new BWeightQc();
                    weightQc.Id = YF.MWS.Util.Utility.GetGuid();
                    if (wLookupQcNo.EditValue != null && wLookupQcNo.CurrentValue.ToObjectString().Length > 0)
                    {
                        weightQc.QcNo = wLookupQcNo.CurrentValue.ToObjectString();
                    }
                    else
                    {
                        weightQc.QcNo = seqNoService.GetSeqNo(SeqCode.Qc.ToString());
                    } 
                }
                weightQc.WeightId = weWeightNo.CurrentValue.ToObjectString();
                weightQc.WeightNo = weWeightNo.Text;
                FormHelper.ControlToEntity<BWeightQc>(this, ref weightQc);
                weightQc.CarId = lookupCar.CurrentValue.ToObjectString();
                weightQc.CarNo = lookupCar.Text;
                weightQc.ReceiverId = weReceiverId.CurrentValue.ToObjectString();
                weightQc.MaterialId = weMaterial.CurrentValue.ToObjectString();
                weightQc.DeliveryId = weDeliveryId.CurrentValue.ToObjectString();
                weightQc.MeasureType = DxHelper.GetCode(combMeasureType);
                weightQc.PackageType = DxHelper.GetCode(combPackageType);
                weightQc.Judgement = DxHelper.GetCode(combJudgement);
                weightQc.ProductFlow = DxHelper.GetCode(combProductFlow);
                weightQc.Inspector = teInspector.Text;
                weightQcService.SaveQc(weightQc);
                RecId = weightQc.Id;
                MessageDxUtil.ShowTips("成功保存质检单.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存质检单过程中发生未知错误,请重试.");
            }
        }

        private void weWeightNo_EditValueChanged(object sender, EventArgs e)
        {
            if (weWeightNo.CurrentValue != null) 
            {
                BWeight weight = weightService.Get(weWeightNo.CurrentValue.ToObjectString());
                if (weight == null) 
                {
                    return;
                }
                BindWeight(weight);
                BindPrimaryAmount();
            }
        }

        private void wLookupQcNo_EditValueChanged(object sender, EventArgs e)
        {
            if (wLookupQcNo.EditValue != null && wLookupQcNo.CurrentValue.ToObjectString().Length>0) 
            {
                BWeightQc weightQc = weightQcService.GetByNo(wLookupQcNo.CurrentValue.ToObjectString());
                BindWeightQc(weightQc);
            }
        }
 
    }
}