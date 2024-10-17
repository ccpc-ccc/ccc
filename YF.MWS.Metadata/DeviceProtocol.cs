using System;
using System.Collections.Generic;
using System.Text;
using YF.Utility;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 仪表协议
    /// </summary>
    public class DeviceProtocol
    {
        /// <summary>
        /// 开始位
        /// </summary>
        public byte BeginBit { get; set; }
        /// <summary>
        /// 结束位
        /// </summary>
        public byte EndBit { get; set; }

        /// <summary>
        /// 帧长度
        /// </summary>
        public int FrameLength { get; set; }

        /// <summary>
        /// 开始截取位
        /// </summary>
        public int InterceptBit { get; set; }

        /// <summary>
        /// 小数点
        /// </summary>
        public int Point { get; set; }

        /// <summary>
        /// 数据顺序
        /// </summary>
        public string Sequence { get; set; }
    }
    public class ProtoclAnaly {
        public static decimal? GetWithTOLEDO(byte[] byteFrame) {
            List<byte> listDigit = new List<byte>() { (byte)0x30, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x39 };
            int index = byteFrame.IndexOf(0,0x02);
            if (index < 0 || byteFrame.Length <= index + 10) return null;
            byte[] bs= new byte[byteFrame.Length-index];
            Buffer.BlockCopy(byteFrame, index, bs, 0, bs.Length);
            StringBuilder sbDigit = new StringBuilder();
            //获取称重数据
            for (int i = 4; i < 10; i++) {
                if (!listDigit.Contains(bs[i]))
                    bs[i] = (byte)0x30;
                sbDigit.Append(bs[i] - 0x30);
            }

            decimal weightValue = sbDigit.ToString().ToDecimal();
            byte byteState = (byte)(bs[1] & 0x07);
            switch (byteState) {
                case 3:
                    weightValue /= 10;
                    break;
                case 4:
                    weightValue /= 100;
                    break;
                case 5:
                    weightValue /= 1000;
                    break;
                case 6:
                    weightValue /= 10000;
                    break;
                case 7:
                    weightValue /= 100000;
                    break;
            }
            byte byteValue = (byte)(bs[2] & 0x02);
            if (byteValue == 0x02)
                weightValue = -weightValue;
            return weightValue;
        }
    }
}
