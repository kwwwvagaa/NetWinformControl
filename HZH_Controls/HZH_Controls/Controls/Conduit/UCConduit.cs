// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-04
//
// ***********************************************************************
// <copyright file="UCConduit.cs">
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
using System.ComponentModel;

namespace HZH_Controls.Controls.Conduit
{
    /// <summary>
    /// Class UCConduit.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCConduit : UserControl
    {
        /// <summary>
        /// The conduit style
        /// </summary>
        private ConduitStyle conduitStyle = ConduitStyle.Horizontal_None_None;

        /// <summary>
        /// Gets or sets the conduit style.
        /// </summary>
        /// <value>The conduit style.</value>
        [Description("样式"), Category("自定义")]
        public ConduitStyle ConduitStyle
        {
            get { return conduitStyle; }
            set
            {
                string strOld = conduitStyle.ToString().Substring(0, 1);
                string strNew = value.ToString().Substring(0, 1);
                conduitStyle = value;
                if (strOld != strNew)
                {
                    this.Size = new Size(this.Size.Height, this.Size.Width);
                }
                Refresh();
            }
        }

        /// <summary>
        /// The conduit color
        /// </summary>
        private Color conduitColor = Color.FromArgb(255, 77, 59);
        [Description("颜色"), Category("自定义")]
        /// <summary>
        /// Gets or sets the color of the conduit.
        /// </summary>
        /// <value>The color of the conduit.</value>
        public Color ConduitColor
        {
            get { return conduitColor; }
            set
            {
                conduitColor = value;
                Refresh();
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
                if (liquidDirection != Conduit.LiquidDirection.None)
                    Refresh();
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
        /// The int pen width
        /// </summary>
        int intPenWidth = 0;

        /// <summary>
        /// The int line left
        /// </summary>
        int intLineLeft = 0;
        /// <summary>
        /// The m timer
        /// </summary>
        Timer m_timer;
        /// <summary>
        /// Initializes a new instance of the <see cref="UCConduit"/> class.
        /// </summary>
        public UCConduit()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.SizeChanged += UCConduit_SizeChanged;
            this.Size = new Size(200, 50);
            m_timer = new Timer();
            m_timer.Interval = 100;
            m_timer.Tick += timer_Tick;
            m_timer.Enabled = true;
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void timer_Tick(object sender, EventArgs e)
        {
            intLineLeft += 2;
            if (intLineLeft > 12)
                intLineLeft = 0;
            Refresh();
        }


        /// <summary>
        /// Handles the SizeChanged event of the UCConduit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void UCConduit_SizeChanged(object sender, EventArgs e)
        {
            intPenWidth = conduitStyle.ToString().StartsWith("H") ? this.Height : this.Width;
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            List<ArcEntity> lstArcs = new List<ArcEntity>();

            GraphicsPath path = new GraphicsPath();
            GraphicsPath linePath = new GraphicsPath();
            switch (conduitStyle)
            {
                #region H    English:H
                case ConduitStyle.Horizontal_None_None:
                    path.AddLines(new PointF[]
                    { 
                        new PointF(0, 0), 
                        new PointF(this.ClientRectangle.Right, 0),
                        new PointF(this.ClientRectangle.Right, this.Height),
                        new PointF(0, this.Height)
                    });
                    path.CloseAllFigures();
                    linePath.AddLine(0, this.Height / 2, this.Width, this.Height / 2);
                    break;
                case ConduitStyle.Horizontal_Up_None:
                    path.AddLines(new PointF[]
                    { 
                        new PointF(0, 0), 
                        new PointF(this.ClientRectangle.Right, 0),
                        new PointF(this.ClientRectangle.Right, this.Height),
                        new PointF(0+intPenWidth, this.Height)
                    });
                    path.AddArc(new Rectangle(0, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), 90, 90);
                    path.CloseAllFigures();

                    linePath.AddArc(new Rectangle(intPenWidth / 2 + 1, -1 * intPenWidth / 2 - 1, intPenWidth, intPenWidth), 181, -91);
                    linePath.AddLine(intPenWidth, this.Height / 2, this.Width, this.Height / 2);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(0, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), startAngle = 90, sweepAngle = 90 });
                    break;
                case ConduitStyle.Horizontal_Down_None:
                    path.AddLines(new PointF[]
                    { 
                        new PointF(intPenWidth, 0), 
                        new PointF(this.ClientRectangle.Right, 0),
                        new PointF(this.ClientRectangle.Right, this.Height),
                        new PointF(0, this.Height)
                    });
                    path.AddArc(new Rectangle(0, -1, intPenWidth * 2, intPenWidth * 2), 180, 90);
                    path.CloseAllFigures();

                    linePath.AddArc(new Rectangle(intPenWidth / 2 + 1, this.Height / 2, intPenWidth, intPenWidth), 179, 91);
                    linePath.AddLine(intPenWidth + 1, this.Height / 2, this.Width, this.Height / 2);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(0, -1, intPenWidth * 2, intPenWidth * 2), startAngle = 180, sweepAngle = 90 });
                    break;
                case ConduitStyle.Horizontal_None_Up:
                    path.AddLines(new PointF[]
                    { 
                        new PointF(this.ClientRectangle.Right-intPenWidth, this.Height),
                        new PointF(0, this.Height),
                        new PointF(0, 0), 
                        new PointF(this.ClientRectangle.Right-intPenWidth, 0)
                    });
                    path.AddArc(new Rectangle(this.ClientRectangle.Right - intPenWidth * 2, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), 0, 90);
                    path.CloseAllFigures();

                    linePath.AddLine(0, this.Height / 2, this.Width - intPenWidth, this.Height / 2);
                    linePath.AddArc(new Rectangle(this.ClientRectangle.Right - intPenWidth - intPenWidth / 2 - 1, -1 * intPenWidth / 2 - 1, intPenWidth, intPenWidth), 91, -91);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(this.ClientRectangle.Right - intPenWidth * 2, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), startAngle = 0, sweepAngle = 90 });
                    break;
                case ConduitStyle.Horizontal_None_Down:
                    path.AddLines(new PointF[]
                    { 
                        new PointF(this.ClientRectangle.Right, this.Height),
                        new PointF(0, this.Height),
                        new PointF(0, 0), 
                        new PointF(this.ClientRectangle.Right-intPenWidth, 0)
                    });
                    path.AddArc(new Rectangle(this.ClientRectangle.Right - intPenWidth * 2, -1, intPenWidth * 2, intPenWidth * 2), 270, 90);
                    path.CloseAllFigures();

                    linePath.AddLine(0, this.Height / 2, this.Width - intPenWidth - 1, this.Height / 2);
                    linePath.AddArc(new Rectangle(this.ClientRectangle.Right - intPenWidth - intPenWidth / 2 - 1, intPenWidth / 2, intPenWidth, intPenWidth), 269, 91);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(this.ClientRectangle.Right - intPenWidth * 2, -1, intPenWidth * 2, intPenWidth * 2), startAngle = 270, sweepAngle = 90 });
                    break;
                case ConduitStyle.Horizontal_Down_Up:
                    path.AddLine(new Point(intPenWidth, 0), new Point(this.Width, 0));
                    path.AddArc(new Rectangle(this.ClientRectangle.Right - intPenWidth * 2, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), 0, 90);
                    path.AddLine(new Point(this.Width - intPenWidth, this.Height), new Point(0, this.Height));
                    path.AddArc(new Rectangle(0, -1, intPenWidth * 2, intPenWidth * 2), 180, 90);
                    path.CloseAllFigures();

                    linePath.AddArc(new Rectangle(intPenWidth / 2 + 1, this.Height / 2, intPenWidth, intPenWidth), 179, 91);
                    //linePath.AddLine(intPenWidth, this.Height / 2, this.Width - intPenWidth, this.Height / 2);
                    linePath.AddArc(new Rectangle(this.ClientRectangle.Right - intPenWidth - intPenWidth / 2 - 1, -1 * intPenWidth / 2 - 1, intPenWidth, intPenWidth), 91, -91);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(0, -1, intPenWidth * 2, intPenWidth * 2), startAngle = 180, sweepAngle = 90 });
                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(this.ClientRectangle.Right - intPenWidth * 2, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), startAngle = 0, sweepAngle = 90 });
                    break;
                case ConduitStyle.Horizontal_Up_Down:
                    path.AddLine(new Point(0, 0), new Point(this.Width - intPenWidth, 0));
                    path.AddArc(new Rectangle(this.ClientRectangle.Right - intPenWidth * 2, -1, intPenWidth * 2, intPenWidth * 2), 270, 90);
                    path.AddLine(new Point(this.Width, this.Height), new Point(intPenWidth, this.Height));
                    path.AddArc(new Rectangle(0, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), 90, 90);
                    path.CloseAllFigures();

                    linePath.AddArc(new Rectangle(intPenWidth / 2 + 1, -1 * intPenWidth / 2 - 1, intPenWidth, intPenWidth), 181, -91);
                    linePath.AddLine(intPenWidth, this.Height / 2, this.Width - intPenWidth - 1, this.Height / 2);
                    linePath.AddArc(new Rectangle(this.ClientRectangle.Right - intPenWidth - intPenWidth / 2 - 1, intPenWidth / 2, intPenWidth, intPenWidth), 269, 91);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(0, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), startAngle = 90, sweepAngle = 90 });
                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(this.ClientRectangle.Right - intPenWidth * 2, -1, intPenWidth * 2, intPenWidth * 2), startAngle = 270, sweepAngle = 90 });
                    break;
                case ConduitStyle.Horizontal_Up_Up:
                    path.AddLine(new Point(0, 0), new Point(this.Width, 0));
                    path.AddArc(new Rectangle(this.ClientRectangle.Right - intPenWidth * 2, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), 0, 90);
                    path.AddLine(new Point(this.Width - intPenWidth, this.Height), new Point(intPenWidth, this.Height));
                    path.AddArc(new Rectangle(0, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), 90, 90);
                    path.CloseAllFigures();

                    linePath.AddArc(new Rectangle(intPenWidth / 2 + 1, -1 * intPenWidth / 2 - 1, intPenWidth, intPenWidth), 181, -91);
                    //linePath.AddLine(intPenWidth, this.Height / 2, this.Width - intPenWidth, this.Height / 2);
                    linePath.AddArc(new Rectangle(this.ClientRectangle.Right - intPenWidth - intPenWidth / 2 - 1, -1 * intPenWidth / 2 - 1, intPenWidth, intPenWidth), 91, -91);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(0, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), startAngle = 90, sweepAngle = 90 });
                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(this.ClientRectangle.Right - intPenWidth * 2, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), startAngle = 0, sweepAngle = 90 });
                    break;
                case ConduitStyle.Horizontal_Down_Down:
                    path.AddLine(new Point(intPenWidth, 0), new Point(this.Width - intPenWidth, 0));
                    path.AddArc(new Rectangle(this.ClientRectangle.Right - intPenWidth * 2, -1, intPenWidth * 2, intPenWidth * 2), 270, 90);
                    path.AddLine(new Point(this.Width, this.Height), new Point(0, this.Height));
                    path.AddArc(new Rectangle(0, -1, intPenWidth * 2, intPenWidth * 2), 180, 90);
                    path.CloseAllFigures();

                    linePath.AddArc(new Rectangle(intPenWidth / 2 + 1, this.Height / 2, intPenWidth, intPenWidth), 179, 91);
                    linePath.AddLine(intPenWidth + 1, this.Height / 2, this.Width - intPenWidth - 1, this.Height / 2);
                    linePath.AddArc(new Rectangle(this.ClientRectangle.Right - intPenWidth - intPenWidth / 2 - 1, intPenWidth / 2, intPenWidth, intPenWidth), 269, 91);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(0, -1, intPenWidth * 2, intPenWidth * 2), startAngle = 180, sweepAngle = 90 });
                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(this.ClientRectangle.Right - intPenWidth * 2, -1, intPenWidth * 2, intPenWidth * 2), startAngle = 270, sweepAngle = 90 });
                    break;
                #endregion

                #region V    English:V
                case ConduitStyle.Vertical_None_None:
                    path.AddLines(new PointF[]
                    { 
                        new PointF(0, 0), 
                        new PointF(this.ClientRectangle.Right, 0),
                        new PointF(this.ClientRectangle.Right, this.Height),
                        new PointF(0, this.Height)
                    });
                    path.CloseAllFigures();
                    linePath.AddLine(this.Width / 2, 0, this.Width / 2, this.Height);
                    break;
                case ConduitStyle.Vertical_Left_None:
                    path.AddLines(new PointF[]
                    { 
                        new PointF(this.ClientRectangle.Right, intPenWidth),
                        new PointF(this.ClientRectangle.Right, this.Height),
                        new PointF(0, this.Height),
                        new PointF(0, 0)
                    });
                    path.AddArc(new Rectangle(-1 * intPenWidth, 0, intPenWidth * 2, intPenWidth * 2), 270, 90);
                    path.CloseAllFigures();

                    linePath.AddArc(new Rectangle(-1 * intPenWidth / 2 - 1, intPenWidth / 2 + 1, intPenWidth, intPenWidth), 269, 91);
                    linePath.AddLine(intPenWidth / 2, intPenWidth, intPenWidth / 2, this.Height);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(-1 * intPenWidth, 0, intPenWidth * 2, intPenWidth * 2), startAngle = 270, sweepAngle = 90 });
                    break;
                case ConduitStyle.Vertical_Right_None:
                    path.AddLines(new PointF[]
                    { 
                        new PointF(this.ClientRectangle.Right, 0),
                        new PointF(this.ClientRectangle.Right, this.Height),
                        new PointF(0, this.Height),
                        new PointF(0, intPenWidth)
                    });
                    path.AddArc(new Rectangle(-1, 0, intPenWidth * 2, intPenWidth * 2), 180, 90);
                    path.CloseAllFigures();

                    linePath.AddArc(new Rectangle(intPenWidth / 2, intPenWidth / 2 + 1, intPenWidth, intPenWidth), 271, -91);
                    linePath.AddLine(intPenWidth / 2, intPenWidth + 1, intPenWidth / 2, this.Height);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(-1, 0, intPenWidth * 2, intPenWidth * 2), startAngle = 180, sweepAngle = 90 });
                    break;
                case ConduitStyle.Vertical_None_Left:
                    path.AddLines(new PointF[]
                    { 
                        new PointF(0, this.Height),
                        new PointF(0, 0),
                        new PointF(this.ClientRectangle.Right, 0),
                        new PointF(this.ClientRectangle.Right, this.Height-intPenWidth),
                    });
                    path.AddArc(new Rectangle(-1 * intPenWidth, this.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), 0, 90);
                    path.CloseAllFigures();

                    linePath.AddLine(this.Width / 2, 0, this.Width / 2, this.Height - intPenWidth);
                    linePath.AddArc(new Rectangle(-1 * intPenWidth / 2 - 1, this.Height - intPenWidth - intPenWidth / 2 - 1, intPenWidth, intPenWidth), -1, 91);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(-1 * intPenWidth, this.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), startAngle = 0, sweepAngle = 90 });
                    break;
                case ConduitStyle.Vertical_None_Right:
                    path.AddLines(new PointF[]
                    { 
                        new PointF(0, this.Height-intPenWidth),
                        new PointF(0, 0),
                        new PointF(this.ClientRectangle.Right, 0),
                        new PointF(this.ClientRectangle.Right, this.Height),
                    });
                    path.AddArc(new Rectangle(-1, this.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), 90, 90);
                    path.CloseAllFigures();

                    linePath.AddLine(this.Width / 2, 0, this.Width / 2, this.Height - intPenWidth - 1);
                    linePath.AddArc(new Rectangle(intPenWidth / 2, this.Height - intPenWidth - intPenWidth / 2 - 1, intPenWidth, intPenWidth), 181, -91);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(-1, this.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), startAngle = 90, sweepAngle = 90 });
                    break;
                case ConduitStyle.Vertical_Left_Right:
                    path.AddLine(this.Width, intPenWidth, this.Width, this.Height);
                    path.AddArc(new Rectangle(-1, this.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), 90, 90);
                    path.AddLine(0, this.Height - intPenWidth, 0, 0);
                    path.AddArc(new Rectangle(-1 * intPenWidth, 0, intPenWidth * 2, intPenWidth * 2), 270, 90);
                    path.CloseAllFigures();

                    linePath.AddArc(new Rectangle(-1 * intPenWidth / 2 - 1, intPenWidth / 2 + 1, intPenWidth, intPenWidth), 269, 91);
                    //linePath.AddLine(intPenWidth / 2, intPenWidth, intPenWidth / 2, this.Height - intPenWidth);
                    linePath.AddArc(new Rectangle(intPenWidth / 2, this.Height - intPenWidth - intPenWidth / 2 - 1, intPenWidth, intPenWidth), 181, -91);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(-1 * intPenWidth, 0, intPenWidth * 2, intPenWidth * 2), startAngle = 270, sweepAngle = 90 });
                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(-1, this.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), startAngle = 90, sweepAngle = 90 });
                    break;
                case ConduitStyle.Vertical_Right_Left:
                    path.AddLine(this.Width, 0, this.Width, this.Height - intPenWidth);
                    path.AddArc(new Rectangle(-1 * intPenWidth, this.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), 0, 90);
                    path.AddLine(0, this.Height, 0, intPenWidth);
                    path.AddArc(new Rectangle(-1, 0, intPenWidth * 2, intPenWidth * 2), 180, 90);
                    path.CloseAllFigures();

                    linePath.AddArc(new Rectangle(intPenWidth / 2, intPenWidth / 2 + 1, intPenWidth, intPenWidth), 271, -91);
                    //linePath.AddLine(intPenWidth / 2, intPenWidth, intPenWidth / 2, this.Height - intPenWidth);
                    linePath.AddArc(new Rectangle(-1 * intPenWidth / 2 - 1, this.Height - intPenWidth - intPenWidth / 2 - 1, intPenWidth, intPenWidth), -1, 91);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(-1, 0, intPenWidth * 2, intPenWidth * 2), startAngle = 180, sweepAngle = 90 });
                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(-1 * intPenWidth, this.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), startAngle = 0, sweepAngle = 90 });
                    break;
                case ConduitStyle.Vertical_Left_Left:
                    path.AddLine(this.Width, intPenWidth, this.Width, this.Height - intPenWidth);
                    path.AddArc(new Rectangle(-1 * intPenWidth, this.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), 0, 90);
                    path.AddLine(0, this.Height, 0, 0);
                    path.AddArc(new Rectangle(-1 * intPenWidth, 0, intPenWidth * 2, intPenWidth * 2), 270, 90);
                    path.CloseAllFigures();

                    linePath.AddArc(new Rectangle(-1 * intPenWidth / 2 - 1, intPenWidth / 2 + 1, intPenWidth, intPenWidth), 269, 91);
                    //linePath.AddLine(intPenWidth / 2, intPenWidth, intPenWidth / 2, this.Height - intPenWidth);
                    linePath.AddArc(new Rectangle(-1 * intPenWidth / 2 - 1, this.Height - intPenWidth - intPenWidth / 2 - 1, intPenWidth, intPenWidth), -1, 91);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(-1 * intPenWidth, 0, intPenWidth * 2, intPenWidth * 2), startAngle = 270, sweepAngle = 90 });
                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(-1 * intPenWidth, this.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), startAngle = 0, sweepAngle = 90 });
                    break;
                case ConduitStyle.Vertical_Right_Right:
                    path.AddLine(this.Width, 0, this.Width, this.Height);
                    path.AddArc(new Rectangle(-1, this.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), 90, 90);
                    path.AddLine(0, this.Height - intPenWidth, 0, intPenWidth);
                    path.AddArc(new Rectangle(-1, 0, intPenWidth * 2, intPenWidth * 2), 180, 90);
                    path.CloseAllFigures();

                    linePath.AddArc(new Rectangle(intPenWidth / 2, intPenWidth / 2 + 1, intPenWidth, intPenWidth), 271, -91);
                    //linePath.AddLine(intPenWidth / 2, intPenWidth, intPenWidth / 2, this.Height - intPenWidth);
                    linePath.AddArc(new Rectangle(intPenWidth / 2, this.Height - intPenWidth - intPenWidth / 2 - 1, intPenWidth, intPenWidth), 180, -91);

                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(-1, 0, intPenWidth * 2, intPenWidth * 2), startAngle = 180, sweepAngle = 90 });
                    lstArcs.Add(new ArcEntity() { rect = new Rectangle(-1, this.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), startAngle = 90, sweepAngle = 90 });
                    break;
                #endregion
            }
            g.FillPath(new SolidBrush(conduitColor), path);

            //渐变色
            int intCount = intPenWidth / 2 / 4;
            int intSplit = (255 - 100) / intCount;
            for (int i = 0; i < intCount; i++)
            {
                int _penWidth = intPenWidth / 2 - 4 * i;
                if (_penWidth <= 0)
                    _penWidth = 1;
                g.DrawPath(new Pen(new SolidBrush(Color.FromArgb(40, Color.White.R, Color.White.G, Color.White.B)), _penWidth), linePath);
                if (_penWidth == 1)
                    break;
            }

            g.SetGDIHigh();
            //使用抗锯齿画圆角
            foreach (var item in lstArcs)
            {
                g.DrawArc(new Pen(new SolidBrush(this.BackColor)), item.rect, item.startAngle, item.sweepAngle);
            }

            //液体流动
            if (LiquidDirection != Conduit.LiquidDirection.None)
            {
                Pen p = new Pen(new SolidBrush(liquidColor), 4);
                p.DashPattern = new float[] { 6, 6 };
                p.DashOffset = intLineLeft * (LiquidDirection == Conduit.LiquidDirection.Forward ? -1 : 1);
                g.DrawPath(p, linePath);
            }
        }


        /// <summary>
        /// Class ArcEntity.
        /// </summary>
        class ArcEntity
        {
            /// <summary>
            /// Gets or sets the rect.
            /// </summary>
            /// <value>The rect.</value>
            public Rectangle rect { get; set; }
            /// <summary>
            /// Gets or sets the start angle.
            /// </summary>
            /// <value>The start angle.</value>
            public float startAngle { get; set; }
            /// <summary>
            /// Gets or sets the sweep angle.
            /// </summary>
            /// <value>The sweep angle.</value>
            public float sweepAngle { get; set; }
        }

    }

    /// <summary>
    /// Enum LiquidDirection
    /// </summary>
    public enum LiquidDirection
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The forward
        /// </summary>
        Forward,
        /// <summary>
        /// The backward
        /// </summary>
        Backward
    }

    /// <summary>
    /// 管道样式Enum ConduitStyle
    /// </summary>
    public enum ConduitStyle
    {
        /// <summary>
        /// 直线 The horizontal none none
        /// </summary>
        Horizontal_None_None,
        /// <summary>
        /// 左上The horizontal up none
        /// </summary>
        Horizontal_Up_None,
        /// <summary>
        /// 左下The horizontal down none
        /// </summary>
        Horizontal_Down_None,
        /// <summary>
        /// 右上The horizontal none up
        /// </summary>
        Horizontal_None_Up,
        /// <summary>
        /// 右下The horizontal none down
        /// </summary>
        Horizontal_None_Down,
        /// <summary>
        /// 左下右上The horizontal down up
        /// </summary>
        Horizontal_Down_Up,
        /// <summary>
        /// 左上右下The horizontal up down
        /// </summary>
        Horizontal_Up_Down,
        /// <summary>
        /// 左上，右上The horizontal up up
        /// </summary>
        Horizontal_Up_Up,
        /// <summary>
        /// 左下右下The horizontal down down
        /// </summary>
        Horizontal_Down_Down,

        /// <summary>
        /// 竖线The vertical none none
        /// </summary>
        Vertical_None_None,
        /// <summary>
        /// 上左The vertical left none
        /// </summary>
        Vertical_Left_None,
        /// <summary>
        /// 上右The vertical right none
        /// </summary>
        Vertical_Right_None,
        /// <summary>
        /// 下左The vertical none left
        /// </summary>
        Vertical_None_Left,
        /// <summary>
        /// 下右The vertical none right
        /// </summary>
        Vertical_None_Right,
        /// <summary>
        /// 上左下右The vertical left right
        /// </summary>
        Vertical_Left_Right,
        /// <summary>
        /// 上右下左The vertical right left
        /// </summary>
        Vertical_Right_Left,
        /// <summary>
        /// 上左下左The vertical left left
        /// </summary>
        Vertical_Left_Left,
        /// <summary>
        /// 上右下右The vertical right left
        /// </summary>
        Vertical_Right_Right,
    }
}
