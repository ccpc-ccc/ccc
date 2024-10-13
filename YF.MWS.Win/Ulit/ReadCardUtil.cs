using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Metadata;

namespace YF.MWS.Win
{
    /// <summary>
    /// 读卡验证工具类
    /// </summary>
    public class ReadCardUtil
    {
        /// <summary>
        /// 是否是重复识别的结果
        /// </summary>
        /// <param name="recognitionTimeSpan"></param>
        /// <param name="result"></param>
        /// <param name="lstRecognitionResult"></param>
        /// <returns></returns>
        private static bool IsRepeated(int recognitionTimeSpan, ReadCardResult result, List<ReadCardResult> lstRecognitionResult)
        {
            bool isRepeated = false;
            ReadCardResult find = null;
            if (lstRecognitionResult != null && lstRecognitionResult.Count > 0)
            {
                find = lstRecognitionResult.Find(c => c.CardId == result.CardId);
            }
            if (find != null)
            {
                DateTime expiredTime = find.RecognitionTime.AddMinutes(recognitionTimeSpan);
                if (DateTime.Compare(result.RecognitionTime, expiredTime) <= 0)
                {
                    isRepeated = true;
                }
            }
            return isRepeated;
        }

        public static List<ReadCardResult> RefreshResult(List<ReadCardResult> lstRecognitionResult, int recognitionTimeSpan)
        {
            List<ReadCardResult> lstFreshedResult = new List<ReadCardResult>();
            foreach (ReadCardResult result in lstRecognitionResult)
            {
                DateTime dtNow = DateTime.Now;
                DateTime dtExpired = result.RecognitionTime.AddMinutes(recognitionTimeSpan);
                if (DateTime.Compare(dtNow, dtExpired) < 0)
                {
                    lstFreshedResult.Add(result);
                }
            }
            return lstFreshedResult;
        }

        /// <summary>
        /// 验证识别的卡号是否有效
        /// </summary>
        /// <param name="carNo"></param>
        /// <param name="startSameCarNoControl"></param>
        /// <param name="recognitionTimeSpan"></param>
        /// <returns></returns>
        public static bool IsValidateCardNo(ReadCardResult result, int recognitionTimeSpan, List<ReadCardResult> lstRecognitionResult)
        {
            bool isValidated = false;
            bool isRepeated = IsRepeated(recognitionTimeSpan, result, lstRecognitionResult);
            if (!isRepeated)
            {
                isValidated = true;
            }
            return isValidated;
        }
    }
}
