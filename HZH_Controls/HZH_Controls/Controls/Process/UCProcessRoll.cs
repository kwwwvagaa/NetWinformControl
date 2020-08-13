using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.ComponentModel;

namespace HZH_Controls.Controls
{
    public class UCProcessRoll : Control
    {
        private Color rollColor = Color.FromArgb(0, 122, 204);

        [Description("滚动的颜色"), Category("自定义")]
        public Color RollColor
        {
            get { return rollColor; }
            set { rollColor = value; }
        }

        [Description("是否滚动"), Category("自定义")]
        public bool Roll
        {
            get { return timer.Enabled; }
            set
            {
                timer.Enabled = value;
                if (!value)
                {
                    workRect = new Rectangle(-this.Width / 3, 0, this.Width / 3, this.Height);
                    Invalidate();
                }
            }
        }

        [Description("滚动间隔时间"), Category("自定义")]
        public int SplitTime
        {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }

        Timer timer = new Timer();
        public UCProcessRoll()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SizeChanged += UCProcessRoll_SizeChanged;
            this.Size = new Size(300, 3);
            this.BackColor = Color.White;
            timer.Interval = 30;
            timer.Tick += timer_Tick;
            timer.Enabled = true;
        }


        Rectangle workRect;

        void UCProcessRoll_SizeChanged(object sender, EventArgs e)
        {
            workRect = new Rectangle(-this.Width / 3, 0, this.Width / 3, this.Height);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();
            var r1 = new RectangleF(new Point(workRect.Left - 1, workRect.Top), new Size(workRect.Width / 3 + 1, workRect.Height));
            var r2 = new RectangleF(new Point(workRect.Right - workRect.Width / 3, workRect.Top), new Size(workRect.Width / 3, workRect.Height));
            LinearGradientBrush lgb1 = new LinearGradientBrush(r1, Color.FromArgb(0, rollColor), rollColor, 0f);
            LinearGradientBrush lgb2 = new LinearGradientBrush(r2, rollColor, Color.FromArgb(0, rollColor), 0f);
            g.FillRectangle(lgb1, new Rectangle(new Point(workRect.Left, workRect.Top), new Size(workRect.Width / 3, workRect.Height)));
            g.FillRectangle(new SolidBrush(rollColor), new RectangleF(workRect.Left + workRect.Width / 3 - 1, workRect.Top, workRect.Width / 3 + 3, workRect.Height));
            g.FillRectangle(lgb2, r2);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (workRect != null)
            {
                workRect = new Rectangle(workRect.Left + 10, 0, this.Width / 3, this.Height);

                if (workRect.Left >= this.ClientRectangle.Right)
                {
                    workRect = new Rectangle(-this.Width / 3, 0, this.Width / 3, this.Height);
                }
                Invalidate();
            }
        }
    }
}
