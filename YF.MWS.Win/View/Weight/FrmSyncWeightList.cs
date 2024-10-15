using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.MWS.Metadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Metadata.Query;
using YF.MWS.SQliteService;
using DevExpress.XtraGrid.Views.Base;
using YF.MWS.Win.Core;
using System.ServiceModel;
using YF.Utility.Log;
using YF.MWS.Util;
using YF.MWS.Db;
using System.IO;
using YF.Utility.IO;
using System.Threading;
using YF.MWS.Win.Uc;
using YF.MWS.BaseMetadata;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;

namespace YF.MWS.Win.View.Weight
{
    public partial class FrmSyncWeightList : BaseForm
    {
        private IWeightService weightService = new WeightService();
        private IWebWeightService webWeightService = new WebWeightService();
        private IFileService fileService = new FileService();
        private IMasterService masterService = new MasterService();
        private IWeightExtService extService = new WeightExtService();
        private IWebFileService webFileService = new WebFileService();
        private GridCheckMarksSelection chkWeight;
        private List<QWeight> lst = new List<QWeight>();
        private Thread thSync;
        private bool isSync = false;
        private bool isSyncWeight = false;
        private string serverUrl = string.Empty;

        public FrmSyncWeightList()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            lst = weightService.GetList(teStartDate.Time, teEndDate.Time, combFinishState.SelectedIndex);
            gcWeight.DataSource = lst;
            gcWeight.RefreshDataSource();
            //gvWeight.OptionsView.ColumnAutoWidth = false;
            //gvWeight.BestFitColumns();
            if (chkWeight == null)
                chkWeight = new GridCheckMarksSelection(gvWeight);
            chkWeight.ClearSelection();
        }

        private void FrmSyncWeightList_Load(object sender, EventArgs e)
        {
            teEndDate.Time = DateTime.Now;
            teStartDate.Time = DateTime.Now;
            if (Program._cfg.Transfer != null)
            {
                serverUrl = Program._cfg.Transfer.ServerUrl;
            }
        }

        private void gvWeight_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "SyncState") 
            {
                if (e.ListSourceRowIndex < lst.Count && lst[e.ListSourceRowIndex].SyncState == 1)
                {
                    e.DisplayText = "已同步";
                }
                else 
                {
                    e.DisplayText = "未同步";
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            isSyncWeight = true;
            thSync = new Thread(new ThreadStart(StartUpload));
            thSync.IsBackground = true;
            thSync.Start();
        }

        private void StartUpload()
        {
            isSync = false;
            this.Invoke(new Action(() =>
            {
                using (Utility.GetWaitForm("正在上传数据到服务器..."))
                {
                    try
                    {
                        List<object> lst = chkWeight.GetSelectedRow(false);
                        QWeight weight;
                        foreach (object obj in lst) 
                        {
                            weight = (QWeight)obj;
                            //fileService.DeleteRemote(serverUrl, weight.WeightId);
                            Upload(weight.Id);
                        }
                        isSync = true;
                        if (isSync)
                        {
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        isSync = false;
                        Logger.WriteException(ex);
                    }
                }
                if (isSync)
                {
                    MessageDxUtil.ShowTips("成功上传数据到服务器.");
                }
                else
                {
                    MessageDxUtil.ShowError("上传数据到服务器时发生未知错误,请重试.");
                }
            }));
        }

        private void Upload(string weightId) 
        {
            if (isSyncWeight) 
            {
                SyncWeight weight = weightService.GetTWeight(weightId);
                bool isSaved = webWeightService.Save(weight);
                Logger.Write(string.Format("Sync-Weight:{0}-Result:{1}",weight.Weight.WeightNo,isSaved));
                if (isSaved)
                    weightService.UpdateSyncState(weightId);
                List<BFile> lstFile = fileService.GetUploadList(weightId);
                if (lstFile != null && lstFile.Count > 0)
                {
                    foreach (BFile file in lstFile)
                    {
                        SyncUtil.UploadPhoto(file, webFileService, fileService, serverUrl);
                    }
                }
            }
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            isSyncWeight = false;
            thSync = new Thread(new ThreadStart(StartUpload));
            thSync.IsBackground = true;
            thSync.Start();
        }
    }
}