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
using System.Security.Cryptography;
using System.Management;

namespace YF.MWS.Win
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
        public static string GetMachineCode() {
            var cpuInfo = GetCpuInfo();
            var diskInfo = GetHDid();
            var macAddresses = GetMoAddress();

            var sb = new StringBuilder();
            sb.Append(cpuInfo);
            sb.Append(diskInfo);
            foreach (var address in macAddresses) {
                sb.Append(address);
            }

            var inputBytes = Encoding.ASCII.GetBytes(sb.ToString());
            var provider = new MD5CryptoServiceProvider();
            var hashBytes = provider.ComputeHash(inputBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "");
        }

        ///   <summary> 
        ///   获取cpu序列号     
        ///   </summary> 
        ///   <returns> string </returns> 
        public static string GetCpuInfo() {
            string cpuInfo = "";
            try {
                using (ManagementClass cimobject = new ManagementClass("Win32_Processor")) {
                    ManagementObjectCollection moc = cimobject.GetInstances();

                    foreach (ManagementObject mo in moc) {
                        cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                        mo.Dispose();
                    }
                }
            } catch (Exception) {
                throw;
            }
            return cpuInfo.ToString();
        }

        ///   <summary> 
        ///   获取硬盘ID     
        ///   </summary> 
        ///   <returns> string </returns> 
        public static string GetHDid() {
            string HDid = "";
            try {
                using (ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive")) {
                    ManagementObjectCollection moc1 = cimobject1.GetInstances();
                    foreach (ManagementObject mo in moc1) {
                        HDid = (string)mo.Properties["Model"].Value;
                        mo.Dispose();
                    }
                }
            } catch (Exception) {

                throw;
            }
            return HDid.ToString();
        }

        ///   <summary> 
        ///   获取网卡硬件地址 
        ///   </summary> 
        ///   <returns> string </returns> 
        public static string GetMoAddress() {
            string MoAddress = "";
            try {
                using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration")) {
                    ManagementObjectCollection moc2 = mc.GetInstances();
                    foreach (ManagementObject mo in moc2) {
                        if ((bool)mo["IPEnabled"] == true)
                            MoAddress = mo["MacAddress"].ToString();
                        mo.Dispose();
                    }
                }
            } catch (Exception) {
                throw;
            }
            return MoAddress.ToString();
        }

        private static string GetCpuId() {
            var managementObject = new ManagementObject("win32_processor");
            return managementObject.GetPropertyValue("ProcessorId").ToString();
        }

        private static string GetHardDiskId() {
            var managementObject = new ManagementObject("win32_physicalmedia");
            return managementObject.GetPropertyValue("SerialNumber").ToString();
        }

        private static string GetVideoId() {
            var managementObject = new ManagementObject("win32_videocontroller");
            return managementObject.GetPropertyValue("VideoProcessorId").ToString();
        }
        private static string[] GetMacAddresses() {
            var macAddresses = new string[2];
            var mc = new ManagementClass("win32_networkAdapterConfiguration");
            var mo = mc.GetInstances();

            var i = 0;
            foreach (var o in mo) {
                if ((bool)o.GetPropertyValue("IPEnabled")) {
                    macAddresses[i] = o.GetPropertyValue("MacAddress").ToString();
                    i++;
                }
            }
            return macAddresses;
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
