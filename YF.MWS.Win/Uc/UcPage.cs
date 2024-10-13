using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Metadata.Event;
using YF.MWS.Metadata;
using YF.Utility;
using YF.MWS.Metadata.Query;

namespace YF.MWS.Win.Uc
{
    public partial class UcPage : UserControl
    {
        private QPage page;

        public QPage Page
        {
            get { return page; }
            set { page = value; }
        }
        public event PageChangedEventHandler PageChanged;
        public UcPage()
        {
            InitializeComponent();
            page = new QPage();
        }

        private void UcPage_Load(object sender, EventArgs e)
        {
            InitControl();
        }

        public void InitControl() 
        {
            if (page.TotalPages <= 1)
            {
                dnPager.Buttons.CustomButtons[0].Enabled = false;
                dnPager.Buttons.CustomButtons[1].Enabled = false;
                dnPager.Buttons.CustomButtons[2].Enabled = false;
                dnPager.Buttons.CustomButtons[3].Enabled = false;
            }
            else 
            {
                dnPager.Buttons.CustomButtons[0].Enabled = false;
                dnPager.Buttons.CustomButtons[1].Enabled = false;
                dnPager.Buttons.CustomButtons[2].Enabled = true;
                dnPager.Buttons.CustomButtons[3].Enabled = true;
            }
            lblPage.Text = "第1页";
        }

        private void dnPager_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Custom) 
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                PageDirection direction = btn.Tag.ToObjectString().ToEnum<PageDirection>();
                switch (direction)
                {
                    case PageDirection.First:
                        page.PageIndex = 0;
                        break;
                    case PageDirection.Next:
                        page.PageIndex++;
                        break;
                    case PageDirection.Prev:
                        page.PageIndex--;
                        break;
                    case PageDirection.Last:
                        page.PageIndex = page.TotalPages - 1;
                        break;
                }
                if (page.TotalPages <= 1)
                {
                    dnPager.Buttons.CustomButtons[0].Enabled = false;
                    dnPager.Buttons.CustomButtons[1].Enabled = false;
                    dnPager.Buttons.CustomButtons[2].Enabled = false;
                    dnPager.Buttons.CustomButtons[3].Enabled = false;
                }
                else 
                {
                    dnPager.Buttons.CustomButtons[0].Enabled = true;
                    dnPager.Buttons.CustomButtons[1].Enabled = true;
                    dnPager.Buttons.CustomButtons[2].Enabled = true;
                    dnPager.Buttons.CustomButtons[3].Enabled = true;
                    if (page.PageIndex == 0) 
                    {
                        dnPager.Buttons.CustomButtons[0].Enabled = false;
                        dnPager.Buttons.CustomButtons[1].Enabled = false; 
                    }
                    if (page.PageIndex == page.TotalPages-1)
                    { 
                        dnPager.Buttons.CustomButtons[2].Enabled = false;
                        dnPager.Buttons.CustomButtons[3].Enabled = false;
                    }
                }
                lblPage.Text = string.Format("第{0}页",page.PageIndex+1);
                if (PageChanged != null) 
                {
                    PageChanged(sender, new PageChangedEventArgs(direction, page));
                }
            }
        }
    }
}
