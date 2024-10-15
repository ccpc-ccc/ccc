using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Util;
using YF.Utility.Data;
using YF.Utility;
using YF.MWS.Metadata.Query;
using YF.Utility.Log;
using YF.MWS.Metadata.Cfg;
using YF.MWS.BaseMetadata;
using YF.Data.NHProvider;
using FluentData;
using YF.Utility.Language;
using static System.Windows.Forms.AxHost;

namespace YF.MWS.SQliteService
{
    /// <summary>
    /// 称重存储类
    /// Author:闫孝感
    /// Date:2024-10-14
    /// </summary>
    public class WeightService : BaseService,IWeightService {
        private IMasterService masterService = new MasterService();
        private IMaterialService materialService = new MaterialService();
        private ICarService carService = new CarService();
        private IPayService payService = new PayService();
        private IWarehService warehService = new WarehService();
        private IWeightQueryService weightQueryService = new WeightQueryService();
        private IUserService userService=new UserService();
        private ISeqNoService seqNoService = new SeqNoService();

        #region private methods
        private List<SCar> HandleCar(DataTable dt) 
        {
            if(!dt.Columns.Contains("车牌号")) return null;
            List<SCar> oldCars = null;
            oldCars = carService.GetList();
            bool isSaved = false;
            if (oldCars == null)
                oldCars = new List<SCar>();
            int columnIndex = 1;
            foreach (DataRow dr in dt.Rows) 
            {
                if (dr[columnIndex] != null && dr[columnIndex].ToObjectString().Length > 0 && !oldCars.Exists(c => c.CarNo == dr[columnIndex].ToObjectString())) 
                {
                    SCar car = new SCar();
                    car.Id = Util.Utility.GetGuid();
                    car.CarNo = dr["车牌号"].ToObjectString();
                    car.CarType = CarType.Out.ToString();
                    isSaved = carService.Save(car);
                    if (isSaved) 
                    {
                        oldCars.Add(car);
                    }
                }
            }
            return carService.GetList();
        }

        private List<SCustomer> HandleCustomer(DataTable dt, CustomerType type) 
        {
            List<SCustomer> oldCustomers = masterService.GetCustomerList(type);
            if (oldCustomers == null)
                oldCustomers = new List<SCustomer>();
            bool isSaved = false;
            string columnName = type.ToDescription();
            if (!dt.Columns.Contains(columnName)) return null;
            foreach (DataRow dr in dt.Rows) 
            {
                if (dr[columnName] != null && dr[columnName].ToObjectString().Length > 0
                    && !oldCustomers.Exists(c => c.CustomerName == dr[columnName].ToObjectString())) 
                {
                    SCustomer customer = new SCustomer();
                    customer.CustomerType = type.ToString();
                    customer.CustomerName = dr[columnName].ToObjectString();
                    customer.CustomerCode = PinYinUtil.GetInitial(customer.CustomerName);
                    customer.PYCustomerName = PinYinUtil.GetPinYin(customer.CustomerName);
                    customer.Id = Util.Utility.GetGuid();
                    isSaved = masterService.SaveCustomer(customer);
                    if (isSaved) 
                    {
                        oldCustomers.Add(customer);
                    }
                }
            }
            return masterService.GetCustomerList(type);
        }

        private List<SWareh> HandleWareh(DataTable dt) 
        {
            List<SWareh> oldWarehs = null;
            oldWarehs = warehService.GetList();
            if (oldWarehs == null)
                oldWarehs = new List<SWareh>();
            bool isSaved = false;
            int columnIndex = 7;
            foreach (DataRow dr in dt.Rows) 
            {
                if (dr[columnIndex] != null && dr[columnIndex].ToObjectString().Length > 0 
                    && !oldWarehs.Exists(c => c.WarehName == dr[columnIndex].ToObjectString())) 
                {
                    SWareh wareh = new SWareh();
                    wareh.WarehName = dr[5].ToObjectString();
                    wareh.Id = Util.Utility.GetGuid();
                    wareh.WarehCode = PinYinUtil.GetInitial(wareh.WarehName);
                    isSaved = warehService.Save(wareh);
                    if (isSaved)
                    {
                        oldWarehs.Add(wareh);
                    }
                }
            }
            return warehService.GetList();
        }

        private List<SMaterial> HandleMaterial(DataTable dt) 
        {
            List<SMaterial> oldMaterials = new List<SMaterial>();
            oldMaterials = materialService.GetMaterialList();
            bool isSaved = false;
            if (oldMaterials == null)
                oldMaterials = new List<SMaterial>();
            int columnIndex = 5;
            int specColumnIndex = 6;
            foreach (DataRow dr in dt.Rows) 
            {
                if (dr[columnIndex] != null && dr[columnIndex].ToObjectString().Length > 0 
                    && !oldMaterials.Exists(c => c.MaterialName == dr[columnIndex].ToObjectString())) 
                {
                    SMaterial material = new SMaterial();
                    material.MaterialName = dr[columnIndex].ToObjectString();
                    material.MaterialCode = PinYinUtil.GetInitial(material.MaterialName);
                    material.PYMaterialName = PinYinUtil.GetPinYin(material.MaterialName);
                    material.SpecName = dr[specColumnIndex].ToObjectString();
                    material.State = 1;
                    material.Unit="Kg";
                    material.Id = Util.Utility.GetGuid();
                    isSaved = materialService.SaveMaterial(material);
                    if (isSaved)
                    {
                        oldMaterials.Add(material);
                    }
                }
            }
            return materialService.GetMaterialList();
        }

