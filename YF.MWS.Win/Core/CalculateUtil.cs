using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.Metadata;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Uc.Weight;
using YF.Utility;
using YF.Utility.Log;

namespace YF.MWS.Win.Core
{
    /// <summary>
    /// 计算工具类
    /// </summary>
    public class CalculateUtil
    {
        private static decimal GetValue(string controlName, List<IField> lstField) 
        {
            decimal d = 0m;
            IField field = lstField.Find(c => c.ControlName == controlName);
            if (field != null) 
            {
                d = field.CurrentValue.ToDecimal();
            }
            return d;
        }

        private static string GetFormulate(string exp, List<IField> lstField)
        {
            StringBuilder sbExp = new StringBuilder();
            int length = exp.Length;
            int nextIndex = 0;
            int index = 0;
            string controlName;
            for (int i = 0; i < length; i++)
            {
                if (i == nextIndex)
                {
                    if (exp.Substring(i, 1) == "[")
                    {
                        index = exp.IndexOf("]", i);
                        controlName = exp.Substring(i + 1, index - i - 1);
                        sbExp.Append(GetValue(controlName,lstField));
                        nextIndex = index + 1;
                    }
                    else
                    {
                        sbExp.Append(exp.Substring(i, 1));
                        nextIndex += 1;
                    }
                }
            }
            return sbExp.ToString();
        }

        public static CalculateField GetCalculateField(string controlName,string exp,int autoCalNo)
        {
            if (!string.IsNullOrEmpty(controlName) && !string.IsNullOrEmpty(exp))
            {
                CalculateField calField = new CalculateField();
                calField.ControlName = controlName;
                calField.AutoCalNo = autoCalNo;
                calField.Expression = exp;
                int length = exp.Length;
                int nextIndex = 0;
                int index = 0;
                string tempControlName;
                for (int i = 0; i < length; i++)
                {
                    if (i == nextIndex)
                    {
                        if (exp.Substring(i, 1) == "[")
                        {
                            index = exp.IndexOf("]", i);
                            tempControlName = exp.Substring(i + 1, index - i - 1);
                            calField.LstRelatedControl.Add(tempControlName);
                            nextIndex = index + 1;
                        }
                        else
                        {
                            nextIndex += 1;
                        }
                    }
                }
                return calField;
            }
            else 
            {
                return null;
            }
        }

        public static bool CanCalculatedEvent(List<CalculateField> lst, string controlName)
        {
            bool canCal = false;
            foreach (CalculateField f in lst)
            {
                if (f.LstRelatedControl != null && f.LstRelatedControl.Count > 0 && f.LstRelatedControl.Exists(c => !string.IsNullOrEmpty(c) && c == controlName))
                {
                    canCal = true;
                }
            }
            return canCal;
        }

        public static List<CalculateField> GetCalculateList(List<CalculateField> lst, string controlName) 
        {
            List<CalculateField> lstCalField = new List<CalculateField>();
            foreach (CalculateField f in lst) 
            {
                if (f.LstRelatedControl!=null && f.LstRelatedControl.Count>0 &&f.LstRelatedControl.Exists(c => !string.IsNullOrEmpty(c) && c == controlName)) 
                {
                    lstCalField.Add(f);
                }
            }
            return lstCalField;
        }

        public static void SetControlNameList(List<string> lst,string exp)
        {
            int length = exp.Length;
            int nextIndex = 0;
            int index = 0;
            string controlName;
            for (int i = 0; i < length; i++)
            {
                if (i == nextIndex)
                {
                    if (exp.Substring(i, 1) == "[")
                    {
                        index = exp.IndexOf("]", i);
                        controlName = exp.Substring(i + 1, index - i - 1);
                        if (!lst.Exists(c => c == controlName))
                        {
                            lst.Add(controlName);
                        }
                        nextIndex = index + 1;
                    }
                    else
                    {
                        nextIndex += 1;
                    }
                }
            }
        }

        public static decimal Calculate(string expression, List<IField> lstField)
        {
            object obj = 0;
            string formulate;
            try
            {
                formulate = GetFormulate(expression, lstField);
                DataTable dt = new DataTable();
                obj = dt.Compute(formulate, "");
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
            return obj.ToDecimal();
        }

        private static decimal GetWeight(WNumbericEdit editor) 
        {
            return (editor != null) ? editor.Text.ToDecimal() : 0;
        }

        public static decimal GetChargeWeight(MainWeight ucWeight, ChargeRuleType type) 
        {
            decimal weight = 0;
            var weGrossWeight = ucWeight.FindControl<WNumbericEdit>("GrossWeight");
            var weTareWeight = ucWeight.FindControl<WNumbericEdit>("TareWeight");
            var weSuttleWeight = ucWeight.FindControl<WNumbericEdit>("SuttleWeight");
            var weNetWeight = ucWeight.FindControl<WNumbericEdit>("NetWeight");
            switch (type) 
            {
                case ChargeRuleType.GrossWeight:
                    weight = GetWeight(weGrossWeight);
                    break;
                case ChargeRuleType.SummaryWeight:
                    weight = GetWeight(weGrossWeight) + GetWeight(weTareWeight);
                    break;
                case ChargeRuleType.SuttleWeight:
                    weight = GetWeight(weSuttleWeight);
                    break;
                case ChargeRuleType.TareWeight:
                    weight = GetWeight(weTareWeight);
                    break;
            }
            return weight;
        }
    }
}
