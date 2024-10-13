using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using YF.Utility.Log;

namespace YF.MWS.Util
{
    public static class RegeditUtil
    {
        public static void InsertDomain(string domain, string prefix)
        {
            try
            {
                RegistryKey hkml = Registry.CurrentUser;//读取HKEY_CURRENT_USER
                string address = @"SOFTWARE\MICROSOFT\WINDOWS\CURRENTVERSION\INTERNET SETTINGS\ZONEMAP\Domains";
                RegistryKey key1 = hkml.OpenSubKey(address, true);
                RegistryKey regDomain = key1.CreateSubKey(domain);
                RegistryKey regWww = regDomain.CreateSubKey(prefix);
                regWww.SetValue("http", 0x2, RegistryValueKind.DWord);
                key1.Close();
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        public static void InsertIP(string ip, string name)
        {
            try
            {
                RegistryKey hkml = Registry.CurrentUser;//读取HKEY_CURRENT_USER     
                string address = @"SOFTWARE\MICROSOFT\WINDOWS\CURRENTVERSION\INTERNET SETTINGS\ZONEMAP\RANGES";
                RegistryKey key1 = hkml.OpenSubKey(address, true);
                RegistryKey Name1 = key1.CreateSubKey(name);//新建项  
                Name1.SetValue(":Range", ip, RegistryValueKind.String);//赋值   
                Name1.SetValue("http", 0x2, RegistryValueKind.DWord);//赋值
                key1.Close();
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }
    }
}
