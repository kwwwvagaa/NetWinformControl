// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-23-2019
//
// ***********************************************************************
// <copyright file="UCProcessWave.cs">
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

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCProcessWave.
    /// Implements the <see cref="HZH_Controls.Controls.UCControlBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.UCControlBase" />
    public partial class UCProcessWave : UCControlBase
    {
        /// <summary>
        /// The m is rectangle
        /// </summary>
        private bool m_isRectangle = false;
        /// <summary>
        /// Gets or sets a value indicating whether this instance is rectangle.
        /// </summary>
        /// <value><c>true</c> if this instance is rectangle; otherwise, <c>false</c>.</value>
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
        /// <summary>
        /// 圆角角度
        /// </summary>
        /// <value>The coner radius.</value>
        [Browsable(false)]
        public new int ConerRadius
        {
            get;
            set;
        }
        /// <summary>
        /// 是否圆角
        /// </summary>
        /// <value><c>true</c> if this instance is radius; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public new bool IsRadius
        {
            get;
            set;
        }

        /// <summary>
        /// 当使用边框时填充颜色，当值为背景色或透明色或空值则不填充
        /// </summary>
        /// <value>The color of the fill.</value>
        [Browsable(false)]
        public new Color FillColor
        {
            get;
            set;
        }
        #endregion


        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        [Description("值变更事件"), Category("自定义")]
        public event EventHandler ValueChanged;
        /// <summary>
        /// The m value
        /// </summary>
        int m_value = 0;
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
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

        /// <summary>
        /// The m maximum value
        /// </summary>
        private int m_maxValue = 100;

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
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

        /// <summary>
        /// 获取或设置控件显示的文字的字体。
        /// </summary>
        /// <value>The font.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
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

        /// <summary>
        /// 获取或设置控件的前景色。
        /// </summary>
        /// <value>The color of the fore.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
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

        /// <summary>
        /// Gets or sets the color of the value.
        /// </summary>
        /// <value>The color of the value.</value>
        [Description("值颜色"), Category("自定义")]
        public Color ValueColor
        {
            get { return this.ucWave1.WaveColor; }
            set
            {
                this.ucWave1.WaveColor = value;
            }
        }

        /// <summary>
        /// 边框宽度
        /// </summary>
        /// <value>The width of the rect.</value>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="UCProcessWave" /> class.
        /// </summary>
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

        /// <summary>
        /// Handles the Painted event of the ucWave1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the SizeChanged event of the UCProcessWave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs" /> instance containing the event data.</param>
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
