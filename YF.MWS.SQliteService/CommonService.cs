using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.Data.NHProvider;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.Util;
using YF.Utility.Data;

namespace YF.MWS.SQliteService
{
    /// <summary>
    /// 
    /// Author:闫孝感
    /// Date:2025-02-08
    /// </summary>
    public class CommonService :BaseService, ICommonService {
        #region ILogService 成员

        public bool save(BCommon common)
        {
            if(string.IsNullOrEmpty(common.Id))
                common.Id = YF.MWS.Util.Utility.GetGuid();
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                string sql = SqliteSqlUtil.GetSaveSql<BCommon>(common, "B_Common");
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                return service.Save<BCommon>(common,common.Id);
            }
        }

        public BCommon GetModel(string Caption)
        {
            string sql;
            sql = string.Format(@"select * from B_Common where Caption='{0}'", Caption);
            return base.getModel<BCommon>(sql);
        }

        #endregion
    }
}
