using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata.Event;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using System.Drawing;
using YF.MWS.BaseMetadata;
using YF.MWS.CacheService;
using YF.MWS.Metadata;
using YF.Utility;
using YF.Utility.Log;

namespace YF.MWS.Win.Uc.Weight
{
    public class WMaterialEdit : ComboBoxEdit, IField
    {
        private object currentValue;
        private IMaterialService materialService = new MaterialService();
        private List<SMaterial> materials;
        private List<SMaterial> tempMaterials;

        public WMaterialEdit()
        {
            this.Properties.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown;
            this.Properties.Buttons[0].ToolTip = "下拉选择物资";
            this.Properties.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton() { Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, ToolTip = "窗口选择物资" });
            this.Properties.AutoComplete = false;
        }

        protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
        {
            base.OnClickButton(buttonInfo);
            if (buttonInfo.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                using (FrmMaterialSelector frm = new FrmMaterialSelector())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        this.currentValue = frm.MaterialId;
                        this.Text = frm.MaterialName;
                        SelectedItem = new ListItem() { Text = frm.MaterialId, Value = frm.MaterialName };
                    }
                }
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            LoadData(true);
            ShowPopup();
            SelectionStart = Text.Length;
        }

        public void LoadMaterial()
        {
            materials = materialService.GetMaterialList();
            LoadData(true);
        }

        private void LoadData(bool loadAll=false)
        {
            Properties.Items.Clear();
            tempMaterials = new List<SMaterial>();
            if (materials == null)
                materials = materialService.GetMaterialList();
            if (materials != null && materials.Count > 0 && Text.Length > 0 && loadAll)
            {
                tempMaterials = materials.FindAll(c => c.MaterialName.Contains(Text.Trim()) ||
                (!string.IsNullOrEmpty(c.PYMaterialName) && c.PYMaterialName.ToLower().Contains(Text.ToLower().Trim()))||
                 (!string.IsNullOrEmpty(c.MachineCode) && c.MachineCode.Contains(Text.Trim()))
                );
            }
            else
            {
                tempMaterials = materials;
            }
            if (tempMaterials != null && tempMaterials.Count > 0)
            {
                List<ListItem> items = new List<ListItem>();
                foreach (SMaterial material in tempMaterials)
                {
                    items.Add(new ListItem() { Value = material.Id, Text = material.MaterialName });
                }
                DxHelper.BindComboBoxEdit(this, items, null);
            }
        }

        public void SetMaterial()
        {
            string materialName = this.Text.Trim();
            if (!string.IsNullOrEmpty(materialName))
            {
                SMaterial material = materialService.GetMaterialByName(materialName);
                if (material == null || string.IsNullOrEmpty(material.Id) || material.Id.Length==0)
                {
                    material = new SMaterial();
                    material.Id = YF.MWS.Util.Utility.GetGuid();
                    material.MaterialName = materialName;
                    material.MaterialCode = YF.Utility.Language.PinYinUtil.GetInitial(materialName);
                    material.State = (int)MaterialStateType.Enable;
                    materialService.SaveMaterial(material);
                    materials = materialService.GetMaterialList();
                    LoadData(true);
                }
                MasterCacher.Refresh();
                this.currentValue = material.Id;
            }
        }

        #region IField 成员
        public string ActionName
        {
            get;
            set;
        }
        public string Caption
        {
            get;
            set;
        }
        public string ErrorTipText
        {
            get;
            set;
        }
        public object CurrentValue
        {
            get
            {
                string selectValue = DxHelper.GetStrValue(this);
                if (!string.IsNullOrEmpty(selectValue))
                    return selectValue;
                return currentValue;
            }
            set
            {
                currentValue = value;
                if (currentValue != null && currentValue.ToObjectString().Length > 0)
                {
                    SelectedItem = Properties.Items.Cast<ListItem>().FirstOrDefault(c => c.Value == Convert.ToString(value));
                    if (SelectedItem == null || SelectedItem.ToObjectString().Length == 0)
                    {
                        SMaterial material = materialService.GetMaterial(currentValue.ToString());
                        if (material != null)
                        {
                            Text = material.MaterialName;
                        }
                    }
                }
            }
        }

        public string FieldName
        {
            get;
            set;
        }

        public bool IsRequired
        {
            get;
            set;
        }

        /// <summary>
        /// 启用驻留
        /// </summary>
        public bool StartStay { get; set; }
        /// <summary>
        /// 启用自动保存
        /// </summary>
        public bool StartAutoSave { get; set; }

        public int DecimalDigits
        {
            get;
            set;
        }

        public void Clear()
        {
            try
            {
                CurrentValue = t1;
                if (IsHandleCreated)
                {
                    BeginInvoke(new Action(() =>
                    {
                       if(t1==null) Text = "";
                    }));
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        public void SetEnabled(bool enable)
        {
            this.Enabled = enable;
        }

        public string ControlName
        {
            get;
            set;
        }

        public string Expression
        {
            get;
            set;
        }

        public int AutoCalcNo
        {
            get;
            set;
        }
        public string t1 { get; set; }

        public void InitData()
        {
            this.Font = CfgUtil.GetFont();
            LoadData();
        }

        public WeightVauleChangedEventHandler WeightVauleChanged
        {
            get;
            set;
        }

        public string EditText
        {
            get { return Text; }
            set { Text = value; }
        }

        public void SetReadonly()
        {
            this.Properties.ReadOnly = true;
        }

        public Point ParentLocation
        {
            get;
            set;
        }
        public void SaveInputItem()
        {
            SetMaterial();
        }
        #endregion
    }
}
