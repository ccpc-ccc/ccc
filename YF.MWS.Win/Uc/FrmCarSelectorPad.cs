using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Db;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.CacheService;

namespace YF.MWS.Win.Uc
{
    public partial class FrmCarSelectorPad : DevExpress.XtraEditors.XtraForm
    {
        private ICarService carService = new CarService();
        private bool isSelect = false;
        public string CarId { get; set; }
        public string CarNo { get; set; }
        public FrmCarSelectorPad()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCarSelectorPad_Load(object sender, EventArgs e)
        {
            SetEvent();
        }

        private void SetEvent() 
        {
            btnBeijing.Click += btnCode_Click;
            btnA.Click += btnCode_Click;
            btnB.Click += btnCode_Click;
            btnC.Click += btnCode_Click;
            btnChongqin.Click += btnCode_Click;
            btnD.Click += btnCode_Click;
            btnE.Click += btnCode_Click;
            btnEight.Click += btnCode_Click;
            btnF.Click += btnCode_Click;
            btnFive.Click += btnCode_Click;
            btnFour.Click += btnCode_Click;
            btnG.Click += btnCode_Click;
            btnGan.Click += btnCode_Click;
            btnGansu.Click += btnCode_Click;
            btnGuangdong.Click += btnCode_Click;
            btnGuangxi.Click += btnCode_Click;
            btnGuizhou.Click += btnCode_Click;
            btnH.Click += btnCode_Click;
            btnHainan.Click += btnCode_Click;
            btnHei.Click += btnCode_Click;
            btnHu.Click += btnCode_Click;
            btnHubei.Click += btnCode_Click;
            btnHunan.Click += btnCode_Click;
            btnI.Click += btnCode_Click;
            btnJ.Click += btnCode_Click;
            btnJi.Click += btnCode_Click;
            btnJiLin.Click += btnCode_Click;
            btnJin.Click += btnCode_Click;
            btnK.Click += btnCode_Click;
            btnL.Click += btnCode_Click;
            btnLiao.Click += btnCode_Click;
            btnLu.Click += btnCode_Click;
            btnM.Click += btnCode_Click;
            btnMeng.Click += btnCode_Click;
            btnMin.Click += btnCode_Click;
            btnN.Click += btnCode_Click;
            btnNine.Click += btnCode_Click;
            btnNingxia.Click += btnCode_Click;
            btnO.Click += btnCode_Click;
            btnOne.Click += btnCode_Click;
            btnP.Click += btnCode_Click;
            btnQ.Click += btnCode_Click;
            btnQinhai.Click += btnCode_Click;
            btnR.Click += btnCode_Click;
            btnS.Click += btnCode_Click;
            btnSeven.Click += btnCode_Click;
            btnShanxi.Click += btnCode_Click;
            btnSichuan.Click += btnCode_Click;
            btnSix.Click += btnCode_Click;
            btnSu.Click += btnCode_Click;
            btnT.Click += btnCode_Click;
            btnThree.Click += btnCode_Click;
            btnTianJing.Click += btnCode_Click;
            btnTwo.Click += btnCode_Click;
            btnU.Click += btnCode_Click;
            btnV.Click += btnCode_Click;
            btnW.Click += btnCode_Click;
            btnWan.Click += btnCode_Click;
            btnX.Click += btnCode_Click;
            btnXizang.Click += btnCode_Click;
            btnY.Click += btnCode_Click;
            btnYu.Click += btnCode_Click;
            btnYunnan.Click += btnCode_Click;
            btnZ.Click += btnCode_Click;
            btnZero.Click += btnCode_Click;
            btnZhe.Click += btnCode_Click;
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            isSelect = false;
            SimpleButton btn = (SimpleButton)sender;
            if (btn != null)
            {
                teCarNo.Text = teCarNo.Text + btn.Text;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SetCarNo();
            this.DialogResult = DialogResult.OK;
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
                    CarId = car.Id;
                    CarNo = car.CarNo;
                }
            }
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (teCarNo.Text.Length > 0)
            {
                teCarNo.Text = teCarNo.Text.Substring(0, teCarNo.Text.Length - 1);
            }
        }
    }
}