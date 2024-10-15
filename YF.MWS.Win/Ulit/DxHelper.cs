using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using YF.MWS.Metadata.UI;
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
using YF.MWS.CacheService;
using YF.Utility.Log;
using YF.Utility.IO;
using DevExpress.XtraPrinting;
using YF.Utility.Metadata;

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
        public static void SetSelectItemValue(ComboBoxEdit combo, string value) {
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
        public static void BindComboBoxEdit<T>(ComboBoxEdit combo, int seletedValue = -1)
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

        public static void BindComboBoxEdit(ComboBoxEdit combo, SysCode code, object selectedValue)
        {
            combo.Properties.Items.Clear();
            List<SCode> lst = MasterCacher.GetSubCodeList(code.ToString());
            ComboBoxItemCollection coll = combo.Properties.Items;
            coll.BeginUpdate();
            SCode selectedCode = null;
            foreach (SCode c in lst)
            {
                coll.Add(c);
                if (selectedValue != null && c.ItemCode == selectedValue.ToString())
                {
                    selectedCode = c;
                }
            }
            coll.EndUpdate();
            combo.SelectedIndex = -1;
            if (selectedCode != null)
            {
                combo.EditValue = selectedCode;
            }
        }
        public static void BindComboBoxEdit<T>(ComboBoxEdit combo,object selectedValue)where T:Enum {
            SCode selectedCode = null;
            ComboBoxItemCollection coll = combo.Properties.Items;
            coll.BeginUpdate();
            foreach (int eemun in Enum.GetValues(typeof(T))) {
                string sName = Enum.GetName(typeof(T), eemun);//获取名称
                coll.Add(new ListItem() {
                    Text = sName,
                    Value=eemun.ToString()
                });
            }
            coll.EndUpdate();
            combo.SelectedIndex = -1;
            if (selectedCode != null) {
                combo.EditValue = selectedCode;
            }
        }
        public static void BindComboBoxEdit(ComboBoxEdit combo, string code, object selectedValue)
        {
            combo.Properties.Items.Clear();
            List<SCode> lst = MasterCacher.GetSubCodeList(code);
            ComboBoxItemCollection coll = combo.Properties.Items;
            coll.BeginUpdate();
            SCode selectedCode = null;
            foreach (SCode c in lst)
            {
                coll.Add(c);
                if (selectedValue != null && c.ItemCode == selectedValue.ToString())
                {
                    selectedCode = c;
                }
            }
            coll.EndUpdate();
            combo.SelectedIndex = -1;
            if (selectedCode != null)
            {
                combo.EditValue = selectedCode;
            }
            //foreach (SCode c in lst) {
            //    combo.Properties.Items.Add(new ImageComboBoxItem(c.ItemCaption, c.ItemCode));
            //}

            //ImageComboBoxItem
        }


        #region GridControl
        public static bool ContainsField(GridView gv,string fieldName) 
        {
            bool contains = false;
            foreach (GridColumn gc in gv.Columns) 
            {
                if (!string.IsNullOrEmpty(fieldName) && (gc.FieldName.ToUpper() == fieldName.ToUpper() || gc.Caption.ToUpper()==fieldName.ToUpper())) 
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }

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

        public static void CommitRow(GridView gv)
        {
            if (gv == null)
            {
                return;
            }
            gv.CloseEditor();
            gv.UpdateCurrentRow();
        }

        public static void SetGridColumn(GridColumnCollection Columns, List<SWeightViewDtl> lstViewDtl) 
        {
            lstViewDtl = lstViewDtl.FindAll(c => c.ControlType != null && c.ControlType == ControlType.Standard.ToString());
            try
            {
                List<ColumnFilter> verifyGuidViewNumberLength = new List<ColumnFilter>();
                foreach (GridColumn col in Columns)
                {
                    if (col.FieldName != "CheckMarkSelection")
                    {
                        SWeightViewDtl cp = lstViewDtl.Find(c => c.FieldName == col.FieldName);
                        if (cp == null)
                        {
                            //col.Visible = false; 
                        }
                        else 
                        {
                            col.Caption = cp.ControlName;
                            if (!string.IsNullOrEmpty(cp.FullName) && cp.FullName.EndsWith("WNumbericEdit")) 
                            {
                                //col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                                 col.DisplayFormat.FormatString = string.Format("N{0}", cp.DecimalDigits);  
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 设置Grid Column Properties 
        /// </summary>
        /// <param name="Columns"></param>
        /// <param name="gcp"></param>
        /// <param name="Language">多语言</param>
        public static void SetGridColumn(GridColumnCollection Columns, List<ColumnProperty> gcp, NameValueCollection Language)
        {
            try
            {
                List<ColumnFilter> verifyGuidViewNumberLength = new List<ColumnFilter>();
                foreach (GridColumn col in Columns)
                {
                    if (col.FieldName != "CheckMarkSelection")
                    {
                        ColumnProperty cp = gcp.Find(c => c.FieldName == col.FieldName);
                        if (cp == null)
                            col.Visible = false;
                    }
                }
                foreach (var p in gcp)
                {
                    if (Columns[p.FieldName] == null)
                        continue;

                    if (!string.IsNullOrEmpty(p.CaptionLang))
                    {
                        Columns[p.FieldName].Caption = p.CaptionLang;
                        p.Caption = p.CaptionLang;
                    }
                    else if (Language != null)
                    {
                        //by xie fuhong on 2012/10/04
                        if (!string.IsNullOrEmpty(p.LanguageKeyName))
                        {
                            Columns[p.FieldName].Caption = Language[p.LanguageKeyName];
                            p.Caption = Language[p.LanguageKeyName];
                        }
                        else
                        {
                            Columns[p.FieldName].Caption = Language[p.FieldName];
                            p.Caption = Language[p.FieldName];
                        }
                    }
                    else if (p.Caption != null)
                    {
                        Columns[p.FieldName].Caption = p.Caption;
                    }
                    if (!string.IsNullOrEmpty(p.ColumnEditName))
                        Columns[p.FieldName].ColumnEditName = p.ColumnEditName;
                    p.SetLength(Columns);
                    if (Columns[p.FieldName] == null) continue;
                    //设置字段是否可读
                    Columns[p.FieldName].OptionsColumn.ReadOnly = p.ReadOnly;

                    //设置是否接受Tab键
                    // Columns[p.FieldName].OptionsColumn.TabStop = !p.ReadOnly;

                    Columns[p.FieldName].Visible = p.Visible;
                    if (p.FormatType != DevExpress.Utils.FormatType.None)
                    {
                        Columns[p.FieldName].DisplayFormat.FormatType = p.FormatType;
                        Columns[p.FieldName].DisplayFormat.FormatString = p.FormatString;
                    }


                    //by xie fuhong on 2012/09/19
                    //设置必填列的颜色
                    //if (p.NotNull)
                    //{
                    //    Columns[p.FieldName].AppearanceHeader.ForeColor = Color.Red;
                    //}
                    //else
                    //{
                    //    Columns[p.FieldName].AppearanceHeader.ForeColor = Color.Black;
                    //}
                    if (p.IsShowFontBold)
                    {
                        Font f = Columns[p.FieldName].AppearanceHeader.Font;
                        Columns[p.FieldName].AppearanceHeader.Font = new Font(f, FontStyle.Bold);
                    }

                    //by xie fuhong on 2012/09/19
                    if (!p.AllowMove)
                    {
                        Columns[p.FieldName].OptionsColumn.AllowMove = false;
                    }

                    //by xie fuhong on 2012/09/19
                    if (p.IsNotAllowMoveToCustomizationForm)
                    {
                        Columns[p.FieldName].OptionsColumn.AllowShowHide = false;
                    }

                    //by xie fuhong on 2012/09/19
                    if (p.IsNotShowInCustomizationForm)
                    {
                        Columns[p.FieldName].OptionsColumn.AllowShowHide = false;
                    }

                    //by xie fuhong on 2012/10/04
                    if (p.IsAllowBestFitWidth)
                    {
                        Columns[p.FieldName].BestFit();
                    }

                    //设置数字类型的长度
                    if (p.VerifyNumberLength != null)
                    {
                        ColumnFilter verifyNumber = new ColumnFilter()
                        {
                            Column = p.FieldName,
                            DecimalLength = p.VerifyNumberLength.DecimalLength,
                            Length = p.VerifyNumberLength.Length
                        };
                        verifyGuidViewNumberLength.Add(verifyNumber);
                    }
                    //设置停靠列

                    Columns[p.FieldName].Fixed = p.FixedStyle;
                }
                // var view = Columns.View as DevExpress.XtraGrid.Views.Grid.GridView;
                //设置数字类型的长度
                // if (verifyGuidViewNumberLength != null && verifyGuidViewNumberLength.Count > 0)
                //     verify.VerifyGridDigitColumnsLength(view, verifyGuidViewNumberLength);

                //view.RowCellStyle += (object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e) =>
                //{
                //    if (e.RowHandle >= 0)
                //    {
                //        var FieldName = from p in gcp where e.Column.FieldName == p.FieldName && p.NotNull == true select p.FieldName;
                //        if (FieldName.Count() > 0)
                //        {
                //            e.Appearance.BackColor = Color.DeepSkyBlue;
                //            e.Appearance.BackColor2 = Color.LightCyan;
                //        }
                //    }
                //};              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 设置gird样式
        /// </summary>
        /// <param name="gv"></param>
        public static void SetGridView(GridView gv)
        {
            gv.OptionsView.ColumnAutoWidth = false;
            gv.OptionsView.ShowGroupPanel = false;
            gv.OptionsView.ShowAutoFilterRow = false;
            gv.BestFitColumns();
            // gv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;

            gv.IndicatorWidth = 35;
            gv.BestFitColumns();
            gv.CustomDrawRowIndicator += gv_CustomDrawRowIndicator;
            gv.GridControl.UseEmbeddedNavigator = true;
            gv.GridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            gv.GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            gv.GridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            gv.GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            gv.GridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gv.ColumnChanged += new EventHandler(gv_ColumnChanged);

        }

        public static void SetGridColumnStyle(GridView gv) 
        {
            for (int i = 0; i < gv.Columns.Count; i++) 
            {
                if (gv.Columns[i].ColumnType.Name == "DateTime") 
                {
                    gv.Columns[i].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                    gv.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                }
            }
            gv.RefreshData();
        }

        static void gv_ColumnChanged(object sender, EventArgs e)
        {
            var s = sender as DevExpress.XtraGrid.Columns.GridColumn;
            if (s != null && !s.ReadOnly != s.OptionsColumn.TabStop)
            {
                s.OptionsColumn.TabStop = !s.ReadOnly;
            }
        }
        static void gv_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
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

        public static void CommitRow(TreeList tl)
        {
            tl.PostEditor();
            tl.CloseEditor();
            tl.EndCurrentEdit();
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

        public static void SetTreeListColumn(DevExpress.XtraTreeList.Columns.TreeListColumnCollection Columns, List<ColumnProperty> cp, NameValueCollection Language)
        {
            try
            {
                //Verify verify = new Verify();
                List<ColumnFilter> verifyGuidViewNumberLength = new List<ColumnFilter>();
                foreach (var p in cp)
                {
                    if (Columns[p.FieldName] == null)
                        continue;

                    if (!string.IsNullOrEmpty(p.Caption))
                        Columns[p.FieldName].Caption = p.Caption;
                    else
                    {
                        if (Language != null)
                        {
                            //by xie fuhong on 2012/10/04
                            if (!string.IsNullOrEmpty(p.LanguageKeyName))
                            {
                                Columns[p.FieldName].Caption = Language[p.LanguageKeyName];
                                p.Caption = Language[p.LanguageKeyName];
                            }
                            else
                            {
                                Columns[p.FieldName].Caption = Language[p.FieldName];
                                p.Caption = Language[p.FieldName];
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(p.ColumnEditName))
                        Columns[p.FieldName].ColumnEditName = p.ColumnEditName;
                    p.SetLength(Columns);
                    if (Columns[p.FieldName] == null) continue;
                    //设置字段是否可读
                    Columns[p.FieldName].OptionsColumn.ReadOnly = p.ReadOnly;
                    Columns[p.FieldName].Visible = p.Visible;
                    //if (p.FormatType != DevExpress.Utils.FormatType.None)
                    //{
                    //    Columns[p.FieldName].DisplayFormat.FormatType = p.FormatType;
                    //    Columns[p.FieldName].DisplayFormat.FormatString = p.FormatString;
                    //}

                    //by xie fuhong on 2012/09/19
                    if (p.IsShowFontBold)
                    {
                        Font f = Columns[p.FieldName].AppearanceHeader.Font;
                        Columns[p.FieldName].AppearanceHeader.Font = new Font(f, FontStyle.Bold);
                    }

                    //by xie fuhong on 2012/09/19
                    if (!p.AllowMove)
                    {
                        Columns[p.FieldName].OptionsColumn.AllowMove = false;
                    }

                    //by xie fuhong on 2012/10/04
                    if (p.IsNotAllowMoveToCustomizationForm)
                    {
                        Columns[p.FieldName].OptionsColumn.AllowMoveToCustomizationForm = false;
                    }

                    //by xie fuhong on 2012/10/04
                    if (p.IsNotShowInCustomizationForm)
                    {
                        Columns[p.FieldName].OptionsColumn.ShowInCustomizationForm = false;
                    }

                    //by xie fuhong on 2012/10/04
                    if (p.IsAllowBestFitWidth)
                    {
                        Columns[p.FieldName].BestFit();
                    }

                    //设置数字类型的长度
                    if (p.VerifyNumberLength != null)
                    {
                        ColumnFilter verifyNumber = new ColumnFilter()
                        {
                            Column = p.FieldName,
                            DecimalLength = p.VerifyNumberLength.DecimalLength,
                            Length = p.VerifyNumberLength.Length
                        };
                        verifyGuidViewNumberLength.Add(verifyNumber);
                    }
                    //设置停靠列
                    Columns[p.FieldName].Fixed = p.TreeFixedStyle;
                }
                //var view = Columns.TreeList as DevExpress.XtraGrid.Views.Grid.GridView;
                ////设置数字类型的长度
                //if (verifyGuidViewNumberLength != null && verifyGuidViewNumberLength.Count > 0)
                //    verify.VerifyGridDigitColumnsLength(view, verifyGuidViewNumberLength);

                //view.RowCellStyle += (object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e) =>
                //{
                //    if (e.RowHandle >= 0)
                //    {
                //        var FieldName = from p in gcp where e.Column.FieldName == p.FieldName && p.NotNull == true select p.FieldName;
                //        if (FieldName.Count() > 0)
                //        {
                //            e.Appearance.BackColor = Color.DeepSkyBlue;
                //            e.Appearance.BackColor2 = Color.LightCyan;
                //        }
                //    }
                //};              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
        public static void BindGridLookUpEdit(GridLookUpEdit look, object obj, string valueMember, string displayMember, List<ColumnProperty> lstColumn)
        {

            look.Properties.DataSource = obj;
            look.Properties.ValueMember = valueMember;
            look.Properties.DisplayMember = displayMember;
            look.Properties.View.Columns.Clear();
            foreach (ColumnProperty cp in lstColumn)
            {
                look.Properties.View.Columns.Add(new GridColumn() { Caption = cp.Caption, FieldName = cp.FieldName });
            }
            for (int i = 0; i < look.Properties.View.Columns.Count; i++)
            {
                look.Properties.View.Columns[i].Visible = true;
            }
            look.Properties.NullText = "";
            look.Properties.View.OptionsView.ColumnAutoWidth = true;
            look.Properties.View.OptionsView.ShowGroupPanel = false;
            look.Properties.View.OptionsView.ShowAutoFilterRow = true;
            look.Properties.View.BestFitColumns();
            look.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            SetGridLookUpEditByEmpty(look);
        }

        public static void BindSearchLookUpEdit(SearchLookUpEdit look, object obj, string valueMember, string displayMember, List<ColumnProperty> lstColumn)
        {
            look.Properties.DataSource = obj;
            look.Properties.ValueMember = valueMember;
            look.Properties.DisplayMember = displayMember;
            look.Properties.View.Columns.Clear();
            foreach (ColumnProperty cp in lstColumn)
            {
                look.Properties.View.Columns.Add(new GridColumn() { Caption = cp.Caption, FieldName = cp.FieldName });
            }
            for (int i = 0; i < look.Properties.View.Columns.Count; i++)
            {
                look.Properties.View.Columns[i].Visible = true;
            }
            look.Properties.NullText = "";
            look.Properties.View.OptionsView.ColumnAutoWidth = true;
            look.Properties.View.OptionsView.ShowGroupPanel = false;
            look.Properties.View.OptionsView.ShowAutoFilterRow = true;
            look.Properties.View.BestFitColumns();
            look.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            // SetGridLookUpEditByEmpty(look);
        }
        #endregion



    }
}
