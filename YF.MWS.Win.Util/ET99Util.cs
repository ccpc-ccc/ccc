using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using YF.MWS.Metadata;
using YF.Utility.Log;

namespace YF.MWS.Win.Util
{
    public class ET99Util
    {
        #region 常量

        /// <summary>
        /// 函数执行成功 
        /// </summary>
        internal const int ET_SUCCESS = 0x00;

        /// <summary>
        /// 访问被拒绝，权限不够 
        /// </summary>
        internal const int ET_ACCESS_DENY = 0x01;

        /// <summary>
        /// 通讯错误，没有打开设备 
        /// </summary>
        internal const int ET_COMMUNICATIONS_ERROR = 0x02;

        /// <summary>
        /// 无效的参数，参数出错 
        /// </summary>
        internal const int ET_INVALID_PARAMETER = 0x03;

        /// <summary>
        /// 没有设置 PID 
        /// </summary>
        internal const int ET_NOT_SET_PID = 0x04;

        /// <summary>
        /// 打开指定的设备失败 
        /// </summary>
        internal const int ET_UNIT_NOT_FOUND = 0x05;

        /// <summary>
        /// 硬件错误 
        /// </summary>
        internal const int ET_HARD_ERROR = 0x06;

        /// <summary>
        /// 未知错误 
        /// </summary>
        internal const int ET_UNKNOWN_ERROR = 0x07;

        /// <summary>
        /// 验证 PIN码掩码 
        /// </summary>
        internal const int ET_PIN_ERR_MASK = 0x0F;

        /// <summary>
        /// 验证 PIN码,设备被锁定
        /// </summary>
        internal const int ET_PIN_ERR_LOCKED = 0xF0;

        /// <summary>
        /// 验证 PIN码错误且永远不锁死 
        /// </summary>
        internal const int ET_PIN_ERR_MAX = 0xFF;

        /// <summary>
        /// 表示验证普通用户 pin 
        /// </summary>
        internal const int ET_VERIFY_USERPIN = 0;

        /// <summary>
        /// 表示验证超级用户 pin 
        /// </summary>
        internal const int ET_VERIFY_SOPIN = 1;

        /// <summary>
        /// 表示数据区可读写 
        /// </summary>
        internal const int ET_USER_WRITE_READ = 0;

        /// <summary>
        /// 表示数据区只允许读
        /// </summary>
        internal const int ET_USER_READ_ONLY = 1;

        /// <summary>
        /// 常量 PID,默认的产品PID
        /// </summary>
        internal const string CONST_PID = "ffffffff";

        #endregion

        /// <summary>
        /// 根据错误码显示错误提示内容
        /// </summary>
        /// <param name="result"></param>
        public static string ShowResultText(uint result)
        {
            switch (result)
            {
                case (ET_SUCCESS):
                    {
                        return "操作成功！";
                    }
                case (ET_ACCESS_DENY):
                    {
                        return "访问被拒绝，权限不够！";
                    }
                case (ET_COMMUNICATIONS_ERROR):
                    {
                        return "通讯错误，没有打开设备 ！";
                    }
                case (ET_INVALID_PARAMETER):
                    {
                        return "无效的参数，参数出错 ！";
                    }
                case (ET_NOT_SET_PID):
                    {
                        return "没有设置 PID ！";
                    }
                case (ET_UNIT_NOT_FOUND):
                    {
                        return "打开指定的设备失败！";
                    }
                case (ET_HARD_ERROR):
                    {
                        return "硬件错误！";
                    }
                case (ET_UNKNOWN_ERROR):
                    {
                        return "未知错误！";
                    }
                case (ET_PIN_ERR_MAX):
                    {
                        return "PIN码错误！请核实。";
                    }
                case (ET_PIN_ERR_LOCKED):
                    {
                        return "PIN码错误！设备已经被锁死。";
                    }
            }

            //输出剩余PIN验证次数
            if (result > ET_PIN_ERR_LOCKED && result < ET_PIN_ERR_MAX)
            {
                return "PIN码验证错误！剩余重试次数：" + (result - ET_PIN_ERR_LOCKED).ToString();
            }

            return "未知代码！";
        }

