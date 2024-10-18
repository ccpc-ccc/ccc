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
    public class MasterService :BaseService, IMasterService
    {
        #region IMasterService 成员
        //public MasterService(ConnectionStrings connection):base(connection) { }
        public MasterService():base() { }
        public bool Compress()
        {
            bool isCompressed = false;
            string sql = "VACUUM";
            isCompressed = sqliteDb.ExecuteNonQuery(sql) > 0;
            return isCompressed;
        }

        public void DataBackup(string backDir)
        {
            string dbName = YF.MWS.Util.Utility.GetDbName();
            if (!string.IsNullOrEmpty(backDir))
                backDir = @"D:\MWS\DataBack";
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                string procedureName = "SP_BackDb";
                if (!backDir.EndsWith("\\"))
                    backDir = backDir + "\\";
                List<DataParameter> lstParameter = new List<DataParameter>();
                DataParameter parameter1 = new DataParameter() { DataType = DbType.String, ParameterName = "@DbName", Val = dbName };
                DataParameter parameter2 = new DataParameter() { DataType = DbType.String, ParameterName = "@BackDir", Val = dbName };
                lstParameter.Add(parameter1);
                lstParameter.Add(parameter2);
                service.ExecuteStoredProcedure(procedureName, lstParameter);
            }
            else 
            {
                
                if (!Directory.Exists(backDir))
                    Directory.CreateDirectory(backDir);
                string fileName = string.Format("MWS_{0}.db",DateTime.Now.ToString("yyyyMMdd"));
                string backDbFileName = Path.Combine(backDir, fileName);

                File.Copy(dbName, backDbFileName,true);
            }
        }

        public bool DataPurge(int year) 
        {
            List<string> lstSql = new List<string>();
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                lstSql.Add(string.Format("delete from B_Weight where datepart(year,CreateTime)<={0}", year));
                lstSql.Add(string.Format("delete from B_WeightDetail where datepart(year,CreateTime)<={0}", year));
                lstSql.Add(string.Format("delete from B_WeightAttribute where datepart(year,CreateTime)<={0}", year));
                lstSql.Add(string.Format("delete from B_WeightQc where datepart(year,CreateTime)<={0}", year));
                lstSql.Add(string.Format("delete from B_WeightExt where datepart(year,CreateTime)<={0}", year));
                lstSql.Add(string.Format("delete from B_File where datepart(year,CreateTime)<={0}", year));
                lstSql.Add(string.Format("delete from B_Log where datepart(year,CreateTime)<={0}", year));
                lstSql.Add(string.Format("delete from B_PlanCard where datepart(year,CreateTime)<={0}", year));
                lstSql.Add(string.Format("delete from B_Pay where datepart(year,CreateTime)<={0}", year));
                lstSql.Add(string.Format("delete from B_WeightWareh where datepart(year,CreateTime)<={0}", year));

                //lstSql.Add(string.Format("delete from S_Customer where datepart(year,CreateTime)<={0}", year));
                //lstSql.Add(string.Format("delete from S_CustomerPrice where datepart(year,CreateTime)<={0}", year));
                //lstSql.Add(string.Format("delete from S_Car where datepart(year,CreateTime)<={0}", year));
                return service.ExecuteNonQuery(lstSql);
            }
            else
            {
                lstSql.Add(string.Format("delete from B_Weight where abs(strftime('%Y',CreateTime))<={0}", year));
                lstSql.Add(string.Format("delete from B_WeightDetail where abs(strftime('%Y',CreateTime))<={0}", year));
                lstSql.Add(string.Format("delete from B_WeightAttribute where abs(strftime('%Y',CreateTime))<={0}", year));
                lstSql.Add(string.Format("delete from B_WeightQc where abs(strftime('%Y',CreateTime))<={0}", year));
                lstSql.Add(string.Format("delete from B_WeightExt where abs(strftime('%Y',CreateTime))<={0}", year));
                lstSql.Add(string.Format("delete from B_File where abs(strftime('%Y',CreateTime))<={0}", year));
                lstSql.Add(string.Format("delete from B_Log where abs(strftime('%Y',CreateTime))<={0}", year));
                lstSql.Add(string.Format("delete from B_PlanCard where abs(strftime('%Y',CreateTime))<={0}", year));

                lstSql.Add(string.Format("delete from B_Task where abs(strftime('%Y',CreateTime))<={0}", year));
                lstSql.Add(string.Format("delete from B_WeightWareh where abs(strftime('%Y',CreateTime))<={0}", year));
                lstSql.Add(string.Format("delete from B_Pay where abs(strftime('%Y',CreateTime))<={0}", year));

                //lstSql.Add(string.Format("delete from S_Customer where abs(strftime('%Y',CreateTime))<={0}", year));
                //lstSql.Add(string.Format("delete from S_CustomerPrice where abs(strftime('%Y',CreateTime))<={0}", year));
                //lstSql.Add(string.Format("delete from S_Car where abs(strftime('%Y',CreateTime))<={0}", year));
                return sqliteDb.ExecuteNonQuery(lstSql) > 0;
            }
            
        }

        /// <summary>
        /// 清理数据库
        /// </summary>
        /// <returns></returns>
        public bool InitDb()
        {
            List<string> lstSql = new List<string>();
            lstSql.Add("delete from B_PlanCard");
            lstSql.Add("delete from B_CardPreset");
            lstSql.Add("delete from B_File");
            lstSql.Add("delete from B_Log");
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                lstSql.Add("delete from B_Task");
            }
            else 
            {
                lstSql.Add("delete from B_CarPark");
                lstSql.Add("delete from B_Park");
                lstSql.Add("delete from B_Plan");
                lstSql.Add("delete from B_PayRecord");
                lstSql.Add("delete from B_Qc");
                lstSql.Add("delete from B_Scan");
                lstSql.Add("delete from B_WeightConfirm");
                //lstSql.Add("delete from B_WeightOverload");
                lstSql.Add("delete from B_WeightReceive");
                lstSql.Add("delete from B_WeightWarning");
                lstSql.Add("delete from S_Ad");
                lstSql.Add("delete from S_Contract");
                lstSql.Add("delete from S_CustomerMaterial");
                lstSql.Add("delete from S_MaterialPrice");
                lstSql.Add("delete from S_MaterialSeries");
                lstSql.Add("delete from S_Staff");
            }
            lstSql.Add("delete from B_Pay");
            lstSql.Add("delete from B_Weight");
            lstSql.Add("delete from B_WeightAttribute");
            lstSql.Add("delete from B_WeightDetail");
            lstSql.Add("delete from B_WeightExt");
            lstSql.Add("delete from B_WeightQc");
            lstSql.Add("delete from B_WeightTemp");
            lstSql.Add("delete from S_AlgLibrary");
            lstSql.Add("delete from S_Car");
            lstSql.Add("delete from S_CardViewDtl");
            lstSql.Add("delete from S_Customer");
            lstSql.Add("delete from S_CustomerPrice");
            lstSql.Add("delete from S_Dept");
            lstSql.Add("delete from S_Device");
            lstSql.Add("delete from S_Material");
            lstSql.Add("delete from S_Wareh");

            bool isInited = false;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                isInited=service.ExecuteNonQuery(lstSql);
            }
            else
            {
                isInited = sqliteDb.ExecuteNonQuery(lstSql)>0;
            }
            return isInited;
        }

        public void ImportCode(List<SCode> codes) 
        {
            foreach (SCode code in codes)
                SaveCode(code);
        }

        public bool DeleteCode(string codeId)
        {
            bool isDeleted = false;
            string sql = string.Format(@"delete from S_Code where Id='{0}'", codeId);
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

        /// <summary>
        /// 根据部门Id获取部门信息
        /// </summary>
        /// <param name="deptId">部门Id</param>
        /// <returns></returns>
        public SDept GetDepart(string deptId)
        {
            SDept depart = null;
            string sql;
            sql = string.Format(@"select * from S_Dept where Id = '{0}'", deptId);
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
                depart = TableHelper.RowToEntity<SDept>(dt.Rows[0]);
            }
            return depart;
        }

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <returns></returns>
        public List<SDept> GetDeptList()
        {
            string sql;
            sql = "select *, (select CompanyName from S_Company where Id = S_Dept.CompanyId) as CompanyName, "
                + "(select ItemCaption from S_Code where ItemCode = S_Dept.DeptType) as DeptTypeName from S_Dept";
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                dt = service.GetDataTable(sql);
            }
            return TableHelper.TableToList<SDept>(dt);
        }

        /// <summary>
        /// 根据公司Id获取所有部门
        /// </summary>
        /// <param name="companyId">公司Id</param>
        /// <returns></returns>
        public DataTable GetDeptByCompanyId(string companyId)
        {
            string sql;
            sql = string.Format("select * from S_Dept where CompanyId = '{0}'", companyId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                return sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                return service.GetDataTable(sql);
            }
        }

        /// <summary>
        /// 根据公司Id获取部门列表
        /// </summary>
        /// <param name="companyId">公司Id</param>
        /// <returns></returns>
        public List<SDept> GetDeptListByCompany(string companyId)
        {
            string sql;
            sql = string.Format("select * from S_Dept where CompanyId = '{0}'", companyId);
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                dt = service.GetDataTable(sql);
            }
            return TableHelper.TableToList<SDept>(dt);
        }

        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="deptId">部门Id</param>
        /// <returns></returns>
        public bool DeleteDepart(string deptId)
        {
            bool isDeleted = false;
            string sql = string.Format(@"delete from S_Dept where Id = '{0}'", deptId);
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

        public SCode GetCode(string codeId)
        {
            SCode code = null;
            string sql;
            sql = string.Format(@"select * from S_Code where Id='{0}'", codeId);
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
                code = TableHelper.RowToEntity<SCode>(dt.Rows[0]);
            }
            return code;
        }

        /// <summary>
        /// 根据编码获取系统编码
        /// </summary>
        /// <param name="codeNo">编码</param>
        /// <returns></returns>
        public SCode GetCodeByCodeNo(string codeNo)
        {
            SCode code = null;
            string sql;
            sql = string.Format(@"select * from S_Code where ItemCode='{0}'", codeNo);
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
                code = TableHelper.RowToEntity<SCode>(dt.Rows[0]);
            }
            return code;
        }

        public bool CustomerExist(string type,string customerName, string customerId)
        {
            bool isExist = false;
            string sql = string.Format("select count(Id) from S_Customer where CustomerType='{0}' and CustomerName='{1}' and Id!='{2}' ", type, customerName, customerId);
            return sqliteDb.ExecuteScalar(sql).ToInt() > 0;
        }

        public SCustomer GetCustomer(string customerId)
        {
            SCustomer customer = new SCustomer();
            string sql;
            sql = string.Format("select * from S_Customer where Id='{0}'",customerId);
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
                customer = TableHelper.RowToEntity<SCustomer>(dt.Rows[0]);
            }
            return customer;
        }

        public List<SCustomer> GetSyncCustomer(BWeight weight) 
        {
            List<SCustomer> lstCustomer = new List<SCustomer>();
            string sql;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" and ((Id='{0}' and SyncState=0) or (Id='{1}' and SyncState=0) or (Id='{2}' and SyncState=0) or (Id='{3}' and SyncState=0))",
                                       weight.CustomerId, weight.SupplierId, weight.DeliveryId, weight.ReceiverId);
            sql = string.Format("SELECT 	* FROM S_Customer  WHERE 	1 = 1 {0}",sb.ToString());
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
                lstCustomer = TableHelper.TableToList<SCustomer>(dt);
            }
            return lstCustomer;
        }

        public DataTable GetCustomerTable(string customerId) 
        {
            string sql;
            sql = string.Format("select * from S_Customer where Id='{0}'", customerId);
            DataTable dt;
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

        public SCustomer GetCustomerByName(CustomerType customerType,string customerName)
        {
            SCustomer customer = null;
            string sql;
            sql = string.Format("select * from S_Customer where CustomerType='{0}' and CustomerName='{1}'", customerType,customerName);
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
                customer = TableHelper.RowToEntity<SCustomer>(dt.Rows[0]);
            }
            return customer;
        }

        public SCustomer GetCustomerByIdCard(CustomerType customerType, string idCardNo)
        {
            SCustomer customer = null;
            string sql = string.Format("select * from S_Customer where CustomerType='{0}' and IdCard='{1}'", customerType, idCardNo);
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
                customer = TableHelper.RowToEntity<SCustomer>(dt.Rows[0]);
            }
            return customer;
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

        public DataTable GetCustomerByCustomerType(CustomerType customerType)
        {
            string sql;
            sql = string.Format(@"select CustomerCode as '客户编号',CustomerName as '客户名称',Contracter as '联系人',Tel as '电话号码',Addr as '地址'
                                            from S_Customer where CustomerType='{0}' and RowState!={1}", customerType.ToString(),(int)RowState.Delete);
            DataTable dt;
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

        public List<SCode> GetList(string parentNo = null) {
            string sql = "select * from S_Code order by OrderNo";
            if (parentNo != null) {
                sql = string.Format("select * from S_Code where ItemCode like '%{0}%' and (ParentId is null or ParentId='') union " +
                    "select * from S_Code where ParentId in (select Id from S_Code where ItemCode like '%{0}%' and (ParentId is null or ParentId='')) order by OrderNo", parentNo);
            }
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                dt = service.GetDataTable(sql);
            }
            return TableHelper.TableToList<SCode>(dt);
        }

        public List<SCode> GetList(int systemFlag)
        {
            string sql;
            sql = string.Format("select * from S_Code  where SystemFlag={0}  order by OrderNo",systemFlag);
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                dt = service.GetDataTable(sql);
            }
            return TableHelper.TableToList<SCode>(dt);
        }


        public bool SaveCode(SCode code)
        {
            bool isSaved = false;
            string sql;
            if (string.IsNullOrEmpty(code.Id))
            {
                code.Id = YF.MWS.Util.Utility.GetGuid(); 
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = SqliteSqlUtil.GetSaveSql<SCode>(code, "S_Code");
                isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                isSaved = service.Save<SCode>(code, code.Id);
            }
            return isSaved;
        }

        public bool SaveCode(SCode code, string parentCode)
        {
            bool isSaved = false;
            if (string.IsNullOrEmpty(parentCode))
                return isSaved;
            SCode parent = null;
            string sql;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format("select * from S_Code where ItemCode='{0}' and (length(ParentId)=0 or ParentId is null)", parentCode);
            }
            else
            {
                sql = string.Format("select * from S_Code where ItemCode='{0}' and (len(ParentId)=0 or ParentId is null)", parentCode);
            }
            DataTable dt = service.GetDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                parent = TableHelper.RowToEntity<SCode>(dt.Rows[0]);
            }
            if (parent != null)
            {
                code.ParentId = parent.Id;
                sql = string.Format("select count(1) from S_Code where ParentId='{0}' and ItemCaption='{1}'",
                    code.ParentId, code.ItemCaption);
                dt = service.GetDataTable(sql);
                int rows = 0;
                if (dt != null)
                {
                    rows = dt.Rows[0][0].ToInt();
                }
                if (rows == 0)
                {
                    isSaved = SaveCode(code);
                }
            }
            return isSaved;
        }

        public bool SaveCustomer(SCustomer customer)
        {
            bool isSaved = false;
            customer.SyncState = 0;
            if (string.IsNullOrEmpty(customer.Id)) 
            {
                customer.Id = YF.MWS.Util.Utility.GetGuid();
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                string sql = string.Empty;
                sql = SqliteSqlUtil.GetSaveSql<SCustomer>(customer, "S_Customer");
                if (!string.IsNullOrEmpty(sql))
                {
                    isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
                }
            }
            else 
            {
                isSaved = service.Save<SCustomer>(customer,customer.Id);
            }
            return isSaved;
        }


        public List<SCode> GetSubList(string code)
        {
            string sql;
            sql = string.Format("select * from S_Code where ParentId in(select Id from S_Code where ItemCode='{0}') order by OrderNo", code);
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                dt = service.GetDataTable(sql);
            }
            return TableHelper.TableToList<SCode>(dt);
        } 

        /// <summary>
        /// 保存部门信息
        /// </summary>
        /// <param name="depart">部门信息实体类</param>
        /// <returns></returns>
        public bool SaveDepart(SDept depart)
        {
            bool isSaved = false;
            if (string.IsNullOrEmpty(depart.Id))
            {
                depart.Id = Util.Utility.GetGuid();
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                string sql = string.Empty; 
                sql = SqliteSqlUtil.GetSaveSql<SDept>(depart, "S_Dept");
                if (!string.IsNullOrEmpty(sql))
                {
                    isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
                }
            }
            else 
            {
                isSaved = service.Save<SDept>(depart, depart.Id);
            }
            return isSaved;
        }


        public void UpdateCustomerSyncState(int syncState,string customerId)
        {
            string sql;
            sql=string.Format(@"update S_Customer set SyncState={0} where Id='{1}' ",syncState,customerId);
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
