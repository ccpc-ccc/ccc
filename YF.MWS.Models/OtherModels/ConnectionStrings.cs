using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace YF.MWS.BaseMetadata {
    public class ConnectionStrings {
        public string ConnectionString { get; set; }
        public bool IsAutoCloseConnection { get; set; }
        public int DbType { get; set; }
    }
}