        private string GetDeleteWeightDetail(WeightType type, string weightId)
        {
            string sql;
            List<string> lstSql = new List<string>();
            sql = string.Format(@"delete from B_WeightDetail where WeightId='{0}' and WeightType={1}", weightId, (int)type);
            lstSql.Add(sql);
            return sql;
        }

        private void SaveAttribute(string weightId, List<BWeightAttribute> lst)
        {
            if (lst != null && lst.Count > 0)
            {
                List<string> lstSql = new List<string>();
                lstSql.Add(string.Format("delete from B_WeightAttribute where WeightId='{0}'", weightId)); 
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    foreach (BWeightAttribute attr in lst)
                    {
                        lstSql.Add(SqliteSqlUtil.GetSaveSql<BWeightAttribute>(attr, "B_WeightAttribute"));
                    }
                    sqliteDb.ExecuteNonQuery(lstSql);
                }
                else 
                {
                    service.ExecuteNonQuery(lstSql);
                    foreach (BWeightAttribute attr in lst)
                    {
                        service.Save<BWeightAttribute>(attr,attr.AttributeId);
                    }
                }
            }
        }

        #endregion 
 

        /// <summary>
        /// 物理删除磅单
        /// </summary>
        /// <param name="weightId">磅单Id</param>
        /// <returns></returns>
        public bool DeleteWeight(BWeight weight)
        {
            bool isDeleted = false;
            IFileService fileService = new FileService();
            string sql = string.Empty;
            List<string> lstSql = new List<string>(); 
            sql = string.Format(@"DELETE FROM B_Weight  WHERE Id = '{0}'", weight.Id);
            lstSql.Add(sql);
            sql = string.Format(@"DELETE FROM B_WeightDetail  WHERE Id = '{0}'", weight.Id);
            lstSql.Add(sql);
            sql = string.Format(@"DELETE FROM B_WeightAttribute  WHERE Id = '{0}'", weight.Id);
            lstSql.Add(sql);
            sql = string.Format(@"DELETE FROM B_WeightExt  WHERE Id = '{0}'", weight.Id);
            lstSql.Add(sql);
            sql = string.Format(@"DELETE FROM B_WeightQc  WHERE Id = '{0}'", weight.Id);
            lstSql.Add(sql);
            sql = string.Format(@"DELETE FROM B_Pay  WHERE Id = '{0}'", weight.Id);
            lstSql.Add(sql);
            if (weight.RowState != 3) {
                decimal dw = weight.d2;
                if (weight.d2 <= 0) dw = weight.SuttleWeight;
                if (weight.WarehBizType == WarehBizType.ChuKu.ToObjectString()) {
                    sql = string.Format(@"update S_Material SET Quantity=Quantity+{0} where Id='{1}'", dw, weight.MaterialId);
                    lstSql.Add(sql);
                }else if(weight.WarehBizType == WarehBizType.RuKu.ToObjectString()) {
                    sql = string.Format(@"update S_Material SET Quantity=Quantity-{0} where Id='{1}'", dw, weight.MaterialId);
                    lstSql.Add(sql);
                }
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isDeleted= sqliteDb.ExecuteNonQuery(lstSql) > 0; 
            }
            else 
            {
                isDeleted= service.ExecuteNonQuery(lstSql);
            }
            if (isDeleted)
            {
                fileService.DeleteBatch(weight.Id);
            }
            return isDeleted;
        }
        public bool DeleteWeightDetail(WeightType type, string weightId) 
        {
            bool isDeleted = false;
            string sql;
            List<string> lstSql = new List<string>();
            sql = string.Format(@"delete from B_WeightDetail where WeightId='{0}' and WeightType={1}", weightId, (int)type);
            lstSql.Add(sql);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                //isDeleted = sqliteDb.ExecuteNonQuery(lstSql) > 0;
            }
            else
            {
                isDeleted = service.ExecuteNonQuery(lstSql);
            }
            return isDeleted;
        }

        public SyncWeight GetTWeight(string weightId)
        {
            SyncWeight weight = new SyncWeight();
            weight.Weight = Get(weightId);
            weight.TareWeight = GetDetail(weightId, WeightType.Tare);
            weight.GrossWeight = GetDetail(weightId, WeightType.Gross);
            return weight;
        }

        public bool UpdateWeight(string weightId, RowState state)
        {
            bool isUpdated = false;
            string sql = string.Empty;
            sql = string.Format("select * from B_Weight where Id = '{0}'", weightId);
            DataTable dt = GetTable(sql);
            BWeight weight = null;
            if (dt != null && dt.Rows.Count > 0) {
             weight = TableHelper.RowToEntity<BWeight>(dt.Rows[0]);
            }
            List<string> lstSql = new List<string>();
            if (weight != null&&state==RowState.Delete) {
                decimal dw = weight.SuttleWeight;
                if (weight.d2 > 0) dw = weight.d2;
                SMaterial material = materialService.GetMaterial(weight.MaterialId);
                if (material != null) {
                    if (weight.WarehBizType == "RuKu") {
                        material.Quantity = material.Quantity - dw;
                    } else if (weight.WarehBizType == "ChuKu") {
                        material.Quantity = material.Quantity + dw;
                    }
                    materialService.SaveMaterial(material);
                }
            }
            sql = string.Format(@"UPDATE B_Weight SET RowState = '{1}' WHERE Id = '{0}'", weightId, (int)state);
            lstSql.Add(sql);
            sql = string.Format(@"UPDATE B_WeightDetail SET RowState = '{1}' WHERE Id = '{0}'", weightId, (int)state);
            lstSql.Add(sql);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isUpdated = sqliteDb.ExecuteNonQuery(lstSql) > 0;
            }
            else
            {
                isUpdated = service.ExecuteNonQuery(lstSql);
            }
            if (isUpdated)
            {
                payService.UpdateRowState(state, weightId);
            }
            return isUpdated;
        }

        public DataTable GetWeighter() 
        {
            DataTable dt;
            string sql;
            sql = "select distinct WeighterName from B_Weight ";
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

        public int GetWeightCountByMaterial(string materialId)
        {
            int count = 0;
            string sql = string.Format(@"select count(*) from B_Weight where MaterialId='{0}'", materialId);
            object scalar = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                scalar = sqliteDb.ExecuteScalar(sql);
            }
            else
            {
                scalar = service.GetScalar(sql);
            }
            if (scalar != null)
                count = Convert.ToInt32(scalar);
            return count;
        }

        /// <summary>
        /// 获取当天的所有磅单列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTodayList()
        {
            DataTable dt;
            DateTime dtNow = DateTime.Now.AddDays(1);
            string sql;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"select Id,WeightNo,TareWeight,GrossWeight,SuttleWeight,NetWeight,
                       CreateTime as WeightTime from B_Weight where CreateTime >=datetime('{0}') and  CreateTime <datetime('{1}') and RowState != '{2}'",
                            DateTime.Now.ToString("yyyy-MM-dd 00:00:00"), dtNow.ToString("yyyy-MM-dd 00:00:00"), (int)RowState.Delete);
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                sql = string.Format(@"select Id,WeightNo,TareWeight,GrossWeight,SuttleWeight,NetWeight,
                       CreateTime as WeightTime from B_Weight where CreateTime >= '{0}' and  CreateTime < '{1}'  and RowState != '{2}'",
                DateTime.Now.ToString("yyyy-MM-dd 00:00:00"), dtNow.ToString("yyyy-MM-dd 00:00:00"), (int)RowState.Delete);
                dt = service.GetDataTable(sql);
            }
            return dt;
        }

        public List<BWeight> GetUploadList() 
        {
            List<BWeight> lstWeight = new List<BWeight>();
            DataTable dt;
            string sql;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"select Id,WeightNo,TareWeight,GrossWeight,SuttleWeight,NetWeight,OverWeight,
                                          CreateTime as WeightTime from B_Weight where SyncState={0} order by CreateTime desc limit 0,100", (int)SyncState.UnSynced);
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                sql = string.Format(@"select top 100 Id,WeightNo,TareWeight,GrossWeight,SuttleWeight,NetWeight,OverWeight,
                                            CreateTime as WeightTime from B_Weight where SyncState={0} order by CreateTime desc", (int)SyncState.UnSynced);
                dt = service.GetDataTable(sql);
            }
            lstWeight = TableHelper.TableToList<BWeight>(dt);
            return lstWeight;
        }

        public List<BWeight> GetTodayWeightList(string carNo)
        {
            List<BWeight> lstWeight = new List<BWeight>();
            DataTable dt;
            DateTime dtNow = DateTime.Now.AddDays(1);
            string sql;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"select Id,WeightNo,TareWeight,GrossWeight,SuttleWeight,NetWeight,OverWeight,
                                          CreateTime as WeightTime from B_Weight where LOWER(CarNo) = LOWER('{0}') and CreateTime >=datetime('{1}') 
                                          and  CreateTime <datetime('{2}') and RowState != '{3}'",
                                          carNo, DateTime.Now.ToString("yyyy-MM-dd 00:00:00"), dtNow.ToString("yyyy-MM-dd 00:00:00"), (int)RowState.Delete);
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                sql = string.Format(@"select Id,WeightNo,TareWeight,GrossWeight,SuttleWeight,NetWeight,OverWeight,
                                            CreateTime as WeightTime from B_Weight where CarNo = '{0}' and CreateTime >= '{1}' and  CreateTime < '{2}'  and RowState != '{3}'",
                                            carNo, DateTime.Now.ToString("yyyy-MM-dd 00:00:00"), dtNow.ToString("yyyy-MM-dd 00:00:00"), (int)RowState.Delete);
                dt = service.GetDataTable(sql);
            }
            lstWeight = TableHelper.TableToList<BWeight>(dt);
            return lstWeight;
        }

        /// <summary>
        /// 获取当前日期的磅单记录总数
        /// </summary>
        /// <returns></returns>
        public int GetCurrentDateCount()
        {
            int count = 0;
            DataTable dt;
            DateTime dtNow = DateTime.Now.AddDays(1);
            string sql;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"select count(1) from B_Weight where CreateTime >=datetime('{0}') and  CreateTime <datetime('{1}') ",
                            DateTime.Now.ToString("yyyy-MM-dd 00:00:00"), dtNow.ToString("yyyy-MM-dd 00:00:00"));
                dt = sqliteDb.ExecuteDataTable(sql);
                count = dt.Rows[0][0].ToInt();
            }
            else 
            {
                sql = string.Format(@"select count(1) from B_Weight where CreateTime >='{0}' and  CreateTime <'{1}' ",
                DateTime.Now.ToString("yyyy-MM-dd 00:00:00"), dtNow.ToString("yyyy-MM-dd 00:00:00"));
                dt = service.GetDataTable(sql);
                count = dt.Rows[0][0].ToInt();
            }
            return count;
        }

        public BWeightDetail GetDetail(string weightId, WeightType type)
        {
            BWeightDetail detail = null;
            string sql;
            sql = string.Format(@"select * from B_WeightDetail where WeightId='{0}' and WeightType='{1}'", weightId, (int)type);
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
                detail = TableHelper.RowToEntity<BWeightDetail>(dt.Rows[0]);
            }
            return detail;
        }


        /// <summary>
        /// 获取当前的磅单列表
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <param name="syncState">0:未同步 1:已同步 2:所有状态</param>
        /// <returns></returns>
        public List<QWeight> GetList(DateTime dtStart, DateTime dtEnd, int syncState)
        {
            List<QWeight> lst = new List<QWeight>();
            StringBuilder sbCondition = new StringBuilder();
            sbCondition.AppendFormat(" where a.RowState != '{0}' ", (int)RowState.Delete);
            if (dtStart != DateTime.MinValue)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sbCondition.AppendFormat("and a.FinishTime>=datetime('{0}') ", dtStart.ToString("yyyy-MM-dd 00:00:00"));
                }
                else 
                {
                    sbCondition.AppendFormat("and a.FinishTime>= '{0}' ", dtStart.ToString("yyyy-MM-dd 00:00:00"));
                }
            }
            if (dtEnd != DateTime.MinValue)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sbCondition.AppendFormat("and a.FinishTime<datetime('{0}') ", dtEnd.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                }
                else 
                {
                    sbCondition.AppendFormat("and a.FinishTime<'{0}' ", dtEnd.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                }
            }
            //sbCondition.AppendFormat("and a.FinishState='{0}'", (int)FinishState.Finished);
            if (syncState != 2)
            {
                sbCondition.AppendFormat("and a.SyncState='{0}'", syncState);
            }
            string sql;
            sql = string.Format(@"select a.SyncState,a.Id as WeightId,GrossWeight,SuttleWeight,TareWeight,NetWeight,OverWeight,OverWeightState,UnitCharge,RealCharge,
                                            AxleCount,MaterialModel,a.FinishTime,a.FinishState,a.WeightProcess,a.PrintCount,b.FullName as Weighter,
                                            a.CreateTime,a.WeightNo,a.CarNo,d.CustomerName as ReceiverName,e.MaterialName,f.CustomerName as DeliveryName,
                                                  g.CustomerName as CustomerName
                                                 from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                                left join S_Customer d on a.ReceiverId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id 
                                                 left join S_Customer f on a.DeliveryId=f.Id 
                                                 left join S_Customer g on a.CustomerId=g.Id {0} order by a.FinishTime desc", sbCondition);
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
                lst = TableHelper.TableToList<QWeight>(dt);
            } 
            return lst;
        }
         

        /// <summary>
        /// 获取当前的磅单列表
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <param name="finishState">0:未完成 1:已完成 2:所有状态</param>
        /// <returns></returns>
        public List<QWeight> GetList(DateTime dtStart, DateTime dtEnd, int finishState, int overWegihtState)
        {
            List<QWeight> lst = new List<QWeight>();
            StringBuilder sbCondition = new StringBuilder();
            sbCondition.AppendFormat(" where a.RowState != '{0}' ", (int)RowState.Delete);
            if (dtStart != DateTime.MinValue)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sbCondition.AppendFormat("and a.FinishTime>=datetime('{0}') ", dtStart.ToString("yyyy-MM-dd 00:00:00"));
                }
                else 
                {
                    sbCondition.AppendFormat("and a.FinishTime>='{0}' ", dtStart.ToString("yyyy-MM-dd 00:00:00"));
                }
            }
            if (dtEnd != DateTime.MinValue)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sbCondition.AppendFormat("and a.FinishTime<datetime('{0}') ", dtEnd.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                }
                else 
                {
                    sbCondition.AppendFormat("and a.FinishTime<'{0}' ", dtEnd.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                }
            }
            if (finishState != 2)
            {
                sbCondition.AppendFormat("and a.FinishState='{0}'", finishState);
            }
            if (overWegihtState != 2)
            {
                if (overWegihtState == 0)
                {
                    sbCondition.Append("and a.OverWeight<=0");
                }
                else
                {
                    sbCondition.Append("and a.OverWeight>0");
                }
            }
            string sql;
            sql = string.Format(@"select a.Id as WeightId,GrossWeight,SuttleWeight,TareWeight,NetWeight,MaxWeight,OverWeight,OverWeightState,UnitCharge,RealCharge,
                                              a.WeightProcess,AxleCount,MaterialModel,a.FinishTime,a.FinishState,a.PrintCount,b.FullName as Weighter,a.CreateTime,
                                                a.WeightNo,a.CarNo,d.CustomerName as ReceiverName,e.MaterialName,f.CustomerName as DeliveryName,g.CustomerName as CustomerName,
                                                i.FreightSettleState,i.PaymentSettleState 
                                                 from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                                left join S_Customer d on a.ReceiverId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id 
                                                 left join S_Customer f on a.DeliveryId=f.Id 
                                                 left join S_Customer g on a.CustomerId=g.Id 
                                                 left join B_WeightExt i on a.Id=i.Id
                                                 {0} order by a.WeightNo desc", sbCondition);
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
                lst = TableHelper.TableToList<QWeight>(dt);
            } 
            return lst;
        }

        public DataTable GetList(string where) {
            string sql = "select a.*,b.MaterialName from B_Weight a left join S_Material b on a.MaterialId=b.MaterialId";
            if (where != "" && where != "") {
                sql += " where 1=1 "+where;
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                return sqliteDb.ExecuteDataTable(sql);
            } else {
                return service.GetDataTable(sql);
            }
        }
        /// <summary>
        /// 根据磅单ID获取明细列表
        /// </summary>
        /// <param name="weightId"></param>
        /// <returns></returns>
        public DataTable GetDetailList(string weightId)
        {
            DataTable dt;
            DateTime dtNow = DateTime.Now.AddDays(1);
            string sql; 
            sql = string.Format(@"select b.FullName as Weighter,TareWeight,GrossWeight,SuttleWeight,
                        WeightTime from B_WeightDetail a left join S_User b on a.WeighterId=b.Id where a.Id='{0}' order by WeightTime desc",
                        weightId);
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

        public BWeight Get(string weightId)
        {
            string sql = string.Format(@"select * from B_Weight where Id='{0}'", weightId);
            return base.getModel<BWeight>(sql);
        }
        public VWeight GetAll(string weightId)
        {
            string sql = string.Format(@"select a.*,b.MaterialName,b.MaterialCode,c.WarehName,d.CustomerName CustomerName,
                                        e.CustomerName DeliveryName,f.CustomerName ReceiverName,g.CustomerName TransferName,j.CustomerName ManufacturerName,k.CustomerName SupplierName
                                        from B_Weight a left join S_Material b on a.MaterialId=b.Id 
                                                 left join S_Wareh c on a.WarehId=c.Id
                                                 left join S_Customer d on a.CustomerId=d.Id 
                                                 left join S_Customer e on a.DeliveryId=e.Id  
                                                 left join S_Customer f on a.ReceiverId=f.Id 
                                                 left join S_Customer g on a.TransferId=g.Id 
                                                 left join S_Customer j on a.ManufacturerId=j.Id 
                                                 left join S_Customer k on a.SupplierId=k.Id  where a.Id='{0}'", weightId);
            return base.getModel<VWeight>(sql);
        }

        public BWeight GetLastWeight()
        {
            BWeight weight = null;
            string sql;
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = "select * from B_Weight  order by CreateTime desc limit 0,1";
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                sql = "select top 1 * from B_Weight  order by CreateTime desc";
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                weight = TableHelper.RowToEntity<BWeight>(dt.Rows[0]);
            }
            return weight;
        }

        public List<BWeightAttribute> GetAttributeList(string weightId)
        {
            List<BWeightAttribute> lst = new List<BWeightAttribute>();
            string sql;
            sql = string.Format("select * from B_WeightAttribute where WeightId='{0}'", weightId);
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
                lst = TableHelper.TableToList<BWeightAttribute>(dt);
            }
            return lst;
        }

        public List<QDriver> GetDriverList()
        {
            List<QDriver> lstDriver = new List<QDriver>();
            string sql;
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = "SELECT DISTINCT a.DriverName from B_Weight a where length(DriverName)>0";
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                sql = "SELECT DISTINCT a.DriverName from B_Weight a where len(DriverName)>0";
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                lstDriver = TableHelper.TableToList<QDriver>(dt);
            }
            return lstDriver;
        }

        /// <summary>
        /// 根据车辆ID获取最近时间一条未完成的称重记录
        /// </summary>
        /// <param name="carNo">车Id</param>
        /// <returns></returns>
        public BWeight GetUnFinishedByCarId(string carId)
        {
            BWeight weight = null;
            string sql;
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"select * from B_Weight where LOWER(CarId) = LOWER('{0}') and FinishState=0 and RowState!='{1}' 
                             order by CreateTime desc limit 0,1", carId, (int)RowState.Delete);
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                sql = string.Format(@"select top 1 * from B_Weight where CarId= '{0}' and FinishState=0 and RowState!='{1}' 
                             order by CreateTime desc", carId, (int)RowState.Delete);
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                weight = TableHelper.RowToEntity<BWeight>(dt.Rows[0]);
            }
            return weight;
        }

        public BWeight GetUnFinishedByCardNo(string cardNo)
        {
            BWeight weight = null;
            string sql;
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"select * from B_Weight where LOWER(CardNo) = LOWER('{0}') and FinishState=0 and RowState!='{1}' 
                             order by CreateTime desc limit 0,1", cardNo, (int)RowState.Delete );
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                sql = string.Format(@"select top 1 * from B_Weight where CardNo= '{0}' and FinishState=0 and RowState!='{1}' 
                             order by CreateTime desc", cardNo, (int)RowState.Delete);
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                weight = TableHelper.RowToEntity<BWeight>(dt.Rows[0]);
            }
            return weight;
        }

        /// <summary>
        /// 根据卡号获取最近时间一条未完成的称重记录
        /// </summary>
        /// <param name="carNo">车Id</param>
        /// <returns></returns>
        public BWeight GetUnFinishedByCardNo(string cardNo, WeightProcess process)
        {
            BWeight weight = null;
            string sql;
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"select * from B_Weight where LOWER(CardNo) = LOWER('{0}') and FinishState=0 and RowState!='{1}'  and WeightProcess={2}
                             order by CreateTime desc limit 0,1", cardNo, (int)RowState.Delete, (int)process);
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                sql = string.Format(@"select top 1 * from B_Weight where CardNo= '{0}' and FinishState=0 and RowState!='{1}'  and WeightProcess={2}
                             order by CreateTime desc", cardNo, (int)RowState.Delete, (int)process);
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                weight = TableHelper.RowToEntity<BWeight>(dt.Rows[0]);
            }
            return weight;
        }

        public List<BWeight> GetUnFinishedList(DateTime startTime)
        {
            string sql = string.Format(@"select * from B_Weight where FinishState={0} and RowState!={1} and CreateTime<'{2}'",
                                                        (int)FinishState.Unfinished, (int)RowState.Delete, startTime.ToString("yyyy-MM-dd HH:mm:ss"));
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                return sqliteDb.GetObjectList<BWeight>(sql);
            }
            else
            {
                return service.GetObjectList<BWeight>(sql);
            }
        }

        public string GetUnFinishedWeightId(string attributeName, string attributeValue,string subjectId) 
        {
            string weightId = string.Empty;
            string sql;
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"select distinct c.[Id] as Weight  from B_WeightAttribute a inner join S_Attribute b on a.[AttributeId]=b.[Id] and b.[SubjectId]='{0}'
                                  inner join B_Weight c on a.[WeightId]=c.[Id] where c.[FinishState]=0 and c.[RowState]!='{1}' and b.[AttributeName]='{2}' and a.[AttributeValue] = '{3}'
                                  order by c.[FinishTime] desc limit 0,1", subjectId, (int)RowState.Delete,attributeName,attributeValue);
                dt = sqliteDb.ExecuteDataTable(sql);

            }
            else
            {
                sql = string.Format(@"select top 1 c.[Id] as Weight  from B_WeightAttribute a inner join S_Attribute b on a.[AttributeId]=b.[Id] and b.[SubjectId]='{0}'
                                  inner join B_Weight c on a.[WeightId]=c.[Id] where c.[FinishState]=0 and c.[RowState]!='{1}' and b.[AttributeName]='{2}' and a.[AttributeValue]='{3}'
                                  order by c.[FinishTime] desc", subjectId, (int)RowState.Delete, attributeName, attributeValue);
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                weightId = dt.Rows[0][0].ToObjectString();
            }
            return weightId;
        }

        /// <summary>
        /// 根据车牌号获取最近时间一条未完成的称重记录
        /// </summary>
        /// <param name="carNo">车牌号</param>
        /// <returns></returns>
        public BWeight GetUnFinishedByCarNo(string carNo)
        {
            BWeight weight = null;
            string sql;
            DataTable dt=null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"select * from B_Weight where LOWER(CarNo) = LOWER('{0}') and FinishState=0 and RowState!='{1}' 
                             order by CreateTime desc limit 0,1", carNo, (int)RowState.Delete);
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                sql = string.Format(@"select top 1 * from B_Weight where CarNo = '{0}' and FinishState=0 and RowState!='{1}' 
                             order by CreateTime desc", carNo, (int)RowState.Delete);
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                weight = TableHelper.RowToEntity<BWeight>(dt.Rows[0]);
            }
            return weight;
        }

        public bool ImportNew(DataTable dtWeight,SysCfg cfg) 
        {
            bool isImported = false;
            List<SCar> cars = HandleCar(dtWeight);
            List<SCustomer> delivers = HandleCustomer(dtWeight, CustomerType.Delivery);
            List<SCustomer> customers = HandleCustomer(dtWeight, CustomerType.Customer);
            List<SCustomer> receivers = HandleCustomer(dtWeight, CustomerType.Receiver);
            List<SMaterial> materials = HandleMaterial(dtWeight);
            List<SWareh> warehs = HandleWareh(dtWeight);
            BWeight weight = null;
            BWeightDetail tareDetail = null;
            BWeightDetail grossDetail = null;
            FinishState state = FinishState.Unfinished;
            DateTime createTime = DateTime.Now;
            DateTime finishTime = DateTime.Now;
            DateTime grossTime = DateTime.Now;
            DateTime tareTime = DateTime.Now;
            string columnName = "";
            string unit="Kg";
            string date = "";
            foreach (DataRow dr in dtWeight.Rows)
            {
                if(dtWeight.Columns.Contains("年")&& dtWeight.Columns.Contains("月")&& dtWeight.Columns.Contains("日")) {
                    date = dr["年"].ToObjectString()+"-"+ dr["月"].ToObjectString()+"-"+ dr["日"].ToObjectString();
                }
                if (dtWeight.Columns.Contains("单位") && dr["单位"].ToObjectString().Length > 0) {
                    weight.MeasureUnit = dr["单位"].ToObjectString().ToEnum<MeasureUnitType>().ToString();
                }
                if (dtWeight.Columns.Contains("数量") && dr["数量"].ToObjectString().Length > 0) {
                    weight.SuttleWeight = dr["数量"].ToObjectString().ToDecimal();
                }
                if (dtWeight.Columns.Contains("备注") && dr["备注"].ToObjectString().Length > 0) {
                    weight.Remark = dr["备注"].ToObjectString();
                }
                weight = new BWeight();
                tareDetail = null;
                grossDetail = null;
                createTime = date.ToDateTime();
                finishTime = date.ToDateTime();
                tareTime = date.ToDateTime();
                grossTime = date.ToDateTime();
                weight.Id = YF.MWS.Util.Utility.GetGuid();
                weight.FinishTime = finishTime;
                weight.CreateTime = createTime;
                weight.WeightNo = "";
                weight.GrossWeight =0;
                weight.TareWeight = 0;
                //weight.CardNo = dr[12].ToObjectString();
                if (string.IsNullOrEmpty(weight.MeasureUnit)) 
                {
                    weight.MeasureUnit = unit;
                }
                if (string.IsNullOrEmpty(weight.WeightNo)) 
                {
                    weight.WeightNo = seqNoService.GetSeqNo(SeqCode.Weight.ToString());
                }
                weight.MachineCode = CurrentClient.Instance.MachineCode;
                weight.WeighterId = CurrentUser.Instance.Id;
                weight.WeighterName = CurrentUser.Instance.FullName;
                if (cars != null && cars.Count > 0 && dr["车牌号"] != null && dr["车牌号"].ToObjectString().Length > 0)
                {
                    SCar car = cars.Find(c => c.CarNo == dr["车牌号"].ToObjectString());
                    if (car != null)
                    {
                        weight.CarNo = car.CarNo;
                        weight.CarId = car.Id;
                    }
                }
                if(string.IsNullOrEmpty(weight.CarNo)) 
                {
                    weight.CarNo = dr["车牌号"].ToObjectString();
                }
                columnName = "物资名称";
                if (materials != null && materials.Count > 0 && dr[columnName] != null && dr[columnName].ToObjectString().Length > 0) 
                {
                    SMaterial material = materials.Find(c => c.MaterialName == dr[columnName].ToObjectString());
                    if (material != null) 
                    {
                        weight.MaterialId = material.Id;
                    }
                }
                weight.MaterialModel = dr["规格型号"].ToObjectString();
                columnName = "客户单位";
                if (customers != null && customers.Count > 0 && dr[columnName] != null && dr[columnName].ToObjectString().Length > 0) 
                {
                    SCustomer customer = customers.Find(c => c.CustomerName == dr[columnName].ToObjectString());
                    if (customer != null) 
                    {
                        weight.CustomerId = customer.Id;
                    }
                }
                columnName = "供应单位";
                if (receivers != null && receivers.Count > 0 && dr[columnName] != null && dr[columnName].ToObjectString().Length > 0)
                {
                    SCustomer receiver = receivers.Find(c => c.CustomerName == dr[columnName].ToObjectString());
                    if (receiver != null)
                    {
                        weight.ReceiverId = receiver.Id;
                    }
                }
                columnName = "生产厂家";
                if (delivers != null && delivers.Count > 0 && dr[columnName] != null && dr[columnName].ToObjectString().Length > 0)
                {
                    SCustomer deliver = delivers.Find(c => c.CustomerName == dr[columnName].ToObjectString());
                    if (deliver != null)
                    {
                        weight.DeliveryId = deliver.Id;
                    }
                }
                columnName = "收货单位";
                if (warehs != null && warehs.Count > 0 && dr[columnName] != null && dr[columnName].ToObjectString().Length > 0)
                {
                    SWareh wareh = warehs.Find(c => c.WarehName == dr[columnName].ToObjectString());
                    if (wareh != null) 
                    {
                        weight.WarehId = wareh.Id;
                    }
                }
                if (weight.TareWeight > 0)
                {
                    tareDetail = new BWeightDetail();
                    tareDetail.WeightTime = tareTime;
                    tareDetail.Id = YF.MWS.Util.Utility.GetGuid();
                    tareDetail.WeightId = weight.Id;
                    tareDetail.OrderSource = OrderSource.Weight.ToString();
                    tareDetail.WeightType = (int)WeightType.Tare;
                    tareDetail.WeighterId = CurrentUser.Instance.Id;
                    tareDetail.TareWeight = weight.TareWeight;
                }
                if (weight.GrossWeight > 0)
                {
                    grossDetail = new BWeightDetail();
                    grossDetail.Id = YF.MWS.Util.Utility.GetGuid();
                    grossDetail.WeightTime =grossTime;
                    grossDetail.WeightId = weight.Id;
                    grossDetail.OrderSource = OrderSource.Weight.ToString();
                    grossDetail.WeightType = (int)WeightType.Gross;
                    grossDetail.WeighterId = CurrentUser.Instance.Id;
                    grossDetail.GrossWeight = weight.GrossWeight;
                }
                if (tareDetail!=null && grossDetail!=null && tareDetail.TareWeight > 0 && grossDetail.GrossWeight > 0)
                {
                    state = FinishState.Finished;
                }
                else
                {
                    state = FinishState.Unfinished;
                }
                weight.FinishState = (int)state;
                weight.OrderSource = OrderSource.Weight.ToString();
                weight.ViewId = CurrentClient.Instance.ViewId;
                weight.WeightProcess = (int)WeightProcess.Two;
                isImported = Save(weight, tareDetail, grossDetail, null);
            }
            return isImported;
        }

        /// <summary>
        /// 获取磅单明细列表
        /// </summary>
        /// <param name="weightId">磅单Id</param>
        /// <returns></returns>
        public List<BWeightDetail> GetWeightDetail(string weightId)
        {
            string sql;
            sql = string.Format("select * from B_WeightDetail where WeightId = '{0}'", weightId);
            DataTable dt =null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                dt = service.GetDataTable(sql);
            }
            return TableHelper.TableToList<BWeightDetail>(dt);
        } 

        public bool Save(BWeight weight, BWeightDetail tareDetail, BWeightDetail grossDetail, BWeight oldWeight = null)
        {
            bool isSaved = false;
            bool isSaveTareWeight = true;
            bool isSaveGrossWeight = true;
            List<string> lstSql = new List<string>();
            if (weight.PayType== "Settled") 
            {
                weight.AdditionalTime = DateTime.Now;
                weight.d3 = weight.d2;
                if (weight.d3 <= 0) weight.d3 = weight.SuttleWeight;
            }
            if (tareDetail != null && string.IsNullOrEmpty(tareDetail.WeighterName)) 
            {
                tareDetail.WeighterName = CurrentUser.Instance.FullName;
            }
            if (grossDetail != null && string.IsNullOrEmpty(grossDetail.WeighterName))
            {
                grossDetail.WeighterName = CurrentUser.Instance.FullName;
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                string sql = SqliteSqlUtil.GetSaveSql<BWeight>(weight, "B_Weight");
                lstSql.Add(sql);
                if (tareDetail!=null && tareDetail.TareWeight > 0)
                {
                    lstSql.Add(GetDeleteWeightDetail(WeightType.Tare, weight.Id));
                    lstSql.Add(SqliteSqlUtil.GetSaveSql<BWeightDetail>(tareDetail, "B_WeightDetail"));
                }
                if (grossDetail!=null && grossDetail.GrossWeight > 0)
                {
                    lstSql.Add(GetDeleteWeightDetail(WeightType.Gross, weight.Id));
                    lstSql.Add(SqliteSqlUtil.GetSaveSql<BWeightDetail>(grossDetail, "B_WeightDetail"));
                } 
                isSaved = sqliteDb.ExecuteNonQuery(lstSql) > 0;
            }
            else 
            {
                isSaved = service.Save<BWeight>(weight, weight.Id);
                if (isSaved && tareDetail != null && tareDetail.TareWeight > 0)
                {
                    DeleteWeightDetail(WeightType.Tare, weight.Id);
                    isSaveTareWeight = service.Save<BWeightDetail>(tareDetail, tareDetail.Id);
                }
                if (isSaved && grossDetail != null && grossDetail.GrossWeight > 0)
                {
                    DeleteWeightDetail(WeightType.Gross, weight.Id);
                    isSaveGrossWeight = service.Save<BWeightDetail>(grossDetail, grossDetail.Id);
                }
            }
            if (isSaved && oldWeight == null&&weight.FinishState==1) {
                decimal dw = weight.SuttleWeight;
                if(weight.d2>0)dw=weight.d2;
                SMaterial material = materialService.GetMaterial(weight.MaterialId);
                if (material != null) {
                    if (weight.WarehBizType == "RuKu") {
                        material.Quantity = material.Quantity+ dw;
                    } else if (weight.WarehBizType == "ChuKu") {
                        material.Quantity = material.Quantity- dw;
                    }
                    materialService.SaveMaterial(material);
                }
                SCustomer customer=masterService.GetCustomer(weight.CustomerId);
                if (customer != null && weight.UnitMoney > 0) {
                    if (weight.WarehBizType == "RuKu") {
                    customer.BalanceAmount = customer.BalanceAmount + weight.UnitMoney;
                    } else if (weight.WarehBizType == "ChuKu") {
                    customer.BalanceAmount = customer.BalanceAmount - weight.UnitMoney;
                    }
                    if (weight.PayType == "Settled") {
                        payService.AddPay(new BPay() {
                            PayAmount=weight.UnitMoney,
                            PayTime=DateTime.Now,
                            CarNo=weight.CarNo,
                            RefId=weight.Id,
                            CustomerId=weight.CustomerId,
                        });
                    } else {
                    masterService.SaveCustomer(customer);
                    }
                }
            }
            return isSaved;
        }
        public bool Save(BWeight weight) {
            bool isSaved = false;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                isSaved = sqliteDb.ExecuteNonQuery(SqliteSqlUtil.GetSaveSql<BWeight>(weight, "B_Weight")) > 0;
            } else {
                isSaved = service.Save<BWeight>(weight, weight.Id);
            }
            return isSaved;
        }


        public void Summary(string weightId)
        {
            BWeight weight = Get(weightId);
            if (weight != null)
            {
                ImpurityMeaType meaType = weight.ImpurityMeaType.ToEnum<ImpurityMeaType>();
                decimal tareWeight = 0m;
                decimal grossWeight = 0m;
                decimal suttleWeight = 0m;
                decimal netWeight = 0m;
                string sql;
                sql = string.Format(@"select sum(GrossWeight),sum(TareWeight) from B_WeightDetail where WeightId='{0}'", weightId);
                DataTable dt =null;
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    dt = sqliteDb.ExecuteDataTable(sql);
                }
                else 
                {
                    dt = service.GetDataTable(sql);
                }
                tareWeight = dt.Rows[0][1].ToDecimal();
                grossWeight = dt.Rows[0][0].ToDecimal();
                if (tareWeight > 0 && grossWeight > 0)
                {
                    suttleWeight = grossWeight - tareWeight;
                    if (meaType == ImpurityMeaType.NetValue)
                    {
                        netWeight = suttleWeight - weight.ImpurityWeight;
                    }
                    else
                    {
                        netWeight = suttleWeight - suttleWeight * weight.ImpurityWeight * 0.01m;
                    }
                    sql = string.Format(@"update B_Weight set TareWeight='{2}',GrossWeight='{3}',NetWeight='{0}',SuttleWeight='{4}'
                                            where Id='{1}'", netWeight, weightId, tareWeight, grossWeight, suttleWeight);
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                    {
                        sqliteDb.ExecuteNonQuery(sql);
                    }
                    else 
                    {
                        service.ExecuteNonQuery(sql);
                    }
                }
            }
        }

        public void UpdatePrint(string weightId)
        {
            string sql;
            sql = string.Format("update B_Weight set PrintCount=PrintCount+1 where Id='{0}'", weightId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sqliteDb.ExecuteNonQuery(sql);
            }
            else 
            {
                service.ExecuteNonQuery(sql);
            }
        }

        public bool UpdateQcState(string weightId, QcState state, decimal deducteWeight) 
        {
            string sql = string.Format(@"update B_Weight set QcState={1} where Id = '{0}' ", weightId,(int)state);
            if (deducteWeight > 0)
            {
                sql = string.Format(@"update B_Weight set QcState={1},ImpurityWeight='{2}' where Id = '{0}' ", weightId, (int)state,deducteWeight);
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                return sqliteDb.ExecuteNonQuery(sql)>0;
            }
            else
            {
                return service.ExecuteNonQuery(sql);
            }
        }

        public void UpdateSyncState(string weightId)
        {
            string sql = string.Format(@"update B_Weight set SyncState=1 where Id = '{0}' ", weightId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sqliteDb.ExecuteNonQuery(sql);
            }
            else 
            {
                service.ExecuteNonQuery(sql);
            }
        }

        public bool UpdateWeightNo(string weightId, string weightNo) 
        {
            string sql;
            sql = string.Format(@"update B_Weight set WeightNo='{1}' where Id = '{0}' ", weightId,weightNo);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                return sqliteDb.ExecuteNonQuery(sql)>0;
            }
            else
            {
                return service.ExecuteNonQuery(sql);
            }
        }
    }
}
