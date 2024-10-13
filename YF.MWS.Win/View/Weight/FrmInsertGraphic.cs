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
using System.IO;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Win.Util;
using YF.Utility.Log;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.View.Weight
{
    public partial class FrmInsertGraphic : DevExpress.XtraEditors.XtraForm
    {
        private string currentFilePath;
        private IFileService fileService = new FileService();

        public string CurrentWeightId;
        public FrmInsertGraphic()
        {
            InitializeComponent();
        }

        private void btnItemBrowse_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ofdGraphic.ShowDialog() == DialogResult.OK) 
            {
                currentFilePath = ofdGraphic.FileName;
                peGraphic.Image = Image.FromFile(currentFilePath);
                btnItemSave.Enabled = true;
            }
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            Save();
        }

        private void Save() 
        {
            try
            {
                string fileName = "File\\Waybill\\" + YF.MWS.Util.Utility.GetGuid() + Path.GetExtension(currentFilePath);
                string fullPath = Path.Combine(Application.StartupPath, fileName);
                File.Copy(currentFilePath, fullPath, true);
                BFile file = new BFile();
                file.BusinessType = FileBusinessType.Waybill.ToString();
                file.FileExtension = Path.GetExtension(currentFilePath);
                file.Id = YF.MWS.Util.Utility.GetGuid();
                file.FileUrl = fileName;
                file.RecId = CurrentWeightId;
                file.TableName = "B_Weight";
                fileService.Add(file);
                btnItemSave.Enabled = false;
                MessageDxUtil.ShowTips("成功保存图片信息.");
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存图片信息时发生未知错误,请重试.");
            }
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmInsertGraphic_Load(object sender, EventArgs e)
        {

        }
    }
}