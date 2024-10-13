using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.Utility.IO;
using YF.MWS.Win.Util;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Metadata;
using YF.Utility;
using YF.MWS.Db;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmImportCard : DevExpress.XtraEditors.XtraForm
    {
        private ICardService cardService = new CardService();
        private ICarService carService=new CarService();
        private ICustomerService customerService = new CustomerService();
        private IMasterService masterService = new MasterService();
        private IMaterialService materialService = new MaterialService();
        public FrmImportCard()
        {
            InitializeComponent();
        }

        private void FrmImportCard_Load(object sender, EventArgs e)
        {

        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            DxHelper.OpenFile("Excel 97-2003 文件|*.xls|Excel 文件|*.xlsx", btnFile);
        }

        private void barItemImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateForm())
            {
                ImportMode mode = rgImportMode.EditValue.ToEnum<ImportMode>();
                if (mode == ImportMode.New)
                {
                    string message = "全新导入的方式会将原有的数据全部删除,您确定要这样操作吗?";
                    if (MessageDxUtil.ShowYesNoAndTips(message) != DialogResult.Yes)
                    {
                        return;
                    }
                }
                Import();
            }
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (rgImportMode.EditValue == null)
            {
                rgImportMode.ErrorText = "请选择导入方式";
                isValidated = false;
                return isValidated;
            }
            if (btnFile.Text.Length == 0)
            {
                btnFile.ErrorText = "请选择要导入的文件";
                isValidated = false;
                return isValidated;
            }
            return isValidated;
        }

        private void Import()
        {
            List<ImportResult> lstResult = new List<ImportResult>();
            using (Utility.GetWaitForm("正在导入"))
            {
                DataTable dt = NPOIHelper.GetDataTable(btnFile.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    List<BPlanCard> lstCard = new List<BPlanCard>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr[0] == null || dr[0].ToObjectString().Length == 0)
                            continue;
                        lstCard.Add(new BPlanCard()
                        {
                            Id = dr[0].ToObjectString(),
                            MachineCode = CurrentClient.Instance.MachineCode,
                            CardNo = dr[1].ToObjectString(),
                            CarNo = dr[2].ToObjectString(),
                            DriverName = dr[3].ToObjectString(),
                            PlanNo = dr[4].ToObjectString(),
                            MeasureType = dr[5].ToObjectString(),
                            CustomerName = dr[6].ToObjectString(),
                            DeliveryName = dr[7].ToObjectString(),
                            ReceiverName = dr[8].ToObjectString(),
                            MaterialName = dr[9].ToObjectString()
                        });
                    }
                    ImportMode mode = rgImportMode.EditValue.ToEnum<ImportMode>();
                    lstResult = cardService.ImportCard(lstCard, mode, carService, customerService, materialService);
                }
            }
            int successCount = 0;
            int failedCount = 0;
            if (lstResult != null && lstResult.Count > 0)
            {
                successCount = lstResult.Count(c => c.Success == true);
                failedCount = lstResult.Count(c => c.Success == false);
            }
            string message = string.Format("导入结果:导入成功{0}条记录,导入失败{1}条记录.", successCount, failedCount);
            MessageDxUtil.ShowTips(message);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}