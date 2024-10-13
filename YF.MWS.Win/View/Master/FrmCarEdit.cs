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

namespace YF.MWS.Win.View.Master
{
    public partial class FrmCarEdit : BaseForm
    {
        private ICarService carService = new CarService();
        private ISeqNoService seqNoService = new SeqNoService();
        private SCar car;
        private bool isAdd = true;
        private string carNo;

        public string CarNo
        {
            get { return carNo; }
            set { carNo = value; }
        }
        public decimal Tare { get; set; }
        public FrmCarEdit()
        {
            InitializeComponent();
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            Save();
        }

        private void FrmCarEdit_Load(object sender, EventArgs e)
        {
                BindData();
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (teCarNo.Text.Length == 0)
            {
                teCarNo.ErrorText = "请输入车牌号";
                teCarNo.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                isValidated = false;
            }
            //if (combCarType.EditValue==null)
            //{
            //    combCarType.ErrorText = "请选择车辆类型";
            //    combCarType.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            //    isValidated = false;
            //}
            //if (teTare.Text.ToDecimal() <= 0) 
            //{
            //    teTare.ErrorText = "请输入皮重";
            //    isValidated = false;
            //}
            return isValidated;
        }

        private void Save()
        {
            try
            {
                if (ValidateForm())
                {
                    if (car == null)
                    {
                        car = new SCar();
                        car.Id = YF.MWS.Util.Utility.GetGuid();
                    }
                    FormHelper.ControlToEntity<SCar>(this, ref car);
                    car.CarType = DxHelper.GetCode(combCarType);
                    car.LimitState = chkLimitState.Checked ? 1 : 0;
                    car.CarNo = teCarNo.Text.Trim().Replace(" ", "");
                    if (carService.CarNoExist(car.CarNo, car.Id))
                    {
                        MessageDxUtil.ShowWarning(string.Format("车牌号({0})已经存在,请勿重复添加.",car.CarNo));
                    }
                    else
                    {
                        bool isSaved=carService.Save(car);
                        if (isSaved)
                        {
                            if (FrmMain != null)
                                FrmMain.LoadCar();
                            CarCacher.Remove(car.CarNo);
                            CarCacher.Remove();
                        }
                        MessageDxUtil.ShowTips("成功保存车辆信息.");
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch(Exception ex) 
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存车辆信息时发生未知错误,请重试.");
            }
        }

        private void BindData() 
        {
            if (string.IsNullOrEmpty(RecId))
            {
                DxHelper.BindComboBoxEdit(combCarType, SysCode.CarType, null); 
            }
            else 
            {
                car = carService.Get(RecId);
                if (car != null)
                {
                    teCarNo.Enabled = false;
                    isAdd = false;
                    DxHelper.BindComboBoxEdit(combCarType, SysCode.CarType, car.CarType);
                    FormHelper.BindControl<SCar>(this, car);
                    chkLimitState.Checked = car.LimitState == 1 ? true : false;
                }
                else 
                {
                    if (!string.IsNullOrEmpty(carNo)) 
                    {
                        teCarNo.Text = carNo;
                    }
                    DxHelper.BindComboBoxEdit(combCarType, SysCode.CarType, null);
                }
            }
        }

        private void barItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        
    }
}