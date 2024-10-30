using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using YF.MWS.Db;
using YF.MWS.Metadata;
using System.Data;
using YF.Utility;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using System.Collections.Specialized;
using System.Drawing;
using DevExpress.XtraTreeList.Nodes;
using System.Windows.Forms;
using YF.Utility.Log;
using YF.Utility.IO;
using DevExpress.XtraPrinting;
using YF.Utility.Metadata;
using System.Reflection;
using System.ComponentModel;

namespace YF.MWS.Win
{
    public static class DxHelper
    {
        public static void OpenFile(string fileFilter,ButtonEdit btnFile)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                if (!string.IsNullOrEmpty(fileFilter))
                {
                    //openFile.Filter = "Excel 文件|*.xls";
                    openFile.Filter = fileFilter;
                }
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFile.FileName;
                    btnFile.Text = filePath;
                }
            }
        }

        public static void ExportXlsx(GridView gv) 
        {
            string columnName = "CheckMarkSelection";
            bool isExist = false;
            if (DxHelper.FindColumn(gv, columnName) != null)
            {
                isExist = true;
            }
            if (isExist)
            {
                gv.Columns[columnName].Visible = false;
            }
            gv.OptionsPrint.AutoWidth = false;
            using (SaveFileDialog sfdFileSave = new SaveFileDialog())
            {
                sfdFileSave.Filter = "Excel 文件|*.xlsx";
                if (sfdFileSave.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfdFileSave.FileName;
                    XlsxExportOptions options = new XlsxExportOptions();
                    options.TextExportMode = TextExportMode.Value;
                    gv.ExportToXlsx(filePath, options);
                }
            }
            if (isExist)
            {
                gv.Columns[columnName].Visible = true;
            }
        }

        public static void ExportXls(DataTable dt,string fileFilter)
        {
            using (SaveFileDialog sfdFileSave = new SaveFileDialog())
            {
                if (!string.IsNullOrEmpty(fileFilter))
                {
                    sfdFileSave.Filter = fileFilter;
                }
                if (sfdFileSave.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfdFileSave.FileName;
                    NPOIHelper.DataTableToExcel(dt, filePath, null);
                }
            }
        }

        public static string GetCode(ComboBoxEdit combo)
        {
            string code = string.Empty;
            if (combo.EditValue != null)
            {
                try
                {
                    ListItem item = combo.EditValue as ListItem;
                    if (item != null)
                    { 
                        code = item.Value; 
                    }
                    else
                    {
                        SCode c = combo.EditValue as SCode;
                        if (c != null)
                        {
                            code = c.ItemCode;
                        }
                    }
                }
                catch(Exception ex) 
                {
                    Logger.WriteException(ex);
                }
            }
            return code;
        }

        public static string GetText(ComboBoxEdit combo)
        {
            string value = string.Empty;
            if (combo.EditValue != null)
            {
                try
                {
                    ListItem c = combo.EditValue as ListItem;
                    if (c != null)
                        return c.Text;

                    var code = combo.EditValue as SCode;
                    if (code != null)
                    {
                        return code.ItemCode;
                    }
                    return combo.Text;
                }
                catch { }
            }
            return value;
        }

        public static int GetValue(ComboBoxEdit combo)
        {
            int value = 0;
            if (combo.EditValue != null)
            {
                try
                { 
                    var code = combo.EditValue as SCode;
                    if (code != null)
                    {
                        value= code.ItemValue.ToInt();
                    }
                }
                catch { }
            }
            return value;
        }

        public static int GetEnumValue(ComboBoxEdit combo)
        {
            int value = -1;
            if (combo.EditValue != null)
            {
                try
                {
                    var code = combo.EditValue as ListItem;
                    if (code != null)
                    {
                        value = code.Value.ToInt();
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteException(ex);
                }
            }
            return value;
        }
        public static string GetEnumCode(this ComboBoxEdit combo)
        {
            string value = null;
            if (combo.EditValue != null)
            {
                try
                {
                    var code = combo.EditValue as EnumItem;
                    if (code != null)
                    {
                        value = code.ItemCode;
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteException(ex);
                }
            }
            return value;
        }
        public static string GetStrValue(this ComboBoxEdit combo)
        {
            string value = string.Empty;
            try
            {
                ListItem c;
                if (combo.SelectedItem != null)
                {
                    c = combo.SelectedItem as ListItem;
                    if (c != null)
                        return c.Value;
                }
                c = combo.EditValue as ListItem;
                if (c != null)
                    return c.Value;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
            return value;
        }
        public static void SetSelectItemValue(this ComboBoxEdit combo, string value) {
            try {
                foreach(ListItem c in combo.Properties.Items) {
                    if (c.Value == value) {
                        combo.SelectedItem = c;
                        return;
                    }
                }
                combo.SelectedItem = null;
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }
        /// <summary>
        /// 枚举类型绑定到下拉列表
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="combo"></param>
        /// <param name="seletedValue"></param>
        public static void BindComboBoxEdit<T>(ComboBoxEdit combo, int seletedValue)
        {
            combo.Properties.Items.Clear();
            ComboBoxItemCollection coll = combo.Properties.Items;
            List<ListItem> lst = new List<ListItem>();
            //lst.Add(new ListItem() { Text="全部",Value=-1 });
            coll.BeginUpdate();
            ListItem selectedItem = null;
            List<EnumItem> items = Converter.ToEnumItemList<T>();
            if (items != null && items.Count > 0)
            {
                foreach (EnumItem item in items)
                {
                    lst.Add(new ListItem()
                    {
                        Text = item.ItemCaption,
                        Value = item.ItemValue.ToString()
                    });
                    if (item.ItemValue == seletedValue)
                    {
                        selectedItem = new ListItem()
                        {
                            Text = item.ItemCaption,
                            Value = item.ItemValue.ToString()
                        };
                    }
                }
            }
            if (selectedItem != null)
            {
                combo.EditValue = selectedItem;
            }
            coll.AddRange(lst.ToArray());
            coll.EndUpdate();
        }
        public static void BindComboBoxEdit<T>(ComboBoxEdit combo, string seletedValue = "")
        {
            combo.Properties.Items.Clear();
            ComboBoxItemCollection coll = combo.Properties.Items;
            List<ListItem> lst = new List<ListItem>();
            //lst.Add(new ListItem() { Text="全部",Value=-1 });
            coll.BeginUpdate();
            ListItem selectedItem = null;
            List<EnumItem> items = Converter.ToEnumItemList<T>();
            if (items != null && items.Count > 0) {
                foreach (EnumItem item in items)
                {
                    lst.Add(new ListItem()
                    {
                        Text = item.ItemCaption,
                        Value = item.ItemCode
                    });
                    if (item.ItemCode == seletedValue)
                    {
                        selectedItem = new ListItem()
                        {
                            Text = item.ItemCaption,
                            Value = item.ItemCode
                        };
                    }
                }
            }
            if (selectedItem != null)
            {
                combo.EditValue = selectedItem;
            }
            coll.AddRange(lst.ToArray());
            coll.EndUpdate();
        }
        public static void BindComboBoxEdit(ComboBoxEdit combo, DataTable dt, string textField, string seletedValue)
        {
            combo.Properties.Items.Clear();
            ComboBoxItemCollection coll = combo.Properties.Items;
            List<ListItem> lst = new List<ListItem>();
            coll.BeginUpdate();
            ListItem selectedItem = null;
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new ListItem(dr[textField].ToObjectString(),dr["Id"].ToObjectString()));
                if (dr["Id"].ToObjectString() == seletedValue)
                {
                    selectedItem = new ListItem(dr[textField].ToObjectString(),dr["Id"].ToObjectString());
                }
            }
            if (selectedItem != null)
            {
                combo.EditValue = selectedItem;
            }
            coll.AddRange(lst.ToArray());
            coll.EndUpdate();
        }


        public static void BindComboBoxEdit(this ComboBoxEdit combo, List<ListItem> lst, string seletedValue = null)
        {
            combo.Properties.Items.Clear();
            ComboBoxItemCollection coll = combo.Properties.Items;
            coll.BeginUpdate();
            ListItem selectedItem = null;
            coll.AddRange(lst.ToArray());
            foreach (ListItem item in lst)
            {
                if (!string.IsNullOrEmpty(seletedValue) && item.Value == seletedValue)
                {
                    selectedItem = item;
                }
            }
            if (selectedItem != null)
            {
                combo.SelectedItem = selectedItem;
            }
            coll.EndUpdate();
        }


        #region GridControl

        public static GridColumn FindColumn(GridView gv, string fieldName)
        {
            GridColumn col = null;
            foreach (GridColumn gc in gv.Columns)
            {
                if (!string.IsNullOrEmpty(fieldName) && (gc.FieldName.ToUpper() == fieldName.ToUpper() || gc.Caption.ToUpper() == fieldName.ToUpper()))
                {
                    col = gc;
                    break;
                }
            }
            return col;
        }

        public static void CancelEdit(GridView gv)
        {
            if (gv.DataSource != null)
            {
                if (gv.DataSource is DataTable)
                {
                    DataTable dt = (DataTable)gv.DataSource;
                    dt.RejectChanges();
                }
            }
        }

        public static void CancelEdit(TreeList tl)
        {
            if (tl.DataSource != null)
            {
                if (tl.DataSource is DataTable)
                {
                    DataTable dt = (DataTable)tl.DataSource;
                    dt.RejectChanges();
                }
            }
        }

        #endregion


        public static void SetChildNode(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
            }
        }
        public static void SetParentNode(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool isCheck = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        isCheck = true;
                        break;
                    }
                }
                node.ParentNode.CheckState = isCheck ? CheckState.Indeterminate : check;
                if (node.ParentNode.ParentNode != null) 
                {
                    SetParentNode(node.ParentNode, check);
                }
            }
        }


        /// <summary>
        /// 得到TreeList的选中node
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public static List<TreeListNode> GetTreeCheckedNodes(TreeListNodes nodes)
        {
            var checkedNodes = new List<TreeListNode>();
            GetTreeListCheckedNodes(checkedNodes, nodes);
            return checkedNodes;
        }
        /// <summary>
        /// 得到TreeList的选中node
        /// </summary>
        /// <param name="list"></param>
        /// <param name="nodes"></param>
        private static void GetTreeListCheckedNodes(List<TreeListNode> list, TreeListNodes nodes)
        {
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in nodes)
            {
                if (node.CheckState == CheckState.Checked || node.CheckState == CheckState.Indeterminate)
                {
                    list.Add(node);
                    GetTreeListCheckedNodes(list, node.Nodes);
                }
            }
        }

        public static void SetItemGridLookUpEditByEmpty(RepositoryItemGridLookUpEdit itemLook)
        {
            itemLook.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            itemLook.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
              
                   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete){
                    Tag="Delete"
                   }

            });
            itemLook.ButtonClick += delegate(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
            {
                var look = sender as DevExpress.XtraEditors.GridLookUpEdit;
                if (look != null && !look.Properties.ReadOnly)
                {
                    string tag = e.Button.Tag as string;
                    if (!String.IsNullOrEmpty(tag) && tag == "Delete")
                    {
                        look.EditValue = null;
                    }
                }
            };
        }

        public static void SetItemComboBoxByEmpty(RepositoryItemComboBox itemLook)
        {
            itemLook.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            itemLook.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
              
                   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete){
                    Tag="Delete"
                   }

            });
            itemLook.ButtonClick += delegate(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
            {
                var look = sender as DevExpress.XtraEditors.ComboBoxEdit;
                if (look != null && !look.Properties.ReadOnly)
                {
                    string tag = e.Button.Tag as string;
                    if (!String.IsNullOrEmpty(tag) && tag == "Delete")
                    {
                        look.EditValue = null;
                    }
                }
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmbName"></param>
        /// <param name="dt"></param>
        /// <param name="ValueMember"></param>
        /// <param name="DisplayMember"></param>
        /// <returns></returns>
        public static RepositoryItemComboBox SetItemComboBox(string cmbName, List<SCode> lst)
        {
            RepositoryItemImageComboBox itemCMB = new RepositoryItemImageComboBox();
            itemCMB.AutoHeight = false;
            if (lst.Count > 0)
            {
                foreach (SCode c in lst)
                {
                    ImageComboBoxItem imageComboBoxItem1 = new ImageComboBoxItem(c.ItemCaption, c.ItemCode);
                    itemCMB.Items.Add(imageComboBoxItem1);
                }
            }
            itemCMB.Name = cmbName;
            SetItemComboBoxByEmpty(itemCMB);
            return itemCMB;
        }

        public static RepositoryItemGridLookUpEdit SetItemGridLookUpEdit(string itemLookName, object dataSource, string valueMember, string displayMember)
        {
            var itemLook = new RepositoryItemGridLookUpEdit();
            itemLook.Name = itemLookName;
            itemLook.DataSource = dataSource;
            itemLook.ValueMember = valueMember;
            itemLook.DisplayMember = displayMember;
            itemLook.NullText = "";

            itemLook.AutoComplete = true;
            itemLook.View.OptionsView.ColumnAutoWidth = true;
            itemLook.View.OptionsView.ShowGroupPanel = false;
            itemLook.View.OptionsView.ShowAutoFilterRow = true;
            itemLook.View.BestFitColumns();
            itemLook.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            itemLook.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            itemLook.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            SetItemGridLookUpEditByEmpty(itemLook);
            return itemLook;
        }

        #region gridLookEdit
        public static void SetGridLookUpEditByEmpty(DevExpress.XtraEditors.GridLookUpEdit look)
        {
            if (look.Properties.Buttons.Count > 1)
            {
                look.Properties.Buttons.RemoveAt(1);
            }
            look.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
              
                   new DevExpress.XtraEditors.Controls.EditorButton( DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                   {
                    Tag="Delete"
                   }
            });
            look.ButtonClick += delegate(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
            {
                var edit = sender as DevExpress.XtraEditors.GridLookUpEdit;
                if (edit != null && !edit.Properties.ReadOnly)
                {
                    string tag = e.Button.Tag as string;
                    if (!String.IsNullOrEmpty(tag) && tag == "Delete")
                    {
                        edit.EditValue = null;
                    }
                }
            };
        }
        /// <summary>
        /// 老方法请直接使用BindGridLookUpEdit
        /// </summary>
        /// <param name="look"></param>
        /// <param name="dt"></param>
        /// <param name="valueMember"></param>
        /// <param name="displayMember"></param>
        public static void BindGridLookUpEditByEmpty(DevExpress.XtraEditors.GridLookUpEdit look, DataTable dt, string valueMember, string displayMember)
        {
            BindGridLookUpEdit(look, dt, valueMember, displayMember);
        }
        public static void BindGridLookUpEdit(DevExpress.XtraEditors.GridLookUpEdit look, DataTable dt, string valueMember, string displayMember)
        {

            look.Properties.DataSource = dt;
            look.Properties.ValueMember = valueMember;
            look.Properties.DisplayMember = displayMember;
            look.Properties.NullText = "";
            look.Properties.View.OptionsView.ColumnAutoWidth = true;
            look.Properties.View.OptionsView.ShowGroupPanel = false;
            look.Properties.View.OptionsView.ShowAutoFilterRow = true;
            look.Properties.View.BestFitColumns();
            look.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            // look.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            SetGridLookUpEditByEmpty(look);
        }
        #endregion



    }
}
