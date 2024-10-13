using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using YF.MWS.Win.Util;
using YF.MWS.Db;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using DevExpress.XtraGrid.Views.Grid;
using YF.MWS.CacheService;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.Uc
{
    public partial class FrmCarSelector : DevExpress.XtraEditors.XtraForm
    {
        private ICarService carService = new CarService();
        private List<SCar> lstCar = new List<SCar>();
        private GridCheckMarksSelection chkCar;
        private bool isSelect=false;
        public string CarId { get; set; }
        public string CarNo { get; set; }

        public FrmCarSelector()
        {
            InitializeComponent();
        } 

        private void btnOK_Click(object sender, EventArgs e)
        {
            SetCarNo();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCarSelector_Load(object sender, EventArgs e)
        {
            tabCar.SelectedTabPageIndex = 1;
            BindData();
        }

        private void BindData()
        {
            lstCar = CarCacher.GetList();
            gcCar.DataSource = lstCar;
            if (chkCar == null)
                chkCar = new GridCheckMarksSelection(gvCar);
            chkCar.ClearSelection();
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            isSelect=false;
            SimpleButton btn = (SimpleButton)sender;
            if (btn != null) 
            {
                teCarNo.Text = teCarNo.Text + btn.Text;
            }
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (teCarNo.Text.Length > 0) 
            {
                teCarNo.Text = teCarNo.Text.Substring(0,teCarNo.Text.Length - 1);
            }
        }

        private void gvCar_RowClick(object sender, RowClickEventArgs e)
        {
            isSelect=true;
            if (gvCar.GetFocusedRow() != null) 
            {
                SCar car = (SCar)gvCar.GetFocusedRow();
                CarId = car.Id;
                CarNo = car.CarNo;
                teCarNo.Text = car.CarNo;
            }
        }

        private bool ValidateForm() 
        {
            bool isValidated = true;
            if (teCarNo.Text.Length > 10) 
            {
                teCarNo.ErrorText = "车牌号长度不能超过10个字符.";
                isValidated = false;
            }
            return isValidated;
        }

        private void SetCarNo() 
        {
            if (!isSelect) 
            {
                SCar car = CarCacher.GetWithCarNo(teCarNo.Text.Trim());
                if (car != null)
                {
                    CarId = car.Id;
                    CarNo = car.CarNo;
                }
                else 
                {
                    car = new SCar();
                    car.Id = YF.MWS.Util.Utility.GetGuid();
                    car.CarNo = teCarNo.Text.Trim();
                    car.CarType = "A1";
                    carService.Save(car);
                    CarCacher.Remove(car.CarNo);
                    CarId = car.Id;
                    CarNo = car.CarNo;
                }
            }
        }

        private void gvCar_DoubleClick(object sender, EventArgs e)
        {
            isSelect = true;
            if (gvCar.GetFocusedRow() != null)
            {
                SCar car = (SCar)gvCar.GetFocusedRow();
                CarId = car.Id;
                CarNo = car.CarNo;
                teCarNo.Text = car.CarNo;
            }
            SetCarNo();
            this.DialogResult = DialogResult.OK;
        }
    }
}