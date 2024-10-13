using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Metadata;
using YF.Utility;

namespace YF.MWS.Win.Uc
{
    public partial class DateFilter : DevExpress.XtraEditors.XtraUserControl
    {
        public RadioGroup RgSummaryType
        {
            get
            {
                return rgSummaryType;
            }
        }
        private DateTime dtStart = DateTime.Now;
        private DateTime dtEnd = DateTime.Now;

        public DateTime DtEnd
        {
            get { return dtEnd; }
            set { dtEnd = value; }
        }

        public DateTime DtStart
        {
            get { return dtStart; }
            set { dtStart = value; }
        }
        private int startDate;

        public int StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        private int endDate;

        public int EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public DateFilter()
        {
            InitializeComponent();
            InitControl();
        }

        private void InitControl()
        {
            teDay.Time = DateTime.Now;
            teWeek.Time = DateTime.Now;
            teMonth.Time = DateTime.Now;
            teQuanter.Time = DateTime.Now;
            teYear.Time = DateTime.Now;
            teStartDate.Time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            teEndDate.Time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            for (int i = 1; i <= 52; i++)
            {
                combWeek.Properties.Items.Add(string.Format("第{0}周", i));
            }
        }

        public DateSummaryType DateType
        {
            get
            {
                return rgSummaryType.SelectedIndex.ToEnum<DateSummaryType>();
            }
        }

        public void SetStartDate(DateTime date) 
        {
            teStartDate.Time = date;
        }

        public void SetDate()
        {
            startDate = 0;
            endDate = 0;
            DateSummaryType type = rgSummaryType.SelectedIndex.ToEnum<DateSummaryType>();
            switch (type)
            {
                case DateSummaryType.Custom:
                    startDate = teStartDate.Time.ToString("yyyyMMdd").ToInt();
                    dtStart = teStartDate.Time;
                    endDate = teEndDate.Time.ToString("yyyyMMdd").ToInt();
                    dtEnd = teEndDate.Time;
                    break;
                case DateSummaryType.Day:
                    startDate = teDay.Time.ToString("yyyyMMdd").ToInt();
                    dtStart = teDay.Time;
                    endDate = teDay.Time.ToString("yyyyMMdd").ToInt();
                    dtEnd = teDay.Time;
                    break;
                case DateSummaryType.Month:
                    startDate = DateUtil.FirstDayOfMonth(teMonth.Time.Year, teMonth.Time.Month).ToString("yyyyMMdd").ToInt();
                    dtStart = DateUtil.FirstDayOfMonth(teMonth.Time.Year, teMonth.Time.Month);
                    endDate = DateUtil.LastDayOfMonth(teMonth.Time.Year, teMonth.Time.Month).ToString("yyyyMMdd").ToInt();
                    dtEnd = DateUtil.LastDayOfMonth(teMonth.Time.Year, teMonth.Time.Month);
                    break;
                case DateSummaryType.Quanter:
                    startDate = DateUtil.FirstDayOfQuarter(teQuanter.Time.Year, combQuanter.SelectedIndex + 1).ToString("yyyyMMdd").ToInt();
                    dtStart = DateUtil.FirstDayOfQuarter(teQuanter.Time.Year, combQuanter.SelectedIndex + 1);
                    endDate = DateUtil.LastDayOfQuarter(teQuanter.Time.Year, combQuanter.SelectedIndex + 1).ToString("yyyyMMdd").ToInt();
                    dtEnd = DateUtil.LastDayOfQuarter(teQuanter.Time.Year, combQuanter.SelectedIndex + 1);
                    break;
                case DateSummaryType.Week:
                    int indexWeek = combWeek.SelectedIndex;
                    if (indexWeek < 0)
                    {
                        indexWeek = 0;
                    }
                    startDate = DateUtil.FirstDayOfWeek(teWeek.Time.Year, indexWeek + 1).ToString("yyyyMMdd").ToInt();
                    dtStart = DateUtil.FirstDayOfWeek(teWeek.Time.Year, indexWeek + 1);
                    endDate = DateUtil.LastDayOfWeek(teWeek.Time.Year, indexWeek + 1).ToString("yyyyMMdd").ToInt();
                    dtEnd = DateUtil.LastDayOfWeek(teWeek.Time.Year, indexWeek + 1);
                    break;
                case DateSummaryType.Year:
                    startDate = DateUtil.FirstDayOfYear(teYear.Time.Year).ToString("yyyyMMdd").ToInt();
                    dtStart = DateUtil.FirstDayOfYear(teYear.Time.Year);
                    endDate = DateUtil.LastDayOfYear(teYear.Time.Year).ToString("yyyyMMdd").ToInt();
                    dtEnd = DateUtil.LastDayOfYear(teYear.Time.Year);
                    break;
            }
        }
    }
}
