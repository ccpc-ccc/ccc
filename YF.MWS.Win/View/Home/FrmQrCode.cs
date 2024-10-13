using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using com.google.zxing.common;
using com.google.zxing;
using DevExpress.XtraEditors;

namespace YF.MWS.Win.View.Home
{
    public partial class FrmQrCode : DevExpress.XtraEditors.XtraForm
    {

        public string Url { get; set; }
        public FrmQrCode(string url)
        {
            InitializeComponent();
            Url = url;
        }

        private void FrmAd_Load(object sender, EventArgs e)
        {
            ByteMatrix byteMatrix = new MultiFormatWriter().encode(Url, BarcodeFormat.QR_CODE, 420, 460);
            int width=byteMatrix.Width;
            int height=byteMatrix.Height;
            Bitmap bmp = new Bitmap(width, height,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for(int x = 0; x < width; x++) {
                for(int y = 0; y < height; y++) {
                    bmp.SetPixel(x, y, byteMatrix.get_Renamed(x, y) != -1 ? ColorTranslator.FromHtml("0xFF000000") : ColorTranslator.FromHtml("0xFFFFFFFF"));
                }
            }
            this.pictureEdit1.Image = bmp;
        }

        private void FrmAd_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}