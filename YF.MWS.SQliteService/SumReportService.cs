using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Util;

namespace YF.MWS.SQliteService
{
    public class SumReportService : ISumReportService
    {
        private SqliteDb sqliteDb = new SqliteDb();

        #region ISumReportService 成员

        public DataSet GetReportSource(string sql)
        {
            DataSet ds = new DataSet();
            ds.DataSetName = "Report";
            ds = sqliteDb.ExecuteDataSet(sql);
            return ds;
        }

        #endregion
    }
}
