using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using YF.Utility.Log;

namespace YF.MWS.Win.Util.Video.DHNew
{
    public class DHVideo
    {
        private IntPtr m_LoginID = IntPtr.Zero;
        private NET_DEVICEINFO_Ex m_DeviceInfo;
        private const int m_WaitTime = 5000;
        
        private static fHaveReConnectCallBack m_ReConnectCallBack;
        private static fRealDataCallBackEx2 m_RealDataCallBackEx2;
        private static fSnapRevCallBack m_SnapRevCallBack;
        private IntPtr loginId = IntPtr.Zero;
        /// <summary>
        /// 实时预览句柄
        /// </summary>
        private IntPtr realPlayHandle = IntPtr.Zero;

        public DHVideo() 
        {
            m_ReConnectCallBack = new fHaveReConnectCallBack(ReConnectCallBack);
            m_RealDataCallBackEx2 = new fRealDataCallBackEx2(RealDataCallBackEx);
            m_SnapRevCallBack = new fSnapRevCallBack(SnapRevCallBack);
        }

        public bool Capture(string filePath)
        {
            bool isCaptured = false;
            try
            {
                if (realPlayHandle != IntPtr.Zero)
                {
                    isCaptured = NETClientNew.CapturePicture(realPlayHandle, filePath, EM_NET_CAPTURE_FORMATS.JPEG_70);
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
            return isCaptured;
        }

        public  bool Login(string ip, int port, string userName, string password)
        {
            bool isLogined = false;
            m_DeviceInfo = new NET_DEVICEINFO_Ex();
            m_LoginID = NETClientNew.Login(ip, (ushort)port, userName, password, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref m_DeviceInfo);
            if (IntPtr.Zero == m_LoginID)
            {
                Logger.Write(string.Format("登录大华摄像头失败,原因:" + NETClientNew.GetLastError()));
                return isLogined;
            }
            else 
            {
                Logger.Write("登录大华摄像头成功");
                isLogined = true;
            }
            return isLogined;
        }

        public bool Logout() 
        {
            return NETClientNew.Logout(m_LoginID);
        }

        public bool PreviewCamera(IntPtr hWnd, int channelNo) 
        {
            bool isPreview = false;
            realPlayHandle = NETClientNew.RealPlay(m_LoginID, channelNo, hWnd, EM_RealPlayType.Realplay_1);
            if (realPlayHandle != IntPtr.Zero)
            {
                NETClientNew.SetRealDataCallBack(realPlayHandle, m_RealDataCallBackEx2, IntPtr.Zero, EM_REALDATA_FLAG.DATA_WITH_FRAME_INFO | EM_REALDATA_FLAG.PCM_AUDIO_DATA | EM_REALDATA_FLAG.RAW_DATA | EM_REALDATA_FLAG.YUV_DATA);
                isPreview = true;
            }
            return isPreview;
        }

        #region CallBack 回调


        private void ReConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {

        }

        private void RealDataCallBackEx(IntPtr lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr param, IntPtr dwUser)
        {
            //do something such as save data,send data,change to YUV. 比如保存数据，发送数据，转成YUV等.
        }

        private void SnapRevCallBack(IntPtr lLoginID, IntPtr pBuf, uint RevLen, uint EncodeType, uint CmdSerial, IntPtr dwUser)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "capture";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (EncodeType == 10) //.jpg
            {
                DateTime now = DateTime.Now;
                string fileName = "async" + CmdSerial.ToString() + ".jpg";
                string filePath = path + "\\" + fileName;
                byte[] data = new byte[RevLen];
                Marshal.Copy(pBuf, data, 0, (int)RevLen);
                using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    stream.Write(data, 0, (int)RevLen);
                    stream.Flush();
                    stream.Dispose();
                }
            }
        }
        #endregion
    }
}
