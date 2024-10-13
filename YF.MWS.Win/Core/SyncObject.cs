using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Db;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Partner;
using YF.MWS.Metadata.Transfer;

namespace YF.MWS.Win.Core
{
    public class SyncObject
    {
        public string WeightId;
        public TransferCfg Transfer;
        public TPWeight Weight;
        public BPay Pay { get; set; }
        public IFileService FileService;
        public IWebFileService WebFileService;
        public IMasterService MasterService;
        public IMaterialService MaterialService;
        public IPayService PayService;
        public IWeightExtService WeightExtService;
        public ISyncService SyncService;
        public string ServerUrl;
        public List<BFile> LstFile;
        public YF.MWS.Client.DataService.Interface.IWeightService WeightService;
    }
}
