namespace YF.MWS.Win.Uc
{
    partial class MainWeight
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layControl = new DevExpress.XtraLayout.LayoutControl();
            this.layGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.dxValidator = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidator)).BeginInit();
            this.SuspendLayout();
            // 
            // layControl
            // 
            this.layControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layControl.Location = new System.Drawing.Point(0, 0);
            this.layControl.Name = "layControl";
            this.layControl.Root = this.layGroup;
            this.layControl.Size = new System.Drawing.Size(836, 405);
            this.layControl.TabIndex = 0;
            this.layControl.Text = "layoutControl1";
            // 
            // layGroup
            // 
            this.layGroup.CustomizationFormText = "layoutControlGroup1";
            this.layGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layGroup.GroupBordersVisible = false;
            this.layGroup.Location = new System.Drawing.Point(0, 0);
            this.layGroup.Name = "layGroup";
            this.layGroup.Size = new System.Drawing.Size(836, 405);
            this.layGroup.Text = "layGroup";
            this.layGroup.TextVisible = false;
            // 
            // MainWeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layControl);
            this.Name = "MainWeight";
            this.Size = new System.Drawing.Size(836, 405);
            ((System.ComponentModel.ISupportInitialize)(this.layControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidator)).EndInit();
            this.ResumeLayout(false);

        }

       

        #endregion

        private DevExpress.XtraLayout.LayoutControl layControl;
        private DevExpress.XtraLayout.LayoutControlGroup layGroup;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidator;
      
    }
}
