using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Win.Uc;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmClientEdit : BaseForm
    {
        private IClientService clientService = new ClientService();

        public FrmClientEdit()
        {
            InitializeComponent();
        }

        private void FrmClientEdit_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(RecId)) 
            {
                SClient client = clientService.GetById(RecId);
                if (client != null) 
                {
                    teClientName.Text = client.ClientName;
                    teMachineCode.Text = client.MachineCode;
                }
            }
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (teClientName.Text.Length == 0) 
            {
                teClientName.ErrorText = "请输入客户端名称";
                return;
            }
            bool isUpdated = clientService.UpdateClientName(RecId, teClientName.Text);
            if (isUpdated)
            {
                MessageDxUtil.ShowTips("成功修改客户端信息");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else 
            {
                MessageDxUtil.ShowError("修改客户端信息发生未知错误,请重试.");
            }
        }
    }
}