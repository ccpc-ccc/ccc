using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.Utility.Calculate;
using YF.Utility.Log;
using YF.Utility.Security;
using YF.Utility;
using YF.Utility.Configuration;
using YF.Utility.IO;
using System.Windows.Forms;
using YF.Utility.Serialization;
using YF.MWS.Db;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Util
{
    public class Utility
    {
        #region Private Methods
        private static void InitColumn(DataTable dtSource, string columnName, string columnNameUpper) 
        {
            if (dtSource.Columns.Contains(columnName) && dtSource.Columns.Contains(columnNameUpper))
            {
                dtSource.Columns.Add(columnNameUpper);
            }
        }

        #endregion
       

        public static DateTime GetTime(string time, string dateFormat = "yyyy-MM-dd HH:mm:ss")
        {
            DateTime dt = DateTime.Now;
            dt = DateTime.ParseExact(time, dateFormat, System.Globalization.CultureInfo.InvariantCulture);
            return dt;
        }
        /// <summary>
        /// 时间比较
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>大于则返回1,小于则返回-1,等于则返回0</returns>
        public static int CompareDate(string startDate, string endDate) {
            if (Convert.ToInt32(endDate) - Convert.ToInt32(startDate) < 0) {
                return -1;
            }
            if (Convert.ToInt32(endDate) - Convert.ToInt32(startDate) > 0) {
                return 1;
            } else {
                return 0;
            }
        }

        public static bool IsAdWeeks(string weeks) 
        {
            bool isAdWeeks = false;
            int weekIndex = (int)DateTime.Now.DayOfWeek;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                weekIndex = 7;
            }
            if (!string.IsNullOrEmpty(weeks) && weeks.Contains(weekIndex.ToString())) 
            {
                isAdWeeks = true;
            }
            return isAdWeeks;
        }

        public static string GetColumnName(DataTable dtViewDtl, string fieldName) 
        {
            string columnName = fieldName;
            if (dtViewDtl != null && dtViewDtl.Rows.Count > 0)
            {
                DataRow[] drs = dtViewDtl.Select(string.Format("FieldName='{0}'", fieldName));
                if (drs != null && drs.Length > 0)
                {
                    if (drs[0]["ControlName"].ToObjectString().Length > 0)
                    {
                        columnName = drs[0]["ControlName"].ToObjectString();
                    }
                }
            }
            return columnName;
        }

        public static SysCfg GetCfg()
        {
            SysCfg cfg = null;
            if (cfg == null)
            {
                string xmlPath = Path.Combine(Application.StartupPath, "SysCfg.xml");
                cfg = null;
                if (File.Exists(xmlPath))
                {
                    cfg = XmlUtil.Deserialize<SysCfg>(xmlPath);
                }
            }
            if (cfg == null)
            {
                cfg = new SysCfg();
            }
            return cfg;
        }

        public static string GetComputerName()
        {
            string name = Consts.DEFAULT_CLIENT_NAME;
            //try
            //{
            //    name = System.Environment.GetEnvironmentVariable("ComputerName");
            //    if (string.IsNullOrEmpty(name))
            //        name = Environment.MachineName;
            //    if (string.IsNullOrEmpty(name))
            //        name = Environment.UserName;
            //    if (string.IsNullOrEmpty(name))
            //        name = Environment.UserDomainName;
            //}
            //catch (Exception ex)
            //{
            //    Logger.WriteException(ex);
            //}
            return name;
        }

        /// <summary>
        /// 获取数据库文件名称或者路径
        /// </summary>
        /// <returns></returns>
        public static string GetDbName() 
        {
            string dbName = string.Empty;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dbName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppSetting.GetValue("dsnSqlite"));
            }
            else 
            {
                string dsn = AppSetting.GetValue("dsn");
                if (!string.IsNullOrEmpty(dsn))
                {
                    List<string> values = dsn.Split(';').ToList();
                    if (values != null && values.Count > 0)
                    {
                        foreach (string val in values)
                        {
                            string[] paramVals = val.Split('=');
                            if (paramVals != null && paramVals.Length > 1)
                            {
                                if (paramVals[0].ToLower() == "database")
                                {
                                    dbName = paramVals[1];
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return dbName;
        }

        /// <summary>
        /// 初始化行号,实付金额转换为金额大写列
        /// </summary>
        /// <param name="dt"></param>
        public static void InitRow(DataTable dt) 
        {
            string xmlPath = Path.Combine(Application.StartupPath, "SysCfg.xml");
            SysCfg cfg = XmlUtil.Deserialize<SysCfg>(xmlPath);
            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }
            string columnRownoName="行号";
            if (!dt.Columns.Contains(columnRownoName)) 
            {
                dt.Columns.Add(columnRownoName, typeof(int));
            }
            
            int rows = dt.Rows.Count;
            for (int i = 0; i < rows; i++) 
            {
                dt.Rows[i][columnRownoName] = i + 1;
                /*if (dt.Columns.Contains(columnName) && dt.Columns.Contains(columnNameUpper))
                {
                    dt.Rows[i][columnNameUpper] = MoneyToUpper(dt.Rows[i][columnName].ToObjectString());
                }*/
            }
        }

        public static bool ExistColumn(DataTable dt, string columnName) 
        {
            bool isExist = false;
            foreach (DataColumn dc in dt.Columns) 
            {
                if (dc.ColumnName.ToLower() == columnName.ToLower()) 
                {
                    isExist = true;
                    break;
                }
            }
            return isExist;
        }


        public static object GetValue<T>(T t, List<PropertyInfo> lstProperty, string propertyName)
        { 
            PropertyInfo pi = null;
            object obj = null;
            pi = lstProperty.Find(p => p.Name == propertyName);
            if (pi != null)
            {
                obj = pi.GetValue(t, null);
                if (obj != null)
                {
                    if (pi.PropertyType.Name == "Guid")
                    {
                        if (new Guid(obj.ToString()) == Guid.Empty)
                        {
                            obj = Guid.Empty;
                        }
                    }
                    if (pi.PropertyType.Name == "DateTime")
                    {
                        if (DateTime.Parse(obj.ToString()) == DateTime.MinValue)
                        {
                            obj = DateTime.MinValue;
                        }
                    }
                }
            }
            return obj;
        }

        ///   <summary> 
        ///  获取某一日期是该年中的第几周
        ///   </summary> 
        ///   <param name="dt"> 日期 </param> 
        ///   <returns> 该日期在该年中的周数 </returns> 
        public static int GetWeekOfYear(DateTime dt)
        {
            GregorianCalendar gc = new GregorianCalendar();
            return gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        /// <summary>
        /// 转换人民币大小金额
        /// </summary>
        /// <param name="num">金额</param>
        /// <returns>返回大写形式</returns>
        public static string NumToRMB(decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字
            string str3 = "";    //从原num值中取出的值
            string str4 = "";    //数字的字符串形式
            string str5 = "";  //人民币大写金额形式
            int i;    //循环变量
            int j;    //num的值乘以100的字符串长度
            string ch1 = "";    //数字的汉语读法
            string ch2 = "";    //数字位的汉字读法
            int nzero = 0;  //用来计算连续的零值是几个
            int temp;            //从原num值中取出的值

            num = Math.Round(Math.Abs(num), 2);    //将num取绝对值并四舍五入取2位小数
            str4 = ((long)(num * 100)).ToString();        //将num乘100并转换成字符串形式
            j = str4.Length;      //找出最高位
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j);   //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分

            //循环取出每一位需要转换的值
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //取出需转换的某一位的值
                temp = Convert.ToInt32(str3);      //转换为数字
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;
                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整”
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }
        public static string NumToChinese(decimal num) {
            string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾"; //数字位所对应的汉字
            string str4 = "";    //数字的字符串形式
            string str5 = "";  //人民币大写金额形式
            string str6 = "";
            int p = 0;  //小数点的位置
            int i;    //循环变量
            int j;    //num的值乘以100的字符串长度
            string ch1 = "";    //数字的汉语读法
            string ch2 = "";    //数字位的汉字读法
            int nzero = 0;  //用来计算连续的零值是几个
            int temp;            //从原num值中取出的值

            //num = Math.Round(Math.Abs(num), 2);    //将num取绝对值并四舍五入取2位小数
            str4 = num.ToString();        //将num转换成字符串形式
            p = str4.IndexOf(".");
            if (p > 0) {
                str6 = str4.Substring(p + 1);
                str4 = str4.Substring(0, p);
            } else if (p == 0) {
                str6 = str4.Substring(1);
                str4 = "0";
            }
            if (str4.Length > 13) { return "溢出"; }
            j = str4.Length;
            str2 = str2.Substring(13 - j);   //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分
            for (i = 0; i < j; i++) {
                char s = str4[i];
                temp = str4.Substring(i, 1).ToInt();
                if (i != (j - 5) && i != (j - 9) && i != (j - 13)) {
                    //当所取位数不为万、亿、万亿上的数字时
                    if (s == '0') {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    } else {
                        if (nzero != 0) {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                        } else {
                            ch1 = str1.Substring(temp * 1, 1);
                        }
                        if (i < j - 1) ch2 = str2.Substring(i, 1);
                        else ch2 = "";
                        nzero = 0;
                    }
                } else {
                    //该位是万亿，亿，万位等关键位
                    if (s != '0' && nzero != 0) {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    } else if (s != '0' && nzero == 0) {
                        ch1 = str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    } else if (s == '0' && nzero >= 3) {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    } else {
                        if (j >= 11) {
                            ch1 = "";
                            nzero = nzero + 1;
                        } else {
                            ch1 = "";
                            ch2 = str2.Substring(i, 1);
                            nzero = nzero + 1;
                        }
                    }
                }
                str5 = str5 + ch1 + ch2;
            }
            j = str6.Length;
            if (j > 0) str5 += "点";
            for (i = 0; i < j; i++) {
                temp = str6.Substring(i, 1).ToInt();
                str5 += str1[temp].ToString();
            }
            if (num == 0) {
                str5 = "零";
            }
            return str5;
        }

        ///   <summary> 
        ///  获取某一年有多少周
        ///   </summary> 
        ///   <param name="year"> 年份 </param> 
        ///   <returns> 该年周数 </returns> 
        public static int GetWeekAmount(int year)
        {
            DateTime end = new DateTime(year, 12, 31);   // 该年最后一天 
            System.Globalization.GregorianCalendar gc = new GregorianCalendar();
            return gc.GetWeekOfYear(end, CalendarWeekRule.FirstDay, DayOfWeek.Monday);   // 该年星期数 
        }

        public static int GetQuanter(int month) 
        {
            double f = Convert.ToDouble(month) / 3f;
            if (f > Convert.ToInt32(f))
            {
                return Convert.ToInt32(f) + 1;
            }
            return Convert.ToInt32(f); 
        }

        /// <summary>
        /// 将GUID转换为去掉中横线的字符串
        /// </summary>
        /// <returns></returns>
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static string GetDispayFormatValue(DisplayFormatStringType type) 
        {
            string displayFormat = string.Empty;
            FieldInfo field = type.GetType().GetField(type.ToString());
            if (field == null)
            {
                return displayFormat;
            }
            object[] objs = field.GetCustomAttributes(typeof(FormatValueAttribute), false);
            if (objs == null || objs.Length == 0) 
                return displayFormat;
            FormatValueAttribute da = (FormatValueAttribute)objs[0];
            if (da != null)
            {
                displayFormat = da.FormatValue;
            }
            return displayFormat;
        }

        /// <summary>
        /// 检测程序进程是否已经在运行
        /// </summary>
        /// <returns></returns>
        public static bool ProcessRunning(string _AppName, string _path)
        {
            string _ProcessName = _AppName;
            Process[] processes = Process.GetProcessesByName(_ProcessName.Substring(0, _ProcessName.Length - 4));
            //遍历正在有相同名字运行的进程
            foreach (Process process in processes)
            {
                //确保例程从EXE文件运行
                if (Path.Combine(_path, _AppName).ToLower() == process.MainModule.FileName.ToLower())
                {
                    //返回检测到主程序在运行
                    return true;
                }
            }
            //没有其它的主程序进程，返回false
            return false;
        }

        /// <summary>
        /// 启动程序
        /// </summary>
        /// <param name="fileName"></param>
        public static bool Start(string fileName)
        {
            bool isStarted = false;
            try
            {
                Process proc = Process.Start(fileName);
                if (proc != null)
                {
                    proc.WaitForExit();
                }
                isStarted = true;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
            return isStarted;
        }

        public static void StartExe(string appName, string arguments)
        {
            string path = appName;
            Process ps = new Process();
            ps.StartInfo.FileName = path;
            ps.StartInfo.Arguments = arguments;
            //ps.StartInfo.Arguments = "-routine";
            ps.StartInfo.CreateNoWindow = true;
            //ps.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);
            ps.Start();
        }

        /// <summary>
        /// 将LIST转换为SQL语句中的IN查询串
        /// </summary>
        /// <param name="lstId"></param>
        /// <returns></returns>
        public static string GetSqlIn(List<string> lstId)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string id in lstId)
            {
                sb.AppendFormat("'{0}',", id);
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }       
    }
}
