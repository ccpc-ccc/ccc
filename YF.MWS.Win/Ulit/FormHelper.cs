using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.XtraEditors;
using YF.Utility;
using YF.Utility.Metadata;
using YF.Utility.Log;
using YF.MWS.Win.Uc.Weight;

namespace YF.MWS.Win
{
    public class FormHelper
    {
        #region Private Methods
        private static string GetValue<T>(T t, List<PropertyInfo> lstProperty, string propertyName)
        {
            string val = string.Empty;
            PropertyInfo pi = null;
            object obj = null;
            pi = lstProperty.Find(p => p.Name == propertyName);
            if (pi != null)
            {
                obj = pi.GetValue(t, null);
                if (obj != null)
                {
                    val = obj.ToString();
                    if (pi.PropertyType.Name == "Guid")
                    {
                        if (new Guid(val) == Guid.Empty)
                        {
                            val = string.Empty;
                        }
                    }
                    if (pi.PropertyType.Name == "DateTime")
                    {
                        if (DateTime.Parse(val) == DateTime.MinValue)
                        {
                            val = string.Empty;
                        }
                        else
                        {
                            val = DateTime.Parse(val).ToLongDateString();
                        }
                    }
                }
            }
            return val;
        }

        private static void SetCheckEdit<T>(CheckEdit chk, T t, List<PropertyInfo> lstProperty) 
        {
            string val = GetValue<T>(t, lstProperty, chk.Tag.ToObjectString());
            bool isChecked=false;
            if (!string.IsNullOrEmpty(val) && val.ToLower() == "true") 
            {
                isChecked = true;
            }
            if (chk != null)
                chk.Checked = isChecked;
        }

        private static void SetTextEditValue<T>(TextEdit txt, T t, List<PropertyInfo> lstProperty)
        {
            string val = GetValue<T>(t, lstProperty, txt.Tag.ToObjectString());
            if (val != null && val.Length > 0)
                txt.Text = val;
        }


        private static void SetDateEditValue<T>(DateEdit de, T t, List<PropertyInfo> lstProperty)
        {
            string val = GetValue<T>(t, lstProperty, de.Tag.ToObjectString());
            if (val != null && val.Length > 0)
                de.EditValue = val;
        }//GridLookUpEdit
        private static void SetGridLookUpEditValue<T>(GridLookUpEdit look, T t, List<PropertyInfo> lstProperty)
        {
            string val = GetValue<T>(t, lstProperty, look.Tag.ToObjectString());
            if (val != null && val.Length > 0)
                look.EditValue = val;
        }

