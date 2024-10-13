using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Util;
using YF.MWS.Db;
using System.Data;
using YF.Utility.Data;
using YF.Data.NHProvider;

using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;

namespace YF.MWS.SQliteService
{
    public class AttributeService :BaseService, IAttributeService
    {

        public SAttribute GetAttribute(string Id)
        {
            string sql;
            sql = string.Format("select * from S_Attribute where Id='{0}'",Id);
            return getModel<SAttribute>(sql);
        }

        public List<SAttribute> GetAttributeList(string subjectId)
        {
            List<SAttribute> lstAttr = new List<SAttribute>();
            string sql;
            sql = string.Format("select * from S_Attribute where SubjectId='{0}'", subjectId);
            DataTable dt = null;
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
                lstAttr = TableHelper.TableToList<SAttribute>(dt);
            }
            return lstAttr;
        }

        public List<BWeightAttribute> GetWeightAttributeList(string weightId)
        {
            List<BWeightAttribute> lstAttr = new List<BWeightAttribute>();
            string sql;
            sql = string.Format(@"select b.AttributeName,b.FieldName,a.AttributeId,a.AttributeValue,a.Id,a.WeightId
                                        from B_WeightAttribute a left join S_Attribute b  on a.AttributeId=b.Id where a.WeightId='{0}'", weightId);
            DataTable dt = null;
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
                lstAttr = TableHelper.TableToList<BWeightAttribute>(dt);
            }
            return lstAttr;
        }

        public SAttributeSubject GetSubject(string subjectId)
        {
            SAttributeSubject attr = null;
            string sql;
            sql = string.Format("select * from S_AttributeSubject where Id='{0}'", subjectId);
            return getModel<SAttributeSubject>(sql);
        }

        public List<SAttributeSubject> GetSubjectList()
        {
            List<SAttributeSubject> lstSubject = new List<SAttributeSubject>();
            string sql;
            sql = "select * from S_AttributeSubject";
            DataTable dt = null;
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
                lstSubject = TableHelper.TableToList<SAttributeSubject>(dt);
            }
            return lstSubject;
        }

        public bool DeleteAttribute(string attributeId)
        {
            bool isDeleted = false;
            string sql;
            sql = string.Format(@"delete from S_Attribute where Id='{0}'", attributeId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isDeleted = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                isDeleted = service.ExecuteNonQuery(sql);
            }
            return isDeleted;
        }

        public bool DeleteSubject(string subjectId)
        {
            bool isDeleted = false;
            List<SAttribute> lst;
            lst=GetAttributeList(subjectId);
            if (lst == null || lst.Count == 0) 
            {
                string sql;
                sql = string.Format(@"delete from S_AttributeSubject where Id='{0}'", subjectId);
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    isDeleted = sqliteDb.ExecuteNonQuery(sql) > 0;
                }
                else 
                {
                    isDeleted = service.ExecuteNonQuery(sql);
                }
            }
            return isDeleted;
        }

        public bool SaveAttribute(SAttribute attribute)
        {
            string sql;
            sql = SqliteSqlUtil.GetSaveSql<SAttribute>(attribute, "S_Attribute");
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                return service.Save<SAttribute>(attribute,attribute.Id);
            }
        }

        public bool SaveSubject(SAttributeSubject subject)
        {
            string sql;
            sql = SqliteSqlUtil.GetSaveSql<SAttributeSubject>(subject, "S_AttributeSubject");
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                return service.Save<SAttributeSubject>(subject, subject.Id);
            }
        }

        public bool SaveWeightAttribute(string weightId, List<BWeightAttribute> lstAttr) 
        {
            bool isSaved = false;
            if (lstAttr == null || lstAttr.Count == 0) 
            {
                return isSaved;
            }
            List<string> lstSql=new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("delete from B_WeightAttribute where WeightId='{0}';", weightId);
            lstSql.Add(sb.ToString());
            foreach (BWeightAttribute attr in lstAttr) 
            {
               lstSql.Add(string.Format("{0};", SqliteSqlUtil.GetSaveSql<BWeightAttribute>(attr, "B_WeightAttribute")));
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isSaved = sqliteDb.ExecuteNonQuery(lstSql) > 0;
            }
            else 
            {
                isSaved = service.ExecuteNonQuery(lstSql);
            }
            return isSaved;
        }
    }
}
