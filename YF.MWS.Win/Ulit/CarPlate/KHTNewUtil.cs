using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using YF.MWS.Metadata.CarPlate;
using YF.Utility.Log;

namespace YF.MWS.Win.Util
{
    public class KHTNewUtil
    {
        private KHTNewSDK.CLIENT_LPRC_DataEx2Callback DataEx2Callback = null;   // 识别回调
        private string ipFirst;
        private string ipSecond;
        IntPtr pIPFirst = IntPtr.Zero;   // 相机1 ip
        IntPtr pIPSecond = IntPtr.Zero;   // 相机2 ip
        private bool connectFirst = false;
        private bool connectSecond = false;
        /// <summary>
        /// 定义识别车牌的委托
        /// </summary>
        public delegate void RecognizePlateDelegate(PlateInfo plateInfo);

        /// <summary>
        /// 识别车牌事件
        /// </summary>
        public RecognizePlateDelegate RecognizePlate = null;

        public KHTNewUtil(string mIPFirst, string mIPSecond) 
        {
            ipFirst = mIPFirst;
            ipSecond = mIPSecond;
            try
            {
                pIPFirst = Marshal.StringToHGlobalAnsi(ipFirst);
                if (!string.IsNullOrEmpty(ipSecond))
                {
                    pIPSecond = Marshal.StringToHGlobalAnsi(ipSecond);
                }
                this.DataEx2Callback = new KHTNewSDK.CLIENT_LPRC_DataEx2Callback(OnDataEx2Callback);
                KHTNewSDK.CLIENT_LPRC_RegDataEx2Event(this.DataEx2Callback);
                //设备连接
                if (KHTNewSDK.CLIENT_LPRC_InitSDK(8080, IntPtr.Zero, 0, pIPFirst, 1) != 0)  // 用最后一个参数简单来区别相机(一般传入用户数据)
                {
                    Logger.Write("连接快号通1号相机失败");
                }
                else
                {
                    Logger.Write("连接快号通1号相机成功");
                    connectFirst = true;
                }
                if (pIPSecond != IntPtr.Zero)
                {
                    if (KHTNewSDK.CLIENT_LPRC_InitSDK(8080, IntPtr.Zero, 0, pIPSecond, 2) != 0)
                    {
                        Logger.Write("连接快号通2号相机失败");
                    }
                    else
                    {
                        Logger.Write("连接快号通2号相机成功");
                        connectSecond = true;
                    }
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }

        //识别结果回调函数
        private void OnDataEx2Callback(ref  KHTNewSDK.CLIENT_LPRC_PLATE_RESULTEX recResultEx, uint dwUser)
        {
            string carNo = recResultEx.chLicense;
            string ip = string.Empty;
            if (dwUser == 1)
            {
                ip = ipFirst;
            }
            if (dwUser == 2)
            {
                ip = ipSecond;
            }
            PlateInfo plateInfo = new PlateInfo();
            plateInfo.IP = recResultEx.chCLIENTIP;
            plateInfo.Num = carNo;
            if (RecognizePlate != null)
                RecognizePlate(plateInfo);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Release()
        {
            KHTNewSDK.CLIENT_LPRC_QuitSDK();
        }

    }
}