        /// <summary>
        /// 查找计算机上指定 pid 的 ET99 个数。
        /// </summary>
        /// <param name="pid">[in]产品标识,  为固定长度 8 个字节的字符串； </param>
        /// <param name="count">[out]还回的设备个数；</param>
        /// <returns></returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_FindToken(byte[] pid, out int count);

        /// <summary>
        /// 打开指定 PID的硬件,由 index 指定打开硬件的索引， index 应该小于等于找到的 Token 数目。进入匿名用户状态。
        /// </summary>
        /// <param name="hHandle">[out]打开设备的句柄，返回给用户，供以后的函数调用；</param>
        /// <param name="pid">[in]输入的硬件设备的 pid,  为固定长度 8 个字节的字符串；</param>
        /// <param name="index">[in]打开第 index 个硬件设备。 </param>
        /// <returns>ET_SUCCESS：执行成功。 ET_UNIT_NOT_FOUND：打开指定的设备失败。</returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_OpenToken(ref IntPtr hHandle, byte[] pid, int index);

        /// <summary>
        /// 关闭指定的设备。 
        /// </summary>
        /// <param name="hHandle">[in] 设备句柄。</param>
        /// <returns>ET_SUCCESS：关闭成功。  ET_COMMUNICATIONS_ERROR：没有打开设备。</returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_CloseToken(IntPtr hHandle);

        /// <summary>
        /// 从指定的位置，读取指定的数据到指定的 BUFFER 中。此函数调用需要有User权限，且调用以后不改变安全状态。
        /// </summary>
        /// <param name="hHandle">：[in]设备句柄</param>
        /// <param name="offset">[in]偏移量 </param>
        /// <param name="len">[in]长度，不能超过 60，如果超过则需要读多次。</param>
        /// <param name="pucReadBuf">[out]读出的数据存放此缓存区中，调用者保证缓冲区大小至少是 Len，否则可能产生系统存取异常。 </param>
        /// <returns>第二章 API接口函数 ET_COMMUNICATIONS_ERROR：没有打开设备。ET_SUCCESS：表示成功。 ET_INVALID_PARAMETER：无效的参数。 ET_NOT_SET_PID：没有设置 PID。 ET_ACCESS_DENY：权限不够。 </returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_Read(IntPtr hHandle, ushort offset, int len, byte[] pucReadBuf);

        /// <summary>
        /// 将 buf 中，Length 长的数据写到指定的偏移。有存取权限控制。匿名状态不可用，且在普通用户状态时还需要检查设备的配置。不改变安全状态。
        /// </summary>
        /// <param name="hHandle">[in]设备句柄；</param>
        /// <param name="offset">[in]偏移；</param>
        /// <param name="len">[in]长度，不能超过 60，如果超过则需要写多次； </param>
        /// <param name="pucReadBuf">[in]等写入的数据缓存区指针； </param>
        /// <returns>ET_SUCCESS：表示成功。 ET_HARD_ERROR：硬件错误 ET_INVALID_PARAMETER：无效的参数。 ET_NOT_SET_PID：没有设置 PID。 ET_ACCESS_DENY：权限不够。 ET_COMMUNICATIONS_ERROR：没有打开设备。 </returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_Write(IntPtr hHandle, ushort offset, int len, byte[] pucWriteBuf);

        /// <summary>
        /// 根据参数中指定的种子，产生产品标识。种子长度不能超过 51 个字节。必须在超级用户状态下才能用，调用以后不改变安全状态。 
        /// </summary>
        /// <param name="hHandle">[in]设备句柄； </param>
        /// <param name="seedlen">[in]种子； </param>
        /// <param name="pucseed">[in]种子长度，小于等于 51； </param>
        /// <param name="pid">[out]产生的产品标识,  为固定长度 8 个字节的字符串； </param>
        /// <returns>ET_SUCCESS：表示成功； ET_HARD_ERROR：硬件错误 ET_INVALID_PARAMETER：无效的参数； ET_ACCESS_DENY：权限不够，需要先验证 SOPIN。 ET_COMMUNICATIONS_ERROR：没有打开设备。</returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_GenPID(IntPtr hHandle, int seedlen, byte[] pucseed, StringBuilder pid);

