using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Metadata
{
    public static class MetadataConverter {
        /// <summary>
        /// 将DataTable数据转换下拉列表
        /// </summary>
        public static List<ListItem> ToListItems(this DataTable dt,string text) {
            if (dt == null) return null;
            List<ListItem> list = new List<ListItem>();
            foreach (DataRow dr in dt.Rows) {
                list.Add(new ListItem(dr[text].ToString(), dr["Id"].ToString()));
            }
            return list;
        }
    }
}
