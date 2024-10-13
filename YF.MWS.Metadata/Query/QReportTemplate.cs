using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.Utility.Data;
using YF.Utility;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Metadata.Query
{
    public class QReportTemplate : SReportTemplate
    {
        public string ReportTypeCaption
        {
            get 
            {
                string caption = string.Empty;
                if (TemplateType == YF.MWS.BaseMetadata.TemplateType.Document.ToString())
                {
                    caption = EnumUtil.GetEnumDescription(ReportType.ToEnum<DocumentType>());
                }
                else
                {
                    caption = EnumUtil.GetEnumDescription(ReportType.ToEnum<SummaryReportType>());
                }
                return caption;
            }
        }

        public string TemplateAliasName 
        {
            get 
            {
                if (IsDefault == 1)
                {
                    return string.Format("{0}(默认)", TemplateName);
                }
                else 
                {
                    return TemplateName;
                }
            }
        }
    }
}
