using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using YF.MWS.Db;
using YF.MWS.BaseMetadata;
using DevExpress.XtraEditors;

namespace YF.MWS.Win.Util
{
    public class RoleUtil
    {
        /// <summary>
        /// 自定义的控件是否具有可编辑权限
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="lstModule"></param>
        /// <returns></returns>
        public static bool IsEnabled(Control ctrl, List<SModule> lstModule) 
        {
            bool enabled = false;
            if (CurrentUser.Instance.IsAdministrator)
            {
                return true;
            }
            if (ctrl.Tag!=null && !string.IsNullOrEmpty(ctrl.Tag.ToString()) && lstModule!=null && lstModule.Count>0)
            {
                SModule module = lstModule.Find(c => !string.IsNullOrEmpty(c.ActionName) && c.ActionName.ToLower() == ctrl.Tag.ToString().ToLower());
                if (module != null) 
                {
                    enabled = true;
                }
            }
            return enabled;
        }

        public static bool GetBarItem(BarItem item, List<SModule> lstModule)
        {
            bool isEnabled = false;
            if (item.Tag != null && !string.IsNullOrEmpty(item.Tag.ToString()) && lstModule != null && lstModule.Count > 0)
            {
                SModule module = lstModule.Find(m => !string.IsNullOrEmpty(m.ActionName) && m.ActionName.ToLower() == item.Tag.ToString().ToLower());
                if (module != null)
                {
                    isEnabled = true;
                }
            }
            return isEnabled;
        }

        public static void SetBarItem(List<BarItem> lstItem, List<SModule> lstModule)
        {
            if (CurrentUser.Instance.IsAdministrator)
            {
                return;
            }
            foreach (BarItem c in lstItem)
            {
                c.Enabled = false;
                if (c.Tag != null && !string.IsNullOrEmpty(c.Tag.ToString()) && lstModule != null && lstModule.Count > 0)
                {
                    SModule module = lstModule.Find(m => !string.IsNullOrEmpty(m.ActionName) && m.ActionName.ToLower() == c.Tag.ToString().ToLower());
                    if (module != null)
                    {
                        c.Enabled = true;
                    }
                    else
                    {
                        c.Enabled = false;
                        c.Visibility = BarItemVisibility.Never;
                    }
                }
            }
        }

        public static void SetBarSubItem(List<BarSubItem> lstItem, List<SModule> lstModule)
        {
            if (CurrentUser.Instance.IsAdministrator)
            {
                return;
            }
            foreach (BarItem c in lstItem)
            {
                c.Enabled = false;
                if (c.Tag != null && !string.IsNullOrEmpty(c.Tag.ToString()) && lstModule != null && lstModule.Count > 0)
                {
                    SModule module = lstModule.Find(m => !string.IsNullOrEmpty(m.ActionName) && m.ActionName.ToLower() == c.Tag.ToString().ToLower());
                    if (module != null)
                    {
                        c.Enabled = true;
                    }
                    else
                    {
                        c.Enabled = false;
                        c.Visibility = BarItemVisibility.Never;
                    }
                }
            }
        }

        public static bool HasPermission(Control c, List<SModule> lstModule)
        {
            bool hasPermission = false;
            if (lstModule == null || lstModule.Count == 0 || CurrentUser.Instance.IsAdministrator)
            {
                return true;
            }
            if (c.Tag != null && !string.IsNullOrEmpty(c.Tag.ToString()) && lstModule != null && lstModule.Count > 0)
            {
                SModule module = lstModule.Find(m => !string.IsNullOrEmpty(m.ActionName) && m.ActionName.ToLower() == c.Tag.ToString().ToLower());
                if (module != null)
                {
                    hasPermission = true;
                }
            }
            return hasPermission;
        }

        public static void SetButton(List<SimpleButton> buttons, List<SModule> modules)
        {
            if (CurrentUser.Instance.IsAdministrator)
            {
                return;
            }
            if (modules == null)
                modules = new List<SModule>();
            string tag = string.Empty;
            foreach (Control c in buttons)
            {
                if (c.Tag != null && !string.IsNullOrEmpty(c.Tag.ToString()))
                {
                    tag = string.Format("{0}", c.Tag.ToString().Split('|')[0]);
                    SModule module = modules.Find(m => !string.IsNullOrEmpty(m.ActionName) && m.ActionName.ToLower() == tag.ToLower());
                    if (module != null)
                    {
                        c.Enabled = true;
                    }
                    else
                    {
                        c.Enabled = false;
                    }
                }
            }
        }

        public static void SetControl(List<Control> lstControl, List<SModule> lstModule) 
        {
            if (lstModule == null || lstModule.Count == 0) 
            {
                return;
            }
            foreach (Control c in lstControl) 
            {
                if (c.Tag != null && !string.IsNullOrEmpty(c.Tag.ToString())) 
                {
                    SModule module = lstModule.Find(m => !string.IsNullOrEmpty(m.ActionName) && m.ActionName.ToLower() == c.Tag.ToString().ToLower());
                    if (module != null)
                    {
                        c.Enabled = true;
                    }
                    else 
                    {
                        c.Enabled = false;
                        c.Visible = false;
                    }
                }
            }
        }
    }
}
