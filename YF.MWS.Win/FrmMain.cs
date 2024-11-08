using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraSplashScreen;
using System.Threading;
using System.Linq;
using YF.MWS.Win.View.Home;
using YF.MWS.Win.View.Master;
using YF.MWS.Win.Util;
using YF.Utility.Configuration;
using System.IO;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Win.Core;
using System.ServiceModel;
using YF.Utility.IO;
using YF.Utility.Log;
using YF.MWS.Db;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;
using YF.Utility;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.View.Weight;
using YF.MWS.Win.View.User;
using YF.MWS.Util;
using YF.MWS.CacheService;
using YF.Utility.Data;
using System.Xml.Linq;
using System.Diagnostics;
using YF.MWS.Metadata.Message;
using System.Deployment.Application;
using YF.MWS.Db.Server;
using DevExpress.XtraBars.Ribbon;

namespace YF.MWS.Win {
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm {
        #region private property

        private string nameSpace = "YF.MWS.Win.View";
        private string parameter = string.Empty;
        private LoginCfg loginCfg = null;
        private string loginCfgXml = Path.Combine(Application.StartupPath, "LoginCfg.xml");
        private bool returnResult = false;
        private DateTime dtStart = DateTime.Now;
        private List<SModule> lstModule = new List<SModule>();
        private List<SModule> lstUserModule = new List<SModule>();
        private ISyncService syncService;
        private ILogService logSerivce = new LogService();
        private IMasterService masterService = new MasterService();
        private AuthCfg auth = null;
        private SysCfg cfg = null;
        private WeightCacher weightCacher = new WeightCacher();
        private FrmWeight fWeight = null;
        /// <summary>
        /// 是否自动维护
        /// </summary>
        private bool startAutoMaintain;
        /// <summary>
        /// 自动启动时间间隔类型
        /// </summary>
        private ReStartTimeSpanType reStartTimeSpan;
        /// <summary>
        /// 相隔小时数
        /// </summary>
        private int hours = 0;
        /// <summary>
        /// 固定时间集合
        /// </summary>
        private List<DateTime> fixedTimes;
        /// <summary>
        /// 上次启动时间
        /// </summary>
        private DateTime lastLauchTime = DateTime.Now;

        #endregion

        public FrmMain() {
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            SplashScreenManager.ShowForm(this, typeof(FrmSplashScreen), true, true);
            //Thread.Sleep(2000);
            InitializeComponent();
            SkinHelper.InitSkinGallery(rgbTheme, true);
            this.Text = AppSetting.GetValue("appName");
            InitStateBar();
            SetClickEvent();
            IniUtility.FilePath = Path.Combine(Application.StartupPath, ConfigurationManager.AppSettings["ini"].Replace(".\\", ""));
            IniUtil.FilePath = Path.Combine(Application.StartupPath, ConfigurationManager.AppSettings["ini"].Replace(".\\", ""));
            ribbon.Minimized = true;
            CurrentClient.Instance.sysCfg = CfgUtil.GetCfg();
            cfg=new SysCfg();
            auth = CfgUtil.GetAuth();
            Program.frmViewVideoDevice = new FrmViewVideoDevice();
            Program.frmViewVideoDevice.Visible = false;
            SplashScreenManager.CloseForm();
            Authorization();
        }

        public void InitCorp() {
            barStaticItemClient.Caption = string.Format("当前站点:{0}", CurrentUser.Instance.ClientName);
        }

        private void InitStateBar() {
            InitCorp();
            barStaticItemUser.Caption = string.Format(barStaticItemUser.Caption, CurrentUser.Instance.FullName);

            VersionType type = CurrentClient.Instance.CurrentVersion.ToEnum<VersionType>();
            string dbVersion = "单机版";
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver) {
                dbVersion = "网络版";
            }
            if (type == VersionType.Official) {
                barStaticItemVersion.Caption = string.Format("正式版 当前版本:{0} 软件版本号:{1}", dbVersion, Application.ProductVersion);
                barStaticItemRegsiterType.Caption = string.Format("注册方式:{0}", EnumUtil.GetEnumDescription(CurrentClient.Instance.RegType));
            } else {
                barStaticItemRegsiterType.Caption = "注册方式:试用版";
                barStaticItemVersion.Caption = string.Format("试用版(剩余使用天数:{0}天) 当前版本:{1} 软件版本号:{2}", CurrentClient.Instance.ResidualDays, dbVersion, Application.ProductVersion);
            }
            //ShowDockPanel(false);
        }


