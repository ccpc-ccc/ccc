using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;

namespace YF.MWS.Win.View.Weight
{
    public partial class FrmViewVideo : BaseForm
    {
        private List<BFile> lstFile = new List<BFile>();
        private IFileService fileService = new FileService();
        private int currentIndex = 0;

        public FrmViewVideo()
        {
            InitializeComponent();
        }

        private void FrmViewVideo_Load(object sender, EventArgs e)
        {
            BindData();
            LoadVideo();
        }

        private void btnItemClose_ItemClick(object sender,ItemClickEventArgs e)
        {
            this.Close();
        }

        private void player_StatusChange(object sender, EventArgs e)
        {
            /*  0 Undefined Windows Media Player is in an undefined state.(未定义) 
            1 Stopped Playback of the current media item is stopped.(停止) 
            2 Paused Playback of the current media item is paused. When a media item is paused, resuming playback begins from the same location.(停留) 
            3 Playing The current media item is playing.(播放) 
            4 ScanForward The current media item is fast forwarding. 
            5 ScanReverse The current media item is fast rewinding. 
            6 Buffering The current media item is getting additional data from the server.(转换) 
            7 Waiting Connection is established, but the server is not sending data. Waiting for session to begin.(暂停) 
            8 MediaEnded Media item has completed playback. (播放结束) 
            9 Transitioning Preparing new media item. 
            10 Ready Ready to begin playing.(准备就绪) 
            11 Reconnecting Reconnecting to stream.(重新连接) 
        */
            //判断视频是否已停止播放  
            if ((int)player.playState == 1)
            {
                //停顿2秒钟再重新播放  
                //System.Threading.Thread.Sleep(2000);
                //重新播放  
                //player.Ctlcontrols.play();
            }  
        }

        private void btnItemFirst_ItemClick(object sender, ItemClickEventArgs e)
        {
            currentIndex = 0;
            LoadVideo();
        }

        private void barItemPrev_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
            }
            LoadVideo();
        }

        private void barItemNext_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (currentIndex < lstFile.Count - 1)
            {
                currentIndex++;
            }
            LoadVideo();
        }

        private void barItemLast_ItemClick(object sender, ItemClickEventArgs e)
        {
            currentIndex = lstFile.Count - 1;
            LoadVideo();
        }

        private void LoadVideo() 
        {
            if (lstFile.Count >= currentIndex + 1)
            {
                BFile file = lstFile[currentIndex];
                string fileName = Path.Combine(Application.StartupPath, file.FileUrl);
                player.URL = fileName;
            }
        }

        private void BindData()
        {
            lstFile = fileService.Get(RecId, "B_Weight", FileBusinessType.Video);
        }
    }
}