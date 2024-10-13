using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YF.MWS.Client.DataService.Interface
{
    public interface ISumReportService
    {
        DataSet GetReportSource(string sql);
    }
}
