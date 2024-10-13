using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using System.Data;
using YF.Utility.Data;
using YF.Utility;
using YF.MWS.Util;
using YF.Data.NHProvider;

using YF.MWS.BaseMetadata;
using System.Data.SqlClient;
using YF.MWS.Metadata.Query;
using YF.Data.NHProvider.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata;

namespace YF.MWS.SQliteService
{
    public class SeqNoService : ISeqNoService
    {
        private SqliteDb sqliteDb = new SqliteDb();
        private IService service = null;
        /// <summary>
        /// 磅单号是否随机生成
        /// </summary>
        private bool generateWeightNoByRand = false;

        public SeqNoService() 
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                service = ServiceInitialization.DbService;
            }
            SysCfg cfg = Util.Utility.GetCfg();
            if (cfg != null && cfg.Weight != null)
                generateWeightNoByRand = cfg.Weight.GenerateWeightNoByRand;
        }
        /// <summary>
        /// 系统序列号服务接口
        /// Author:yafyr
        /// Date:2014-10-07
        /// </summary>
        #region ISeqNoService 成员
        public bool Cancel(string seqCode) 
        {
            string sql = string.Format(@"update S_SeqNo set RuningNo=RuningNo-1 where SeqCode='{0}'", seqCode);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                return service.ExecuteNonQuery(sql);
            }
        }

        public string GetSeqNo(string seqCode)
        {
            string prefix = string.Empty;
            string seqNo = string.Empty;
            if (!string.IsNullOrEmpty(seqCode) && seqCode == SeqCode.Weight.ToString() && generateWeightNoByRand)
            {
                SSeqNo seq = GetByCode(seqCode);
                prefix = string.Empty;
                if (seq != null)
                    prefix = seq.Prefix;
                return string.Format("{0}{1}", prefix, IdWorker.NewID().ToString());
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                string currentDate = DateTime.Now.ToString("yyyyMMdd");
                DataTable dt;
                string sql;
                string datefomart = string.Empty;
                string fixString = string.Empty;
                int fixedLen = 0;
                bool appendDate = true;
                sql = string.Format(@"select Prefix,DateFomart,FixedLen from S_SeqNo where SeqCode='{0}'", seqCode);
                dt = sqliteDb.ExecuteDataTable(sql);
                int runingNo = 0;
                if (dt.Rows.Count > 0)
                {
                    prefix = dt.Rows[0][0].ToObjectString();
                    datefomart = dt.Rows[0][1].ToObjectString();
                    fixedLen = dt.Rows[0][2].ToInt();
                    if (datefomart.Length == 0 || datefomart=="NA")
                    {
                        appendDate = false;
                        sql = string.Format(@"select RuningNo from S_SeqNo where SeqCode='{0}'", seqCode);
                    }
                    else
                    {
                        sql = string.Format(@"select RuningNo from S_SeqNo where SeqCode='{0}' and CurrentDate='{1}'", seqCode, currentDate);
                    }
                    dt = sqliteDb.ExecuteDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        runingNo = dt.Rows[0][0].ToInt() + 1;
                        if (appendDate)
                        {
                            sql = string.Format(@"update S_SeqNo set CurrentDate='{0}',RuningNo=RuningNo+1 where SeqCode='{1}'", currentDate, seqCode);
                        }
                        else 
                        {
                            sql = string.Format(@"update S_SeqNo set RuningNo=RuningNo+1 where SeqCode='{0}'", seqCode);
                        }
                    }
                    else
                    {
                        runingNo = 1;
                        if (appendDate)
                        {
                            sql = string.Format(@"update S_SeqNo set CurrentDate='{0}',RuningNo=1 where SeqCode='{1}'", currentDate, seqCode);
                        }
                        else 
                        {
                            sql = string.Format(@"update S_SeqNo set RuningNo=1 where SeqCode='{0}'", seqCode);
                        }
                    }
                }
                sqliteDb.ExecuteNonQuery(sql);
                if (appendDate)
                {
                    fixedLen = fixedLen - datefomart.Length - prefix.Length - runingNo.ToString().Length;
                }
                else 
                {
                    fixedLen = fixedLen - prefix.Length - runingNo.ToString().Length;
                }
                if (fixedLen > 0)
                {
                    fixString = runingNo.ToString().PadLeft(fixedLen + runingNo.ToString().Length, '0');
                }
                else 
                {
                    fixString = runingNo.ToString();
                }
                if (string.IsNullOrEmpty(datefomart))
                {
                    datefomart = "yyyyMMdd";
                }
                if (appendDate)
                {
                    seqNo = prefix + DateTime.Now.ToString(datefomart) + fixString;
                }
                else 
                {
                    seqNo = prefix + fixString;
                }
                
            }
            else
            {
                string procedureName = "SP_GetSeqNo";
                List<DataParameter> lstParameter = new List<DataParameter>();
                DataParameter parameter1 = new DataParameter() { DataType = DbType.String, ParameterName = "@SeqCode", Val = seqCode };
                DataParameter parameter2 = new DataParameter() { DataType = DbType.String, ParameterName = "@SeqNo", Direction = ParameterDirection.Output, Size = 50 };
                lstParameter.Add(parameter1);
                lstParameter.Add(parameter2);
                service.ExecuteStoredProcedure(procedureName, lstParameter);
                if (lstParameter[1].Val != null)
                {
                    seqNo = lstParameter[1].Val.ToObjectString();
                }
            }
            return seqNo;
        }

        public SSeqNo Get(string noId)
        {
            SSeqNo user = null;
            string sql;
            sql = string.Format(@"select * from S_SeqNo where Id='{0}'", noId);
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                user = TableHelper.RowToEntity<SSeqNo>(dt.Rows[0]);
            }
            return user;
        }

        private SSeqNo GetByCode(string seqCode)
        {
            SSeqNo user = null;
            string sql;
            sql = string.Format(@"select * from S_SeqNo where SeqCode='{0}'", seqCode);
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                user = TableHelper.RowToEntity<SSeqNo>(dt.Rows[0]);
            }
            return user;
        }

        public List<QSeqNo> GetList(List<SCode> lstCode)
        {
            string sql;
            DataTable dt;
            List<QSeqNo> lstSeqNo = new List<QSeqNo>();
            SCode code=null;
            sql = "select * from S_SeqNo";
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                lstSeqNo = TableHelper.TableToList<QSeqNo>(dt);
            }
            foreach (QSeqNo seq in lstSeqNo) 
            {
                code = lstCode.Find(c => c.ItemCode == seq.SeqCode);
                if (code != null) 
                {
                    seq.SeqCodeCaption = code.ItemCaption;
                }
            }
            return lstSeqNo;
        }

        public string Preview(string seqCode)
        {
            string prefix = string.Empty;
            string currentDate = DateTime.Now.ToString("yyyyMMdd");
            string seqNo = string.Empty;
            DataTable dt;
            string sql;
            string datefomart = string.Empty;
            string fixString = string.Empty;
            int fixedLen = 0;
            bool appendDate = true;
            sql = string.Format(@"select Prefix,DateFomart,FixedLen from S_SeqNo where SeqCode='{0}'", seqCode);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                dt = service.GetDataTable(sql);
            }
            int runingNo = 0;
            if (dt.Rows.Count > 0)
            {
                prefix = dt.Rows[0][0].ToObjectString();
                datefomart = dt.Rows[0][1].ToObjectString();
                fixedLen = dt.Rows[0][2].ToInt();
                if (datefomart.Length == 0 || datefomart == "NA")
                {
                    appendDate = false;
                    sql = string.Format(@"select RuningNo from S_SeqNo where SeqCode='{0}'", seqCode);
                }
                else
                {
                    sql = string.Format(@"select RuningNo from S_SeqNo where SeqCode='{0}' and CurrentDate='{1}'", seqCode, currentDate);
                }
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    dt = sqliteDb.ExecuteDataTable(sql);
                }
                else
                {
                    dt = service.GetDataTable(sql);
                }
                if (dt.Rows.Count > 0)
                {
                    runingNo = dt.Rows[0][0].ToInt() + 1;
                }
                else
                {
                    runingNo = 1;
                }
            }

            if (appendDate)
            {
                fixedLen = fixedLen - datefomart.Length - prefix.Length - runingNo.ToString().Length;
            }
            else
            {
                fixedLen = fixedLen - prefix.Length - runingNo.ToString().Length;
            }
            if (fixedLen > 0)
            {
                fixString = runingNo.ToString().PadLeft(fixedLen + runingNo.ToString().Length, '0');
            }
            else
            {
                fixString = runingNo.ToString();
            }
            if (string.IsNullOrEmpty(datefomart))
            {
                datefomart = "yyyyMMdd";
            }
            if (appendDate)
            {
                seqNo = prefix + DateTime.Now.ToString(datefomart) + fixString;
            }
            else
            {
                seqNo = prefix + fixString;
            }
            return seqNo;
        }

        public bool Save(SSeqNo seqNo)
        {
            bool isSaved = false;
            string sql;
            if (string.IsNullOrEmpty(seqNo.Id))
            {
                seqNo.Id = Util.Utility.GetGuid();
            }
            sql = SqliteSqlUtil.GetSaveSql<SSeqNo>(seqNo, "S_SeqNo");
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                isSaved = service.Save<SSeqNo>(seqNo, seqNo.Id);
            }
            return isSaved;
        }

        #endregion

    }
}
