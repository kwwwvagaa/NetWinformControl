// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-03
//
// ***********************************************************************
// <copyright file="UCMeter.cs">
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
    /// Class UCMeter.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCMeter : UserControl
    {
        private int splitCount = 10;
        /// <summary>
        /// Gets or sets the split count.
        /// </summary>
        /// <value>The split count.</value>
        [Description("分隔刻度数量，>1"), Category("自定义")]
        public int SplitCount
        {
            get { return splitCount; }
            set
            {
                if (value < 1)
                    return;
                splitCount = value;
                Refresh();
            }
        }

        private int meterDegrees = 150;
        /// <summary>
        /// Gets or sets the meter degrees.
        /// </summary>
        /// <value>The meter degrees.</value>
        [Description("表盘跨度角度，0-360"), Category("自定义")]
        public int MeterDegrees
        {
            get { return meterDegrees; }
            set
            {
                if (value > 360 || value <= 0)
                    return;
                meterDegrees = value;
                Refresh();
            }
        }

        private decimal minValue = 0;
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        [Description("最小值,<MaxValue"), Category("自定义")]
        public decimal MinValue
        {
            get { return minValue; }
            set
            {
                if (value >= maxValue)
                    return;
                minValue = value;
                Refresh();
            }
        }

        private decimal maxValue = 100;
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        [Description("最大值,>MinValue"), Category("自定义")]
        public decimal MaxValue
        {
            get { return maxValue; }
            set
            {
                if (value <= minValue)
                    return;
                maxValue = value;
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
        [Description("刻度字体"), Category("自定义")]
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

        private decimal m_value = 0;
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Description("值，>=MinValue并且<=MaxValue"), Category("自定义")]
        public decimal Value
        {
            get { return m_value; }
            set
            {
                if (value < minValue || value > maxValue)
                    return;
                m_value = value;
                Refresh();
            }
        }

        private MeterTextLocation textLocation = MeterTextLocation.None;
        /// <summary>
        /// Gets or sets the text location.
        /// </summary>
        /// <value>The text location.</value>
        [Description("值和固定文字显示位置"), Category("自定义")]
        public MeterTextLocation TextLocation
        {
            get { return textLocation; }
            set
            {
                textLocation = value;
                Refresh();
            }
        }

        private string fixedText;
        /// <summary>
        /// Gets or sets the fixed text.
        /// </summary>
        /// <value>The fixed text.</value>
        [Description("固定文字"), Category("自定义")]
        public string FixedText
        {
            get { return fixedText; }
            set
            {
                fixedText = value;
                Refresh();
            }
        }

        private Font textFont = DefaultFont;
        /// <summary>
        /// Gets or sets the text font.
        /// </summary>
        /// <value>The text font.</value>
        [Description("值和固定文字字体"), Category("自定义")]
        public Font TextFont
        {
            get { return textFont; }
            set
            {
                textFont = value;
                Refresh();
            }
        }

        private Color externalRoundColor = Color.FromArgb(255, 77, 59);
        /// <summary>
        /// Gets or sets the color of the external round.
        /// </summary>
        /// <value>The color of the external round.</value>
        [Description("外圆颜色"), Category("自定义")]
        public Color ExternalRoundColor
        {
            get { return externalRoundColor; }
            set
            {
                externalRoundColor = value;
                Refresh();
            }
        }

        private Color insideRoundColor = Color.FromArgb(255, 77, 59);
        /// <summary>
        /// Gets or sets the color of the inside round.
        /// </summary>
        /// <value>The color of the inside round.</value>
        [Description("内圆颜色"), Category("自定义")]
        public Color InsideRoundColor
        {
            get { return insideRoundColor; }
            set
            {
                insideRoundColor = value;
                Refresh();
            }
        }

        private Color boundaryLineColor = Color.FromArgb(255, 77, 59);
        /// <summary>
        /// Gets or sets the color of the boundary line.
        /// </summary>
        /// <value>The color of the boundary line.</value>
        [Description("边界线颜色"), Category("自定义")]
        public Color BoundaryLineColor
        {
            get { return boundaryLineColor; }
            set
            {
                boundaryLineColor = value;
                Refresh();
            }
        }

        private Color scaleColor = Color.FromArgb(255, 77, 59);
        /// <summary>
        /// Gets or sets the color of the scale.
        /// </summary>
        /// <value>The color of the scale.</value>
        [Description("刻度颜色"), Category("自定义")]
        public Color ScaleColor
        {
            get { return scaleColor; }
            set
            {
                scaleColor = value;
                Refresh();
            }
        }

        private Color scaleValueColor = Color.FromArgb(255, 77, 59);
        /// <summary>
        /// Gets or sets the color of the scale value.
        /// </summary>
        /// <value>The color of the scale value.</value>
        [Description("刻度值文字颜色"), Category("自定义")]
        public Color ScaleValueColor
        {
            get { return scaleValueColor; }
            set
            {
                scaleValueColor = value;
                Refresh();
            }
        }

        private Color pointerColor = Color.FromArgb(255, 77, 59);
        /// <summary>
        /// Gets or sets the color of the pointer.
        /// </summary>
        /// <value>The color of the pointer.</value>
        [Description("指针颜色"), Category("自定义")]
        public Color PointerColor
        {
            get { return pointerColor; }
            set
            {
                pointerColor = value;
                Refresh();
            }
        }

        private Color textColor = Color.FromArgb(255, 77, 59);
        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        [Description("值和固定文字颜色"), Category("自定义")]
        public Color TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value;
                Refresh();
            }
        }

        Rectangle m_rectWorking;
        public UCMeter()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SizeChanged += UCMeter1_SizeChanged;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Size = new Size(350, 200);
        }

        void UCMeter1_SizeChanged(object sender, EventArgs e)
        {
            m_rectWorking = new Rectangle(10, 10, this.Width - 20, this.Height - 20);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();

            //外圆
            float fltStartAngle = -90 - (meterDegrees) / 2 + 360;
            var r1 = new Rectangle(m_rectWorking.Location, new Size(m_rectWorking.Width, m_rectWorking.Width));
            g.DrawArc(new Pen(new SolidBrush(externalRoundColor), 1), r1, fltStartAngle, meterDegrees);
            //内圆
            var r2 = new Rectangle(m_rectWorking.Left + (m_rectWorking.Width - m_rectWorking.Width / 4) / 2, m_rectWorking.Top + (m_rectWorking.Width - m_rectWorking.Width / 4) / 2, m_rectWorking.Width / 4, m_rectWorking.Width / 4);
            g.DrawArc(new Pen(new SolidBrush(insideRoundColor), 1), r2, fltStartAngle, meterDegrees);

            //边界线
            if (meterDegrees != 360)
            {
                float fltAngle = fltStartAngle - 180;

                float intY = (float)(m_rectWorking.Top + m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - m_rectWorking.Width / 8) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                float intX = (float)(m_rectWorking.Left + (m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - m_rectWorking.Width / 8) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));

                float fltY1 = (float)(m_rectWorking.Top + m_rectWorking.Width / 2 - (m_rectWorking.Width / 8 * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                float fltX1 = (float)(m_rectWorking.Left + (m_rectWorking.Width / 2 - (m_rectWorking.Width / 8 * Math.Cos(Math.PI * (fltAngle / 180.00F)))));

                g.DrawLine(new Pen(new SolidBrush(boundaryLineColor), 1), new PointF(intX, intY), new PointF(fltX1, fltY1));
                g.DrawLine(new Pen(new SolidBrush(boundaryLineColor), 1), new PointF(m_rectWorking.Right - (fltX1 - m_rectWorking.Left), fltY1), new PointF(m_rectWorking.Right - (intX - m_rectWorking.Left), intY));
            }

            //分割线
            int _splitCount = splitCount * 2;
            float fltSplitValue = (float)meterDegrees / (float)_splitCount;
            for (int i = 0; i <= _splitCount; i++)
            {
                float fltAngle = (fltStartAngle + fltSplitValue * i - 180) % 360;
                float fltY1 = (float)(m_rectWorking.Top + m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                float fltX1 = (float)(m_rectWorking.Left + (m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));
                float fltY2 = 0;
                float fltX2 = 0;
                if (i % 2 == 0)
                {
                    fltY2 = (float)(m_rectWorking.Top + m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 10) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                    fltX2 = (float)(m_rectWorking.Left + (m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 10) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));
                    if (!(meterDegrees == 360 && i == _splitCount))
                    {
                        decimal decValue = minValue + (maxValue - minValue) / _splitCount * i;
                        var txtSize = g.MeasureString(decValue.ToString("0.##"), this.Font);
                        float fltFY1 = (float)(m_rectWorking.Top - txtSize.Height / 2 + m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 20) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                        float fltFX1 = (float)(m_rectWorking.Left - txtSize.Width / 2 + (m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 20) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));
                        g.DrawString(decValue.ToString("0.##"), Font, new SolidBrush(scaleValueColor), fltFX1, fltFY1);
                    }
                }
                else
                {
                    fltY2 = (float)(m_rectWorking.Top + m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 5) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                    fltX2 = (float)(m_rectWorking.Left + (m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 5) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));
                }
                g.DrawLine(new Pen(new SolidBrush(scaleColor), i % 2 == 0 ? 2 : 1), new PointF(fltX1, fltY1), new PointF(fltX2, fltY2));
            }

            //值文字和固定文字
            if (textLocation != MeterTextLocation.None)
            {
                string str = m_value.ToString("0.##");
                var txtSize = g.MeasureString(str, textFont);
                float fltY = m_rectWorking.Top + m_rectWorking.Width / 4 - txtSize.Height / 2;
                float fltX = m_rectWorking.Left + m_rectWorking.Width / 2 - txtSize.Width / 2;
                g.DrawString(str, textFont, new SolidBrush(textColor), new PointF(fltX, fltY));

                if (!string.IsNullOrEmpty(fixedText))
                {
                    str = fixedText;
                    txtSize = g.MeasureString(str, textFont);
                    fltY = m_rectWorking.Top + m_rectWorking.Width / 4 + txtSize.Height / 2;
                    fltX = m_rectWorking.Left + m_rectWorking.Width / 2 - txtSize.Width / 2;
                    g.DrawString(str, textFont, new SolidBrush(textColor), new PointF(fltX, fltY));
                }
            }

            //画指针
            g.FillEllipse(new SolidBrush(Color.FromArgb(100, pointerColor.R, pointerColor.G, pointerColor.B)), new Rectangle(m_rectWorking.Left + m_rectWorking.Width / 2 - 10, m_rectWorking.Top + m_rectWorking.Width / 2 - 10, 20, 20));
            g.FillEllipse(new SolidBrush(pointerColor), new Rectangle(m_rectWorking.Left + m_rectWorking.Width / 2 - 5, m_rectWorking.Top + m_rectWorking.Width / 2 - 5, 10, 10));
            float fltValueAngle = (fltStartAngle + ((float)(m_value - minValue) / (float)(maxValue - minValue)) * (float)meterDegrees - 180) % 360;
            float intValueY1 = (float)(m_rectWorking.Top + m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 30) * Math.Sin(Math.PI * (fltValueAngle / 180.00F))));
            float intValueX1 = (float)(m_rectWorking.Left + (m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 30) * Math.Cos(Math.PI * (fltValueAngle / 180.00F)))));
            g.DrawLine(new Pen(new SolidBrush(pointerColor), 3), intValueX1, intValueY1, m_rectWorking.Left + m_rectWorking.Width / 2, m_rectWorking.Top + m_rectWorking.Width / 2);
        }
    }

    /// <summary>
    /// Enum MeterTextLocation
    /// </summary>
    public enum MeterTextLocation
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The top
        /// </summary>
        Top,
        /// <summary>
        /// The bottom
        /// </summary>
        Bottom
    }
}
