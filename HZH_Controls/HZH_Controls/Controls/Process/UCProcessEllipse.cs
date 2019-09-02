// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCProcessEllipse.cs
// 作　　者：HZH
// 创建日期：2019-08-31 16:04:30
// 功能描述：UCProcessEllipse    English:UCProcessEllipse
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
    public partial class UCProcessEllipse : UserControl
    {
        [Description("值改变事件"), Category("自定义")]
        public event EventHandler ValueChanged;

        private Color m_backEllipseColor = Color.FromArgb(228, 231, 237);
        /// <summary>
        /// 圆背景色
        /// </summary>
        [Description("圆背景色"), Category("自定义")]
        public Color BackEllipseColor
        {
            get { return m_backEllipseColor; }
            set
            {
                m_backEllipseColor = value;
                Refresh();
            }
        }

        private Color m_coreEllipseColor = Color.FromArgb(228, 231, 237);
        /// <summary>
        /// 内圆颜色，ShowType=Ring 有效
        /// </summary>
        [Description("内圆颜色，ShowType=Ring 有效"), Category("自定义")]
        public Color CoreEllipseColor
        {
            get { return m_coreEllipseColor; }
            set
            {
                m_coreEllipseColor = value;
                Refresh();
            }
        }

        private Color m_valueColor = Color.FromArgb(255, 77, 59);

        [Description("值圆颜色"), Category("自定义")]
        public Color ValueColor
        {
            get { return m_valueColor; }
            set
            {
                m_valueColor = value;
                Refresh();
            }
        }

        private bool m_isShowCoreEllipseBorder = true;
        /// <summary>
        /// 内圆是否显示边框，ShowType=Ring 有效
        /// </summary>
        [Description("内圆是否显示边框，ShowType=Ring 有效"), Category("自定义")]
        public bool IsShowCoreEllipseBorder
        {
            get { return m_isShowCoreEllipseBorder; }
            set
            {
                m_isShowCoreEllipseBorder = value;
                Refresh();
            }
        }

        private ValueType m_valueType = ValueType.Percent;
        /// <summary>
        /// 值文字类型
        /// </summary>
        [Description("值文字类型"), Category("自定义")]
        public ValueType ValueType
        {
            get { return m_valueType; }
            set
            {
                m_valueType = value;
                Refresh();
            }
        }

        private int m_valueWidth = 30;
        /// <summary>
        /// 外圆值宽度
        /// </summary>
        [Description("外圆值宽度，ShowType=Ring 有效"), Category("自定义")]
        public int ValueWidth
        {
            get { return m_valueWidth; }
            set
            {
                if (value <= 0 || value > Math.Min(this.Width, this.Height))
                    return;
                m_valueWidth = value;
                Refresh();
            }
        }

        private int m_valueMargin = 5;
        /// <summary>
        /// 外圆值间距
        /// </summary>
        [Description("外圆值间距"), Category("自定义")]
        public int ValueMargin
        {
            get { return m_valueMargin; }
            set
            {
                if (value < 0 || m_valueMargin >= m_valueWidth)
                    return;
                m_valueMargin = value;
                Refresh();
            }
        }

        private int m_maxValue = 100;
        /// <summary>
        /// 最大值
        /// </summary>
        [Description("最大值"), Category("自定义")]
        public int MaxValue
        {
            get { return m_maxValue; }
            set
            {
                if (value > m_value || value <= 0)
                    return;
                m_maxValue = value;
                Refresh();
            }
        }

        private int m_value = 0;
        /// <summary>
        /// 当前值
        /// </summary>
        [Description("当前值"), Category("自定义")]
        public int Value
        {
            get { return m_value; }
            set
            {
                if (m_maxValue < value || value < 0)
                    return;
                m_value = value;
                if (ValueChanged != null)
                {
                    ValueChanged(this, null);
                }
                Refresh();
            }
        }
        private Font m_font = new Font("Arial Unicode MS", 20);
        [Description("文字字体"), Category("自定义")]
        public override Font Font
        {
            get
            {
                return m_font;
            }
            set
            {
                m_font = value;
                Refresh();
            }
        }
        Color m_foreColor = Color.White;
        [Description("文字颜色"), Category("自定义")]
        public override Color ForeColor
        {
            get
            {
                return m_foreColor;
            }
            set
            {
                m_foreColor = value;
                Refresh();
            }
        }

        private ShowType m_showType = ShowType.Ring;

        [Description("显示类型"), Category("自定义")]
        public ShowType ShowType
        {
            get { return m_showType; }
            set
            {
                m_showType = value;
                Refresh();
            }
        }

        public UCProcessEllipse()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SetGDIHigh();

            int intWidth = Math.Min(this.Size.Width, this.Size.Height) - 1;
            //底圆
            g.FillEllipse(new SolidBrush(m_backEllipseColor), new Rectangle(new Point(0, 0), new Size(intWidth, intWidth)));
            if (m_showType == HZH_Controls.Controls.ShowType.Ring)
            {
                //中心圆
                int intCore = intWidth - m_valueWidth * 2;
                g.FillEllipse(new SolidBrush(m_coreEllipseColor), new Rectangle(new Point(m_valueWidth, m_valueWidth), new Size(intCore, intCore)));
                //中心圆边框
                if (m_isShowCoreEllipseBorder)
                {
                    g.DrawEllipse(new Pen(m_valueColor, 2), new Rectangle(new Point(m_valueWidth + 1, m_valueWidth + 1), new Size(intCore - 1, intCore - 1)));
                }
                if (m_value > 0 && m_maxValue > 0)
                {
                    float fltPercent = (float)m_value / (float)m_maxValue;
                    if (fltPercent > 1)
                    {
                        fltPercent = 1;
                    }

                    g.DrawArc(new Pen(m_valueColor, m_valueWidth - m_valueMargin * 2), new RectangleF(new Point(m_valueWidth / 2 + m_valueMargin / 4, m_valueWidth / 2 + m_valueMargin / 4), new SizeF(intWidth - m_valueWidth - m_valueMargin / 2 + (m_valueMargin == 0 ? 0 : 1), intWidth - m_valueWidth - m_valueMargin / 2 + (m_valueMargin == 0 ? 0 : 1))), -90, fltPercent * 360);

                    string strValueText = m_valueType == HZH_Controls.Controls.ValueType.Percent ? fltPercent.ToString("0%") : m_value.ToString();
                    System.Drawing.SizeF _txtSize = g.MeasureString(strValueText, this.Font);
                    g.DrawString(strValueText, this.Font, new SolidBrush(this.ForeColor), new PointF((intWidth - _txtSize.Width) / 2 + 1, (intWidth - _txtSize.Height) / 2 + 1));
                }
            }
            else
            {
                if (m_value > 0 && m_maxValue > 0)
                {
                    float fltPercent = (float)m_value / (float)m_maxValue;
                    if (fltPercent > 1)
                    {
                        fltPercent = 1;
                    }

                    g.FillPie(new SolidBrush(m_valueColor), new Rectangle(m_valueMargin, m_valueMargin, intWidth - m_valueMargin * 2, intWidth - m_valueMargin * 2), -90, fltPercent * 360);

                    string strValueText = m_valueType == HZH_Controls.Controls.ValueType.Percent ? fltPercent.ToString("0%") : m_value.ToString();
                    System.Drawing.SizeF _txtSize = g.MeasureString(strValueText, this.Font);
                    g.DrawString(strValueText, this.Font, new SolidBrush(this.ForeColor), new PointF((intWidth - _txtSize.Width) / 2 + 1, (intWidth - _txtSize.Height) / 2 + 1));
                }
            }

        }
    }

    public enum ValueType
    {
        /// <summary>
        /// 百分比
        /// </summary>
        Percent,
        /// <summary>
        /// 数值
        /// </summary>
        Absolute
    }

    public enum ShowType
    {
        /// <summary>
        /// 圆环
        /// </summary>
        Ring,
        /// <summary>
        /// 扇形
        /// </summary>
        Sector
    }
}
