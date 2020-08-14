using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HZH_Controls;
using HZH_Controls.Controls;
using HZH_Controls.Forms;

namespace Test
{
    public partial class FrmMain : FrmWithTitle
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.FreezeControl(this, true);
                this.tvMenu.Nodes.Add("关于授权");
                TreeNode tnForm = new TreeNode("  窗体");
                tnForm.Nodes.Add("提示窗体");
                tnForm.Nodes.Add("多输入窗体");
                tnForm.Nodes.Add("气泡提示窗体");
                tnForm.Nodes.Add("有返回的窗体");
                tnForm.Nodes.Add("等待窗体");
                tnForm.Nodes.Add("仅有标题的窗体");
                tnForm.Nodes.Add("确定取消窗体1");
                tnForm.Nodes.Add("确定取消窗体2");
                tnForm.Nodes.Add("资源加载窗体");
                this.tvMenu.Nodes.Add(tnForm);

                TreeNode tnControl = new TreeNode("  控件");
                tnControl.Nodes.Add("表单控件");
                tnControl.Nodes.Add("按钮");
                tnControl.Nodes.Add("选项卡");
                tnControl.Nodes.Add("树");
                tnControl.Nodes.Add("列表");
                tnControl.Nodes.Add("平铺列表");
                tnControl.Nodes.Add("垂直导航");
                tnControl.Nodes.Add("横向列表");
                tnControl.Nodes.Add("分页控件");
                tnControl.Nodes.Add("表格");
                tnControl.Nodes.Add("表格-自定义单元格");
                tnControl.Nodes.Add("树表格");
                tnControl.Nodes.Add("进度条");
                tnControl.Nodes.Add("步骤控件");
                tnControl.Nodes.Add("面包屑导航");
                tnControl.Nodes.Add("文字提示");
                tnControl.Nodes.Add("滚动文字");
                tnControl.Nodes.Add("滑块");
                tnControl.Nodes.Add("水波");
                tnControl.Nodes.Add("有标题的面板");
                tnControl.Nodes.Add("图标");
                tnControl.Nodes.Add("滚动条");
                tnControl.Nodes.Add("控件水印");
                tnControl.Nodes.Add("表单验证");
                tnControl.Nodes.Add("图片采样控件");
                tnControl.Nodes.Add("倒影");
                tnControl.Nodes.Add("内置颜色");
                tnControl.Nodes.Add("导航菜单");
                tnControl.Nodes.Add("扩展导航菜单");
                tnControl.Nodes.Add("类Office导航菜单");
                tnControl.Nodes.Add("分割线标签");
                tnControl.Nodes.Add("时间轴");
                tnControl.Nodes.Add("穿梭框");
                tnControl.Nodes.Add("引用区块");
                tnControl.Nodes.Add("右键菜单");
                tnControl.Nodes.Add("日历备忘录");
                this.tvMenu.Nodes.Add(tnControl);

                TreeNode tnCharts = new TreeNode("  图表");
                tnCharts.Nodes.Add("组织结构图");
                tnCharts.Nodes.Add("滚动图表");
                tnCharts.Nodes.Add("雷达图");
                tnCharts.Nodes.Add("金字塔图");
                tnCharts.Nodes.Add("Live Charts");
                this.tvMenu.Nodes.Add(tnCharts);

