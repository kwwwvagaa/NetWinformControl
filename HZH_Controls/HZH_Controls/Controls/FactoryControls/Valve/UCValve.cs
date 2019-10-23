// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-06
//
// ***********************************************************************
// <copyright file="UCValve.cs">
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using HZH_Controls.Controls;
using System.ComponentModel;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCValve.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCValve : UserControl
    {
        /// <summary>
        /// Occurs when [open checked].
        /// </summary>
        [Description("打开状态改变事件"), Category("自定义")]
        public event EventHandler OpenChecked;
        /// <summary>
        /// The valve style
        /// </summary>
        private ValveStyle valveStyle = ValveStyle.Horizontal_Top;

        /// <summary>
        /// Gets or sets the valve style.
        /// </summary>
        /// <value>The valve style.</value>
        [Description("阀门样式"), Category("自定义")]
        public ValveStyle ValveStyle
        {
            get { return valveStyle; }
            set
            {
                valveStyle = value;
                Refresh();
            }
        }

        /// <summary>
        /// The valve color
        /// </summary>
        private Color valveColor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the color of the valve.
        /// </summary>
        /// <value>The color of the valve.</value>
        [Description("阀门颜色"), Category("自定义")]
        public Color ValveColor
        {
            get { return valveColor; }
            set
            {
                valveColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// The switch color
        /// </summary>
        private Color switchColor = Color.FromArgb(232, 30, 99);

        /// <summary>
        /// Gets or sets the color of the switch.
        /// </summary>
        /// <value>The color of the switch.</value>
        [Description("开关把手颜色"), Category("自定义")]
        public Color SwitchColor
        {
            get { return switchColor; }
            set
            {
                switchColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// The axis color
        /// </summary>
        private Color axisColor = Color.FromArgb(3, 169, 243);

        /// <summary>
        /// Gets or sets the color of the axis.
        /// </summary>
        /// <value>The color of the axis.</value>
        [Description("轴颜色"), Category("自定义")]
        public Color AxisColor
        {
            get { return axisColor; }
            set
            {
                axisColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// The asis bottom color
        /// </summary>
        private Color asisBottomColor = Color.FromArgb(3, 169, 243);

        /// <summary>
        /// Gets or sets the color of the asis bottom.
        /// </summary>
        /// <value>The color of the asis bottom.</value>
        [Description("轴底座颜色"), Category("自定义")]
        public Color AsisBottomColor
        {
            get { return asisBottomColor; }
            set { asisBottomColor = value; }
        }

        /// <summary>
        /// The opened
        /// </summary>
        private bool opened = true;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UCValve" /> is opened.
        /// </summary>
        /// <value><c>true</c> if opened; otherwise, <c>false</c>.</value>
        [Description("是否打开"), Category("自定义")]
        public bool Opened
        {
            get { return opened; }
            set
            {
                opened = value;
                Refresh();
                if (OpenChecked != null)
                {
                    OpenChecked(this, null);
                }
            }
        }

        /// <summary>
        /// The liquid direction
        /// </summary>
        private LiquidDirection liquidDirection = LiquidDirection.Forward;

        /// <summary>
        /// Gets or sets the liquid direction.
        /// </summary>
        /// <value>The liquid direction.</value>
        [Description("液体流动方向"), Category("自定义")]
        public LiquidDirection LiquidDirection
        {
            get { return liquidDirection; }
            set
            {
                liquidDirection = value;
                if (value == LiquidDirection.None)
                    m_timer.Enabled = false;
                else
                    m_timer.Enabled = true;
                Refresh();
            }
        }

        /// <summary>
        /// The liquid speed
        /// </summary>
        private int liquidSpeed = 100;

        /// <summary>
        /// 液体流速，越小，速度越快Gets or sets the liquid speed.
        /// </summary>
        /// <value>The liquid speed.</value>
        [Description("液体流速，越小，速度越快"), Category("自定义")]
        public int LiquidSpeed
        {
            get { return liquidSpeed; }
            set
            {
                if (value <= 0)
                    return;
                liquidSpeed = value;
                m_timer.Interval = value;
            }
        }

        /// <summary>
        /// The liquid color
        /// </summary>
        private Color liquidColor = Color.FromArgb(3, 169, 243);

        /// <summary>
        /// Gets or sets the color of the liquid.
        /// </summary>
        /// <value>The color of the liquid.</value>
        [Description("液体颜色"), Category("自定义")]
        public Color LiquidColor
        {
            get { return liquidColor; }
            set
            {
                liquidColor = value;
                if (liquidDirection != LiquidDirection.None)
                    Refresh();
            }
        }
        /// <summary>
        /// The m timer
        /// </summary>
        Timer m_timer;
        /// <summary>
        /// The int line left
        /// </summary>
        int intLineLeft = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="UCValve" /> class.
        /// </summary>
        public UCValve()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Size = new Size(120, 100);
            m_timer = new Timer();
            m_timer.Interval = 100;
            m_timer.Tick += timer_Tick;
            m_timer.Enabled = true;
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void timer_Tick(object sender, EventArgs e)
        {
            intLineLeft += 2;
            if (intLineLeft > 12)
                intLineLeft = 0;
            Refresh();
        }


        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            Rectangle rectGuan = Rectangle.Empty;//管道
            Rectangle rectJK1 = Rectangle.Empty;//接口1
            Rectangle rectJK2 = Rectangle.Empty;//接口2
            Rectangle rectZ = Rectangle.Empty;//轴
            GraphicsPath linePath = new GraphicsPath();//管道中心线
            GraphicsPath dzPath = new GraphicsPath();//轴底座
            GraphicsPath bsPath = new GraphicsPath();//开关把手
            switch (valveStyle)
            {
                case ValveStyle.Horizontal_Top:
                    rectGuan = new Rectangle(0, this.Height / 2, this.Width, this.Height / 2 - this.Height / 8);
                    rectJK1 = new Rectangle(this.Height / 8, rectGuan.Top - this.Height / 8, rectGuan.Height / 2, rectGuan.Height + this.Height / 4);
                    rectJK2 = new Rectangle(rectGuan.Right - this.Height / 8 - rectGuan.Height / 2, rectGuan.Top - this.Height / 8, rectGuan.Height / 2, rectGuan.Height + this.Height / 4);
                    linePath.AddLine(new Point(rectGuan.Left - 10, rectGuan.Top + rectGuan.Height / 2), new Point(rectGuan.Right + 10, rectGuan.Top + rectGuan.Height / 2));
                    rectZ = new Rectangle(rectGuan.Left + (rectGuan.Width - rectGuan.Height / 4) / 2, 10, rectGuan.Height / 4, rectGuan.Top - 10);
                    Point[] psTop = new Point[]             
                    {
                        new Point(rectGuan.Left+(rectGuan.Width-rectGuan.Height/2)/2,rectGuan.Top- this.Height / 8- 5 ),
                        new Point(rectGuan.Right-(rectGuan.Width-rectGuan.Height/2)/2,rectGuan.Top- this.Height / 8- 5 ),
                        new Point(rectGuan.Right-(rectGuan.Width-rectGuan.Height)/2,rectGuan.Top+2 ),
                        new Point(rectGuan.Left+(rectGuan.Width-rectGuan.Height)/2,rectGuan.Top +2),
                    };
                    dzPath.AddLines(psTop);
                    dzPath.CloseAllFigures();
                    if (opened)
                    {
                        bsPath.AddLine(rectGuan.Left + (rectGuan.Width - rectGuan.Height - 10) / 2, 10 + (rectGuan.Height / 3) / 2, rectGuan.Left + (rectGuan.Width - rectGuan.Height - 10) / 2 + rectGuan.Height + 10, 10 + (rectGuan.Height / 3) / 2);
                    }
                    else
                    {
                        bsPath.AddLine(new Point(rectGuan.Left + rectGuan.Width / 2 - 3, 1), new Point(rectGuan.Left + rectGuan.Width / 2 + 4, rectGuan.Height + 10));
                    }
                    break;
                case ValveStyle.Horizontal_Bottom:
                    rectGuan = new Rectangle(0, this.Height / 8, this.Width, this.Height / 2 - this.Height / 8);
                    rectJK1 = new Rectangle(this.Height / 8, rectGuan.Top - this.Height / 8, rectGuan.Height / 2, rectGuan.Height + this.Height / 4);
                    rectJK2 = new Rectangle(rectGuan.Right - this.Height / 8 - rectGuan.Height / 2, rectGuan.Top - this.Height / 8, rectGuan.Height / 2, rectGuan.Height + this.Height / 4);
                    linePath.AddLine(new Point(rectGuan.Left - 10, rectGuan.Top + rectGuan.Height / 2), new Point(rectGuan.Right + 10, rectGuan.Top + rectGuan.Height / 2));
                    rectZ = new Rectangle(rectGuan.Left + (rectGuan.Width - rectGuan.Height / 4) / 2, rectGuan.Bottom + 10, rectGuan.Height / 4, this.Height - 10 - (rectGuan.Bottom + 10));
                    Point[] psBottom = new Point[]             
                    {
                        new Point(rectGuan.Left+(rectGuan.Width-rectGuan.Height/2)/2,rectGuan.Bottom+ this.Height / 8+ 5 ),
                        new Point(rectGuan.Right-(rectGuan.Width-rectGuan.Height/2)/2,rectGuan.Bottom+ this.Height / 8+ 5 ),
                        new Point(rectGuan.Right-(rectGuan.Width-rectGuan.Height)/2,rectGuan.Bottom-2 ),
                        new Point(rectGuan.Left+(rectGuan.Width-rectGuan.Height)/2,rectGuan.Bottom-2),
                    };
                    dzPath.AddLines(psBottom);
                    dzPath.CloseAllFigures();
                    if (opened)
                    {
                        bsPath.AddLine(rectGuan.Left + (rectGuan.Width - rectGuan.Height - 10) / 2, this.Height - (10 + (rectGuan.Height / 3) / 2), rectGuan.Left + (rectGuan.Width - rectGuan.Height - 10) / 2 + rectGuan.Height + 10, this.Height - (10 + (rectGuan.Height / 3) / 2));
                    }
                    else
                    {
                        bsPath.AddLine(new Point(rectGuan.Left + rectGuan.Width / 2 - 3, this.Height - 1), new Point(rectGuan.Left + rectGuan.Width / 2 + 4, this.Height - (rectGuan.Height + 10)));
                    }
                    break;
                case ValveStyle.Vertical_Left:
                    rectGuan = new Rectangle(this.Width / 8, 0, this.Width / 2 - this.Width / 8, this.Height);
                    rectJK1 = new Rectangle(0, this.Width / 8, rectGuan.Width + this.Width / 4, rectGuan.Width / 2);
                    rectJK2 = new Rectangle(0, this.Height - this.Width / 8 - rectGuan.Width / 2, rectGuan.Width + this.Width / 4, rectGuan.Width / 2);
                    linePath.AddLine(new Point(rectGuan.Left + rectGuan.Width / 2, rectGuan.Top - 10), new Point(rectGuan.Left + rectGuan.Width / 2, rectGuan.Bottom + 10));
                    rectZ = new Rectangle(rectGuan.Right, rectGuan.Top + (rectGuan.Height - rectGuan.Width / 4) / 2, rectGuan.Right - 10, rectGuan.Width / 4);
                    Point[] psLeft = new Point[]             
                    {
                        new Point(rectGuan.Right+ this.Width / 8+ 5 ,rectGuan.Top + (rectGuan.Height - rectGuan.Width / 2) / 2),
                        new Point(rectGuan.Right+ this.Width / 8+ 5 ,rectGuan.Top + (rectGuan.Height - rectGuan.Width / 2) / 2+rectGuan.Width / 2),                      
                        new Point(rectGuan.Right-2, rectGuan.Top +(rectGuan.Height-rectGuan.Width)/2+rectGuan.Width),
                        new Point(rectGuan.Right-2, rectGuan.Top +(rectGuan.Height-rectGuan.Width)/2),
                    };
                    dzPath.AddLines(psLeft);
                    dzPath.CloseAllFigures();
                    if (opened)
                    {
                        bsPath.AddLine(this.Width - (10 + (rectGuan.Width / 3) / 2), rectGuan.Top + (rectGuan.Height - rectGuan.Width - 10) / 2, this.Width - (10 + (rectGuan.Width / 3) / 2), rectGuan.Top + (rectGuan.Height - rectGuan.Width - 10) / 2 + rectGuan.Width + 10);
                    }
                    else
                    {
                        bsPath.AddLine(new Point(this.Width - 1, rectGuan.Top + rectGuan.Height / 2 - 3), new Point(this.Width - (rectGuan.Width + 10), rectGuan.Top + rectGuan.Height / 2 + 4));
                    }
                    break;
                case ValveStyle.Vertical_Right:
                    rectGuan = new Rectangle(this.Width - this.Width / 8 - (this.Width / 2 - this.Width / 8), 0, this.Width / 2 - this.Width / 8, this.Height);
                    rectJK1 = new Rectangle(this.Width - (rectGuan.Width + this.Width / 4), this.Width / 8, rectGuan.Width + this.Width / 4, rectGuan.Width / 2);
                    rectJK2 = new Rectangle(this.Width - (rectGuan.Width + this.Width / 4), this.Height - this.Width / 8 - rectGuan.Width / 2, rectGuan.Width + this.Width / 4, rectGuan.Width / 2);
                    linePath.AddLine(new Point(rectGuan.Left + rectGuan.Width / 2, rectGuan.Top - 10), new Point(rectGuan.Left + rectGuan.Width / 2, rectGuan.Bottom + 10));
                    rectZ = new Rectangle(10, rectGuan.Top + (rectGuan.Height - rectGuan.Width / 4) / 2, rectGuan.Left - 10, rectGuan.Width / 4);
                    Point[] psRight = new Point[]             
                    {
                        new Point(rectGuan.Left- (this.Width / 8+ 5) ,rectGuan.Top + (rectGuan.Height - rectGuan.Width / 2) / 2),
                        new Point(rectGuan.Left-( this.Width / 8+ 5) ,rectGuan.Top + (rectGuan.Height - rectGuan.Width / 2) / 2+rectGuan.Width / 2),                      
                        new Point(rectGuan.Left+2, rectGuan.Top +(rectGuan.Height-rectGuan.Width)/2+rectGuan.Width),
                        new Point(rectGuan.Left+2, rectGuan.Top +(rectGuan.Height-rectGuan.Width)/2),
                    };
                    dzPath.AddLines(psRight);
                    dzPath.CloseAllFigures();

                    if (opened)
                    {
                        bsPath.AddLine((10 + (rectGuan.Width / 3) / 2), rectGuan.Top + (rectGuan.Height - rectGuan.Width - 10) / 2, (10 + (rectGuan.Width / 3) / 2), rectGuan.Top + (rectGuan.Height - rectGuan.Width - 10) / 2 + rectGuan.Width + 10);
                    }
                    else
                    {
                        bsPath.AddLine(new Point(1, rectGuan.Top + rectGuan.Height / 2 - 3), new Point((rectGuan.Width + 10), rectGuan.Top + rectGuan.Height / 2 + 4));
                    }
                    break;
            }

            //管道
            g.FillRectangle(new SolidBrush(valveColor), rectGuan);
            //接口
            g.FillRectangle(new SolidBrush(valveColor), rectJK1);
            g.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), rectJK1);
            g.FillRectangle(new SolidBrush(valveColor), rectJK2);
            g.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), rectJK2);


            //高亮
            int intCount = (valveStyle.ToString().StartsWith("H") ? rectGuan.Height : rectGuan.Width) / 2 / 4;
            for (int i = 0; i < intCount; i++)
            {
                int _penWidth = (valveStyle.ToString().StartsWith("H") ? rectGuan.Height : rectGuan.Width) / 2 - 4 * i;
                if (_penWidth <= 0)
                    _penWidth = 1;
                g.DrawPath(new Pen(new SolidBrush(Color.FromArgb(40, Color.White.R, Color.White.G, Color.White.B)), _penWidth), linePath);
                if (_penWidth == 1)
                    break;
            }

            g.SetGDIHigh();
            //轴
            g.FillRectangle(new SolidBrush(axisColor), rectZ);

            //阀门底座           
            g.FillPath(new SolidBrush(asisBottomColor), dzPath);
            g.FillPath(new SolidBrush(Color.FromArgb(50, Color.White)), dzPath);

            //把手
            g.DrawPath(new Pen(new SolidBrush(switchColor), (valveStyle.ToString().StartsWith("H") ? rectGuan.Height : rectGuan.Width) / 3), bsPath);

            //液体流动
            if (opened)
            {
                Pen p = new Pen(new SolidBrush(liquidColor), 4);
                p.DashPattern = new float[] { 6, 6 };
                p.DashOffset = intLineLeft * (LiquidDirection == LiquidDirection.Forward ? -1 : 1);
                g.DrawPath(p, linePath);
            }
        }
    }

    /// <summary>
    /// Enum ValveStyle
    /// </summary>
    public enum ValveStyle
    {
        /// <summary>
        /// 横向，开关在上方
        /// </summary>
        Horizontal_Top,
        /// <summary>
        /// 横向，开关在下方
        /// </summary>
        Horizontal_Bottom,
        /// <summary>
        /// 纵向，开关在左侧
        /// </summary>
        Vertical_Left,
        /// <summary>
        /// 纵向，开关在右侧
        /// </summary>
        Vertical_Right,
    }
}
