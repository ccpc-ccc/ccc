using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using YF.MWS.Metadata;
using YF.MWS.Win.Util;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.UI;
using YF.MWS.Db;
using YF.MWS.Win.Util.Video;
using YF.Utility.Log;
using System.IO;
using YF.MWS.Win.View.Master;

namespace YF.MWS.Win.Uc
{
    public partial class WeightControl : UserControl
    {
        public int Index { get; private set; }
        public WeightControl(int index)
        {
            InitializeComponent();
            this.Index = index;
        }

        private void VideoControl_Load(object sender, EventArgs e)
        {
            this.lbName.Text = Program._cfg.Device[Index].Name;
        }

        /// <summary>
        ///  Device Disconnection Handling
        /// </summary>
        /// <param name="lLoginID"></param>
        /// <param name="pchDVRIP"></param>
        /// <param name="nDVRPort"></param>
        /// <param name="dwUser"></param>
        private void DisConnectEvent(int lLoginID, StringBuilder pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            //Device Disconnection Handling          
            //MessageBox.Show("Device User Disconnect", pMsgTitle);
        }

        /// <summary>
        /// 重连回调函数
        /// </summary>
        private void DisConnectCallBack(int loginId, string dvrIP, int dvrPort, IntPtr hwdUser)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            FrmDeviceSetting frm = new FrmDeviceSetting(this.Index);
            frm.ShowDialog();
        }
    }
}
