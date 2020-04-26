// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-10
//
// ***********************************************************************
// <copyright file="UCThermometer.cs">
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
    /// Class UCThermometer.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCThermometer : UserControl
    {
        /// <summary>
        /// The glass tube color
        /// </summary>
        private Color glassTubeColor = Color.FromArgb(211, 211, 211);

        /// <summary>
        /// Gets or sets the color of the glass tube.
        /// </summary>
        /// <value>The color of the glass tube.</value>
        [Description("玻璃管颜色"), Category("自定义")]
        public Color GlassTubeColor
        {
            get { return glassTubeColor; }
            set
            {
                glassTubeColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// The mercury color
        /// </summary>
        private Color mercuryColor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the color of the mercury.
        /// </summary>
        /// <value>The color of the mercury.</value>
        [Description("水印颜色"), Category("自定义")]
        public Color MercuryColor
        {
            get { return mercuryColor; }
            set
            {
                mercuryColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// The minimum value
        /// </summary>
        private decimal minValue = 0;
        /// <summary>
        /// 左侧刻度最小值
        /// </summary>
        /// <value>The minimum value.</value>
        [Description("左侧刻度最小值"), Category("自定义")]
        public decimal MinValue
        {
            get { return minValue; }
            set
            {
                minValue = value;
                Refresh();
            }
        }

        /// <summary>
        /// The maximum value
        /// </summary>
        private decimal maxValue = 100;
        /// <summary>
        /// 左侧刻度最大值
        /// </summary>
        /// <value>The maximum value.</value>
        [Description("左侧刻度最大值"), Category("自定义")]
        public decimal MaxValue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
                Refresh();
            }
        }

        /// <summary>
        /// The m value
        /// </summary>
        private decimal m_value = 10;
        /// <summary>
        /// 左侧刻度值
        /// </summary>
        /// <value>The value.</value>
        [Description("左侧刻度值"), Category("自定义")]
        public decimal Value
        {
            get { return m_value; }
            set
            {
                m_value = value;
                Refresh();
            }
        }

        /// <summary>
        /// The split count
        /// </summary>
        private int splitCount = 1;
        /// <summary>
        /// 刻度分隔份数
        /// </summary>
        /// <value>The split count.</value>
        [Description("刻度分隔份数"), Category("自定义")]
        public int SplitCount
        {
            get { return splitCount; }
            set
            {
                if (value <= 0)
                    return;
                splitCount = value;
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
        [Description("获取或设置控件显示的文字的字体"), Category("自定义")]
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
        [Description("获取或设置控件的文字及刻度颜色"), Category("自定义")]
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
        /// The left temperature unit
        /// </summary>
        private TemperatureUnit leftTemperatureUnit = TemperatureUnit.C;
        /// <summary>
        /// 左侧刻度单位，不可为none
        /// </summary>
        /// <value>The left temperature unit.</value>
        [Description("左侧刻度单位，不可为none"), Category("自定义")]
        public TemperatureUnit LeftTemperatureUnit
        {
            get { return leftTemperatureUnit; }
            set
            {
                if (value == TemperatureUnit.None)
                    return;
                leftTemperatureUnit = value;
                Refresh();
            }
        }

        /// <summary>
        /// The right temperature unit
        /// </summary>
        private TemperatureUnit rightTemperatureUnit = TemperatureUnit.C;
        /// <summary>
        /// 右侧刻度单位，当为none时，不显示
        /// </summary>
        /// <value>The right temperature unit.</value>
        [Description("右侧刻度单位，当为none时，不显示"), Category("自定义")]
        public TemperatureUnit RightTemperatureUnit
        {
            get { return rightTemperatureUnit; }
            set
            {
                rightTemperatureUnit = value;
                Refresh();
            }
        }

        /// <summary>
        /// The m rect working
        /// </summary>
        Rectangle m_rectWorking;
        /// <summary>
        /// The m rect left
        /// </summary>
        Rectangle m_rectLeft;
        /// <summary>
        /// The m rect right
        /// </summary>
        Rectangle m_rectRight;
        /// <summary>
        /// Initializes a new instance of the <see cref="UCThermometer" /> class.
        /// </summary>
        public UCThermometer()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.SizeChanged += UCThermometer_SizeChanged;
            this.Size = new Size(70, 200);
        }

        /// <summary>
        /// Handles the SizeChanged event of the UCThermometer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void UCThermometer_SizeChanged(object sender, EventArgs e)
        {
            m_rectWorking = new Rectangle(this.Width / 2 - this.Width / 8, this.Width / 4, this.Width / 4, this.Height - this.Width / 2);
            m_rectLeft = new Rectangle(0, m_rectWorking.Top + m_rectWorking.Width / 2, (this.Width - this.Width / 4) / 2 - 2, m_rectWorking.Height - m_rectWorking.Width * 2);
            m_rectRight = new Rectangle(this.Width - (this.Width - this.Width / 4) / 2 + 2, m_rectWorking.Top + m_rectWorking.Width / 2, (this.Width - this.Width / 4) / 2 - 2, m_rectWorking.Height - m_rectWorking.Width * 2);
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

            //玻璃管管
            GraphicsPath path = new GraphicsPath();
            path.AddLine(m_rectWorking.Left, m_rectWorking.Bottom, m_rectWorking.Left, m_rectWorking.Top + m_rectWorking.Width / 2);
            path.AddArc(new Rectangle(m_rectWorking.Left, m_rectWorking.Top, m_rectWorking.Width, m_rectWorking.Width), 180, 180);
            path.AddLine(m_rectWorking.Right, m_rectWorking.Top + m_rectWorking.Width / 2, m_rectWorking.Right, m_rectWorking.Bottom);
            path.CloseAllFigures();
            g.FillPath(new SolidBrush(glassTubeColor), path);

            //底部
            var rectDi = new Rectangle(this.Width / 2 - m_rectWorking.Width, m_rectWorking.Bottom - m_rectWorking.Width - 2, m_rectWorking.Width * 2, m_rectWorking.Width * 2);
            g.FillEllipse(new SolidBrush(glassTubeColor), rectDi);
            g.FillEllipse(new SolidBrush(mercuryColor), new Rectangle(rectDi.Left + 4, rectDi.Top + 4, rectDi.Width - 8, rectDi.Height - 8));

            //刻度
            decimal decSplit = (maxValue - minValue) / splitCount;
            decimal decSplitHeight = m_rectLeft.Height / splitCount;
            for (int i = 0; i <= splitCount; i++)
            {
                g.DrawLine(new Pen(new SolidBrush(ForeColor), 1), new PointF(m_rectLeft.Left + 2, (float)(m_rectLeft.Bottom - decSplitHeight * i)), new PointF(m_rectLeft.Right, (float)(m_rectLeft.Bottom - decSplitHeight * i)));

                var valueLeft = (minValue + decSplit * i).ToString("0.##");
                var sizeLeft = g.MeasureString(valueLeft, Font);
                g.DrawString(valueLeft, Font, new SolidBrush(ForeColor), new PointF(m_rectLeft.Left, m_rectLeft.Bottom - (float)decSplitHeight * i - sizeLeft.Height - 1));

                if (rightTemperatureUnit != TemperatureUnit.None)
                {
                    g.DrawLine(new Pen(new SolidBrush(Color.Black), 1), new PointF(m_rectRight.Left + 2, (float)(m_rectRight.Bottom - decSplitHeight * i)), new PointF(m_rectRight.Right, (float)(m_rectRight.Bottom - decSplitHeight * i)));
                    var valueRight = GetRightValue(minValue + decSplit * i).ToString("0.##");
                    var sizeRight = g.MeasureString(valueRight, Font);
                    g.DrawString(valueRight, Font, new SolidBrush(ForeColor), new PointF(m_rectRight.Right - sizeRight.Width - 1, m_rectRight.Bottom - (float)decSplitHeight * i - sizeRight.Height - 1));
                }
                if (i != splitCount)
                {
                    if (decSplitHeight > 40)
                    {
                        var decSp1 = decSplitHeight / 10;
                        for (int j = 1; j < 10; j++)
                        {
                            if (j == 5)
                            {
                                g.DrawLine(new Pen(new SolidBrush(ForeColor), 1), new PointF(m_rectLeft.Right - 10, (m_rectLeft.Bottom - (float)decSplitHeight * i - ((float)decSp1 * j))), new PointF(m_rectLeft.Right, (m_rectLeft.Bottom - (float)decSplitHeight * i - ((float)decSp1 * j))));
                                if (rightTemperatureUnit != TemperatureUnit.None)
                                {
                                    g.DrawLine(new Pen(new SolidBrush(ForeColor), 1), new PointF(m_rectRight.Left + 10, (m_rectRight.Bottom - (float)decSplitHeight * i - ((float)decSp1 * j))), new PointF(m_rectRight.Left, (m_rectRight.Bottom - (float)decSplitHeight * i - ((float)decSp1 * j))));
                                }
                            }
                            else
                            {
                                g.DrawLine(new Pen(new SolidBrush(ForeColor), 1), new PointF(m_rectLeft.Right - 5, (m_rectLeft.Bottom - (float)decSplitHeight * i - ((float)decSp1 * j))), new PointF(m_rectLeft.Right, (m_rectLeft.Bottom - (float)decSplitHeight * i - ((float)decSp1 * j))));
                                if (rightTemperatureUnit != TemperatureUnit.None)
                                {
                                    g.DrawLine(new Pen(new SolidBrush(ForeColor), 1), new PointF(m_rectRight.Left + 5, (m_rectRight.Bottom - (float)decSplitHeight * i - ((float)decSp1 * j))), new PointF(m_rectRight.Left, (m_rectRight.Bottom - (float)decSplitHeight * i - ((float)decSp1 * j))));
                                }
                            }
                        }
                    }
                    else if (decSplitHeight > 10)
                    {
                        g.DrawLine(new Pen(new SolidBrush(ForeColor), 1), new PointF(m_rectLeft.Right - 5, (m_rectLeft.Bottom - (float)decSplitHeight * i - (float)decSplitHeight / 2)), new PointF(m_rectLeft.Right, (m_rectLeft.Bottom - (float)decSplitHeight * i - (float)decSplitHeight / 2)));
                        if (rightTemperatureUnit != TemperatureUnit.None)
                        {
                            g.DrawLine(new Pen(new SolidBrush(ForeColor), 1), new PointF(m_rectRight.Left + 5, (m_rectRight.Bottom - (float)decSplitHeight * i - (float)decSplitHeight / 2)), new PointF(m_rectRight.Left, (m_rectRight.Bottom - (float)decSplitHeight * i - (float)decSplitHeight / 2)));
                        }
                    }
                }
            }
            //单位
            string strLeftUnit = GetUnitChar(leftTemperatureUnit);
            g.DrawString(strLeftUnit, Font, new SolidBrush(ForeColor), new PointF(m_rectLeft.Left + 2, 2));
            if (rightTemperatureUnit != TemperatureUnit.None)
            {
                string strRightUnit = GetUnitChar(rightTemperatureUnit);
                var rightSize = g.MeasureString(strRightUnit, Font);
                g.DrawString(strRightUnit, Font, new SolidBrush(ForeColor), new PointF(m_rectRight.Right - 2 - rightSize.Width, 2));
            }
            //值
            float fltHeightValue = (float)(Value / (maxValue - minValue) * m_rectLeft.Height);
            RectangleF rectValue = new RectangleF(m_rectWorking.Left + 4, m_rectLeft.Top + (m_rectLeft.Height - fltHeightValue), m_rectWorking.Width - 8, fltHeightValue + (m_rectWorking.Height - m_rectWorking.Width / 2 - m_rectLeft.Height));
            g.FillRectangle(new SolidBrush(mercuryColor), rectValue);


            var sizeValue = g.MeasureString(m_value.ToString("0.##"), Font);
            g.DrawString(m_value.ToString("0.##"), Font, new SolidBrush(Color.White), new PointF(rectDi.Left + (rectDi.Width - sizeValue.Width) / 2, rectDi.Top + (rectDi.Height - sizeValue.Height) / 2 + 1));
        }

        /// <summary>
        /// Gets the unit character.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns>System.String.</returns>
        private string GetUnitChar(TemperatureUnit unit)
        {
            string strUnit = "℃";
            switch (unit)
            {
                case TemperatureUnit.C:
                    strUnit = "℃";
                    break;
                case TemperatureUnit.F:
                    strUnit = "℉";
                    break;
                case TemperatureUnit.K:
                    strUnit = "K";
                    break;
                case TemperatureUnit.R:
                    strUnit = "°R";
                    break;
                case TemperatureUnit.Re:
                    strUnit = "°Re";
                    break;
            }
            return strUnit;
        }

        /// <summary>
        /// Gets the right value.
        /// </summary>
        /// <param name="decValue">The decimal value.</param>
        /// <returns>System.Decimal.</returns>
        private decimal GetRightValue(decimal decValue)
        {
            //先将左侧的换算为摄氏度
            var dec = decValue;
            switch (leftTemperatureUnit)
            {
                case TemperatureUnit.F:
                    dec = (decValue - 32) / (9M / 5M);
                    break;
                case TemperatureUnit.K:
                    dec = decValue - 273;
                    break;
                case TemperatureUnit.R:
                    dec = decValue / (5M / 9M) - 273.15M;
                    break;
                case TemperatureUnit.Re:
                    dec = decValue / 1.25M;
                    break;
                default:
                    break;
            }

            switch (rightTemperatureUnit)
            {
                case TemperatureUnit.C:
                    return dec;
                case TemperatureUnit.F:
                    return 9M / 5M * dec + 32;
                case TemperatureUnit.K:
                    return dec + 273;
                case TemperatureUnit.R:
                    return (dec + 273.15M) * (5M / 9M);
                case TemperatureUnit.Re:
                    return dec * 1.25M;
            }
            return decValue;
        }
    }

    /// <summary>
    /// Enum TemperatureUnit
    /// </summary>
    public enum TemperatureUnit
    {
        /// <summary>
        /// 不显示
        /// </summary>
        None,
        /// <summary>
        /// 摄氏度
        /// </summary>
        C,
        /// <summary>
        /// 华氏度
        /// </summary>
        F,
        /// <summary>
        /// 开氏度
        /// </summary>
        K,
        /// <summary>
        /// 兰氏度
        /// </summary>
        R,
        /// <summary>
        /// 列氏度
        /// </summary>
        Re
    }
}
