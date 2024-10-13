using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Db;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.CacheService;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.View.Order
{
    public partial class FrmCarPlanEdit : BaseForm
    {
        private IPlanService planService = new PlanService();
        private ISeqNoService seqNoService = new SeqNoService();
        private BPlan plan=null;

        public FrmCarPlanEdit()
        {
            InitializeComponent();
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidateForm())
            {
                Save();
            }
        }

        private void FrmCarEdit_Load(object sender, EventArgs e)
        {
            LoadControl();
            BindData();
        }
        void LoadControl()
        {
            weWarehBizType.InitDataNew();
            weLimitType.InitDataNew();
            this.teStartTime.EditValue = DateTime.Now;
            this.teEndTime.EditValue = DateTime.Now.AddMonths(3);
        }
        private void BindData()
        {
            if (!string.IsNullOrEmpty(RecId))
            {
                plan = planService.Get(RecId);
                if (!string.IsNullOrEmpty(plan.CustomerId)) wCustomer.CurrentValue = plan.CustomerId;
                wCarLookup.CurrentValue = wCarLookup.EditText = plan.CarNo;
                tePlanCarCount.Text = plan.PlanCarCount.ToString();
                teStartTime.EditValue = plan.StartTime.ToObjectString();
                teEndTime.EditValue = plan.EndTime.ToObjectString();
                wCustomer.CurrentValue = plan.CustomerId;
                tePlanCarCount.Text = plan.PlanCarCount.ToObjectString();
                tePlanWeight.Text = plan.PlanWeight.ToObjectString();
                weMaterial.CurrentValue = plan.MaterialId;
                rgPlanType.EditValue = (int)plan.PlanType;
                weWarehBizType.CurrentValue = (int)plan.WarehBiz;
                weLimitType.CurrentValue = (int)plan.LimitType;
                teRemark.Text = plan.Remark;
            }
        }
        private bool ValidateForm()
        {
            bool isValidated = true;
            PlanType planType = rgPlanType.EditValue.ToEnum<PlanType>();
            if (wCustomer.Text.Length == 0)
            {
                wCustomer.ErrorText = "请选择客户单位";
                isValidated = false;
            }
            if (planType == PlanType.Car)
            {
                if (wCarLookup.Text.Length == 0)
                {
                    wCarLookup.ErrorText = "请选择或输入车牌号";
                    isValidated = false;
                }
            }
            BPlan find = planService.Get(wCustomer.CurrentValue.ToObjectString(), PlanStateType.Going);
            if (planType == PlanType.Car)
            {
                find = planService.GetByCar(wCarLookup.Text, PlanStateType.Going);
            }
            if (find != null)
            {
                if (plan == null)
                {
                    if (planType == PlanType.Car)
                    {
                        MessageDxUtil.ShowWarning(string.Format("此车辆({0})已存在进行中的计划单,不能重复提交", wCarLookup.Text));
                    }
                    else
                    {
                        MessageDxUtil.ShowWarning(string.Format("此客户({0})已存在进行中的计划单,不能重复提交", wCustomer.Text));
                    }
                    isValidated = false;
                }
                else
                {
                    if (plan.Id != find.Id)
                    {
                        if (planType == PlanType.Car)
                        {
                            MessageDxUtil.ShowWarning(string.Format("此车辆({0})已存在进行中的计划单,不能重复提交", wCarLookup.Text));
                        }
                        else
                        {
                            MessageDxUtil.ShowWarning(string.Format("此客户({0})已存在进行中的计划单,不能重复提交", wCustomer.Text));
                        }
                        isValidated = false;
                    }
                }
            }
            //if (weMaterial.CurrentValue.ToObjectString().Length == 0)
            //{
            //    weMaterial.ErrorText = "请选择物资";
            //    isValidated = false;
            //}
            //if (weWarehBizType.SelectedItem == null)
            //{
            //    weWarehBizType.ErrorText = "请选择业务类型";
            //    isValidated = false;
            //}
            PlanLimitType limitType = weLimitType.CurrentValue.ToObjectString().ToEnum<PlanLimitType>();
            if (limitType == PlanLimitType.Weight)
            {
                if (tePlanWeight.Text.ToDecimal() <= 0)
                {
                    tePlanWeight.ErrorText = "请输入计划吨位";
                    isValidated = false;
                }
            }
            if (limitType == PlanLimitType.Count)
            {
                if (tePlanCarCount.Text.ToInt() <= 0)
                {
                    tePlanCarCount.ErrorText = "请输入计划车数";
                    isValidated = false;
                }
            }
            return isValidated;
        }

        private void Save()
        {
            try
            {
                if (plan == null)
                {
                    plan = new BPlan();
                    plan.Id = YF.MWS.Util.Utility.GetGuid();
                    plan.PlanNo=seqNoService.GetSeqNo(SeqCode.Plan.ToString());
                }
                wCarLookup.SaveInputItem();
                wCustomer.SaveInputItem();
                plan.CarNo= wCarLookup.Text;
                plan.CustomerId = wCustomer.CurrentValue.ToObjectString();
                plan.PlanCarCount =int.Parse(tePlanCarCount.Text.Trim());
                plan.PlanWeight = decimal.Parse(tePlanWeight.Text.Trim());
                plan.MaterialId = weMaterial.CurrentValue.ToObjectString();
                plan.PlanType = rgPlanType.EditValue.ToEnum<PlanType>();
                plan.Remark = teRemark.Text;
                plan.WarehBiz = weWarehBizType.CurrentValue.ToObjectString().ToEnum<WarehBizType>();
                plan.LimitType = weLimitType.CurrentValue.ToObjectString().ToEnum<PlanLimitType>();
                plan.StartTime = teStartTime.Time;
                plan.EndTime = teEndTime.Time;
                bool isSaved = planService.Save(plan);
                if (isSaved)
                {
                    MessageDxUtil.ShowTips("成功保存派车计划");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageDxUtil.ShowError("保存派车计划信息时发生未知错误,请重试.");
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存派车计划信息时发生未知错误,请重试.");
            }
        }
    }
}