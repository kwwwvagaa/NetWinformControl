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
    public class UCSampling : UserControl
    {
        private Bitmap samplingImag = null;
        [Browsable(true), Category("自定义属性"), Description("采样图片"), Localizable(true)]
        public Bitmap SamplingImag
        {
            get { return samplingImag; }
            set
            {
                samplingImag = value;
                ResetBorderPath();
                Invalidate();
            }
        }

        private Color? transparent = null;

        [Browsable(true), Category("自定义属性"), Description("透明色，如果为空，则使用0,0坐标处的颜色"), Localizable(true)]
        public Color? Transparent
        {
            get { return transparent; }
            set
            {
                transparent = value;
                ResetBorderPath();
                Invalidate();
            }
        }

        private int alpha = 50;

        [Browsable(true), Category("自定义属性"), Description("当作透明色的透明度，小于此透明度的颜色将被认定为透明，0-255"), Localizable(true)]
        public int Alpha
        {
            get { return alpha; }
            set
            {
                if (value < 0 || value > 255)
                    return;
                alpha = value;
                ResetBorderPath();
                Invalidate();
            }
        }

        private int colorThreshold = 10;

        [Browsable(true), Category("自定义属性"), Description("透明色颜色阀值"), Localizable(true)]
        public int ColorThreshold
        {
            get { return colorThreshold; }
            set
            {
                colorThreshold = value;
                ResetBorderPath();
                Invalidate();
            }
        }

        private Bitmap _bitCache;
        public UCSampling()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SizeChanged += UCSampling_SizeChanged;
            this.Size = new Size(35, 35);
        }
        GraphicsPath m_borderPath = new GraphicsPath();

        void UCSampling_SizeChanged(object sender, EventArgs e)
        {
            ResetBorderPath();
        }

        private void ResetBorderPath()
        {
            if (samplingImag == null)
            {
                m_borderPath = this.ClientRectangle.CreateRoundedRectanglePath(5);
            }
            else
            {
                var bit = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
                using (var bitg = Graphics.FromImage(bit))
                {
                    bitg.DrawImage(samplingImag, this.ClientRectangle, 0, 0, samplingImag.Width, samplingImag.Height, GraphicsUnit.Pixel);
                }
                _bitCache = bit;
                m_borderPath = new GraphicsPath();
                List<PointF> lstPoints = GetBorderPoints(bit, transparent ?? samplingImag.GetPixel(0, 0));
                m_borderPath.AddLines(lstPoints.ToArray());
                m_borderPath.CloseAllFigures();
            }
        }

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
                    if (!(((int)_color.A) <= alpha || IsLikeColor(_color, transparent)))
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

        private bool IsLikeColor(Color color1, Color color2)
        {
            var cv = Math.Sqrt(Math.Pow((color1.R - color2.R), 2) + Math.Pow((color1.G - color2.G), 2) + Math.Pow((color1.B - color2.B), 2));
            if (cv <= colorThreshold)
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
            e.Graphics.SetGDIHigh();

            this.Region = new System.Drawing.Region(m_borderPath);
           
            if (_bitCache != null)
                e.Graphics.DrawImage(_bitCache, 0, 0);
           
        }
    }
}
