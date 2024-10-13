using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Repository;

namespace YF.MWS.Metadata.UI
{
    public class ColumnProperty
    {
        private bool _ReadOnly = false;
        private bool _Visible = true;
        private int _MaxLength = 0;
        private int _MinLength = 0;
        private int _TabIndex = -1;

        //by xie fuhong on 2012/10/04
        private bool isAllowBestFitWidth = false;

        //by xie fuhong on 2012/10/04
        //Adjusts Column width to display  the contents of a cell as best as possible.
        public bool IsAllowBestFitWidth
        {
            get { return isAllowBestFitWidth; }
            set { isAllowBestFitWidth = value; }
        }

        //by xie fuhong on 2012/10/04
        private string languageKeyName = string.Empty;

        //by xie fuhong on 2012/10/04
        // LanguageKeyName != FieldName
        public string LanguageKeyName
        {
            get { return languageKeyName; }
            set { languageKeyName = value; }
        }

        //by xie fuhong on 2012/09/19
        private bool allowMove = true;

        //by xie fuhong on 2012/09/19
        public bool AllowMove
        {
            get
            {
                return allowMove;
            }
            set { allowMove = value; }
        }

        //by xie fuhong on 2012/09/19
        public bool IsNotAllowMoveToCustomizationForm
        {
            get
            {
                if (NotNull) //Not allow hide Required Field 不允许隐藏必输字段
                {
                    return true;
                }
                if (FontBold) //Not allow hide 黑体 Field 不允许隐藏黑体字段
                {
                    return true;
                }
                return false;
            }
        }

        //by xie fuhong on 2012/09/19
        public bool IsShowFontBold
        {
            get
            {
                if (FontBold)//黑体
                {
                    return true;
                }
                if (NotNull) //Required Field is Bold设置必填列为黑体
                {
                    return true;
                }
                return false;
            }
        }

        //by xie fuhong on 2012/09/19
        public bool IsNotShowInCustomizationForm
        {
            get
            {
                if (!Visible)//hide not visible Field in choosing column list 不允许在选择字段列表中出现不可见的字段
                {
                    return true;
                }
                return false;
            }
        }

        public int TabIndex
        {
            get { return _TabIndex; }
            set { _TabIndex = value; }
        }
        public bool FontBold { get; set; }
        private string _Regular = "(.|\n)";
        /// <summary>
        /// 对应数据源字段
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 标题在没有Language的时候用这个
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// 如果要用自定义Lang不用Language的和FiledName一致的多语言是用这个
        /// </summary>
        public string CaptionLang { get; set; }
        /// <summary>
        /// 是否容许编辑
        /// </summary>
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set { _ReadOnly = value; }
        }
        /// <summary>
        /// 是否是必填项
        /// </summary>
        public bool NotNull
        {
            get;
            set;
        }
        /// <summary>
        /// 是否默认可见
        /// </summary>
        public bool Visible { get { return _Visible; } set { _Visible = value; } }
        /// <summary>
        /// 对应Grid里的EditName
        /// </summary>
        public string ColumnEditName { get; set; }
        public int MaxLength { get { return _MaxLength; } set { _MaxLength = value; } }
        public int MinLength { get { return _MinLength; } set { _MinLength = value; } }
        public string Regular { get { return _Regular; } set { _Regular = value; } }
        public DevExpress.Utils.FormatType FormatType { get; set; }
        public string FormatString { get; set; }
        public decimal MaxValue { get; set; }
        public decimal MinValue { get; set; }

        public ColumnFilter VerifyNumberLength { get; set; }
        private DevExpress.XtraGrid.Columns.FixedStyle _FixedStyle = DevExpress.XtraGrid.Columns.FixedStyle.None;
        public DevExpress.XtraGrid.Columns.FixedStyle FixedStyle { get { return _FixedStyle; } set { _FixedStyle = value; } }
        private DevExpress.XtraTreeList.Columns.FixedStyle _TreeFixedStyle = DevExpress.XtraTreeList.Columns.FixedStyle.None;
        public DevExpress.XtraTreeList.Columns.FixedStyle TreeFixedStyle { get { return _TreeFixedStyle; } set { _TreeFixedStyle = value; } }
        public void SetLength(DevExpress.XtraGrid.Columns.GridColumnCollection Columns)
        {
            if (_MaxLength == _MinLength && _MinLength.Equals(0) && _MaxLength.Equals(0))
            {
                return;
            }

            if (Columns[FieldName].ColumnType == Type.GetType("System.Decimal"))
            {
                Columns[FieldName].ColumnEdit = new RepositoryItemSpinEdit()
                {
                    MaxLength = _MaxLength,
                    MaxValue = MaxValue,
                    MinValue = MinValue
                };
            }
            else if (Columns[FieldName].ColumnEdit != null)
            {
                switch (Columns[FieldName].ColumnEdit.GetType().FullName)
                {
                    case "DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit":
                        var edit1 = Columns[FieldName].ColumnEdit as RepositoryItemButtonEdit;
                        edit1.MaxLength = _MaxLength;
                        break;
                    case "DevExpress.XtraEditors.Repository.RepositoryItemTextEdit":
                        var edit2 = Columns[FieldName].ColumnEdit as RepositoryItemTextEdit;
                        edit2.MaxLength = _MaxLength;
                        break;
                    case "DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit":
                        var edit3 = Columns[FieldName].ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit;
                        edit3.MaxLength = _MaxLength;
                        break;
                }

            }
            else if (Columns[FieldName].ColumnType == Type.GetType("System.String"))
            {
                Columns[FieldName].ColumnEdit = new RepositoryItemTextEdit()
                {
                    MaxLength = _MaxLength,
                };
            }
        }
        public void SetLength(DevExpress.XtraTreeList.Columns.TreeListColumnCollection Columns)
        {
            if (_MaxLength == _MinLength && _MinLength.Equals(0) && _MaxLength.Equals(0))
            {
                return;
            }

            if (Columns[FieldName].ColumnType == Type.GetType("System.Decimal"))
            {
                Columns[FieldName].ColumnEdit = new RepositoryItemSpinEdit()
                {
                    MaxLength = _MaxLength,
                    MaxValue = MaxValue,
                    MinValue = MinValue
                };
            }
            else if (Columns[FieldName].ColumnEdit != null)
            {
                switch (Columns[FieldName].ColumnEdit.GetType().FullName)
                {
                    case "DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit":
                        var edit1 = Columns[FieldName].ColumnEdit as RepositoryItemButtonEdit;
                        edit1.MaxLength = _MaxLength;
                        break;
                    case "DevExpress.XtraEditors.Repository.RepositoryItemTextEdit":
                        var edit2 = Columns[FieldName].ColumnEdit as RepositoryItemTextEdit;
                        edit2.MaxLength = _MaxLength;
                        break;
                    case "DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit":
                        var edit3 = Columns[FieldName].ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit;
                        edit3.MaxLength = _MaxLength;
                        break;
                }

            }
            else if (Columns[FieldName].ColumnType == Type.GetType("System.String"))
            {
                Columns[FieldName].ColumnEdit = new RepositoryItemTextEdit()
                {
                    MaxLength = _MaxLength,
                };
            }
        }

    }
}
