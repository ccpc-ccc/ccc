using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using YF.MWS.Metadata.Event;
using YF.MWS.Metadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.Utility;
using YF.MWS.Win.Util;
using YF.MWS.Db;
using DevExpress.Utils.Controls;
using System.Threading.Tasks;
using YF.MWS.Win.View.Master;
using DevExpress.XtraEditors.Controls;

namespace YF.MWS.Win.Uc
{
    public partial class WeightViewControl : DevExpress.XtraEditors.XtraUserControl {
        public WeightDirection Direction = WeightDirection.Left;
        public event WeightItemClickEventHandler WeightItemClick;
        public event ViewItemClickEventHandler ViewItemClick;
        /// <summary>
        /// 当前选中控件
        /// </summary>
        private SControl currentControl = null;
        private bool isChange=false;
        public delegate Task ControlChange(SControl oldControl, SControl newControl);
        /// <summary>
        /// 字段数据
        /// </summary>
        public SWeightViewDtl weightViewDtl { get; set; } = null;
        public List<SControl> weightControls { get; set; }
        public FrmViewShow frm { get; set; }

        public WeightViewControl(List<SControl> weightControls, SWeightViewDtl weightViewDtl)
        {
            InitializeComponent();
            this.weightControls = new List<SControl>();
            this.weightControls.AddRange(weightControls);
            if(weightViewDtl != null) {
                this.weightViewDtl = weightViewDtl;
                SControl control = new SControl() {
                    Id=weightViewDtl.ControlId,
                    Caption=weightViewDtl.Caption,
                    FullName=weightViewDtl.FullName,
                    ControlName=weightViewDtl.ControlName,
                    FieldName=weightViewDtl.FieldName
                };
                this.weightControls.Insert(1, control);
            }
            BindData();
        }

        private void WeightMenu2_Load(object sender, EventArgs e) {

        }
        public void BindData() {
            List<ListItem> items = new List<ListItem>();
            SControl sControl = null;
            foreach (SControl control in weightControls) {
                items.Add(new ListItem(control.ControlName, control.FieldName));
                if(control != null&& weightViewDtl!=null&& control.FieldName == weightViewDtl.FieldName) {
                    sControl=control;
                }
            }
            string value = "";
            if (weightViewDtl != null) value = weightViewDtl.FieldName;
            DxHelper.BindComboBoxEdit(cbData, items, value);
            currentControl= sControl;
        }
        private void cbData_SelectedIndexChanged(object sender, EventArgs e) {
            if (isChange) return;
            isChange = true;
                SControl control = weightControls[cbData.SelectedIndex];
                if (control == null|| control.FieldName==null||control.FieldName=="") {
                    weightViewDtl = null;
                txtCaption.Text = "";
            } else {
                    weightViewDtl = new SWeightViewDtl() {
                    ControlId = control.Id,
                    ControlName =control.ControlName,
                    RowState=0,
                    FullName=control.FullName,
                    Caption=control.Caption,
                    Show2=1,
                    FieldName=control.FieldName
                    };
                    txtCaption.Text = weightViewDtl.Caption;
                }
            if (frm != null) frm.BindData(currentControl, control,this);
            currentControl = control;
            isChange=false;
        }
        public void ChangeItem(SControl oldControl,SControl newControl,WeightViewControl control) {
            if (control == this) return;
           if(oldControl!=null&&oldControl.Id!="") this.weightControls.Add(oldControl);
           if(newControl!=null&&newControl.Id!="")  this.weightControls.Remove(newControl);
            BindData();
        }
        private void txtCaption_EditValueChanged(object sender, EventArgs e) {
            if(weightViewDtl != null) {
                weightViewDtl.Caption = txtCaption.Text;
                //txtCaption.SelectionStart= txtCaption.Text.Length;
            }
        }
    }
}
