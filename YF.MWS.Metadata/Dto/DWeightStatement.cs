using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility;

namespace YF.MWS.Metadata.Dto
{
    public class DWeightStatement
    {
        public virtual string CompanyName { get; set; }

        public virtual decimal NetWeightTotal { get; set; }

        public virtual int WeightCount { get; set; }

        public string ReportType { get; set; }

        public virtual string ReportDate { get; set; }

        public string StartDate 
        {
            get 
            {
                WeightReportType type = ReportType.ToEnum<WeightReportType>();
                string date = string.Empty;
                switch (type) 
                {
                    case WeightReportType.Day:
                    case WeightReportType.Today:
                        date = ReportDate;
                        break;
                    case WeightReportType.Month:
                        {
                            DateTime dtStart = DateTime.Parse(ReportDate);
                            date = dtStart.ToString("yyyy-MM-dd");
                        }
                        break;
                    case WeightReportType.Year:
                        {
                            DateTime dtStart = new DateTime(int.Parse(ReportDate), 1, 1);
                            date = dtStart.ToString("yyyy-MM-dd");
                        }
                        break;
                }
                return date;
            }
        }

        public string EndDate 
        {
            get
            {
                WeightReportType type = ReportType.ToEnum<WeightReportType>();
                string date = string.Empty;
                switch (type)
                {
                    case WeightReportType.Day:
                    case WeightReportType.Today:
                        date = ReportDate;
                        break;
                    case WeightReportType.Month:
                        {
                            DateTime dtStart = DateTime.Parse(ReportDate);
                            DateTime dtEnd=DateUtil.LastDayOfMonth(dtStart.Year, dtStart.Month);
                            date = dtEnd.ToString("yyyy-MM-dd");
                        }
                        break;
                    case WeightReportType.Year:
                        {
                            DateTime dtStart = new DateTime(int.Parse(ReportDate), 1, 1);
                            DateTime dtEnd = DateUtil.LastDayOfYear(dtStart.Year);
                            date = dtEnd.ToString("yyyy-MM-dd");
                        }
                        break;
                }
                return date;
            }
        }
    }
}
