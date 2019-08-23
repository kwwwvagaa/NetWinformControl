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
    public class UCWaveWithSource : UCControlBase
    {
        private int m_waveActualWidth = 50;

        private int m_waveWidth = 50;

        [Description("波形宽度"), Category("自定义")]
        public int WaveWidth
        {
            get { return m_waveWidth; }
            set
            {
                if (value <= 0)
                    return;
                m_waveWidth = value;
                ResetWaveCount();
                Refresh();
            }
        }

        private int m_sleepTime = 1000;
        /// <summary>
        /// 波运行速度（运行时间间隔，毫秒）
        /// </summary>
        [Description("运行速度（运行时间间隔，毫秒）"), Category("自定义")]
        public int SleepTime
        {
            get { return m_sleepTime; }
            set
            {
                if (value <= 0)
                    return;
                m_sleepTime = value;
                if (timer != null)
                {
                    timer.Enabled = false;
                    timer.Interval = value;
                    timer.Enabled = true;
                }
            }
        }

        private float m_lineTension = 0.5f;
        /// <summary>
        /// 线弯曲程度
        /// </summary>
        [Description("线弯曲程度(0-1）"), Category("自定义")]
        public float LineTension
        {
            get { return m_lineTension; }
            set
            {
                if (!(value >= 0 && value <= 1))
                {
                    return;
                }
                m_lineTension = value;
                Refresh();
            }
        }

        private Color m_lineColor = Color.FromArgb(150, 73, 119, 232);

        [Description("曲线颜色"), Category("自定义")]
        public Color LineColor
        {
            get { return m_lineColor; }
            set
            {
                m_lineColor = value;
                Refresh();

            }
        }

        private Color m_gridLineColor = Color.FromArgb(50, 73, 119, 232);

        [Description("网格线颜色"), Category("自定义")]
        public Color GridLineColor
        {
            get { return m_gridLineColor; }
            set
            {
                m_gridLineColor = value;
                Refresh();
            }
        }

        private Color m_gridLineTextColor = Color.FromArgb(150, 73, 119, 232);

        [Description("网格文本颜色"), Category("自定义")]
        public Color GridLineTextColor
        {
            get { return m_gridLineTextColor; }
            set
            {
                m_gridLineTextColor = value;
                Refresh();
            }
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }
        /// <summary>
        /// 数据源，用以缓存所有需要显示的数据
        /// </summary>
        List<KeyValuePair<string, double>> m_dataSource = new List<KeyValuePair<string, double>>();
        /// <summary>
        /// 当前需要显示的数据
        /// </summary>
        List<KeyValuePair<string, double>> m_currentSource = new List<KeyValuePair<string, double>>();
        Timer timer = new Timer();
        /// <summary>
        /// 画图区域
        /// </summary>
        Rectangle m_drawRect;

        int m_waveCount = 0;
        public UCWaveWithSource()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            this.SizeChanged += UCWaveWithSource_SizeChanged;
            this.IsShowRect = true;
            this.RectColor = Color.FromArgb(232, 232, 232);
            this.FillColor = Color.FromArgb(197, 229, 250);
            this.RectWidth = 1;
            this.ConerRadius = 10;
            this.IsRadius = true;
            this.Size = new Size(300, 200);

            timer.Interval = m_sleepTime;
            timer.Tick += timer_Tick;
            this.VisibleChanged += UCWave_VisibleChanged;


        }

     
        /// <summary>
        /// 添加需要显示的数据
        /// </summary>
        /// <param name="key">名称</param>
        /// <param name="value">值</param>
        public void AddSource(string key, double value)
        {
            m_dataSource.Add(new KeyValuePair<string, double>(key, value));
        }

        void UCWave_VisibleChanged(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                timer.Enabled = this.Visible;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            m_currentSource = GetCurrentList();
            m_dataSource.RemoveAt(0);
            this.Refresh();
        }
        void UCWaveWithSource_SizeChanged(object sender, EventArgs e)
        {
            m_drawRect = new Rectangle(60, 20, this.Width - 80, this.Height - 60);
            ResetWaveCount();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();

            int intLineSplit = m_drawRect.Height / 4;
            for (int i = 0; i <= 4; i++)
            {
                var pen = new Pen(new SolidBrush(m_gridLineColor), 1);
                // pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                g.DrawLine(pen, m_drawRect.Left, m_drawRect.Bottom - 1 - i * intLineSplit, m_drawRect.Right, m_drawRect.Bottom - 1 - i * intLineSplit);
            }

            if (m_currentSource == null || m_currentSource.Count <= 0)
            {
                for (int i = 0; i <= 4; i++)
                {
                    string strText = (100 / 4 * i).ToString();
                    System.Drawing.SizeF _numSize = g.MeasureString(strText, this.Font);
                    g.DrawString(strText, Font, new SolidBrush(m_gridLineTextColor), m_drawRect.Left - _numSize.Width - 1, m_drawRect.Bottom - 1 - i * intLineSplit - (_numSize.Height / 2));
                }
                return;
            }
            List<Point> lst1 = new List<Point>();
            double dblValue = m_currentSource.Max(p => p.Value);
            int intValue = (int)dblValue;
            int intDivisor = ("1".PadRight(intValue.ToString().Length - 1, '0')).ToInt();
            if (intDivisor < 100)
                intDivisor = 100;
            int intTop = intValue;
            if (intValue % intDivisor != 0)
            {
                intTop = (intValue / intDivisor + 1) * intDivisor;
            }
            if (intTop == 0)
                intTop = 100;

            for (int i = 0; i <= 4; i++)
            {
                string strText = (intTop / 4 * i).ToString();
                System.Drawing.SizeF _numSize = g.MeasureString(strText, this.Font);
                g.DrawString(strText, Font, new SolidBrush(m_gridLineTextColor), m_drawRect.Left - _numSize.Width - 1, m_drawRect.Bottom - 1 - i * intLineSplit - (_numSize.Height / 2));
            }

            int intEndX = 0;
            int intEndY = 0;
            for (int i = 0; i < m_currentSource.Count; i++)
            {
                intEndX = i * m_waveActualWidth + m_drawRect.X;
                intEndY = m_drawRect.Bottom - 1 - (int)(m_currentSource[i].Value / intTop * m_drawRect.Height);
                lst1.Add(new Point(intEndX, intEndY));
                if (!string.IsNullOrEmpty(m_currentSource[i].Key))
                {
                    System.Drawing.SizeF _numSize = g.MeasureString(m_currentSource[i].Key, this.Font);
                    int txtX = intEndX - (int)(_numSize.Width / 2) + 1;
                    g.DrawString(m_currentSource[i].Key, Font, new SolidBrush(m_gridLineTextColor), new PointF(txtX, m_drawRect.Bottom + 5));
                }
            }

            int intFirstY = m_drawRect.Bottom - 1 - (int)(m_currentSource[0].Value / intTop * m_drawRect.Height);


            GraphicsPath path1 = new GraphicsPath();
            path1.AddCurve(lst1.ToArray(), m_lineTension);
            g.DrawPath(new Pen(new SolidBrush(m_lineColor), 1), path1);

        }
        /// <summary>
        /// 得到当前需要画图的数据
        /// </summary>
        /// <returns></returns>
        private List<KeyValuePair<string, double>> GetCurrentList()
        {
            if (m_dataSource.Count < m_waveCount)
            {
                int intCount = m_waveCount - m_dataSource.Count;
                for (int i = 0; i < intCount; i++)
                {
                    m_dataSource.Add(new KeyValuePair<string, double>("", 0));
                }
            }

            var lst = m_dataSource.GetRange(0, m_waveCount);
            if (lst.Count == 1)
                lst.Insert(0, new KeyValuePair<string, double>("", 0));
            return lst;
        }

        /// <summary>
        /// 计算需要显示的个数
        /// </summary>
        private void ResetWaveCount()
        {
            m_waveCount = m_drawRect.Width / m_waveWidth;
            m_waveActualWidth = m_waveWidth + (m_drawRect.Width % m_waveWidth) / m_waveCount;
            m_waveCount++;
            if (m_dataSource.Count < m_waveCount)
            {
                int intCount = m_waveCount - m_dataSource.Count;
                for (int i = 0; i < intCount; i++)
                {
                    m_dataSource.Insert(0, new KeyValuePair<string, double>("", 0));
                }
            }
        }
    }
}