        /// <summary>
        /// 产生 16 字节的随机数，放到参数指定的 BUF中。调用者需要保护 BUF至少16 字节，否则会产生系统的存取异常。该函数在匿名状态不可用，且在函数调用以后，安全状态不变。 
        /// </summary>
        /// <param name="hHandle">[in]设备句柄 </param>
        /// <param name="pucRandBuf">[out]等写入的数据缓存区指针 </param>
        /// <returns></returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_GenRandom(IntPtr hHandle, ref byte[] pucRandBuf);

        /// <summary>
        /// 产生超级用户 PIN 码 
        /// </summary>
        /// <param name="hHandle">[in]设备句柄 </param>
        /// <param name="seedlen">[in]产生超级用户密码需要的种子。 </param>
        /// <param name="pucseed">[in]种子长度，小于等于 51 </param>
        /// <param name="pucNewSoPin">：[out]用于存放产生的超级用户密码的缓冲区指针，至少可容纳 16 字节。 </param>
        /// <returns></returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_GenSOPIN(IntPtr hHandle, int seedlen, byte[] pucseed, StringBuilder pucNewSoPin);

        /// <summary>
        /// 重新设置普通用户密码为 16 个‘F’，相当于解锁。命令执行成功后，当前安全状态变成超级用户状态。 
        /// </summary>
        /// <param name="hHandle">[in]设备句柄 </param>
        /// <param name="pucSoPin">[in]超级用户密码，16 字节。</param>
        /// <returns>如果验证超级PIN码错误，并且错误值在0xF0和ET_PIN_ERR_MAX （0xFF）之间,我们可以通过错误码&ET_PIN_ERR_MASK(0x0F)得到剩余重试次数。如果还回 0xF0 表示已经被锁死，如果还回 0xFF 表示验证出错，且 pin 永远不被锁死</returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_ResetPIN(IntPtr hHandle, byte[] pucSoPin);
        
        /// <summary>
        /// 更新参数指定的密钥，此密钥是用于计算 HMAC－MD5 的。其中 KEY的获得，是通过一个纯软件接口 HMAC_MD5（），参见相应说明。匿名状态不可用，且在普通用户状态时还需要检查设备配置。不改变安全状态。
        /// </summary>
        /// <param name="hHandle">[in]设备句柄 </param>
        /// <param name="Keyid">[in]密钥指示，取值范围（1—8） </param>
        /// <param name="pucKeyBuf">[in]KEY缓存区指针, KEY固定为 32 字节。 </param>
        /// <returns></returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_SetKey(IntPtr hHandle, int Keyid, byte[] pucKeyBuf);

        /// <summary>
        /// 标准 HMAC_MD5 的软件实现，参照 RFC2104 标准。
        /// </summary>
        /// <param name="pucText">[in]等处理的数据缓存区指针，大于 0 小于等于 51 个字节 </param>
        /// <param name="ulText_Len">[in]数据长度，大于 0 小于等于 51 </param>
        /// <param name="pucKey">[in]密钥，按标准 RFC2104，长度可以任意 </param>
        /// <param name="ulKey_Len">[in]密钥长度 </param>
        /// <param name="pucToenKey">[out]硬件计算需要的 KEY，固定 32 字节。 </param>
        /// <param name="pucDigest">[out]计算结果，固定 16 字节。 </param>
        /// <returns></returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint MD5_HMAC(byte[] pucText, byte ulText_Len, byte[] pucKey, byte ulKey_Len, byte[] pucToenKey, byte[] pucDigest); //[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 32)] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 16)]

        /// <summary>
        /// 利用硬件计算 HMAC-MD5  ，pid 为出厂时，还回错误。权限等同于 KEY的读权限。不改变安全状态。
        /// </summary>
        /// <param name="hHandle">[in]设备句柄 </param>
        /// <param name="Keyid">[in]密钥指示，范围（1—8）</param>
        /// <param name="textLen">[in]待计算的数据，大于 0 小于等于 51 个字节 </param>
        /// <param name="pucText">[in]数据长度，大于 0 小于等于 51 </param>
        /// <param name="digest">[out]散列结果的数据指针，固定长度 16 个字节。 </param>
        /// <returns></returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_HMAC_MD5(IntPtr hHandle, int Keyid, int textLen, byte[] pucText, byte[] digest); //[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 16)]

