using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.MWS.Metadata.Dto;

namespace YF.MWS.Client.DataService.Interface
{
    public interface ISyncService
    {
        byte[] GetUpload(string tempDbFile);
        bool SaveMaterial(string url, SMaterial material, string machineCode);
        bool SaveWareh(string url, SWareh material, string machineCode);
        bool SaveCustomer(string url, SCustomer customer,string machineCode);
        bool SavePay(string url, BPay pay, string machineCode);
        bool SaveView(string url, DSyncWeightView view, string machineCode);
    }
}
