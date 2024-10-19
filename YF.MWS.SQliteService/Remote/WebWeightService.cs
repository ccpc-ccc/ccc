using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Db;
using YF.MWS.Db.Server;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Dto;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata.Transfer;
using YF.MWS.Util;
using YF.MWS.Util.Dynamic;
using YF.Utility;
using YF.Utility.Configuration;
using YF.Utility.Log;
using YF.Utility.Net;

namespace YF.MWS.SQliteService.Remote
{
    public class WebWeightService : IWebWeightService {
        public static string ServerUrl { get; set; }
        public static string Token { get; set; }
        public static string CompanyId { get; set; }
        public static string ClientId { get; set; }
        IWarehService warehService = new WarehService();
        ICustomerService customerService = new CustomerService();
        IMaterialService materialService = new MaterialService();
        IFileService fileService = new FileService();
        IWeightService weightService = new WeightService();
        public WebWeightService() {
            WebWeightService.ServerUrl=AppSetting.GetValue("EcsServer");
        }
        public static ReturnEntity Login(string CompanyCode, string MachineCode, string RegisterCode) {
            string url = string.Format("{0}/api/client/login", WebWeightService.ServerUrl);
            var json = new {
                companyCode = CompanyCode,
                machineCode = MachineCode,
                registerCode = RegisterCode
            };
            ReturnEntity entity = WebBaseService.sendPost(url, json);
            if(entity==null) return null;
            if (entity.Result && entity.model != null) {
                Newtonsoft.Json.Linq.JObject obj=entity.model;
                if (obj != null) {
                    ClientId = obj["id"].ToString();
                    Newtonsoft.Json.Linq.JObject company = obj["company"] as Newtonsoft.Json.Linq.JObject;
                    CompanyId = company["id"].ToString();
                        }
            }
            return entity;
        }
        public static bool synWeightViewDtl(List<SWeightViewDtl> sWeightViewDtls) {
            if (string.IsNullOrEmpty(WebWeightService.Token)) return false;
            string url = string.Format("{0}/api/weightViewDtl/importData", WebWeightService.ServerUrl);
            var json = new {
                list = sWeightViewDtls
            }.JsonSerialize();
            return WebBaseService.sendPost(url, json,Token).Result;
        }
        public BWeight Get(string carNo) {
            if (string.IsNullOrEmpty(WebWeightService.Token)) return null;
            string url = string.Format("{0}/api/weight/getModelState1", WebWeightService.ServerUrl);
            var json = new {
                carNo = carNo,
                companyId= WebWeightService.CompanyId,
                clientId= WebWeightService.ClientId
            };
            ReturnEntity entity= WebBaseService.sendPost(url, json, Token);
            if(entity==null||!entity.Result||entity.model==null) return null;
            BWeight weight = new BWeight() { };
            Type type = weight.GetType();
            System.Reflection.PropertyInfo[] properties = type.GetProperties();
            foreach(PropertyInfo info in properties) {
                var value = entity.model[RetCode.firstLowercase(info.Name)];
                if (value== null) continue;
                if (info.PropertyType == typeof(string)) {
                    info.SetValue(weight, value.ToString());
                }else if (info.PropertyType == typeof(int)) {
                    info.SetValue(weight, value.ToInt());
                } else if (info.PropertyType == typeof(decimal)) {
                    info.SetValue(weight, value.ToDecimal());
                } else if (info.PropertyType == typeof(double)) {
                    info.SetValue(weight, (double)value.ToDecimal());
                } else if (info.PropertyType == typeof(DateTime)) {
                    info.SetValue(weight, value.ToDateTime());
                }
            }
            weight.ServiceId = weight.Id;
            weight.FinishState = 0;
            #region 车辆
            var oc = entity.model;
            if (oc != null) {
                SCar car = new SCar() { CarNo = oc["carNo"].ToString()};
                ICarService carService = new CarService();
                SCar carOld = carService.GetByCarNo(car.CarNo);
                if (carOld == null) {
                    carOld = carService.Add(car.CarNo);
                }
                weight.CustomerId = carOld.Id;
            }
            #endregion
            #region  客户单位调整
            var model = entity.model["customer"];
            if (model != null) {
                if (model != null) {
                    SCustomer customer = new SCustomer() { Id = model["id"].ToString(), CustomerCode = model["customerCode"].ToString(), CustomerName = model["customerName"].ToString() };
                    SCustomer old = customerService.GetCustomerByName(CustomerType.Customer, customer.CustomerName);
                    if (old == null) {
                        old = customerService.AddCustomer(CustomerType.Customer, customer.CustomerName);
                    }
                    weight.CustomerId = old.Id;
                }
            }
            #endregion
            #region  仓库调整
            model = entity.model["wareh"];
            if (model != null) {
                SWareh wareh = new SWareh() { Id = model["id"].ToString(), WarehCode = model["warehCode"].ToString(), WarehName = model["warehName"].ToString() };
                SWareh warehOld = warehService.GetByName(wareh.WarehName);
                if (warehOld == null) {
                    warehOld = wareh;
                    warehOld.Id = System.Guid.NewGuid().ToString("N");
                    warehService.Save(warehOld);
                }
            weight.WarehId = warehOld.Id;
            }
            #endregion
            #region 货物调整
            model = entity.model["material"];
            if (model != null) {
            SMaterial material = new SMaterial() { Id = model["id"].ToString(), MaterialCode = model["materialCode"].ToString(), MaterialName = model["materialName"].ToString() };
            SMaterial materialOld = materialService.GetMaterialByName(material.MaterialName);
            if (materialOld == null) {
                materialOld = material;
                materialOld.Id = System.Guid.NewGuid().ToString("N");
                materialOld.State = 1;
                materialService.SaveMaterial(materialOld);
            }
            weight.MaterialId = materialOld.Id;
            }
            #endregion
            return weight;
        }
        public bool doneWeight(BWeight weightOld)
        {
            QWeight weight = new QWeight();
            Type type = weightOld.GetType();
            System.Reflection.PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo info in properties) {
                PropertyInfo p = weightOld.GetType().GetProperty(info.Name);
                if (p == null) continue;
                var value = p.GetValue(weightOld,null);
                if (value == null) continue;
                if (info.PropertyType == typeof(string)) {
                    info.SetValue(weight, value.ToString());
                } else if (info.PropertyType == typeof(int)) {
                    info.SetValue(weight, value.ToInt());
                } else if (info.PropertyType == typeof(decimal)) {
                    info.SetValue(weight, value.ToDecimal());
                } else if (info.PropertyType == typeof(double)) {
                    info.SetValue(weight, (double)value.ToDecimal());
                } else if (info.PropertyType == typeof(DateTime)) {
                    info.SetValue(weight, value.ToDateTime());
                }
            }
            weight.CompanyId = WebWeightService.CompanyId;
            weight.ClientId=WebWeightService.ClientId;
            #region  客户单位调整
                SCustomer customer = customerService.GetCustomer(weight.CustomerId);
                if (customer != null) weight.CustomerName= customer.CustomerName;
            #endregion
            #region  仓库调整
            SWareh wareh = warehService.Get(weight.WarehId);
            if (wareh != null) weight.WarehName = wareh.WarehName;
            #endregion
            #region 货物调整
            SMaterial material = materialService.GetMaterial(weight.MaterialId);
            if (material != null) weight.MaterialName = material.MaterialName;
            #endregion
            List<BFile>lstFile = fileService.Get(weight.Id, "B_Weight", FileBusinessType.Graphic);
            weight.files = lstFile;
            weight.Id = weight.ServiceId;
            weight.CreateTime = null;
            weight.UpdateTime = null;
            string url = string.Format("{0}/api/weight/doneWeight", WebWeightService.ServerUrl);
            var isOk = WebBaseService.sendPost(url, weight, Token).Result;
            foreach(BFile file in lstFile) {
                   file.FileContent= UnitUtil.FileToBase64(file.FileUrl);
                file.RecId = weight.Id;
            }
            if (isOk) {
                url = string.Format("{0}/api/file/save", WebWeightService.ServerUrl);
                WebBaseService.sendPost(url, lstFile, Token);
            }
            return isOk;
        }

