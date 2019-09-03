// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-20-2019
//
// ***********************************************************************
// <copyright file="UCProcessLine.cs">
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
    /// Class UCProcessLine.
    /// Implements the <see cref="System.Windows.Forms.Control" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("ValueChanged")]
    public class UCProcessLine : Control
    {
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
        /// The m value color
        /// </summary>
        Color m_valueColor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the color of the value.
        /// </summary>
        /// <value>The color of the value.</value>
        [Description("值进度条颜色"), Category("自定义")]
        public Color ValueColor
        {
            get { return m_valueColor; }
            set
            {
                m_valueColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// The m value bg color
        /// </summary>
        private Color m_valueBGColor = Color.FromArgb(228, 231, 237);

        /// <summary>
        /// Gets or sets the color of the value bg.
        /// </summary>
        /// <value>The color of the value bg.</value>
        [Description("值背景色"), Category("自定义")]
        public Color ValueBGColor
        {
            get { return m_valueBGColor; }
            set
            {
                m_valueBGColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// The m border color
        /// </summary>
        private Color m_borderColor = Color.FromArgb(228, 231, 237);

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Description("边框颜色"), Category("自定义")]
        public Color BorderColor
        {
            get { return m_borderColor; }
            set
            {
                m_borderColor = value;
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
        [Description("值字体"), Category("自定义")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                Refresh();
            }
        }

        /// <summary>
        /// 获取或设置控件的前景色。
        /// </summary>
        /// <value>The color of the fore.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [Description("值字体颜色"), Category("自定义")]
        public override System.Drawing.Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                Refresh();
            }
        }
        /// <summary>
        /// The m value text type
        /// </summary>
        private ValueTextType m_valueTextType = ValueTextType.Percent;

        /// <summary>
        /// Gets or sets the type of the value text.
        /// </summary>
        /// <value>The type of the value text.</value>
        [Description("值显示样式"), Category("自定义")]
        public ValueTextType ValueTextType
        {
            get { return m_valueTextType; }
            set
            {
                m_valueTextType = value;
                Refresh();
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UCProcessLine" /> class.
        /// </summary>
        public UCProcessLine()
        {
            Size = new Size(200, 15);
            ForeColor = Color.White;
            Font = new Font("Arial Unicode MS", 10);
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
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SetGDIHigh();

            Brush sb = new SolidBrush(m_valueBGColor);
            g.FillRectangle(sb, new Rectangle(base.ClientRectangle.X, base.ClientRectangle.Y, base.ClientRectangle.Width - 3, base.ClientRectangle.Height - 2));
            GraphicsPath path1 = ControlHelper.CreateRoundedRectanglePath(new Rectangle(base.ClientRectangle.X, base.ClientRectangle.Y + 1, base.ClientRectangle.Width - 3, base.ClientRectangle.Height - 4), 2);
            g.DrawPath(new Pen(m_borderColor, 1), path1);
            LinearGradientBrush lgb = new LinearGradientBrush(new Point(0, 0), new Point(0, base.ClientRectangle.Height - 3), m_valueColor, Color.FromArgb(250, m_valueColor.R, m_valueColor.G, m_valueColor.B));
            g.FillPath(lgb, ControlHelper.CreateRoundedRectanglePath(new Rectangle(0, (base.ClientRectangle.Height - (base.ClientRectangle.Height - 3)) / 2, (base.ClientRectangle.Width - 3) * Value / m_maxValue, base.ClientRectangle.Height - 4), 2));
            string strValue = string.Empty;
            if (m_valueTextType == HZH_Controls.Controls.ValueTextType.Percent)
                strValue = ((float)Value / (float)m_maxValue).ToString("0%");
            else if (m_valueTextType == HZH_Controls.Controls.ValueTextType.Absolute)
                strValue = Value + "/" + m_maxValue;
            if (!string.IsNullOrEmpty(strValue))
            {
                System.Drawing.SizeF sizeF = g.MeasureString(strValue, Font);
                g.DrawString(strValue, Font, new SolidBrush(ForeColor), new PointF((this.Width - sizeF.Width) / 2, (this.Height - sizeF.Height) / 2 + 1));
            }
        }

    }

    /// <summary>
    /// Enum ValueTextType
    /// </summary>
    public enum ValueTextType
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// 百分比
        /// </summary>
        Percent,
        /// <summary>
        /// 数值
        /// </summary>
        Absolute
    }
}