        private void SetClickEvent() {
            //注册Ribbon所有BarItem的点击事件
            foreach (BarItem item in ribbon.Items) {
                item.ItemClick += new ItemClickEventHandler(ItemClick);
            }
        }

        public void BarItemClick(string tag) {
            foreach (BarItem item in ribbon.Items) {
                if (item.Tag != null && item.Tag.ToObjectString() == tag)
                    item.PerformClick();
            }
        }

        private void ItemClick(object sender, ItemClickEventArgs e) {
            //if(Program.frmViewVideoDevice!=null) Program.frmViewVideoDevice.Hide();
            if (e.Item.Tag == null || e.Item.Tag.ToObjectString().Length == 0) return;
            getTag(e.Item.Tag.ToString());
        }
        private void getTag(string t) {
            string tag = string.Empty;
            string fullName = string.Empty;
            string nameSpace = "YF.MWS.Win.View";
                returnResult = false;
                if (t.Split('|').Length == 2) {
                    fullName = nameSpace + "." + t.Split('|')[0];
                    tag = t.Split('|')[1];
                } else if (t.Split('|').Length == 3) {
                    fullName = nameSpace + "." + t.Split('|')[0];
                    tag = t.Split('|')[1];
                    parameter = t.Split('|')[2];
                    returnResult = true;
                } else {
                    fullName = nameSpace + "." +t;
                }
            HandleItemClick(tag,fullName);
        }
        public void LoadCar() {
            FrmWeight frmWeight = GetFrmWeight();
            if (frmWeight != null)
                frmWeight.LoadCar();
        }

        public void LoadMaterial() {
            FrmWeight frmWeight = GetFrmWeight();
            if (frmWeight != null)
                frmWeight.LoadMaterial();
        }

        public void LoadCustomer(CustomerType customerType) {
            FrmWeight frmWeight = GetFrmWeight();
            if (frmWeight != null)
                frmWeight.LoadCustomer(customerType);
        }

        private FrmWeight GetFrmWeight() {
            FrmWeight frmWeight = null;
            foreach (Form f in MdiChildren) {
                if (f.Tag != null && f.Tag.ToString() == "YF.MWS.Win.View.Weight.FrmWeight") {
                    frmWeight = (FrmWeight)f;
                }
            }
            return frmWeight;
        }

