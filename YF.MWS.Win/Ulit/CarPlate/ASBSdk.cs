using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YF.MWS.Win.Util.CarPlate
{
    public class DEVINFO
    {
        public string szip;// = new string(new char[32]);
        public string szdevname;// = new string(new char[128]);
        public uint unport;
        public string szuser;// = new string(new char[64]);
        public string szpwd;// = new string(new char[64]);
    }
    /// <summary>
    /// api接口
    /// </summary>
    public static class ASBSdk
    {

        // 定义回调函数格式， 必须严格遵守 
        //C++ TO C# CONVERTER TODO TASK: The original C++ function pointer contained an unconverted modifier:
        //ORIGINAL LINE: typedef int (WINAPI *IPCSDK_CALLBACK)(char *ip, char *buff, unsigned int len);
        unsafe public delegate int IPCSDK_CALLBACK(string ip, IntPtr buff, UInt32 len);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Init
        // *         初始化server端socket, 必须先调用， 否则其他API可能以为未初始化而失败
        // *
        // * @param[in]   port             监听的端口号， 相机默认向8190端口发送数据，
        //                                 如果相机不修改端口的话，这个值应该是8190
        //                                 否则按照相机发送端口来填值
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Init(ushort port);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", EntryPoint = "IPCSDK_Init", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Init(ushort port);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_UnInit
        // *         反初始化server端socket
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_UnInit();
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        //int IPCSDK_UnInit();

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Get_Version
        // *         获取IPCSDK版本号， 版本格式如下
        // * @param[out]  main_version  IPCSDK主版本号，使用者外部分配4字节空间，将指针作为输入
        // * @param[out]  sub_version   IPCSDK子版本号，使用者外部分配4字节空间，将指针作为输入
        // * @param[out]  third_version IPCSDK扩展版本号，使用者外部分配4字节空间，将指针作为输入
        // * @param[out]  fouth_version IPCSDK修正版本号，使用者外部分配4字节空间，将指针作为输入
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Get_Version(uint *main_version, uint *sub_version, uint *third_version, uint *fouth_version);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Get_Version(ref uint main_version, ref uint sub_version, ref uint third_version, ref uint fouth_version);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Find_Camera
        // *         搜索发现网络环境中的相机
        // * @param[out]  camera_num   相机个数
        // * @param[out]  ip_list      相机IP列表， 需要分配至少128*sizeof(CAMERA_IP)空间
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Find_Camera(uint *camera_num, CAMERA_IP_TAG *ip_list);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Find_Camera(ref uint camera_num, IntPtr p);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Login_Camera
        // *         登录相机
        // *
        // * @param[in]   ip      相机IP
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Login_Camera(sbyte *ip);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Login_Camera(ref string ip);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Logout_Camera
        // *         登出相机
        // *
        // * @param[in]   ip      相机IP
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Logout_Camera(sbyte *ip);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Logout_Camera(ref string ip);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Start_Stream
        // *         在指定窗体上显示视频流
        // *
        // * @param[in]   hMainHwnd   主窗口句柄
        // * @param[in]   hHwnd       视频显示控件的句柄
        // * @param[in]   ip          相机IP
        // * @param[in]   channel     主副码流选择, 0->主码流1920x1080; 1->子码流640x480
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Start_Stream(IntPtr hMainHwnd, IntPtr hHwnd, sbyte *ip, uint channel);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Start_Stream(IntPtr hMainHwnd, IntPtr hHwnd, string ip, UInt32 channel);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Stop_Stream
        // *         停止相机视频流
        // *
        // * @param[in]   ip      相机IP
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Stop_Stream(sbyte *ip);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:

        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Manual_Capture_Write_File(string ip, string filename);


        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Stop_Stream(string ip);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Draw_Rect_On_Stream
        // *         在视频上话矩形框
        // *
        // * @param[in]   ip          相机IP
        // * @param[in]   left        矩形框左坐标
        // * @param[in]   right       矩形框右坐标
        // * @param[in]   top         矩形框上坐标
        // * @param[in]   bottom      矩形框下坐标
        // * @param[in]   clean_flag  是否清除之前的矩形框, 0->不清除， 1->清除
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Draw_Rect_On_Stream(sbyte *ip, uint left, uint right, uint top, uint bottom, bool clean_flag);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Draw_Rect_On_Stream(string ip, uint left, uint right, uint top, uint bottom, bool clean_flag);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Get_Camera_Para
        // *         获取相机端参数
        //
        // * @param[in]   ip     相机IP， 例如"192.168.1.1"
        // * @param[out]  para   使用者分配空间，将指针作为输入参数，
        // *                     函数成功返回后该指针指向的内存为接收到的相机参数
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Get_Camera_Para(sbyte *ip, IntPtr para);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Get_Camera_Para(string ip, IntPtr para);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Set_Camera_Para
        // *         设置相机端参数
        //
        // * @param[in]  ip     相机IP， 例如"192.168.1.1"
        // * @param[in]  para   参数指针, 来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Set_Camera_Para(sbyte *ip, IntPtr para);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Set_Camera_Para(string ip, IntPtr para);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_ROI
        // *         设置车牌识别相机的感兴趣区域
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  index   ROI的索引， 最多支持ROI_NUM_MAX个ROI，0-3
        // * @param[in]  left    车牌识别区域左
        // * @param[in]  right   车牌识别区域右
        // * @param[in]  top     车牌识别区域上
        // * @param[in]  bottom  车牌识别区域下
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_ROI(IntPtr para, uint index, uint left, uint right, uint top, uint bottom);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_ROI(IntPtr para, uint index, uint left, uint right, uint top, uint bottom);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_ROI_Comments
        // *         设置车牌识别相机的感兴趣区域备注
        // *
        // * @param[in]  para       参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  index      ROI的索引， 最多支持ROI_NUM_MAX个ROI， 0-3
        // * @param[in]  comments   对应ROI的备注
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_ROI_Comments(IntPtr para, uint index, sbyte *comments);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_ROI_Comments(IntPtr para, uint index, string comments);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Plate_Width
        // *         设置车牌识别相机需要识别的车牌宽度范围， 有效范围PLATE_WIDTH_MIN到PLATE_WIDTH_MAX
        //           根据相机场景精确的设置车牌宽度范围可以有效节约算法时间，提高识别速度
        //
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  min     车牌识别的最小宽度， 画面中车牌宽度小于这个值不识别， 最小值PLATE_WIDTH_MIN
        // * @param[in]  max     车牌识别的最大宽度， 画面中车牌宽度大于这个值不识别， 最大值PLATE_WIDTH_MAX
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Plate_Width(IntPtr para, uint min, uint max);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Plate_Width(IntPtr para, uint min, uint max);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Default_Province
        // *         设置车牌识别相机安装的所在省份，用于车牌模糊时的默认车牌汉字
        //
        // * @param[in]  para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  province     省份字符串, 例如相机安装在江苏省，请填入汉字, "苏" ，其他省份参照列表
        // * 北京市 京
        // * 天津市 津
        // * 上海市 沪
        // * 重庆市 渝
        // * 河北省 冀
        // * 山西省 晋
        // * 辽宁省 辽
        // * 吉林省 吉
        // * 黑龙江省 黑
        // * 江苏省 苏
        // * 浙江省 浙
        // * 安徽省 皖
        // * 福建省 闽
        // * 江西省 赣
        // * 山东省 鲁
        // * 河南省 豫
        // * 湖北省 鄂
        // * 湖南省 湘
        // * 广东省 粤
        // * 海南省 琼
        // * 四川省 川
        // * 贵州省 贵
        // * 云南省 云
        // * 陕西省 陕
        // * 甘肃省 甘
        // * 青海省 青
        // * 西藏自治区 藏
        // * 广西壮族自治区 桂
        // * 内蒙古自治区 蒙
        // * 宁夏回族自治区 宁
        // * 新疆维吾尔自治区 新
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Default_Province(IntPtr para, sbyte *province);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Default_Province(IntPtr para, string province);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Rec_Times
        // *         设置车牌识别相机检测到每次触发后相机的识别次数
        //
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  times   每次触发尝试识别的次数，建议值10
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Rec_Times(IntPtr para, uint times);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Rec_Times(IntPtr para, uint times);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Road_Number
        // *         设置车牌识别相机场景中的车道数， 现在有且只支持1车道，将来可扩展支持多车道
        //
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  number    相机视角覆盖的车道数， 现在只支持1车道，将来可扩展支持多车道
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Road_Number(IntPtr para, uint number);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Road_Number(IntPtr para, uint number);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Output_Threshold
        // *         设置车牌识别相机车牌的输出门限，合理的输出门限值可以过滤置信度低的错误车牌，
        // *         同时保证有效车牌能够正常输出， 这个值建议为80
        // *
        // * @param[in]  para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  threshold    合理范围 60-90, 建议值80
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Output_Threshold(IntPtr para, uint threshold);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Output_Threshold(IntPtr para, uint threshold);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Trigger_Mode
        // *         设置车牌识别相机车牌的触发模式
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  mode    触发模式，参考TRIGGER_MODE枚举
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Trigger_Mode(IntPtr para, uint mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Trigger_Mode(IntPtr para, uint mode);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Rec_Mode
        // *         设置车牌识别相机车牌的识别模式
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  mode    识别模式， 参考RECOGNIZE_MODE枚举
        // *                     0->单帧模式, 识别速度快， 开闸速度快
        // *                     1->多帧选优模式， 识别速度稍慢， 可以过滤驶离车牌
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Rec_Mode(IntPtr para, uint mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Rec_Mode(IntPtr para, uint mode);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Upload_Mode
        // *         设置车牌识别相机车牌的上传模式
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  mode    上传模式，参考TRANSFER_MODE枚举
        // *                     0->JSON上传, 用于对接Android平台
        // *                     1->SDK上传， 推荐方式
        // *                     2->FTP上传， 直接上传到FTP服务器
        // *                     3->U盘存储， 识别图片存储在相机的外接U盘中
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Upload_Mode(IntPtr para, uint mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Upload_Mode(IntPtr para, uint mode);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Output_Resolution
        // *         设置车牌识别相机识别结果图片输出分辨率
        // *
        // * @param[in]  para        参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  resolution  输出分辨率，参考OUTPUT_RESOLUTION
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Output_Resolution(IntPtr para, uint resolution);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Output_Resolution(IntPtr para, uint resolution);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Output_Filter
        // *         设置车牌识别相机车牌的上传过滤，主要用于老旧小区出入均使用同一条车道的情况
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  mode    输出过滤，参考OUTPUT_MODE枚举
        // *                     0->过滤驶离车牌， 1->不过滤，全部输出
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Output_Filter(IntPtr para, uint mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Output_Filter(IntPtr para, uint mode);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Door_Mode
        // *         设置车牌识别相机车牌的闸机控制模式
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  mode    道闸控制模式, 参考DOOR_MODE枚举
        // *                     0->相机自动开闸， 只要识别到车牌就自动开闸
        // *                     1->相机为除了黑名单车牌以外的车牌自动开闸
        // *                     2->仅白名单开闸， 只有识别到的车牌在白名单内才自动开闸
        // *                     3->上位机开闸, 相机识别到任何车牌都不自动开闸，只有收到上位机的开闸指令才开闸，
        // *                        完全由上位机决定开闸与否
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Door_Mode(IntPtr para, uint mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Door_Mode(IntPtr para, uint mode);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Door_Delay
        // *         设置车牌识别相机车牌的闸机控制延时，开闸后多久控制闸机关闭，为了适应各种闸机对控制信号的时序要求
        // *         实际用使用中，为了防止砸车情况的发生，闸机往往配合防砸车地感线圈使用，所以闸机的关闭一般都由地感线圈
        // *         控制
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  ms      道闸控制延时，单位ms，最小值和最大值参考DOOR_DELAY_MIN和DOOR_DELAY_MMAX
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Door_Delay(IntPtr para, uint ms);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Door_Delay(IntPtr para, uint ms);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Door_Controle_Reverse
        // *         设置车牌识别相机的闸机控制电平反向，为了适应不同的继电器电路
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  mode    0->高电平开闸，低电平关闸
        // *                     1->低电平开闸，高电平关闸
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Door_Controle_Reverse(IntPtr para, uint mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Door_Controle_Reverse(IntPtr para, uint mode);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Enable_Individual_Plate
        // *         设置车牌识别相机是否支持个性化车牌
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  enable    0->不支持
        // *                       1->支持
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Enable_Individual_Plate(IntPtr para, uint enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Enable_Individual_Plate(IntPtr para, uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Enable_Tractor_Plate
        // *         设置车牌识别相机是否支持农用车牌
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  enable    0->不支持
        // *                       1->支持
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Enable_Tractor_Plate(IntPtr para, uint enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Enable_Tractor_Plate(IntPtr para, uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Enable_Embassy_Plate
        // *         设置车牌识别相机是否支持使馆车牌
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  enable    0->不支持
        // *                       1->支持
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Enable_Embassy_Plate(IntPtr para, uint enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Enable_Embassy_Plate(IntPtr para, uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Enable_DoubleRow_Plate
        // *         设置车牌识别相机是否支持双层车牌
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  enable    0->不支持
        // *                       1->支持
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Enable_DoubleRow_Plate(IntPtr para, uint enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Enable_DoubleRow_Plate(IntPtr para, uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Enable_OSD_Character
        // *         设置车牌识别相机输出的识别图片中是否支持OSD叠加车牌字符信息
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  enable    0->不支持
        // *                       1->支持
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Enable_OSD_Character(IntPtr para, uint enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Enable_OSD_Character(IntPtr para, uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Enable_OSD_Rect
        // *         设置车牌识别相机是否支持OSD叠加车牌框，感兴趣区域等，一般调试安装时使用，实际使用时关闭
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  enable    0->不支持
        // *                       1->支持
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Enable_OSD_Rect(IntPtr para, uint enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Enable_OSD_Rect(IntPtr para, uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Enable_Output_Once_Only
        // *         设置车牌识别相机是否同一车牌只输出一次， 建议调试安装时关闭，正常使用时使能
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  enable    0->不使能
        // *                       1->使能
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Enable_Output_Once_Only(IntPtr para, uint enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Enable_Output_Once_Only(IntPtr para, uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Output_Once_Only_Interval
        // *         设置车牌识别相机同一车牌只输出一次的时间间隔， 防止同一辆车快速反复进出
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  time      相同车牌只输出一次的时间间隔，单位秒， 建议值10-30秒， 有效值为10-60
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Output_Once_Only_Interval(IntPtr para, uint time);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Output_Once_Only_Interval(IntPtr para, uint time);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Light_Controle_Reverse
        // *         设置车牌识别相机的补光灯控制电平反向，为了适应不同的继电器电路
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  mode    0->高电平开灯，低电平关灯
        // *                     1->低电平开灯，高电平关灯
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Light_Controle_Reverse(IntPtr para, uint mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Light_Controle_Reverse(IntPtr para, uint mode);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Enable_Whitelist
        // *         设置车牌识别相机是否使能白名单，必须先使用IPCSDK_Import_WhiteList导入白名单后再使能，
        // *         否则会出现不可预期的问题
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  enable    0->不使能
        // *                       1->使能
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Enable_Whitelist(IntPtr para, uint enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Enable_Whitelist(IntPtr para, uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Enable_Blacklist
        // *         设置车牌识别相机是否使能黑名单，必须先使用IPCSDK_Import_BlackList导入黑名单后再使能
        // *         此功能相机最多只能做到黑名单不开闸的效果，真正的其他功能必须在上位机接收到车牌后，通过
        // *         IPCSDK_Get_Plate_Type得到车牌类型为PLATE_TYPE_BLACKLIST时在界面上弹出对话框或者直接上传公安网
        // *         才能发挥黑名单的更大作用，例如物业费未交住户入场，盗抢车牌，套牌车牌报警等
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  enable    0->不使能
        // *                       1->使能
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Enable_Blacklist(IntPtr para, uint enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Enable_Blacklist(IntPtr para, uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_Upload_Server_Info
        // *         设置车牌识别相机上传服务器信息
        // *
        // * @param[in]  para          参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  server_ip     服务器IP     例如"192.168.1.100"
        // * @param[in]  server_port   服务器端口   例如"8190"
        // * @param[in]  server_user   服务器用户名 只有上传模式为FTP模式是才需要 例如"ftpuser"， 最长32个字符
        // * @param[in]  server_passwd 服务器密码   只有上传模式为FTP模式是才需要 例如"ftppasswd" 最长32个字符
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_Upload_Server_Info(IntPtr para, sbyte *server_ip, uint server_port, sbyte *server_user, sbyte *server_passwd);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Upload_Server_Info(IntPtr para, string server_ip, uint server_port, string server_user, string server_passwd);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_RS485
        // *         设置车牌识别相机的RS485参数
        // *
        // * @param[in]  para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  baudrate     RS485波特率     例如9600
        // * @param[in]  databit      RS485数据位     例如8
        // * @param[in]  stopbit      RS485停止位     例如1
        // * @param[in]  checkbit     RS485校验位     例如0->无校验位 1->奇校验 2->偶校验
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_RS485(IntPtr para, uint baudrate, uint databit, uint stopbit, uint checkbit);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_RS485(IntPtr para, uint baudrate, uint databit, uint stopbit, uint checkbit);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_RS485_Mode
        // *         设置车牌识别相机RS485工作模式
        // *
        // * @param[in]  para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  mode         RS485工作模式   0->透明传输 : 1->输出车牌 : 2->LED显示屏控制
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_RS485_Mode(IntPtr para, uint mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_RS485_Mode(IntPtr para, uint mode);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_LED_Type
        // *         设置车牌识别相机LED显示屏型号
        // *
        // * @param[in]  para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  type         RS485显示屏型号， 暂只支持铭星电子的4字屏，该屏一屏最多可支持4个汉字
        // *                          或者8个字符显示，需要支持其他型号LED屏可付费集成。
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_LED_Type(IntPtr para, uint type);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_LED_Type(IntPtr para, uint type);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_LED_Content1
        // *         设置车牌识别相机LED显示屏白名单车牌号前面需要显示的内容，例如车牌号"苏A12345"属于白名单车牌，
        // *         客户需要在识别到白名单车牌时，在其前面显示"VIP客户"4个字， 那么这个API可以实现"VIP客户“字符的设置
        // *         LED显示内容如下"VIP客户苏A12345"
        // *
        // * @param[in]  para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  content      可输入汉字和字符，汉字必须是GB2312编码格式的, 最长支持64个字符/32个汉字
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_LED_Content1(IntPtr para, sbyte *content);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_LED_Content1(IntPtr para, string content);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_LED_Content2
        // *         设置车牌识别相机LED显示屏白名单车牌号后面需要显示的内容，例如车牌号"苏A12345"属于白名单车牌，
        // *         客户需要在识别到白名单车牌时，在其后面显示"欢迎光临"4个字， 那么这个API可以实现"欢迎光临“字符的设置
        // *         LED显示内容如下"VIP客户苏A12345欢迎光临"
        // *
        // * @param[in]  para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  content      可输入汉字和字符，汉字必须是GB2312编码格式的, 最长支持64个字符/32个汉字
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_LED_Content2(IntPtr para, sbyte *content);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_LED_Content2(IntPtr para, string content);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_LED_Content3
        // *         设置车牌识别相机LED显示屏普通车牌号前面需要显示的内容，例如车牌号"苏A12345"属于普通车牌，
        // *         客户需要在识别到普通车牌时，在其前面显示"临时车牌"4个字， 那么这个API可以实现"临时车牌“字符的设置
        // *         LED显示内容如下"临时车牌苏A12345"
        // *
        // * @param[in]  para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  content      可输入汉字和字符，汉字必须是GB2312编码格式的, 最长支持64个字符/32个汉字
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_LED_Content3(IntPtr para, sbyte *content);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_LED_Content3(IntPtr para, string content);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Set_LED_Content4
        // *         设置车牌识别相机LED显示屏普通名单车牌号前面需要显示的内容，例如车牌号"苏A12345"属于普通车牌，
        // *         客户需要在识别到普通车牌时，在其后面显示"一路平安"4个字， 那么这个API可以实现"一路平安“字符的设置
        // *         LED显示内容如下"临时车牌苏A12345一路平安"
        // *
        // * @param[in]  para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  content      可输入汉字和字符，汉字必须是GB2312编码格式的, 最长支持64个字符/32个汉字
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Set_LED_Content4(IntPtr para, sbyte *content);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_LED_Content4(IntPtr para, string content);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Send_RS485_Data
        // *         发送RS485数据, 相机不做任何转换，透明传输到RS485接口
        //
        // * @param[in]  ip     相机IP， 例如"192.168.1.1"
        // * @param[in]  buf    需要传输的数据buffer指针
        // * @param[in]  nlen   需要传输的数据长度， 最大长度支持256字节
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Send_RS485_Data(sbyte *ip, byte *buf, int nlen);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Send_RS485_Data(string ip, [MarshalAs(UnmanagedType.LPArray)] byte[] buf, int nlen);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Import_WhiteList
        // *         导入白名单
        //
        // * @param[in]  ip     相机IP， 例如"192.168.1.1"
        // * @param[in]  buf    需要导入的白名单数据buffer指针， 可以是whitelist.txt的内容，
        // *                    whitelist.txt的格式须满足如下格式， 车牌号， 起始日期， 结束日期， 中间用空格隔开
        // *                    苏A12345 2015/11/05 2016/11/04
        // *                    京A69286 2015/11/05 2016/11/04
        // * @param[in]  nlen   需要导入的白名单的数据长度， 最大支持1MB， 20000条数据
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Import_WhiteList(sbyte *ip, byte *buf, int nlen);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Import_WhiteList(string ip, [MarshalAs(UnmanagedType.LPArray)] byte[] buf, int nlen);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Import_BlackList
        // *         导入黑
        //
        // * @param[in]  ip     相机IP， 例如"192.168.1.1"
        // * @param[in]  buf    需要导入的黑名单数据buffer指针， 可以是blacklist.txt的内容，
        // *                    whitelist.txt的格式须满足如下格式， 车牌号， 起始日期， 结束日期， 中间用空格隔开
        // *                    苏A12345 2015/11/05 2016/11/04
        // *                    京A69286 2015/11/05 2016/11/04
        // * @param[in]  nlen   需要导入的黑名单的数据长度， 最大支持1MB， 1000条数据
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Import_BlackList(sbyte *ip, byte *buf, int nlen);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Import_BlackList(string ip, [MarshalAs(UnmanagedType.LPArray)] byte[] buf, int nlen);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Manual_Trigger_Rec
        // *         通过网络手动触发识别， 相机会尝试识别IPCSDK_Alg_Set_Rec_Times设定的次数，如果识别到车牌
        // *         输出识别到的车牌，如果未识别到车牌，输出置信度为100的车牌号为“ABCDEFG”的车牌，以便上位机
        // *         手动录入车牌
        // *
        // * @param[in]  ip     相机IP， 例如"192.168.1.1"
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Manual_Trigger_Rec(sbyte *ip);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Manual_Trigger_Rec(ref string ip);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Manual_Open_Door
        // *         通过网络手动开闸，注意这个接口不会自动关闸， 需要IPCSDK_Manual_Close_Door才能关闸，
        // *         或者相机开启了自动开闸选项，下次识别到车牌后会自动关闸
        // *
        // * @param[in]  ip     相机IP， 例如"192.168.1.1"
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Manual_Open_Door(sbyte *ip);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Manual_Open_Door(string ip);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Manual_Close_Door
        // *         通过网络手动触发关闸， 如果相机开启了自动开闸选项，下次识别到车牌后会仍然会自动关闸
        //
        // * @param[in]  ip     相机IP， 例如"192.168.1.1"
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Manual_Close_Door(sbyte *ip);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Manual_Close_Door(string ip);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Manual_Open_Auto_Close_Door
        // *         通过网络手动开闸，使用这个接口相机会延迟delay_ms后自动关闸
        // *
        // * @param[in]  ip        相机IP， 例如"192.168.1.1"
        // * @param[in]  delay_ms  开闸后延迟关闸的毫秒数，合法值是10-10000
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Manual_Open_Auto_Close_Door(sbyte *ip, uint delay_ms);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Manual_Open_Auto_Close_Door(ref string ip, uint delay_ms);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Manual_Turn_On_Light
        // *         通过网络手动开灯，注意这个接口不会自动关灯， 需要IPCSDK_Manual_Turn_Off_Light才能关闸
        // *
        // * @param[in]  ip     相机IP， 例如"192.168.1.1"
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Manual_Turn_On_Light(sbyte *ip);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Manual_Turn_On_Light(string ip);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Manual_Turn_Off_Light
        // *         通过网络手动关灯
        //
        // * @param[in]  ip     相机IP， 例如"192.168.1.1"
        // *
        // * @return 0->成功 : 其他值->失败
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Manual_Turn_Off_Light(sbyte *ip);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Manual_Turn_Off_Light(string ip);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_ROI
        // *         获取车牌识别相机的感兴趣区域
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  index   ROI的索引， 最多支持ROI_NUM_MAX个ROI， 0-3
        // * @param[out] left    车牌识别区域左
        // * @param[out] right   车牌识别区域右
        // * @param[out] top     车牌识别区域上
        // * @param[out] bottom  车牌识别区域下
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_ROI(IntPtr para, uint index, uint *left, uint *right, uint *top, uint *bottom);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_ROI(IntPtr para, uint index, ref uint left, ref uint right, ref uint top, ref uint bottom);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_ROI_Comments
        // *         获取车牌识别相机的感兴趣区域备注
        // *
        // * @param[in]  para       参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  index      ROI的索引， 最多支持ROI_NUM_MAX个ROI， 0-3
        // * @param[out] comments   对应ROI的备注, 外部至少分配32字节空间
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_ROI_Comments(IntPtr para, uint index, sbyte *comments);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_ROI_Comments(IntPtr para, UInt32 index, StringBuilder comments);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Plate_Width
        // *         获取车牌识别相机需要识别的车牌宽度范围， 有效范围PLATE_WIDTH_MIN到PLATE_WIDTH_MAX
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] min     车牌识别的最小宽度， 使用者分配unsigned int空间，将指针作为输入参数
        // * @param[out] max     车牌识别的最大宽度， 使用者分配unsigned int空间，将指针作为输入参数
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Plate_Width(IntPtr para, uint *min, uint *max);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Plate_Width(IntPtr para, ref uint min, ref uint max);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Default_Province
        // *         获取车牌识别相机安装的默认省份
        //
        // * @param[in]  para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] province     省份字符串, 使用者分配t空间，将指针作为输入参数
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Default_Province(IntPtr para, sbyte *province);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Default_Province(IntPtr para, StringBuilder province);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Rec_Times
        // *         获取车牌识别相机每次触发识别次数
        //
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] times   返回每次触发识别次数， 使用者分配t空间，将指针作为输入参数
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Rec_Times(IntPtr para, uint *times);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Rec_Times(IntPtr para, ref uint times);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Road_Number
        // *         获取车牌识别相机场景中的车道数
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] number    相机视角覆盖的车道数，使用者分配t空间，将指针作为输入参数
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Road_Number(IntPtr para, uint *number);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Road_Number(IntPtr para, ref uint number);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Output_Threshold
        // *         获取车牌识别相机车牌的输出门限
        // *
        // * @param[in]  para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] threshold    输出门限值门指针，使用者分配t空间，将指针作为输入参数
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Output_Threshold(IntPtr para, uint *threshold);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Output_Threshold(IntPtr para, ref uint threshold);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Trigger_Mode
        // *         获取车牌识别相机车牌的触发模式
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] mode    触发模式，使用者分配t空间，将指针作为输入参数，参考TRIGGER_MODE枚举
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Trigger_Mode(IntPtr para, uint *mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Trigger_Mode(IntPtr para, ref uint mode);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Rec_Mode
        // *         获取车牌识别相机车牌的识别模式
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] mode    识别模式，使用者分配t空间，将指针作为输入参数，参考RECOGNIZE_MODE枚举
        // *                     0->单帧模式, 识别速度快， 开闸速度快
        // *                     1->多帧选优模式， 识别速度稍慢， 可以过滤驶离车牌
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Rec_Mode(IntPtr para, uint *mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Rec_Mode(IntPtr para, ref uint mode);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Upload_Mode
        // *         获取车牌识别相机车牌的上传模式
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] mode    上传模式，使用者分配t空间，将指针作为输入参数，参考TRANSFER_MODE枚举
        // *                     0->JSON上传, 用于对接Android平台
        // *                     1->SDK上传， 推荐方式
        // *                     2->FTP上传， 直接上传到FTP服务器
        // *                     3->U盘存储， 识别图片存储在相机的外接U盘中
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Upload_Mode(IntPtr para, uint *mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Upload_Mode(IntPtr para, ref uint mode);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Output_Resolution
        // *         获取车牌识别相机图片输出分辨率
        // *
        // * @param[in]   para        参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out]  resolution  返回输出分辨率，使用者分配t空间，将指针作为输入参数，参考OUTPUT_RESOLUTION
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Output_Resolution(IntPtr para, uint *resolution);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Output_Resolution(IntPtr para, ref uint resolution);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Output_Filter
        // *         获取车牌识别相机车牌的上传过滤，主要用于老旧小区出入公用一条车道的情况
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] mode    输出过滤选项，使用者分配t空间，将指针作为输入参数，参考OUTPUT_MODE枚举
        // *                     0->过滤驶离车牌， 1->不过滤，全部输出
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Output_Filter(IntPtr para, uint *mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Output_Filter(IntPtr para, ref uint mode);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Door_Mode
        // *         获取车牌识别相机车牌的闸机控制模式
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] mode    道闸控制模式, 使用者分配t空间，将指针作为输入参数，参考DOOR_MODE枚举
        // *                     0->相机自动开闸， 只要识别到车牌就自动开闸
        // *                     1->相机为除了黑名单车牌以外的车牌自动开闸
        // *                     2->仅白名单开闸， 只有识别到的车牌在白名单内才自动开闸
        // *                     3->上位机开闸, 相机识别到任何车牌都不自动开闸，只有收到上位机的开闸指令才开闸，
        // *                        完全由上位机决定开闸与否
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Door_Mode(IntPtr para, uint *mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Door_Mode(IntPtr para, ref uint mode);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Door_Delay
        // *         获取车牌识别相机车牌的闸机控制延时
        // *
        // * @param[in]   para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out]  ms      返回道闸控制延时，单位ms，最小值和最大值参考DOOR_DELAY_MIN和DOOR_DELAY_MMAX
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Door_Delay(IntPtr para, uint *ms);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Door_Delay(IntPtr para, ref uint ms);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Door_Controle_Reverse
        // *         获取车牌识别相机的闸机控制电平反向
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] mode    道闸反向控制状态，使用者分配t空间，将指针作为输入参数
        // *                     0->高电平开闸，低电平关闸
        // *                     1->低电平开闸，高电平关闸
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Door_Controle_Reverse(IntPtr para, uint *mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Door_Controle_Reverse(IntPtr para, ref uint mode);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Enable_Individual_Plate
        // *         获取车牌识别相机是否支持个性化车牌
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] enable    0->不支
        // *                       1->支持
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Enable_Individual_Plate(IntPtr para, uint *enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Enable_Individual_Plate(IntPtr para, ref uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Enable_Tractor_Plate
        // *         获取车牌识别相机是否支持农用车牌
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] enable    0->不支持
        // *                       1->支持
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Enable_Tractor_Plate(IntPtr para, uint *enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Enable_Tractor_Plate(IntPtr para, ref uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Enable_Embassy_Plate
        // *         获取车牌识别相机是否支持使馆车牌
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] enable    0->不支持
        // *                       1->支持
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Enable_Embassy_Plate(IntPtr para, uint *enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Enable_Embassy_Plate(IntPtr para, ref uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Enable_DoubleRow_Plate
        // *         获取车牌识别相机是否支持双层车牌
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] enable    0->不支持
        // *                       1->支持
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Enable_DoubleRow_Plate(IntPtr para, uint *enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Enable_DoubleRow_Plate(IntPtr para, ref uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Enable_OSD_Character
        // *         获取车牌识别相机是否支持OSD叠加车牌字符信息
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] enable    0->不支持
        // *                       1->支持
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Enable_OSD_Character(IntPtr para, uint *enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Enable_OSD_Character(IntPtr para, ref uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Enable_OSD_Rect
        // *         获取车牌识别相机是否支持OSD叠加车牌框，感兴趣区域等，一般调试时使用，实际使用时关闭
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] enable    0->不支持
        // *                       1->支持
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Enable_OSD_Rect(IntPtr para, uint *enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Enable_OSD_Rect(IntPtr para, ref uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Enable_Output_Once_Only
        // *         获取车牌识别相机是否使能了同一车牌只输出一次
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] enable    0->不使能
        // *                       1->使能
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Enable_Output_Once_Only(IntPtr para, uint *enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Enable_Output_Once_Only(IntPtr para, ref uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Output_Once_Only_Interval
        // *         获取车牌识别相机同一车牌只输出一次的时间间隔
        // *
        // * @param[in]   para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out]  time      相同车牌只输出一次的时间间隔，单位秒， 返回值为当前相机设置的时间间隔
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Output_Once_Only_Interval(IntPtr para, uint *time);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Output_Once_Only_Interval(IntPtr para, ref uint time);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Light_Controle_Reverse
        // *         获取车牌识别相机的补光灯控制电平反向
        // *
        // * @param[in]  para    参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] mode    道闸反向控制状态，使用者分配t空间，将指针作为输入参数
        // *                     0->高电平开灯，低电平关灯
        // *                     1->低电平开灯，高电平关灯
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Light_Controle_Reverse(IntPtr para, uint *mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Light_Controle_Reverse(IntPtr para, ref uint mode);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Enable_Whitelist
        // *         获取车牌识别相机是否使能了白名单
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] enable    0->不使能
        // *                       1->使能
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Enable_Whitelist(IntPtr para, uint *enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Enable_Whitelist(IntPtr para, ref uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Enable_Blacklist
        // *         获取车牌识别相机是否使能了黑名单
        // *
        // * @param[in]  para      参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out] enable    0->不使能
        // *                       1->使能
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Enable_Blacklist(IntPtr para, uint *enable);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Enable_Blacklist(IntPtr para, ref uint enable);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_Upload_Server_Info
        // *         获取车牌识别相机上传服务器信息
        // *
        // * @param[in]  para          参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[in]  server_ip     服务器IP     例如"192.168.1.100"
        // * @param[in]  server_port   服务器端口   例如"8190"
        // * @param[in]  server_user   服务器用户名 只有上传模式为FTP模式是才需要 例如"ftpuser"
        // * @param[in]  server_passwd 服务器密码   只有上传模式为FTP模式是才需要 例如"ftppasswd"
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_Upload_Server_Info(IntPtr para, sbyte *server_ip, uint *server_port, sbyte *server_user, sbyte *server_passwd);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Upload_Server_Info(IntPtr para, StringBuilder server_ip, ref uint server_port, StringBuilder server_user, StringBuilder server_passwd);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_RS485
        // *         获取车牌识别相机RS485设置
        // *
        // * @param[in]   para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out]  baudrate     RS485波特率     例如9600
        // * @param[out]  databit      RS485数据位     例如8
        // * @param[out]  stopbit      RS485停止位     例如1
        // * @param[out]  checkbit     RS485校验位     例如0->无校验位 1->奇校验 2->偶校验
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_RS485(IntPtr para, uint *baudrate, uint *databit, uint *stopbit, uint *checkbit);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_RS485(IntPtr para, ref uint baudrate, ref uint databit, ref uint stopbit, ref uint checkbit);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_RS485_Mode
        // *         获取车牌识别相机RS485工作模式
        // *
        // * @param[in]   para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out]  mode         RS485工作模式   0->透明传输 : 1->输出车牌 : 2->LED显示屏输出
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_RS485_Mode(IntPtr para, uint *mode);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_RS485_Mode(IntPtr para, ref uint mode);


        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_Expourse_Range(IntPtr para, ref uint min, ref uint max);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_LED_Type
        // *         获取车牌识别相机LED显示屏型号
        // *
        // * @param[in]   para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out]  type         RS485显示屏型号， 暂只支持铭星电子的4字屏，该屏一屏最多可支持4个汉字或者8个字符显示
        // *                           需要支持其他LED屏可付费集成。
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_LED_Type(IntPtr para, uint *type);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_LED_Type(IntPtr para, ref uint type);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_LED_Content1
        // *         获取车牌识别相机LED显示屏白名单车牌号前面需要显示的内容，例如车牌号"苏A12345"属于白名单车牌，
        // *         如果客户设置了在其前面显示"VIP客户"4个字， 那么这个API可以获取"VIP客户“字符的设置
        // *
        // * @param[in]   para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out]  content      需要外部分配至少64字节空间， 输出为汉字或字符，
        // *                           汉字是GB2312编码格式的, 最长为64个字符/32个汉字
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_LED_Content1(IntPtr para, sbyte *content);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_LED_Content1(IntPtr para, StringBuilder content);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_LED_Content2
        // *         设置车牌识别相机LED显示屏白名单车牌号前面需要显示的内容，例如车牌号"苏A12345"属于白名单车牌，
        // *         如果客户设置了在其后面显示"一路平安"4个字， 那么这个API可以获取"一路平安“字符的设置
        // *
        // * @param[in]   para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out]  content      需要外部分配至少64字节空间， 输出为汉字或字符，
        // *                           汉字是GB2312编码格式的, 最长为64个字符/32个汉字
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_LED_Content2(IntPtr para, sbyte *content);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_LED_Content2(IntPtr para, StringBuilder content);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_LED_Content3
        // *         获取车牌识别相机LED显示屏普通车牌号前面需要显示的内容，例如车牌号"苏A12345"属于普通车牌，
        // *         如果客户设置了在其前面显示"临时车牌"4个字， 那么这个API可以获取"临时车牌“字符的设置
        // *
        // * @param[in]   para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out]  content      需要外部分配至少64字节空间， 输出为汉字或字符，
        // *                           汉字是GB2312编码格式的, 最长为64个字符/32个汉字
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_LED_Content3(IntPtr para, sbyte *content);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_LED_Content3(IntPtr para, StringBuilder content);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Alg_Get_LED_Content4
        // *         获取车牌识别相机LED显示屏普通名单车牌号前面需要显示的内容，例如车牌号"苏A12345"属于普通车牌，
        // *         如果客户设置了在其后面显示"包年更优惠"5个字， 那么这个API可以获取"包年更优惠“字符的设置
        // *
        // * @param[in]   para         参数buffer指针，来源于IPCSDK_Get_Camera_Para的第二个输入参数para
        // * @param[out]  content      需要外部分配至少64字节空间， 输出为汉字或字符，
        // *                           汉字是GB2312编码格式的, 最长为64个字符/32个汉字
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Alg_Get_LED_Content4(IntPtr para, sbyte *content);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Get_LED_Content4(IntPtr para, StringBuilder content);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Register_Callback
        // *         注册用户的处理回调函数
        // *
        // * @param[in]  callback   用户的回调函数，
        // *                        形式必须为int callback_func(char ip[16], unsigned char *buf, unsigned int len)
        // *                        且正常处理返回值应该为0, 否则会弹出错误提示框并提醒用户回调函数返回值
        // *                        ip  发送相机IP地址
        // *                        buf 相机发送来的数据指针
        // *                        len 相机发送来的数据长度
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Register_Callback(IPCSDK_CALLBACK callback);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Register_Callback(IPCSDK_CALLBACK callback);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Get_Plate_Jpeg
        // *         从接收到的数据中提取车牌特写jpeg数据
        // *
        // * @param[in]  data_buf       对应于callback_func的第二个输入参数， buf
        // * @param[out] plate_jpeg_buf 存放车牌特写jpeg的buf指针，外部分配空间，不能为NULL
        // * @param[out] plate_jpeg_len 存放车牌特写jpeg长度的变量指针， 外部分配空间，不能为NULL
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Get_Plate_Jpeg(byte *data_buf, byte *plate_buf, uint *plate_len);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        //public static extern int IPCSDK_Get_Plate_Jpeg(IntPtr data_buf, [MarshalAs(UnmanagedType.LPArray)]  IntPtr plate_buf, ref uint plate_len);
        public static extern int IPCSDK_Get_Plate_Jpeg(IntPtr data_buf, IntPtr plate_buf, ref uint plate_len);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Get_Plate_Info
        // *         从接收到的数据中提取车牌信息， 包括车牌坐标，颜色， 置信度等信息
        // *
        // * @param[in]   data_buf     对应于callback_func的第二个输入参数， buf
        // * @param[out]  plate_result 车牌信息输出指针，不能为空指针，需要预分配空间， 至少64KB
        // * @param[out]  result_len   返回的车牌信息总长度
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Get_Plate_Info(unsigned char *data_buf, void *plate_result, unsigned int *result_len);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Get_Plate_Info(IntPtr data_buf, IntPtr plate_result, ref uint result_len);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Get_Plate_License
        // *         从接收到的数据中提取车牌号， 此函数用于从接收到的数据中获取车牌号
        // *
        // * @param[in]   data_buf     对应于IPCSDK_Get_Plate_Info的第二个输入参数， plate_result
        // * @param[out]  license      车牌号，不能为空指针，需要预分配至少16字节空间， 输出为字符串格式
        //                             例如：“苏A12345”
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Get_Plate_License(IntPtr plate_result, sbyte *license);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Get_Plate_License(IntPtr plate_result, StringBuilder license);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Get_Plate_Color
        // *         从接收到的数据中提取车牌颜色
        // *
        // * @param[in]   data_buf     对应于IPCSDK_Get_Plate_Info的第二个输入参数， plate_result
        // * @param[out]  color        车牌颜色，不能为空指针，需要预分配至少8字节空间， 输出为字符串格式
        //                             例如：“蓝”
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Get_Plate_Color(IntPtr plate_result, sbyte *color);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Get_Plate_Color(IntPtr plate_result, StringBuilder color);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Get_Plate_Confidence
        // *         从接收到的数据中提取车牌置信度
        // *
        // * @param[in]   data_buf     对应于IPCSDK_Get_Plate_Info的第二个输入参数， plate_result
        // * @param[out]  confidence   车牌置信度，不能为空指针，需要预分配至少4字节空间， 输出为无符号整形
        //                             例如：85
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Get_Plate_Confidence(IntPtr plate_result, uint *confidence);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Get_Plate_Confidence(IntPtr plate_result, ref uint confidence);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Get_Plate_Location
        // *         从接收到的数据中提取车牌位置
        // *
        // * @param[in]   data_buf   对应于IPCSDK_Get_Plate_Info的第二个输入参数， plate_result
        // * @param[out]  x_offset   车牌在图片中的水平偏移值
        // * @param[out]  y_offset   车牌在图片中的垂直偏移值
        // * @param[out]  width      车牌在图片中的宽度
        // * @param[out]  height     车牌在图片中的高度
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Get_Plate_Location(IntPtr plate_result, uint *x_offset, uint *y_offset, uint *width, uint *height);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Get_Plate_Location(IntPtr plate_result, ref uint x_offset, ref uint y_offset, ref uint width, ref uint height);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Get_Plate_Time
        // *         从接收到的数据中提取车牌识别耗时
        // *
        // * @param[in]   data_buf   对应于IPCSDK_Get_Plate_Info的第二个输入参数， plate_result
        // * @param[out]  time       车牌识别耗时，单位ms
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Get_Plate_Time(IntPtr plate_result, uint *time);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Get_Plate_Time(IntPtr plate_result, ref uint time);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Get_Plate_Type
        // *         从接收到的数据中获取车牌是否为黑白名单中的车牌
        // *
        // * @param[in]   data_buf   对应于IPCSDK_Get_Plate_Info的第二个输入参数， plate_result
        // * @param[in]   index      车牌的索引, 停车场出入口支持1个车牌， 所以这里暂时只支持输入0
        // * @param[out]  type       车牌类型，参见enum PLATE_TYPE
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Get_Plate_Type(IntPtr plate_result, uint index, uint *type);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Get_Plate_Type(IntPtr plate_result, uint index, ref uint type);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Get_Plate_Start_Date
        // *         从接收到的数据中获取车牌起始日期， 这个函数必须是在IPCSDK_Get_Plate_Type获取到type
        // *         不为PLATE_TYPE_NORMAL的情况下才有意义，因为普通车牌是没有起始日期的
        // *
        // * @param[in]   data_buf   对应于IPCSDK_Get_Plate_Info的第二个输入参数， plate_result
        // * @param[in]   index      车牌的索引, 停车场出入口支持1个车牌， 所以这里暂时只支持输入0
        // * @param[out]  year       开始日期的年， 需要调用者分配unsigned int 空间
        // * @param[out]  month      开始日期的月， 需要调用者分配unsigned int 空间
        // * @param[out]  day        开始日期的日， 需要调用者分配unsigned int 空间
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Get_Plate_Start_Date(IntPtr plate_result, uint index, uint *year, uint *month, uint *day);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Get_Plate_Start_Date(IntPtr plate_result, uint index, ref uint year, ref uint month, ref uint day);

        // --------------------------------------------------------------------------
        //*
        // * @brief  IPCSDK_Get_Plate_End_Date
        // *         从接收到的数据中获取车牌结束日期， 这个函数必须是在IPCSDK_Get_Plate_Type获取到type
        // *         不为PLATE_TYPE_NORMAL的情况下才有意义，因为普通车牌是没有结束日期的
        // *
        // * @param[in]   data_buf   对应于IPCSDK_Get_Plate_Info的第二个输入参数， plate_result
        // * @param[in]   index      车牌的索引, 停车场出入口支持1个车牌， 所以这里暂时只支持输入0
        // * @param[out]  year       结束日期的年， 需要调用者分配unsigned int 空间
        // * @param[out]  month      结束日期的月， 需要调用者分配unsigned int 空间
        // * @param[out]  day        结束日期的日， 需要调用者分配unsigned int 空间
        // *
        // * @return 0->成功 : -1->输入参数不合法
        // 
        // --------------------------------------------------------------------------
        //C++ TO C# CONVERTER NOTE: WINAPI is not available in C#:
        //ORIGINAL LINE: int WINAPI IPCSDK_Get_Plate_End_Date(IntPtr plate_result, uint index, uint *year, uint *month, uint *day);
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Get_Plate_End_Date(IntPtr plate_result, uint index, ref uint year, ref uint month, ref uint day);


        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Set_Debug_Mode(string ip, string server_ip, uint server_port, uint on_off);


        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Manual_Format_Udisk(string ip);

        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Export_WhiteList(string ip, [MarshalAs(UnmanagedType.LPArray)] byte[] buf, ref uint nlen);

        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Export_BlackList(string ip, [MarshalAs(UnmanagedType.LPArray)] byte[] buf, ref uint nlen);

        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Add_WhiteList(string ip, string license, uint begin_year, uint begin_month, uint begin_day,
                                uint end_year, uint end_month, uint end_day);

        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Add_BlackList(string ip, string license, uint begin_year, uint begin_month, uint begin_day,
                                uint end_year, uint end_month, uint end_day);

        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Delete_WhiteList(string ip, string license);

        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Delete_BlackList(string ip, string license);

        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Delete_WhiteList_All(string ip);

        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Delete_BlackList_All(string ip);

        [DllImport("IPCSDK.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int IPCSDK_Alg_Set_Expourse_Range(IntPtr para, uint min, uint max);
    }


    //*
    // * @file IPCSDK.h
    // * @brief 此文件用于上位机接收和解析相机发送的车牌数据
    // 





    // 相机IP地址 
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CAMERA_IP
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] ip; //相机IP 
        [MarshalAs(UnmanagedType.U2)]
        public ushort port; // 相机视频流端口 
        [MarshalAs(UnmanagedType.U2)]
        public ushort reserved; // 保留字段，32bit对齐 
    }

    // 感兴趣区域定义 
    public class ROI_RECT
    {
        public int left; //左 offset 
        public int top; //上 offset 
        public int right; //右 offset 
        public int bottom; //下 offset 
    }

    // 触发模式 
    public enum TRIGGER_MODE : int
    {
        TRIGGER_MODE_VIDEO, // 视频移动侦测触发
        TRIGGER_MODE_IO, // 地感触发
        TRIGGER_MODE_MIX, // 混合模式
        TRIGGER_MODE_MAX // End of the enum
    }

    // 识别模式 
    public enum RECOGNIZE_MODE : int
    {
        RECOGNIZE_MODE_SNAP, // 单帧识别模式
        RECOGNIZE_MODE_VIDEO, // 多帧选优模式
        RECOGNIZE_MODE_MAX // End of the enum
    }

    // 上传模式 
    public enum TRANSFER_MODE : int
    {
        TRANSFER_MODE_JSON = 0, // JSON 上传方式
        TRANSFER_MODE_SDK = 1, // SDK 上传方式
        TRANSFER_MODE_FTP = 2, // FTP 上传方式
        TRANSFER_MODE_UDISK = 3, // 存储到U盘
        TRANSFER_MODE_MAX = 4 // End of the enum
    }

    // 输出分辨率 
    public enum OUTPUT_RESOLUTION : uint
    {
        OUTPUT_RESOLUTION_1024_576, // 1024x576
        OUTPUT_RESOLUTION_1920_1080, // 1080P
        OUTPUT_RESOLUTION_MAX // End of the enum
    }

    // 输出模式 
    public enum OUTPUT_MODE : int
    {
        OUTPUT_MODE_NEAR, // 只输出驶来方向的车牌，过滤驶离防线的车牌
        OUTPUT_MODE_ALL, // 输出全部识别到的车牌
        OUTPUT_MODE_MAX // End of the enum
    }

    // 道闸模式 
    public enum DOOR_MODE : int
    {
        DOOR_MODE_CAMERA_AUTO, // 相机只要识别到车牌就开闸
        DOOR_MODE_CAMERA_AUTO_EXCEPT_BLACK, // 相机为除了黑名单的用户开闸
        DOOR_MODE_CAMERA_WHITELIST, // 相机只为白名单用户开闸
        DOOR_MODE_PC_CONTROL, // 相机不自动开闸，完全等PC指令
        DOOR_MODE_MAX // End of the enum
    }


    // RS485工作模式 
    public enum RS485_MODE : uint
    {
        RS485_MODE_TRANSPARENT = 0, // 透明传输方式
        RS485_MODE_PLATE_OUTPUT = 0, // 私有协议车牌输出方式
        RS485_MODE_LED_CONTROL = 0, // 控制LED显示屏方式
        RS485_MODE_MAX = 0 // End of the enum
    }

    // LED显示屏型号 
    public enum LED_TYPE : int
    {
        LED_TYPE_MINGXING_8CHAR, // 铭星4字屏
        LED_TYPE_CUSTORM_DEFINE, // 客户付费集成
        LED_TYPE_MAX // End of the enum
    }

    // 车牌号类型 
    public enum PLATE_TYPE : int
    {
        PLATE_TYPE_NORMAL, // 普通车牌
        PLATE_TYPE_WHITELIST, // 有效期内的白名单车牌
        PLATE_TYPE_WHITELIST_OUT_OF_DATE, // 过期的白名单车牌
        PLATE_TYPE_BLACKLIST, // 有效期内的黑名单车牌
        PLATE_TYPE_BLACKLIST_OUT_OF_DATE, // 过期的黑名单车牌
        PLATE_TYPE_MAX // End of the enum
    }

    internal sealed class DefineConstants
    {
        public const int ROI_NUM_MAX = 6;
        public const int PLATE_WIDTH_MIN = 65;
        public const int PLATE_WIDTH_MAX = 380;
        public const int OUTPUT_INTERVAL_MIN = 10;
        public const int OUTPUT_INTERVAL_MAX = 60;
        public const int DOOR_DELAY_MIN = 300;
        public const int DOOR_DELAY_MAX = 1000;
    }
}
