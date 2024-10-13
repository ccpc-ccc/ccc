using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.MWS.Metadata;

namespace YF.MWS.Util
{
    public class MatadataUtil
    {
        public static List<SCode> GetSubCodeList(List<SCode> lstAll, SysCode code)
        {
            SCode parent = null;
            List<SCode> lstFind = new List<SCode>();
            if (lstAll != null && lstAll.Count > 0)
            {
                parent=lstAll.Find((c => c.ItemCode == code.ToString() && (string.IsNullOrEmpty(c.ParentId) || c.ParentId.Length==0)));
                if (parent != null)
                {
                    lstFind = lstAll.FindAll(c => c.ParentId == parent.Id);
                }
            }
            return lstFind;
        }
    }
}
