using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    public static class RetCode
    {
        public static string UnitFile(string value) {
            if(string.IsNullOrEmpty(value)) { return ""; }
            if (value == "GJ") {
                return "公斤";
            } else if (value == "KG" || value == "kg") {
                return "千克";
            } else if (value.ToUpper() == "JIN") {
                return "斤";
            } else {
                return "吨";
            }
        }
        public static bool isColumns(this DataTable dt, string[] names) {
            bool isColumns = true;
            foreach(string name in names) {
                if(!dt.Columns.Contains(name)) {
                    return false;
                }
            }
            return isColumns;
        }
        /// <summary>
        /// 首字母转小写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string firstLowercase(string str) {
            if (string.IsNullOrEmpty(str)) {
                return str;
            }
            str = str.Substring(0, 1).ToLower() + str.Substring(1);
            return str;
        }
    }
}
