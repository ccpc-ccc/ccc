using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Log;

namespace YF.MWS.Util
{
    public class NumerFormat
    {
        // 转换数字 拾亿仟万
        private static char ToNum(char x)
        {
            string strChnNames = "零壹贰叁肆伍陆柒捌玖";
            string strNumNames = "0123456789";
            return strChnNames[strNumNames.IndexOf(x)];
        }

        // 转换万以下整数 
        private static string ChangeInt(string x)
        {
            string[] strArrayLevelNames = new string[4] { "", "拾", "佰", "仟" };
            string ret = "";
            int i;
            for (i = x.Length - 1; i >= 0; i--)
                if (x[i] == '0')
                    ret = ToNum(x[i]) + ret;
                else
                    ret = ToNum(x[i]) + strArrayLevelNames[x.Length - 1 - i] + ret;
            while ((i = ret.IndexOf("零零")) != -1)
                ret = ret.Remove(i, 1);
            if (ret[ret.Length - 1] == '零' && ret.Length > 1)
                ret = ret.Remove(ret.Length - 1, 1);
            if (ret.Length >= 2 && ret.Substring(0, 2) == "壹拾")
                ret = ret.Remove(0, 1);
            return ret;
        }

        // 转换整数 
        private static string ToInt(string x)
        {
            int len = x.Length;
            string ret, temp;
            if (len <= 4)
                ret = ChangeInt(x);
            else if (len <= 8)
            {
                ret = ChangeInt(x.Substring(0, len - 4)) + "万";
                temp = ChangeInt(x.Substring(len - 4, 4));
                if (temp.IndexOf("仟") == -1 && temp != "")
                    ret += "零" + temp;
                else
                    ret += temp;
            }
            else
            {
                ret = ChangeInt(x.Substring(0, len - 8)) + "亿";
                temp = ChangeInt(x.Substring(len - 8, 4));
                if (temp.IndexOf("仟") == -1 && temp != "")
                    ret += "零" + temp;
                else
                    ret += temp;
                ret += "万";
                temp = ChangeInt(x.Substring(len - 4, 4));
                if (temp.IndexOf("仟") == -1 && temp != "")
                    ret += "零" + temp;
                else
                    ret += temp;
            }
            int i;
            if ((i = ret.IndexOf("零万")) != -1)
                ret = ret.Remove(i + 1, 1);
            while ((i = ret.IndexOf("零零")) != -1)
                ret = ret.Remove(i, 1);
            if (ret[ret.Length - 1] == '零' && ret.Length > 1)
                ret = ret.Remove(ret.Length - 1, 1);
            return ret;
        }

        private static string ToDecimal(string x)
        {
            string ret = "";
            for (int i = 0; i < x.Length; i++)
                ret += ToNum(x[i]);
            return ret;
        }

        public static string NumToChinese(string x)
        {
            string[] P_array_num = new string[] { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            //为数字位数建立一个位数组
            string[] P_array_digit = new string[] { "", "拾", "佰", "仟" };
            //为数字单位建立一个单位数组
            string[] P_array_units = new string[] { "", "万", "亿", "万亿" };
            string P_str_returnValue = ""; //返回值
            int finger = 0; //字符位置指针
            int P_int_m = x.Length % 4; //取模
            int P_int_k = 0;
            if (P_int_m > 0)
                P_int_k = x.Length / 4 + 1;
            else
                P_int_k = x.Length / 4;
            //外层循环,四位一组,每组最后加上单位: ",万亿,",",亿,",",万,"
            for (int i = P_int_k; i > 0; i--)
            {
                int P_int_L = 4;
                if (i == P_int_k && P_int_m != 0)
                    P_int_L = P_int_m;
                //得到一组四位数
                string four = x.Substring(finger, P_int_L);
                int P_int_l = four.Length;
                //内层循环在该组中的每一位数上循环
                for (int j = 0; j < P_int_l; j++)
                {
                    //处理组中的每一位数加上所在的位
                    int n = Convert.ToInt32(four.Substring(j, 1));
                    if (n == 0)
                    {
                        if (j < P_int_l - 1 && Convert.ToInt32(four.Substring(j + 1, 1)) > 0 && !P_str_returnValue.EndsWith(P_array_num[n]))
                            P_str_returnValue += P_array_num[n];
                    }
                    else
                    {
                        if (!(n == 1 && (P_str_returnValue.EndsWith(P_array_num[0]) | P_str_returnValue.Length == 0) && j == P_int_l - 2))
                            P_str_returnValue += P_array_num[n];
                        P_str_returnValue += P_array_digit[P_int_l - j - 1];
                    }
                }
                finger += P_int_L;
                //每组最后加上一个单位:",万,",",亿," 等
                if (i < P_int_k) //如果不是最高位的一组
                {
                    if (Convert.ToInt32(four) != 0)
                        //如果所有4位不全是0则加上单位",万,",",亿,"等
                        P_str_returnValue += P_array_units[i - 1];
                }
                else
                {
                    //处理最高位的一组,最后必须加上单位
                    P_str_returnValue += P_array_units[i - 1];
                }
            }
            return P_str_returnValue;
        }

        public static string NumToChn(string x)
        {
            if (x.Length == 0)
                return "";
            string ret = "";
            try
            {
                if (x[0] == '-')
                {
                    ret = "负";
                    x = x.Remove(0, 1);
                }
                if (x[0].ToString() == ".")
                    x = "0" + x;
                if (x[x.Length - 1].ToString() == ".")
                    x = x.Remove(x.Length - 1, 1);
                if (x.IndexOf(".") > -1)
                    ret += ToInt(x.Substring(0, x.IndexOf("."))) + "点" + ToDecimal(x.Substring(x.IndexOf(".") + 1));
                else
                    ret += ToInt(x);
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
            if(ret.EndsWith("点零零"))
            {
                ret = ret.Replace("点零零", "");
            }
            if (ret.EndsWith("点零"))
            {
                ret = ret.Replace("点零", "");
            }
            return ret;
        } 
    }
}
