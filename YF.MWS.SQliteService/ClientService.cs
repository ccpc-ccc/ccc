﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Util;
using YF.Utility.Data;
using YF.Utility;
using YF.Data.NHProvider;

using YF.Utility.Security;

namespace YF.MWS.SQliteService
{
    public class ClientService : IClientService
    {
        private SqliteDb sqliteDb = new SqliteDb();
        private IService service = null;
        

        public ClientService()
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                service = ServiceInitialization.DbService;
            }
        }

        public bool Add(string machineCode,string authCode) 
        {
            bool isRegistered = false;
            SClient clientFind = Get(machineCode);
            if (clientFind != null) 
            {
                return isRegistered;
            }
            string sql;
            SClient client = new SClient();
            client.Id = YF.MWS.Util.Utility.GetGuid();
            client.RegisterType = RegisterMode.SoftdogOnly.ToString();
            client.AuthCode = authCode;
            client.MachineCode = machineCode;
            client.RegisterDate = DateTime.Now;
            client.ExpireDate = DateTime.Now;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = SqliteSqlUtil.GetSaveSql<SClient>(client, "S_Client");
                isRegistered = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                isRegistered = service.Insert(client);
            }
            return isRegistered;
        }

        public bool Delete()
        {
            bool isDeleted = false;
            string sql = string.Format(@"delete from S_Client ");
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

        public bool Delete(string machineCode)
        {
            bool isDeleted = false;
            string sql = string.Format(@"delete from S_Client where MachineCode='{0}'", machineCode);
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

        public bool DeleteById(string clientId)
        {
            bool isDeleted = false;
            string sql = string.Format(@"update S_Client set RowState={1} where Id='{0}'", clientId,(int)RowState.Delete);
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

        public bool IsConnect() 
        {
            bool isConnected = false;
            string sql = "select 1 as TestCol";
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                if (service != null) 
                {
                    DataTable dt = service.GetDataTable(sql);
                    if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToInt() == 1) 
                    {
                        isConnected = true;
                    }
                }
            }
            else
            {
                DataTable dt = sqliteDb.ExecuteDataTable(sql);
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToInt() == 1)
                {
                    isConnected = true;
                }
            }
            return isConnected;
        }

        public SClient GetById(string clientId)
        {
            SClient client = null;
            string sql;
            sql = string.Format("select * from S_Client where Id='{0}'",clientId);
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
                client = TableHelper.RowToEntity<SClient>(dt.Rows[0]);
            }
            return client;
        }

        public SClient Get()
        {
            SClient client = null;
            string sql= string.Format("select * from S_Client");
            DataTable dt=null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                client = TableHelper.RowToEntity<SClient>(dt.Rows[0]);
            }
            return client;
        }

        public List<SClient> GetList() 
        {
            string sql = string.Format("select * from S_Client where RowState!={0}",(int)RowState.Delete);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                return sqliteDb.GetObjectList<SClient>(sql);
            else
                return service.GetObjectList<SClient>(sql);
        }

        public SClient Get(string machineCode) 
        {
            SClient client = null;
            string sql;
            sql =string.Format("select * from S_Client where MachineCode='{0}'",machineCode);
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
                client = TableHelper.RowToEntity<SClient>(dt.Rows[0]);
            }
            return client;
        }

        public bool Register(string clientName, string machineCode, string registerCode, string expireCode, string totalTimes, string verifyCode,string authCode) 
        {
            string sql;
            bool isRegistered = false;
            SClient client = Get(machineCode);
            string currentDate = DateTime.Now.ToString("yyyyMMdd");
            bool isExist = true;
            if (client == null) 
            {
                isExist = false;
                client = new SClient();
                client.Id = YF.MWS.Util.Utility.GetGuid();
                client.RegisterDate = DateTime.Now;
                client.ClientName = clientName;
            }
            client.RegisterType = CurrentClient.Instance.RegType.ToString();
            client.MachineCode = machineCode;
            client.RegisterCode = registerCode;
            client.AuthCode = authCode;
            DateTime expireDate = DateTime.ParseExact(YF.Utility.Security.Encrypt.DecryptDES(expireCode, CurrentClient.Instance.EncryptKey), "yyyyMMdd", null);
            client.ExpireDate = expireDate;
            client.ExpireCode = expireCode;
            client.TotalTimes = totalTimes;
            client.UsedTimes = YF.Utility.Security.Encrypt.EncryptDES("1", CurrentClient.Instance.EncryptKey);
            client.CurrentDate = YF.Utility.Security.Encrypt.EncryptDES(currentDate, CurrentClient.Instance.EncryptKey);
            client.VerifyCode = verifyCode;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = SqliteSqlUtil.GetSaveSql<SClient>(client, "S_Client");
                isRegistered= sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                if (isExist)
                {
                    isRegistered=service.Update(client);
                }
                else
                {
                    isRegistered=service.Insert(client);
                }
            }
            return isRegistered;
        }

        public bool RegisterProbation(string machineCode, string clientName)
        {
            bool isRegistered = false;
            SClient client = Get(machineCode);
            if (client == null)
            {
                int maxUsedTimes = 30;
                string expireCode = Encrypt.EncryptDES(DateTime.Now.AddMonths(1).ToString("yyyyMMdd"), CurrentClient.Instance.EncryptKey);
                string totalTimes = Encrypt.EncryptDES(maxUsedTimes.ToString(), CurrentClient.Instance.EncryptKey);
                string verifyCode = YF.MWS.Util.Utility.GetGuid();
                string registerCode = SoftRegister.GenerateRegisterCode(machineCode);
                isRegistered = Register(clientName, machineCode, registerCode, expireCode, totalTimes, verifyCode,"1");
            }
            return isRegistered;
        }

        public bool Update(string clientId) 
        {
            SClient client = GetById(clientId);
            bool isUpdated = false;
            if (client != null) 
            {
                string sql;
                string now = DateTime.Now.ToString("yyyyMMdd");
                string currentDate = YF.Utility.Security.Encrypt.DecryptDES(client.CurrentDate, CurrentClient.Instance.EncryptKey);
                if (string.IsNullOrEmpty(currentDate) || currentDate.ToInt() == 0)
                {
                    currentDate = DateTime.Now.AddMonths(-3).ToString("yyyyMMdd");
                }
                if (YF.MWS.Util.Utility.CompareDate(now, currentDate) != 0)
                {
                    int usedTimes = YF.Utility.Security.Encrypt.DecryptDES(client.UsedTimes, CurrentClient.Instance.EncryptKey).ToInt()+1;
                    int cDate = currentDate.ToInt() + 1;
                    client.UsedTimes = YF.Utility.Security.Encrypt.EncryptDES(usedTimes.ToString(), CurrentClient.Instance.EncryptKey);
                    client.CurrentDate = YF.Utility.Security.Encrypt.EncryptDES(now, CurrentClient.Instance.EncryptKey);
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                    {
                        sql = SqliteSqlUtil.GetSaveSql<SClient>(client, "S_Client");
                        isUpdated = sqliteDb.ExecuteNonQuery(sql) > 0;
                    }
                    else 
                    {
                        isUpdated = service.Update(client);
                    }
                }
            }
            return isUpdated;
        }

        public bool UpdateAuthCode(string machineCode, string authCode) 
        {
            string sql;
            sql = string.Format("update S_Client set AuthCode='{0}' where MachineCode='{1}' ",authCode,machineCode);
            bool isUpdated = false;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isUpdated = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                isUpdated = service.ExecuteNonQuery(sql);
            }
            return isUpdated;
        }

        public bool UpdateClientName(string clientId, string clientName)
        {
            string sql;
            sql = string.Format("update S_Client set ClientName='{0}' where Id='{1}' ", clientName, clientId);
            bool isUpdated = false;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isUpdated = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                isUpdated = service.ExecuteNonQuery(sql);
            }
            return isUpdated;
        }

        public bool UpdateProbation(string machineCode, int days)
        {
            bool isUpdated = false;
            int maxUsedTimes = days;
            int hasUsed = 0;
            DateTime expireDate = DateTime.Now.AddDays(days);
            string expireCode = Encrypt.EncryptDES(DateTime.Now.AddDays(days).ToString("yyyyMMdd"), CurrentClient.Instance.EncryptKey);
            string totalTimes = Encrypt.EncryptDES(maxUsedTimes.ToString(), CurrentClient.Instance.EncryptKey);
            string usedTimes = Encrypt.EncryptDES(hasUsed.ToString(), CurrentClient.Instance.EncryptKey);
            string sql;
            sql = string.Format(@"update S_Client set ExpireDate='{0}',ExpireCode='{1}',TotalTimes='{2}',UsedTimes='{3}' where MachineCode='{4}'",
                                         expireDate.ToString("yyyy-MM-dd"), expireCode, totalTimes, usedTimes, machineCode);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isUpdated = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                isUpdated = service.ExecuteNonQuery(sql);
            }
            return isUpdated;
        }
    }
}
