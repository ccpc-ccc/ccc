using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YF.MWS.BaseMetadata;
using YF.MWS.CacheService;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata.CarPlate;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Event;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata;
using YF.MWS.SQliteService.Remote;
using YF.MWS.SQliteService;
using YF.MWS.Util;
using YF.MWS.Win.Core;
using YF.MWS.Win.Uc;
using YF.Utility;
using System.Collections;
using System.Diagnostics;
using YF.Utility.Data;
using YF.Utility.Configuration;
using DevExpress.XtraRichEdit.UI;
using DevExpress.Utils.Layout;

namespace YF.MWS.Win.View.Weight {
    public partial class FrmWeight2 : BaseForm {
        private ISeqNoService seqNoService = new SeqNoService();
        private IReportService reportService = new ReportService();
        private IWeightQueryService weightQueryService = new WeightQueryService();
        private IAttributeService attributeService = new AttributeService();
        private IFileService fileService = new FileService();
        private IWebFileService webFileService = new WebFileService();
        private IWebPayService webPayService = new WebPayService();
        private IWeightViewService viewService=new WeightViewService();
        private ICompanyService companyService = new CompanyService();


        private List<BarItem> lstItem = new List<BarItem>();
        private IMasterService masterService = new MasterService();
        private ICarService carService = new CarService();
        private IWeightService weightService = new WeightService();
        private IWeightExtService weightExtService = new WeightExtService();
        public FrmWeight2() {
            InitializeComponent();
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
        }
        private void FrmWeight_FormClosing(object sender, FormClosingEventArgs e) {
        }

        private void FrmWeight_FormClosed(object sender, FormClosedEventArgs e) {
        }

        private void FrmWeight2_Load(object sender, EventArgs e) {
            int ds = AppSetting.GetValue("devices").ToInt();
            tbPlan.ColumnCount = ds;
            tbPlan.ColumnStyles.Clear();
            List<DeviceCfg> lstDevice = Program._cfg.Device;
            for (int i = 0; i < ds; i++) {
                if (lstDevice.Count <= i) lstDevice.Add(new DeviceCfg());
                WeightControl weight = new WeightControl(i);
                weight.Height = tbPlan.Height;
                weight.Width = tbPlan.Width / ds;
                tbPlan.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, tbPlan.Width / ds));
                tbPlan.Controls.Add(weight, i, 0);
            }
            Program._cfg.Device = lstDevice;
            this.btnRegister.Visible = CurrentClient.Instance.CurrentVersion == VersionType.Probation;
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            FrmWeightSearch frm = new FrmWeightSearch(-1);
            frm.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            FrmRegister frm = new FrmRegister();
            frm.ShowDialog();
        }
    }
}
