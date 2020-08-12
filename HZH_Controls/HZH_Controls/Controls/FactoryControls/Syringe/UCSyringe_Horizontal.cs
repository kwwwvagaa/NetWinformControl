using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls.FactoryControls.Syringe
{
    public partial class UCSyringe_Horizontal : UserControl
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

        private bool leftOrRight = true;

        [Description("朝向：true左，false右"), Category("自定义")]
        public bool LeftOrRight
        {
            get { return leftOrRight; }
            set
            {
                leftOrRight = value;
                Refresh();
            }
        }
        int moveindex = 1;
        Rectangle workRect;
        public UCSyringe_Horizontal()
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
            maxMoveValue = (this.Width - 40) / 3 * 2 - 20;
            if (leftOrRight)
            {
                workRect = new Rectangle(20, 0, this.Width - 20, this.Height);
            }
            else
            {
                workRect = new Rectangle(0, 0, this.Width - 20, this.Height);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();
            if (leftOrRight)
            {
                //出口
                g.FillRectangle(new SolidBrush(bottomColor), new Rectangle(0, workRect.Height / 2 - workRect.Height / 8, 20 + 10, workRect.Height / 4));
                //g.FillRectangle(new SolidBrush(bottomColor), new Rectangle(0, workRect.Height / 4, 10, workRect.Height /2));
                //桶壁
                g.FillRectangle(new SolidBrush(subjectColor), new System.Drawing.Rectangle(workRect.Left + 10, workRect.Top, workRect.Width / 3 * 2, workRect.Height));
                //底座
                g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Left, workRect.Top, 20, workRect.Height));
                g.FillRectangle(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Left + 10, workRect.Top, 10, workRect.Height));
                g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Left + 10, workRect.Top, 20, workRect.Height));
                //液体
                g.FillRectangle(new SolidBrush(liquidColor), new System.Drawing.Rectangle(workRect.Left + 20 + 10, workRect.Height / 4, workRect.Width / 3 * 2 - 20, workRect.Height / 2));
                g.FillEllipse(new SolidBrush(liquidColor), new System.Drawing.Rectangle(workRect.Left + 20, workRect.Height / 4, 20, workRect.Height / 2));

                //画空气
                g.FillRectangle(Brushes.White, new Rectangle(workRect.Left + workRect.Width / 3 * 2 - (moveValue), workRect.Height / 4, moveValue + 15, workRect.Height / 2));

                //画推杆
                g.FillRectangle(new SolidBrush(bottomColor), new Rectangle(workRect.Left + workRect.Width / 3 * 2 - (moveValue), workRect.Top + workRect.Height / 2 - workRect.Height / 16, moveValue + 15, workRect.Height / 8));
                //g.FillRectangle(new SolidBrush(bottomColor), new Rectangle(workRect.Left + workRect.Width / 2, workRect.Top + workRect.Height / 2 - workRect.Height / 16, maxMoveValue - moveValue + 20 + 10, workRect.Height / 8));

                //画推柄
                //g.FillEllipse(new SolidBrush(bottomColor), new Rectangle(workRect.Left + workRect.Width /3* 2 + maxMoveValue - moveValue + 20, workRect.Height / 4, 20, workRect.Height / 2));

                //画塞子
                g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Left + workRect.Width / 3 * 2 - (moveValue) - 10, workRect.Height / 4, 20, workRect.Height / 2));

                //桶顶部
                g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Left + workRect.Width / 3 * 2, workRect.Top, 20, workRect.Height));
                g.FillRectangle(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Left + workRect.Width / 3 * 2 + 10, workRect.Top, 5, workRect.Height));
                g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Left + workRect.Width / 3 * 2 + 5, workRect.Top, 20, workRect.Height));

                //顶部
                g.FillRectangle(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Left + workRect.Width / 3 * 2 + 10, workRect.Top, workRect.Width / 3 - 20, workRect.Height));
                g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Right - 20, workRect.Top, 20, workRect.Height));

                //出水
                g.FillRectangle(new SolidBrush(liquidColor), new Rectangle(0, workRect.Height / 2 - workRect.Height / 16, 20 + 30, workRect.Height / 8));
            }
            else
            {
                //出口
                g.FillRectangle(new SolidBrush(bottomColor), new Rectangle(workRect.Right - 10, workRect.Height / 2 - workRect.Height / 8, 20 + 10, workRect.Height / 4));
                //桶壁
                g.FillRectangle(new SolidBrush(subjectColor), new System.Drawing.Rectangle(workRect.Left + workRect.Width / 3 - 10, workRect.Top, workRect.Width / 3 * 2, workRect.Height));
                //底座
                g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Right - 20, workRect.Top, 20, workRect.Height));
                g.FillRectangle(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Right - 10 - 10, workRect.Top, 10, workRect.Height));
                g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Right - 10 - 20, workRect.Top, 20, workRect.Height));
                //液体
                g.FillRectangle(new SolidBrush(liquidColor), new System.Drawing.Rectangle(workRect.Right - 20 - 10 - (workRect.Width / 3 * 2 - 20), workRect.Height / 4, workRect.Width / 3 * 2 - 20, workRect.Height / 2));
                g.FillEllipse(new SolidBrush(liquidColor), new System.Drawing.Rectangle(workRect.Right - 20 - 20, workRect.Height / 4, 20, workRect.Height / 2));
                //画空气
                g.FillRectangle(Brushes.White, new Rectangle(workRect.Right - workRect.Width / 3 * 2 - 15, workRect.Height / 4, moveValue + 15, workRect.Height / 2));
                //画推杆
                g.FillRectangle(new SolidBrush(bottomColor), new Rectangle(workRect.Right - workRect.Width / 3 * 2, workRect.Top + workRect.Height / 2 - workRect.Height / 16, moveValue, workRect.Height / 8));
                //g.FillRectangle(new SolidBrush(bottomColor), new Rectangle(workRect.Left + moveValue + 10, workRect.Top + workRect.Height / 2 - workRect.Height / 16, maxMoveValue - moveValue + 20 + 10, workRect.Height / 8));
                //画推柄
                //g.FillEllipse(new SolidBrush(bottomColor), new Rectangle(workRect.Left + moveValue, workRect.Height / 4, 20, workRect.Height / 2));

                //画塞子
                g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Right - workRect.Width / 3 * 2 + (moveValue) - 10, workRect.Height / 4, 20, workRect.Height / 2));

                //桶顶部
                g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Right - workRect.Width / 3 * 2 - 20, workRect.Top, 20, workRect.Height));
                g.FillRectangle(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Right - workRect.Width / 3 * 2 - 10 - 5, workRect.Top, 5, workRect.Height));
                g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Right - workRect.Width / 3 * 2 - 5 - 20, workRect.Top, 20, workRect.Height));

                //顶部
                g.FillRectangle(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Left + 10, workRect.Top, workRect.Width / 3 - 20, workRect.Height));
                g.FillEllipse(new SolidBrush(bottomColor), new System.Drawing.Rectangle(workRect.Left, workRect.Top, 20, workRect.Height));

                //出水
                g.FillRectangle(new SolidBrush(liquidColor), new Rectangle(workRect.Right - 30, workRect.Height / 2 - workRect.Height / 16, 20 + 30, workRect.Height / 8));
            }


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
