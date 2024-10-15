using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.Utility.Data;
using System.Data;
using System.Transactions;
using YF.MWS.Metadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Util;
using YF.Data.NHProvider;
using YF.MWS.BaseMetadata;
using System.Data.SqlClient;
using YF.Utility;
using YF.Data.NHProvider.Metadata;
using System.IO;
using YF.MWS.Metadata.Cfg;

namespace YF.MWS.SQliteService
{
    public class MaterialService : BaseService, IMaterialService {
        #region IMasterService 成员
        //public MaterialService(ConnectionStrings connection):base(connection) { }


        public List<ImportResult> ImportMaterial(List<SMaterial> lstMaterial, ImportMode mode) 
        {
            List<ImportResult> lstResult = new List<ImportResult>();
            bool isImported = false;
            if (lstMaterial == null || lstMaterial.Count == 0)
                return lstResult;
            string sql;
            List<string> lstSql = new List<string>();
            List<SMaterial> lstAll = GetMaterialList();
            SMaterial find = null;
            if (mode == ImportMode.New) 
            {
                sql = "delete from S_Material";
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    isImported = sqliteDb.ExecuteNonQuery(sql) > 0;
                }
                else
                {
                    isImported = service.ExecuteNonQuery(sql);
                }
            }
            foreach (SMaterial material in lstMaterial) 
            {
                if (string.IsNullOrEmpty(material.MaterialName))
                    continue;
                material.CreateTime = DateTime.Now;
                if (mode == ImportMode.New) 
                {
                    isImported=SaveMaterial(material);
                    if (isImported)
                        lstResult.Add(new ImportResult() { Success = true });
                    else
                        lstResult.Add(new ImportResult() { Success=false });
                }
                if (mode == ImportMode.Increment) 
                {
                    if (lstAll != null && lstAll.Count > 0)
                    {
                        find = lstAll.Find(c => c.MaterialName == material.MaterialName);
                        if (find == null) 
                        {
                            isImported = SaveMaterial(material);
                            if (isImported)
                                lstAll.Add(material);
                            if (isImported)
                                lstResult.Add(new ImportResult() { Success = true });
                            else
                                lstResult.Add(new ImportResult() { Success = false });
                        }
                    }
                    else 
                    {
                        isImported = SaveMaterial(material);
                        if (isImported)
                            lstResult.Add(new ImportResult() { Success = true });
                        else
                            lstResult.Add(new ImportResult() { Success = false });
                    }
                }
            }
            return lstResult;
        }


        public SMaterial GetMaterialByName(string materialName)
        {
            SMaterial material = null;
            string sql = string.Format("select * from S_Material where MaterialName='{0}'", materialName);
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                sql = string.Format("select * from S_Material where MaterialName=N'{0}'", materialName);
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                material = TableHelper.RowToEntity<SMaterial>(dt.Rows[0]);
            }
            return material;
        }

        public List<SCustomer> GetCustomerList()
        {
            string sql;
            sql = string.Format("select * from S_Customer where RowState!={0}",(int)RowState.Delete);
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                dt = service.GetDataTable(sql);
            }
            return TableHelper.TableToList<SCustomer>(dt);
        }

        public List<SCustomer> GetCustomerList(CustomerType customerType)
        {
            string sql;
            sql = string.Format("select * from S_Customer where CustomerType='{0}' and RowState!={1}", customerType.ToString(), (int)RowState.Delete);
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                dt = service.GetDataTable(sql);
            }
            return TableHelper.TableToList<SCustomer>(dt);
        }


        /// <summary>
        /// 根据物资编号获取物资信息
        /// </summary>
        /// <param name="materialId">物资编号</param>
        /// <returns></returns>
        public SMaterial GetMaterial(string materialId)
        {
            SMaterial material = null;
            string sql;
            sql = string.Format(@"select * from S_Material where Id = '{0}'", materialId);
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
                material = TableHelper.RowToEntity<SMaterial>(dt.Rows[0]);
            }
            return material;
        }

        public SMaterial GetSyncMaterial(string materialId)
        {
            SMaterial material = null;
            string sql;
            sql = string.Format(@"select * from S_Material where Id = '{0}' and SyncState=0", materialId);
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
                material = TableHelper.RowToEntity<SMaterial>(dt.Rows[0]);
            }
            return material;
        }

        /// <summary>
        /// 获取物资列表
        /// </summary>
        /// <returns></returns>
        public List<SMaterial> GetMaterialList()
        {
            string sql = "select * from S_Material";
            return base.getList<SMaterial>(sql);
        }
        public List<SMaterial> GetMaterialByCompanyId(string companyId) {
            string sql = $"select * from S_Material where CompanyId='{companyId}'";
            return base.getList<SMaterial>(sql);
        }
        /// <summary>
        /// 获取物资列表
        /// </summary>
        /// <returns></returns>
        public List<SMaterial> GetMaterialList(MaterialStateType state = MaterialStateType.Enable) 
        {
            string sql;
            sql = string.Format(@"select * from S_Material where RowState!={0} and State={1}", (int)RowState.Delete, (int)state);
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            return TableHelper.TableToList<SMaterial>(dt);
        } 

        public DataTable GetMaterialExport() 
        {
            string sql;
            sql = @"select Id as '物资编号',MaterialCode as '物资编码',MaterialName as '物资名称',PYMaterialName as '物资简称',
                    SpecName as '规格',Unit as '计量单位',UnitPrice as '单价'
                     from S_Material;";
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            return dt;
        }

        /// <summary>
        /// 根据物资编号删除物资信息
        /// </summary>
        /// <param name="materialId">物资编号</param>
        /// <returns></returns>
        public bool DeleteMaterial(string materialId)
        {
            string sql = string.Format(@"delete from S_Material where Id = '{0}'", materialId);
            return base.ExecuteSql(sql);
        }

        /// <summary>
        /// 保存物资信息
        /// </summary>
        /// <param name="material">物资信息实体类</param>
        /// <returns></returns>
        public bool SaveMaterial(SMaterial material)
        {
            bool isSaved = false;
            string sql = string.Empty;
            if (string.IsNullOrEmpty(material.Id))
            {
                material.Id = Util.Utility.GetGuid();
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = SqliteSqlUtil.GetSaveSql<SMaterial>(material, "S_Material");
                if (!string.IsNullOrEmpty(sql))
                {
                    isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
                }
            }
            else 
            {
                isSaved = service.Save<SMaterial>(material, material.Id);
            }
            return isSaved;
        }


        public void UpdateMaterialSyncState(int syncState, string materialId) 
        {
            string sql;
            sql = string.Format(@"update S_Material set SyncState={0} where Id='{1}' ", syncState, materialId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sqliteDb.ExecuteNonQuery(sql);
            }
            else
            {
                service.ExecuteNonQuery(sql);
            }
        }

        #endregion
    }
}
