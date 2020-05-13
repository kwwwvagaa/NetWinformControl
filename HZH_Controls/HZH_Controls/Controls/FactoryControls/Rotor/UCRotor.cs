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
    public partial class UCRotor : UserControl
    {
        private Color rotorColor = Color.Black;

        public Color RotorColor
        {
            get { return rotorColor; }
            set
            {
                rotorColor = value;
                Refresh();
            }
        }

        RotorAround rotorAround = RotorAround.None;
        int jiaodu = 0;
        public RotorAround RotorAround
        {
            get { return rotorAround; }
            set
            {
                rotorAround = value;
                if (value == RotorAround.None)
                {
                    timer1.Enabled = false;
                    jiaodu = 0;
                    Refresh();
                }
                else
                    timer1.Enabled = true;
            }
        }
        private int speed = 100;

        [Description("旋转速度，100-1000，值越小 速度越快"), Category("自定义")]
        public int Speed
        {
            get { return speed; }
            set
            {
                if (value < 100 || value > 1000)
                    return;
                speed = value;
                timer1.Interval = value;
            }
        }

        int maxWidth = 0;
        int one = 0;
        Dictionary<int, GraphicsPath> lstCachePath = new Dictionary<int, GraphicsPath>();
        public UCRotor()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            maxWidth = Math.Min(this.Width, this.Height);
            one = maxWidth / 10;
            ResetPathCache();
            this.SizeChanged += UCRotor_SizeChanged;
        }

        void UCRotor_SizeChanged(object sender, EventArgs e)
        {
            maxWidth = Math.Min(this.Width, this.Height);
            one = maxWidth / 10;
            ResetPathCache();

        }

        private void ResetPathCache()
        {
            for (int i = 0; i < 180; i += 15)
            {
                Bitmap bitcache = new Bitmap(Width, Height);
                var gimg = Graphics.FromImage(bitcache);
                gimg.SetGDIHigh();
                gimg.Clear(Color.Red);
                gimg.TranslateTransform(Width / 2, Height / 2);
                // 旋转画板
                gimg.RotateTransform(i);
                // 回退画板x,y轴移动过的距离
                gimg.TranslateTransform(-(Width / 2), -(Height / 2));
                gimg.FillEllipse(new SolidBrush(Color.Black), new Rectangle((this.Width - maxWidth) / 2, (this.Height - maxWidth) / 2 + maxWidth / 4 + maxWidth / 8, maxWidth / 2, maxWidth / 2 - maxWidth / 4));
                gimg.FillEllipse(new SolidBrush(Color.Black), new Rectangle(this.Width / 2, (this.Height - maxWidth) / 2 + maxWidth / 4 + maxWidth / 8, maxWidth / 2, maxWidth / 2 - maxWidth / 4));
                gimg.FillEllipse(new SolidBrush(Color.Black), new Rectangle((this.Width - maxWidth) / 2 + maxWidth / 2 - maxWidth / 8, (this.Height - maxWidth) / 2 + maxWidth / 2 - maxWidth / 8, maxWidth / 4, maxWidth / 4));
                gimg.Dispose();
                var borderPath = new GraphicsPath();
                borderPath.AddLines(GetBorderPoints(bitcache, Color.Red).ToArray());
                borderPath.CloseAllFigures();
                lstCachePath[i] = borderPath;

                bitcache.Dispose();
            }
        }

        /// <summary>
        /// Gets the border points.
        /// </summary>
        /// <param name="bit">The bit.</param>
        /// <param name="transparent">The transparent.</param>
        /// <returns>List&lt;PointF&gt;.</returns>
        private List<PointF> GetBorderPoints(Bitmap bit, Color transparent)
        {
            float diameter = (float)Math.Sqrt(bit.Width * bit.Width + bit.Height * bit.Height);
            int intSplit = 0;
            intSplit = (int)(7 - (diameter - 200) / 100);
            if (intSplit < 1)
                intSplit = 1;
            List<PointF> lstPoint = new List<PointF>();
            for (int i = 0; i < 360; i += intSplit)
            {
                for (int j = (int)diameter / 2; j > 5; j--)
                {
                    Point p = GetPointByAngle(i, j, new PointF(bit.Width / 2, bit.Height / 2));
                    if (p.X < 0 || p.Y < 0 || p.X >= bit.Width || p.Y >= bit.Height)
                        continue;
                    Color _color = bit.GetPixel(p.X, p.Y);
                    if (!(((int)_color.A) <= 50 || IsLikeColor(_color, transparent)))
                    {
                        if (!lstPoint.Contains(p))
                        {
                            lstPoint.Add(p);
                        }
                        break;
                    }
                }
            }
            return lstPoint;
        }

        /// <summary>
        /// Determines whether [is like color] [the specified color1].
        /// </summary>
        /// <param name="color1">The color1.</param>
        /// <param name="color2">The color2.</param>
        /// <returns><c>true</c> if [is like color] [the specified color1]; otherwise, <c>false</c>.</returns>
        private bool IsLikeColor(Color color1, Color color2)
        {
            var cv = Math.Sqrt(Math.Pow((color1.R - color2.R), 2) + Math.Pow((color1.G - color2.G), 2) + Math.Pow((color1.B - color2.B), 2));
            if (cv <= 10)
                return true;
            else
                return false;
        }

        #region 根据角度得到坐标    English:Get coordinates from angles
        /// <summary>
        /// 功能描述:根据角度得到坐标    English:Get coordinates from angles
        /// 作　　者:HZH
        /// 创建日期:2019-09-28 11:56:25
        /// 任务编号:POS
        /// </summary>
        /// <param name="angle">angle</param>
        /// <param name="radius">radius</param>
        /// <param name="origin">origin</param>
        /// <returns>返回值</returns>
        private Point GetPointByAngle(float angle, float radius, PointF origin)
        {
            float y = origin.Y + (float)Math.Sin(Math.PI * (angle / 180.00F)) * radius;
            float x = origin.X + (float)Math.Cos(Math.PI * (angle / 180.00F)) * radius;
            return new Point((int)x, (int)y);
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            this.Region = new System.Drawing.Region(lstCachePath[jiaodu]);
            g.TranslateTransform(Width / 2, Height / 2);
            // 旋转画板
            g.RotateTransform(jiaodu);
            // 回退画板x,y轴移动过的距离
            g.TranslateTransform(-(Width / 2), -(Height / 2));
            g.FillEllipse(new SolidBrush(rotorColor), new Rectangle((this.Width - maxWidth) / 2+5, (this.Height - maxWidth) / 2 + maxWidth / 4 + maxWidth / 8+2, maxWidth / 2-5, maxWidth / 2 - maxWidth / 4-4));
            g.FillEllipse(new SolidBrush(rotorColor), new Rectangle(this.Width / 2, (this.Height - maxWidth) / 2 + maxWidth / 4 + maxWidth / 8+2, maxWidth / 2-5, maxWidth / 2 - maxWidth / 4-4));
            g.FillEllipse(new SolidBrush(rotorColor), new Rectangle((this.Width - maxWidth) / 2 + maxWidth / 2 - maxWidth / 8, (this.Height - maxWidth) / 2 + maxWidth / 2 - maxWidth / 8, maxWidth / 4, maxWidth / 4));
            g.FillEllipse(new SolidBrush(Color.FromArgb(10, Color.White)), new Rectangle((this.Width - maxWidth) / 2 + maxWidth / 2 - maxWidth / 8, (this.Height - maxWidth) / 2 + maxWidth / 2 - maxWidth / 8, maxWidth / 4, maxWidth / 4));

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (rotorAround == RotorAround.Clockwise)
            {
                jiaodu += 15;
                if (jiaodu == 180)
                    jiaodu = 0;
            }
            else if (rotorAround == RotorAround.Counterclockwise)
            {
                jiaodu -= 15;
                if (jiaodu < 0)
                    jiaodu = 165;
            }

            Refresh();
        }
    }
    public enum RotorAround
    {
        /// <summary>
        /// 不旋转
        /// </summary>
        None,
        /// <summary>
        /// 顺时针
        /// </summary>
        Clockwise,
        /// <summary>
        /// 逆时针
        /// </summary>
        Counterclockwise
    }
}
