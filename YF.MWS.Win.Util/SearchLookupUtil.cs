using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using YF.MWS.Db;
using YF.MWS.Metadata;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraLayout;
using System.Windows.Forms;
using DevExpress.XtraGrid.Editors;

namespace YF.MWS.Win.Util
{
    /// <summary>
    /// Search Lookup帮助类
    /// Author:仇军
    /// Date:2014.10.05
    /// </summary>
    public class SearchLookupUtil
    {
        #region Private Methods

        private static void lookup_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DevExpress.Utils.Win.IPopupControl control = sender as DevExpress.Utils.Win.IPopupControl;
            DevExpress.XtraEditors.Popup.PopupBaseForm Form = control.PopupWindow as DevExpress.XtraEditors.Popup.PopupBaseForm;
            Control btFindLCI = GetFindControlLayoutItem(Form, "btFind");
            if (btFindLCI != null)
            {
                btFindLCI.Text = "查找";
            }
            Control btClear = GetFindControlLayoutItem(Form, "btClear");
            if (btClear != null)
            {
                btClear.Text = "清除";
            }
        }

        private static Control GetFindControlLayoutItem(PopupBaseForm Form, string strName)
        {
            if (Form != null)
            {
                foreach (Control FormC in Form.Controls)
                {
                    if (FormC is SearchEditLookUpPopup)
                    {
                        SearchEditLookUpPopup SearchPopup = FormC as SearchEditLookUpPopup;
                        foreach (Control SearchPopupC in SearchPopup.Controls)
                        {
                            if (SearchPopupC is LayoutControl)
                            {
                                LayoutControl FormLayout = SearchPopupC as LayoutControl;
                                Control Button = FormLayout.GetControlByName(strName);
                                if (Button != null)
                                {
                                    return Button;
                                }

                            }
                        }
                    }
                }
            }
            return null;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 设置数据源
        /// </summary>
        /// <param name="lookup"></param>
        /// <param name="dataSource"></param>
        /// <param name="valueMember"></param>
        /// <param name="displayMember"></param>
        /// <param name="lstField"></param>
        public static void BindData(SearchLookUpEdit lookup, object dataSource, string valueMember, string displayMember, List<LookupField> lstField)
        {
            lookup.Properties.DataSource = dataSource;
            lookup.Properties.View.OptionsView.ShowColumnHeaders = true;
            lookup.Properties.ValueMember = valueMember;
            lookup.Properties.DisplayMember = displayMember;
            lookup.Properties.View.Columns.Clear();
            if (lstField != null)
            {
                foreach (LookupField f in lstField)
                {
                    lookup.Properties.View.Columns.AddVisible(f.FieldName, f.Caption);
                }
            }
            lookup.Properties.View.BestFitColumns();
            //lookup.Properties.View.OptionsFind.ShowFindButton = false; 
            //lookup.QueryPopUp += new System.ComponentModel.CancelEventHandler(lookup_QueryPopUp);
        }

        public static string GetCustomerId(SearchLookUpEdit lookup) 
        {
            string customerId = string.Empty;
            if (lookup.Properties.View.GetFocusedRow() != null) 
            {
                customerId = ((SCustomer)lookup.Properties.View.GetFocusedRow()).CustomerId;
            }
            return customerId;
        }

        #endregion

    }
}
