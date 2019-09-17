// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="Axis.cs">
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
using System.Drawing;
using System.Linq;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class Axis.
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Axis
    {
        /// <summary>
        /// The minimum value buf
        /// </summary>
        private double minValBuf;

        /// <summary>
        /// The maximum value buf
        /// </summary>
        private double maxValBuf;

        /// <summary>
        /// The data step
        /// </summary>
        private double dataStep;

        /// <summary>
        /// The location step
        /// </summary>
        private float locationStep;

        /// <summary>
        /// The maximum label width
        /// </summary>
        private float maxLabelWidth;

        /// <summary>
        /// The maximum label height
        /// </summary>
        private float maxLabelHeight;

        /// <summary>
        /// The chart
        /// </summary>
        private UCChart _chart;

        /// <summary>
        /// The type
        /// </summary>
        private AxisType _type;

        /// <summary>
        /// The maximum value limit
        /// </summary>
        private double _maxValueLimit = 1.0;

        /// <summary>
        /// The minimum value limit
        /// </summary>
        private double _minValueLimit = 0.0;

        /// <summary>
        /// The labels
        /// </summary>
        private List<AxisLabel> _labels = new List<AxisLabel>();

        /// <summary>
        /// The is custom labels
        /// </summary>
        private bool _isCustomLabels = false;

        /// <summary>
        /// The visible
        /// </summary>
        private bool _visible = true;

        /// <summary>
        /// The label visible
        /// </summary>
        private bool _labelVisible = true;

        /// <summary>
        /// The color
        /// </summary>
        private Color _color = Color.FromArgb(51, 51, 51);

        /// <summary>
        /// The brush
        /// </summary>
        private Brush _brush;

        /// <summary>
        /// The position
        /// </summary>
        private AxisPosition _position = AxisPosition.LeftBottom;

        /// <summary>
        /// The title
        /// </summary>
        private string _title;

        /// <summary>
        /// The is reverse
        /// </summary>
        private bool _isReverse = false;

        /// <summary>
        /// The automatic adapt
        /// </summary>
        private bool _autoAdapt = true;

        /// <summary>
        /// The zoom enabled
        /// </summary>
        private bool _zoomEnabled = true;

        /// <summary>
        /// Gets the chart.
        /// </summary>
        /// <value>The chart.</value>
        [Browsable(false)]
        public UCChart Chart
        {
            get
            {
                return _chart;
            }
            internal set
            {
                _chart = value;
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        [Browsable(false)]
        public AxisType Type
        {
            get
            {
                return _type;
            }
            internal set
            {
                _type = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum value limit.
        /// </summary>
        /// <value>The maximum value limit.</value>
        [Category("自定义")]
        [Description("最大值极限。")]
        [DefaultValue(1.0)]
        public double MaxValueLimit
        {
            get
            {
                return _maxValueLimit;
            }
            set
            {
                _maxValueLimit = value;
                MaxValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the minimum value limit.
        /// </summary>
        /// <value>The minimum value limit.</value>
        [Category("自定义")]
        [Description("最小值极限。")]
        [DefaultValue(0.0)]
        public double MinValueLimit
        {
            get
            {
                return _minValueLimit;
            }
            set
            {
                _minValueLimit = value;
                MinValue = value;
            }
        }

        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <value>The labels.</value>
        [Category("自定义")]
        [Description("标签。")]
        [TypeConverter(typeof(CollectionConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<AxisLabel> Labels
        {
            get
            {
                return _labels;
            }
            private set
            {
                _labels = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is custom labels.
        /// </summary>
        /// <value><c>true</c> if this instance is custom labels; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("是否使用自定义标签。")]
        [DefaultValue(false)]
        public bool IsCustomLabels
        {
            get
            {
                return _isCustomLabels;
            }
            set
            {
                _isCustomLabels = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Axis"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("显示/隐藏。")]
        [DefaultValue(true)]
        public bool Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                _visible = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [label visible].
        /// </summary>
        /// <value><c>true</c> if [label visible]; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("显示/隐藏标签，隐藏的标签不占用布局空间。")]
        [DefaultValue(true)]
        public bool LabelVisible
        {
            get
            {
                return _labelVisible;
            }
            set
            {
                _labelVisible = value;
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Category("自定义")]
        [Description("颜色。")]
        [DefaultValue(true)]
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                _brush = new SolidBrush(value);
            }
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        [Category("自定义")]
        [Description("位置。")]
        [DefaultValue(AxisPosition.LeftBottom)]
        public AxisPosition Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Category("自定义")]
        [Description("标题。")]
        [DefaultValue(null)]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is reverse.
        /// </summary>
        /// <value><c>true</c> if this instance is reverse; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("是否反转方向。")]
        [DefaultValue(false)]
        public bool IsReverse
        {
            get
            {
                return _isReverse;
            }
            set
            {
                _isReverse = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic adapt].
        /// </summary>
        /// <value><c>true</c> if [automatic adapt]; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("是否让数据范围自适应。")]
        [DefaultValue(true)]
        public bool AutoAdapt
        {
            get
            {
                return _autoAdapt;
            }
            set
            {
                _autoAdapt = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [zoom enabled].
        /// </summary>
        /// <value><c>true</c> if [zoom enabled]; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("缩放使能。")]
        [DefaultValue(true)]
        public bool ZoomEnabled
        {
            get
            {
                return _zoomEnabled;
            }
            set
            {
                _zoomEnabled = value;
            }
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        [Browsable(false)]
        public float Width
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        [Browsable(false)]
        public float Height
        {
            get;
            private set;
        }
        /// <summary>
        /// The maximum value
        /// </summary>
        private double maxValue = 1.0;
        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        [Browsable(false)]
        public double MaxValue
        {
            get { return maxValue; }
            private set { maxValue = value; }
        }


        /// <summary>
        /// The minimum value
        /// </summary>
        private double minValue = 0.0;
        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        [Browsable(false)]
        public double MinValue
        {
            get { return minValue; }
            private set { minValue = value; }
        }


        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <value>The range.</value>
        [Browsable(false)]
        public double Range
        {
            get
            {
                double num = MaxValue - MinValue;
                if (num <= 0.0)
                {
                    return 1.0;
                }
                return num;
            }
        }

        /// <summary>
        /// The zoom state
        /// </summary>
        ZoomType zoomState = ZoomType.None;
        /// <summary>
        /// Gets the state of the zoom.
        /// </summary>
        /// <value>The state of the zoom.</value>
        [Browsable(false)]
        public ZoomType ZoomState
        {
            get { return zoomState; }
            private set { zoomState = value; }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Axis"/> class.
        /// </summary>
        public Axis()
        {
            _labels = new List<AxisLabel>();
            _brush = new SolidBrush(_color);
            maxLabelWidth = 0f;
            maxLabelHeight = 0f;
        }

        /// <summary>
        /// Resets the range.
        /// </summary>
        internal void ResetRange()
        {
            MinValue = (minValBuf = _minValueLimit);
            MaxValue = (maxValBuf = _maxValueLimit);
        }

        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="series">The series.</param>
        /// <param name="axisType">Type of the axis.</param>
        /// <param name="separatorSum">The separator sum.</param>
        internal void UpdateRange(SeriesBase series, AxisType axisType, int separatorSum)
        {
            if (_autoAdapt && !_isCustomLabels)
            {
                double? num = (axisType == AxisType.X) ? series.MinValueX : series.MinValueY;
                double? num2 = (axisType == AxisType.X) ? series.MaxValueX : series.MaxValueY;
                bool flag = false;
                if (num.HasValue && minValBuf > num.Value)
                {
                    minValBuf = num.Value;
                    flag = true;
                }
                if (num2.HasValue && maxValBuf < num2.Value)
                {
                    maxValBuf = num2.Value;
                    flag = true;
                }
                if (flag)
                {
                    UpdateRange(minValBuf, maxValBuf, separatorSum);
                }
            }
        }

        /// <summary>
        /// Updates the zoom.
        /// </summary>
        /// <param name="times">The times.</param>
        internal void UpdateZoom(double times)
        {
            if (_zoomEnabled)
            {
                if (times > 0.0)
                {
                    ZoomState = ZoomType.Enlarge;
                }
                else if (times < 0.0)
                {
                    ZoomState = ZoomType.Reduce;
                }
                else
                {
                    ZoomState = ZoomType.None;
                }
                if (times != 0.0)
                {
                    double range = Range;
                    MinValue += range * times;
                    MaxValue -= range * times;
                }
            }
        }

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="separatorSum">The separator sum.</param>
        internal void UpdateLabel(int separatorSum)
        {
            if (!_isCustomLabels)
            {
                _labels.Clear();
                dataStep = Range / (double)separatorSum;
                for (int i = 0; i <= separatorSum; i++)
                {
                    double value = dataStep * (double)i + MinValue;
                    _labels.Add(new AxisLabel(value));
                }
            }
        }

        /// <summary>
        /// Updates the size1.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="font">The font.</param>
        internal void UpdateSize1(Graphics g, Font font)
        {
            if (_type == AxisType.X)
            {
                Height = CountAxisXHeight(g, font);
            }
            else if (_type == AxisType.Y)
            {
                Width = CountAxisYWidth(g, font);
            }
        }

        /// <summary>
        /// Updates the size2.
        /// </summary>
        /// <param name="border">The border.</param>
        /// <param name="separatorSum">The separator sum.</param>
        internal void UpdateSize2(Rectangle border, int separatorSum)
        {
            if (_type == AxisType.X)
            {
                Width = border.Width;
                locationStep = Width / (float)separatorSum;
            }
            else if (_type == AxisType.Y)
            {
                Height = border.Height;
                locationStep = Height / (float)separatorSum;
            }
        }

        /// <summary>
        /// Updates the offset.
        /// </summary>
        /// <param name="separatorSum">The separator sum.</param>
        /// <param name="offset">The offset.</param>
        internal void UpdateOffset(int separatorSum, int offset)
        {
            if (_isCustomLabels)
            {
                return;
            }
            int num = (int)((float)offset / locationStep);
            double num2 = (double)num * dataStep;
            if (num2 != 0.0)
            {
                _labels.Clear();
                for (int i = 0; i <= separatorSum; i++)
                {
                    double num3 = dataStep * (double)i + MinValue;
                    num3 = (_isReverse ? (num3 + num2) : (num3 - num2));
                    _labels.Add(new AxisLabel(num3));
                }
            }
        }

        /// <summary>
        /// Draws the axis x.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="font">The font.</param>
        /// <param name="border">The border.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="top">The top.</param>
        /// <param name="bottom">The bottom.</param>
        internal void DrawAxisX(Graphics g, Font font, Rectangle border, int offset, ref float top, ref float bottom)
        {
            if (!_visible)
            {
                return;
            }
            float x = (float)border.Left + (float)border.Width / 2f;
            float num = _isCustomLabels ? ((float)(border.Left + offset)) : ((float)border.Left + (float)offset % locationStep);
            StringFormat format;
            StringFormat format2;
            float y;
            float y2;
            if (_position == AxisPosition.RightTop)
            {
                format = AxisFormat.TitleFormatTopAxisX;
                format2 = AxisFormat.LabelFormatTopAxisX;
                y = top;
                y2 = top + Height - 3f;
                top += Height;
            }
            else
            {
                format = AxisFormat.TitleFormatBottomAxisX;
                format2 = AxisFormat.LabelFormatBottomAxisX;
                y = (float)border.Bottom + bottom + Height;
                y2 = (float)border.Bottom + bottom + 3f;
                bottom += Height;
            }
            if (_labelVisible)
            {
                int count = _labels.Count;
                if (count > 0)
                {
                    RectangleF rectangleF = default(RectangleF);
                    for (int i = 0; i < count; i++)
                    {
                        float num3;
                        if (_isCustomLabels)
                        {
                            double num2 = _isReverse ? _labels[count - i - 1].Value : _labels[i].Value;
                            num3 = Convert.ToSingle((double)Width / Range * (num2 - MinValue));
                            if (_isReverse)
                            {
                                num3 = Width - num3;
                            }
                        }
                        else
                        {
                            num3 = (float)i * locationStep;
                        }
                        num3 += num;
                        if (num3 >= (float)border.Left && num3 <= (float)border.Right)
                        {
                            PointF pointF = new PointF(num3, y2);
                            if (!rectangleF.Contains(pointF))
                            {
                                string s = _isReverse ? _labels[count - i - 1].Content : _labels[i].Content;
                                g.DrawString(s, font, _brush, pointF, format2);
                                rectangleF = new RectangleF(num3, y2, maxLabelWidth + 21f, maxLabelHeight);
                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(_title))
            {
                g.DrawString(_title, font, _brush, x, y, format);
            }
        }

        /// <summary>
        /// Draws the axis y.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="font">The font.</param>
        /// <param name="border">The border.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        internal void DrawAxisY(Graphics g, Font font, Rectangle border, int offset, ref float left, ref float right)
        {
            if (!_visible)
            {
                return;
            }
            float y = border.Top + border.Height / 2;
            float num = _isCustomLabels ? ((float)(border.Top + offset)) : ((float)border.Top + (float)offset % locationStep);
            StringFormat format;
            StringFormat format2;
            float x;
            float x2;
            if (_position == AxisPosition.RightTop)
            {
                format = AxisFormat.TitleFormatRightAxisY;
                format2 = AxisFormat.LabelFormatRightAxisY;
                x = (float)border.Right + right + Width;
                x2 = (float)border.Right + right + 3f;
                right += Width;
            }
            else
            {
                format = AxisFormat.TitleFormatLeftAxisY;
                format2 = AxisFormat.LabelFormatLeftAxisY;
                x = left;
                x2 = left + Width - 3f;
                left += Width;
            }
            if (_labelVisible)
            {
                int count = _labels.Count;
                if (count > 0)
                {
                    RectangleF rectangleF = default(RectangleF);
                    for (int i = 0; i < count; i++)
                    {
                        float num3;
                        if (_isCustomLabels)
                        {
                            double num2 = _isReverse ? _labels[i].Value : _labels[count - i - 1].Value;
                            num3 = Convert.ToSingle((double)Height / Range * (num2 - MinValue));
                            if (!_isReverse)
                            {
                                num3 = Height - num3;
                            }
                        }
                        else
                        {
                            num3 = (float)i * locationStep;
                        }
                        num3 += num;
                        if (num3 >= (float)border.Top && num3 <= (float)border.Bottom)
                        {
                            PointF pointF = new PointF(x2, num3);
                            if (!rectangleF.Contains(pointF))
                            {
                                string s = _isReverse ? _labels[i].Content : _labels[count - i - 1].Content;
                                g.DrawString(s, font, _brush, pointF, format2);
                                rectangleF = new RectangleF(x2, num3, maxLabelWidth, maxLabelHeight + 6f);
                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(_title))
            {
                ChartsHelper.DrawString(g, _title, font, _brush, new PointF(x, y), format, -90f);
            }
        }

        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="separatorSum">The separator sum.</param>
        private void UpdateRange(double min, double max, int separatorSum)
        {
            double num = max - min;
            double d = num / (double)separatorSum;
            double num2 = Math.Pow(10.0, Math.Floor(Math.Log(d) / Math.Log(10.0)));
            double num3 = num / (double)separatorSum;
            double num4 = num3 / num2;
            double num5 = (num4 > 5.0) ? (10.0 * num2) : ((num4 > 2.0) ? (5.0 * num2) : ((!(num4 > 1.0)) ? num2 : (2.0 * num2)));
            MinValue = Math.Floor(min / num5) * num5;
            MaxValue = Math.Ceiling(max / num5) * num5;
        }

        /// <summary>
        /// Counts the width of the axis y.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="font">The font.</param>
        /// <returns>System.Single.</returns>
        private float CountAxisYWidth(Graphics g, Font font)
        {
            if (!_visible)
            {
                return 0f;
            }
            float num = 0f;
            if (!string.IsNullOrEmpty(_title))
            {
                SizeF size = g.MeasureString(_title, font);
                num = ChartsHelper.ConvertSize(size, -90f).Width + 3f;
            }
            if (!_labelVisible || _labels.Count < 1)
            {
                return num;
            }
            maxLabelHeight = 0f;
            maxLabelWidth = 0f;
            for (int i = 0; i < _labels.Count; i++)
            {
                SizeF sizeF = g.MeasureString(_labels[i].Content, font);
                maxLabelHeight = ((sizeF.Height > maxLabelHeight) ? sizeF.Height : maxLabelHeight);
                maxLabelWidth = ((sizeF.Width > maxLabelWidth) ? sizeF.Width : maxLabelWidth);
            }
            return num + maxLabelWidth + 3f;
        }

        /// <summary>
        /// Counts the height of the axis x.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="font">The font.</param>
        /// <returns>System.Single.</returns>
        private float CountAxisXHeight(Graphics g, Font font)
        {
            if (!_visible)
            {
                return 0f;
            }
            float num = string.IsNullOrEmpty(_title) ? 0f : (g.MeasureString(_title, font).Height + 3f);
            if (!_labelVisible || _labels.Count < 1)
            {
                return num;
            }
            maxLabelHeight = 0f;
            maxLabelWidth = 0f;
            for (int i = 0; i < _labels.Count; i++)
            {
                SizeF sizeF = g.MeasureString(_labels[i].Content, font);
                maxLabelHeight = ((sizeF.Height > maxLabelHeight) ? sizeF.Height : maxLabelHeight);
                maxLabelWidth = ((sizeF.Width > maxLabelWidth) ? sizeF.Width : maxLabelWidth);
            }
            return num + maxLabelHeight + 3f;
        }

        /// <summary>
        /// Sets the labels.
        /// </summary>
        /// <param name="labels">The labels.</param>
        /// <param name="startValue">The start value.</param>
        /// <param name="valueStep">The value step.</param>
        public void SetLabels(string[] labels, double startValue = 0.0, double valueStep = 0.1)
        {
            if (labels != null)
            {
                _isCustomLabels = true;
                _labels.Clear();
                for (int i = 0; i < labels.Length; i++)
                {
                    _labels.Add(new AxisLabel(startValue + (double)i * valueStep)
                    {
                        Content = labels[i]
                    });
                }
            }
            if (_chart != null)
                _chart.Invalidate();
        }

        /// <summary>
        /// Sets the labels.
        /// </summary>
        /// <param name="labels">The labels.</param>
        /// <param name="values">The values.</param>
        public void SetLabels(string[] labels, double[] values)
        {
            if (labels != null && values != null)
            {
                _isCustomLabels = true;
                _labels.Clear();
                for (int i = 0; i < labels.Length; i++)
                {
                    _labels.Add(new AxisLabel(values[i])
                    {
                        Content = labels[i]
                    });
                }
            }
            if (_chart != null)
                _chart.Invalidate();
        }

        /// <summary>
        /// Sets the labels.
        /// </summary>
        /// <param name="dateTimes">The date times.</param>
        /// <param name="format">The format.</param>
        /// <param name="startValue">The start value.</param>
        /// <param name="valueStep">The value step.</param>
        public void SetLabels(DateTime[] dateTimes, string format = "yyyy-MM-dd HH:mm:ss", double startValue = 0.0, double valueStep = 0.1)
        {
            if (dateTimes != null)
            {
                _isCustomLabels = true;
                _labels.Clear();
                for (int i = 0; i < dateTimes.Length; i++)
                {
                    _labels.Add(new AxisLabel(startValue + (double)i * valueStep)
                    {
                        Content = dateTimes[i].ToString(format)
                    });
                }
            }
            if (_chart != null)
                _chart.Invalidate();
        }

        /// <summary>
        /// Sets the labels.
        /// </summary>
        /// <param name="dateTimes">The date times.</param>
        /// <param name="values">The values.</param>
        /// <param name="format">The format.</param>
        public void SetLabels(DateTime[] dateTimes, double[] values, string format = "yyyy-MM-dd HH:mm:ss")
        {
            if (dateTimes != null && values != null)
            {
                _isCustomLabels = true;
                _labels.Clear();
                for (int i = 0; i < dateTimes.Length; i++)
                {
                    _labels.Add(new AxisLabel(values[i])
                    {
                        Content = dateTimes[i].ToString(format)
                    });
                }
            }
            if (_chart != null)
                _chart.Invalidate();
        }

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public string GetLabel(double value)
        {
            if (_isCustomLabels)
            {
                IEnumerable<AxisLabel> enumerable = from lab in _labels
                                                    where lab.Value == value
                                                    select lab;
                if (enumerable != null && enumerable.Count() > 0)
                {
                    return enumerable.Last().Content;
                }
                return string.Empty;
            }
            return value.ToString();
        }
    }
}
