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
    public partial class UCHouse : UserControl
    {
        private Color roofColor = Color.Black;

        public Color RoofColor
        {
            get { return roofColor; }
            set { roofColor = value; }
        }

        private Color wallColor = Color.Red;

        public Color WallColor
        {
            get { return wallColor; }
            set { wallColor = value; }
        }
        public UCHouse()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();

            //GraphicsPath path = new GraphicsPath();
            //path.AddLines(new Point[]{
            //new Point(0,this.Height/2-20),
            //new Point(this.Width/4,0),
            //new Point(this.Width/4*3,20),
            //new Point(this.Width-1,this.Height/2),           
            //new Point(this.Width-1,this.Height-1),
            //new Point(this.Width/2,this.Height-1),
            //new Point(0,this.Height-20),
            //});
            //path.CloseFigure();
            //g.DrawPath(new Pen(new SolidBrush(Color.Red)), path);
            //g.DrawLine(new Pen(new SolidBrush(Color.Red)), new Point(this.Width / 4 * 3, 20), new Point(this.Width / 2, this.Height / 2));
            //g.DrawLines(new Pen(new SolidBrush(Color.Red)),new Point[]{ new Point(0, this.Height / 2 - 20), new Point(this.Width / 2, this.Height / 2),new Point(this.Width/2,this.Height-1)});
            //g.DrawLine(new Pen(new SolidBrush(Color.Red)), new Point(this.Width / 2, this.Height / 2), new Point(this.Width - 1, this.Height / 2));

            GraphicsPath pathRoof = new GraphicsPath();
            pathRoof.AddLines(new Point[] 
            {
                new Point(0,this.Height/2-20),
                new Point(this.Width/4,0),
                new Point(this.Width/4*3,0),
                new Point(this.Width / 2, this.Height / 2)
            });
            pathRoof.CloseFigure();
            g.FillPath(new SolidBrush(roofColor), pathRoof);

            GraphicsPath pathWall = new GraphicsPath();
            pathWall.AddLines(new Point[]
            {
                new Point(0,this.Height/2-20),
                new Point(this.Width / 2, this.Height / 2),
                new Point(this.Width/4*3, 0),
                new Point(this.Width, this.Height / 2),
                new Point(this.Width , this.Height),
                new Point(this.Width , this.Height),
                new Point(this.Width/2 , this.Height),
                new Point(0 , this.Height-20),
            });
            pathWall.CloseFigure();
            g.FillPath(new SolidBrush(wallColor), pathWall);
            g.DrawLines(new Pen( new SolidBrush(Color.FromArgb(50,Color.White))), new Point[] { new Point(this.Width / 2, this.Height), new Point(this.Width / 2, this.Height / 2), new Point(this.Width, this.Height / 2) });
        }
    }
}