        private void HandleItemClick(string tag,string fullName,bool fromNavBarItem = false) {
            if (fullName == null || fullName == "") return;
            //如果要弹出对话框，则需要将对应BarItem的Tag设置为Dialog
            if (!string.IsNullOrEmpty(tag)) {
                if (fullName == "YF.MWS.Win.View.RefreshCache") {
                    string message = "确实要刷新系统缓存吗?";
                    if (MessageDxUtil.ShowYesNoAndTips(message) == DialogResult.Yes) {
                        CacheUtil.Refresh();
                    }
                    return;
                }
                if (tag == "Dialog") {
                    if (fullName == "YF.MWS.Win.View.Setting.FrmFont") {
                        fontDialog.Font = CfgUtil.GetFont();
                        if (fontDialog.ShowDialog() == DialogResult.OK) {
                            SaveFontCfg();
                            MessageDxUtil.ShowTips("如需应用新字体,请重新打开称重界面.");
                        }
                        return;
                    }
                    if (fullName == "YF.MWS.Win.View.Home.FrmHelp") {
                        YF.MWS.Util.Utility.Start(Path.Combine(Application.StartupPath, @"Config\仓舒智能称重系统说明书.pdf"));
                        return;
                    }
                    if (fullName == "YF.MWS.Win.View.Setting.FrmTransferCfg") {
                        YF.MWS.Win.View.Setting.FrmTransferCfg frmCfg = new YF.MWS.Win.View.Setting.FrmTransferCfg();
                        frmCfg.FrmMain = this;
                        frmCfg.ShowDialog();
                        return;
                    }
                    if (fullName == "YF.MWS.Win.View.Master.FrmDeviceSetting") {
                        string formName = "YF.MWS.Win.View.Weight.FrmWeight";
                        Form frm = FindChildForm(formName);
                        bool isContiue = true;
                        if (frm != null) {
                            isContiue = false;
                            string message = "打开称重仪设置界面需要关闭新建磅单界面,是否继续?";
                            if (MessageDxUtil.ShowYesNoAndTips(message) == System.Windows.Forms.DialogResult.Yes) {
                                RemoveChildForm(formName);
                                isContiue = true;
                            }
                        }
                        if (isContiue) {
                            FrmDeviceSetting frmDevice = new FrmDeviceSetting();
                            //frmDevice.DeviceNo = Convert.ToInt32(parameter);
                            frmDevice.ShowDialog();
                        }
                        return;
                    }
                    if (fullName == "YF.MWS.Win.View.Master.FrmSysConfig") {
                        string formName = "YF.MWS.Win.View.Weight.FrmWeight";
                        Form frm = FindChildForm(formName);
                        bool isContiue = true;
                        if (frm != null) {
                            isContiue = false;
                            string message = "打开软件设置界面需要关闭新建磅单界面,是否继续?";
                            if (MessageDxUtil.ShowYesNoAndTips(message) == System.Windows.Forms.DialogResult.Yes) {
                                RemoveChildForm(formName);
                                isContiue = true;
                            }
                        }
                        if (isContiue) {
                            Form f = FindChildForm(fullName);
                            if (f != null) {
                                f.Focus();
                            } else {
                                OpenForm(fullName);
                            }
                        }
                        return;
                    }
                    if (fullName == "YF.MWS.Win.View.Master.FrmVideoSetting") {
                        FrmVideoSetting frmVideo = new FrmVideoSetting();
                        frmVideo.CameraNo = Convert.ToInt32(parameter);
                        frmVideo.ShowDialog();
                        return;
                    }
                    if (fullName == "YF.MWS.Win.View.Master.FrmScreenCfg") {
                        int ledNo = parameter.ToInt();
                        FrmScreenCfg frmScreen = new FrmScreenCfg();
                        frmScreen.ShowDialog();
                        return;
                    }
                    Type type = Type.GetType(fullName);
                    Form form = (Form)type.Assembly.CreateInstance(fullName);
                    if (form == null)
                        return;
                    if (returnResult) {
                        form.ShowDialog();
                    } else {
                        form.ShowDialog();
                    }
                }
            } else {
                bool isContiue = true;
                if (fullName == "YF.MWS.Win.View.User.FrmChangeUser") {
                    string message = "您确定要退出,更换其他账户登录吗?";
                    if (MessageDxUtil.ShowYesNoAndTips(message) == System.Windows.Forms.DialogResult.Yes) {
                        string fileName = Application.ExecutablePath;
                        YF.MWS.Util.Utility.StartExe(fileName, "-changeUser");
                        Thread.Sleep(500);
                        Application.ExitThread();
                    }
                    return;
                }
                if (fullName == "YF.MWS.Win.View.Pay.FrmPayCfg") {
                    string formName = "YF.MWS.Win.View.Master.FrmSysConfig";
                    Form frm = FindChildForm(formName);
                    //frm.Icon = global::YF.MWS.Win.Properties.Resources.favicon;
                    if (frm != null) {
                        isContiue = false;
                        string message = "打开支付配置界面需要关闭软件设置界面,是否继续?";
                        if (MessageDxUtil.ShowYesNoAndTips(message) == System.Windows.Forms.DialogResult.Yes) {
                            RemoveChildForm(formName);
                            isContiue = true;
                        }
                    }
                    if (!isContiue)
                        return;
                }
                if (fullName == "YF.MWS.Win.View.Weight.FrmWeight") {
                    string formName = "YF.MWS.Win.View.Master.FrmSysConfig";
                    Form frm = FindChildForm(formName);
                    if (frm != null) {
                        isContiue = false;
                        string message = "打开新建磅单界面需要关闭软件设置界面,是否继续?";
                        if (MessageDxUtil.ShowYesNoAndTips(message) == System.Windows.Forms.DialogResult.Yes) {
                            RemoveChildForm(formName);
                            isContiue = true;
                        }
                    }
                }
                if (!isContiue)
                    return;
                Form f = FindChildForm(fullName);
                if (f != null) {
                    f.Focus();
                } else {
                    OpenForm(fullName);
                }
            }
        }

