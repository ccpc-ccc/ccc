using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Win.Util
{
    public class DigitConvertUtil
    {
        /// <summary>
        /// 待转换数字值
        /// </summary>
        private double numeric;

        public double Numeric
        {
            get { return numeric; }
            set { numeric = value; }
        }

        /// <summary>
        /// 中文数字
        /// </summary>
        private string[] NumChar = new string[] { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };

        public DigitConvertUtil(double num)
        {
            this.numeric = num;
        }

        /// <summary>
        /// 判断是否为合法数字
        /// </summary>
        private bool IsNumber
        {
            get
            {
                if (this.numeric > double.MaxValue || this.numeric <= 0)
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// 数字转换为文字
        /// </summary>
        /// <returns></returns>
        public string ConvertToString()
        {
            string result = "";

            if (this.IsNumber)
            {
                string[] num = this.numeric.ToString().Split('.');
                if (num.Length == 1)
                {
                    result = this.NumberToString(num[0]);
                    result = result.Replace("零零", "零");
                }
                else
                {
                    result = this.NumberToString(num[0]) + this.FloatToString(num[1]);
                    result = result.Replace("零零", "零");
                }
            }

            return result;
        }

        /// <summary>
        /// 数字转换为文字
        /// </summary>
        /// <param name="num">待转换的数字字符串</param>
        /// <returns></returns>
        private string ConvertToChar(string num)
        {
            StringBuilder sbChar = new StringBuilder();
            for (int i = 0; i < num.Length; i++)
            {
                sbChar.Append(NumChar[int.Parse(num.Substring(i, 1))]);
            }
            return sbChar.ToString();
        }

        /// <summary>
        /// 转换两位数
        /// </summary>
        /// <param name="num">数字字符串</param>
        /// <returns></returns>
        private string ConvertTwoNum(string num)
        {
            string temp = "", result = "";
            string strNum = num.Substring(0, 1);

            if (strNum != "零")
            {
                temp = num.Replace("零", "");
                if (temp.Length == 1)
                {
                    result = num.Substring(0, 1) + "拾";
                }
                else
                {
                    result = num.Substring(0, 1) + "拾";
                    result += num.Substring(1, 1);
                }
            }
            else
                result = num;

            return result;
        }

        /// <summary>
        /// 转换三位数
        /// </summary>
        /// <param name="num">数字字符串</param>
        /// <returns></returns>
        private string ConvertThreeNum(string num)
        {
            string temp = "", result = "";
            string strNum = num.Substring(0, 2);

            if (strNum != "零零")
            {
                temp = num.Replace("零零", "");
                if (temp.Length == 1)
                {
                    result = num.Substring(0, 1) + "佰";
                }
                else
                {
                    if (num.Substring(0, 1) != "零")
                        result = num.Substring(0, 1) + "佰";
                    else
                        result = num.Substring(0, 1);

                    result += this.ConvertTwoNum(num.Substring(1, 2));
                }
            }
            else
            {
                result = num.Replace("零零", "零");
            }

            return result;
        }

        /// <summary>
        /// 转换四位数
        /// </summary>
        /// <param name="num">数字字符串</param>
        /// <returns></returns>
        private string ConvertFourNum(string num)
        {
            string result = "";

            if (num.Length == 1)
                result = this.ConvertToChar(num);
            else if (num.Length == 2)
            {
                result = this.ConvertToChar(num);
                result = this.ConvertTwoNum(result);
            }
            else if (num.Length == 3)
            {
                result = this.ConvertToChar(num);
                result = this.ConvertThreeNum(result);
            }
            else
            {
                result = this.ConvertToChar(num);
                string temp = "";
                string strNum = result.Substring(0, 4);

                if (strNum != "零零零零")
                {
                    strNum = result.Substring(0, 3);
                    if (strNum != "零零零")
                    {
                        temp = result.Replace("零零零", "");
                        if (temp.Length == 1)
                        {
                            result = result.Substring(0, 1) + "仟";
                        }
                        else
                        {
                            if (result.Substring(0, 1) != "零")
                                temp = result.Substring(0, 1) + "仟";
                            else
                                temp = result.Substring(0, 1);

                            result = temp + this.ConvertThreeNum(result.Substring(1, 3));
                        }
                    }
                    else
                    {
                        result = result.Replace("零零零", "零");
                    }
                }
                else
                {
                    result = result.Replace("零零零零", "");
                }
            }

            return result;
        }

        /// <summary>
        /// 整数转换为文字
        /// </summary>
        /// <param name="num">整数字符串</param>
        /// <returns></returns>
        private string NumberToString(string num)
        {
            string result = "";

            if (num.Length <= 4)
                result = this.ConvertFourNum(num);
            else if (num.Length > 4 && num.Length <= 8)
            {
                result = this.ConvertFourNum(num.Substring(0, num.Length - 4)) + "萬";
                result += this.ConvertFourNum(num.Substring(num.Length - 4, 4));
            }

            return result;
        }

        /// <summary>
        /// 小数转换为文字
        /// </summary>
        /// <param name="num">小数字符串</param>
        /// <returns></returns>
        private string FloatToString(string num)
        {
            string result = num.TrimEnd('0');
            if (result.Length > 0)
                result = "点" + this.ConvertToChar(result);

            return result;
        }
    }
}
