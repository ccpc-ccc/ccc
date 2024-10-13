using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Metadata.UI;
using System.IO;
using DevExpress.XtraEditors.Repository;
using System.Threading;

namespace YF.MWS.Win.View.Home
{
    public partial class FrmHelp : DevExpress.XtraEditors.XtraForm
    {
        public FrmHelp()
        {
            InitializeComponent();
        }

        private void linkOpenFile_Click(object sender, System.EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(OpenFile), null);
        }

        private void FrmHelp_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            string reportFilePath = Path.Combine(Application.StartupPath, @"File\Help");
            List<FileItem> lstFile = Utility.GetFileList(reportFilePath);
            gcReport.DataSource = lstFile;
        }

        private void OpenFile(object obj)
        {
            if (gvReport.GetFocusedRow() != null)
            {
                FileItem item = (FileItem)gvReport.GetFocusedRow();
                Utility.Start(item.FullPath);
            }
        }
    }
}