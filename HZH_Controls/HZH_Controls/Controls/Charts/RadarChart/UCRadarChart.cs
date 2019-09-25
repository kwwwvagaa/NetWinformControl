// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-25
//
// ***********************************************************************
// <copyright file="UCRadarChart.cs">
//     Copyright by Huang Zhenghui(黄正辉) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub：https://github.com/kwwwvagaa/NetWinformControl
// gitee：https://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
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
    /// <summary>
    /// Class UCRadarChart.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCRadarChart : UserControl
    {
        /// <summary>
        /// The split count
        /// </summary>
        private int splitCount = 5;
        /// <summary>
        /// Gets or sets the split count.
        /// </summary>
        /// <value>The split count.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置分隔份数")]
        public int SplitCount
        {
            get { return splitCount; }
            set
            {
                splitCount = value;
                Invalidate();
            }
        }
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置是否使用圆代替连线进行分隔")]
        public bool UseRoundSplit { get; set; }

        /// <summary>
        /// The split odd color
        /// </summary>
        private Color splitOddColor = Color.White;
        /// <summary>
        /// 分隔奇数栏背景色
        /// </summary>
        /// <value>The color of the split odd.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置分隔奇数栏背景色")]
        public Color SplitOddColor
        {
            get { return splitOddColor; }
            set
            {
                splitOddColor = value;
                Invalidate();
            }
        }
        /// <summary>
        /// The split even color
        /// </summary>
        private Color splitEvenColor = Color.FromArgb(232, 232, 232);
        /// <summary>
        /// 分隔偶数栏背景色
        /// </summary>
        /// <value>The color of the split even.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置分隔偶数栏背景色")]
        public Color SplitEvenColor
        {
            get { return splitEvenColor; }
            set
            {
                splitEvenColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The line color
        /// </summary>
        private Color lineColor = Color.FromArgb(153, 153, 153);
        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置线条色")]
        public Color LineColor
        {
            get { return lineColor; }
            set
            {
                lineColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The radar positions
        /// </summary>
        private RadarPosition[] radarPositions;
        /// <summary>
        /// 节点列表，至少需要3个
        /// </summary>
        /// <value>The radar positions.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置节点，至少需要3个")]
        public RadarPosition[] RadarPositions
        {
            get { return radarPositions; }
            set
            {
                radarPositions = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The title
        /// </summary>
        private string title;
        /// <summary>
        /// 标题
        /// </summary>
        /// <value>The title.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置标题")]
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                ResetTitleSize();
                Invalidate();
            }
        }

        /// <summary>
        /// The title font
        /// </summary>
        private Font titleFont = new Font("微软雅黑", 12);
        /// <summary>
        /// Gets or sets the title font.
        /// </summary>
        /// <value>The title font.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置标题字体")]
        public Font TitleFont
        {
            get { return titleFont; }
            set
            {
                titleFont = value;
                ResetTitleSize();
                Invalidate();
            }
        }

        /// <summary>
        /// The title color
        /// </summary>
        private Color titleColor = Color.Black;
        /// <summary>
        /// Gets or sets the color of the title.
        /// </summary>
        /// <value>The color of the title.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置标题文本颜色")]
        public Color TitleColor
        {
            get { return titleColor; }
            set
            {
                titleColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The lines
        /// </summary>
        private RadarLine[] lines;
        /// <summary>
        /// Gets or sets the lines.
        /// </summary>
        /// <value>The lines.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置值线条，Values长度必须与RadarPositions长度一致，否则无法显示")]
        public RadarLine[] Lines
        {
            get { return lines; }
            set
            {
                lines = value;
                Invalidate();
            }
        }



        /// <summary>
        /// The title size
        /// </summary>
        SizeF titleSize = SizeF.Empty;
        /// <summary>
        /// The m rect working
        /// </summary>
        private RectangleF m_rectWorking = Rectangle.Empty;
        /// <summary>
        /// The line value type size
        /// </summary>
        SizeF lineValueTypeSize = SizeF.Empty;
        /// <summary>
        /// The int line value COM count
        /// </summary>
        int intLineValueComCount = 0;
        /// <summary>
        /// The int line value row count
        /// </summary>
        int intLineValueRowCount = 0;
        /// <summary>
        /// Initializes a new instance of the <see cref="UCRadarChart"/> class.
        /// </summary>
        public UCRadarChart()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.SizeChanged += UCRadarChart_SizeChanged;
            Size = new System.Drawing.Size(150, 150);
            radarPositions = new RadarPosition[0];
            if (ControlHelper.IsDesignMode())
            {
                radarPositions = new RadarPosition[6];
                for (int i = 0; i < 6; i++)
                {
                    radarPositions[i] = new RadarPosition
                    {
                        Text = "Item" + (i + 1),
                        MaxValue = 100
                    };
                }
            }

            lines = new RadarLine[0];
            if (ControlHelper.IsDesignMode())
            {
                Random r = new Random();
                lines = new RadarLine[2];
                for (int i = 0; i < 2; i++)
                {
                    lines[i] = new RadarLine()
                    {
                        Name = "line" + i
                    };
                    lines[i].Values = new double[radarPositions.Length];
                    for (int j = 0; j < radarPositions.Length; j++)
                    {
                        lines[i].Values[j] = r.Next(20, (int)radarPositions[j].MaxValue);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the SizeChanged event of the UCRadarChart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void UCRadarChart_SizeChanged(object sender, EventArgs e)
        {
            ResetWorkingRect();
        }

        /// <summary>
        /// Resets the working rect.
        /// </summary>
        private void ResetWorkingRect()
        {
            if (lines != null && lines.Length > 0)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    foreach (var item in lines)
                    {
                        var s = g.MeasureString(item.Name, Font);
                        if (s.Width > lineValueTypeSize.Width)
                            lineValueTypeSize = s;
                    }
                }
            }
            var lineTypePanelHeight = 0f;
            if (lineValueTypeSize != SizeF.Empty)
            {
                intLineValueComCount = (int)(this.Width / (lineValueTypeSize.Width + 25));

                intLineValueRowCount = lines.Length / intLineValueComCount;
                if (lines.Length % intLineValueComCount != 0)
                {
                    intLineValueRowCount++;
                }
                lineTypePanelHeight = (lineValueTypeSize.Height + 10) * intLineValueRowCount;
            }
            var min = Math.Min(this.Width, this.Height - titleSize.Height - lineTypePanelHeight);
            var rectWorking = new RectangleF((this.Width - min) / 2 + 10, titleSize.Height + lineTypePanelHeight + 10, min - 10, min - 10);
            //处理文字
            float fltSplitAngle = 360F / radarPositions.Length;
            float fltRadiusWidth = rectWorking.Width / 2;
            float minX = rectWorking.Left;
            float maxX = rectWorking.Right;
            float minY = rectWorking.Top;
            float maxY = rectWorking.Bottom;
            using (Graphics g = this.CreateGraphics())
            {
                PointF centrePoint = new PointF(rectWorking.Left + rectWorking.Width / 2, rectWorking.Top + rectWorking.Height / 2);
                for (int i = 0; i < radarPositions.Length; i++)
                {
                    float fltAngle = 270 + fltSplitAngle * i;
                    fltAngle = fltAngle % 360;
                    PointF _point = GetPointByAngle(centrePoint, fltAngle, fltRadiusWidth);
                    var _txtSize = g.MeasureString(radarPositions[i].Text, Font);
                    if (_point.X < centrePoint.X)//左
                    {
                        if (_point.X - _txtSize.Width < minX)
                        {
                            minX = rectWorking.Left + _txtSize.Width;
                        }
                    }
                    else//右
                    {
                        if (_point.X + _txtSize.Width > maxX)
                        {
                            maxX = rectWorking.Right - _txtSize.Width;
                        }
                    }
                    if (_point.Y < centrePoint.Y)//上
                    {
                        if (_point.Y - _txtSize.Height < minY)
                        {
                            minY = rectWorking.Top + _txtSize.Height;
                        }
                    }
                    else//下
                    {
                        if (_point.Y + _txtSize.Height > maxY)
                        {
                            maxY = rectWorking.Bottom - _txtSize.Height;
                        }
                    }
                }
            }

            min = Math.Min(maxX - minX, maxY - minY);
            m_rectWorking = new RectangleF(minX, minY, min, min);
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();

            if (!string.IsNullOrEmpty(title))
            {
                g.DrawString(title, titleFont, new SolidBrush(titleColor), new RectangleF(m_rectWorking.Left + (m_rectWorking.Width - titleSize.Width) / 2, m_rectWorking.Top - titleSize.Height - 10 - (intLineValueRowCount * (10 + lineValueTypeSize.Height)), titleSize.Width, titleSize.Height));
            }

            if (radarPositions.Length <= 2)
            {
                g.DrawString("至少需要3个顶点", Font, new SolidBrush(Color.Black), m_rectWorking, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                return;
            }

            var y = m_rectWorking.Top - 20 - (intLineValueRowCount * (10 + lineValueTypeSize.Height));

            for (int i = 0; i < intLineValueRowCount; i++)
            {
                var x = 0f;
                int intCount = intLineValueComCount;
                if (i == intLineValueRowCount - 1)
                {
                    intCount = lines.Length % intLineValueComCount;

                }
                x = m_rectWorking.Left + (m_rectWorking.Width - intCount * (lineValueTypeSize.Width + 25)) / 2;

                for (int j = 0; j < intCount; j++)
                {
                    g.FillRectangle(new SolidBrush(lines[i * intLineValueComCount + j].LineColor.Value), new RectangleF(x + (lineValueTypeSize.Width + 25) * j, y + lineValueTypeSize.Height * i, 15, lineValueTypeSize.Height));
                    g.DrawString(lines[i * intLineValueComCount + j].Name, Font, new SolidBrush(lines[i * intLineValueComCount + j].LineColor.Value), new PointF(x + (lineValueTypeSize.Width + 25) * j + 20, y + lineValueTypeSize.Height * i));
                }
            }

            float fltSplitAngle = 360F / radarPositions.Length;
            float fltRadiusWidth = m_rectWorking.Width / 2;
            float fltSplitRadiusWidth = fltRadiusWidth / splitCount;
            PointF centrePoint = new PointF(m_rectWorking.Left + m_rectWorking.Width / 2, m_rectWorking.Top + m_rectWorking.Height / 2);

            List<List<PointF>> lstRingPoints = new List<List<PointF>>(splitCount);
            //分割点
            for (int i = 0; i < radarPositions.Length; i++)
            {
                float fltAngle = 270 + fltSplitAngle * i;
                fltAngle = fltAngle % 360;
                for (int j = 0; j < splitCount; j++)
                {
                    if (i == 0)
                    {
                        lstRingPoints.Add(new List<PointF>());
                    }
                    PointF _point = GetPointByAngle(centrePoint, fltAngle, fltSplitRadiusWidth * (splitCount - j));
                    lstRingPoints[j].Add(_point);
                }
            }

            if (UseRoundSplit)
            {
                for (int i = 0; i < splitCount; i++)
                {
                    RectangleF rect = new RectangleF(centrePoint.X - fltSplitRadiusWidth * (splitCount - i), centrePoint.Y - fltSplitRadiusWidth * (splitCount - i), fltSplitRadiusWidth * (splitCount - i) * 2, fltSplitRadiusWidth * (splitCount - i) * 2);
                    if (i % 2 == 0)
                    {
                        g.FillEllipse(new SolidBrush(splitOddColor), rect);
                    }
                    else
                    {
                        g.FillEllipse(new SolidBrush(splitEvenColor), rect);
                    }

                    g.DrawEllipse(new Pen(new SolidBrush(lineColor)), rect);
                }
            }
            else
            {
                //间隔颜色
                for (int i = 0; i < lstRingPoints.Count; i++)
                {
                    var ring = lstRingPoints[i];
                    GraphicsPath path = new GraphicsPath();
                    path.AddLines(ring.ToArray());
                    if ((lstRingPoints.Count - i) % 2 == 0)
                    {
                        g.FillPath(new SolidBrush(splitEvenColor), path);
                    }
                    else
                    {
                        g.FillPath(new SolidBrush(splitOddColor), path);
                    }
                }
                //画环
                foreach (var ring in lstRingPoints)
                {
                    ring.Add(ring[0]);
                    g.DrawLines(new Pen(new SolidBrush(lineColor)), ring.ToArray());
                }
            }
            //分割线
            foreach (var item in lstRingPoints[0])
            {
                g.DrawLine(new Pen(new SolidBrush(lineColor)), centrePoint, item);
            }

            //值
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line.Values.Length != radarPositions.Length)//如果数据长度和节点长度不一致则不绘制
                    continue;
                if (line.LineColor == null || line.LineColor == Color.Empty || line.LineColor == Color.Transparent)
                    line.LineColor = ControlHelper.Colors[i + 13];
                List<PointF> ps = new List<PointF>();
                for (int j = 0; j < radarPositions.Length; j++)
                {
                    float fltAngle = 270 + fltSplitAngle * j;
                    fltAngle = fltAngle % 360;
                    PointF _point = GetPointByAngle(centrePoint, fltAngle, fltRadiusWidth * (float)(line.Values[j] / radarPositions[i].MaxValue));
                    ps.Add(_point);
                }
                ps.Add(ps[0]);
                if (line.FillColor != null && line.FillColor != Color.Empty && line.FillColor != Color.Transparent)
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddLines(ps.ToArray());
                    g.FillPath(new SolidBrush(line.FillColor.Value), path);
                }
                g.DrawLines(new Pen(new SolidBrush(line.LineColor.Value), 2), ps.ToArray());

                for (int j = 0; j < radarPositions.Length; j++)
                {
                    var item = ps[j];
                    g.FillEllipse(new SolidBrush(Color.White), new RectangleF(item.X - 3, item.Y - 3, 6, 6));
                    g.DrawEllipse(new Pen(new SolidBrush(line.LineColor.Value)), new RectangleF(item.X - 3, item.Y - 3, 6, 6));
                    if (line.ShowValueText)
                    {
                        var valueSize = g.MeasureString(line.Values[j].ToString("0.##"), Font);
                        g.DrawString(line.Values[j].ToString("0.##"), Font, new SolidBrush(line.LineColor.Value), new PointF(item.X - valueSize.Width / 2, item.Y - valueSize.Height - 5));
                    }
                }
            }

            //文本

            for (int i = 0; i < radarPositions.Length; i++)
            {
                PointF point = lstRingPoints[0][i];
                var txtSize = g.MeasureString(radarPositions[i].Text, Font);

                if (point.X == centrePoint.X)
                {
                    if (point.Y > centrePoint.Y)
                    {
                        g.DrawString(radarPositions[i].Text, Font, new SolidBrush(ForeColor), new PointF(point.X - txtSize.Width / 2, point.Y + 10));
                    }
                    else
                    {
                        g.DrawString(radarPositions[i].Text, Font, new SolidBrush(ForeColor), new PointF(point.X - txtSize.Width / 2, point.Y - 10 - txtSize.Height));
                    }
                }
                else if (point.Y == centrePoint.Y)
                {
                    if (point.X < centrePoint.X)
                        g.DrawString(radarPositions[i].Text, Font, new SolidBrush(ForeColor), new PointF(point.X - 10 - txtSize.Width, point.Y - txtSize.Height / 2));
                    else
                        g.DrawString(radarPositions[i].Text, Font, new SolidBrush(ForeColor), new PointF(point.X + 10, point.Y - txtSize.Height / 2));
                }
                else if (point.X < centrePoint.X)//左
                {
                    if (point.Y < centrePoint.Y)//左上
                    {
                        g.DrawString(radarPositions[i].Text, Font, new SolidBrush(ForeColor), new PointF(point.X - 10 - txtSize.Width, point.Y - 10 + txtSize.Height / 2));
                    }
                    else//左下
                    {
                        g.DrawString(radarPositions[i].Text, Font, new SolidBrush(ForeColor), new PointF(point.X - 10 - txtSize.Width, point.Y + 10 - txtSize.Height / 2));
                    }
                }
                else
                {
                    if (point.Y < centrePoint.Y)//右上
                    {
                        g.DrawString(radarPositions[i].Text, Font, new SolidBrush(ForeColor), new PointF(point.X + 10, point.Y - 10 + txtSize.Height / 2));
                    }
                    else//右下
                    {
                        g.DrawString(radarPositions[i].Text, Font, new SolidBrush(ForeColor), new PointF(point.X + 10, point.Y + 10 - txtSize.Height / 2));
                    }
                }
            }

        }

        #region 根据中心点、角度、半径计算圆边坐标点    English:Calculating the coordinate points of circular edge according to the center point, angle and radius
        /// <summary>
        /// 功能描述:根据中心点、角度、半径计算圆边坐标点    English:Calculating the coordinate points of circular edge according to the center point, angle and radius
        /// 作　　者:HZH
        /// 创建日期:2019-09-25 09:46:32
        /// 任务编号:POS
        /// </summary>
        /// <param name="centrePoint">centrePoint</param>
        /// <param name="fltAngle">fltAngle</param>
        /// <param name="fltRadiusWidth">fltRadiusWidth</param>
        /// <returns>返回值</returns>
        private PointF GetPointByAngle(PointF centrePoint, float fltAngle, float fltRadiusWidth)
        {
            PointF p = centrePoint;
            if (fltAngle == 0)
            {
                p.X += fltRadiusWidth;
            }
            else if (fltAngle == 90)
            {
                p.Y += fltRadiusWidth;
            }
            else if (fltAngle == 180)
            {
                p.X -= fltRadiusWidth;
            }
            else if (fltAngle == 270)
            {
                p.Y -= fltRadiusWidth;
            }
            else if (fltAngle > 0 && fltAngle < 90)
            {
                p.Y += (float)Math.Sin(Math.PI * (fltAngle / 180.00F)) * fltRadiusWidth;
                p.X += (float)Math.Cos(Math.PI * (fltAngle / 180.00F)) * fltRadiusWidth;
            }
            else if (fltAngle > 90 && fltAngle < 180)
            {
                p.Y += (float)Math.Sin(Math.PI * ((180 - fltAngle) / 180.00F)) * fltRadiusWidth;
                p.X -= (float)Math.Cos(Math.PI * ((180 - fltAngle) / 180.00F)) * fltRadiusWidth;
            }
            else if (fltAngle > 180 && fltAngle < 270)
            {
                p.Y -= (float)Math.Sin(Math.PI * ((fltAngle - 180) / 180.00F)) * fltRadiusWidth;
                p.X -= (float)Math.Cos(Math.PI * ((fltAngle - 180) / 180.00F)) * fltRadiusWidth;
            }
            else if (fltAngle > 270 && fltAngle < 360)
            {
                p.Y -= (float)Math.Sin(Math.PI * ((360 - fltAngle) / 180.00F)) * fltRadiusWidth;
                p.X += (float)Math.Cos(Math.PI * ((360 - fltAngle) / 180.00F)) * fltRadiusWidth;
            }
            return p;
        }
        #endregion

        /// <summary>
        /// Resets the size of the title.
        /// </summary>
        private void ResetTitleSize()
        {
            if (!string.IsNullOrEmpty(title))
            {
                using (Graphics g = this.CreateGraphics())
                {
                    titleSize = g.MeasureString(title, titleFont);
                }
            }
            else
            {
                titleSize = SizeF.Empty;
            }
            titleSize.Height += 20;
            ResetWorkingRect();
        }
    }
}
