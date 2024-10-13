using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.CacheService;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmCodeList : DevExpress.XtraEditors.XtraForm
    {
        private IMasterService masterService = new MasterService();
        public FrmCodeList()
        { 
            InitializeComponent(); 
        }

        private void FrmCodeList_Load(object sender, EventArgs e)
        {
            using (Utility.GetWaitForm(this))
            {
                 BindData();
            }
        }

        private void BindData() {
            string parentNo = txtParentNo.Text;
            var lstCode = masterService.GetList(parentNo);
            tlCode.DataSource = lstCode;
            tlCode.ExpandAll();
        }

        private void btnItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmCodeEdit frmEdit = new FrmCodeEdit())
            {
                frmEdit.SystemFlag = 1;
                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void btnItemAddSub_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmCodeEdit frmEdit = new FrmCodeEdit())
            {
                frmEdit.SystemFlag = 1;
                if (tlCode.FocusedNode != null)
                {
                    frmEdit.ParentId = tlCode.FocusedNode["CodeId"].ToString();
                    frmEdit.ParentItemCaption = tlCode.FocusedNode["ItemCaption"].ToObjectString();
                }
                if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void btnItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmCodeEdit frmEdit = new FrmCodeEdit())
            {
                frmEdit.SystemFlag = 1;
                if (tlCode.FocusedNode != null)
                {
                    frmEdit.CodeId = tlCode.FocusedNode["CodeId"].ToString();
                }
                if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void btnItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string message = "确实要删除此编码信息吗?此操作不可撤销,请慎重.";
            if (MessageDxUtil.ShowYesNoAndTips(message) == System.Windows.Forms.DialogResult.Yes)
            {
                if (tlCode.FocusedNode != null)
                {
                    string codeId = tlCode.FocusedNode["CodeId"].ToString();
                    List<SCode> subCodes=masterService.GetSubList(tlCode.FocusedNode["ItemCode"].ToObjectString());
                    if (subCodes != null && subCodes.Count > 0) 
                    {
                        MessageDxUtil.ShowWarning("此编码信息含有子级编码项,不能被删除,请先删除子项.");
                        return;
                    }
                    if (masterService.DeleteCode(codeId))
                    {
                        MessageDxUtil.ShowTips("删除系统编码信息成功.");
                        BindData();
                    }
                    else
                    {
                        MessageDxUtil.ShowTips("删除系统编码信息失败.");
                    }
                }
            }
        }

        private void btnItemRefreh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BindData();
        }

        private void barItemExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var codes = masterService.GetList();
            if (codes == null || codes.Count == 0)
            {
                MessageDxUtil.ShowWarning("暂无数据字典可以导出");
                return;
            }
            using (SaveFileDialog sfdFileSave = new SaveFileDialog())
            {
                sfdFileSave.Filter = "Xml 文件|*.xml";
                sfdFileSave.FileName = "数据字典.xml";
                if (sfdFileSave.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfdFileSave.FileName;
                    XmlUtil.Serialize<List<SCode>>(codes, filePath);
                    MessageDxUtil.ShowTips("成功导出数据字典");
                }
            }
        }

        private void barItemImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Xml 文件|*.xml";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFile.FileName;
                    List<SCode> codes = XmlUtil.Deserialize<List<SCode>>(filePath);
                    if (codes == null || codes.Count == 0)
                    {
                        MessageDxUtil.ShowWarning("文件选择错误,请重新选择");
                        return;
                    }
                    masterService.ImportCode(codes);
                    MasterCacher.Refresh();
                    MessageDxUtil.ShowTips("成功导入数据字典");
                    BindData();
                }
            }
        }

    }
}