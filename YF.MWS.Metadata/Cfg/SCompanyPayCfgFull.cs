using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Metadata.Cfg
{
    public class SCompanyPayCfgFull
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public PayPluginType PayType { get; set; }

        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string Key { get; set; }
        public string MCHID { get; set; }
    }
}
