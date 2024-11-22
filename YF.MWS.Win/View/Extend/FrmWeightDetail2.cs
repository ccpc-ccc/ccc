using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Util;
using YF.MWS.Win.Core;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Uc.Weight;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.Utility.Log;
using YF.MWS.CacheService;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using YF.MWS.Metadata.Dto;
using System.Web.UI.WebControls.Expressions;

namespace YF.MWS.Win.View.Extend
{
    public partial class FrmWeightDetail2 : BaseForm
    {
        public DataTable Dt { get; set; }
        private IMasterService masterService = new MasterService();
        private ICarService carService = new CarService();
        private IWeightQueryService weightQueryService = new WeightQueryService();
        private ICardService cardService = new CardService();
        private ICustomerService customerService = new CustomerService();
        private IWeightService weightService = new WeightService();
        private IWeightViewService viewService = new WeightViewService();
        private IAttributeService attributeService = new AttributeService();
        private IWeightExtService weightExtService = new WeightExtService();
        private ISeqNoService seqNoService = new SeqNoService();
        private IFileService fileService = new FileService();
        private IWebPayService webPayService = new WebPayService();
        private ILogService logService = new LogService();
        private SyncObject syncObj = new SyncObject();
        /// <summary>
        /// 物资单价
        /// </summary>
        private WNumbericEdit weUnitPrice;
        private string softOneUnit;

        /// <summary>
        /// 毛重详情
        /// </summary>
        private BWeightDetail tareDetail;
        /// <summary>
        /// 皮重详情
        /// </summary>
        private BWeightDetail grossDetail;

        private bool isSearchEdit = false;
        /// <summary>
        /// 是否开启磅单输入项自动保存(不存在对应的基础数据项的前提下)
        /// </summary>
        private bool startInputItemAutoSave;
        private WeightProcess currentWeightProcess = WeightProcess.Two;
        private bool startAutoUpload = false;
        /// <summary>
        /// 启用计划单限制功能
        /// </summary>
        private bool startPlan = false;
        /// <summary>
        /// 是否为磅单搜索
        /// </summary>
        public bool IsSearchEdit
        {
            get { return isSearchEdit; }
            set { isSearchEdit = value; }
        }

        public FrmWeightDetail2()
        {
            InitializeComponent();
        }


        private void Save()
        {
            try
            {
                BWeight weight = null;
                foreach(DataRow dr in Dt.Rows) {
                    string RecId = dr["WeightId"].ToString();
                if (!string.IsNullOrEmpty(RecId))
                {
                    weight = weightService.Get(RecId);
                }
                if(weight==null) { continue; }
                weight.AdditionalTime = DateTime.Now;
                weight.PayType = "Settled";
                weight.d3 = weight.d2;
                    if (weight.d3 == 0) {
                        weight.d3 = weight.SuttleWeight;
                    }
                weight.UnitPrice= txtUnitPrice.Text.ToDecimal();
                weight.UnitMoney= weight.UnitPrice* weight.d3;
                weightService.Save(weight);
                }
                MessageDxUtil.ShowTips("结算成功！");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存磅单信息时发生未知错误,请重试.");
            }
        }
        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
                Save();
        }

        private void barItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmWeightDetail_Load(object sender, EventArgs e)
        {
            gcWeight.DataSource = Dt;
            gvWeight.Columns["ViewId"].Visible = false;
            gvWeight.Columns["WeightId"].Visible = false;
            getTotal();
        }
        private void getTotal() {
            decimal totalWeight = 0;
            foreach(DataRow row in Dt.Rows) {
                if (row["d2"].ToDecimal()>0) {
                    totalWeight += row["d2"].ToDecimal();
                } else {
                    totalWeight += row["SuttleWeight"].ToDecimal();
                }
            }
            txtD3.Text=totalWeight.ToString();
        }

        private void txtD3_EditValueChanged(object sender, EventArgs e) {
            txtUnitMoney.Text = (txtD3.Text.ToDecimal()*txtUnitPrice.Text.ToDecimal()).ToString();
        }
    }
}