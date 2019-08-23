using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    public class UCWave : Control
    {
        public event PaintEventHandler OnPainted; 

        private Color m_waveColor = Color.FromArgb(73, 119, 232);

        [Description("波纹颜色"), Category("自定义")]
        public Color WaveColor
        {
            get { return m_waveColor; }
            set { m_waveColor = value; }
        }

        private int m_waveWidth = 200;
        /// <summary>
        /// 为方便计算，强制使用10的倍数
        /// </summary>
        [Description("波纹宽度（为方便计算，强制使用10的倍数）"), Category("自定义")]
        public int WaveWidth
        {
            get { return m_waveWidth; }
            set
            {
                m_waveWidth = value;
                m_waveWidth = m_waveWidth / 10 * 10;
                intLeftX = value * -1;
            }
        }

        private int m_waveHeight = 30;
        /// <summary>
        /// 波高
        /// </summary>
        [Description("波高"), Category("自定义")]
        public int WaveHeight
        {
            get { return m_waveHeight; }
            set { m_waveHeight = value; }
        }

        private int m_waveSleep = 50;
        /// <summary>
        /// 波运行速度（运行时间间隔，毫秒）
        /// </summary>
        [Description("波运行速度（运行时间间隔，毫秒）"), Category("自定义")]
        public int WaveSleep
        {
            get { return m_waveSleep; }
            set
            {
                if (value <= 0)
                    return;
                m_waveSleep = value;
                if (timer != null)
                {
                    timer.Enabled = false;
                    timer.Interval = value;
                    timer.Enabled = true;
                }
            }
        }

        Timer timer = new Timer();
        int intLeftX = -200;
        public UCWave()
        {
            this.Size = new Size(600, 100);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            timer.Interval = m_waveSleep;
            timer.Tick += timer_Tick;
            this.VisibleChanged += UCWave_VisibleChanged;
        }

        void UCWave_VisibleChanged(object sender, EventArgs e)
        {
            timer.Enabled = this.Visible;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            intLeftX -= 10;
            if (intLeftX == m_waveWidth * -2)
                intLeftX = m_waveWidth * -1;
            this.Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();
            List<Point> lst1 = new List<Point>();
            List<Point> lst2 = new List<Point>();
            int m_intX = intLeftX;
            while (true)
            {
                lst1.Add(new Point(m_intX, 1));
                lst1.Add(new Point(m_intX + m_waveWidth / 2, m_waveHeight));

                lst2.Add(new Point(m_intX + m_waveWidth / 4, 1));
                lst2.Add(new Point(m_intX + m_waveWidth / 4 + m_waveWidth / 2, m_waveHeight));
                m_intX += m_waveWidth;
                if (m_intX > this.Width + m_waveWidth)
                    break;
            }

            GraphicsPath path1 = new GraphicsPath();
            path1.AddCurve(lst1.ToArray(), 0.5F);
            path1.AddLine(this.Width + 1, -1, this.Width + 1, this.Height);
            path1.AddLine(this.Width + 1, this.Height, -1, this.Height);
            path1.AddLine(-1, this.Height, -1, -1);

            GraphicsPath path2 = new GraphicsPath();
            path2.AddCurve(lst2.ToArray(), 0.5F);
            path2.AddLine(this.Width + 1, -1, this.Width + 1, this.Height);
            path2.AddLine(this.Width + 1, this.Height, -1, this.Height);
            path2.AddLine(-1, this.Height, -1, -1);

            g.FillPath(new SolidBrush(Color.FromArgb(220, m_waveColor.R, m_waveColor.G, m_waveColor.B)), path1);
            g.FillPath(new SolidBrush(Color.FromArgb(220, m_waveColor.R, m_waveColor.G, m_waveColor.B)), path2);

            if (OnPainted != null)
            {
                OnPainted(this, e);
            }
        }
    }
}
