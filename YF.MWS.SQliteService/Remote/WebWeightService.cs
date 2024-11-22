using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web.UI.WebControls;
using System.Windows.Forms;
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
        public WebWeightService() {
            WebWeightService.ServerUrl=AppSetting.GetValue("EcsServer");
        }
        public bool doneWeight(BWeight weightOld,TransferCfg transfer)
        {
            try {
                FWeight weight = new FWeight();
                weight.billerName = transfer.CompanyName;
                weight.plateNumber = weightOld.CarNo;
                weight.actualLoad = weightOld.SuttleWeight;
                weight.transportStartTime = weightOld.CreateTime.ToString("yyyy-MM-dd HH:mm:ss").ToDateTime();
                weight.transportEndTime = weightOld.FinishTime.ToString("yyyy-MM-dd HH:mm:ss").ToDateTime();
                weight.miningAreaName = transfer.CompanyCode;
                weight.billAddress = transfer.Address;
                #region  客户单位调整
                SCustomer customer = customerService.GetCustomer(weightOld.CustomerId);
                if (customer != null) weight.intendedArrivalHarbour = customer.CustomerName;
                else weight.intendedArrivalHarbour = "";
                #endregion
                #region 货物调整
                SMaterial material = materialService.GetMaterial(weightOld.MaterialId);
                if (material != null) weight.category = material.MachineCode.ToInt();
                #endregion
                List<BFile> lstFile = fileService.Get(weightOld.Id, "B_Weight", FileBusinessType.Graphic);
                List<string> images = new List<string>();
                foreach (BFile file in lstFile) {
                    string fileName = Path.Combine(Application.StartupPath, file.FileUrl);
                    if (File.Exists(fileName)) {
                        using (FileStream fs = new FileStream(fileName, FileMode.Open)) {
                            byte[] buffer = new byte[fs.Length];
                            fs.Read(buffer, 0, buffer.Length);
                            images.Add(Convert.ToBase64String(buffer));
                        }
                    }
                }
                weight.documents = images.ToArray();
                //Logger.Write("weight: " + weight.JsonSerialize());
                var model = WebBaseService.sendPost(transfer.ServerUrl, weight, Token);
                if (model == null) return false;
                if (model.status != 200) {
                    Logger.Write("上传服务器失败： " + model.message);
                    return false;
                }
                if (model.result.status.ToUpper() != "OK") {
                    Logger.Write("服务器保存失败： " + model.result.message);
                    return false;
                }
            } catch (Exception ex) {
                Logger.Write(ex.Message);
                return false;
            }
            return true;
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

    }
}
