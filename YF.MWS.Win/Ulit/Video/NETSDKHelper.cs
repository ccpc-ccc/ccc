using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YF.MWS.Win.Util.Video
{
    public enum NETDEV_CHANNEL_STATUS_E
    {
        NETDEV_CHL_STATUS_OFFLINE,
        NETDEV_CHL_STATUS_ONLINE,
        NETDEV_CHL_STATUS_VIDEO_LOST,
        NETDEV_CHL_STATUS_MAX,

        NETDEV_CHL_STATUS_BUTT
    }

    public enum NETDEV_CAMERA_TYPE_E
    {
        NETDEV_CAMERA_TYPE_FIX = 0,
        NETDEV_CAMERA_TYPE_PTZ = 1,

        NETDEV_CAMERA_TYPE_INVALID = 0xFF
    }

    public enum NETDEV_RENDER_SCALE_E
    {
        NETDEV_RENDER_SCALE_FULL = 0,
        NETDEV_RENDER_SCALE_PROPORTION = 1,

        NETDEV_RENDER_SCALE_BUTT = 0xFF
    }

    public enum NETDEV_LIVE_STREAM_INDEX_E
    {
        NETDEV_LIVE_STREAM_INDEX_MAIN = 0,
        NETDEV_LIVE_STREAM_INDEX_AUX = 1,
        NETDEV_LIVE_STREAM_INDEX_THIRD = 2,

        NETDEV_LIVE_STREAM_INDEX_BUTT
    };

    public enum NETDEV_PICTURE_FORMAT_E
    {
        NETDEV_PICTURE_BMP = 0,                  /* bmp */
        NETDEV_PICTURE_JPG = 1,                  /* jpg */

        NETDEV_PICTURE_BUTT
    };

    public enum NETDEV_EXCEPTION_TYPE_E
    {
        /*  200~299 */

        /* 300~399 */
        NETDEV_EXCEPTION_REPORT_VOD_END = 300,
        NETDEV_EXCEPTION_REPORT_VOD_ABEND,
        NETDEV_EXCEPTION_REPORT_BACKUP_END,
        NETDEV_EXCEPTION_REPORT_BACKUP_DISC_OUT,
        NETDEV_EXCEPTION_REPORT_BACKUP_DISC_FULL,
        NETDEV_EXCEPTION_REPORT_BACKUP_ABEND,

        NETDEV_EXCEPTION_EXCHANGE = 0x8000,            /* 45S */

        NETDEV_EXCEPTION_REPORT_MAX,

        NETDEV_EXCEPTION_REPORT_INVALID = 0xFFFF
    };

    public enum NETDEV_VIDEO_CODE_TYPE_E
    {
        NETDEV_VIDEO_CODE_MJPEG = 0,          /* MJPEG */
        NETDEV_VIDEO_CODE_H264 = 1,          /* H.264 */
        NETDEV_VIDEO_CODE_BUTT
    };

    public enum UW_VIDEO_QUALITY_E
    {
        VQ_L0 = 0,            /* highest */
        VQ_L1 = 1,
        VQ_L2 = 4,            /* high */
        VQ_L3 = 8,
        VQ_L4 = 12,           /* middle */
        VQ_L5 = 16,
        VQ_L6 = 20,           /* low */
        VQ_L7 = 24,
        VQ_L8 = 28,           /* lower */
        VQ_L9 = 31,           /* lowest */

        VQ_LEVEL_INVALID = -1,
    };

    public enum NETDEV_CONFIG_COMMAND_E
    {
        NETDEV_GET_DEVICECFG = 100,            /* #NETDEV_DEVICE_INFO_S  Get device information, see #NETDEV_DEVICE_INFO_S */
        NETDEV_SET_DEVICECFG = 101,

        NETDEV_GET_NTPCFG = 110,            /* NTP#NETDEV_SYSTEM_NTP_INFO_S  Get NTP parameter, see #NETDEV_SYSTEM_NTP_INFO_S */
        NETDEV_SET_NTPCFG = 111,            /* NTP#NETDEV_SYSTEM_NTP_INFO_S  Set NTP parameter, see #NETDEV_SYSTEM_NTP_INFO_S */

        NETDEV_GET_STREAMCFG = 120,            /* #NETDEV_VIDEO_STREAM_INFO_S  Get video encoding parameter, see #NETDEV_VIDEO_STREAM_INFO_S */
        NETDEV_SET_STREAMCFG = 121,            /* #NETDEV_VIDEO_STREAM_INFO_S  Set video encoding parameter, see #NETDEV_VIDEO_STREAM_INFO_S */

        NETDEV_GET_PTZPRESETS = 130,            /* #NETDEV_PTZ_ALLPRESETS_S  Get PTZ preset, see #NETDEV_PTZ_ALLPRESETS_S */

        NETDEV_GET_OSDCFG = 140,            /* OSD#NETDEV_VIDEO_OSD_CFG_S  Get OSD configuration information, see #NETDEV_VIDEO_OSD_CFG_S */
        NETDEV_SET_OSDCFG = 141,            /* OSD#NETDEV_VIDEO_OSD_CFG_S  Set OSD configuration information, see #NETDEV_VIDEO_OSD_CFG_S */

        NETDEV_GET_ALARM_OUTPUTCFG = 150,            /* #NETDEV_ALARM_OUTPUT_LIST_S  Get boolean configuration information, see #NETDEV_ALARM_OUTPUT_LIST_S */
        NETDEV_SET_ALARM_OUTPUTCFG = 151,            /* #NETDEV_ALARM_OUTPUT_LIST_S       Set boolean configuration information, see #NETDEV_ALARM_OUTPUT_LIST_S */
        NETDEV_TRIGGER_ALARM_OUTPUT = 152,            /* LPNETDEV_TRIGGER_ALARM_OUTPUT_LIST_S  Trigger boolean    LPNETDEV_TRIGGER_ALARM_OUTPUT_LIST_S */
        NETDEV_GET_ALARM_INPUTCFG = 153,            /* #NETDEV_ALARM_INPUT_INFO_S Get the number of boolean inputs   see #NETDEV_ALARM_INPUT_INFO_S*/

        NETDEV_GET_IMAGECFG = 160,            /* #NETDEV_IMAGE_SETTING_S  Get image configuration information, see #NETDEV_IMAGE_SETTING_S */
        NETDEV_SET_IMAGECFG = 161,            /* #NETDEV_IMAGE_SETTING_S  Set image configuration information, see #NETDEV_IMAGE_SETTING_S */

        NETDEV_GET_NETWORKCFG = 170,            /* #NETDEV_IMAGE_SETTING_S  Get network configuration information, see #NETDEV_IMAGE_SETTING_S */
        NETDEV_SET_NETWORKCFG = 171,            /* #NETDEV_IMAGE_SETTING_S  Set network configuration information, see #NETDEV_IMAGE_SETTING_S */

        NETDEV_GET_PRIVACYMASKCFG = 180,            /* #NETDEV_PRIVACY_MASK_CFG_S  Get privacy mask configuration information, see #NETDEV_PRIVACY_MASK_CFG_S */
        NETDEV_SET_PRIVACYMASKCFG = 181,            /* #NETDEV_PRIVACY_MASK_CFG_S  Set privacy mask configuration information, see #NETDEV_PRIVACY_MASK_CFG_S */
        NETDEV_DELETE_PRIVACYMASKCFG = 182,            /* Delete privacy mask configuration information */

        NETDEV_GET_TAMPERALARM = 190,            /*  Get tamper alarm configuration information, see#NETDEV_TAMPER_ALARM_INFO_S */
        NETDEV_SET_TAMPERALARM = 191,            /*  Set tamper alarm configuration information, see#NETDEV_TAMPER_ALARM_INFO_S */

        NETDEV_GET_MOTIONALARM = 201,            /* Get motion alarm configuration information, see#NETDEV_MOTION_ALARM_INFO_S */
        NETDEV_SET_MOTIONALARM = 202             /*  Set motion alarm configuration information, see#NETDEV_MOTION_ALARM_INFO_S */
    };

    /**
     * @enum tagNETDEVCFGCmd
     * @brief   Parameter configuration command words Enumeration definition
     * @attention  None
     */
    public enum NETDEV_DEVICETYPE_E
    {
        NETDEV_DTYPE_UNKNOWN = -1,              /* Unknown type */
        NETDEV_DTYPE_IPC = 1,                   /* IPC range [1-100] */
        NETDEV_DTYPE_NVR = 101,                 /* NVR range [101-200] */
        NETDEV_DTYPE_DC = 201,                  /* DC range [201-300] */
        NETDEV_DTYPE_EC = 301,                  /* EC range [301-400] */
        NETDEV_DTYPE_CVS = 401,
        NETDEV_DTYPE_VMS = 501

    };

    public enum NETDEV_PROTOCAL_E
    {
        NETDEV_TRANSPROTOCAL_RTPTCP = 1
    };

    public enum NETDEV_PTZ_E
    {
        NETDEV_PTZ_FOCUSNEAR = 0x0202,       /* Focus near */
        NETDEV_PTZ_FOCUSFAR = 0x0204,       /* Focus far */
        NETDEV_PTZ_ZOOMTELE = 0x0302,       /*   Zoom in */
        NETDEV_PTZ_ZOOMWIDE = 0x0304,       /*   Zoom out */
        NETDEV_PTZ_TILTUP = 0x0402,         /*   Tilt up */
        NETDEV_PTZ_TILTDOWN = 0x0404,       /*   Tilt down */
        NETDEV_PTZ_PANRIGHT = 0x0502,       /*   Pan right */
        NETDEV_PTZ_PANLEFT = 0x0504,        /*   Pan left */
        NETDEV_PTZ_LEFTUP = 0x0702,         /*   Move up left */
        NETDEV_PTZ_LEFTDOWN = 0x0704,       /*   Move down left */
        NETDEV_PTZ_RIGHTUP = 0x0802,        /*   Move up right */
        NETDEV_PTZ_RIGHTDOWN = 0x0804,      /*   Move down right */

        NETDEV_PTZ_ALLSTOP = 0x0901,        /*   All-stop command word */

        NETDEV_PTZ_TRACKCRUISE = 0x1001,                /*   Start route patrol*/
        NETDEV_PTZ_TRACKCRUISESTOP = 0x1002,            /*   Stop route patrol*/
        NETDEV_PTZ_TRACKCRUISEREC = 0x1003,             /*   Start recording route */
        NETDEV_PTZ_TRACKCRUISERECSTOP = 0x1004,         /*   Stop recording route */
        NETDEV_PTZ_TRACKCRUISEADD = 0x1005,             /*   Add patrol route */
        NETDEV_PTZ_TRACKCRUISEDEL = 0x1006,             /*   Delete patrol route */

        NETDEV_PTZ_AREAZOOMIN = 0x1101,                 /*   Zoom in area */
        NETDEV_PTZ_AREAZOOMOUT = 0x1102,                /*   Zoom out area */
        NETDEV_PTZ_AREAZOOM3D = 0x1103,                 /* 3D  3D positioning */

        NETDEV_PTZ_BRUSHON = 0x0A01,                    /*   Wiper on */
        NETDEV_PTZ_BRUSHOFF = 0x0A02,                   /*   Wiper off */

        NETDEV_PTZ_LIGHTON = 0x0B01,                    /*   Lamp on */
        NETDEV_PTZ_LIGHTOFF = 0x0B02,                   /*   Lamp off */

        NETDEV_PTZ_HEATON = 0x0C01,                     /*   Heater on */
        NETDEV_PTZ_HEATOFF = 0x0C02,                    /*   Heater off */

        NETDEV_PTZ_SNOWREMOINGON = 0x0D01,              /*   Snowremoval on */
        NETDEV_PTZ_SNOWREMOINGOFF = 0x0D02,             /*   Snowremoval off  */

        NETDEV_PTZ_BUTT
    };

    public enum NETDEV_PTZ_PRESETCMD_E
    {
        NETDEV_PTZ_SET_PRESET = 0,            /*   Set preset */
        NETDEV_PTZ_CLE_PRESET = 1,            /*   Clear preset */
        NETDEV_PTZ_GOTO_PRESET = 2             /*   Go to preset */
    };

    public enum NETDEV_PTZ_CRUISECMD_E
    {
        NETDEV_PTZ_ADD_CRUISE = 0,         /*    Add patrol route */
        NETDEV_PTZ_MODIFY_CRUISE = 1,         /*   Edit patrol route */
        NETDEV_PTZ_DEL_CRUISE = 2,         /*   Delete patrol route */
        NETDEV_PTZ_RUN_CRUISE = 3,         /*   Start patrol */
        NETDEV_PTZ_STOP_CRUISE = 4          /*   Stop patrol */
    };

    public enum NETDEV_MEDIA_FILE_FORMAT_E
    {
        NETDEV_MEDIA_FILE_MP4 = 0,           /* mp4  mp4 media file */
        NETDEV_MEDIA_FILE_TS = 1,            /* TS  TS media file */
        NETDEV_MEDIA_FILE_BUTT
    };

    public enum NETDEV_VOD_PLAY_STATUS_E
    {
        /**   Play status */
        NETDEV_PLAY_STATUS_16_BACKWARD = 0,        /* 16  Backward at 16x speed */
        NETDEV_PLAY_STATUS_8_BACKWARD = 1,        /* 8  Backward at 8x speed */
        NETDEV_PLAY_STATUS_4_BACKWARD = 2,        /* 4  Backward at 4x speed */
        NETDEV_PLAY_STATUS_2_BACKWARD = 3,        /* 2  Backward at 2x speed */
        NETDEV_PLAY_STATUS_1_BACKWARD = 4,        /*   Backward at normal speed */
        NETDEV_PLAY_STATUS_HALF_BACKWARD = 5,        /* 1/2  Backward at 1/2 speed */
        NETDEV_PLAY_STATUS_QUARTER_BACKWARD = 6,        /* 1/4  Backward at 1/4 speed */
        NETDEV_PLAY_STATUS_QUARTER_FORWARD = 7,        /* 1/4  Play at 1/4 speed */
        NETDEV_PLAY_STATUS_HALF_FORWARD = 8,        /* 1/2  Play at 1/2 speed */
        NETDEV_PLAY_STATUS_1_FORWARD = 9,        /*   Forward at normal speed */
        NETDEV_PLAY_STATUS_2_FORWARD = 10,       /* 2  Forward at 2x speed */
        NETDEV_PLAY_STATUS_4_FORWARD = 11,       /* 4  Forward at 4x speed */
        NETDEV_PLAY_STATUS_8_FORWARD = 12,       /* 8  Forward at 8x speed */
        NETDEV_PLAY_STATUS_16_FORWARD = 13,       /* 16  Forward at 16x speed */

        NETDEV_PLAY_STATUS_INVALID
    };

    public enum NETDEV_VOD_PLAY_CTRL_E
    {
        NETDEV_PLAY_CTRL_PLAY = 0,           /*   Play */
        NETDEV_PLAY_CTRL_PAUSE = 1,           /*   Pause */
        NETDEV_PLAY_CTRL_RESUME = 2,           /*   Resume */
        NETDEV_PLAY_CTRL_GETPLAYTIME = 3,           /*   Obtain playing time */
        NETDEV_PLAY_CTRL_SETPLAYTIME = 4,           /*   Configure playing time */
        NETDEV_PLAY_CTRL_GETPLAYSPEED = 5,           /*   Obtain playing speed */
        NETDEV_PLAY_CTRL_SETPLAYSPEED = 6            /*   Configure playing speed */
    };

    public enum NETDEV_HOSTTYPE_E
    {
        NETDEV_NETWORK_HOSTTYPE_IPV4 = 0,               /* IPv4 */
        NETDEV_NETWORK_HOSTTYPE_IPV6 = 1,               /* IPv6 */
        NETDEV_NETWORK_HOSTTYPE_DNS = 2                /* DNS */
    };
    public enum NETDEV_RELAYOUTPUT_STATE_E
    {
        NETDEV_BOOLEAN_STATUS_ACTIVE = 0,            /*   Triggered */
        NETDEV_BOOLEAN_STATUS_INACTIVE = 1             /*  Not triggered */
    };

    public enum NETDEV_OSD_TIME_FORMAT_CAP_E
    {
        NETDEV_OSD_TIME_FORMAT_CAP_HHMMSS = 0,          /* HH:mm:ss */
        NETDEV_OSD_TIME_FORMAT_CAP_HH_MM_SS_PM          /* hh:mm:ss tt */

    };

    public enum NETDEV_E_DOWNLOAD_SPEED_E
    {
        NETDEV_DOWNLOAD_SPEED_ONE = 0,         /*   1x */
        NETDEV_DOWNLOAD_SPEED_TWO,             /*   2x */
        NETDEV_DOWNLOAD_SPEED_FOUR,            /*   4x */
        NETDEV_DOWNLOAD_SPEED_EIGHT            /*   8x */
    };

    public enum NETDEV_PROTOCOL_TYPE_E
    {
        NETDEV_NETWORK_PROTOCOLTYPE__HTTP = 0,
        NETDEV_NETWORK_PROTOCOLTYPE__HTTPS = 1,
        NETDEV_NETWORK_PROTOCOLTYPE__RTSP = 2
    };

    public enum NETDEV_TIME_ZONE_E
    {
        NETDEV_TIME_ZONE_W1200 = 0,              /* W12 */
        NETDEV_TIME_ZONE_W1100 = 1,              /* W11 */
        NETDEV_TIME_ZONE_W1000 = 2,              /* W10 */
        NETDEV_TIME_ZONE_W0900 = 3,              /* W9 */
        NETDEV_TIME_ZONE_W0800 = 4,              /* W8 */
        NETDEV_TIME_ZONE_W0700 = 5,              /* W7 */
        NETDEV_TIME_ZONE_W0600 = 6,              /* W6 */
        NETDEV_TIME_ZONE_W0500 = 7,              /* W5 */
        NETDEV_TIME_ZONE_W0430 = 8,              /* W4:30 */
        NETDEV_TIME_ZONE_W0400 = 9,              /* W4 */
        NETDEV_TIME_ZONE_W0330 = 10,             /* W3:30 */
        NETDEV_TIME_ZONE_W0300 = 11,             /* W3 */
        NETDEV_TIME_ZONE_W0200 = 12,             /* W2 */
        NETDEV_TIME_ZONE_W0100 = 13,             /* W1 */
        NETDEV_TIME_ZONE_0000 = 14,             /* W0 */
        NETDEV_TIME_ZONE_E0100 = 15,             /* E1 */
        NETDEV_TIME_ZONE_E0200 = 16,             /* E2 */
        NETDEV_TIME_ZONE_E0300 = 17,             /* E3 */
        NETDEV_TIME_ZONE_E0330 = 18,             /* E3:30 */
        NETDEV_TIME_ZONE_E0400 = 19,             /* E4 */
        NETDEV_TIME_ZONE_E0430 = 20,             /* E4:30 */
        NETDEV_TIME_ZONE_E0500 = 21,             /* E5 */
        NETDEV_TIME_ZONE_E0530 = 22,             /* E5:30 */
        NETDEV_TIME_ZONE_E0545 = 23,             /* E5:45 */
        NETDEV_TIME_ZONE_E0600 = 24,             /* E6 */
        NETDEV_TIME_ZONE_E0630 = 25,             /* E6:30 */
        NETDEV_TIME_ZONE_E0700 = 26,             /* E7 */
        NETDEV_TIME_ZONE_E0800 = 27,             /* E8 */
        NETDEV_TIME_ZONE_E0900 = 28,             /* E9 */
        NETDEV_TIME_ZONE_E0930 = 29,             /* E9:30 */
        NETDEV_TIME_ZONE_E1000 = 30,             /* E10 */
        NETDEV_TIME_ZONE_E1100 = 31,             /* E11 */
        NETDEV_TIME_ZONE_E1200 = 32,             /* E12 */
        NETDEV_TIME_ZONE_E1300 = 33,             /* E13 */

        NETDEV_TIME_ZONE_INVALID = 0xFF          /* Invalid value */
    };

    /**
 * @enum tagNETDEVCFGCmd
 * @brief   Parameter configuration command words Enumeration definition
 * @attention  None
 */

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_INFO_S
    {
        public Int32 dwAlarmType;
        public Int64 tAlarmTime;
        public Int32 dwChannelID;
        public Int16 wIndex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
        public byte[] szReserve;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEVICE_INFO_S
    {
        public Int32 dwDevType;
        public Int16 wAlarmInPortNum;                   /* Number of alarm inputs */
        public Int16 wAlarmOutPortNum;                  /* Number of alarm outputs */
        public Int32 dwChannelNum;                      /* Number of Channels */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] szReserve;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_CHL_DETAIL_INFO_S
    {
        public Int32 dwChannelID;
        public Int32 dwType;
        public Int32 enStatus;        /*NETDEV_CHANNEL_STATUS_E*/
        public Int32 dwStreamNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 68)]
        public byte[] szReserve;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PREVIEWINFO_S
    {
        public Int32 dwChannelID;
        public Int32 dwStreamType;
        public Int32 dwLinkMode;
        public IntPtr hPlayWnd;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 264)]
        public byte[] szReserve;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FILECOND_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] szFileName;      /*   Recording file name */
        public Int32 dwChannelID;
        public Int32 dwFileType;
        public Int64 tBeginTime;
        public Int64 tEndTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 104)]
        public byte[] szReserve;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FINDDATA_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szFileName;

        public Int64 tBeginTime;
        public Int64 tEndTime;

        public byte byFileType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 171)]
        public byte[] szReserve;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PLAYBACKINFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szFileName;

        public Int64 tBeginTime;
        public Int64 tEndTime;

        public Int32 dwLinkMode;
        public IntPtr hPlayWnd;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 264)]
        public byte[] szReserve;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PLAYBACKCOND_S
    {
        public Int32 dwChannelID;                  /*   Playback channel */
        public Int64 tBeginTime;                  /*   Playback start time */
        public Int64 tEndTime;                    /*   Playback end time */
        public Int32 dwLinkMode;                   /*  Transport protocol, see enumeration #NETDEV_PROTOCAL_E */
        public IntPtr hPlayWnd;                    /*   Play window handle */
        public Int32 dwFileType;                   /* #NETDEV_PLAN_STORE_TYPE_E  Recording storage type, see enumeration #NETDEV_PLAN_STORE_TYPE_E */
        public Int32 dwDownloadSpeed;               /*  #NETDEV_E_DOWNLOAD_SPEED_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public byte[] byRes;                 /*   Reserved */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_STREAM_INFO_S
    {
        public Int32 enStreamType;       /*  NETDEV_LIVE_STREAM_INDEX_E*/
        public Int32 bEnableFlag;
        public Int32 dwHeight;           /* -Height */
        public Int32 dwWidth;            /* -Width */
        public Int32 dwFrameRate;
        public Int32 dwBitRate;
        public Int32 enCodeType;         /*  NETDEV_VIDEO_CODE_TYPE_E*/
        public Int32 enQuality;          /*  UW_VIDEO_QUALITY_E*/
        public Int32 dwGop;              /* I */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szReserve;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_OPERATEAREA_S
    {
        public Int32 dwBeginPointX;                           /* X[0,10000]  Area start point X value [0,10000] */
        public Int32 dwBeginPointY;                           /* Y[0,10000]  Area start point Y value [0,10000] */
        public Int32 dwEndPointX;                             /* X[0,10000]  Area end point X value [0,10000] */
        public Int32 dwEndPointY;                             /* Y [0,10000]  Area end point Y value [0,10000] */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_PRESET_S
    {
        public Int32 dwPresetID;                                 /* ID  Preset ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szPresetName;                /*   Preset name */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_ALLPRESETS_S
    {
        public Int32 dwSize;                             /*   Total number of presets */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public NETDEV_PTZ_PRESET_S[] astPreset;   /*   Structure of preset information */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CRUISE_POINT_S
    {
        public Int32 dwPresetID;                     /* ID  Preset ID */
        public Int32 dwStayTime;                     /*   Stay time */
        public Int32 dwSpeed;                        /*   Speed */
        public Int32 dwReserve;                      /*   Reserved */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CRUISE_INFO_S
    {
        public Int32 dwCuriseID;                                     /* ID  Route ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] szCuriseName;                    /*   Route name */
        public Int32 dwSize;                                         /*   Number of presets included in the route */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public NETDEV_CRUISE_POINT_S[] astCruisePoint;     /*    Information of presets included in the route */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CRUISE_LIST_S
    {
        public Int32 dwSize;                                         /*   Number of patrol routes */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public NETDEV_CRUISE_INFO_S[] astCruiseInfo;      /*   Information of patrol routes */
    };

    /**
 * @struct tagNETDEVPtzTrackinfo
 * @brief   Route information of PTZ route patrol Structure definition
 * @attention  None
 */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_TRACK_INFO_S
    {
        public Int32 dwTrackNum;                                               /*   Number of existing patrol routes */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] aszTrackName;  /*   Route name */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IMAGE_SETTING_S
    {
        public Int32 dwContrast;                   /*   Contrast */
        public Int32 dwBrightness;                 /*   Brightness */
        public Int32 dwSaturation;                 /*   Saturation */
        public Int32 dwSharpness;                  /*   Sharpness */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[] byRes;                     /* Reserved */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SYSTEM_IPADDR_S
    {
        public Int32 eIPType;                            /* #NETDEV_HOSTTYPE_E  Protocol type, see enumeration #NETDEV_HOSTTYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
        public char[] szIPAddr;           /* IP  IP address */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SYSTEM_NTP_INFO_S
    {
        public bool bSupportDHCP;                      /* DHCP  Support DHCP or not */
        public NETDEV_SYSTEM_IPADDR_S stAddr;          /* NTP   NTP information */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_NETWORKCFG_S
    {
        public Int32 dwMTU;                                         /* MTU value */
        public Int32 dwIPv4DHCP;                                    /* DHCP of IPv4 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] szIpv4Address;                                /* IP address of IPv4 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] szIPv4GateWay;                                /*  Gateway of IPv4 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] byRes;                                        /*   Reserved */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_INPUT_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] szName;                                                  /*    Name of input alarm */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_INPUT_LIST_S
    {
        public Int32 dwSize;                                           /*   Number of input alarms */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public NETDEV_ALARM_INPUT_INFO_S[] astAlarmInputInfo;       /*   Configuration information of input alarms */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_OUTPUT_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] szName;                                           /*  Boolean name */
        public Int32 dwChancelId;                                       /*  Channel number */
        public Int32 enDefaultStatus;                                   /*  Default status of boolean output, see enumeration #NETDEV_BOOLEAN_MODE_E */
        public Int32 dwDurationSec;                                     /*  Alarm duration (s) */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_OUTPUT_LIST_S
    {
        public Int32 dwSize;                                                 /*    Number of booleans  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public NETDEV_ALARM_OUTPUT_INFO_S[] astAlarmOutputInfo;           /*   Boolean configuration information */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TRIGGER_ALARM_OUTPUT_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] szName;          /*   Boolean name */
        public NETDEV_RELAYOUTPUT_STATE_E enOutputState;                  /* ,#NETDEV_RELAYOUTPUT_STATE_E  Trigger status, see enumeration #NETDEV_RELAYOUTPUT_STATE_E */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_AREA_SCOPE_S
    {
        public Int32 dwLocateX;             /** x[0,10000] * Coordinates of top point x [0,10000] */
        public Int32 dwLocateY;             /** y[0,10000] * Coordinates of top point y [0,10000] */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OSD_TIME_S
    {
        public bool bEnableFlag;        /** OSD BOOL_TRUEBOOL_FALSE * Enable time OSD, BOOL_TRUE means enable and BOOL_FALSE means disable */
        public bool bWeekEnableFlag;    /** () * Display week or not (reserved) */
        public NETDEV_AREA_SCOPE_S stAreaScope;        /**  * Area coordinates */
        public Int32 udwTimeFormat;      /** OSDNETDEV_OSD_TIME_FORMAT_E * Time OSD format, see NETDEV_OSD_TIME_FORMAT_E */
        public Int32 udwDateFormat;      /** OSDNETDEV_OSD_DATE_FMT_E * Date OSD format, see NETDEV_OSD_TIME_FORMAT_E */

    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OSD_TEXT_OVERLAY_S
    {
        public bool bEnableFlag;                /** OSD BOOL_TRUEBOOL_FALSE * Enable OSD text overlay, BOOL_TRUE means enable and BOOL_FALSE means disable */
        public NETDEV_AREA_SCOPE_S stAreaScope;                /** OSD * OSD text overlay area coordinates */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] szOSDText;    /** OSD * OSD text overlay name strings */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] byRes;                               /*   Reserved */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_OSD_CFG_S
    {
        public NETDEV_OSD_TIME_S stTimeOSD;        /* OSD  Information of channel time OSD */
        public NETDEV_OSD_TEXT_OVERLAY_S stNameOSD;        /* OSD  Information of channel name OSD */
        public Int16 wTextNum;         /* OSD  Text OSD exists or not */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public NETDEV_OSD_TEXT_OVERLAY_S[] astTextOverlay;   /** OSD * Information of channel OSD text overlay */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEVICE_BASICINFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] szDevModel;                     /*   Device model */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] szSerialNum;                    /*   Hardware serial number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] szFirmwareVersion;              /*   Software version */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] szMacAddress;                   /* IPv4Mac  MAC address of IPv4 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] szDeviceName;                   /* Device name */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 448)]
        public byte[] byRes;                                    /*   Reserved */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PRIVACY_MASK_AREA_INFO_S
    {
        public Int32 bIsEanbled;           /*   Enable or not. */
        public Int32 dwTopLeftX;           /* X [0, 10000]  Upper left corner X [0, 10000]  */
        public Int32 dwTopLeftY;           /* Y [0, 10000]  Upper left corner Y [0, 10000]  */
        public Int32 dwBottomRightX;       /* X [0, 10000]  Lower right corner x [0, 10000] */
        public Int32 dwBottomRightY;       /* Y [0, 10000]  Lower right corner y [0, 10000] */
        public Int32 dwIndex;              /* Index */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PRIVACY_MASK_CFG_S
    {
        public Int32 dwSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NETDEV_PRIVACY_MASK_AREA_INFO_S[] astArea;  /*  *< Mask area parameters */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_EFFECT_S
    {
        public Int32 dwContrast;                   /* Contrast */
        public Int32 dwBrightness;                 /* Brightness */
        public Int32 dwSaturation;                 /* Saturation */
        public Int32 dwHue;                        /* Hue */
        public Int32 dwGamma;                      /* Gamma */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] byRes;                    /* Reserved */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECT_S
    {
        public Int32 dwLeft;                               /* X axis left point value [0,10000] */
        public Int32 dwTop;                                /* Y axis top point value [0,10000] */
        public Int32 dwRight;                              /* X axis right point value [0,10000] */
        public Int32 dwBottom;                             /* Y axis bottom point value [0,10000] */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct array
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public Int16[] wTemp;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MOTION_ALARM_INFO_S
    {
        public Int32 dwSensitivity;                                                     /* Sensitivity */
        public Int32 dwObjectSize;                                                      /* Objection Size */
        public Int32 dwHistory;                                                         /* History */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public array[] awScreenInfo;                                                       /* Screen Info */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;                                                             /* Reserved */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TAMPER_ALARM_INFO_S
    {
        public Int32 dwSensitivity;                               /* Sensitivity */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                       /* Reserved */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_UPNP_PORT_STATE_S
    {
        public NETDEV_PROTOCOL_TYPE_E eType;
        public bool bEnbale;
        public Int32 dwPort;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_UPNP_NAT_STATE_S
    {
        public Int32 dwSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public NETDEV_UPNP_PORT_STATE_S[] astUpnpPort;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_S
    {
        public Int32 dwYear;                       /* Year */
        public Int32 dwMonth;                      /* Month */
        public Int32 dwDay;                        /* Day */
        public Int32 dwHour;                       /* Hour */
        public Int32 dwMinute;                     /* Minute */
        public Int32 dwSecond;                     /* Second */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_CFG_S
    {
        public NETDEV_TIME_ZONE_E dwTimeZone;                      /* see NETDEV_TIME_ZONE_E */
        public NETDEV_TIME_S stTime;                               /* Time */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public byte[] byRes;                                       /* Reserved */
    };

    public class NETDEVSDK
    {
        /*@brief */
        public const int NETDEV_LEN_32 = 32;
        public const int NETDEV_IPADDR_STR_MAX_LEN = 64;
        public const int NETDEV_MAX_PRESET_NUM = 256;

        public const int NETDEV_FILE_NAME_MAX_LEN = 256;

        public const int NETDEV_LEN_260 = 260;

        public const int TRUE = 1;

        public const int FALSE = 0;
        public const int NETDEV_E_NONSUPPORT = 38;

        public static int m_bRouteRecording;
        public static int m_bTracking;


        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Init();

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Cleanup();

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_AlarmMessCallBack_PF(IntPtr lpUserID, Int32 dwChannelID, NETDEV_ALARM_INFO_S stAlarmInfo, IntPtr lpBuf, Int32 dwBufLen, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmCallBack(IntPtr lpUserID, IntPtr cbAlarmMessCallBack, IntPtr lpUserData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_ExceptionCallBack_PF(IntPtr lpUserID, Int32 dwType, IntPtr stAlarmInfo, IntPtr lpExpHandle, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetExceptionCallBack(IntPtr cbExceptionCallBack, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSDKVersion();

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_Login(String szDevIP, Int16 wDevPort, String szUserName, String szPassword, IntPtr pstDevInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Logout(IntPtr lpUserID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_QueryVideoChlDetailList(IntPtr lpUserID, ref int pdwChlCount, IntPtr pstVideoChlList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_RealPlay(IntPtr lpUserID, ref NETDEV_PREVIEWINFO_S pstPreviewInfo, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopRealPlay(IntPtr lpRealHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SaveRealData(IntPtr lpRealHandle, String szSaveFileName, Int32 dwFormat);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopSaveRealData(IntPtr lpRealHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PlaySound(IntPtr lpRealHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopPlaySound(IntPtr lpRealHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetBitRate(IntPtr lpRealHandle, ref int pdwBitRate);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetFrameRate(IntPtr lpRealHandle, ref int pdwFrameRate);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoEncodeFmt(IntPtr lpRealHandle, ref int pdwVideoEncFmt);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetResolution(IntPtr lpRealHandle, ref int pdwWidth, ref int pdwHeight);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetLostPacketRate(IntPtr lpRealHandle, ref int pulRecvPktNum, ref int pulLostPktNum);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ResetLostPacketRate(IntPtr lpRealHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CapturePicture(IntPtr lpRealHandle, String szFileName, Int32 dwCaptureMode);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CaptureNoPreview(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType, String szFileName, Int32 dwCaptureMode);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetRenderScale(IntPtr lpRealHandle, Int32 enRenderScale); /*NETDEV_RENDER_SCALE_E*/

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindFile(IntPtr lpUserID, ref NETDEV_FILECOND_S pFindCond);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextFile(IntPtr lpFindHandle, ref NETDEV_FINDDATA_S lpFindData); /*NETDEV_FINDDATA_S*/

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClose(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_PlayBackByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_PlayBackByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopPlayBack(IntPtr lpPlayHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_GetFileByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo, String szSaveFileName, Int32 dwFormat);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopGetFile(IntPtr lpPlayHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PlayBackControl(IntPtr lpPlayHandle, Int32 dwControlCode, ref Int32 pdwBuffer);


        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZPreset(IntPtr lpPlayHandle, Int32 dwPTZPresetCmd, String pszPresetName, Int32 dwPresetID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZControl(IntPtr lpPlayHandle, Int32 dwPTZCommand, Int32 dwSpeed);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, ref int dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Reboot(IntPtr lpUserID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_OpenSound(IntPtr lpRealHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CloseSound(IntPtr lpRealHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZControl_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCommand, Int32 dwSpeed);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetLastError();

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZSelZoomIn_Other(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_OPERATEAREA_S pstPtzOperateArea);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZPreset_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZPresetCmd, String pszPresetName, Int32 dwPresetID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PTZ_ALLPRESETS_S lpOutBuffer, Int32 dwOutBufferSize, ref Int32 pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_CRUISE_LIST_S pstCruiseList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZCruise_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCruiseCmd, ref NETDEV_CRUISE_INFO_S pstCruiseInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetTrackCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_TRACK_INFO_S pstTrackCruiseInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZTrackCruise(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZTrackCruiseCmd, ref byte pszTrackCruiseName);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_INPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEVICE_BASICINFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_GetFileByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackCond, String pszSaveFileName, Int32 dwFormat);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_RestoreConfig(IntPtr lpUserID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDigitalZoom(IntPtr lpRealHandle, IntPtr hWnd, IntPtr pstRect);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);


        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyDeviceName(IntPtr lpUserID, String strDeviceName);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetLogPath(String strLogPath);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);
    }
}
