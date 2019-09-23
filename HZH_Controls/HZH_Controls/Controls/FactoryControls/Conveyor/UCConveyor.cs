// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-05
//
// ***********************************************************************
// <copyright file="UCConveyor.cs">
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

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCConveyor.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCConveyor : UserControl
    {
        /// <summary>
        /// The conveyor color
        /// </summary>
        private Color conveyorColor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the color of the conveyor.
        /// </summary>
        /// <value>The color of the conveyor.</value>
        [Description("传送带颜色"), Category("自定义")]
        public Color ConveyorColor
        {
            get { return conveyorColor; }
            set
            {
                conveyorColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// The inclination
        /// </summary>
        private double inclination = 0;

        /// <summary>
        /// Gets or sets the inclination.
        /// </summary>
        /// <value>The inclination.</value>
        [Description("传送带角度（-90<=value<=90）"), Category("自定义")]
        public double Inclination
        {
            get { return inclination; }
            set
            {
                if (value > 90 || value < -90)
                    return;
                inclination = value;
                ResetWorkingRect();
                Refresh();
            }
        }

        /// <summary>
        /// The conveyor height
        /// </summary>
        private int conveyorHeight = 50;

        /// <summary>
        /// Gets or sets the height of the conveyor.
        /// </summary>
        /// <value>The height of the conveyor.</value>
        [Description("传送带高度"), Category("自定义")]
        public int ConveyorHeight
        {
            get { return conveyorHeight; }
            set
            {
                conveyorHeight = value;
                ResetWorkingRect();
                Refresh();
            }
        }

        /// <summary>
        /// The conveyor direction
        /// </summary>
        private ConveyorDirection conveyorDirection = ConveyorDirection.Forward;

        /// <summary>
        /// Gets or sets the conveyor direction.
        /// </summary>
        /// <value>The conveyor direction.</value>
        [Description("传送带运行方向"), Category("自定义")]
        public ConveyorDirection ConveyorDirection
        {
            get { return conveyorDirection; }
            set
            {
                conveyorDirection = value;
                if (value == HZH_Controls.Controls.ConveyorDirection.None)
                {
                    m_timer.Enabled = false;
                    Refresh();
                }
                else
                {
                    m_timer.Enabled = true;
                }
            }
        }

        /// <summary>
        /// The liquid speed
        /// </summary>
        private int conveyorSpeed = 100;

        /// <summary>
        /// 传送带运行速度，越小，速度越快Gets or sets the ConveyorSpeed.
        /// </summary>
        /// <value>The liquid speed.</value>
        [Description("传送带运行速度，越小，速度越快"), Category("自定义")]
        public int ConveyorSpeed
        {
            get { return conveyorSpeed; }
            set
            {
                if (value <= 0)
                    return;
                conveyorSpeed = value;
                m_timer.Interval = value;
            }
        }

        /// <summary>
        /// The m working rect
        /// </summary>
        Rectangle m_workingRect;
        /// <summary>
        /// The int line left
        /// </summary>
        int intLineLeft = 0;
        /// <summary>
        /// The m timer
        /// </summary>
        Timer m_timer;
        /// <summary>
        /// Initializes a new instance of the <see cref="UCConveyor" /> class.
        /// </summary>
        public UCConveyor()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SizeChanged += UCConveyor_SizeChanged;
            this.Size = new Size(300, 50);
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
        /// Handles the SizeChanged event of the UCConveyor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void UCConveyor_SizeChanged(object sender, EventArgs e)
        {
            ResetWorkingRect();
        }

        /// <summary>
        /// Resets the working rect.
        /// </summary>
        private void ResetWorkingRect()
        {
            if (inclination == 90 || inclination == -90)
            {
                m_workingRect = new Rectangle((this.Width - conveyorHeight) / 2, 1, conveyorHeight, this.Height - 2);
            }
            else if (inclination == 0)
            {
                m_workingRect = new Rectangle(1, (this.Height - conveyorHeight) / 2 + 1, this.Width - 2, conveyorHeight);
            }
            else
            {
                //根据角度计算需要的高度
                int intHeight = (int)(Math.Tan(Math.PI * (Math.Abs(inclination) / 180.00000)) * (this.Width));
                if (intHeight >= this.Height)
                    intHeight = this.Height;

                int intWidth = (int)(intHeight / (Math.Tan(Math.PI * (Math.Abs(inclination) / 180.00000))));
                intHeight += conveyorHeight;
                if (intHeight >= this.Height)
                    intHeight = this.Height;
                m_workingRect = new Rectangle((this.Width - intWidth) / 2 + 1, (this.Height - intHeight) / 2 + 1, intWidth - 2, intHeight - 2);
            }
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();
            //g.FillRectangle(new SolidBrush(Color.FromArgb(100, conveyorColor)), m_workingRect);

            //轴
            //左端
            var rectLeft = new Rectangle(m_workingRect.Left + 5, (inclination >= 0 ? (m_workingRect.Bottom - conveyorHeight) : m_workingRect.Top) + 5, conveyorHeight - 10, conveyorHeight - 10);
            g.FillEllipse(new SolidBrush(conveyorColor), rectLeft);
            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(rectLeft.Left + (rectLeft.Width - 6) / 2, rectLeft.Top + (rectLeft.Height - 6) / 2, 6, 6));
            //右端
            var rectRight = new Rectangle(m_workingRect.Right - conveyorHeight + 5, (inclination >= 0 ? (m_workingRect.Top) : (m_workingRect.Bottom - conveyorHeight)) + 5, conveyorHeight - 10, conveyorHeight - 10);
            g.FillEllipse(new SolidBrush(conveyorColor), rectRight);
            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(rectRight.Left + (rectRight.Width - 6) / 2, rectRight.Top + (rectRight.Height - 6) / 2, 6, 6));

            //传送带
            //左端
            GraphicsPath path = new GraphicsPath();
            GraphicsPath pathRegion = new GraphicsPath();
            path.AddArc(new Rectangle(m_workingRect.Left + 3, (inclination >= 0 ? (m_workingRect.Bottom - conveyorHeight) : m_workingRect.Top) + 3, conveyorHeight - 6, conveyorHeight - 6), 90F - (float)inclination, 180F);
            pathRegion.AddArc(new Rectangle(m_workingRect.Left, (inclination >= 0 ? (m_workingRect.Bottom - conveyorHeight) : m_workingRect.Top), conveyorHeight, conveyorHeight), 90F - (float)inclination, 180F);
            //右端
            path.AddArc(new Rectangle(m_workingRect.Right - conveyorHeight + 3, (inclination >= 0 ? (m_workingRect.Top) : (m_workingRect.Bottom - conveyorHeight)) + 3, conveyorHeight - 6, conveyorHeight - 6), 270 - (float)inclination, 180F);
            pathRegion.AddArc(new Rectangle(m_workingRect.Right - conveyorHeight, (inclination >= 0 ? (m_workingRect.Top) : (m_workingRect.Bottom - conveyorHeight)), conveyorHeight, conveyorHeight), 270 - (float)inclination, 180F);
            path.CloseAllFigures();

            base.Region = new System.Drawing.Region(pathRegion);

            g.DrawPath(new Pen(new SolidBrush(conveyorColor), 3), path);

            //液体流动
            if (ConveyorDirection != ConveyorDirection.None)
            {
                Pen p = new Pen(new SolidBrush(Color.FromArgb(150, this.BackColor)), 4);
                p.DashPattern = new float[] { 6, 6 };
                p.DashOffset = intLineLeft * (ConveyorDirection == ConveyorDirection.Forward ? -1 : 1);
                g.DrawPath(p, path);
            }
        }
    }

    /// <summary>
    /// Enum ConveyorDirection
    /// </summary>
    public enum ConveyorDirection
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
}
