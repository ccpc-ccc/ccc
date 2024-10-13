using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.Utility.Security;
using YF.Utility;
using System.IO;
using YF.Utility.Configuration;

namespace YF.MWS.Win.Util
{
    /// <summary>
    /// 软件注册验证
    /// </summary>
    public class SoftValidator
    {
        /// <summary>
        /// 获取本机的机器码
        /// </summary>
        /// <returns></returns>
        public static string GetMachineCode() 
        {
            string machineCode = SoftRegister.GenerateMachineCode();
            CodeGeneratorMode mode = AppSetting.GetValue("codeGeneratorMode").ToEnum<CodeGeneratorMode>();
            if (mode == CodeGeneratorMode.Auto)
            {
                machineCode = SoftRegister.GenerateMachineCode();
            }
            else
            {
                machineCode = AppSetting.GetValue("machineCode");
            }
            return machineCode;
        }

        /// <summary>
        /// 通过验证注册文件来获取验证结果(正式版使用)
        /// </summary>
        /// <param name="client"></param>
        /// <param name="machineCode"></param>
        /// <returns></returns>
        public static ValidateResult ValidateWithRegisterFile(SClient client, string machineCode)
        {
            ValidateResult result = new ValidateResult();
            if (client != null)
            {
                if (!string.IsNullOrEmpty(client.ExpireCode))
                {
                    string endDate = DateTime.Now.ToString("yyyyMMdd");
                    string expiredDate = YF.Utility.Security.Encrypt.DecryptDES(client.ExpireCode, CurrentClient.Instance.EncryptKey);
                    if (YF.MWS.Util.Utility.CompareDate(expiredDate, endDate) != -1)
                    {
                        result.IsExpired = true;
                    }
                    int totalTimes = YF.Utility.Security.Encrypt.DecryptDES(client.TotalTimes, CurrentClient.Instance.EncryptKey).ToInt();
                    int usedTimes = YF.Utility.Security.Encrypt.DecryptDES(client.UsedTimes, CurrentClient.Instance.EncryptKey).ToInt();
                    if (usedTimes >= totalTimes)
                    {
                        result.IsExpired = true;
                    }
                }
                if (!string.IsNullOrEmpty(client.MachineCode) && !string.IsNullOrEmpty(client.RegisterCode))
                {
                    if (!string.IsNullOrEmpty(machineCode))
                    {
                        string registerCode = SoftRegister.GenerateRegisterCode(machineCode).ToMd5();
                        if (registerCode.ToLower() == client.RegisterCode.ToMd5().ToLower())
                        {
                            result.IsRegistered = true;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取验证结果(试用版使用)
        /// </summary>
        /// <param name="client"></param>
        /// <param name="machineCode"></param>
        /// <returns></returns>
        public static ValidateResult ValidateProbation(SClient client, string machineCode)
        {
            ValidateResult result = new ValidateResult();
            int maxUsedTimes = 30;
            if (client != null)
            {
                if (!string.IsNullOrEmpty(client.ExpireCode))
                {
                    string endDate = DateTime.Now.ToString("yyyyMMdd");
                    string expiredDate = YF.Utility.Security.Encrypt.DecryptDES(client.ExpireCode, CurrentClient.Instance.EncryptKey);
                    if (YF.MWS.Util.Utility.CompareDate(expiredDate, endDate) != -1)
                    {
                        result.IsExpired = true;
                    }
                    int totalTimes = YF.Utility.Security.Encrypt.DecryptDES(client.TotalTimes, CurrentClient.Instance.EncryptKey).ToInt();
                    if (totalTimes > maxUsedTimes)
                    {
                        totalTimes = maxUsedTimes;
                    }
                    int usedTimes = YF.Utility.Security.Encrypt.DecryptDES(client.UsedTimes, CurrentClient.Instance.EncryptKey).ToInt();
                    if (usedTimes >= totalTimes)
                    {
                        result.IsExpired = true;
                    }
                    int availableTimes = totalTimes - usedTimes;
                    if (availableTimes <= 0)
                    {
                        availableTimes = 0;
                        result.IsExpired = true;
                    }
                    else 
                    {
                        result.IsRegistered = true;
                    }
                    result.AvailableTimes = availableTimes;
                }
            }
            return result;
        }

        public static ValidateResult ValidateProbation(string filePath)
        {
            ValidateResult result = new ValidateResult();
            result.IsRegistered = true;
            if (!File.Exists(filePath))
            {
                CreateProbationRegisterFile(filePath);
            }
            string[] contents = File.ReadAllLines(filePath);
            string now = DateTime.Now.ToString("yyyyMMdd");
            if (contents != null || contents.Length == 2)
            {
                string currentDate = YF.Utility.Security.Encrypt.DecryptDES(contents[1], CurrentClient.Instance.EncryptKey);
                int usedTimes = Encrypt.DecryptDES(contents[0], CurrentClient.Instance.EncryptKey).ToInt();
                if (YF.MWS.Util.Utility.CompareDate(now, currentDate) != 0)
                {
                    usedTimes += 1;
                    List<string> lstContent = new List<string>();
                    lstContent.Add(YF.Utility.Security.Encrypt.EncryptDES(usedTimes.ToString(), CurrentClient.Instance.EncryptKey));
                    lstContent.Add(YF.Utility.Security.Encrypt.EncryptDES(DateTime.Now.ToString("yyyyMMdd"), CurrentClient.Instance.EncryptKey));
                    File.WriteAllLines(filePath, lstContent.ToArray());
                }
                int availableTimes = 30 - usedTimes;
                if (availableTimes <= 0)
                {
                    availableTimes = 0;
                    result.IsExpired = true;
                }
                result.AvailableTimes = availableTimes;
            }
            return result;
        }

        public static bool ValidateExpireDate()
        {
            bool isValidated = false;
            DateTime expireDate = Encrypt.DecryptDES(AppSetting.GetValue("expireDate")).ToDateTime();
            DateTime now = DateTime.Now;
            if (expireDate > now)
                isValidated = true;
            return isValidated;
        }

        private static void CreateProbationRegisterFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                List<string> lstContent = new List<string>();
                lstContent.Add(YF.Utility.Security.Encrypt.EncryptDES("1", CurrentClient.Instance.EncryptKey));
                lstContent.Add(YF.Utility.Security.Encrypt.EncryptDES(DateTime.Now.ToString("yyyyMMdd"), CurrentClient.Instance.EncryptKey));
                File.WriteAllLines(filePath, lstContent.ToArray());
            }
        }
    }
}
