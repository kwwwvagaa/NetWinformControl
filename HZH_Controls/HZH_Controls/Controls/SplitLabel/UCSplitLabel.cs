using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace HZH_Controls.Controls
{
    public class UCSplitLabel : Label
    {
        [Localizable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                ResetMaxSize();
            }
        }
        [Localizable(true)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                ResetMaxSize();
            }
        }
        [Localizable(true)]
        public override Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }
            set
            {
                base.MinimumSize = value;
                ResetMaxSize();
            }
        }


        [Localizable(true)]
        public override Size MaximumSize
        {
            get
            {
                return base.MaximumSize;
            }
            set
            {
                base.MaximumSize = value;
                ResetMaxSize();
            }
        }
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }


        private Color lineColor = LineColors.Light;

        public Color LineColor
        {
            get { return lineColor; }
            set
            {
                lineColor = value;
                Invalidate();
            }
        }

        private void ResetMaxSize()
        {
            using (var g = this.CreateGraphics())
            {
                var _width = Width;
                var size = g.MeasureString(string.IsNullOrEmpty(Text) ? "A" : Text, Font);
                if (MinimumSize.Height != (int)size.Height)
                    MinimumSize = new Size(base.MinimumSize.Width, (int)size.Height);
                if (MaximumSize.Height != (int)size.Height)
                    MaximumSize = new Size(base.MaximumSize.Width, (int)size.Height);
                this.Width = _width;
            }
        }
        public UCSplitLabel()
            : base()
        {
            if (ControlHelper.IsDesignMode())
            {
                Text = "分割线";
                Font = new Font("微软雅黑", 8f);
            }
            this.AutoSize = false;
            Padding = new Padding(20, 0, 0, 0);
            MinimumSize = new System.Drawing.Size(150, 10);
            PaddingChanged += UCSplitLabel_PaddingChanged;
            this.Width = 200;
        }

        void UCSplitLabel_PaddingChanged(object sender, EventArgs e)
        {
            if (Padding.Left < 20)
            {
                Padding = new Padding(20, Padding.Top, Padding.Right, Padding.Bottom);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();

            var size = g.MeasureString(Text, Font);
            g.DrawLine(new Pen(new SolidBrush(lineColor)), new PointF(1, Padding.Top + (this.Height - Padding.Top - Padding.Bottom) / 2), new PointF(Padding.Left - 2, Padding.Top + (this.Height - Padding.Top - Padding.Bottom) / 2));
            g.DrawLine(new Pen(new SolidBrush(lineColor)), new PointF(Padding.Left + size.Width + 1, Padding.Top + (this.Height - Padding.Top - Padding.Bottom) / 2), new PointF(Width - Padding.Right, Padding.Top + (this.Height - Padding.Top - Padding.Bottom) / 2));

        }
    }
}
