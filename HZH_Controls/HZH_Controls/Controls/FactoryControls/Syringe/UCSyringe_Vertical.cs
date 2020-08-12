using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HZH_Controls.Controls
{
    public partial class UCSyringe : UserControl
    {
        private Color bottomColor = Color.FromArgb(128, 128, 128);

        [Description("底座、推杆、把柄颜色"), Category("自定义")]
        public Color BottomColor
        {
            get { return bottomColor; }
            set { bottomColor = value; }
        }
        private Color subjectColor = Color.FromArgb(192, 192, 192);

        [Description("主体颜色"), Category("自定义")]
        public Color SubjectColor
        {
            get { return subjectColor; }
            set { subjectColor = value; }
        }
        private Color liquidColor = Color.FromArgb(135, 206, 235);

        [Description("液体颜色"), Category("自定义")]
        public Color LiquidColor
        {
            get { return liquidColor; }
            set { liquidColor = value; }
        }

        private int splitTime = 100;

        [Description("动画时间间隔"), Category("自定义")]
        public int SplitTime
        {
            get { return splitTime; }
            set
            {
                if (value <= 0)
                    return;
                splitTime = value;
                timer1.Interval = value;
            }
        }

        private int splitMove = 10;

        [Description("动画每次移动的像素"), Category("自定义")]
        public int SplitMove
        {
            get { return splitMove; }
            set { splitMove = value; }
        }
        int maxMoveValue = 0;

        [Description("最大可移动像素值"), Category("自定义")]
        public int MaxMoveValue
        {
            get { return maxMoveValue; }
            private set { maxMoveValue = value; }
        }
        int moveValue = 0;

        [Description("当前移动像素值"), Category("自定义")]
        public int MoveValue
        {
            get { return moveValue; }
            set
            {
                moveValue = value;
                Refresh();
            }
        }

        [Description("是否使用动画"), Category("自定义")]
        public bool Animation
        {
            get { return timer1.Enabled; }
            set { timer1.Enabled = value; }
        }

        int moveindex = 1;
        public UCSyringe()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.SizeChanged += UCSyringe_SizeChanged;
            UCSyringe_SizeChanged(null, null);
        }

        void UCSyringe_SizeChanged(object sender, EventArgs e)
        {
            maxMoveValue = this.Height / 2 - 40;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();
            //桶壁
            g.FillRectangle(new SolidBrush(subjectColor), new System.Drawing.Rectangle(0, e.ClipRectangle.Bottom - this.Height / 2 - 10, this.Width, this.Height / 2));
            //底座
            g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(0, e.ClipRectangle.Bottom - 20, this.Width, 20));
            g.FillRectangle(new SolidBrush(bottomColor), new System.Drawing.Rectangle(0, e.ClipRectangle.Bottom - 10 - 10, this.Width, 10));
            g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(0, e.ClipRectangle.Bottom - 20 - 10, this.Width, 20));

            //液体
            g.FillRectangle(new SolidBrush(liquidColor), new System.Drawing.Rectangle(this.Width / 4, e.ClipRectangle.Bottom - this.Height / 2 - 10, this.Width / 2, this.Height / 2 - 20));
            g.FillEllipse(new SolidBrush(liquidColor), new System.Drawing.Rectangle(this.Width / 4, e.ClipRectangle.Bottom - this.Height / 2 - 10 + this.Height / 2 - 40, this.Width / 2, 30));

            //画空气
            g.FillRectangle(Brushes.White, new Rectangle(this.Width / 4, e.ClipRectangle.Bottom - this.Height / 2 - 10, this.Width / 2, moveValue + 15));

            //画推杆
            g.FillRectangle(new SolidBrush(bottomColor), new Rectangle(this.Width / 2 - this.Width / 16, e.ClipRectangle.Bottom - this.Height / 2 - 30 - (maxMoveValue - moveValue), this.Width / 8, maxMoveValue - moveValue + 10));
            g.FillRectangle(new SolidBrush(bottomColor), new Rectangle(this.Width / 2 - this.Width / 16, e.ClipRectangle.Bottom - this.Height / 2 - 10, this.Width / 8, moveValue + 15));

            //画推柄
            g.FillEllipse(new SolidBrush(bottomColor), new Rectangle(this.Width / 4, e.ClipRectangle.Bottom - this.Height / 2 - 40 - (maxMoveValue - moveValue), this.Width / 2, 20));

            //画塞子
            g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(this.Width / 4, moveValue + e.ClipRectangle.Bottom - this.Height / 2 - 10, this.Width / 2, 20));
          
            //桶顶部
            g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(0, e.ClipRectangle.Bottom - this.Height / 2 - 20, this.Width, 20));
            g.FillRectangle(new SolidBrush(bottomColor), new System.Drawing.Rectangle(0, e.ClipRectangle.Bottom - this.Height / 2 - 10 - 5, this.Width, 5));
            g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(0, e.ClipRectangle.Bottom - this.Height / 2 - 20 - 5, this.Width, 20));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var v = moveValue + moveindex * splitMove;
            if (v <= 0 || v >= maxMoveValue)
            {
                moveindex = moveindex * -1;
                v = moveValue + moveindex * splitMove;
            }
            MoveValue = v;
        }
    }
}