        /// <summary>
        /// 验证密码，以获得相应的安全状态，不受安全状态限制，验证成功以后，进入相应的安全状态。ET_VERIFY_USER_PIN = 验证的是普通用户PIN码，如果验证通过，则进入普通用户状态。
        /// </summary>
        /// <param name="hHandle">[in]设备句柄；</param>
        /// <param name="Flags">[in]验证 PIN的类型，见下表； </param>
        /// <param name="pucPIN">[in] PIN 码，固定长度 16 个字节。 </param>
        /// <returns></returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_Verify(IntPtr hHandle, int Flags, byte[] pucPIN);

        /// <summary>
        ///   修改普通用户密码，从 pucOldPIN，改为 pucNewPIN。普通用户密码长度固定为 16 字节。此命令可以在匿名状态下进行，命令执行成功后，进入普通用户状态。 
        /// </summary>
        /// <param name="hHandle">[in]设备句柄</param>
        /// <param name="pucOldPIN">[in]原来的密码，长度固定为 16 字节 </param>
        /// <param name="pucNewPIN">[in]新密码，长度固定为 16 字节 </param>
        /// <returns></returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_ChangeUserPIN(IntPtr hHandle, byte[] pucOldPIN, byte[] pucNewPIN);

        /// <summary>
        /// 重置安全状态，回到匿名用户状态。 
        /// </summary>
        /// <param name="hHandle">[in]设备句柄 </param>
        /// <returns></returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_ResetSecurityState(IntPtr hHandle);

        /// <summary>
        /// 获得硬件序列号。可以在匿名状态下进行。不改变安全状态。
        /// </summary>
        /// <param name="hHandle">[in]设备句柄 </param>
        /// <param name="pucSN">[out]用于存放获得的序列号，长度固定为 8 字节 </param>
        /// <returns></returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_GetSN(IntPtr hHandle, byte[] pucSN); //[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 32)]

        /// <summary>
        /// 对硬件进行配置。必须在超级用户状态下进行。不改变安全状态。 
        /// </summary>
        /// <param name="hHandle">[in]设备句柄 </param>
        /// <param name="bSoPINRetries">[in]超级 PIN 码的重试次数，范围 0—15，0 表示永远不被锁死；</param>
        /// <param name="bUserPINRetries">：[in]用户 PIN 码的重试次数，范围 0—15，0 表示永远不被锁死； </param>
        /// <param name="bUserReadOnly">[in]读写/只读标注，如下表； </param>
        /// <param name="bBack">[in]保留字，必须为 0。</param>
        /// <returns></returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_SetupToken(IntPtr hHandle, byte bSoPINRetries, byte bUserPINRetries, byte bUserReadOnly, byte bBack);

        /// <summary>
        /// 打开 LED灯，使其变亮。匿名状态不可用，不改变安全状态。设备加电后，LED灯是常亮的
        /// </summary>
        /// <param name="hHandle">[in]设备句柄 </param>
        /// <returns></returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_TurnOnLED(IntPtr hHandle);

        /// <summary>
        /// 关闭 LED灯，使其变亮。匿名状态不可用，不改变安全状态。设备加电后，LED灯是常亮的
        /// </summary>
        /// <param name="hHandle">[in]设备句柄 </param>
        /// <returns></returns>
        [DllImport("FT_ET99_API.dll")]
        public static extern uint et_TurnOffLED(IntPtr hHandle);

        /// <summary>
        /// 当前打开设备的句柄
        /// </summary>
        private IntPtr handle;

