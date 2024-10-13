using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.BaseMetadata;
using System.Threading.Tasks;
using YF.MWS.CacheService;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmViewShow : BaseForm
    {
        private IWeightViewService viewService = new WeightViewService();
        private List<SControl> lstControl = new List<SControl>();
        private List<WeightViewControl> lstViewControls = new List<WeightViewControl>();
        private SWeightView View = null;
        private ControlType ctrlType= ControlType.Standard; 
        public string ViewId;

        public FrmViewShow()
        {
            InitializeComponent();
        }
        

        private void FrmViewDetail_Load(object sender, EventArgs e)
        {
            BindData();
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

        private void Save() 
        {
            try
            {
                if(View==null)View=new SWeightView() { ViewType="Weight"};
                View.ViewName=txtViewName.Text;
                View.ColumnsCount = txtColumnConut.Text.ToInt();
                View.IsDefault=chkDefual.Checked?1:0;
                List<SWeightViewDtl> lstViewDtl=new List<SWeightViewDtl>();
                foreach (WeightViewControl c in this.lstViewControls) {
                    if (c.weightViewDtl != null) {
                        lstViewDtl.Add(c.weightViewDtl);
                    }
                }
                bool isSave=viewService.saveWeightView(View, lstViewDtl);
                if (isSave) {
                    MessageDxUtil.ShowTips("成功保存界面信息.");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                } else MessageDxUtil.ShowTips("保存界面信息失败.");
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存界面信息时发生未知错误,请重试.");
            }
        }

        private void BindData() 
        {
            lstControl = viewService.GetViewControlList();
            lstControl.Insert(0, new SControl() { Id="",FullName="",FieldName=""});
            lstViewControls.Clear();
            if (!string.IsNullOrEmpty(ViewId)) 
            {
                List<SWeightViewDtl> lstViewDtl = viewService.GetDetailList(ViewId);
                View=viewService.GetView(ViewId);
                txtViewName.Text = View.ViewName;
                txtColumnConut.Text= View.ColumnsCount.ToString();
                lstControl= WeightControlCacher.Remove(lstControl, lstViewDtl);
                foreach (SWeightViewDtl dtl in lstViewDtl) {
                    WeightViewControl control = new WeightViewControl(lstControl,dtl);
                    control.frm = this;
                lstViewControls.Add(control);
                }
            } else {
                for (int i= 0;i<txtColumnConut.Text.ToInt();i++) {
                    WeightViewControl control = new WeightViewControl(lstControl,null);
                    control.frm = this;
                lstViewControls.Add(control);
                }
            }
            UpdateShow();
        }
        private void UpdateShow() {
            this.pcControls.Controls.Clear();
            int num = txtColumnConut.Text.ToInt();
            int w = pcControls.Width / num;
            int i = 0;
            int j = 0;
                foreach (WeightViewControl control in lstViewControls) {
                i = i % num;
                    control.Location =new Point( w * i,j*control.Height);
                control.Width = w;
                    control.BindData();
                this.pcControls.Controls.Add(control);
                if (i+1>=num) j++;
                i++;
                }
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (txtViewName.Text.Length == 0)
            {
                txtViewName.ErrorText = "请输入控件名称";
                isValidated = false;
            }
            if (txtColumnConut.Text.ToInt() <= 0) {
                txtColumnConut.ErrorText = "控件列数至少要有一列";
                isValidated = false;
            }
            return isValidated;
        }
        public void BindData(SControl oldControl,SControl newControl,WeightViewControl control) {
            if (oldControl == null && newControl == null) return;
            if(oldControl == newControl) return;
            this.lstControl = control.weightControls;
            foreach(WeightViewControl dtl in lstViewControls) {
                dtl.ChangeItem(oldControl, newControl, control);
            }
        }

        private void txtColumnConut_Leave(object sender, EventArgs e) {
            UpdateShow();
        }

        private void pcControls_SizeChanged(object sender, EventArgs e) {
            UpdateShow();
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            WeightViewControl control = new WeightViewControl(lstControl, null);
            control.frm = this;
            lstViewControls.Add(control);
            UpdateShow();
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            if (lstViewControls.Count <= 0) return;
            lstViewControls.RemoveAt(lstViewControls.Count-1);
            UpdateShow();
        }

        private void txtColumnConut_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                UpdateShow();
            }
        }
    }
}