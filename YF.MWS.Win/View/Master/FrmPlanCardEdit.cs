using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Dto;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.BaseMetadata;
using YF.MWS.CacheService;
using System.Threading;
using YF.MWS.Metadata.Cfg;
using System.IO.Ports;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmPlanCardEdit : BaseForm
    {
        private WriteCardCfg writeCard;
        private bool isVirtualCard = false;
        /// <summary>
        /// 虚拟卡
        /// </summary>
        public bool IsVirtualCard
        {
            get { return isVirtualCard; }
            set { isVirtualCard = value; }
        }

        public FrmPlanCardEdit()
        {
            InitializeComponent();
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool isSaved=ucCardEdit.Save();
            if(isSaved)
               DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucCardEdit.ClosePort();
            barItemOpen.Enabled = true;
            btnItemSave.Enabled = false;
            barItemSaveAndNew.Enabled = false;
            btnItemClose.Enabled = false;
        }

        private void FrmCardEdit_Load(object sender, EventArgs e)
        {
            if (isVirtualCard) 
            {
                barItemComShort.Visibility = BarItemVisibility.Never;
                barItemOpen.Visibility = BarItemVisibility.Never;
                btnItemClose.Visibility = BarItemVisibility.Never;
                barItemSaveAndNew.Enabled = true;
                btnItemSave.Enabled = true;
            }
            if (Cfg != null)
            {
                if (Cfg.WriteCard != null)
                {
                    writeCard = Cfg.WriteCard;
                }
            }
            ucCardEdit.IsVirtualCard = IsVirtualCard;
            combComShort.Items.Add("COM1");
            foreach (string item in SerialPort.GetPortNames())
            {
                combComShort.Items.Add(item);
            }
            if (!string.IsNullOrEmpty(RecId))
            {
                ucCardEdit.LoadCard(RecId);
                barItemSaveAndNew.Visibility = BarItemVisibility.Never;
                btnItemSave.Visibility = BarItemVisibility.Never;
                btnItemClose.Visibility = BarItemVisibility.Never;
                barItemOpen.Visibility = BarItemVisibility.Never;
                barItemComShort.Visibility = BarItemVisibility.Never;
            }
            else
            {
                barItemOnlySave.Visibility = BarItemVisibility.Never;
                if (!IsVirtualCard)
                {
                    barItemSaveAndNew.Enabled = false;
                    btnItemSave.Enabled = false;
                    btnItemClose.Enabled = false;
                }
            }
            if (writeCard != null && !string.IsNullOrEmpty(writeCard.PortName)&&!isVirtualCard)
            {
                barItemComShort.EditValue = writeCard.PortName;
                barItemOpen.PerformClick();
            }
        }

        private void barItemOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (barItemComShort.EditValue == null) 
            {
                MessageDxUtil.ShowWarning("请选择串口号");
                return;
            }
            string portName = barItemComShort.EditValue.ToObjectString();
            if (writeCard != null) 
            {
                int port = int.Parse(portName.Substring(3, portName.Length - 3)) - 1;
                bool isOpen = ucCardEdit.OpenPort();
                if (isOpen)
                {
                    barItemSaveAndNew.Enabled = true;
                    btnItemSave.Enabled = true;
                    btnItemClose.Enabled = true;
                    barItemOpen.Enabled = false;
                }
            }
        }

        private void FrmPlanCardEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucCardEdit.ClosePort();
        }

        private void barItemSaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucCardEdit.Save();
        }

        private void barItemOnlySave_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool isSaved=ucCardEdit.Save();
            if(isSaved)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        
    } 
}