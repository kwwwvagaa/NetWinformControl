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
    public class UCRollText : UserControl
    {
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                if (!string.IsNullOrEmpty(Text))
                {
                    Graphics g = this.CreateGraphics();
                    var size = g.MeasureString(Text, this.Font);
                    rectText = new Rectangle(0, (this.Height - rectText.Height) / 2 + 1, (int)size.Width, (int)size.Height);
                    rectText.Y = (this.Height - rectText.Height) / 2 + 1;
                }
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

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                if (!string.IsNullOrEmpty(value))
                {
                    Graphics g = this.CreateGraphics();
                    var size = g.MeasureString(value, this.Font);
                    rectText = new Rectangle(0, (this.Height - rectText.Height) / 2 + 1, (int)size.Width, (int)size.Height);
                }
                else
                {
                    rectText = Rectangle.Empty;
                }
            }
        }

        private RollStyle _RollStyle = RollStyle.LeftToRight;

        [Description("滚动样式"), Category("自定义")]
        public RollStyle RollStyle
        {
            get { return _RollStyle; }
            set
            {
                _RollStyle = value;
                switch (value)
                {
                    case RollStyle.LeftToRight:
                        m_intdirection = 1;
                        break;
                    case RollStyle.RightToLeft:
                        m_intdirection = -1;
                        break;
                }
            }
        }

        private int _moveStep = 5;

        private int _moveSleepTime = 100;

        [Description("每次滚动间隔时间，越小速度越快"), Category("自定义")]
        public int MoveSleepTime
        {
            get { return _moveSleepTime; }
            set
            {
                if (value <= 0)
                    return;

                _moveSleepTime = value;
                m_timer.Interval = value;
            }
        }

        int m_intdirection = 1;

        Rectangle rectText;
        Timer m_timer;
        public UCRollText()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            this.SizeChanged += UCRollText_SizeChanged;
            this.Size = new Size(450, 30);
            Text = "滚动文字";
            m_timer = new Timer();
            m_timer.Interval = 100;
            m_timer.Tick += m_timer_Tick;
            this.Load += UCRollText_Load;
            this.VisibleChanged += UCRollText_VisibleChanged;
            this.ForeColor = Color.FromArgb(255, 77, 59);
            if (rectText != Rectangle.Empty)
            {
                rectText.Y = (this.Height - rectText.Height) / 2 + 1;
            }
        }

        void m_timer_Tick(object sender, EventArgs e)
        {
            if (rectText == Rectangle.Empty)
                return;
            if (_RollStyle == HZH_Controls.Controls.RollStyle.BackAndForth && rectText.Width >= this.Width)
            {
                return;
            }
            rectText.X = rectText.X + _moveStep * m_intdirection;
            if (_RollStyle == HZH_Controls.Controls.RollStyle.BackAndForth)
            {
                if (rectText.X <= 0)
                {
                    m_intdirection = 1;
                }
                else if (rectText.Right >= this.Width)
                {
                    m_intdirection = -1;
                }
            }
            else if (_RollStyle == HZH_Controls.Controls.RollStyle.LeftToRight)
            {
                if (rectText.X > this.Width)
                {
                    rectText.X = -1 * rectText.Width - 1;
                }
            }
            else
            {
                if (rectText.Right < 0)
                {
                    rectText.X = this.Width + rectText.Width + 1;
                }
            }
            Refresh();
        }

        void UCRollText_VisibleChanged(object sender, EventArgs e)
        {
            m_timer.Enabled = this.Visible;
        }

        void UCRollText_Load(object sender, EventArgs e)
        {
            if (_RollStyle == HZH_Controls.Controls.RollStyle.LeftToRight)
            {
                m_intdirection = 1;
                if (rectText != Rectangle.Empty)
                {
                    rectText.X = -1 * rectText.Width - 1;
                }
            }
            else if (_RollStyle == HZH_Controls.Controls.RollStyle.RightToLeft)
            {
                m_intdirection = -1;
                if (rectText != Rectangle.Empty)
                {
                    rectText.X = this.Width + rectText.Width + 1;
                }
            }
            else
            {
                m_intdirection = 1;
                if (rectText != Rectangle.Empty)
                {
                    rectText.X = 0;
                }
            }
            if (rectText != Rectangle.Empty)
            {
                rectText.Y = (this.Height - rectText.Height) / 2 + 1;
            }
        }

        void UCRollText_SizeChanged(object sender, EventArgs e)
        {
            if (rectText != Rectangle.Empty)
            {
                rectText.Y = (this.Height - rectText.Height) / 2 + 1;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (rectText != Rectangle.Empty)
            {
                e.Graphics.SetGDIHigh();
                e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rectText.Location);
            }
        }
    }

    public enum RollStyle
    {
        LeftToRight,
        RightToLeft,
        BackAndForth
    }
}
