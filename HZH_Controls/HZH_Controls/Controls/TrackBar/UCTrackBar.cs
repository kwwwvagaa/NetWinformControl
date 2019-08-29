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
    public class UCTrackBar : Control
    {
        [Description("值改变事件"), Category("自定义")]
        public event EventHandler ValueChanged;

        private int dcimalDigits = 0;

        [Description("值小数精确位数"), Category("自定义")]
        public int DcimalDigits
        {
            get { return dcimalDigits; }
            set { dcimalDigits = value; }
        }

        private float lineWidth = 10;

        [Description("线宽度"), Category("自定义")]
        public float LineWidth
        {
            get { return lineWidth; }
            set { lineWidth = value; }
        }

        private float minValue = 0;

        [Description("最小值"), Category("自定义")]
        public float MinValue
        {
            get { return minValue; }
            set
            {
                if (minValue > m_value)
                    return;
                minValue = value;
                this.Refresh();
            }
        }

        private float maxValue = 100;

        [Description("最大值"), Category("自定义")]
        public float MaxValue
        {
            get { return maxValue; }
            set
            {
                if (value < m_value)
                    return;
                maxValue = value;
                this.Refresh();
            }
        }

        private float m_value = 0;

        [Description("值"), Category("自定义")]
        public float Value
        {
            get { return this.m_value; }
            set
            {
                if (value > maxValue || value < minValue)
                    return;
                var v = (float)Math.Round((double)value, dcimalDigits);
                if (value == v)
                    return;
                this.m_value = v;
                this.Refresh();
                if (ValueChanged != null)
                {
                    ValueChanged(this, null);
                }
            }
        }

        private Color m_lineColor = Color.FromArgb(255, 77, 59);

        [Description("线颜色"), Category("自定义")]
        public Color LineColor
        {
            get { return m_lineColor; }
            set
            {
                m_lineColor = value;
                this.Refresh();
            }
        }
        RectangleF m_lineRectangle;
        RectangleF m_trackRectangle;

        public UCTrackBar()
        {
            this.Size = new Size(250, 30);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MouseDown += UCTrackBar_MouseDown;
            this.MouseMove += UCTrackBar_MouseMove;
            this.MouseUp += UCTrackBar_MouseUp;
        }

        bool blnDown = false;
        void UCTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_lineRectangle.Contains(e.Location) || m_trackRectangle.Contains(e.Location))
            {
                blnDown = true;
                Value = ((float)e.Location.X / (float)this.Width) * (maxValue - minValue);
            }
        }
        void UCTrackBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnDown)
            {
                Value = ((float)e.Location.X / (float)this.Width) * (maxValue - minValue);
            }
        }
        void UCTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            blnDown = false;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SetGDIHigh();
            m_lineRectangle = new RectangleF(lineWidth, (this.Size.Height - lineWidth) / 2, this.Size.Width - lineWidth * 2, lineWidth);
            GraphicsPath pathLine = ControlHelper.CreateRoundedRectanglePath(m_lineRectangle, 5);
            g.FillPath(new SolidBrush(m_lineColor), pathLine);
            m_trackRectangle = new RectangleF(m_lineRectangle.Left - lineWidth + (((float)m_value / (float)(maxValue - minValue)) * (this.Size.Width - lineWidth * 2)), (this.Size.Height - lineWidth * 2) / 2, lineWidth * 2, lineWidth * 2);
            g.FillEllipse(new SolidBrush(m_lineColor), m_trackRectangle);
            g.FillEllipse(Brushes.White, new RectangleF(m_trackRectangle.X + m_trackRectangle.Width / 4, m_trackRectangle.Y + m_trackRectangle.Height / 4, m_trackRectangle.Width / 2, m_trackRectangle.Height / 2));
        }
    }
}