                TreeNode tnFactory = new TreeNode("  工业控件");
                tnFactory.Nodes.Add("LED文字");
                tnFactory.Nodes.Add("仪表");
                tnFactory.Nodes.Add("管道");
                tnFactory.Nodes.Add("阀门");
                tnFactory.Nodes.Add("鼓风机");
                tnFactory.Nodes.Add("传送带");
                tnFactory.Nodes.Add("警示灯");
                tnFactory.Nodes.Add("箭头");
                tnFactory.Nodes.Add("温度计");
                tnFactory.Nodes.Add("转子");
                tnFactory.Nodes.Add("多通道转盘");
                tnFactory.Nodes.Add("椭圆转盘");
                tnFactory.Nodes.Add("转盘");
                tnFactory.Nodes.Add("注射器");
                this.tvMenu.Nodes.Add(tnFactory);
                AddControl(new UCShouQuan());
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }

        private void tvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            panControl.Controls.Clear();
            string strName = e.Node.Text.Trim();
            this.Title = "HZHControls控件库DEMO--" + strName;
            switch (strName)
            {
                case "关于授权":
                    AddControl(new UCShouQuan());
                    break;
                #region 窗体    English:forms
                case "提示窗体":
                    if (FrmDialog.ShowDialog(this, "是否再显示一个没有取消按钮的提示框？", "模式窗体测试", true) == System.Windows.Forms.DialogResult.OK)
                    {
                        FrmDialog.ShowDialog(this, "这是一个没有取消按钮的提示框", "模式窗体测试");
                    }
                    break;
                case "多输入窗体":
                    FrmInputs frm = new FrmInputs("动态多输入窗体测试",
                        new string[] { "姓名", "电话", "身份证号", "住址" },
                        new Dictionary<string, HZH_Controls.TextInputType>() { { "电话", HZH_Controls.TextInputType.Regex }, { "身份证号", HZH_Controls.TextInputType.Regex } },
                        new Dictionary<string, string>() { { "电话", "^1\\d{0,10}$" }, { "身份证号", "^\\d{0,18}$" } },
                        new Dictionary<string, KeyBoardType>() { { "电话", KeyBoardType.UCKeyBorderNum }, { "身份证号", KeyBoardType.UCKeyBorderNum } },
                        new List<string>() { "姓名", "电话", "身份证号" });
                    frm.ShowDialog(this);
                    break;
                case "气泡提示窗体":
                    FrmTips.ShowTipsError(this, "Error提示信息");
                    FrmTips.ShowTipsInfo(this, "Info提示信息");
                    FrmTips.ShowTipsSuccess(this, "Success提示信息");
                    FrmTips.ShowTipsWarning(this, "Warning提示信息");
                    FrmTips.ShowTips(this, "自定义提示信息", 2000, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, new Size(300, 50), TipsState.Success);
                    break;
                case "有返回的窗体":
                    new FrmTestFrmBack().ShowDialog(this);
                    break;
                case "等待窗体":
                    ControlHelper.ThreadRunExt(this, () =>
                    {
                        Thread.Sleep(5000);
                        ControlHelper.ThreadInvokerControl(this, () =>
                        {
                            FrmTips.ShowTipsSuccess(this, "FrmWaiting测试");
                        });
                    }, null, this);
                    break;
                case "仅有标题的窗体":
                    new FrmWithTitleTest().ShowDialog(this);
                    break;
                case "确定取消窗体1":
                    new FrmOKCancel1Test().ShowDialog(this);
                    break;
                case "确定取消窗体2":
                    new FrmOKCancel2Test().ShowDialog(this);
                    break;
                case "资源加载窗体":
                    FrmTestLoading frmLoading = new FrmTestLoading();
                    frmLoading.BackgroundWorkAction = delegate()
                    {
                        try
                        {
                            frmLoading.CurrentMsg = new KeyValuePair<int, string>(1, "正在初始化配置...");
                            Thread.Sleep(1000);
                            frmLoading.CurrentMsg = new KeyValuePair<int, string>(10, "正在加载第一个资源...");
                            Thread.Sleep(1000);
                            frmLoading.CurrentMsg = new KeyValuePair<int, string>(20, "正在加载第二个资源...");
                            Thread.Sleep(1000);
                            frmLoading.CurrentMsg = new KeyValuePair<int, string>(30, "正在加载第三个资源...");
                            Thread.Sleep(1000);
                            frmLoading.CurrentMsg = new KeyValuePair<int, string>(40, "正在加载第四个资源...");
                            Thread.Sleep(1000);
                            frmLoading.CurrentMsg = new KeyValuePair<int, string>(50, "正在加载第五个资源...");
                            Thread.Sleep(1000);
                            frmLoading.CurrentMsg = new KeyValuePair<int, string>(60, "正在加载第六个资源...");
                            Thread.Sleep(1000);
                            frmLoading.CurrentMsg = new KeyValuePair<int, string>(70, "正在加载第七个资源...");
                            Thread.Sleep(1000);
                            frmLoading.CurrentMsg = new KeyValuePair<int, string>(80, "正在加载第八个资源...");
                            Thread.Sleep(1000);
                            frmLoading.CurrentMsg = new KeyValuePair<int, string>(90, "正在加载第九个资源...");
                            Thread.Sleep(1000);
                            frmLoading.CurrentMsg = new KeyValuePair<int, string>(1000, "数据加载完成...");
                            Thread.Sleep(1000);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("加载资源时出现错误");
                        }
                    };
                    frmLoading.ShowDialog();
                    break;
                #endregion

                #region 控件    English:control
                case "表单控件":
                    AddControl(new UC.UCTestForms());
                    break;
                case "按钮":
                    AddControl(new UC.UCTestBtns());
                    break;
                case "选项卡":
                    AddControl(new UC.UCTestTab());
                    break;
                case "树":
                    AddControl(new UC.UCTestTreeview() { Dock = DockStyle.Left });
                    break;
                case "列表":
                    AddControl(new UC.UCTestList() { Dock = DockStyle.Left });
                    break;
                case "平铺列表":
                    AddControl(new UC.UCTestListView() { Dock = DockStyle.Fill });
                    break;
                case "垂直导航":
                    AddControl(new UC.UCTestMenu() { Dock = DockStyle.Left });
                    break;
                case "横向列表":
                    AddControl(new UC.UCTestHorizontalList());
                    break;
                case "分页控件":
                    AddControl(new UC.UCTestPage());
                    break;
                case "表格":
                    AddControl(new UC.UCTestGridTable());
                    break;
                case "表格-自定义单元格":
                    AddControl(new UC.UCTestGridTableCustom());
                    break;
                case "树表格":
                    AddControl(new UC.UCTestTreeGridTable());
                    break;
                case "进度条":
                    AddControl(new UC.UCTestProcess() { Dock = DockStyle.Fill });
                    break;
                case "步骤控件":
                    AddControl(new UC.UCTestStep() { Dock = DockStyle.Fill });
                    break;
                case "面包屑导航":
                    AddControl(new UC.UCTestNavigation() { Dock = DockStyle.Fill });
                    break;
                case "文字提示":
                    AddControl(new UC.UCTestTips() { Dock = DockStyle.Fill });
                    break;
                case "滚动文字":
                    AddControl(new UC.UCTestRollText() { Dock = DockStyle.Fill });
                    break;
                case "滑块":
                    AddControl(new UC.UCTestTrackbar() { Dock = DockStyle.Fill });
                    break;
                case "水波":
                    AddControl(new UC.UCTestWave() { Dock = DockStyle.Fill });
                    break;
                case "有标题的面板":
                    AddControl(new UC.UCTestPanelTitle() { Dock = DockStyle.Left });
                    break;
                case "图标":
                    AddControl(new UC.UCTestIcon() { Dock = DockStyle.Fill });
                    break;
                case "滚动条":
                    AddControl(new UC.UCTestScrollbar() { Dock = DockStyle.Fill });
                    break;
                case "控件水印":
                    AddControl(new UC.UCTestGraphicalOverlay());
                    break;
                case "表单验证":
                    AddControl(new UC.UCTestVerification() { Dock = DockStyle.Fill });
                    break;
                case "图片采样控件":
                    AddControl(new UC.UCTestSampling());
                    break;
                case "倒影":
                    AddControl(new UC.UCTestShadow());
                    break;
                case "内置颜色":
                    AddControl(new UC.UCTestColors());
                    break;
                case "导航菜单":
                    AddControl(new UC.UCTestNavigationMenu());
                    break;
                case "扩展导航菜单":
                    AddControl(new UC.UCTestNavigationMenuExt());
                    break;
                case "类Office导航菜单":
                    AddControl(new UC.UCTestNavigationMenuOffice());
                    break;
                case "分割线标签":
                    AddControl(new UC.UCTestSplitLabel());
                    break;
                case "时间轴":
                    AddControl(new UC.UCTestTimeLine() { Dock = DockStyle.Fill });
                    break;
                case "穿梭框":
                    AddControl(new UC.UCTestTransfer());
                    break;
                case "引用区块":
                    AddControl(new UC.UCTestPanelQuote());
                    break;
                case "右键菜单":
                    AddControl(new UC.UCTestContextMenu());
                    break;
                case "日历备忘录":
                    AddControl(new UC.UCTestCalendarNotes());
                    break;
                #endregion

                #region 图表    English:Chart
                case "组织结构图":
                    AddControl(new UC.UCTestMindMapping() { Dock = DockStyle.Fill });
                    break;
                case "滚动图表":
                    AddControl(new UC.UCTestWaveChart() { Dock = DockStyle.Fill });
                    break;
                case "雷达图":
                    AddControl(new UC.UCTestRadarChart() { Dock = DockStyle.Fill });
                    break;
                case "金字塔图":
                    AddControl(new UC.UCTestFunnelChart());
                    break;
                case "Live Charts":
                    AddControl(new UC.UCTestLiveCharts());
                    break;
                #endregion

                #region 工业    English:Industry
                case "LED文字":
                    AddControl(new UC.UCTestLED() { Dock = DockStyle.Fill });
                    break;
                case "仪表":
                    AddControl(new UC.UCTestMeter());
                    break;
                case "管道":
                    AddControl(new UC.UCTestConduit());
                    break;
                case "阀门":
                    AddControl(new UC.UCTestValve());
                    break;
                case "鼓风机":
                    AddControl(new UC.UCTestBlower());
                    break;
                case "传送带":
                    AddControl(new UC.UCTestConveyor());
                    break;
                case "警示灯":
                    AddControl(new UC.UCTestSignalLamp());
                    break;
                case "箭头":
                    AddControl(new UC.UCTestArrow());
                    break;
                case "温度计":
                    AddControl(new UC.UCTestThermometer());
                    break;
                case "转子":
                    AddControl(new UC.UCTestRotor());
                    break;
                case "多通道转盘":
                    AddControl(new UC.UCTestDialAisle());
                    break;
                case "椭圆转盘":
                    AddControl(new UC.UCTestUCEllipseDialAisle());
                    break;
                case "转盘":
                    AddControl(new UC.UCTestTurntable());
                    break;
                case "注射器":
                    AddControl(new UC.UCTestSyringe());
                    break;
                #endregion
            }
        }

        private void AddControl(Control c)
        {
            //c.Dock = DockStyle.Fill;
            this.panControl.Controls.Add(c);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.hzhcontrols.com");
        }

    }
}
