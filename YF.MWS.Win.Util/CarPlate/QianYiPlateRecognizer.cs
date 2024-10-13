using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.MWS.Metadata.CarPlate;
using YF.Utility.Log;

namespace YF.MWS.Win.Util.CarPlate
{
    /// <summary>
    /// 芊熠车牌识别仪
    /// </summary>
    public class QianYiPlateRecognizer
    {
        private string ip;
        private static int nCamId = -1;
        private static QianYiSdk.FGetImageCB2 fGetImageCB2;
        private static QianYiSdk.FGetOffLinePayRecordCB fGetOffLinePayRecordCB;
        private static QianYiSdk.FGetOffLineImageCBEx fGetOffLineImageCBEx;
        private static QianYiSdk.FGetReportCBEx fGetReportCBEx;
        private static QianYiSdk.T_VideoDetectParamSetup tVideoDetectParamSetup;
        /// <summary>
        /// 定义识别车牌的委托
        /// </summary>
        public delegate void RecognizePlateDelegate(PlateInfo plateInfo);
        /// <summary>
        /// 识别车牌事件
        /// </summary>
        public RecognizePlateDelegate RecognizePlate = null;
        private bool loginSuccess = false;
        private PictureBox pbVideo = null;

        public bool LoginSuccess
        {
            get { return loginSuccess; }
            set { loginSuccess = value; }
        }

        public QianYiPlateRecognizer(string ip, PictureBox pbVideo) 
        {
            this.ip = ip;
            this.pbVideo = pbVideo;
            QianYiSdk.Net_Init();
            Login();
        }

        private bool Login() 
        {
            bool isSuccess = false;
            try
            {
                nCamId = QianYiSdk.Net_AddCamera(ip);
                if (nCamId == -1)
                {
                    Logger.Write("QY添加相机失败!");
                    return isSuccess;
                }
                int iRet = QianYiSdk.Net_ConnCamera(nCamId, 30000, 10);
                if (iRet != 0)
                {
                    QianYiSdk.Net_DelCamera(nCamId);
                    Logger.Write("QY连接相机失败!");
                    return isSuccess;
                }
                else
                {
                    loginSuccess = true;
                }
                if (pbVideo != null)
                {
                    iRet = QianYiSdk.Net_StartVideo(nCamId, 0, pbVideo.Handle);
                    if (iRet != 0)
                    {
                        QianYiSdk.Net_DisConnCamera(nCamId);
                        QianYiSdk.Net_DelCamera(nCamId);
                        Logger.Write("打开QY视频失败!");
                        loginSuccess = false;
                        return isSuccess;
                    }
                }
                QianYiSdk.Net_RegOffLineClient(nCamId);

                // if (fGetImageCB == null)
                //fGetImageCB = new MyClass.FGetImageCB(FGetImageCB);
                //MyClass.Net_RegImageRecv(fGetImageCB);
                if (fGetImageCB2 == null)
                    fGetImageCB2 = new QianYiSdk.FGetImageCB2(FGetImageCB2);
                QianYiSdk.Net_RegImageRecv2(fGetImageCB2);

                if (fGetOffLinePayRecordCB == null)
                    fGetOffLinePayRecordCB = new QianYiSdk.FGetOffLinePayRecordCB(FGetOffLinePayRecordCB);
                QianYiSdk.Net_RegOffLinePayRecord(nCamId, fGetOffLinePayRecordCB, IntPtr.Zero);

                if (fGetOffLineImageCBEx == null)
                    fGetOffLineImageCBEx = new QianYiSdk.FGetOffLineImageCBEx(FGetOffLineImageCBEx);
                QianYiSdk.Net_RegOffLineImageRecvEx(nCamId, fGetOffLineImageCBEx, IntPtr.Zero);

                if (fGetReportCBEx == null)
                    fGetReportCBEx = new QianYiSdk.FGetReportCBEx(FGetReportCBEx);
                QianYiSdk.Net_RegReportMessEx(nCamId, fGetReportCBEx, IntPtr.Zero);

                iRet = QianYiSdk.Net_QueryVideoDetectSetup(nCamId, ref tVideoDetectParamSetup);

                isSuccess = true;
                Logger.Write("QY连接相机成功!");
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
            return isSuccess;
        }

        private int FGetImageCB2(int tHandle, uint uiImageId, ref QianYiSdk.T_ImageUserInfo2 tImageInfo, ref QianYiSdk.T_PicInfo tPicInfo)
        {
            if (tHandle == nCamId)
            {
                if (tImageInfo.ucViolateCode == 0)
                {
                    
                }
            }
            if (tImageInfo.szLprResult != null)
            {
                string szLprResult = System.Text.Encoding.Default.GetString(tImageInfo.szLprResult).Replace("\0", "");
                PlateInfo plateInfo = new PlateInfo();
                plateInfo.IP = ip;
                plateInfo.Num = szLprResult;
                if (this.RecognizePlate != null)
                {
                    RecognizePlate(plateInfo);
                }
            }
            return 0;
        }

        /// <summary>
        /// 脱机收费数据回调
        /// </summary>
        /// <param name="tHandle"></param>
        /// <param name="ucType"></param>
        /// <param name="ptVehPayInfo"></param>
        /// <param name="uiLen"></param>
        /// <param name="ptPicInfo"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int FGetOffLinePayRecordCB(int tHandle, byte ucType, ref QianYiSdk.T_VehPayRsp ptVehPayInfo, uint uiLen, ref QianYiSdk.T_PicInfo ptPicInfo, IntPtr obj)
        {
            if (tHandle == nCamId)
            {
                 
            }
            return 0;
        }

        /// <summary>
        /// 脱机数据回调
        /// </summary>
        /// <param name="tHandle"></param>
        /// <param name="uiImageId"></param>
        /// <param name="tImageInfo"></param>
        /// <param name="tPicInfo"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int FGetOffLineImageCBEx(int tHandle, uint uiImageId, ref QianYiSdk.T_ImageUserInfo tImageInfo, ref QianYiSdk.T_PicInfo tPicInfo, IntPtr obj)
        {
            if (tHandle == nCamId)
            {
                 
            }

            return 0;
        }

        private int FGetReportCBEx(int tHandle, byte ucType, IntPtr ptMessage, IntPtr pUserData)
        {
            string strMsg = String.Format("{0}", ucType);
            if (14 == ucType) //语音对讲通知
            {
                
            }
            else if (ucType == 16)
            {
                
            }
            return 0;
        }

        public void Logoff()
        {
            if (nCamId != -1)
            {
                if(pbVideo!=null)
                   QianYiSdk.Net_StopVideo(nCamId);
                QianYiSdk.Net_DisConnCamera(nCamId);
                QianYiSdk.Net_DelCamera(nCamId);
                nCamId = -1;
            }
        }

        public void Relase()
        {
            QianYiSdk.Net_UNinit();
        }
    }
}
