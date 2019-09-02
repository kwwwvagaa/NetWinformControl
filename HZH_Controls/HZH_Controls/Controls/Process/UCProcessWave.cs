// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCProcessWave.cs
// 作　　者：HZH
// 创建日期：2019-08-31 16:04:50
// 功能描述：UCProcessWave    English:UCProcessWave
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
// 项目地址：https://github.com/kwwwvagaa/NetWinformControl
// 如果你使用了此类，请保留以上说明
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace HZH_Controls.Controls
{
    public partial class UCProcessWave : UCControlBase
    {
        private bool m_isRectangle = false;
        [Description("是否矩形"), Category("自定义")]
        public bool IsRectangle
        {
            get { return m_isRectangle; }
            set
            {
                m_isRectangle = value;
                if (value)
                {
                    base.ConerRadius = 10;
                }
                else
                {
                    base.ConerRadius = Math.Min(this.Width, this.Height);
                }
            }
        }
        #region 不再使用的父类属性    English:Parent class attributes that are no longer used
        [Browsable(false)]
        public new int ConerRadius
        {
            get;
            set;
        }
        [Browsable(false)]
        public new bool IsRadius
        {
            get;
            set;
        }

        [Browsable(false)]
        public new Color FillColor
        {
            get;
            set;
        }
        #endregion


        [Description("值变更事件"), Category("自定义")]
        public event EventHandler ValueChanged;
        int m_value = 0;
        [Description("当前属性"), Category("自定义")]
        public int Value
        {
            set
            {
                if (value > m_maxValue)
                    m_value = m_maxValue;
                else if (value < 0)
                    m_value = 0;
                else
                    m_value = value;
                if (ValueChanged != null)
                    ValueChanged(this, null);
                ucWave1.Height = (int)((double)m_value / (double)m_maxValue * this.Height) + ucWave1.WaveHeight;
                Refresh();
            }
            get
            {
                return m_value;
            }
        }

        private int m_maxValue = 100;

        [Description("最大值"), Category("自定义")]
        public int MaxValue
        {
            get { return m_maxValue; }
            set
            {
                if (value < m_value)
                    m_maxValue = m_value;
                else
                    m_maxValue = value;
                Refresh();
            }
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        [Description("值颜色"), Category("自定义")]
        public Color ValueColor
        {
            get { return this.ucWave1.WaveColor; }
            set
            {
                this.ucWave1.WaveColor = value;
            }
        }

        [Description("边框宽度"), Category("自定义")]
        public override int RectWidth
        {
            get
            {
                return base.RectWidth;
            }
            set
            {
                if (value < 4)
                    base.RectWidth = 4;
                else
                    base.RectWidth = value;
            }
        }

        public UCProcessWave()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            base.IsRadius = true;
            base.IsShowRect = false;
            RectWidth = 4;
            RectColor = Color.White;
            ForeColor = Color.White;
            ucWave1.Height = (int)((double)m_value / (double)m_maxValue * this.Height) + ucWave1.WaveHeight;
            this.SizeChanged += UCProcessWave_SizeChanged;
            this.ucWave1.OnPainted += ucWave1_Painted;
            base.ConerRadius = Math.Min(this.Width, this.Height);
        }

        void ucWave1_Painted(object sender, PaintEventArgs e)
        {
            e.Graphics.SetGDIHigh();
            if (IsShowRect)
            {
                if (m_isRectangle)
                {
                    Color rectColor = RectColor;
                    Pen pen = new Pen(rectColor, (float)RectWidth);
                    Rectangle clientRectangle = new Rectangle(0, this.ucWave1.Height - this.Height, this.Width, this.Height);
                    GraphicsPath graphicsPath = new GraphicsPath();
                    graphicsPath.AddArc(clientRectangle.X, clientRectangle.Y, 10, 10, 180f, 90f);
                    graphicsPath.AddArc(clientRectangle.Width - 10 - 1, clientRectangle.Y, 10, 10, 270f, 90f);
                    graphicsPath.AddArc(clientRectangle.Width - 10 - 1, clientRectangle.Bottom - 10 - 1, 10, 10, 0f, 90f);
                    graphicsPath.AddArc(clientRectangle.X, clientRectangle.Bottom - 10 - 1, 10, 10, 90f, 90f);
                    graphicsPath.CloseFigure();
                    e.Graphics.DrawPath(pen, graphicsPath);
                }
                else
                {
                    SolidBrush solidBrush = new SolidBrush(RectColor);
                    e.Graphics.DrawEllipse(new Pen(solidBrush, RectWidth), new Rectangle(0, this.ucWave1.Height - this.Height, this.Width, this.Height));
                }
            }

            if (!m_isRectangle)
            {
                //这里曲线救国，因为设置了控件区域导致的毛边，通过画一个没有毛边的圆遮挡
                SolidBrush solidBrush1 = new SolidBrush(RectColor);
                e.Graphics.DrawEllipse(new Pen(solidBrush1, 2), new Rectangle(-1, this.ucWave1.Height - this.Height - 1, this.Width + 2, this.Height + 2));
            }
            string strValue = ((double)m_value / (double)m_maxValue).ToString("0.%");
            System.Drawing.SizeF sizeF = e.Graphics.MeasureString(strValue, Font);
            e.Graphics.DrawString(strValue, Font, new SolidBrush(ForeColor), new PointF((this.Width - sizeF.Width) / 2, (this.ucWave1.Height - this.Height) + (this.Height - sizeF.Height) / 2));
        }

        void UCProcessWave_SizeChanged(object sender, EventArgs e)
        {
            if (!m_isRectangle)
            {
                base.ConerRadius = Math.Min(this.Width, this.Height);
                if (this.Width != this.Height)
                {
                    this.Size = new Size(Math.Min(this.Width, this.Height), Math.Min(this.Width, this.Height));
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SetGDIHigh();
            if (!m_isRectangle)
            {
                //这里曲线救国，因为设置了控件区域导致的毛边，通过画一个没有毛边的圆遮挡
                SolidBrush solidBrush = new SolidBrush(RectColor);
                e.Graphics.DrawEllipse(new Pen(solidBrush, 2), new Rectangle(-1, -1, this.Width + 2, this.Height + 2));
            }
            string strValue = ((double)m_value / (double)m_maxValue).ToString("0.%");
            System.Drawing.SizeF sizeF = e.Graphics.MeasureString(strValue, Font);
            e.Graphics.DrawString(strValue, Font, new SolidBrush(ForeColor), new PointF((this.Width - sizeF.Width) / 2, (this.Height - sizeF.Height) / 2 + 1));
        }
    }
}
