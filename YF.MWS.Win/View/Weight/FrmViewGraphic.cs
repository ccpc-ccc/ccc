using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.MWS.Metadata.Transfer;
using YF.MWS.Util;
using YF.Utility.Log;
using YF.Utility;
using YF.Utility.Metadata;
using System.Linq;

namespace YF.MWS.Win.View.Weight
{
    public partial class FrmViewGraphic : BaseForm
    {
        private List<BFile> lstFile = new List<BFile>();
        private IFileService fileService = new FileService();
        private bool loadImageWithRemote = false;
        private string serverUrl = string.Empty;
        private int currentIndex = 0;
        private int count = 0;
        private CaptureMode mode = CaptureMode.Cut;

        public FrmViewGraphic()
        {
            InitializeComponent();
        }

        private void FrmViewGraphic_Load(object sender, EventArgs e)
        {
            BindData();
            LoadImage();
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void BindData() {
            if (Cfg != null) {
                if (Cfg.Video != null)
                    mode = Cfg.Video.CaptureMode;
                if (Cfg.Weight != null) {
                    loadImageWithRemote = Cfg.Weight.StartLoadImageWithRemote;
                }
                if (Cfg.Transfer != null) {
                    serverUrl = Cfg.Transfer.ServerUrl;
                }
            }
            if (loadImageWithRemote) {
                TPageResult result = fileService.GetListFromRemote(serverUrl, RecId);
                if (result != null && result.Code == (int)ResultCode.Success && result.Rows != null) {
                    lstFile = result.Rows.ToString().JsonDeserialize<List<BFile>>().ToList();
                    if (lstFile != null && lstFile.Count > 0) {
                        lstFile = lstFile.FindAll(c => c.BusinessType == FileBusinessType.Graphic.ToString());
                    }
                }
            } else {
                lstFile = fileService.Get(RecId, "B_Weight", FileBusinessType.Graphic).ToList();
            }
            if (lstFile != null && lstFile.Count > 0) {
                count = lstFile.Count;
            }
        }

        private void btnItemFirst_ItemClick(object sender, ItemClickEventArgs e)
        {
            currentIndex = 0;
            LoadImage();
        }

        private void barItemPrev_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (currentIndex > 0) 
            {
                currentIndex--;
            }
            LoadImage();
        }

        private void barItemNext_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (currentIndex < lstFile.Count - 1) 
            {
                currentIndex++;
            }
            LoadImage();
        }

        private void barItemLast_ItemClick(object sender, ItemClickEventArgs e)
        {
            currentIndex = lstFile.Count - 1;
            LoadImage();
        }

        private void LoadImage() 
        {
            SetPageButton();
            if (lstFile.Count >= currentIndex + 1) 
            {
                BFile file = lstFile[currentIndex];
                if (loadImageWithRemote)
                {
                    string url = string.Format("{0}{1}", serverUrl, file.FileUrl);
                    //Logger.Write(string.Format("fileId:{0};url:{1}", file.FileId, file.FileUrl));
                    peView.LoadAsync(url);
                }
                else
                {
                    string fileName = Path.Combine(Application.StartupPath, file.FileUrl);
                    if(File.Exists(fileName))
                       peView.Image = Image.FromFile(fileName);
                }
                lblCreateTime.Text = string.Format("抓拍时间:{0}",file.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                lblFileType.Text = string.Format("图片类型:{0}",file.FileType.ToEnum<FileType>().ToDescription());
            }
        }

        private void SetPageButton() 
        {
            if (count <= 1)
            {
                btnItemFirst.Enabled = false;
                barItemPrev.Enabled = false;
                barItemNext.Enabled = false;
                barItemLast.Enabled = false;
            }
            else
            {
                btnItemFirst.Enabled = true;
                barItemPrev.Enabled = true;
                barItemNext.Enabled = true;
                barItemLast.Enabled = true;
                if (currentIndex == 0)
                {
                    btnItemFirst.Enabled = false;
                    barItemPrev.Enabled = false;
                }
                if (currentIndex == count - 1)
                {
                    barItemNext.Enabled = false;
                    barItemLast.Enabled = false;
                }
            }
        }

    }
}