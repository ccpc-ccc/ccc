using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using YF.MWS.Metadata.UI;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using YF.MWS.Metadata;
using System.Data;
using YF.Utility;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;
using YF.Utility.Log;
using YF.Utility.IO;
using DevExpress.XtraPrinting;
using YF.Utility.Metadata;
using System.Reflection;
using System.ComponentModel;

namespace test {
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
        /// 计算CRC校验码
        /// </summary>
        /// <param name="message">要计算的二进制数组</param>
        /// <param name="CRC">CRC校验码</param>
        public static byte[] GetCRC(byte[] byteData) {
            ushort CRCFull = 0xFFFF;
            byte CRCHigh = 0xFF, CRCLow = 0xFF;
            char CRCLSB;
            byte[] CRC = new byte[2];
            for (int i = 0; i < byteData.Length; i++) {
                CRCFull = (ushort)(CRCFull ^ byteData[i]);
                for (int j = 0; j < 8; j++) {
                    CRCLSB = (char)(CRCFull & 0x0001);
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

                    if (CRCLSB == 1)
                        CRCFull = (ushort)(CRCFull ^ 0xA001);
                }
            }
            CRC[1] = CRCHigh = (byte)((CRCFull >> 8) & 0xFF);
            CRC[0] = CRCLow = (byte)(CRCFull & 0xFF);
            return CRC;
        }



    }
}
