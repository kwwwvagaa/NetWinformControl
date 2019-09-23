// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="UCBarChart.cs">
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Linq;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCBarChart.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCBarChart : UCControlBase
    {
        /// <summary>
        /// The auxiliary lines
        /// </summary>
        private List<AuxiliaryLine> auxiliary_lines;

        /// <summary>
        /// The value maximum left
        /// </summary>
        private int value_max_left = -1;

        /// <summary>
        /// The value minimum left
        /// </summary>
        private int value_min_left = 0;

        /// <summary>
        /// The value segment
        /// </summary>
        private int value_Segment = 5;

        /// <summary>
        /// The data values
        /// </summary>
        private double[][] data_values = null;

        /// <summary>
        /// The data texts
        /// </summary>
        private string[] data_texts = null;

        ///// <summary>
        ///// The data colors
        ///// </summary>
        //private Color[] data_colors = null;

        /// <summary>
        /// The brush deep
        /// </summary>
        private Brush brush_deep = null;

        /// <summary>
        /// The pen normal
        /// </summary>
        private Pen pen_normal = null;

        /// <summary>
        /// The pen dash
        /// </summary>
        private Pen pen_dash = null;

        /// <summary>
        /// The bar back color
        /// </summary>
        //private Color barBackColor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// The use gradient
        /// </summary>
        private bool useGradient = false;

        /// <summary>
        /// The color deep
        /// </summary>
        private Color color_deep = Color.FromArgb(150, 255, 77, 59);

        /// <summary>
        /// The color dash
        /// </summary>
        private Color color_dash = Color.FromArgb(50, 255, 77, 59);

        /// <summary>
        /// The format left
        /// </summary>
        private StringFormat format_left = null;

        /// <summary>
        /// The format right
        /// </summary>
        private StringFormat format_right = null;

        /// <summary>
        /// The format center
        /// </summary>
        private StringFormat format_center = null;

        /// <summary>
        /// The value is render dash line
        /// </summary>
        private bool value_IsRenderDashLine = true;

        /// <summary>
        /// The is show bar value
        /// </summary>
        private bool isShowBarValue = true;

        /// <summary>
        /// The show bar value format
        /// </summary>
        private string showBarValueFormat = "{0}";

        /// <summary>
        /// The value title
        /// </summary>
        private string value_title = "";

        /// <summary>
        /// The bar percent width
        /// </summary>
        private float barPercentWidth = 0.9f;

        /// <summary>
        /// The components
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 获取或设置控件的背景色。
        /// </summary>
        /// <value>The color of the back.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [Browsable(true)]
        [Description("获取或设置控件的背景色")]
        [Category("自定义")]
        [DefaultValue(typeof(Color), "Transparent")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Browsable(true)]
        [Description("获取或设置当前控件的文本")]
        [Category("自定义")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 获取或设置控件的前景色。
        /// </summary>
        /// <value>The color of the fore.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [Browsable(true)]
        [Description("获取或设置控件的前景色")]
        [Category("自定义")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color lines and text.
        /// </summary>
        /// <value>The color lines and text.</value>
        [Category("自定义")]
        [Description("获取或设置坐标轴及相关信息文本的颜色")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "DimGray")]
        public Color ColorLinesAndText
        {
            get
            {
                return color_deep;
            }
            set
            {
                color_deep = value;
                InitializationColor();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use gradient].
        /// </summary>
        /// <value><c>true</c> if [use gradient]; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("获取或设置本条形图控件是否使用渐进色")]
        [Browsable(true)]
        [DefaultValue(false)]
        public bool UseGradient
        {
            get
            {
                return useGradient;
            }
            set
            {
                useGradient = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color dash lines.
        /// </summary>
        /// <value>The color dash lines.</value>
        [Category("自定义")]
        [Description("获取或设置虚线的颜色")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "LightGray")]
        public Color ColorDashLines
        {
            get
            {
                return color_dash;
            }
            set
            {
                color_dash = value;
                if (pen_dash != null)
                    pen_dash.Dispose();
                pen_dash = new Pen(color_dash);
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is render dash line.
        /// </summary>
        /// <value><c>true</c> if this instance is render dash line; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("获取或设置虚线是否进行显示")]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool IsRenderDashLine
        {
            get
            {
                return value_IsRenderDashLine;
            }
            set
            {
                value_IsRenderDashLine = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value segment.
        /// </summary>
        /// <value>The value segment.</value>
        [Category("自定义")]
        [Description("获取或设置图形的纵轴分段数")]
        [Browsable(true)]
        [DefaultValue(5)]
        public int ValueSegment
        {
            get
            {
                return value_Segment;
            }
            set
            {
                value_Segment = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value maximum left.
        /// </summary>
        /// <value>The value maximum left.</value>
        [Category("自定义")]
        [Description("获取或设置图形的左纵坐标的最大值，该值必须大于最小值，该值为负数，最大值即为自动适配。")]
        [Browsable(true)]
        [DefaultValue(-1)]
        public int ValueMaxLeft
        {
            get
            {
                return value_max_left;
            }
            set
            {
                value_max_left = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value minimum left.
        /// </summary>
        /// <value>The value minimum left.</value>
        [Category("自定义")]
        [Description("获取或设置图形的左纵坐标的最小值，该值必须小于最大值")]
        [Browsable(true)]
        [DefaultValue(0)]
        public int ValueMinLeft
        {
            get
            {
                return value_min_left;
            }
            set
            {
                if (value < value_max_left)
                {
                    value_min_left = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Category("自定义")]
        [Description("获取或设置图标的标题信息")]
        [Browsable(true)]
        [DefaultValue("")]
        public string Title
        {
            get
            {
                return value_title;
            }
            set
            {
                value_title = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is show bar value.
        /// </summary>
        /// <value><c>true</c> if this instance is show bar value; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("获取或设置是否显示柱状图的值文本")]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool IsShowBarValue
        {
            get
            {
                return isShowBarValue;
            }
            set
            {
                isShowBarValue = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the show bar value format.
        /// </summary>
        /// <value>The show bar value format.</value>
        [Category("自定义")]
        [Description("获取或设置柱状图显示值的格式化信息，可以带单位")]
        [Browsable(true)]
        [DefaultValue("")]
        public string ShowBarValueFormat
        {
            get
            {
                return showBarValueFormat;
            }
            set
            {
                showBarValueFormat = value;
                Invalidate();
            }
        }

        private BarChartItem[] barChartItems = new BarChartItem[] { new BarChartItem() };
        [Category("自定义")]
        [Description("获取或设置柱状图的项目")]
        [Browsable(true)]
        public BarChartItem[] BarChartItems
        {
            get { return barChartItems; }
            set { barChartItems = value; }
        }
        [Category("自定义")]
        [Description("获取或设置是否显示柱状图的项目名称")]
        [Browsable(true)]
        public bool ShowChartItemName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCBarChart"/> class.
        /// </summary>
        public UCBarChart()
        {
            InitializeComponent();
            ConerRadius = 10;
            ForeColor = Color.FromArgb(150, 255, 77, 59);
            FillColor = Color.FromArgb(243, 220, 219);
            format_left = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            };
            format_right = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Far
            };
            format_center = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            auxiliary_lines = new List<AuxiliaryLine>();
            pen_dash = new Pen(color_dash);
            pen_dash.DashStyle = DashStyle.Custom;
            pen_dash.DashPattern = new float[2]
			{
				5f,
				5f
			};
            InitializationColor();
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            if (DesignMode)
            {
                barChartItems = new BarChartItem[] { new BarChartItem() };

                data_values = new double[5][];
                for (int i = 0; i < data_values.Length; i++)
                {
                    data_values[i] = new double[] { i + 1 };
                }
            }

        }

        /// <summary>
        /// Initializations the color.
        /// </summary>
        private void InitializationColor()
        {
            if (pen_normal != null)
                pen_normal.Dispose();
            if (brush_deep != null)
                brush_deep.Dispose();
            pen_normal = new Pen(color_deep);
            brush_deep = new SolidBrush(color_deep);
        }
        /// <summary>
        /// Sets the data source.
        /// </summary>
        /// <param name="data">The data.</param>
        public void SetDataSource(double[] data)
        {
            SetDataSource(data, null);
        }

        public void SetDataSource(double[][] data)
        {
            SetDataSource(data, null);
        }
        /// <summary>
        /// Sets the data source.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="texts">X texts</param>
        public void SetDataSource(double[] data, string[] texts)
        {
            data_values = new double[data.Length][];
            for (int i = 0; i < data.Length; i++)
            {
                data_values[i] = new double[] { data[i] };
            }
            if (barChartItems == null || barChartItems.Length <= 0)
                barChartItems = new BarChartItem[] { new BarChartItem() };
            data_texts = texts;
            Invalidate();
        }
        public void SetDataSource(double[][] data, string[] texts)
        {
            data_values = data;
            if (barChartItems == null || barChartItems.Length <= 0)
                barChartItems = new BarChartItem[] { new BarChartItem() };
            data_texts = texts;
            Invalidate();
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            PaintMain(graphics, base.Width, base.Height);
        }

        /// <summary>
        /// Paints the main.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private void PaintMain(Graphics g, int width, int height)
        {
            if (barChartItems == null || barChartItems.Length <= 0)
            {
                if (DesignMode)
                {
                    barChartItems = new BarChartItem[] { new BarChartItem() };
                }
                else
                {
                    return;
                }
            }
            if (data_values == null && DesignMode)
            {
                data_values = new double[5][];
                for (int i = 0; i < data_values.Length; i++)
                {
                    data_values[i] = new double[] { i + 1 };
                }
            }

            double num = (data_values != null && data_values.Length != 0) ? ControlHelper.CalculateMaxSectionFrom(data_values) : 5;
            if (value_max_left > 0)
            {
                num = value_max_left;
            }
            int intLeftX = (int)g.MeasureString(num.ToString(), Font).Width + 3;
            if (intLeftX < 50)
            {
                intLeftX = 50;
            }
            //处理辅助线左侧间距
            if (auxiliary_lines != null && auxiliary_lines.Count > 0)
            {
                var maxAuxiliaryWidth = auxiliary_lines.Max(p => g.MeasureString((p.Tip + "" + p.Value), Font).Width);
                if (intLeftX < maxAuxiliaryWidth)
                {
                    intLeftX = (int)maxAuxiliaryWidth + 5;
                }
            }
            int intRightX = 20;
            //顶部距离
            int intTopY = 25;
            if (!string.IsNullOrEmpty(value_title))
            {
                intTopY += 20;
            }
            //写标题
            if (!string.IsNullOrEmpty(value_title))
            {
                g.DrawString(value_title, Font, brush_deep, new Rectangle(0, 0, width - 1, intTopY - 10), format_center);
            }
            //画项目名称颜色
            if (ShowChartItemName && !(barChartItems.Length == 1 && string.IsNullOrEmpty(barChartItems[0].ItemName)))
            {
                int intItemNameRowCount = 0;
                int intItemNameWidth = 0;
                int intItemNameComCount = 0;

                intItemNameWidth = (int)barChartItems.Max(p => g.MeasureString(p.ItemName, Font).Width) + 40;
                intItemNameComCount = this.Width / intItemNameWidth;
                intItemNameRowCount = barChartItems.Length / intItemNameComCount + (barChartItems.Length % intItemNameComCount != 0 ? 1 : 0);
                int intItemNameHeight = (int)g.MeasureString("A", Font).Height;

                for (int i = 0; i < intItemNameRowCount; i++)
                {
                    int intLeft = (this.Width - (intItemNameWidth * ((i == intItemNameRowCount - 1) ? (barChartItems.Length % intItemNameComCount) : intItemNameComCount))) / 2;
                    int intTop = intTopY - 15 + intItemNameHeight * i + 10;
                    for (int j = i * intItemNameComCount; j < barChartItems.Length && j < (i + 1) * intItemNameComCount; j++)
                    {
                        Rectangle rectColor = new Rectangle(intLeft + (j % intItemNameComCount) * intItemNameWidth, intTop, 20, intItemNameHeight);
                        g.FillRectangle(new SolidBrush(barChartItems[j].BarBackColor??ControlHelper.Colors[j]), rectColor);
                        g.DrawString(barChartItems[j].ItemName, Font, new SolidBrush(ForeColor), new Point(rectColor.Right + 2, rectColor.Top));
                    }
                }
                intTopY += intItemNameRowCount * (intItemNameHeight + 20);
            }

            int intBottomY = 25;
            //处理x坐标文字高度
            if (data_texts != null && data_texts.Length > 0)
            {
                var maxTextsHeight = data_texts.Max(p => g.MeasureString(p, Font).Height);
                if (intBottomY < maxTextsHeight)
                    intBottomY = (int)maxTextsHeight + 5;
            }
            //画xy轴
            Point[] array2 = new Point[3]
			{
				new Point(intLeftX, intTopY - 8),
				new Point(intLeftX, height - intBottomY),
				new Point(width - intRightX+5, height - intBottomY)
			};
            g.DrawLine(pen_normal, array2[0], array2[1]);
            g.DrawLine(pen_normal, array2[1], array2[2]);
            ControlHelper.PaintTriangle(g, brush_deep, new Point(intLeftX, intTopY - 8), 4, GraphDirection.Upward);
            ControlHelper.PaintTriangle(g, brush_deep, new Point(width - intRightX + 5, height - intBottomY), 4, GraphDirection.Rightward);


            //画横向分割线
            for (int j = 0; j <= value_Segment; j++)
            {
                float value = (float)((double)j * (double)(num - value_min_left) / (double)value_Segment + (double)value_min_left);
                float num6 = ControlHelper.ComputePaintLocationY((float)num, value_min_left, height - intTopY - intBottomY, value) + (float)intTopY;
                if (IsNeedPaintDash(num6))
                {
                    g.DrawLine(pen_normal, intLeftX - 4, num6, intLeftX - 1, num6);
                    g.DrawString(layoutRectangle: new RectangleF(0f, num6 - 19f, intLeftX - 4, 40f), s: value.ToString(), font: Font, brush: brush_deep, format: format_right);
                    if (j > 0 && value_IsRenderDashLine)
                    {
                        g.DrawLine(pen_dash, intLeftX, num6, width - intRightX, num6);
                    }
                }
            }
            //计算辅助线y坐标
            for (int i = 0; i < auxiliary_lines.Count; i++)
            {
                auxiliary_lines[i].PaintValue = ControlHelper.ComputePaintLocationY((float)num, value_min_left, height - intTopY - intBottomY, auxiliary_lines[i].Value) + (float)intTopY;
            }

            //画辅助线
            for (int k = 0; k < auxiliary_lines.Count; k++)
            {
                g.DrawLine(auxiliary_lines[k].GetPen(), intLeftX - 4, auxiliary_lines[k].PaintValue, intLeftX - 1, auxiliary_lines[k].PaintValue);
                g.DrawString(layoutRectangle: new RectangleF(0f, auxiliary_lines[k].PaintValue - 9f, intLeftX - 4, 20f), s: auxiliary_lines[k].Tip + "" + auxiliary_lines[k].Value.ToString(), font: Font, brush: auxiliary_lines[k].LineTextBrush, format: format_right);
                g.DrawLine(auxiliary_lines[k].GetPen(), intLeftX, auxiliary_lines[k].PaintValue, width - intRightX, auxiliary_lines[k].PaintValue);
            }
            if (data_values == null || data_values.Length == 0 || data_values.Max(p => p.Length) <= 0)
            {
                return;
            }

            //x轴分隔宽度
            float fltSplitWidth = (float)(width - intLeftX - 1 - intRightX) * 1f / (float)data_values.Length;
            for (int i = 0; i < data_values.Length; i++)
            {
                int intItemSplitCount = barChartItems.Length;
                float _fltSplitWidth = fltSplitWidth * barPercentWidth / intItemSplitCount;
                float _fltLeft = (float)i * fltSplitWidth + (1f - barPercentWidth) / 2f * fltSplitWidth + (float)intLeftX;
                for (int j = 0; j < data_values[i].Length; j++)
                {
                    if (j >= intItemSplitCount)
                    {
                        break;
                    }
                    float fltValueY = ControlHelper.ComputePaintLocationY((float)num, value_min_left, height - intTopY - intBottomY, (float)data_values[i][j]) + (float)intTopY;


                    RectangleF rect = new RectangleF(_fltLeft + _fltSplitWidth * j + (1F - barChartItems[j].BarPercentWidth) * _fltSplitWidth / 2f, fltValueY,
                    _fltSplitWidth * barChartItems[j].BarPercentWidth, (float)(height - intBottomY) - fltValueY);

                    Color color = barChartItems[j].BarBackColor ?? ControlHelper.Colors[j];

                    //画柱状
                    if (useGradient)
                    {
                        if (rect.Height > 0f)
                        {
                            using (LinearGradientBrush brush = new LinearGradientBrush(new PointF(rect.X, rect.Y + rect.Height), new PointF(rect.X, rect.Y), ControlHelper.GetColorLight(color), color))
                            {
                                g.FillRectangle(brush, rect);
                            }
                        }
                    }
                    else
                    {
                        using (Brush brush2 = new SolidBrush(color))
                        {
                            g.FillRectangle(brush2, rect);
                        }
                    }
                    //写值文字
                    if (isShowBarValue)
                    {
                        using (Brush brush3 = new SolidBrush(ForeColor))
                        {
                            g.DrawString(layoutRectangle: new RectangleF(rect.Left - 50f, fltValueY - (float)Font.Height - 2f, _fltSplitWidth + 100f, Font.Height + 2), s: string.Format(showBarValueFormat, data_values[i][j]), font: Font, brush: brush3, format: format_center);
                        }
                    }
                }

                //写x轴文字
                if (data_texts != null && i < data_texts.Length)
                {
                    g.DrawString(layoutRectangle: new RectangleF((float)i * fltSplitWidth + (float)intLeftX - 50f, height - intBottomY - 1, fltSplitWidth + 100f, intBottomY + 1), s: data_texts[i], font: Font, brush: brush_deep, format: format_center);
                }
            }
        }

        /// <summary>
        /// Determines whether [is need paint dash] [the specified paint value].
        /// </summary>
        /// <param name="paintValue">The paint value.</param>
        /// <returns><c>true</c> if [is need paint dash] [the specified paint value]; otherwise, <c>false</c>.</returns>
        private bool IsNeedPaintDash(float paintValue)
        {
            if (data_values == null)
            {
                return true;
            }
            for (int i = 0; i < auxiliary_lines.Count; i++)
            {
                if (Math.Abs(auxiliary_lines[i].PaintValue - paintValue) < (float)Font.Height)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Calculats the maximum width of the text.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <returns>System.Single.</returns>
        private float calculatMaxTextWidth(Graphics g)
        {
            string[] array = data_texts;
            if (array != null && array.Length != 0)
            {
                float num = 0f;
                for (int i = 0; i < data_texts.Length; i++)
                {
                    float width = g.MeasureString(data_texts[i], Font).Width;
                    if (num < width)
                    {
                        num = width;
                    }
                }
                return num;
            }
            return 1f;
        }

        #region 辅助线    English:Guide
        /// <summary>
        /// Adds the left auxiliary.
        /// </summary>
        /// <param name="value">The value.</param>
        public void AddAuxiliaryLine(float value, string strTip = "")
        {
            AddAuxiliaryLine(value, ColorLinesAndText, strTip);
        }

        /// <summary>
        /// Adds the left auxiliary.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lineColor">Color of the line.</param>
        public void AddAuxiliaryLine(float value, Color lineColor, string strTip = "")
        {
            AddAuxiliaryLine(value, lineColor, 1f, true, strTip);
        }

        /// <summary>
        /// Adds the left auxiliary.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lineColor">Color of the line.</param>
        /// <param name="lineThickness">The line thickness.</param>
        /// <param name="isDashLine">if set to <c>true</c> [is dash line].</param>
        public void AddAuxiliaryLine(float value, Color lineColor, float lineThickness, bool isDashLine, string strTip = "")
        {
            AddAuxiliary(value, lineColor, lineThickness, isDashLine, strTip);
        }

        /// <summary>
        /// Adds the auxiliary.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lineColor">Color of the line.</param>
        /// <param name="lineThickness">The line thickness.</param>
        /// <param name="isDashLine">if set to <c>true</c> [is dash line].</param>
        /// <param name="isLeft">if set to <c>true</c> [is left].</param>
        private void AddAuxiliary(float value, Color lineColor, float lineThickness, bool isDashLine, string strTip = "")
        {
            auxiliary_lines.Add(new AuxiliaryLine
            {
                Value = value,
                LineColor = lineColor,
                PenDash = new Pen(lineColor)
                {
                    DashStyle = DashStyle.Custom,
                    DashPattern = new float[2]
					{
						5f,
						5f
					}
                },
                PenSolid = new Pen(lineColor),
                IsDashStyle = isDashLine,
                LineThickness = lineThickness,
                LineTextBrush = new SolidBrush(lineColor),
                Tip = strTip
            });
            Invalidate();
        }

        /// <summary>
        /// Removes the auxiliary.
        /// </summary>
        /// <param name="value">The value.</param>
        public void RemoveAuxiliary(float value)
        {
            int num = 0;
            for (int num2 = auxiliary_lines.Count - 1; num2 >= 0; num2--)
            {
                if (auxiliary_lines[num2].Value == value)
                {
                    auxiliary_lines[num2].Dispose();
                    auxiliary_lines.RemoveAt(num2);
                    num++;
                }
            }
            if (num > 0)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// Removes all auxiliary.
        /// </summary>
        public void RemoveAllAuxiliary()
        {
            int count = auxiliary_lines.Count;
            auxiliary_lines.Clear();
            if (count > 0)
            {
                Invalidate();
            }
        }
        #endregion

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
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            ForeColor = System.Drawing.Color.Black;
            base.Name = "UCBarChart";
            base.Size = new System.Drawing.Size(440, 264);
            ResumeLayout(false);
        }
    }
}