        /// <summary>
        /// 查找设备
        /// </summary>
        /// <param name="pid">设备PID</param>
        /// <returns></returns>
        public bool FindDevice(string pid)
        {
            byte[] bytPID = new byte[8];
            int count = 0;

            if (pid.Length != 8)
            {
                Logger.Write("PID错误，请输入有效的八位PID！");
                return false;
            }

            bytPID = Encoding.ASCII.GetBytes(pid);
            uint result = et_FindToken(bytPID, out count);

            if (result != ET_SUCCESS)
            {
                Logger.Write("查找加密狗失败！请确认您的PID正确。\r\n错误：" + ShowResultText(result));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 打开设备
        /// </summary>
        /// <param name="pid">设备PID</param>
        /// <param name="index">设备索引</param>
        /// <returns></returns>
        public bool OpenDevice(string pid, int index)
        {
            byte[] bytPID = new byte[8];

            if (pid.Length != 8)
            {
                Logger.Write("PID错误，请输入有效的八位PID！");
                return false;
            }

            bytPID = Encoding.ASCII.GetBytes(pid);
            uint result = et_OpenToken(ref handle, bytPID, index);

            if (result != ET_SUCCESS)
            {
                Logger.Write("打开加密狗失败！请确认您的PID正确。\r\n错误：" + ShowResultText(result));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 关闭设备
        /// </summary>
        /// <returns></returns>
        public bool CloseDevice()
        {
            uint result = et_CloseToken(handle);
            if (result == ET_SUCCESS)
            {
                handle = IntPtr.Zero;
            }
            else
            {
                Logger.Write("关闭加密狗失败！\r\n错误：" + ShowResultText(result));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 验证用户权限
        /// </summary>
        /// <param name="userPin">用户PIN码</param>
        /// <param name="role">用户角色</param>
        /// <returns></returns>
        public bool VerifyUser(string userPin, ET99Role role)
        {
            byte[] bytePIN = new byte[16];
            int flag;

            if (handle == IntPtr.Zero)
            {
                Logger.Write("没有打开加密狗设备！");
                return false;
            }

            if (userPin.Length != 16)
            {
                Logger.Write("验证用户权限：请输入有效的16位PID！");
                return false;
            }

            if (role == ET99Role.SuperUser)
            {
                flag = ET_VERIFY_SOPIN;
            }
            else
            {
                flag = ET_VERIFY_USERPIN;
            }

            bytePIN = Encoding.ASCII.GetBytes(userPin);

            uint result = et_Verify(handle, flag, bytePIN);
            if (result != ET_SUCCESS)
            {
                Logger.Write("验证用户权限失败！\r\n错误：" + ShowResultText(result));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 修改普通用户PIN码
        /// </summary>
        /// <param name="oldUserPin">旧PIN码</param>
        /// <param name="newUserPin">新PIN码</param>
        /// <returns></returns>
        public bool ModifyUserPin(string oldUserPin, string newUserPin)
        {
            byte[] byteOldUserPin = new byte[16];
            byte[] byteNewUserPin = new byte[16];

            if (handle == IntPtr.Zero)
            {
                Logger.Write("没有打开加密狗设备！");
                return false;
            }

            if (oldUserPin.Length != 16)
            {
                Logger.Write("修改普通用户PIN码：请输入有效的16位旧PID！");
                return false;
            }

            if (newUserPin.Length != 16)
            {
                Logger.Write("修改普通用户PIN码：请输入有效的16位新PID！");
                return false;
            }

            byteOldUserPin = Encoding.ASCII.GetBytes(oldUserPin);
            byteNewUserPin = Encoding.ASCII.GetBytes(newUserPin);

            uint result = et_ChangeUserPIN(handle, byteOldUserPin, byteNewUserPin);
            if (result != ET_SUCCESS)
            {
                Logger.Write("普通用户PIN码修改失败！\r\n错误：" + ShowResultText(result));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 获取硬件SN
        /// </summary>
        /// <returns></returns>
        public string GetSN()
        {
            byte[] byteSN = new byte[8];

            if (handle == IntPtr.Zero)
            {
                Logger.Write("没有打开加密狗设备！");
                return string.Empty;
            }

            uint result = et_GetSN(handle, byteSN);
            if (result == ET_SUCCESS)
            {
                string strSN = "";
                for (int i = 0; i < 8; i++)
                {
                    strSN += string.Format("{0:X2}", byteSN[i]);
                }
                return strSN;
            }
            else
            {
                Logger.Write("获取硬件SN失败！\r\n错误：" + ShowResultText(result));
                return string.Empty;
            }
        }

        /// <summary>
        /// 重置安全状态
        /// </summary>
        /// <returns></returns>
        public bool ResetStatus()
        {
            if (handle == IntPtr.Zero)
            {
                Logger.Write("没有打开加密狗设备！");
                return false;
            }

            uint result = et_ResetSecurityState(handle);
            if (result != ET_SUCCESS)
            {
                Logger.Write("重置安全状态失败！\r\n错误：" + ShowResultText(result));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 生成新的PID
        /// </summary>
        /// <param name="strSeed">生成新PID的种子</param>
        /// <returns></returns>
        public string GenPID(string strSeed)
        {
            byte[] byteSeed;
            int seedLen = strSeed.Length;

            if (handle == IntPtr.Zero)
            {
                Logger.Write("没有打开加密狗设备！");
                return string.Empty;
            }

            if (strSeed.Length <= 0)
            {
                Logger.Write("生成新的PID：请输入有效的种子！");
                return string.Empty;
            }

            StringBuilder sbNewPID = new StringBuilder();
            byteSeed = Encoding.ASCII.GetBytes(strSeed);
            uint result = et_GenPID(handle, seedLen, byteSeed, sbNewPID);

            if (result == ET_SUCCESS)
            {
                string strNewPID = sbNewPID.ToString().Trim().Substring(0, 8);
                return strNewPID;
            }
            else
            {
                Logger.Write("写入新的PID到当前设备失败！\r\n错误：" + ShowResultText(result));
                return string.Empty;
            }
        }

        /// <summary>
        /// 生成新的超级用户PIN
        /// </summary>
        /// <param name="strSeed">生成新的超级用户PIN的种子</param>
        /// <returns></returns>
        public string GenSoPin(string strSeed)
        {
            byte[] byteSeed;
            StringBuilder sbNewPIN = new StringBuilder(16);
            int seedLen = strSeed.Length;

            if (handle == IntPtr.Zero)
            {
                Logger.Write("没有打开加密狗设备！");
                return string.Empty;
            }

            if (strSeed.Length <= 0)
            {
                Logger.Write("生成新的超级用户PIN：请输入有效的种子！");
                return string.Empty;
            }

            byteSeed = Encoding.ASCII.GetBytes(strSeed);
            uint result = et_GenSOPIN(handle, seedLen, byteSeed, sbNewPIN);
            if (result == ET_SUCCESS)
            {
                string strNewPID = sbNewPIN.ToString().Trim();
                return strNewPID;
            }
            else
            {
                Logger.Write("产生新的超级用户PIN失败！\r\n错误：" + ShowResultText(result));
                return string.Empty;
            }
        }

        /// <summary>
        /// 重置普通用户PIN为：ffffffffffffffff
        /// </summary>
        /// <param name="strSoPIN">超级用户PIN</param>
        /// <returns></returns>
        public bool ResetUserPin(string strSoPIN)
        {
            byte[] bytePIN = new byte[16];

            if (handle == IntPtr.Zero)
            {
                Logger.Write("没有打开加密狗设备！");
                return false;
            }

            if (strSoPIN.Length != 16)
            {
                Logger.Write("重置普通用户PIN码：请输入有效的16位超级用户PIN！");
                return false;
            }

            bytePIN = Encoding.ASCII.GetBytes(strSoPIN);
            uint result = et_ResetPIN(handle, bytePIN);
            if (result != ET_SUCCESS)
            {
                Logger.Write("重置普通用户PIN码失败！\r\n错误：" + ShowResultText(result));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 设置MD5校验密钥
        /// </summary>
        /// <param name="index">标志位（1-8）</param>
        /// <param name="strKey">MD5Key</param>
        /// <returns></returns>
        public bool SetMd5Key(int index, string strKey)
        {
            byte[] byteShortKey;

            if (handle == IntPtr.Zero)
            {
                Logger.Write("没有打开加密狗设备！");
                return false;
            }

            if (strKey.Length <= 0)
            {
                Logger.Write("设置MD5校验密钥：请输入有效的KEY！");
                return false;
            }

            if (index < 1 || index > 8)
            {
                Logger.Write("设置MD5校验密钥：请输入正确的标志位！允许的取值范围1-8。");
                return false;
            }

            //生成需要写入的KEY
            byteShortKey = new byte[strKey.Length];
            byteShortKey = Encoding.ASCII.GetBytes(strKey);

            byte[] randombuffer = new byte[51];
            byte keylen = byte.Parse(strKey.Length.ToString());
            byte randomlen = 51;

            byte[] byteMd5Key = new byte[32];
            byte[] bytedigest = new byte[16];

            //第一个参数是随机数，在设置密钥时没有作用
            //第二个参数是随机数长度，在设置密钥时没有作用
            //第三个参数是分配给客户的密钥
            //第四个参数是分配给客户的密钥的长度
            //第五个参数是返回的32字节的密钥，用于存到锁内
            //第六个参数在设置密钥时没有作用
            uint result = MD5_HMAC(randombuffer, randomlen, byteShortKey, keylen, byteMd5Key, bytedigest);

            result = et_SetKey(handle, index, byteMd5Key);
            if (result != ET_SUCCESS)
            {
                Logger.Write("设置MD5校验密钥失败！\r\n错误：" + ShowResultText(result));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 设置设备参数
        /// </summary>
        /// <param name="soPinRetries">超级用户PIN重试次数</param>
        /// <param name="userPinRetries">普通用户PIN重试次数</param>
        /// <param name="rule">普通用户读写权限</param>
        /// <returns></returns>
        public bool SetDeviceParam(int soPinRetries, int userPinRetries, ET99Rule rule)
        {
            byte byteUserRule;
            byte byteSoPinRetries = 0;
            byte byteUserPinRetries = 0;
            byte byteBack = 0;

            if (handle == IntPtr.Zero)
            {
                Logger.Write("没有打开加密狗设备！");
                return false;
            }

            if (soPinRetries < 0 || soPinRetries > 15)
            {
                Logger.Write("请输入有效的超级用户PIN重试次数(0-15)！");
                return false;
            }
            else
            {
                byte.TryParse(soPinRetries.ToString(), out byteSoPinRetries);
            }

            if (userPinRetries < 0 || userPinRetries > 15)
            {
                Logger.Write("请输入有效的普通用户PIN重试次数(0-15)！");
                return false;
            }
            else
            {
                byte.TryParse(userPinRetries.ToString(), out byteUserPinRetries);
            }

            if (rule == ET99Rule.ReadWrite)
            {
                byteUserRule = ET_USER_WRITE_READ;
            }
            else
            {
                byteUserRule = ET_USER_READ_ONLY;
            }

            uint result = et_SetupToken(handle, byteSoPinRetries, byteUserPinRetries, byteUserRule, byteBack);
            if (result != ET_SUCCESS)
            {
                Logger.Write("设备参数设置失败！\r\n错误：" + ShowResultText(result));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 验证软件和设备的计算结果是否一致
        /// </summary>
        /// <param name="strVerify">待验证计算字符串</param>
        /// <param name="strMD5Key">MD5Key</param>
        /// <param name="index">设备密钥存储区索引</param>
        /// <returns></returns>
        public bool VerifyMd5HMAC(string strVerify, string strMD5Key, int index)
        {
            uint result = 0;
            byte[] byteVerify;

            string strSoftDigest = "";
            string strDeviceDigest = "";

            if (handle == IntPtr.Zero)
            {
                Logger.Write("没有打开加密狗设备！");
                return false;
            }

            if (strVerify.Length < 1 || strVerify.Length > 51)
            {
                Logger.Write("验证计算结果：请输入有效的字符！允许的长度为：1-51");
                return false;
            }

            byteVerify = new byte[strVerify.Length];
            byteVerify = Encoding.ASCII.GetBytes(strVerify);

            //软件计算
            byte[] byteShortKey;
            byteShortKey = new byte[strMD5Key.Length];
            byteShortKey = Encoding.ASCII.GetBytes(strMD5Key);
            byte keylen = byte.Parse(strMD5Key.Length.ToString());
            byte randomlen = byte.Parse(strVerify.Length.ToString());

            byte[] byteMd5Key = new byte[32];
            byte[] bytedigest = new byte[16];
            //第一个参数是随机数
            //第二个参数是随机数长度
            //第三个参数是分配给客户的密钥（应该从数据库中取出）
            //第四个参数是分配给客户的密钥的长度
            //第五个参数没有作用
            //第六个参数为软件计算的结果
            result = MD5_HMAC(byteVerify, randomlen, byteShortKey, keylen, byteMd5Key, bytedigest);

            if (result == ET_SUCCESS)
            {
                for (int i = 0; i < 16; i++)
                {
                    strSoftDigest += string.Format("{0:X2}", bytedigest[i]);
                }
            }
            else
            {
                Logger.Write("验证计算结果：操作失败！\r\n错误：" + ShowResultText(result));
                return false;
            }

            //设备计算
            //第一个参数为设备的handle句柄
            //第二个参数为硬件中密钥索引
            //第三个参数为随机数长度
            //第四个参数为随机数
            //第五个参数为硬件中计算结果
            result = et_HMAC_MD5(handle, index, strVerify.Length, byteVerify, bytedigest);

            if (result == ET_SUCCESS)
            {
                for (int i = 0; i < 16; i++)
                {
                    strDeviceDigest += string.Format("{0:X2}", bytedigest[i]);
                }
            }
            else
            {
                Logger.Write("验证计算结果：操作失败！\r\n错误：" + ShowResultText(result));
                return false;
            }

            return strSoftDigest.Equals(strDeviceDigest);
        }

        /// <summary>
        /// 写数据
        /// </summary>
        /// <param name="strWrite">待写入的数据</param>
        /// <param name="offset">设备存储区的写入偏移</param>
        /// <returns></returns>
        public bool WriteData(string strWrite, int offset)
        {
            byte[] byteWrite = new byte[strWrite.Length];
            byteWrite = Encoding.ASCII.GetBytes(strWrite);

            if (handle == IntPtr.Zero)
            {
                Logger.Write("没有打开加密狗设备！");
                return false;
            }

            uint result = et_Write(handle, (ushort)offset, strWrite.Length, byteWrite);

            if (result == ET_HARD_ERROR)
            {
                Logger.Write("写数据：硬件错误！");
                return false;
            }
            if (result == ET_ACCESS_DENY)
            {
                Logger.Write("写数据：权限不够！");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 读数据
        /// </summary>
        /// <param name="offset">设备存储区的读取偏移</param>
        /// <param name="len">读取的字节数</param>
        /// <returns></returns>
        public string ReadData(int offset, int len)
        {
            byte[] byteRead = new byte[len];

            if (handle == IntPtr.Zero)
            {
                Logger.Write("没有打开加密狗设备！");
                return string.Empty;
            }

            uint result = et_Read(handle, (ushort)offset, len, byteRead);

            if (result == ET_HARD_ERROR)
            {
                Logger.Write("读数据：硬件错误！");
                return string.Empty;
            }
            if (result == ET_ACCESS_DENY)
            {
                Logger.Write("读数据：权限不够！");
                return string.Empty;
            }

            string strRead = Encoding.ASCII.GetString(byteRead);

            return strRead;
        }

        /// <summary>
        /// 清空数据存储区数据
        /// </summary>
        /// <returns></returns>
        public bool Clear()
        {
            //将锁内的数据区全部写成0x00
            byte[] byteZero = new byte[50];
            uint result = 0;

            for (int i = 0; i < 50; i++)
            {
                byteZero[i] = 0x00;
            }

            for (int i = 0; i < 20; i++)
            {
                result = et_Write(handle, (ushort)(i * 50), 50, byteZero);
                if (result != ET_SUCCESS)
                {
                    Logger.Write("清空数据存储区数据：失败！");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 打开LED
        /// </summary>
        /// <returns></returns>
        public bool TurnOnLED()
        {
            if (handle == IntPtr.Zero)
            {
                Logger.Write("没有打开加密狗设备！");
                return false;
            }

            uint result = et_TurnOnLED(handle);

            if (result != ET_SUCCESS)
            {
                Logger.Write("打开LED：操作失败！\r\n错误：" + ShowResultText(result));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 关闭LED
        /// </summary>
        /// <returns></returns>
        public bool TurnOffLED()
        {
            if (handle == IntPtr.Zero)
            {
                Logger.Write("没有打开加密狗设备！");
                return false;
            }

            uint result = et_TurnOffLED(handle);

            if (result != ET_SUCCESS)
            {
                Logger.Write("关闭LED：操作失败！\r\n错误：" + ShowResultText(result));
                return false;
            }

            return true;
        }
    }
}
