using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HZH_Controls.Controls
{
    public class UCValve : UserControl
    {
        private ValveDirection valveDirection = ValveDirection.Horizontal;

        public ValveDirection ValveDirection
        {
            get { return valveDirection; }
            set { valveDirection = value; }
        }

        public UCValve()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.Size = new Size(120, 100);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();

            Rectangle rectGuan = new Rectangle(0, this.Height / 2 - this.Height / 8, this.Width, this.Height / 2 + this.Height / 4);      
            //管道
            g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(rectGuan.Left, rectGuan.Top + this.Height / 8, rectGuan.Width, this.Height / 2 - this.Height / 8));
            //接口
            g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(this.Height / 8,rectGuan.Top,rectGuan.Height/3,rectGuan.Height));
            g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(rectGuan.Right - this.Height / 8 - rectGuan.Height / 3, rectGuan.Top, rectGuan.Height / 3, rectGuan.Height));
            //高亮
            int intCount = rectGuan.Height / 2 / 4;
            int intSplit = (255 - 100) / intCount;
            for (int i = 0; i < intCount; i++)
            {
                int _penWidth = rectGuan.Height / 2 - 4 * i;
                if (_penWidth <= 0)
                    _penWidth = 1;
                g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(10, Color.White)), _penWidth), new Point(rectGuan.Left, rectGuan.Height / 2 + rectGuan.Top), new Point(rectGuan.Right, rectGuan.Height / 2 + rectGuan.Top));
                if (_penWidth == 1)
                    break;
            }

            //阀门底座

        }
    }

    public enum ValveDirection
    {
        Horizontal,
        Vertical
    }
}
