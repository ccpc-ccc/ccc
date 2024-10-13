using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace YF.MWS.Win.View.Weight
{
    public partial class FrmWeightImage : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 磅单号
        /// </summary>
        private string weightId;

        public FrmWeightImage(string weightId)
        {
            InitializeComponent();

            this.weightId = weightId;
        }

        private void FrmWeightImage_Load(object sender, EventArgs e)
        {
            string graphicFolder = string.Format("File\\Graphic\\{0}\\", this.weightId);

            if (Directory.Exists(graphicFolder))
            {
                string[] graphicFiles = Directory.GetFiles(graphicFolder);

                if (graphicFiles != null && graphicFiles.Length > 0)
                {
                    for (int i = 0; i < graphicFiles.Length; i++)
                    {
                        if (i == 0)
                        {
                            this.picWeight1.Image = Image.FromFile(graphicFiles[i]);
                        }

                        if (i == 1)
                        {
                            this.picWeight2.Image = Image.FromFile(graphicFiles[i]);
                        }

                        if (i == 2)
                        {
                            this.picWeight3.Image = Image.FromFile(graphicFiles[i]);
                        }

                        if (i == 3)
                        {
                            this.picWeight4.Image = Image.FromFile(graphicFiles[i]);
                        }
                    }
                }
            }
        }
    }
}