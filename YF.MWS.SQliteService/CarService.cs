using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using System.Data;
using YF.Utility.Data;
using YF.MWS.Util;
using YF.Data.NHProvider;

using YF.MWS.BaseMetadata;
using YF.Utility;
using YF.MWS.Metadata;
using YF.Utility.Log;
using YF.MWS.Metadata.Dto;

namespace YF.MWS.SQliteService
{
    public class CarService : ICarService
    {
        private SqliteDb sqliteDb = new SqliteDb();
        private IService service = null;
        
        public CarService()
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                service = ServiceInitialization.DbService;
            }
        }

        #region ICarService 成员
        public SCar Add(string carNo) 
        {
            carNo = carNo.Trim().Replace(" ", "");
            if (!string.IsNullOrEmpty(carNo))
            {
                SCar find = GetByCarNo(carNo);
                if (find != null)
                    return find;
                SCar car = new SCar();
                car.Id = YF.MWS.Util.Utility.GetGuid();
                car.CarNo = carNo;
                car.CarType = "A1";
                Save(car);
                return car;
            }
            return null;
        }
        public bool Delete(string carId)
        {
            bool isDeleted = false;
            string sql = string.Format(@"delete from S_Car where Id='{0}'", carId);
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

        public DataTable GetExport() 
        {
            DataTable dt=null;
            string sql = @"select CarNo as '车牌号',CarType as '车辆类型',DriverName as '司机',LimitWeight as '限载(吨)',
                          Tare as '皮重(吨)' from S_Car;";
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

        public List<ImportResult> Import(List<SCar> lstCar, ImportMode mode) 
        {
            List<ImportResult> lstResult = new List<ImportResult>();
            List<SCar> lstExistCar = new List<SCar>();
            SCar find = null;
            bool isAdded = false;
            if (lstCar == null || lstCar.Count == 0)
                return lstResult;
            if (mode == ImportMode.New)
            {
                List<string> lstSql = new List<string>();
                lstSql.Add(string.Format(@"delete from S_Car"));
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sqliteDb.ExecuteNonQuery(lstSql);
                }
                else
                {
                    service.ExecuteNonQuery(lstSql);
                }
            }
            else 
            {
                lstExistCar = GetList();
            }
            if (lstExistCar == null)
                lstExistCar = new List<SCar>();
            foreach (SCar car in lstCar) 
            {
                if(lstExistCar != null && lstExistCar.Count > 0) 
                {
                    find = lstExistCar.Find(c => c.CarNo == car.CarNo);
                    if (find != null)
                        continue;
                }
                car.CreateTime = DateTime.Now;
                isAdded = Save(car);
                if (isAdded)
                {
                    lstExistCar.Add(car);
                    lstResult.Add(new ImportResult() { Success = true }); 
                }
                else
                    lstResult.Add(new ImportResult() { Success = false });
            }
            return lstResult;
        }

        public List<SCar> GetList()
        {
            string sql;
            sql = "select * from S_Car order by UpdateTime desc";
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
                return TableHelper.TableToList<SCar>(dt);
            }
            else
            {
                return null;
            }
        }

        public List<SCar> GetList(string carNoKey)
        {
            string sql;
            sql =string.Format("select * from S_Car where CarNo like '%{0}%' order by UpdateTime desc",carNoKey);
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
                return TableHelper.TableToList<SCar>(dt);
            }
            else
            {
                return null;
            }
        }

        public SCar Get(string carId)
        {
            SCar car = null;
            string sql;
            sql = string.Format(@"select * from S_Car where Id='{0}'", carId);
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
                car = TableHelper.RowToEntity<SCar>(dt.Rows[0]);
            }
            return car;
        }

        public List<SCar> GetUnSyncList()
        {
            string sql = string.Format(@"select top 100 * from S_Car where SyncState={0}", (int)SyncState.UnSynced);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"select   * from S_Car where SyncState={0} limit 0,100", (int)SyncState.UnSynced);
                return sqliteDb.GetObjectList<SCar>(sql);
            }
            else
            {
                return service.GetObjectList<SCar>(sql);
            }
        }

        public bool CarNoExist(string carNo,string carId)
        {
            bool isExist = false;
            string sql = string.Format("select count(1) from S_Car where CarNo='{0}' and Id!='{1}' ", carNo,carId);
            int rows = 0;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                rows = sqliteDb.ExecuteScalar(sql).ToInt();
            }
            else
            {
                rows = service.GetDataTable(sql).Rows[0][0].ToInt();
            }
            if (rows > 0)
            {
                isExist = true;
            }
            return isExist;
        }

        public SCar GetByCarNo(string carNo)
        {
            SCar car = null;
            string sql;
            sql = string.Format(@"select * from S_Car where CarNo='{0}'", carNo);
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
                car = TableHelper.RowToEntity<SCar>(dt.Rows[0]);
            }
            return car;
        }

        public SCar Get(string carId, string cardNo)
        {
            SCar car = null;
            string sql;
            sql = string.Format(@"select * from S_Car where Id = '{0}' and CardNo = '{1}'", carId, cardNo);
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
                car = TableHelper.RowToEntity<SCar>(dt.Rows[0]);
            }
            return car;
        }

        public bool Save(SCar car)
        {
            string sql;
            bool isSaved = false;
            if (car.CarNo.Length == 0) 
            {
                return isSaved;
            }
            if (string.IsNullOrEmpty(car.Id)) 
            {
                car.Id = YF.MWS.Util.Utility.GetGuid();
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = SqliteSqlUtil.GetSaveSql<SCar>(car, "S_Car");
                isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                isSaved = service.Save<SCar>(car, car.Id);
            }
            return isSaved;
        }

        public bool UpdateSyncState(BatchUpdate batch)
        {
            bool isUpdated = false;
            if (batch != null && batch.Ids != null)
            {
                string sql = string.Format(@"update S_Car set SyncState={0} where Id in({1})", (int)batch.State, SqlConditionUtil.GetArrayIn(batch.Ids));
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) 
                {
                    isUpdated = sqliteDb.ExecuteNonQuery(sql)>0;
                }
                else
                {
                    isUpdated = service.ExecuteNonQuery(sql);
                }
            }
            return isUpdated;
        }

        #endregion
    }
}
