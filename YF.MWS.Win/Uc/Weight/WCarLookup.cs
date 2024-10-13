using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Db;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Metadata.Event;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using YF.MWS.Metadata.Cfg;
using YF.MWS.CacheService;
using YF.MWS.Metadata;
using YF.Utility.Log;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.Uc.Weight
{
    public partial class WCarLookup : ComboBoxEdit, IField
    {
        private object currentValue;
        private ICarService carService=new CarService(); 
        private string carNo = string.Empty;
        private List<SCar> cars;
        private List<SCar> tempCars;
        public event ManualCarRecognizeTriggerHandler ManualCarRecognizeTrigger;

        public WCarLookup()
        {
            this.Properties.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown;
            this.Properties.Buttons[0].ToolTip = "下拉选择车牌";
            this.Properties.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton() { Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis,ToolTip="窗口选择车牌" });
            this.Properties.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton() { Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, ToolTip="手动触发车牌识别" });
            this.Properties.Buttons[2].Image =  YF.MWS.Win.Properties.Resources.camera_16x16;
            this.Properties.AutoComplete = false;
        }
        
        protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
        {
            carNo = string.Empty;
            base.OnClickButton(buttonInfo);
            if (buttonInfo.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                using (FrmCarSelector frm = new FrmCarSelector())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        this.currentValue = frm.CarId;
                        this.carNo = frm.CarNo;
                        this.Text = frm.CarNo;
                        SelectedItem = new ListItem() { Text = frm.CarId, Value = frm.CarNo };
                    }
                }
            }
            if (buttonInfo.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                if (ManualCarRecognizeTrigger != null)
                    ManualCarRecognizeTrigger(this, new ManualCarRecognizeTriggerEventArgs());
            }
        }
        public string t1 { get; set; }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            InitData();
            this.ShowPopup();
            this.SelectionStart = this.Text.Length;
        }

        public void SetCarNo(decimal tareWeight=0,string driverName = "", CarType carType = CarType.Out)
        {
            if (string.IsNullOrEmpty(this.Text) || this.Text.Trim().Length == 0) return;
            string carNo = this.Text.Trim().Replace(" ", "");
            if (!string.IsNullOrEmpty(carNo) && carNo.Length > 0)
            {
                SCar car = carService.GetByCarNo(carNo);
                if (car != null)
                {
                    this.CurrentValue = car.Id;
                }
                else
                {
                    car = new SCar();
                    car.Id = YF.MWS.Util.Utility.GetGuid();
                    car.CarNo = carNo;
                    car.CarType = carType.ToString();
                    if (!string.IsNullOrEmpty(driverName))
                        car.DriverName = car.DriverName;
                }
                car.Tare = tareWeight;
                carService.Save(car);
                cars = carService.GetList();
                InitData();
                CarCacher.Remove();
                CurrentValue = car.Id;

            }
        }

        #region IField 成员
        public string ActionName
        {
            get;
            set;
        }

        public void LoadCar()
        {
            cars = carService.GetList();
            InitData();
        }

        public void InitData()
        {
            this.Font = CfgUtil.GetFont();
            tempCars = new List<SCar>();
            if (cars == null)
                cars = carService.GetList();
            if (cars != null && cars.Count > 0 && Text.Length > 0)
            {
                tempCars = cars.FindAll(c => c.CarNo.Contains(Text.Trim()));
            }
            else
            {
                tempCars = cars;
            }
            if (tempCars != null)
            {
                List<ListItem> items = new List<ListItem>();
                foreach (SCar car in tempCars)
                {
                    items.Add(new ListItem() { Value = car.Id, Text = car.CarNo });
                }
                DxHelper.BindComboBoxEdit(this, items, null);
            }
        }
        public string Caption
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
                if (currentValue != null)
                {
                    SCar car = carService.Get(currentValue.ToString());
                    if (car != null)
                    {
                        carNo = car.CarNo;
                        Text = car.CarNo;
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

        public void Clear()
        {
            try
            {
                CurrentValue = t1;
                if (IsHandleCreated)
                {
                    BeginInvoke(new Action(() => {
                        if (t1 == null) Text = "";
                    }));
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        public int DecimalDigits
        {
            get;
            set;
        }

        public void SetEnabled(bool enable)
        {
            this.Enabled = enable;
            this.Properties.ReadOnly = !enable;
        }  

        public string ControlName
        {
            get;
            set;
        }

        public string ErrorTipText
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

        public string EditText
        {
            get { return Text; }
            set { Text = value; }
        }

        public WeightVauleChangedEventHandler WeightVauleChanged
        {
            get;
            set;
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
            SetCarNo();
        }
        #endregion
    }
}
