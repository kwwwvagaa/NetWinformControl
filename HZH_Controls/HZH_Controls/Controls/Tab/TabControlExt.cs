// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-17-2019
//
// ***********************************************************************
// <copyright file="TabControlExt.cs">
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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class TabControlExt.
    /// Implements the <see cref="System.Windows.Forms.TabControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TabControl" />
    public class TabControlExt : TabControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabControlExt" /> class.
        /// </summary>
        public TabControlExt()
            : base()
        {
            SetStyles();
            //this.Multiline = true;
            this.ItemSize = new Size(this.ItemSize.Width, 50);
        }
        /// <summary>
        /// Sets the styles.
        /// </summary>
        private void SetStyles()
        {
            base.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
            base.UpdateStyles();
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is show close BTN.
        /// </summary>
        /// <value><c>true</c> if this instance is show close BTN; otherwise, <c>false</c>.</value>
        [Description("是否显示关闭按钮"), Category("自定义")]
        public bool IsShowCloseBtn { get; set; }

        [Description("不可关闭的标签序号列表，下标0"), Category("自定义")]
        public int[] UncloseTabIndexs { get; set; }
        /// <summary>
        /// The back color
        /// </summary>
        private Color _backColor = Color.White;
        /// <summary>
        /// 此成员对于此控件无意义。
        /// </summary>
        /// <value>The color of the back.</value>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(typeof(Color), "White")]
        public override Color BackColor
        {
            get { return _backColor; }
            set
            {
                _backColor = value;
                base.Invalidate(true);
            }
        }

        private Color closeBtnColor = Color.FromArgb(255, 85, 51);

        [Description("关闭按钮颜色")]
        public Color CloseBtnColor
        {
            get { return closeBtnColor; }
            set { closeBtnColor = value; }
        }

        /// <summary>
        /// The border color
        /// </summary>
        private Color _borderColor = Color.FromArgb(232, 232, 232);
        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [DefaultValue(typeof(Color), "232, 232, 232")]
        [Description("TabContorl边框色")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                base.Invalidate(true);
            }
        }

        /// <summary>
        /// The head selected back color
        /// </summary>
        private Color _headSelectedBackColor = Color.FromArgb(255, 85, 51);
        /// <summary>
        /// Gets or sets the color of the head selected back.
        /// </summary>
        /// <value>The color of the head selected back.</value>
        [DefaultValue(typeof(Color), "255, 85, 51")]
        [Description("TabPage头部选中后的背景颜色")]
        public Color HeadSelectedBackColor
        {
            get { return _headSelectedBackColor; }
            set { _headSelectedBackColor = value; }
        }

        /// <summary>
        /// The head selected border color
        /// </summary>
        private Color _headSelectedBorderColor = Color.FromArgb(232, 232, 232);
        /// <summary>
        /// Gets or sets the color of the head selected border.
        /// </summary>
        /// <value>The color of the head selected border.</value>
        [DefaultValue(typeof(Color), "232, 232, 232")]
        [Description("TabPage头部选中后的边框颜色")]
        public Color HeadSelectedBorderColor
        {
            get { return _headSelectedBorderColor; }
            set { _headSelectedBorderColor = value; }
        }

        /// <summary>
        /// The header back color
        /// </summary>
        private Color _headerBackColor = Color.White;
        /// <summary>
        /// Gets or sets the color of the header back.
        /// </summary>
        /// <value>The color of the header back.</value>
        [DefaultValue(typeof(Color), "White")]
        [Description("TabPage头部默认背景颜色")]
        public Color HeaderBackColor
        {
            get { return _headerBackColor; }
            set { _headerBackColor = value; }
        }

        /// <summary>
        /// 绘制控件的背景。
        /// </summary>
        /// <param name="pevent">包含有关要绘制的控件的信息的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (this.DesignMode == true)
            {
                LinearGradientBrush backBrush = new LinearGradientBrush(
                            this.Bounds,
                            SystemColors.ControlLightLight,
                            SystemColors.ControlLight,
                            LinearGradientMode.Vertical);
                pevent.Graphics.FillRectangle(backBrush, this.Bounds);
                backBrush.Dispose();
            }
            else
            {
                this.PaintTransparentBackground(pevent.Graphics, this.ClientRectangle);
            }
        }

        /// <summary>
        /// TabContorl 背景色设置
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="clipRect">The clip rect.</param>
        protected void PaintTransparentBackground(Graphics g, Rectangle clipRect)
        {
            if ((this.Parent != null))
            {
                clipRect.Offset(this.Location);
                PaintEventArgs e = new PaintEventArgs(g, clipRect);
                GraphicsState state = g.Save();
                g.SmoothingMode = SmoothingMode.HighSpeed;
                try
                {
                    g.TranslateTransform((float)-this.Location.X, (float)-this.Location.Y);
                    this.InvokePaintBackground(this.Parent, e);
                    this.InvokePaint(this.Parent, e);
                }
                finally
                {
                    g.Restore(state);
                    clipRect.Offset(-this.Location.X, -this.Location.Y);
                    //新加片段,待测试
                    using (SolidBrush brush = new SolidBrush(_backColor))
                    {
                        clipRect.Inflate(1, 1);
                        g.FillRectangle(brush, clipRect);
                    }
                }
            }
            else
            {
                System.Drawing.Drawing2D.LinearGradientBrush backBrush = new System.Drawing.Drawing2D.LinearGradientBrush(this.Bounds, SystemColors.ControlLightLight, SystemColors.ControlLight, System.Drawing.Drawing2D.LinearGradientMode.Vertical);
                g.FillRectangle(backBrush, this.Bounds);
                backBrush.Dispose();
            }
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Paint the Background 
            base.OnPaint(e);
            this.PaintTransparentBackground(e.Graphics, this.ClientRectangle);
            this.PaintAllTheTabs(e);
            this.PaintTheTabPageBorder(e);
            this.PaintTheSelectedTab(e);
        }

        /// <summary>
        /// Paints all the tabs.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs" /> instance containing the event data.</param>
        private void PaintAllTheTabs(System.Windows.Forms.PaintEventArgs e)
        {
            if (this.TabCount > 0)
            {
                for (int index = 0; index < this.TabCount; index++)
                {
                    this.PaintTab(e, index);
                }
            }
        }

        /// <summary>
        /// Paints the tab.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs" /> instance containing the event data.</param>
        /// <param name="index">The index.</param>
        private void PaintTab(System.Windows.Forms.PaintEventArgs e, int index)
        {
            GraphicsPath path = this.GetTabPath(index);
            this.PaintTabBackground(e.Graphics, index, path);
            this.PaintTabBorder(e.Graphics, index, path);
            this.PaintTabText(e.Graphics, index);
            this.PaintTabImage(e.Graphics, index);
            if (IsShowCloseBtn)
            {
                if (UncloseTabIndexs != null)
                {
                    if (UncloseTabIndexs.ToList().Contains(index))
                        return;
                }
                Rectangle rect = this.GetTabRect(index);
                e.Graphics.DrawLine(new Pen(closeBtnColor, 1F), new Point(rect.Right - 15, rect.Top + 5), new Point(rect.Right - 5, rect.Top + 15));
                e.Graphics.DrawLine(new Pen(closeBtnColor, 1F), new Point(rect.Right - 5, rect.Top + 5), new Point(rect.Right - 15, rect.Top + 15));
            }
        }

        /// <summary>
        /// 设置选项卡头部颜色
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <param name="index">The index.</param>
        /// <param name="path">The path.</param>
        private void PaintTabBackground(System.Drawing.Graphics graph, int index, System.Drawing.Drawing2D.GraphicsPath path)
        {
            Rectangle rect = this.GetTabRect(index);
            if (rect.Width == 0 || rect.Height == 0) return;
            System.Drawing.Brush buttonBrush = new System.Drawing.Drawing2D.LinearGradientBrush(rect, _headerBackColor, _headerBackColor, LinearGradientMode.Vertical);  //非选中时候的 TabPage 页头部背景色
            graph.FillPath(buttonBrush, path);
            //if (index == this.SelectedIndex)
            //{
            //    //buttonBrush = new System.Drawing.SolidBrush(_headSelectedBackColor);
            //    graph.DrawLine(new Pen(_headerBackColor), rect.Right+2, rect.Bottom, rect.Left + 1, rect.Bottom);
            //}
            buttonBrush.Dispose();
        }

        /// <summary>
        /// 设置选项卡头部边框色
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <param name="index">The index.</param>
        /// <param name="path">The path.</param>
        private void PaintTabBorder(System.Drawing.Graphics graph, int index, System.Drawing.Drawing2D.GraphicsPath path)
        {
            Pen borderPen = new Pen(_borderColor);// TabPage 非选中时候的 TabPage 头部边框色
            if (index == this.SelectedIndex)
            {
                borderPen = new Pen(_headSelectedBorderColor); // TabPage 选中后的 TabPage 头部边框色
            }
            graph.DrawPath(borderPen, path);
            borderPen.Dispose();
        }

        /// <summary>
        /// Paints the tab image.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="index">The index.</param>
        private void PaintTabImage(System.Drawing.Graphics g, int index)
        {
            Image tabImage = null;
            if (this.TabPages[index].ImageIndex > -1 && this.ImageList != null)
            {
                tabImage = this.ImageList.Images[this.TabPages[index].ImageIndex];
            }
            else if (this.TabPages[index].ImageKey.Trim().Length > 0 && this.ImageList != null)
            {
                tabImage = this.ImageList.Images[this.TabPages[index].ImageKey];
            }
            if (tabImage != null)
            {
                Rectangle rect = this.GetTabRect(index);
                g.DrawImage(tabImage, rect.Right - rect.Height - 4, 4, rect.Height - 2, rect.Height - 2);
            }
        }

        /// <summary>
        /// Paints the tab text.
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <param name="index">The index.</param>
        private void PaintTabText(System.Drawing.Graphics graph, int index)
        {
            string tabtext = this.TabPages[index].Text;

            System.Drawing.StringFormat format = new System.Drawing.StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;

            Brush forebrush = null;

            if (this.TabPages[index].Enabled == false)
            {
                forebrush = SystemBrushes.ControlDark;
            }
            else
            {
                forebrush = SystemBrushes.ControlText;
            }

            Font tabFont = this.Font;
            if (index == this.SelectedIndex)
            {
                if (this.TabPages[index].Enabled != false)
                {
                    forebrush = new SolidBrush(_headSelectedBackColor);
                }
            }

            Rectangle rect = this.GetTabRect(index);

            var txtSize = ControlHelper.GetStringWidth(tabtext, graph, tabFont);
            Rectangle rect2 = new Rectangle(rect.Left + (rect.Width - txtSize) / 2 - 1, rect.Top, rect.Width, rect.Height);

            graph.DrawString(tabtext, tabFont, forebrush, rect2, format);
        }

        /// <summary>
        /// 设置 TabPage 内容页边框色
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs" /> instance containing the event data.</param>
        private void PaintTheTabPageBorder(System.Windows.Forms.PaintEventArgs e)
        {
            if (this.TabCount > 0)
            {
                Rectangle borderRect = this.TabPages[0].Bounds;
                //borderRect.Inflate(1, 1);
                Rectangle rect = new Rectangle(borderRect.X - 2, borderRect.Y - 1, borderRect.Width + 5, borderRect.Height + 2);
                ControlPaint.DrawBorder(e.Graphics, rect, this.BorderColor, ButtonBorderStyle.Solid);
            }
        }

        /// <summary>
        /// Paints the selected tab.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs" /> instance containing the event data.</param>
        private void PaintTheSelectedTab(System.Windows.Forms.PaintEventArgs e)
        {
            if (this.SelectedIndex == -1)
                return;
            Rectangle selrect;
            int selrectRight = 0;
            selrect = this.GetTabRect(this.SelectedIndex);
            selrectRight = selrect.Right;
            e.Graphics.DrawLine(new Pen(_headSelectedBackColor), selrect.Left, selrect.Bottom + 1, selrectRight, selrect.Bottom + 1);
        }

        /// <summary>
        /// Gets the tab path.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath GetTabPath(int index)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.Reset();

            Rectangle rect = this.GetTabRect(index);

            switch (Alignment)
            {
                case TabAlignment.Top:

                    break;
                case TabAlignment.Bottom:

                    break;
                case TabAlignment.Left:

                    break;
                case TabAlignment.Right:

                    break;
            }

            path.AddLine(rect.Left, rect.Top, rect.Left, rect.Bottom + 1);
            path.AddLine(rect.Left, rect.Top, rect.Right, rect.Top);
            path.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom + 1);
            path.AddLine(rect.Right, rect.Bottom + 1, rect.Left, rect.Bottom + 1);

            return path;
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// The wm setfont
        /// </summary>
        private const int WM_SETFONT = 0x30;
        /// <summary>
        /// The wm fontchange
        /// </summary>
        private const int WM_FONTCHANGE = 0x1d;

        /// <summary>
        /// 引发 <see cref="M:System.Windows.Forms.Control.CreateControl" /> 方法。
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.OnFontChanged(EventArgs.Empty);
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.FontChanged" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.EventArgs" />。</param>
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            IntPtr hFont = this.Font.ToHfont();
            SendMessage(this.Handle, WM_SETFONT, hFont, (IntPtr)(-1));
            SendMessage(this.Handle, WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero);
            this.UpdateStyles();
        }

        /// <summary>
        /// 此成员重写 <see cref="M:System.Windows.Forms.Control.WndProc(System.Windows.Forms.Message@)" />。
        /// </summary>
        /// <param name="m">一个 Windows 消息对象。</param>
        protected override void WndProc(ref Message m)
        {
			 base.WndProc(ref m);
            if (m.Msg == 0x0201) // WM_LBUTTONDOWN
            {
                if (!DesignMode)
                {
                    if (IsShowCloseBtn)
                    {
                        var mouseLocation = this.PointToClient(Control.MousePosition);
                        int index = GetMouseDownTabHead(mouseLocation);
                        if (index >= 0)
                        {
                            if (UncloseTabIndexs != null)
                            {
                                if (UncloseTabIndexs.ToList().Contains(index))
                                    return;
                            }
                            Rectangle rect = this.GetTabRect(index);
                            var closeRect = new Rectangle(rect.Right - 15, rect.Top + 5, 10, 10);
                            if (closeRect.Contains(mouseLocation))
                            {
                                this.TabPages.RemoveAt(index);
                                return;
                            }
                        }
                    }
                }
            }

           
        }
        /// <summary>
        /// 在调度键盘或输入消息之前，在消息循环内对它们进行预处理。
        /// </summary>
        /// <param name="msg">通过引用传递的 <see cref="T:System.Windows.Forms.Message" />，它表示要处理的消息。可能的值有 WM_KEYDOWN、WM_SYSKEYDOWN、WM_CHAR 和 WM_SYSCHAR。</param>
        /// <returns>如果消息已由控件处理，则为 true；否则为 false。</returns>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public override bool PreProcessMessage(ref Message msg)
        {

            return base.PreProcessMessage(ref msg);
        }

        /// <summary>
        /// Gets the mouse down tab head.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>System.Int32.</returns>
        private int GetMouseDownTabHead(Point point)
        {
            for (int i = 0; i < this.TabCount; i++)
            {
                Rectangle rect = this.GetTabRect(i);
                if (rect.Contains(point))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
