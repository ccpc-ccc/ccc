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
using YF.MWS.Win.Uc.Weight;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmCarEdit : BaseForm
    {
        private ICarService carService = new CarService();
        private ISeqNoService seqNoService = new SeqNoService();
        WTextEdit teCarNo;
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

        private void FrmCarEdit_Load(object sender, EventArgs e) {
            teCarNo = mainWeight1.FindControl<WTextEdit>("CarNo");
            BindData();
        }

        private bool ValidateForm()
        {
            if (teCarNo == null) return true;
            bool isValidated = true;
            if (teCarNo.Text.Length == 0)
            {
                teCarNo.ErrorText = "请输入车牌号";
                teCarNo.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                isValidated = false;
            }
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
                    mainWeight1.SaveInputItem();
                    mainWeight1.ControlToEntity<SCar>(ref car);
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
                    mainWeight1.BindControl<SCar>(car);
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