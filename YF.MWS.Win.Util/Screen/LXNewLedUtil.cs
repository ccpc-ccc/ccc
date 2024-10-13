using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Text;
using YF.MWS.Metadata.Screen;
using YF.Utility.Log;

namespace YF.MWS.Win.Util.Screen
{
    public class LXNewLedUtil
    {
        /// <summary>
        /// 设置屏幕参数，只需要调用一次即可
        /// </summary>
        /// <param name="cfg"></param>
        public static void SetScreenParameter(LXCfg cfg)
        {
            int nResult;
            LXNewSDK.COMMUNICATIONINFO CommunicationInfo = new LXNewSDK.COMMUNICATIONINFO();//定义一通讯参数结构体变量用于对设定的LED通讯，具体对此结构体元素赋值说明见COMMUNICATIONINFO结构体定义部份注示
            //ZeroMemory(&CommunicationInfo,sizeof(COMMUNICATIONINFO));
            //TCP通讯********************************************************************************
            CommunicationInfo.SendType = 0;//设为固定IP通讯模式，即TCP通讯
            CommunicationInfo.IpStr = cfg.IPAddr;//给IpStr赋值LED控制卡的IP
            CommunicationInfo.LedNumber = 1;//LED屏号为1，注意socket通讯和232通讯不识别屏号，默认赋1就行了，485必需根据屏的实际屏号进行赋值
            //广播通讯********************************************************************************

            nResult = LXNewSDK.LV_SetBasicInfo(ref CommunicationInfo, cfg.ScreenColor, cfg.ScreenWidth, cfg.ScreenHeight);//设置屏参，屏的颜色为2即为双基色，64为屏宽点数，32为屏高点数，具体函数参数说明见函数声明注示
            if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
            {
                string ErrStr;
                ErrStr = LXNewSDK.LS_GetError(nResult);
                Logger.Write("set led parameter error:" + ErrStr);
            }
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        public static bool SendInfo(LXCfg cfg, string info,int fontSize)
        {
            bool isSuccessed = false;
            try
            {
                int nResult;
                LXNewSDK.COMMUNICATIONINFO CommunicationInfo = new LXNewSDK.COMMUNICATIONINFO();//定义一通讯参数结构体变量用于对设定的LED通讯，具体对此结构体元素赋值说明见COMMUNICATIONINFO结构体定义部份注示
                //ZeroMemory(&CommunicationInfo,sizeof(COMMUNICATIONINFO));
                //TCP通讯********************************************************************************
                CommunicationInfo.SendType = 0;//设为固定IP通讯模式，即TCP通讯
                CommunicationInfo.IpStr = cfg.IPAddr;//给IpStr赋值LED控制卡的IP
                CommunicationInfo.LedNumber = 1;//LED屏号为1，注意socket通讯和232通讯不识别屏号，默认赋1就行了，485必需根据屏的实际屏号进行赋值
                //广播通讯********************************************************************************
                //CommunicationInfo.SendType=1;//设为单机直连，即广播通讯无需设LED控制器的IP地址
                //串口通讯********************************************************************************
                //CommunicationInfo.SendType=2;//串口通讯
                //CommunicationInfo.Commport=1;//串口的编号，如设备管理器里显示为 COM3 则此处赋值 3
                //CommunicationInfo.Baud=9600;//波特率
                //CommunicationInfo.LedNumber=1;

                int hProgram;//节目句柄
                hProgram = LXNewSDK.LV_CreateProgram(cfg.ScreenWidth, cfg.ScreenHeight, cfg.ScreenColor);//根据传的参数创建节目句柄，64是屏宽点数，32是屏高点数，2是屏的颜色，注意此处屏宽高及颜色参数必需与设置屏参的屏宽高及颜色一致，否则发送时会提示错误
                //此处可自行判断有未创建成功，hProgram返回NULL失败，非NULL成功,一般不会失败

                nResult = LXNewSDK.LV_AddProgram(hProgram, 1, 0, 1);//添加一个节目，参数说明见函数声明注示
                if (nResult != 0)
                {
                    string ErrStr;
                    ErrStr = LXNewSDK.LS_GetError(nResult);
                    Logger.Write("add led info error:" + ErrStr);
                    return isSuccessed;
                }
                LXNewSDK.AREARECT AreaRect = new LXNewSDK.AREARECT();//区域坐标属性结构体变量
                AreaRect.left = 0;
                AreaRect.top = 0;
                AreaRect.width = cfg.ScreenWidth;
                AreaRect.height = cfg.ScreenHeight;

                LXNewSDK.LV_AddImageTextArea(hProgram, 1, 1, ref AreaRect, 0);

                LXNewSDK.FONTPROP FontProp = new LXNewSDK.FONTPROP();//文字属性
                FontProp.FontName = "宋体";
                FontProp.FontSize = fontSize;
                FontProp.FontColor = LXNewSDK.COLOR_RED;
                FontProp.FontBold = 0;

                LXNewSDK.PLAYPROP PlayProp = new LXNewSDK.PLAYPROP();
                PlayProp.InStyle = 0;
                PlayProp.DelayTime = cfg.Delay;
                PlayProp.Speed = cfg.PlaySpeed;
                //可以添加多个子项到图文区，如下添加可以选一个或多个添加
                nResult = LXNewSDK.LV_AddMultiLineTextToImageTextArea(hProgram, 1, 1, LXNewSDK.ADDTYPE_STRING, info, ref FontProp, ref PlayProp, 0, 0);//通过字符串添加一个多行文本到图文区，参数说明见声明注示


                nResult = LXNewSDK.LV_Send(ref CommunicationInfo, hProgram);//发送，见函数声明注示
                LXNewSDK.LV_DeleteProgram(hProgram);//删除节目内存对象，详见函数声明注示
                if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                {
                    string ErrStr;
                    ErrStr = LXNewSDK.LS_GetError(nResult);
                    Logger.Write("delete led info error:" + ErrStr);
                }
                isSuccessed = true;
            }
            catch (AccessViolationException acex) 
            {
                Logger.WriteException(acex);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
            return isSuccessed;
        }
    }
}
