// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="UCControlBase.cs">
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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCControlBase.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// Implements the <see cref="System.Windows.Forms.IContainerControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    /// <seealso cref="System.Windows.Forms.IContainerControl" />
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))]
    public partial class UCControlBase : UserControl, IContainerControl
    {
        /// <summary>
        /// The is radius
        /// </summary>
        private bool _isRadius = false;

        /// <summary>
        /// The corner radius
        /// </summary>
        private int _cornerRadius = 24;


        /// <summary>
        /// The is show rect
        /// </summary>
        private bool _isShowRect = false;

        /// <summary>
        /// The rect color
        /// </summary>
        private Color _rectColor = Color.FromArgb(220, 220, 220);

        /// <summary>
        /// The rect width
        /// </summary>
        private int _rectWidth = 1;

        /// <summary>
        /// The fill color
        /// </summary>
        private Color _fillColor = Color.Transparent;
        /// <summary>
        /// 是否圆角
        /// </summary>
        /// <value><c>true</c> if this instance is radius; otherwise, <c>false</c>.</value>
        [Description("是否圆角"), Category("自定义")]
        public virtual bool IsRadius
        {
            get
            {
                return this._isRadius;
            }
            set
            {
                this._isRadius = value;
                Refresh();
            }
        }
        /// <summary>
        /// 圆角角度
        /// </summary>
        /// <value>The coner radius.</value>
        [Description("圆角角度"), Category("自定义")]
        public virtual int ConerRadius
        {
            get
            {
                return this._cornerRadius;
            }
            set
            {
                this._cornerRadius = Math.Max(value, 1);
                Refresh();
            }
        }

        /// <summary>
        /// 是否显示边框
        /// </summary>
        /// <value><c>true</c> if this instance is show rect; otherwise, <c>false</c>.</value>
        [Description("是否显示边框"), Category("自定义")]
        public virtual bool IsShowRect
        {
            get
            {
                return this._isShowRect;
            }
            set
            {
                this._isShowRect = value;
                Refresh();
            }
        }
        /// <summary>
        /// 边框颜色
        /// </summary>
        /// <value>The color of the rect.</value>
        [Description("边框颜色"), Category("自定义")]
        public virtual Color RectColor
        {
            get
            {
                return this._rectColor;
            }
            set
            {
                this._rectColor = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 边框宽度
        /// </summary>
        /// <value>The width of the rect.</value>
        [Description("边框宽度"), Category("自定义")]
        public virtual int RectWidth
        {
            get
            {
                return this._rectWidth;
            }
            set
            {
                this._rectWidth = value;
                Refresh();
            }
        }
        /// <summary>
        /// 当使用边框时填充颜色，当值为背景色或透明色或空值则不填充
        /// </summary>
        /// <value>The color of the fill.</value>
        [Description("当使用边框时填充颜色，当值为背景色或透明色或空值则不填充"), Category("自定义")]
        public virtual Color FillColor
        {
            get
            {
                return this._fillColor;
            }
            set
            {
                this._fillColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCControlBase" /> class.
        /// </summary>
        public UCControlBase()
        {
            this.InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Visible)
            {
                if (this._isRadius)
                {
                    this.SetWindowRegion();
                }
                GraphicsPath graphicsPath = new GraphicsPath();
                if (this._isShowRect || (_fillColor != Color.Empty && _fillColor != Color.Transparent && _fillColor != this.BackColor))
                {
                    Rectangle clientRectangle = base.ClientRectangle;
                    graphicsPath.AddArc(0, 0, _cornerRadius, _cornerRadius, 180f, 90f);
                    graphicsPath.AddArc(clientRectangle.Width - _cornerRadius - 1, 0, _cornerRadius, _cornerRadius, 270f, 90f);
                    graphicsPath.AddArc(clientRectangle.Width - _cornerRadius - 1, clientRectangle.Height - _cornerRadius - 1, _cornerRadius, _cornerRadius, 0f, 90f);
                    graphicsPath.AddArc(0, clientRectangle.Height - _cornerRadius - 1, _cornerRadius, _cornerRadius, 90f, 90f);
                    graphicsPath.CloseFigure();
                }
                e.Graphics.SetGDIHigh();
                if (_fillColor != Color.Empty && _fillColor != Color.Transparent && _fillColor != this.BackColor)
                    e.Graphics.FillPath(new SolidBrush(this._fillColor), graphicsPath);
                if (this._isShowRect)
                {
                    Color rectColor = this._rectColor;
                    Pen pen = new Pen(rectColor, (float)this._rectWidth);
                    e.Graphics.DrawPath(pen, graphicsPath);
                }              
            }
            base.OnPaint(e);
        }

        /// <summary>
        /// Sets the window region.
        /// </summary>
        private void SetWindowRegion()
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(-1, -1, base.Width + 1, base.Height);
            path = this.GetRoundedRectPath(rect, this._cornerRadius);
            base.Region = new Region(path);
        }

        /// <summary>
        /// Gets the rounded rect path.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            Rectangle rect2 = new Rectangle(rect.Location, new Size(radius, radius));
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(rect2, 180f, 90f);//左上角
            rect2.X = rect.Right - radius;
            graphicsPath.AddArc(rect2, 270f, 90f);//右上角
            rect2.Y = rect.Bottom - radius;
            rect2.Width += 1;
            rect2.Height += 1;
            graphicsPath.AddArc(rect2, 360f, 90f);//右下角           
            rect2.X = rect.Left;
            graphicsPath.AddArc(rect2, 90f, 90f);//左下角
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        /// <summary>
        /// WNDs the proc.
        /// </summary>
        /// <param name="m">要处理的 Windows <see cref="T:System.Windows.Forms.Message" />。</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg != 20)
            {
                base.WndProc(ref m);
            }
        }
    }
}
