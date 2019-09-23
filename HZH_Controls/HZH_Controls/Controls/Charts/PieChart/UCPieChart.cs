// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-23
//
// ***********************************************************************
// <copyright file="UCPieChart.cs">
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCPieChart.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCPieChart : UserControl
    {
        /// <summary>
        /// The percent color
        /// </summary>
        private Color percentColor = Color.DodgerBlue;

        /// <summary>
        /// The pie items
        /// </summary>
        private PieItem[] pieItems = new PieItem[0];

        /// <summary>
        /// The random
        /// </summary>
        private Random random = null;

        /// <summary>
        /// The format center
        /// </summary>
        private StringFormat formatCenter = null;

        /// <summary>
        /// The margin
        /// </summary>
        private int margin = 50;

        /// <summary>
        /// The m is render percent
        /// </summary>
        private bool m_IsRenderPercent = false;

        /// <summary>
        /// The percen format
        /// </summary>
        private string percenFormat = "{0:F2}%";

        /// <summary>
        /// The components
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is render percent.
        /// </summary>
        /// <value><c>true</c> if this instance is render percent; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("自定义")]
        [DefaultValue(false)]
        [Description("获取或设置是否显示百分比占用")]
        public bool IsRenderPercent
        {
            get
            {
                return m_IsRenderPercent;
            }
            set
            {
                m_IsRenderPercent = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the text margin.
        /// </summary>
        /// <value>The text margin.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置文本距离，单位为像素，默认50")]
        [DefaultValue(50)]
        public int TextMargin
        {
            get
            {
                return margin;
            }
            set
            {
                margin = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the percent format.
        /// </summary>
        /// <value>The percent format.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置文百分比文字的格式化信息")]
        [DefaultValue("{0:F2}%")]
        public string PercentFormat
        {
            get
            {
                return percenFormat;
            }
            set
            {
                percenFormat = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The center of circle color
        /// </summary>
        private Color centerOfCircleColor = Color.White;
        /// <summary>
        /// Gets or sets the color of the center of circle.
        /// </summary>
        /// <value>The color of the center of circle.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置圆心颜色")]
        public Color CenterOfCircleColor
        {
            get { return centerOfCircleColor; }
            set
            {
                centerOfCircleColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The center of circle width
        /// </summary>
        private int centerOfCircleWidth = 0;
        /// <summary>
        /// Gets or sets the width of the center of circle.
        /// </summary>
        /// <value>The width of the center of circle.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置圆心宽度")]
        public int CenterOfCircleWidth
        {
            get { return centerOfCircleWidth; }
            set
            {
                if (value < 0)
                    return;
                centerOfCircleWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The title
        /// </summary>
        private string title;
        /// <summary>
        /// Gets or sets the ti tle.
        /// </summary>
        /// <value>The ti tle.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置标题")]
        public string TiTle
        {
            get { return title; }
            set
            {
                title = value;
                ResetTitleHeight();
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
                ResetTitleHeight();
                Invalidate();
            }
        }

        /// <summary>
        /// The title froe color
        /// </summary>
        private Color titleFroeColor = Color.Black;
        /// <summary>
        /// Gets or sets the color of the title froe.
        /// </summary>
        /// <value>The color of the title froe.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置标题颜色")]
        public Color TitleFroeColor
        {
            get { return titleFroeColor; }
            set
            {
                titleFroeColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The title size
        /// </summary>
        private SizeF titleSize = SizeF.Empty;
        /// <summary>
        /// Resets the height of the title.
        /// </summary>
        private void ResetTitleHeight()
        {
            if (string.IsNullOrEmpty(title))
                titleSize = SizeF.Empty;
            else
            {
                using (var g = this.CreateGraphics())
                {
                    titleSize = g.MeasureString(title, titleFont);
                }
            }
        }

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        [Browsable(true)]
        [Category("自定义")]
        [Description("获取或设置标题颜色")]
        [Localizable(true)]
        public PieItem[] DataSource
        {
            get { return pieItems; }
            set
            {
                pieItems = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCPieChart"/> class.
        /// </summary>
        public UCPieChart()
        {
            InitializeComponent();
            random = new Random();
            formatCenter = new StringFormat();
            formatCenter.Alignment = StringAlignment.Center;
            formatCenter.LineAlignment = StringAlignment.Center;
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            pieItems = new PieItem[0];
            if (GetService(typeof(IDesignerHost)) != null || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                pieItems = new PieItem[5];

                for (int i = 0; i < 5; i++)
                {
                    pieItems[i] = new PieItem
                    {
                        Name = "Source" + (i + 1),
                        Value = random.Next(10, 100)
                    };
                }
            }
        }

        /// <summary>
        /// Sets the margin paint.
        /// </summary>
        /// <param name="value">The value.</param>
        private void SetMarginPaint(int value)
        {
            if (value > 500)
            {
                margin = 80;
            }
            else if (value > 300)
            {
                margin = 60;
            }
            else
            {
                margin = 40;
            }
        }

        /// <summary>
        /// Gets the center point.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns>Point.</returns>
        private Point GetCenterPoint(out int width)
        {
            width = Math.Min(base.Width, base.Height - (titleSize != SizeF.Empty ? ((int)titleSize.Height) : 0)) / 2 - margin - 8;
            return new Point(base.Width / 2 - 1, base.Height / 2 + (titleSize != SizeF.Empty ? ((int)titleSize.Height) : 0) - 1);
        }

        /// <summary>
        /// Gets the random color.
        /// </summary>
        /// <returns>Color.</returns>
        private Color GetRandomColor()
        {
            int num = random.Next(256);
            int num2 = random.Next(256);
            int blue = (num + num2 > 430) ? random.Next(100) : random.Next(200);
            return Color.FromArgb(num, num2, blue);
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SetGDIHigh();

            int width;
            Point centerPoint = GetCenterPoint(out width);
            Rectangle rectangle = new Rectangle(centerPoint.X - width, centerPoint.Y - width, width * 2, width * 2);
            if (width > 0 && pieItems.Length != 0)
            {
                if (!string.IsNullOrEmpty(title))
                    e.Graphics.DrawString(title, titleFont, new SolidBrush(titleFroeColor), new PointF((this.Width - titleSize.Width) / 2, 5));
                //e.Graphics.FillEllipse(Brushes.AliceBlue, rectangle);
                //e.Graphics.DrawEllipse(Pens.DodgerBlue, rectangle);
                Rectangle rect = new Rectangle(rectangle.X - centerPoint.X, rectangle.Y - centerPoint.Y, rectangle.Width, rectangle.Height);
                e.Graphics.TranslateTransform(centerPoint.X, centerPoint.Y);
                e.Graphics.RotateTransform(90f);
                e.Graphics.DrawLine(Pens.DimGray, 0, 0, width, 0);
                int num = pieItems.Sum((PieItem item) => item.Value);
                float num2 = 0f;
                float num3 = -90f;
                for (int i = 0; i < pieItems.Length; i++)
                {
                    Color cItem = pieItems[i].PieColor ?? ControlHelper.Colors[i];
                    Pen pen = new Pen(cItem, 1f);
                    SolidBrush solidBrush = new SolidBrush(cItem);
                    SolidBrush solidBrush2 = new SolidBrush(cItem);
                    Brush percentBrush = new SolidBrush(cItem);
                    float num4 = e.Graphics.MeasureString(pieItems[i].Name, Font).Width + 3f;
                    float num5 = (num != 0) ? Convert.ToSingle((double)pieItems[i].Value * 1.0 / (double)num * 360.0) : ((float)(360 / pieItems.Length));
                    e.Graphics.FillPie(solidBrush, rect, 0f, 0f - num5);
                    e.Graphics.DrawPie(new Pen(solidBrush), rect, 0f, 0f - num5);
                    e.Graphics.RotateTransform(0f - num5 / 2f);
                    if (num5 < 2f)
                    {
                        num2 += num5;
                    }
                    else
                    {
                        num2 += num5 / 2f;
                        int num6 = 15;
                        if (num2 < 45f || num2 > 315f)
                        {
                            num6 = 20;
                        }
                        if (num2 > 135f && num2 < 225f)
                        {
                            num6 = 20;
                        }
                        e.Graphics.DrawLine(pen, width * 2 / 3, 0, width + num6, 0);
                        e.Graphics.TranslateTransform(width + num6, 0f);
                        if (num2 - num3 < 5f)
                        {
                        }
                        num3 = num2;
                        if (num2 < 180f)
                        {
                            e.Graphics.RotateTransform(num2 - 90f);
                            e.Graphics.DrawLine(pen, 0f, 0f, num4, 0f);
                            e.Graphics.DrawString(pieItems[i].Name, Font, solidBrush2, new Point(0, -Font.Height));
                            if (IsRenderPercent)
                            {
                                e.Graphics.DrawString(string.Format(percenFormat, num5 * 100f / 360f), Font, percentBrush, new Point(0, 1));
                            }
                            e.Graphics.RotateTransform(90f - num2);
                        }
                        else
                        {
                            e.Graphics.RotateTransform(num2 - 270f);
                            e.Graphics.DrawLine(pen, 0f, 0f, num4, 0f);
                            e.Graphics.TranslateTransform(num4 - 3f, 0f);
                            e.Graphics.RotateTransform(180f);
                            e.Graphics.DrawString(pieItems[i].Name, Font, solidBrush2, new Point(0, -Font.Height));
                            if (IsRenderPercent)
                            {
                                e.Graphics.DrawString(string.Format(percenFormat, num5 * 100f / 360f), Font, percentBrush, new Point(0, 1));
                            }
                            e.Graphics.RotateTransform(-180f);
                            e.Graphics.TranslateTransform(0f - num4 + 3f, 0f);
                            e.Graphics.RotateTransform(270f - num2);
                        }
                        e.Graphics.TranslateTransform(-width - num6, 0f);
                        e.Graphics.RotateTransform(0f - num5 / 2f);
                        num2 += num5 / 2f;
                    }
                    solidBrush.Dispose();
                    pen.Dispose();
                    solidBrush2.Dispose();
                    percentBrush.Dispose();
                }
                e.Graphics.ResetTransform();

                if (centerOfCircleWidth > 0)
                {
                    Rectangle rectCenter = new Rectangle(rect.Left + rect.Width / 2 - centerOfCircleWidth / 2, rect.Top + rect.Height / 2 - centerOfCircleWidth / 2, centerOfCircleWidth, centerOfCircleWidth);
                    e.Graphics.FillEllipse(new SolidBrush(centerOfCircleColor), rectCenter);
                }
            }
            else
            {
                e.Graphics.FillEllipse(Brushes.AliceBlue, rectangle);
                e.Graphics.DrawEllipse(Pens.DodgerBlue, rectangle);
                e.Graphics.DrawString("空", Font, Brushes.DimGray, rectangle, formatCenter);
            }
            base.OnPaint(e);
        }
        /// <summary>
        /// Sets the data source.
        /// </summary>
        /// <param name="source">The source.</param>
        public void SetDataSource(PieItem[] source)
        {
            if (source != null)
            {
                DataSource = source;
            }
        }
        /// <summary>
        /// Sets the data source.
        /// </summary>
        /// <param name="names">The names.</param>
        /// <param name="values">The values.</param>
        /// <exception cref="System.ArgumentNullException">
        /// names
        /// or
        /// values
        /// </exception>
        /// <exception cref="System.Exception">两个数组的长度不一致！</exception>
        public void SetDataSource(string[] names, int[] values)
        {
            if (names == null)
            {
                throw new ArgumentNullException("names");
            }
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            if (names.Length != values.Length)
            {
                throw new Exception("两个数组的长度不一致！");
            }
            pieItems = new PieItem[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                pieItems[i] = new PieItem
                {
                    Name = names[i],
                    Value = values[i]
                };
            }
            Invalidate();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">为 true 则释放托管资源和非托管资源；为 false 则仅释放非托管资源。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.Transparent;
            base.Name = "UCPieChart";
            ResumeLayout(false);
        }
    }
}