        public bool UpdateState(string weightId, RowState state)
        {
            string url = string.Format("{0}/api/sf/weight/UpdateRowState?weightId={1}&state={2}", AppSetting.GetValue("EcsServer"), weightId, (int)state);
            return WebApiUtil.Get(url);
        }

        public bool Save(SyncWeight syncWeight)
        {
            if (syncWeight == null || syncWeight.Weight == null)
                return false;
            string url = string.Format("{0}/api/sf/weight/Save", AppSetting.GetValue("EcsServer"));
            string data = syncWeight.JsonSerialize();
            return WebApiUtil.Post(url, data);
        }
        public static ReturnEntity testServer(string url,string token) {
            object obj = new object();
            url = url + "/login";
            ReturnEntity entity = WebBaseService.sendPost(url, obj, token);
            return entity;
        }
        public ServerReturnEntity serverSaveEnterWeightData(string id) {
            if (!CurrentClient.Instance.IsServer || string.IsNullOrEmpty(CurrentClient.Instance.ServerToken)) return null;
            VWeight weight = weightService.GetAll(id);
            if(weight == null) return null;
            ServerWeight serverWeight = new ServerWeight() {
                cby=weight.WeighterName,
                jld=weight.WeightNo,
                clmc=weight.MaterialName,
                ycllx=weight.MaterialCode,
                clgg=weight.TransferName,
                gysmc=weight.ReceiverName,
                pc=weight.WaybillNo,
                jcsj=weight.CreateTime,
                jccz=weight.GrossWeight,
                lcmc=weight.WarehName,
                cph=weight.CarNo,
                contractnumber=weight.t1,
                contractid=weight.t2,
                bz=weight.Remark,
                cssj=weight.FinishTime,
                cccz=weight.TareWeight,
                jz=weight.SuttleWeight
            };
            string url = CurrentClient.Instance.ServerUrl+ "/ext/weight/saveEnterWeightData";
            Logger.Write("称重数据上传： "+ serverWeight.JsonSerialize());
            ServerReturnEntity entity = WebBaseService.sendServerPost(url, serverWeight, CurrentClient.Instance.ServerToken);
            return entity;
        }
        public ServerReturnEntity serverSaveEnterWeightOut(string id) {
            if (!CurrentClient.Instance.IsServer || string.IsNullOrEmpty(CurrentClient.Instance.ServerToken)) return null;
            VWeight weight = weightService.GetAll(id);
            ServerWeightOut serverWeight = new ServerWeightOut() {
                jld=weight.WeightNo,
                cssj=weight.FinishTime,
                jz=weight.SuttleWeight
            };
            string url = CurrentClient.Instance.ServerUrl+ "/ext/weight/saveOutWeightData";
            ServerReturnEntity entity = WebBaseService.sendServerPost(url, serverWeight, CurrentClient.Instance.ServerToken);
            return entity;
        }
    }
}