        private void OpenForm(string formName) {
            Type type = Type.GetType(formName);
            if (type == null) {
                return;
            }
            Form form = (Form)type.Assembly.CreateInstance(formName);
            if (form == null) {
                return;
            }
            if (formName.Contains("Weight.FrmWeight")) fWeight= form as FrmWeight;
            form.Icon = global::YF.MWS.Win.Properties.Resources.favicon;
            form.Tag = formName;
            form.MdiParent = this;
            form.Show();
        }
        /// <summary>
        /// 判断窗体是否已经打开
        /// </summary>
        private Form FindChildForm(string name) {
            Form child = null;
            foreach (Form f in MdiChildren) {
                if (f.Tag != null && f.Tag.ToString() == name) {
                    child = f;
                }
            }
            return child;
        }
        /// <summary>
        /// 关闭已打开的窗体
        /// </summary>

        private void RemoveChildForm(string name) {
            foreach (Form f in MdiChildren) {
                if (f.Tag != null && f.Tag.ToString() == name) {
                    f.Close();
                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e) {
            Program.frmMain = this;
            AllFormCfg frmCfg=CfgUtil.GetFormCfg();
            loginCfg = YF.Utility.Serialization.XmlUtil.Deserialize<LoginCfg>(loginCfgXml);
            if (cfg != null) {
                if (cfg.Launch != null) {
                    startAutoMaintain = cfg.Launch.StartAutoMaintain;
                    reStartTimeSpan = cfg.Launch.ReStartTimeSpan;
                    hours = cfg.Launch.Hours;
                    fixedTimes = cfg.Launch.FixedTimes;
                }
            }
            SetControl();
            SetDefaultPage(cfg);
            lstUserModule = UserCacher.GetModuleList(CurrentUser.Instance.Id);
            lstModule = UserCacher.GetModuleList();
            //SetBarItem();
            this.lbNote.Caption= AppSetting.GetValue("note");
            if (frmCfg.mainFrm.isMax != -1) {
                this.WindowState = frmCfg.mainFrm.isMax==1? FormWindowState.Maximized:FormWindowState.Normal;
                if (frmCfg.mainFrm.x < -100) frmCfg.mainFrm.x = 0;
                if (frmCfg.mainFrm.y < -100) frmCfg.mainFrm.y = 0;
                this.Location =new Point( frmCfg.mainFrm.x,frmCfg.mainFrm.y);
                this.Height = frmCfg.mainFrm.height;
                this.Width = frmCfg.mainFrm.width;
            }
        }
        /// <summary>
        /// 权限验证
        /// </summary>
        private void Authorization() {
            if (CurrentUser.Instance.IsAdministrator) return;
            foreach(RibbonPage page in ribbon.Pages) {
                if (page.Tag != null && page.Tag.ToString() != "") {
                    if (CurrentUser.Instance.Powers==null||!CurrentUser.Instance.Powers.Contains(page.Tag.ToString())) {
                        page.Visible = false;
                        continue;
                    }
                }
                foreach(RibbonPageGroup group in page.Groups) {
                    if (group.Tag != null && group.Tag.ToString() != "") {
                        if (CurrentUser.Instance.Powers == null || !CurrentUser.Instance.Powers.Contains(group.Tag.ToString())) {
                            group.Visible = false;
                            continue;
                        }
                    }
                }
            }
                    foreach (BarItem item in ribbon.Items) {
                        if (item != null && item.SearchTags != null && item.SearchTags != "") {
                        if (CurrentUser.Instance.Powers == null || !CurrentUser.Instance.Powers.Contains(item.SearchTags)) {
                        item.Visibility = BarItemVisibility.Never;
                            continue;
                        }
                        }
                    }
                    foreach(ToolStripItem item in toolStrip1.Items) {
                myToolButton btn=item as myToolButton;
                if (btn != null && btn.PowerNo != null && btn.PowerNo != "") {
                        if (CurrentUser.Instance.Powers == null || !CurrentUser.Instance.Powers.Contains(btn.PowerNo)) {
                        btn.Visible = false;
                        }
                }
            }
        }
        private void SetDefaultPage(SysCfg cfg) {
            if (cfg != null && cfg.Launch != null) {
                if (cfg.Launch.DefaultPage == DefaultPageType.Corp) {
                    FrmWelcome frmWelcome = new FrmWelcome();
                    frmWelcome.Tag = frmWelcome.GetType().FullName;
                    frmWelcome.MdiParent = this;
                    frmWelcome.Show();
                } else {
                }
            } else {
                /*FrmWelcome frmWelcome = new FrmWelcome();
                frmWelcome.Tag = frmWelcome.GetType().FullName;
                frmWelcome.MdiParent = this;
                frmWelcome.Show();*/
            }
            /*fWeight = new FrmWeight();
            fWeight.Tag = fWeight.GetType().FullName;
            fWeight.MdiParent = this;
            fWeight.Show();*/
        }

        private void SetControl() {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver) {
                btnItemDbBackup.Enabled = false;
                barItemRefreshCache.Enabled = false;
            }
            AuthCfg cfg = CfgUtil.GetAuth();
            if (cfg != null) {
                //navBarItemCarRecgonizer.Visible = cfg.CarNoRecognition;
                //navBarItemVideo.Visible = cfg.StartVideo;
                //navBarItemCard.Visible = cfg.ReadCard;
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e) {
            try {
                this.Dispose();
                this.Close();
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }

        private void barItemFontCfg_ItemClick(object sender, ItemClickEventArgs e) {
            fontDialog.Font = CfgUtil.GetFont();

            if (fontDialog.ShowDialog() == DialogResult.OK) {
                SaveFontCfg();
                MessageDxUtil.ShowTips("如需应用新字体,请重新打开称重界面.");
            }
        }

        private void SaveFontCfg() {
            string xmlPath = Path.Combine(Application.StartupPath, "FontCfg.xml");
            Font f = fontDialog.Font;
            FontCfg cfg = new FontCfg();
            cfg.FamilyName = f.FontFamily.Name;
            cfg.FontSize = f.Size;
            cfg.Style = f.Style;
            XmlUtil.Serialize<FontCfg>(cfg, xmlPath);
            CfgUtil.ResetFontCfg();
        }

        private void rgbTheme_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e) {
            if (loginCfg != null && e.Item.Tag != null && e.Item.Tag.ToObjectString().Length > 0) {
                loginCfg.SkinName = e.Item.Tag.ToString();
                XmlUtil.Serialize<LoginCfg>(loginCfg, loginCfgXml);
                CfgUtil.ResetLoginCfg();
            }
        }

        private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e) {
            changeUser();
        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            changeUser();
        }
        private void changeUser() {
            string message = "您确定要退出,更换其他账户登录吗?";
            if (MessageDxUtil.ShowYesNoAndTips(message) == System.Windows.Forms.DialogResult.Yes) {
                string fileName = Application.ExecutablePath;
                YF.MWS.Util.Utility.StartExe(fileName, "-changeUser");
                Thread.Sleep(500);
                Application.ExitThread();
            }
        }

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e) {
            FrmUpPwd frm = new FrmUpPwd();
            frm.ShowDialog();
        }

