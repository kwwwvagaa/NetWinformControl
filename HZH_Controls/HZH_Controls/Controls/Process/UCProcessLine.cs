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
    public class UCProcessLine : Control
    {
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

        Color m_valueColor = Color.FromArgb(73, 119, 232);

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

        private Color m_valueBGColor = Color.White;

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

        private Color m_borderColor = Color.FromArgb(192, 192, 192);

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
        private ValueTextType m_valueTextType = ValueTextType.Percent;

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
        public UCProcessLine()
        {
            Size = new Size(200, 15);
            ForeColor = Color.FromArgb(255, 77, 59);
            Font = new Font("Arial Unicode MS", 10);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Console.WriteLine(DateTime.Now);
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SetGDIHigh();

            Brush sb = new SolidBrush(m_valueBGColor);
            g.FillRectangle(sb, new Rectangle(base.ClientRectangle.X, base.ClientRectangle.Y, base.ClientRectangle.Width - 3, base.ClientRectangle.Height - 2));
            GraphicsPath path1 = ControlHelper.CreateRoundedRectanglePath(new Rectangle(base.ClientRectangle.X, base.ClientRectangle.Y + 1, base.ClientRectangle.Width - 3, base.ClientRectangle.Height - 4), 3);
            g.DrawPath(new Pen(m_borderColor, 1), path1);
            LinearGradientBrush lgb = new LinearGradientBrush(new Point(0, 0), new Point(0, base.ClientRectangle.Height - 3), m_valueColor, Color.FromArgb(200, m_valueColor.R, m_valueColor.G, m_valueColor.B));
            g.FillPath(lgb, ControlHelper.CreateRoundedRectanglePath(new Rectangle(0, (base.ClientRectangle.Height - (base.ClientRectangle.Height - 3)) / 2, (base.ClientRectangle.Width - 3) * Value / m_maxValue, base.ClientRectangle.Height - 4), 3));
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

    public enum ValueTextType
    {
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
