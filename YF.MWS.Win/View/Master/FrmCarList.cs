using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using YF.MWS.CacheService;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Win.Uc;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmCarList : BaseForm
    {
        private ICarService carService = new CarService();
        private List<SCar> lstCar = new List<SCar>();
        private GridCheckMarksSelection chkCar;

        public FrmCarList()
        {
             InitializeComponent(); 
        }

        private void btnItemAdd_ItemClick(object sender,  ItemClickEventArgs e)
        {
            using (FrmCarEdit frmEdit = new FrmCarEdit())
            {
                frmEdit.FrmMain = GetMain();
                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void BindData()
        {
            lstCar = carService.GetList();
            gcCar.DataSource = lstCar;
            if (chkCar == null)
                chkCar = new GridCheckMarksSelection(gvCar);
            chkCar.ClearSelection();
        }

        private void FrmCarList_Load(object sender, EventArgs e)
        {
            using (Utility.GetWaitForm(this))
            {
                BindData();
            }
        }

        private void btnItemEdit_ItemClick(object sender, ItemClickEventArgs e)
        { 
            if (gvCar.GetFocusedRow() != null)
            {
                SCar car = (SCar)gvCar.GetFocusedRow();
                using (FrmCarEdit frmEdit = new FrmCarEdit())
                {
                    frmEdit.FrmMain = GetMain();
                    frmEdit.RecId = car.Id;
                    if (frmEdit.ShowDialog() == DialogResult.OK)
                    {
                        BindData();
                    }
                }
            }
        }

        private void btnItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        { 
            if (chkCar.GetSelectedRow()==null || chkCar.GetSelectedRow().Count==0)
            {
                MessageDxUtil.ShowWarning("请选择要删除的车辆.");
            }
            else 
            {
                if (MessageDxUtil.ShowYesNoAndTips("确实要删除该车辆信息吗?此删除不可撤销,请慎重操作.") == DialogResult.Yes) 
                {
                    List<object> lst = chkCar.GetSelectedRow();
                    foreach (object obj in lst)
                    {
                        SCar car = (SCar)obj;
                        carService.Delete(car.Id);
                    }
                    CarCacher.Remove();
                    BindData();
                }
            }
        }

        private void barItemExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            DxHelper.ExportXls(carService.GetExport(), "Excel 97-2003 文件|*.xls");
        }

        private void barItemImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmImportCar frmImport = new FrmImportCar()) 
            {
                if (frmImport.ShowDialog() == DialogResult.OK) 
                {
                    BindData();
                }
            }
        }

        private void barItemSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            BindData();
        }

        private void barItemSync_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<object> chkObjs = chkCar.GetSelectedRow();
            if (chkObjs == null || chkObjs.Count == 0)
            {
                MessageDxUtil.ShowWarning("请选择要同步的车辆信息");
                return;
            }
            foreach (object obj in chkObjs)
            {
                SCar car = (SCar)obj;
                //webCarService.Add(car);
            }
            MessageDxUtil.ShowTips("成功同步车辆信息");
        }
    }
}