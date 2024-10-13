using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;

namespace YF.MWS.Client.DataService.Interface.Remote
{
    public interface IWebPayService
    {
        bool AddPay(BPay pay);
        bool AddPayFull(BPay pay);
        bool UpdateRowState(RowState rowState, string refId);
    }
}
