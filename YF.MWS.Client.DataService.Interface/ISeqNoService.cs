using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.MWS.Metadata.Query;

namespace YF.MWS.Client.DataService.Interface
{
    /// <summary>
    /// 系统序列号服务接口
    /// Author:yafyr
    /// Date:2014-10-07
    /// </summary>
    public interface ISeqNoService
    {
        bool Cancel(string seqCode);
        SSeqNo Get(string noId);
        string GetSeqNo(string seqCode);
        List<QSeqNo> GetList(List<SCode> lstCode);
        string Preview(string seqCode);
        bool Save(SSeqNo seqNo);
    }
}
