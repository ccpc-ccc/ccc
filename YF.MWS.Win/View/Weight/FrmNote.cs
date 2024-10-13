using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;

namespace YF.MWS.Win.View.Weight
{
    public partial class FrmNote : WaitForm
    {
        public FrmNote()
        {
            InitializeComponent(); 
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SplashScreenManager.CloseForm();
        }
    }
}