        private void btnItemNew_ItemClick(object sender, ItemClickEventArgs e) {

        }
        private void ShowForm(ToolStripButton control) {
            if (control == null || control.Tag == null) return;
            getTag(control.Tag.ToString());
        }
        private void toolStripButton3_Click(object sender, EventArgs e) {
            ToolStripButton control = sender as ToolStripButton;
            ShowForm(control);
        }

        private void toolStripButton6_Click(object sender, EventArgs e) {
            Process.Start("calc.exe");
        }

        private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e) {
            Application.Exit();
        }

        private void barCheckItem2_CheckedChanged(object sender, ItemClickEventArgs e) {
            CurrentClient.Instance.IsSimulateWeight = barCheckItem2.Checked;
        }

        private void barButtonItem65_ItemClick(object sender, ItemClickEventArgs e) {
            Process.Start("calc.exe");
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if(cfg.emailCfg.AutoSend) {
                DateTime last = cfg.emailCfg.LastSendTime;
                string path = "File/Data/"+DateTime.Now.ToString("yyyy年MM月dd日") + "明细报表.xls";
                if (cfg.emailCfg.SendType == "day") {
                    if (last.Date==DateTime.Now.Date&&cfg.emailCfg.SendTime.TimeOfDay>DateTime.Now.TimeOfDay) return;
                } else if (cfg.emailCfg.SendType == "hour") {
                    if (last.ToString("yyyyMMddHH") == DateTime.Now.ToString("yyyyMMddHH")) return;
                }
                DataTable dt = weightCacher.GetListTable(cfg.emailCfg.RereportType.ToEnum<DateTypeNew>());
                NPOIHelper.DataTableToExcel(dt, path, null);
                bool isOk= SendMessage.SendEmail(cfg.emailCfg,path);
                if(isOk) {
                    cfg.emailCfg.LastSendTime = DateTime.Now;
                    CfgUtil.SaveCfg(cfg);
                }
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e) {
            if (fWeight == null) return;
            SysCfg cfg = CfgUtil.GetCfg();
            fWeight.setDevice2(!cfg.Device2.StartDevice);
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            RemoveChildForm(new FrmWeight().GetType().FullName);
            fWeight = null;
        }

        private void toolStripButton5_Click(object sender, EventArgs e) {
            if (Program.frmViewVideoDevice.Visible) {
            Program.frmViewVideoDevice.Visible = false;
            } else {
            Program.frmViewVideoDevice.Visible = true;
            Program.frmViewVideoDevice.Activate();
            }
        }
        public void CapturePicture(string weightId, string waterMarkText, FileType fileType) {
            Program.frmViewVideoDevice.CapturePicture(weightId, waterMarkText, fileType);
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e) {
            if (Program.frmViewVideoDevice != null) {
                Program.frmViewVideoDevice.Close();
                Program.frmViewVideoDevice= null;
            }
            CfgUtil.allFormCfg.mainFrm.isMax = this.WindowState == FormWindowState.Maximized ? 1 : 0;
            CfgUtil.allFormCfg.mainFrm.x = this.Location.X;
            CfgUtil.allFormCfg.mainFrm.y = this.Location.Y;
            CfgUtil.allFormCfg.mainFrm.width = this.Width;
            CfgUtil.allFormCfg.mainFrm.height = this.Height;
            CfgUtil.SaveFormCfg(CfgUtil.allFormCfg);
        }

        private void ribbon_Click(object sender, EventArgs e) {

        }
    }
    public class myToolButton : ToolStripButton {
        /// <summary>
        /// 权限编码
        /// </summary>
        [Description("权限编码")]
        public string  PowerNo{get;set;}
    }
}