        private static void SetSearchLookUpEditValue<T>(SearchLookUpEdit look, T t, List<PropertyInfo> lstProperty)
        {
            string val = GetValue<T>(t, lstProperty, look.Tag.ToObjectString());
            if (val != null && val.Length > 0)
                look.EditValue = val;
        }
        private static void SetSearchComboxValue<T>(WComboBoxTextEdit look, T t, List<PropertyInfo> lstProperty) {
            string val = GetValue<T>(t, lstProperty, look.Tag.ToObjectString());
            if (val != null && val.Length > 0)
                look.CurrentValue = val;
        }
        private static void SetSearchCustomerEdit<T>(WCustomerEdit look, T t, List<PropertyInfo> lstProperty) {
            string val = GetValue<T>(t, lstProperty, look.Tag.ToObjectString());
            if (val != null && val.Length > 0)
                look.CurrentValue = val;
        }
        /// <summary>
        ///    val 为控件值  lstProperty  为 t 的所有属性列表  propertyName 为控件的tag值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <param name="lstProperty"></param>
        /// <param name="propertyName"></param>
        /// <param name="t"></param>
        private static void SetPropertyValue<T>(object val, List<PropertyInfo> lstProperty, string propertyName, ref T t)
        {
            PropertyInfo pi = null;
            object obj = null;
            pi = lstProperty.Find(p => p.Name == propertyName);//获取tag值为propertyName的属性
            if (pi != null)
            {
                try
                {
                    if (!pi.PropertyType.IsGenericType)
                    {
                        if (pi.PropertyType.Name == "Guid")
                        {
                            obj = new Guid(val.ToObjectString());
                            pi.SetValue(t, obj, null);
                        }
                        else if (pi.PropertyType.Name == "String")
                        {
                            obj = val;
                            pi.SetValue(t, obj, null);
                        }
                        else
                        {
                            if (val != null)
                            {
                                obj = Convert.ChangeType(val, pi.PropertyType);
                                pi.SetValue(t, obj, null);
                            }
                        }
                    }
                    else
                    {
                        Type tdef = pi.PropertyType.GetGenericTypeDefinition();
                        if (tdef == typeof(Nullable<>))
                        {
                            obj = Convert.ChangeType(val, Nullable.GetUnderlyingType(pi.PropertyType));
                            pi.SetValue(t, obj, null);
                        }
                    }
                }
                catch (Exception ex) 
                {
                    Logger.WriteException(ex);
                    if (obj != null) 
                    {
                        Logger.Write(string.Format("type:{0},value:{1},time:{2}",pi.PropertyType,obj.ToString(),DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    }
                }
            }
        }
        #endregion
        public static void BindControl<T>(Control control, T t)
        {
            Type type = typeof(T);
            List<PropertyInfo> lstProperty = type.GetProperties().ToList();
            if (control != null && control.HasChildren)
            {
                foreach (Control c in control.Controls)
                {
                    if (c.GetType().Name == "CheckEdit")
                    {
                        CheckEdit txt = (CheckEdit)c;
                        SetCheckEdit<T>(txt, t, lstProperty);
                    }
                    if (c.GetType().Name == "TextEdit")
                    {
                        TextEdit txt = (TextEdit)c;
                        SetTextEditValue<T>(txt, t, lstProperty);
                    }
                    if (c.GetType().Name == "MemoEdit")
                    {
                        MemoEdit txt = (MemoEdit)c;
                        SetTextEditValue<T>(txt, t, lstProperty);
                    }
                    if (c.GetType().Name == "DateEdit")
                    {
                        DateEdit de = (DateEdit)c;
                        SetDateEditValue<T>(de, t, lstProperty);
                    }
                    if (c.GetType().Name == "GridLookUpEdit")
                    {
                        GridLookUpEdit look = (GridLookUpEdit)c;
                        SetGridLookUpEditValue<T>(look, t, lstProperty);
                    }
                    if (c.GetType().Name == "SearchLookUpEdit")
                    {
                        SearchLookUpEdit look = (SearchLookUpEdit)c;
                        SetSearchLookUpEditValue<T>(look, t, lstProperty);
                    }
                    if (c.GetType().Name == "WComboBoxTextEdit") {
                        WComboBoxTextEdit look = (WComboBoxTextEdit)c;
                        SetSearchComboxValue<T>(look,t,lstProperty);
                    }
                    if (c.GetType().Name == "WCustomerEdit") {
                        WCustomerEdit look = (WCustomerEdit)c;
                        SetSearchCustomerEdit<T>(look,t,lstProperty);
                    }

                    if (c.HasChildren)
                    {
                        BindControl<T>(c, t);
                    }
                }
            }
        }

        public static void CleanControl(Control control)
        {
            if (control != null && control.HasChildren)
            {
                foreach (Control c in control.Controls)
                {
                    if (c.GetType().Name == "TextEdit")
                    {
                        TextEdit txt = (TextEdit)c;
                        txt.Text = null;
                    }
                    if (c.GetType().Name == "MemoEdit")
                    {
                        MemoEdit txt = (MemoEdit)c;
                        txt.Text = null;
                    }
                    if (c.GetType().Name == "ComboBoxEdit")
                    {
                        ComboBoxEdit comb = (ComboBoxEdit)c;
                        comb.EditValue = null;
                    }
                    if (c.GetType().Name == "GridLookUpEdit")
                    {
                        GridLookUpEdit look = (GridLookUpEdit)c;
                        look.EditValue = null;
                    }
                    if (c.HasChildren)
                    {
                        CleanControl(c);
                    }
                }
            }
        }

        public static void ControlToEntity<T>(Control control, ref T t)
        {
            Type type = typeof(T);
            List<PropertyInfo> lstProperty = type.GetProperties().ToList();
            if (control != null && control.HasChildren)
            {
                foreach (Control c in control.Controls)
                {
                    if (c.GetType().Name == "CheckEdit")
                    {
                        CheckEdit chk = (CheckEdit)c;
                        SetPropertyValue<T>(chk.Checked, lstProperty, chk.Tag.ToObjectString(), ref t);
                    }
                    if (c.GetType().Name == "TextEdit")
                    {
                        TextEdit txt = (TextEdit)c;
                        SetPropertyValue<T>(txt.Text.Trim(), lstProperty, txt.Tag.ToObjectString(), ref t);
                    }
                    if (c.GetType().Name == "MemoEdit")
                    {
                        MemoEdit m = (MemoEdit)c;
                        SetPropertyValue<T>(m.Text, lstProperty, m.Tag.ToObjectString(), ref t);
                    }
                    if (c.GetType().Name == "GridLookUpEdit")
                    {
                        GridLookUpEdit look = (GridLookUpEdit)c;
                        SetPropertyValue<T>(look.EditValue.ToObjectString(), lstProperty, look.Tag.ToObjectString(), ref t);
                    }
                    if (c.GetType().Name == "SearchLookUpEdit")
                    { 
                        SearchLookUpEdit look = (SearchLookUpEdit)c;
                        SetPropertyValue<T>(look.EditValue.ToObjectString(), lstProperty, look.Tag.ToObjectString(), ref t);
                    }
                    if (c.GetType().Name == "DateEdit")
                    {
                        DateEdit de = (DateEdit)c;
                        SetPropertyValue<T>(de.EditValue.ToObjectString(), lstProperty, de.Tag.ToObjectString(), ref t);
                    }
                    //GridLookUpEdit
                    if (c.HasChildren)
                    {
                        ControlToEntity<T>(c, ref t);
                    }
                }
            }
        }
    }
}
