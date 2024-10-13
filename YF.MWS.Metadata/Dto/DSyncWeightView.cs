using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Metadata.Dto
{
    public class DSyncWeightView
    {
        public string MachineCode { get; set; }
        public string CompanyId { get; set; }
        public SWeightView View { get; set; }
        public List<SWeightViewDtl> LstDetail { get; set; }
    }
}
