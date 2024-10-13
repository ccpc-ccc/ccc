using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Win.Uc;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Db;
using YF.Utility.Log;
using YF.MWS.Win.Util;

namespace YF.MWS.Win.View.Weight
{
    public partial class FrmWeightPad : BaseForm
    {
        private FrmWeight weightForm;

        public FrmWeight WeightForm
        {
            get { return weightForm; }
            set { weightForm = value; }
        }
        public FrmWeightPad()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            using (FrmConfirmExit frmExit = new FrmConfirmExit())
            {
                //frmExit.FormBorderStyle = FormBorderStyle.None;
                if (frmExit.ShowDialog() == DialogResult.OK)
                {
                    Close();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void FrmWeightPad_Load(object sender, EventArgs e)
        {
            try
            {
                InitConfig();
                SetControl();
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }

        private void btnSelectCarNo_Click(object sender, EventArgs e)
        {
            using (FrmCarSelectorPad frmCarSelector = new FrmCarSelectorPad())
            {
                //frmCarSelector.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                if (frmCarSelector.ShowDialog() == DialogResult.OK) 
                {
                    teCarNo.Text = frmCarSelector.CarNo;
                    currentCarId = frmCarSelector.CarId;
                }
            }
        }

        private void btnSelectMaterial_Click(object sender, EventArgs e)
        {
            using (FrmMaterialSelectorPad frmMaterialSelector = new FrmMaterialSelectorPad())
            {
                //frmCarSelector.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                if (frmMaterialSelector.ShowDialog() == DialogResult.OK)
                {
                    teMaterial.Text = frmMaterialSelector.MaterialName;
                    currentMaterialId = frmMaterialSelector.MaterialId;
                }
            }
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            using (FrmCustomerSelectorPad frmCustomerSelector = new FrmCustomerSelectorPad())
            {
                //frmCarSelector.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                if (frmCustomerSelector.ShowDialog() == DialogResult.OK)
                {
                    teCustomer.Text = frmCustomerSelector.CustomerName;
                    currentCustomerId = frmCustomerSelector.CustomerId;
                }
            }
        }

        private void FrmWeightPad_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnFinishInput_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                weightForm.InputFromPad(teCarNo.Text, currentMaterialId, currentCustomerId);
                lblStatus.Text = "已完成信息输入,请等待系统保存...";
                btnFinishInput.Enabled = false;
            }
        }

        private void ClearInput() 
        {
            teCarNo.Text = string.Empty;
            currentCarId = string.Empty;
            teMaterial.Text = string.Empty;
            currentMaterialId = string.Empty;
            teCustomer.Text = string.Empty;
            currentCustomerId = string.Empty;
        }

        private bool ValidateForm() 
        {
            bool isValidated = true;
            if (teCarNo.Text.Length == 0) 
            {
                lblStatus.Text = "请输入车牌号";
                isValidated = false;
                return isValidated;
            }
            if (teMaterial.Text.Length == 0)
            {
                lblStatus.Text = "请选择物资";
                isValidated = false;
                return isValidated;
            }
            return isValidated;
        }

        public void SetStatus(string message,bool enabled) 
        {
            lblStatus.Text = message;
            btnFinishInput.Enabled = enabled;
            ClearInput();
        }
         
    }
}