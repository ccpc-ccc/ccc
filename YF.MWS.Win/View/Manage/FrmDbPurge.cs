using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.MWS.BaseMetadata;
using YF.MWS.Win.View.User;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Manage
{
    public partial class FrmDbPurge : DevExpress.XtraEditors.XtraForm
    {
        private IMasterService masterService = new MasterService();
        private IClientService clientService = new ClientService();
        private int year = DateTime.Now.Year;

        public FrmDbPurge()
        {
            InitializeComponent();
        }

        private void tackBarYear_EditValueChanged(object sender, EventArgs e)
        {
            teStoreYear.Text = tackBarYear.Value.ToString();
            year = DateTime.Now.Year - tackBarYear.Value;
        }

        private void btnItemPurge_ItemClick(object sender, ItemClickEventArgs e)
        {
            string message = string.Format("确实要清除{0}年(包含{0}年)以前的历史业务数据吗?\n该操作不可撤销,请慎重.", year);
            if (year == DateTime.Now.Year)
                message = "确实要清除所有的历史业务数据吗?\n该操作不可撤销,请慎重.";
            if (MessageDxUtil.ShowYesNoAndTips(message) == DialogResult.Yes)
            {
                if (MessageDxUtil.ShowYesNoAndTips(message) == DialogResult.Yes)
                {
                    bool isPurged = masterService.DataPurge(year);
                    if (isPurged)
                    {
                        message = string.Format("已经成功清除{0}年(包含{0}年)以前的历史业务数据.", year);
                        if (year == DateTime.Now.Year)
                            message = "已经成功清除所有的历史业务数据.";
                    }
                    else
                    {
                        message = string.Format("清除{0}年(包含{0}年)以前的历史业务数据时发生未知错误,请重试.", year);
                        if (year == DateTime.Now.Year)
                            message = string.Format("清除所有的历史业务数据时发生未知错误,请重试.", year);
                    }
                    MessageDxUtil.ShowTips(message);
                }
            }
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmDbPurge_Load(object sender, EventArgs e)
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                barItemCompress.Visibility = BarItemVisibility.Always;
            }
            else
            {
                barItemCompress.Visibility = BarItemVisibility.Never;
            }
        }

        private void barItemCompress_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool isCompressed = false;
            using (Utility.GetWaitForm("正在压缩数据库,请稍后..."))
            {
                isCompressed = masterService.Compress();
            }
            if (isCompressed)
            {
                MessageDxUtil.ShowTips("成功压缩数据库.");
            }
            else
            {
                MessageDxUtil.ShowError("压缩数据库发生未知错误,请重试.");
            }
        }

        private void barItemInitDb_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmAuth frmAuth = new FrmAuth())
            {
                if (frmAuth.ShowDialog() == DialogResult.OK)
                {
                    bool isSuccessed = false;
                    string message = "执行此操作会删除所有的历史数据,仅仅保留系统必要的基础数据.\n此操作不可撤销,请慎重.确实要这样操作吗?";
                    if (MessageDxUtil.ShowYesNoAndTips(message) == DialogResult.Yes)
                    {
                        using (Utility.GetWaitForm("正在初始化数据库,请稍后..."))
                        {
                            isSuccessed = masterService.InitDb();
                        }
                        if (isSuccessed)
                        {
                            MessageDxUtil.ShowTips("成功初始化数据库.");
                        }
                        else
                        {
                            MessageDxUtil.ShowError("初始化数据库时发生未知错误,请重试.");
                        }
                    }
                }
            }
        }

        private void barItemResetRegister_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmAuth frmAuth = new FrmAuth())
            {
                if (frmAuth.ShowDialog() == DialogResult.OK)
                {
                    string message = "确实要清空客户端注册信息吗?\n该操作不可撤销,请慎重.";
                    if (MessageDxUtil.ShowYesNoAndTips(message) == DialogResult.Yes)
                    {
                        bool isDeleted = clientService.Delete();
                        if (isDeleted)
                        {
                            MessageDxUtil.ShowTips("成功清空客户端注册信息,重启软件需要重新注册.");
                        }
                        else
                        {
                            MessageDxUtil.ShowError("清空客户端注册信息时发生未知错误,请重试.");
                        }
                    }
                }
            }

        }
    }
}