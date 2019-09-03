// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="FrmBase.cs">
//     Copyright by Huang Zhenghui(黄正辉) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub：https://github.com/kwwwvagaa/NetWinformControl
// gitee：https://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Forms
{
    /// <summary>
    /// Class FrmBase.
    /// Implements the <see cref="System.Windows.Forms.Form" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))]
    public partial class FrmBase : Form
    {
        /// <summary>
        /// Gets or sets the hot keys.
        /// </summary>
        /// <value>The hot keys.</value>
        [Description("定义的热键列表"), Category("自定义")]
        public Dictionary<int, string> HotKeys { get; set; }
        /// <summary>
        /// Delegate HotKeyEventHandler
        /// </summary>
        /// <param name="strHotKey">The string hot key.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public delegate bool HotKeyEventHandler(string strHotKey);
        /// <summary>
        /// 热键事件
        /// </summary>
        [Description("热键事件"), Category("自定义")]
        public event HotKeyEventHandler HotKeyDown;
        #region 字段属性

        /// <summary>
        /// 失去焦点关闭
        /// </summary>
        bool _isLoseFocusClose = false;
        /// <summary>
        /// 是否重绘边框样式
        /// </summary>
        private bool _redraw = false;
        /// <summary>
        /// 是否显示圆角
        /// </summary>
        private bool _isShowRegion = false;
        /// <summary>
        /// 边圆角大小
        /// </summary>
        private int _regionRadius = 10;
        /// <summary>
        /// 边框颜色
        /// </summary>
        private Color _borderStyleColor;
        /// <summary>
        /// 边框宽度
        /// </summary>
        private int _borderStyleSize;
        /// <summary>
        /// 边框样式
        /// </summary>
        private ButtonBorderStyle _borderStyleType;
        /// <summary>
        /// 是否显示模态
        /// </summary>
        private bool _isShowMaskDialog = false;
        /// <summary>
        /// 蒙版窗体
        /// </summary>
        /// <value><c>true</c> if this instance is show mask dialog; otherwise, <c>false</c>.</value>
        [Description("是否显示蒙版窗体")]
        public bool IsShowMaskDialog
        {
            get
            {
                return this._isShowMaskDialog;
            }
            set
            {
                this._isShowMaskDialog = value;
            }
        }
        /// <summary>
        /// 边框宽度
        /// </summary>
        /// <value>The size of the border style.</value>
        [Description("边框宽度")]
        public int BorderStyleSize
        {
            get
            {
                return this._borderStyleSize;
            }
            set
            {
                this._borderStyleSize = value;
            }
        }
        /// <summary>
        /// 边框颜色
        /// </summary>
        /// <value>The color of the border style.</value>
        [Description("边框颜色")]
        public Color BorderStyleColor
        {
            get
            {
                return this._borderStyleColor;
            }
            set
            {
                this._borderStyleColor = value;
            }
        }
        /// <summary>
        /// 边框样式
        /// </summary>
        /// <value>The type of the border style.</value>
        [Description("边框样式")]
        public ButtonBorderStyle BorderStyleType
        {
            get
            {
                return this._borderStyleType;
            }
            set
            {
                this._borderStyleType = value;
            }
        }
        /// <summary>
        /// 边框圆角
        /// </summary>
        /// <value>The region radius.</value>
        [Description("边框圆角")]
        public int RegionRadius
        {
            get
            {
                return this._regionRadius;
            }
            set
            {
                this._regionRadius = Math.Max(value, 1);
            }
        }
        /// <summary>
        /// 是否显示自定义绘制内容
        /// </summary>
        /// <value><c>true</c> if this instance is show region; otherwise, <c>false</c>.</value>
        [Description("是否显示自定义绘制内容")]
        public bool IsShowRegion
        {
            get
            {
                return this._isShowRegion;
            }
            set
            {
                this._isShowRegion = value;
            }
        }
        /// <summary>
        /// 是否显示重绘边框
        /// </summary>
        /// <value><c>true</c> if redraw; otherwise, <c>false</c>.</value>
        [Description("是否显示重绘边框")]
        public bool Redraw
        {
            get
            {
                return this._redraw;
            }
            set
            {
                this._redraw = value;
            }
        }

        /// <summary>
        /// The is full size
        /// </summary>
        private bool _isFullSize = true;
        /// <summary>
        /// 是否全屏
        /// </summary>
        /// <value><c>true</c> if this instance is full size; otherwise, <c>false</c>.</value>
        [Description("是否全屏")]
        public bool IsFullSize
        {
            get { return _isFullSize; }
            set { _isFullSize = value; }
        }
        /// <summary>
        /// 失去焦点自动关闭
        /// </summary>
        /// <value><c>true</c> if this instance is lose focus close; otherwise, <c>false</c>.</value>
        [Description("失去焦点自动关闭")]
        public bool IsLoseFocusClose
        {
            get
            {
                return this._isLoseFocusClose;
            }
            set
            {
                this._isLoseFocusClose = value;
            }
        }
        #endregion

        /// <summary>
        /// Gets a value indicating whether this instance is desing mode.
        /// </summary>
        /// <value><c>true</c> if this instance is desing mode; otherwise, <c>false</c>.</value>
        private bool IsDesingMode
        {
            get
            {
                bool ReturnFlag = false;
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                    ReturnFlag = true;
                else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                    ReturnFlag = true;
                return ReturnFlag;
            }
        }

        #region 初始化
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBase" /> class.
        /// </summary>
        public FrmBase()
        {
            InitializeComponent();
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            //base.HandleCreated += new EventHandler(this.FrmBase_HandleCreated);
            //base.HandleDestroyed += new EventHandler(this.FrmBase_HandleDestroyed);        
            this.KeyDown += FrmBase_KeyDown;
            this.FormClosing += FrmBase_FormClosing;
        }

        /// <summary>
        /// Handles the FormClosing event of the FrmBase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs" /> instance containing the event data.</param>
        void FrmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isLoseFocusClose)
            {
                MouseHook.OnMouseActivity -= hook_OnMouseActivity;
            }
        }


        /// <summary>
        /// Handles the Load event of the FrmBase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmBase_Load(object sender, EventArgs e)
        {
            if (!IsDesingMode)
            {
                if (_isFullSize)
                    SetFullSize();
            }
            if (_isLoseFocusClose)
            {
                MouseHook.OnMouseActivity += hook_OnMouseActivity;
            }
        }

        #endregion

        #region 方法区


        /// <summary>
        /// Handles the OnMouseActivity event of the hook control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        void hook_OnMouseActivity(object sender, MouseEventArgs e)
        {
            try
            {
                if (this._isLoseFocusClose && e.Clicks > 0)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left || e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        if (!this.IsDisposed)
                        {
                            if (!this.ClientRectangle.Contains(this.PointToClient(e.Location)))
                            {
                                base.Close();
                            }
                        }
                    }
                }
            }
            catch { }
        }


        /// <summary>
        /// 全屏
        /// </summary>
        public void SetFullSize()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        /// <summary>
        /// Does the escape.
        /// </summary>
        protected virtual void DoEsc()
        {
            base.Close();
        }

        /// <summary>
        /// Does the enter.
        /// </summary>
        protected virtual void DoEnter()
        {
        }

        /// <summary>
        /// 设置重绘区域
        /// </summary>
        public void SetWindowRegion()
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(-1, -1, base.Width + 1, base.Height);
            path = this.GetRoundedRectPath(rect, this._regionRadius);
            base.Region = new Region(path);
        }
        /// <summary>
        /// 获取重绘区域
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            Rectangle rect2 = new Rectangle(rect.Location, new Size(radius, radius));
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(rect2, 180f, 90f);
            rect2.X = rect.Right - radius;
            graphicsPath.AddArc(rect2, 270f, 90f);
            rect2.Y = rect.Bottom - radius;
            rect2.Width += 1;
            rect2.Height += 1;
            graphicsPath.AddArc(rect2, 360f, 90f);
            rect2.X = rect.Left;
            graphicsPath.AddArc(rect2, 90f, 90f);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        /// <summary>
        /// 将窗体显示为具有指定所有者的模式对话框。
        /// </summary>
        /// <param name="owner">任何实现 <see cref="T:System.Windows.Forms.IWin32Window" />（表示将拥有模式对话框的顶级窗口）的对象。</param>
        /// <returns><see cref="T:System.Windows.Forms.DialogResult" /> 值之一。</returns>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public new DialogResult ShowDialog(IWin32Window owner)
        {
            try
            {
                if (this._isShowMaskDialog && owner != null)
                {
                    var frmOwner = (Control)owner;
                    FrmTransparent _frmTransparent = new FrmTransparent();
                    _frmTransparent.Width = frmOwner.Width;
                    _frmTransparent.Height = frmOwner.Height;
                    Point location = frmOwner.PointToScreen(new Point(0, 0));
                    _frmTransparent.Location = location;
                    _frmTransparent.frmchild = this;
                    _frmTransparent.IsShowMaskDialog = false;
                    return _frmTransparent.ShowDialog(owner);
                }
                else
                {
                    return base.ShowDialog(owner);
                }
            }
            catch (NullReferenceException)
            {
                return System.Windows.Forms.DialogResult.None;
            }
        }

        /// <summary>
        /// 将窗体显示为模式对话框，并将当前活动窗口设置为它的所有者。
        /// </summary>
        /// <returns><see cref="T:System.Windows.Forms.DialogResult" /> 值之一。</returns>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public new DialogResult ShowDialog()
        {
            return base.ShowDialog();
        }
        #endregion

        #region 事件区


        /// <summary>
        /// 关闭时发生
        /// </summary>
        /// <param name="e">一个包含事件数据的 <see cref="T:System.EventArgs" />。</param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (base.Owner != null && base.Owner is FrmTransparent)
            {
                (base.Owner as FrmTransparent).Close();
            }
        }

        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="msg">通过引用传递的 <see cref="T:System.Windows.Forms.Message" />，它表示要处理的 Win32 消息。</param>
        /// <param name="keyData"><see cref="T:System.Windows.Forms.Keys" /> 值之一，它表示要处理的键。</param>
        /// <returns>如果控件处理并使用击键，则为 true；否则为 false，以允许进一步处理。</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int num = 256;
            int num2 = 260;
            bool result;
            if (msg.Msg == num | msg.Msg == num2)
            {
                if (keyData == (Keys)262259)
                {
                    result = true;
                    return result;
                }
                if (keyData != Keys.Enter)
                {
                    if (keyData == Keys.Escape)
                    {
                        this.DoEsc();
                    }
                }
                else
                {
                    this.DoEnter();
                }
            }
            result = false;
            if (result)
                return result;
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Handles the KeyDown event of the FrmBase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        protected void FrmBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (HotKeyDown != null && HotKeys != null)
            {
                bool blnCtrl = false;
                bool blnAlt = false;
                bool blnShift = false;
                if (e.Control)
                    blnCtrl = true;
                if (e.Alt)
                    blnAlt = true;
                if (e.Shift)
                    blnShift = true;
                if (HotKeys.ContainsKey(e.KeyValue))
                {
                    string strKey = string.Empty;
                    if (blnCtrl)
                    {
                        strKey += "Ctrl+";
                    }
                    if (blnAlt)
                    {
                        strKey += "Alt+";
                    }
                    if (blnShift)
                    {
                        strKey += "Shift+";
                    }
                    strKey += HotKeys[e.KeyValue];

                    if (HotKeyDown(strKey))
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                }
            }
        }

        /// <summary>
        /// 重绘事件
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this._isShowRegion)
            {
                this.SetWindowRegion();
            }
            base.OnPaint(e);
            if (this._redraw)
            {
                ControlPaint.DrawBorder(e.Graphics, base.ClientRectangle, this._borderStyleColor, this._borderStyleSize, this._borderStyleType, this._borderStyleColor, this._borderStyleSize, this._borderStyleType, this._borderStyleColor, this._borderStyleSize, this._borderStyleType, this._borderStyleColor, this._borderStyleSize, this._borderStyleType);
            }
        }
        #endregion


        #region 窗体拖动    English:Form drag
        /// <summary>
        /// Releases the capture.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="wMsg">The w MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// The wm syscommand
        /// </summary>
        public const int WM_SYSCOMMAND = 0x0112;
        /// <summary>
        /// The sc move
        /// </summary>
        public const int SC_MOVE = 0xF010;
        /// <summary>
        /// The htcaption
        /// </summary>
        public const int HTCAPTION = 0x0002;

        /// <summary>
        /// 通过Windows的API控制窗体的拖动
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        public static void MouseDown(IntPtr hwnd)
        {
            ReleaseCapture();
            SendMessage(hwnd, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        #endregion

        /// <summary>
        /// 在构造函数中调用设置窗体移动
        /// </summary>
        /// <param name="cs">The cs.</param>
        protected void InitFormMove(params Control[] cs)
        {
            foreach (Control c in cs)
            {
                if (c != null && !c.IsDisposed)
                    c.MouseDown += c_MouseDown;
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the c control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        void c_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown(this.Handle);
        }
    }
}
