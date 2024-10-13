using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Transfer
{
    public class TCustomerResult:Result
    {
        public List<TCustomer> Rows { get; set; }
    }
}
