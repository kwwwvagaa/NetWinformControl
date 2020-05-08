// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-09
//
// ***********************************************************************
// <copyright file="UCBlower.cs">
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
    /// Class UCBlower.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCBlower : UserControl
    {
        /// <summary>
        /// The entrance direction
        /// </summary>
        private BlowerEntranceDirection entranceDirection = BlowerEntranceDirection.None;

        /// <summary>
        /// Gets or sets the entrance direction.
        /// </summary>
        /// <value>The entrance direction.</value>
        [Description("入口方向"), Category("自定义")]
        public BlowerEntranceDirection EntranceDirection
        {
            get { return entranceDirection; }
            set
            {
                entranceDirection = value;
                Refresh();
            }
        }

        /// <summary>
        /// The exit direction
        /// </summary>
        private BlowerExitDirection exitDirection = BlowerExitDirection.Right;

        /// <summary>
        /// Gets or sets the exit direction.
        /// </summary>
        /// <value>The exit direction.</value>
        [Description("出口方向"), Category("自定义")]
        public BlowerExitDirection ExitDirection
        {
            get { return exitDirection; }
            set
            {
                exitDirection = value;
                Refresh();
            }
        }

        /// <summary>
        /// The blower color
        /// </summary>
        private Color blowerColor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the color of the blower.
        /// </summary>
        /// <value>The color of the blower.</value>
        [Description("风机颜色"), Category("自定义")]
        public Color BlowerColor
        {
            get { return blowerColor; }
            set
            {
                blowerColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// The fan color
        /// </summary>
        private Color fanColor = Color.FromArgb(3, 169, 243);

        /// <summary>
        /// Gets or sets the color of the fan.
        /// </summary>
        /// <value>The color of the fan.</value>
        [Description("风叶颜色"), Category("自定义")]
        public Color FanColor
        {
            get { return fanColor; }
            set
            {
                fanColor = value;
                Refresh();
            }
        }
        TurnAround turnAround = TurnAround.None;
        [Description("风叶旋转方向,None表示不旋转"), Category("自定义")]
        public TurnAround TurnAround
        {
            get { return turnAround; }
            set
            {
                turnAround = value;               
                if (value == HZH_Controls.Controls.TurnAround.None)
                {
                    timer1.Enabled = false;
                    jiaodu = 0;
                    Refresh();
                }
                else
                    timer1.Enabled = true;
            }
        }

        private int turnSpeed = 100;
        private int jiaodu = 0;
        private Timer timer1;
        private IContainer components;

        [Description("风叶旋转速度，100-1000，值越小 速度越快"), Category("自定义")]
        public int TurnSpeed
        {
            get { return turnSpeed; }
            set
            {
                if (value < 100 || value > 1000)
                    return;
                turnSpeed = value;               
                timer1.Interval = value;
            }
        }


        /// <summary>
        /// The m rect working
        /// </summary>
        Rectangle m_rectWorking;

        /// <summary>
        /// Initializes a new instance of the <see cref="UCBlower" /> class.
        /// </summary>
        public UCBlower()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.SizeChanged += UCBlower_SizeChanged;
            this.Size = new Size(120, 120);

        }

        /// <summary>
        /// Handles the SizeChanged event of the UCBlower control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void UCBlower_SizeChanged(object sender, EventArgs e)
        {
            int intMin = Math.Min(this.Width, this.Height);
            m_rectWorking = new Rectangle((this.Width - (intMin / 3 * 2)) / 2, (this.Height - (intMin / 3 * 2)) / 2, (intMin / 3 * 2), (intMin / 3 * 2));
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
            GraphicsPath pathLineIn = new GraphicsPath();
            GraphicsPath pathLineOut = new GraphicsPath();
            int intLinePenWidth = 0;

            switch (exitDirection)
            {
                case BlowerExitDirection.Left:
                    g.FillRectangle(new SolidBrush(blowerColor), new Rectangle(0, m_rectWorking.Top, this.Width / 2, m_rectWorking.Height / 2 - 5));
                    intLinePenWidth = m_rectWorking.Height / 2 - 5;
                    pathLineOut.AddLine(new Point(-10, m_rectWorking.Top + (m_rectWorking.Height / 2 - 5) / 2), new Point(m_rectWorking.Left + m_rectWorking.Width / 2, m_rectWorking.Top + (m_rectWorking.Height / 2 - 5) / 2));
                    g.DrawLine(new Pen(new SolidBrush(blowerColor), 3), new Point(1, m_rectWorking.Top - 2), new Point(1, m_rectWorking.Top + (m_rectWorking.Height / 2 - 5) + 2));
                    break;
                case BlowerExitDirection.Right:
                    g.FillRectangle(new SolidBrush(blowerColor), new Rectangle(this.Width / 2, m_rectWorking.Top, this.Width / 2, m_rectWorking.Height / 2 - 5));
                    intLinePenWidth = m_rectWorking.Height / 2 - 5;
                    pathLineOut.AddLine(new Point(this.Width + 10, m_rectWorking.Top + (m_rectWorking.Height / 2 - 5) / 2), new Point(m_rectWorking.Left + m_rectWorking.Width / 2, m_rectWorking.Top + (m_rectWorking.Height / 2 - 5) / 2));
                    g.DrawLine(new Pen(new SolidBrush(blowerColor), 3), new Point(this.Width - 2, m_rectWorking.Top - 2), new Point(this.Width - 2, m_rectWorking.Top + (m_rectWorking.Height / 2 - 5) + 2));
                    break;
                case BlowerExitDirection.Up:
                    g.FillRectangle(new SolidBrush(blowerColor), new Rectangle(m_rectWorking.Right - (m_rectWorking.Width / 2 - 5), 0, m_rectWorking.Width / 2 - 5, this.Height / 2));
                    intLinePenWidth = m_rectWorking.Width / 2 - 5;
                    pathLineOut.AddLine(new Point(m_rectWorking.Right - (m_rectWorking.Width / 2 - 5) / 2, -10), new Point(m_rectWorking.Right - (m_rectWorking.Width / 2 - 5) / 2, m_rectWorking.Top + m_rectWorking.Height / 2));
                    g.DrawLine(new Pen(new SolidBrush(blowerColor), 3), new Point(m_rectWorking.Right + 2, 1), new Point(m_rectWorking.Right - (m_rectWorking.Width / 2 - 5) - 2, 1));
                    break;
            }

            switch (entranceDirection)
            {
                case BlowerEntranceDirection.Left:
                    g.FillRectangle(new SolidBrush(blowerColor), new Rectangle(0, m_rectWorking.Bottom - m_rectWorking.Height / 2 + 5, this.Width / 2, m_rectWorking.Height / 2 - 5));
                    pathLineIn.AddLine(new Point(-10, m_rectWorking.Bottom - m_rectWorking.Height / 2 + 5 + (m_rectWorking.Height / 2 - 5) / 2), new Point(m_rectWorking.Left + m_rectWorking.Width / 2, m_rectWorking.Bottom - m_rectWorking.Height / 2 + 5 + (m_rectWorking.Height / 2 - 5) / 2));
                    g.DrawLine(new Pen(new SolidBrush(blowerColor), 3), new Point(1, m_rectWorking.Bottom - m_rectWorking.Height / 2 + 5 - 2), new Point(1, m_rectWorking.Bottom - m_rectWorking.Height / 2 + 5 + (m_rectWorking.Height / 2 - 5) + 2));
                    break;
                case BlowerEntranceDirection.Right:
                    g.FillRectangle(new SolidBrush(blowerColor), new Rectangle(this.Width / 2, m_rectWorking.Bottom - m_rectWorking.Height / 2 + 5, this.Width / 2, m_rectWorking.Height / 2 - 5));
                    pathLineIn.AddLine(new Point(this.Width + 10, m_rectWorking.Bottom - m_rectWorking.Height / 2 + 5 + (m_rectWorking.Height / 2 - 5) / 2), new Point(m_rectWorking.Left + m_rectWorking.Width / 2, m_rectWorking.Bottom - m_rectWorking.Height / 2 + 5 + (m_rectWorking.Height / 2 - 5) / 2));
                    g.DrawLine(new Pen(new SolidBrush(blowerColor), 3), new Point(this.Width - 2, m_rectWorking.Bottom - m_rectWorking.Height / 2 + 5 - 2), new Point(this.Width - 2, m_rectWorking.Bottom - m_rectWorking.Height / 2 + 5 + (m_rectWorking.Height / 2 - 5) + 2));
                    break;
                case BlowerEntranceDirection.Up:
                    g.FillRectangle(new SolidBrush(blowerColor), new Rectangle(m_rectWorking.Left, 0, m_rectWorking.Width / 2 - 5, this.Height / 2));
                    pathLineIn.AddLine(new Point(m_rectWorking.Left + (m_rectWorking.Width / 2 - 5) / 2, -10), new Point(m_rectWorking.Left + (m_rectWorking.Width / 2 - 5) / 2, m_rectWorking.Top + m_rectWorking.Height / 2));
                    g.DrawLine(new Pen(new SolidBrush(blowerColor), 3), new Point(m_rectWorking.Left - 2, 1), new Point(m_rectWorking.Left + (m_rectWorking.Width / 2 - 5) + 2, 1));
                    break;
            }

            //渐变色
            int _intPenWidth = intLinePenWidth;
            int intCount = _intPenWidth / 2 / 4;
            for (int i = 0; i < intCount; i++)
            {
                int _penWidth = _intPenWidth / 2 - 4 * i;
                if (_penWidth <= 0)
                    _penWidth = 1;
                if (entranceDirection != BlowerEntranceDirection.None)
                    g.DrawPath(new Pen(new SolidBrush(Color.FromArgb(40, Color.White.R, Color.White.G, Color.White.B)), _penWidth), pathLineIn);
                g.DrawPath(new Pen(new SolidBrush(Color.FromArgb(40, Color.White.R, Color.White.G, Color.White.B)), _penWidth), pathLineOut);
                if (_penWidth == 1)
                    break;
            }

            //底座
            GraphicsPath gpDZ = new GraphicsPath();
            gpDZ.AddLines(new Point[] 
            {
                new Point( m_rectWorking.Left+m_rectWorking.Width/2,m_rectWorking.Top+m_rectWorking.Height/2),
                new Point(m_rectWorking.Left+2,this.Height),
                new Point(m_rectWorking.Right-2,this.Height)
            });
            gpDZ.CloseAllFigures();
            g.FillPath(new SolidBrush(blowerColor), gpDZ);
            g.FillPath(new SolidBrush(Color.FromArgb(50, Color.White)), gpDZ);
            g.DrawLine(new Pen(new SolidBrush(blowerColor), 3), new Point(m_rectWorking.Left, this.Height - 2), new Point(m_rectWorking.Right, this.Height - 2));

            //中心
            g.FillEllipse(new SolidBrush(blowerColor), m_rectWorking);
            g.FillEllipse(new SolidBrush(Color.FromArgb(20, Color.White)), m_rectWorking);


            //扇叶
            Rectangle _rect = new Rectangle(m_rectWorking.Left + (m_rectWorking.Width - (m_rectWorking.Width / 3 * 2)) / 2, m_rectWorking.Top + (m_rectWorking.Height - (m_rectWorking.Width / 3 * 2)) / 2, (m_rectWorking.Width / 3 * 2), (m_rectWorking.Width / 3 * 2));

            int _splitCount = 8;
            float fltSplitValue = 360F / (float)_splitCount;
            for (int i = 0; i <= _splitCount; i++)
            {
                float fltAngle = (fltSplitValue * i - 180) % 360 + jiaodu;
                float fltY1 = (float)(_rect.Top + _rect.Width / 2 - ((_rect.Width / 2) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                float fltX1 = (float)(_rect.Left + (_rect.Width / 2 - ((_rect.Width / 2) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));
                float fltY2 = 0;
                float fltX2 = 0;

                fltY2 = (float)(_rect.Top + _rect.Width / 2 - ((_rect.Width / 4) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                fltX2 = (float)(_rect.Left + (_rect.Width / 2 - ((_rect.Width / 4) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));

                g.DrawLine(new Pen(new SolidBrush(fanColor), 2), new PointF(fltX1, fltY1), new PointF(fltX2, fltY2));
            }

            g.FillEllipse(new SolidBrush(fanColor), new Rectangle(_rect.Left + _rect.Width / 2 - _rect.Width / 4 + 2, _rect.Top + _rect.Width / 2 - _rect.Width / 4 + 2, _rect.Width / 2 - 4, _rect.Width / 2 - 4));
            g.FillEllipse(new SolidBrush(Color.FromArgb(50, Color.White)), new Rectangle(_rect.Left - 5, _rect.Top - 5, _rect.Width + 10, _rect.Height + 10));
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UCBlower
            // 
            this.Name = "UCBlower";
            this.ResumeLayout(false);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (turnAround == HZH_Controls.Controls.TurnAround.Clockwise)
            {
                jiaodu += 15;
                if (jiaodu == 45)
                    jiaodu = 0;
            }
            else if (turnAround == HZH_Controls.Controls.TurnAround.Counterclockwise)
            {
                jiaodu -= 15;
                if (jiaodu == -45)
                    jiaodu = 0;
            }

            Refresh();
        }
    }
    /// <summary>
    /// Enum BlowerEntranceDirection
    /// </summary>
    public enum BlowerEntranceDirection
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The left
        /// </summary>
        Left,
        /// <summary>
        /// The right
        /// </summary>
        Right,
        /// <summary>
        /// Up
        /// </summary>
        Up
    }

    /// <summary>
    /// Enum BlowerExitDirection
    /// </summary>
    public enum BlowerExitDirection
    {
        /// <summary>
        /// The left
        /// </summary>
        Left,
        /// <summary>
        /// The right
        /// </summary>
        Right,
        /// <summary>
        /// Up
        /// </summary>
        Up
    }
    /// <summary>
    /// 旋转方向
    /// </summary>
    public enum TurnAround
    {
        /// <summary>
        /// 不旋转
        /// </summary>
        None,
        /// <summary>
        /// 顺时针
        /// </summary>
        Clockwise,
        /// <summary>
        /// 逆时针
        /// </summary>
        Counterclockwise
    }
}
