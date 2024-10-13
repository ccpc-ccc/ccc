using System;
using System.Runtime.InteropServices;
using System.Text;
using YF.Utility.Log;

namespace YF.MWS.Win
{
    public class RF35Util
    {
        /// <summary>
        /// 初始化串口
        /// </summary>
        /// <param name="port">串口号，取值为0～3</param>
        /// <param name="baud">通讯波特率，取值为9600～115200</param>
        /// <returns>成功则返回串口标识符>0，失败返回负值</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_init", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int rf_init(Int16 port, int baud);

        /// <summary>
        /// 释放串口
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <returns>无</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_exit", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_exit(int icdev);

        /// <summary>
        /// 蜂鸣
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="msec">蜂鸣时间，单位是10毫秒</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_beep", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_beep(int icdev, int msec);

        /// <summary>
        /// 取得读写器硬件版本号，如“mwrf100_v3.0”
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="state">返回版本信息</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_get_status", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_get_status(int icdev, [MarshalAs(UnmanagedType.LPArray)]byte[] state);

        /// <summary>
        /// 将密码装入读写模块RAM中
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="mode">装入密码模式，同密码验证模式</param>
        /// <param name="secnr">扇区号（M1卡：0～15；  ML卡：0）</param>
        /// <param name="keybuff">写入读写器中的卡密码</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_load_key", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_load_key(int icdev, int mode, int secnr, [MarshalAs(UnmanagedType.LPArray)]byte[] keybuff);

        /// <summary>
        /// 向读写器中装入十六进制密码
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="mode">密码验证模式</param>
        /// <param name="secnr">扇区号（0～15）</param>
        /// <param name="keybuff">写入读写器中的卡密码</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_load_key_hex", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_load_key_hex(int icdev, int mode, int secnr, [MarshalAs(UnmanagedType.LPArray)]byte[] keybuff);

        /// <summary>
        /// ASSIC码转换为十六进制数
        /// </summary>
        /// <param name="asc">ASSIC码字节数组</param>
        /// <param name="hex">十六进制数字节数组</param>
        /// <param name="len">数据长度</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "a_hex", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 a_hex([MarshalAs(UnmanagedType.LPArray)]byte[] asc, [MarshalAs(UnmanagedType.LPArray)]byte[] hex, int len);

        /// <summary>
        /// 十六进制数转换为ASSIC码
        /// </summary>
        /// <param name="hex">十六进制数字节数组</param>
        /// <param name="asc">ASSIC码字节数组</param>
        /// <param name="len">数据长度</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "hex_a", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 hex_a([MarshalAs(UnmanagedType.LPArray)]byte[] hex, [MarshalAs(UnmanagedType.LPArray)]byte[] asc, int len);

        /// <summary>
        /// 射频读写模块复位
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="msec">复位时间，0～500毫秒有效</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_reset", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_reset(int icdev, int msec);

        /// <summary>
        /// 寻卡请求
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="mode">寻卡模式</param>
        /// <param name="tagtype">卡类型值，0x0004为M1卡，0x0010为ML卡</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_request", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_request(int icdev, int mode, out UInt16 tagtype);

        /// <summary>
        /// 卡防冲突，返回卡的序列号
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="bcnt">设为0</param>
        /// <param name="snr">返回的卡序列号地址</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_anticoll", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_anticoll(int icdev, int bcnt, out uint snr);

        /// <summary>
        /// 从多个卡中选取一个给定序列号的卡
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="snr">卡序列号</param>
        /// <param name="size">指向返回的卡容量的数据</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_select", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_select(int icdev, uint snr, out byte size);

        /// <summary>
        /// 寻卡，能返回在工作区域内某张卡的序列号
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="mode">寻卡模式</param>
        /// <param name="snr">返回的卡序列号</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_card", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_card(int icdev, int mode, [MarshalAs(UnmanagedType.LPArray)]byte[] snr);

        /// <summary>
        /// 验证某一扇区密码
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="mode">密码验证模式</param>
        /// <param name="secnr">要验证密码的扇区号（0～15）</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_authentication", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_authentication(int icdev, int mode, int secnr);

        /// <summary>
        /// 验证某一扇区密码
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="mode">密码验证模式</param>
        /// <param name="keynr">密码扇区号（0～15）</param>
        /// <param name="blocknr">要验证的块地址</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_authentication_2", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_authentication_2(int icdev, int mode, int keynr, int blocknr);

        /// <summary>
        /// 读取卡中数据
        /// 对于M1卡，一次读一个块的数据，为16个字节；
        /// 对于ML卡，一次读出相同属性的两页（0和1，2和3，...），为8个字节
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="blocknr">M1卡——块地址（0～63）；ML卡——页地址（0～11）</param>
        /// <param name="databuff">读出数据</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_read", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_read(int icdev, int blocknr, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

        /// <summary>
        /// 读取卡中数据
        /// 对于M1卡，一次读一个块的数据，为16个字节；
        /// 对于ML卡，一次读出相同属性的两页（0和1，2和3，...），为8个字节
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="blocknr">M1卡——块地址（0～63）；ML卡——页地址（0～11）</param>
        /// <param name="databuff">读出数据，数据以十六进制形式表示</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_read_hex", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_read_hex(int icdev, int blocknr, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

        /// <summary>
        /// 向卡中写入数据
        /// 对于M1卡，一次必须写一个块，为16个字节；
        /// 对于ML卡，一次必须写一页，为4个字节
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="blocknr">M1卡——块地址（1～63）；ML卡——页地址（2～11）</param>
        /// <param name="databuff">要写入的数据</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_write", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_write(int icdev, int blocknr, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

        /// <summary>
        /// 向卡中写入数据
        /// 对于M1卡，一次必须写一个块，为16个字节；
        /// 对于ML卡，一次必须写一页，为4个字节
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="blocknr">M1卡——块地址（1～63）；ML卡——页地址（2～11）</param>
        /// <param name="databuff">要写入的数据，数据以十六进制形式表示</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_write_hex", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_write_hex(int icdev, int blocknr, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

        /// <summary>
        /// 中止对该卡操作
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_halt", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_halt(int icdev);

        /// <summary>
        /// 修改块3的数据
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="sector">扇区号（0～15）</param>
        /// <param name="keya">密码A</param>
        /// <param name="B0">块0控制字，低3位（D2D1D0）对应C10、C20、C30</param>
        /// <param name="B1">块1控制字，低3位（D2D1D0）对应C11、C21、C31</param>
        /// <param name="B2">块2控制字，低3位（D2D1D0）对应C12、C22、C32</param>
        /// <param name="B3">块3控制字，低3位（D2D1D0）对应C13、C23、C33</param>
        /// <param name="Bk">保留参数，取值为0</param>
        /// <param name="keyb">密码B</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("mwrf32.dll", EntryPoint = "rf_changeb3", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_changeb3(int icdev, int sector, [MarshalAs(UnmanagedType.LPArray)]byte[] keya, int B0, int B1, int B2, int B3, int Bk, [MarshalAs(UnmanagedType.LPArray)]byte[] keyb);

        public static string GetCardId(byte[] snr) 
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte sn in snr) 
            {
                if (sn == 0)
                    continue;
                sb.AppendFormat(sn.ToString("X2"));
                //if (sn.ToString().Length < 3)
                //{
                //    sb.AppendFormat(sn.ToString().PadLeft(3, '0'));
                //}
                //else 
                //{
                //    sb.Append(sn.ToString());
                //}
            }
            return sb.ToString();
        }
    }
}
