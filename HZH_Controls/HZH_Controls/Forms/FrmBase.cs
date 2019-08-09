using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Forms
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))]
    public partial class FrmBase : Form
    {
        [Description("定义的热键列表"), Category("自定义")]
        public Dictionary<int, string> HotKeys { get; set; }
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
        //private FrmTransparent _frmTransparent = null;
        /// <summary>
        /// 是否显示蒙版窗体
        /// </summary>
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
        [Description("边框圆角")]
        public int RegionRadius
        {
            get
            {
                return this._regionRadius;
            }
            set
            {
                this._regionRadius = value;
            }
        }
        /// <summary>
        /// 是否显示自定义绘制内容
        /// </summary>
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

        private bool _isFullSize = true;
        /// <summary>
        /// 是否全屏
        /// </summary>
        [Description("是否全屏")]
        public bool IsFullSize
        {
            get { return _isFullSize; }
            set { _isFullSize = value; }
        }
        /// <summary>
        /// 失去焦点自动关闭
        /// </summary>
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

        void FrmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isLoseFocusClose)
            {
                MouseHook.OnMouseActivity -= hook_OnMouseActivity;
            }
        }


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
        protected virtual void DoEsc()
        {
            base.Close();
        }

        protected virtual void DoEnter()
        {
        }
        ///// <summary>
        ///// 隐藏遮罩层
        ///// </summary>
        //public void HideMaskDialog()
        //{
        //    if (this._frmTransparent != null && !this._frmTransparent.IsDisposed)
        //    {
        //        this._frmTransparent.Hide();
        //    }
        //}
        ///// <summary>
        ///// 显示遮罩层
        ///// </summary>
        ///// <param name="frm"></param>
        //public void ShowMaskDialog(FrmBase frm)
        //{
        //    if (this._frmTransparent == null || this._frmTransparent.IsDisposed)
        //    {
        //        this._frmTransparent = new FrmTransparent();
        //    }
        //    this._frmTransparent.Width = base.Width;
        //    this._frmTransparent.Height = base.Height;
        //    Point location = base.PointToScreen(new Point(0, 0));
        //    this._frmTransparent.Location = location;
        //    this._frmTransparent.frmchild = frm;
        //    if (!this._frmTransparent.Visible)
        //    {
        //        this._frmTransparent.ShowDialog(this);
        //    }
        //}
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
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
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

        public new DialogResult ShowDialog()
        {
            return base.ShowDialog();
        }
        #endregion

        #region 事件区

        /// <summary>
        /// 加载时发生
        /// </summary>
        /// <param name="e"></param>
        //protected override void OnLoad(EventArgs e)
        //{
        //    if (this._isShowMaskDialog && base.Owner != null)
        //    {
        //        FrmBase frmBase = base.Owner as FrmBase;
        //        if (frmBase != null)
        //        {
        //            frmBase.ShowMaskDialog(this);
        //        }
        //    }
        //    base.Focus();
        //    base.OnLoad(e);
        //}
        /// <summary>
        /// 关闭时发生
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (base.Owner != null && base.Owner is FrmTransparent)
            {
                (base.Owner as FrmTransparent).Close();
            }
        }
        ///// <summary>
        ///// 处理消息过滤
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void FrmBase_HandleDestroyed(object sender, EventArgs e)
        //{

        //}
        ///// <summary>
        ///// 处理消息过滤
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void FrmBase_HandleCreated(object sender, EventArgs e)
        //{
        //    if (this._isLoseFocusClose)
        //    {
        //        m_hook.Start();
        //    }
        //}
        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
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
        /// <param name="e"></param>
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

    }
}
