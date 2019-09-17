// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="UCChart.cs">
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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCChart.
    /// Implements the <see cref="System.Windows.Forms.Control" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class UCChart : Control
    {
        /// <summary>
        /// The axis margin
        /// </summary>
        public const int AxisMargin = 3;

        /// <summary>
        /// The mini grid sum
        /// </summary>
        public const int MiniGridSum = 5;

        /// <summary>
        /// The is draging
        /// </summary>
        private bool isDraging = false;

        /// <summary>
        /// The mark line location
        /// </summary>
        private Point markLineLocation;

        /// <summary>
        /// The drag location
        /// </summary>
        private Point dragLocation;

        /// <summary>
        /// The zoom times
        /// </summary>
        private double zoomTimes = 0.0;

        /// <summary>
        /// The update flag
        /// </summary>
        private bool updateFlag = true;

        /// <summary>
        /// The mark line pen
        /// </summary>
        private Pen _markLinePen;

        /// <summary>
        /// The need draw mark line
        /// </summary>
        private bool needDrawMarkLine;

        /// <summary>
        /// The horizontal separator sum
        /// </summary>
        private int _horizontalSeparatorSum = 10;

        /// <summary>
        /// The vertical separator sum
        /// </summary>
        private int _verticalSeparatorSum = 10;

        /// <summary>
        /// The axis x
        /// </summary>
        private AxisCollection _axisX = new AxisCollection();

        /// <summary>
        /// The axis y
        /// </summary>
        private AxisCollection _axisY = new AxisCollection();

        /// <summary>
        /// The series
        /// </summary>
        private SeriesCollection _series = new SeriesCollection();

        /// <summary>
        /// The border
        /// </summary>
        private Rectangle _border;

        /// <summary>
        /// The offset x
        /// </summary>
        private int _offsetX;

        /// <summary>
        /// The offset y
        /// </summary>
        private int _offsetY;

        /// <summary>
        /// The horizontal grid visible
        /// </summary>
        private bool _horizontalGridVisible = true;

        /// <summary>
        /// The vertical grid visible
        /// </summary>
        private bool _verticalGridVisible = true;

        /// <summary>
        /// The mini grid visible
        /// </summary>
        private bool _miniGridVisible = false;

        /// <summary>
        /// The mini grid dash style
        /// </summary>
        private DashStyle _miniGridDashStyle = DashStyle.Dot;

        /// <summary>
        /// The legend visible
        /// </summary>
        private bool _legendVisible = true;

        /// <summary>
        /// The zoom enabled
        /// </summary>
        private bool _zoomEnabled = true;

        /// <summary>
        /// The allow drag
        /// </summary>
        private bool _allowDrag = true;

        /// <summary>
        /// The mark line visible
        /// </summary>
        private bool _markLineVisible = false;

        /// <summary>
        /// The mark line color
        /// </summary>
        private Color _markLineColor = Color.FromArgb(80, 126, 211);

        /// <summary>
        /// The select point enabled
        /// </summary>
        private bool _selectPointEnabled = true;

        /// <summary>
        /// Gets or sets the colors.
        /// </summary>
        /// <value>The colors.</value>
        public static List<Color> Colors
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index of the color.
        /// </summary>
        /// <value>The index of the color.</value>
        public static int ColorIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the main tool tip.
        /// </summary>
        /// <value>The main tool tip.</value>
        internal ToolTip MainToolTip
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the legend panel.
        /// </summary>
        /// <value>The legend panel.</value>
        internal FlowLayoutPanel LegendPanel
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the horizontal separator sum.
        /// </summary>
        /// <value>The horizontal separator sum.</value>
        [Category("自定义")]
        [Description("横向分隔器个数。")]
        [DefaultValue(10)]
        public int HorizontalSeparatorSum
        {
            get
            {
                return _horizontalSeparatorSum;
            }
            set
            {
                _horizontalSeparatorSum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the vertical separator sum.
        /// </summary>
        /// <value>The vertical separator sum.</value>
        [Category("自定义")]
        [Description("垂直分隔器个数。")]
        [DefaultValue(10)]
        public int VerticalSeparatorSum
        {
            get
            {
                return _verticalSeparatorSum;
            }
            set
            {
                _verticalSeparatorSum = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the axis x.
        /// </summary>
        /// <value>The axis x.</value>
        [Category("自定义")]
        [Description("X轴集合。")]
        [TypeConverter(typeof(CollectionConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public AxisCollection AxisX { get { return _axisX; } set { _axisX = value; } }

        /// <summary>
        /// Gets or sets the axis y.
        /// </summary>
        /// <value>The axis y.</value>
        [Category("自定义")]
        [Description("Y轴集合。")]
        [TypeConverter(typeof(CollectionConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public AxisCollection AxisY { get { return _axisY; } set { _axisY = value; } }

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        /// <value>The series.</value>
        [Category("自定义")]
        [Description("数据串集合。")]
        [TypeConverter(typeof(CollectionConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SeriesCollection Series { get { return _series; } set { _series = value; } }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        [Browsable(false)]
        public Rectangle Border { get { return _border; } set { _border = value; } }

        /// <summary>
        /// Gets or sets the offset x.
        /// </summary>
        /// <value>The offset x.</value>
        [Browsable(false)]
        public int OffsetX
        {
            get
            {
                return _offsetX;
            }
            set
            {
                _offsetX = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the offset y.
        /// </summary>
        /// <value>The offset y.</value>
        [Browsable(false)]
        public int OffsetY
        {
            get
            {
                return _offsetY;
            }
            set
            {
                _offsetY = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [horizontal grid visible].
        /// </summary>
        /// <value><c>true</c> if [horizontal grid visible]; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("显示/隐藏横向网格线。")]
        [DefaultValue(true)]
        public bool HorizontalGridVisible
        {
            get
            {
                return _horizontalGridVisible;
            }
            set
            {
                _horizontalGridVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [vertical grid visible].
        /// </summary>
        /// <value><c>true</c> if [vertical grid visible]; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("显示/隐藏垂直网格线。")]
        [DefaultValue(true)]
        public bool VerticalGridVisible
        {
            get
            {
                return _verticalGridVisible;
            }
            set
            {
                _verticalGridVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [mini grid visible].
        /// </summary>
        /// <value><c>true</c> if [mini grid visible]; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("显示/隐藏小网格线。")]
        [DefaultValue(false)]
        public bool MiniGridVisible
        {
            get
            {
                return _miniGridVisible;
            }
            set
            {
                _miniGridVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the mini grid dash style.
        /// </summary>
        /// <value>The mini grid dash style.</value>
        [Category("自定义")]
        [Description("小网格线的样式。")]
        [DefaultValue(DashStyle.Dot)]
        public DashStyle MiniGridDashStyle
        {
            get
            {
                return _miniGridDashStyle;
            }
            set
            {
                _miniGridDashStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [legend visible].
        /// </summary>
        /// <value><c>true</c> if [legend visible]; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("显示/隐藏图例。")]
        [DefaultValue(true)]
        public bool LegendVisible
        {
            get
            {
                return _legendVisible;
            }
            set
            {
                _legendVisible = value;
                LegendPanel.Visible = _legendVisible;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the legend dock.
        /// </summary>
        /// <value>The legend dock.</value>
        [Category("自定义")]
        [Description("图例停靠位置。")]
        [DefaultValue(DockStyle.Top)]
        public DockStyle LegendDock
        {
            get
            {
                return LegendPanel.Dock;
            }
            set
            {
                if (value != 0 && value != DockStyle.Fill)
                {
                    if (value == DockStyle.Top || value == DockStyle.Bottom)
                    {
                        LegendPanel.FlowDirection = FlowDirection.LeftToRight;
                    }
                    else if (value == DockStyle.Left || value == DockStyle.Right)
                    {
                        LegendPanel.FlowDirection = FlowDirection.TopDown;
                    }
                    LegendPanel.Dock = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the legend font.
        /// </summary>
        /// <value>The legend font.</value>
        [Category("自定义")]
        [Description("图例字体。")]
        public Font LegendFont
        {
            get
            {
                return LegendPanel.Font;
            }
            set
            {
                LegendPanel.Font = value;
                Invalidate();
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
        /// Gets or sets a value indicating whether [allow drag].
        /// </summary>
        /// <value><c>true</c> if [allow drag]; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("是否允许鼠标拖动")]
        [DefaultValue(true)]
        public bool AllowDrag
        {
            get
            {
                return _allowDrag;
            }
            set
            {
                _allowDrag = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [mark line visible].
        /// </summary>
        /// <value><c>true</c> if [mark line visible]; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("显示/隐藏标记线。")]
        [DefaultValue(false)]
        public bool MarkLineVisible
        {
            get
            {
                return _markLineVisible;
            }
            set
            {
                _markLineVisible = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the mark line.
        /// </summary>
        /// <value>The color of the mark line.</value>
        [Category("自定义")]
        [Description("标记线颜色。")]
        [DefaultValue(typeof(Color), "80, 126, 211")]
        public Color MarkLineColor
        {
            get
            {
                return _markLineColor;
            }
            set
            {
                _markLineColor = value;
                _markLinePen = new Pen(_markLineColor);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [select point enabled].
        /// </summary>
        /// <value><c>true</c> if [select point enabled]; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("查找数据点使能。")]
        [DefaultValue(true)]
        public bool SelectPointEnabled
        {
            get
            {
                return _selectPointEnabled;
            }
            set
            {
                _selectPointEnabled = value;
            }
        }
        /// <summary>
        /// The select mode
        /// </summary>
        SelectMode selectMode = SelectMode.Both;

        /// <summary>
        /// Gets or sets the select mode.
        /// </summary>
        /// <value>The select mode.</value>
        [Category("自定义")]
        [Description("查找数据点的模式。")]
        [DefaultValue(SelectMode.Both)]
        public SelectMode SelectMode
        {
            get { return selectMode; }
            set { selectMode = value; }
        }


        /// <summary>
        /// Gets or sets the axis x index for select.
        /// </summary>
        /// <value>The axis x index for select.</value>
        [Browsable(false)]
        public int AxisXIndexForSelect
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the axis y index for select.
        /// </summary>
        /// <value>The axis y index for select.</value>
        [Browsable(false)]
        public int AxisYIndexForSelect
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置在控件中显示的背景图像。
        /// </summary>
        /// <value>The background image.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [Bindable(false)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        /// <summary>
        /// 获取或设置在 <see cref="T:System.Windows.Forms.ImageLayout" /> 枚举中定义的背景图像布局。
        /// </summary>
        /// <value>The background image layout.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [Bindable(false)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否将控件的元素对齐以支持使用从右向左的字体的区域设置。
        /// </summary>
        /// <value>The right to left.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [Bindable(false)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        /// <summary>
        /// Occurs when [got chart point].
        /// </summary>
        public event ChartPointEventHandler GotChartPoint;

        /// <summary>
        /// Initializes static members of the <see cref="UCChart"/> class.
        /// </summary>
        static UCChart()
        {
            Colors = new List<Color>
			{
				Color.FromArgb(41, 127, 184),
				Color.FromArgb(230, 76, 60),
				Color.FromArgb(240, 195, 15),
				Color.FromArgb(26, 187, 155),
				Color.FromArgb(87, 213, 140),
				Color.FromArgb(154, 89, 181),
				Color.FromArgb(92, 109, 126),
				Color.FromArgb(22, 159, 132),
				Color.FromArgb(39, 173, 96),
				Color.FromArgb(92, 171, 225),
				Color.FromArgb(141, 68, 172),
				Color.FromArgb(229, 126, 34),
				Color.FromArgb(210, 84, 0),
				Color.FromArgb(191, 57, 43)
			};
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCChart"/> class.
        /// </summary>
        public UCChart()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.White;
            Font = new Font("微软雅黑", 12f);
            ForeColor = Color.FromArgb(51, 51, 51);
            base.Padding = new Padding(6);
            base.Size = new Size(400, 300);
            base.TabStop = false;
            _axisX.Chart = this;
            _axisX.Type = AxisType.X;
            _axisY.Chart = this;
            _axisY.Type = AxisType.Y;
            _series.Chart = this;
            _markLinePen = new Pen(_markLineColor);
            MainToolTip = new ToolTip();
            LegendPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Top
            };
            base.Controls.Add(LegendPanel);
            base.PaddingChanged += delegate
            {
                Invalidate();
            };
        }

        /// <summary>
        /// Handles the <see cref="E:GotChartPoint" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ChartPointEventArgs"/> instance containing the event data.</param>
        private void OnGotChartPoint(ChartPointEventArgs e)
        {
            if (this.GotChartPoint != null)
            {
                this.GotChartPoint.Invoke(this, e);
            }
        }

        /// <summary>
        /// 引发 <see cref="M:System.Windows.Forms.Control.CreateControl" /> 方法。
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            InitializeChart();
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (updateFlag)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Graphics graphics = e.Graphics;
                graphics.Clear(BackColor);
                UpdateAxisRange();
                UpdateChartBorder(graphics, base.Size);
                UpdateAxisSize();
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                DrawFrame(graphics);
                DrawAxis(graphics);
                graphics.Clip = new Region(_border);
                DrawSeries(graphics);
                DrawMarkLine(graphics);
                stopwatch.Stop();
                Debug.WriteLine("It took {stopwatch.ElapsedMilliseconds} milliseconds to redraw.");
            }
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.SizeChanged" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.EventArgs" />。</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.MouseDown" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.MouseEventArgs" />。</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (_allowDrag && e.Button == MouseButtons.Left)
            {
                dragLocation = e.Location;
                isDraging = true;
                Cursor = Cursors.Hand;
            }
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.MouseMove" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.MouseEventArgs" />。</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            bool flag = false;
            if (_allowDrag && isDraging)
            {
                int num = e.X - dragLocation.X;
                int num2 = e.Y - dragLocation.Y;
                dragLocation = e.Location;
                if (num != 0 || num2 != 0)
                {
                    _offsetX += num;
                    _offsetY += num2;
                    flag = true;
                }
            }
            if (_markLineVisible)
            {
                if (_border.Contains(e.Location))
                {
                    if (markLineLocation != e.Location)
                    {
                        markLineLocation = e.Location;
                        needDrawMarkLine = true;
                        flag = true;
                    }
                }
                else if (needDrawMarkLine)
                {
                    needDrawMarkLine = false;
                    flag = true;
                }
            }
            if (flag)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.MouseUp" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.MouseEventArgs" />。</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (_selectPointEnabled && _border.Contains(e.Location) && e.Button == MouseButtons.Left)
            {
                SelectPoints(e.Location);
            }
            if (_allowDrag && e.Button == MouseButtons.Left)
            {
                isDraging = false;
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.MouseWheel" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.MouseEventArgs" />。</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (_zoomEnabled && _border.Contains(e.Location))
            {
                if (e.Delta > 0 && zoomTimes > -1.95)
                {
                    zoomTimes -= 0.05;
                }
                else if (e.Delta < 0 && zoomTimes < 0.45)
                {
                    zoomTimes += 0.05;
                }
                zoomTimes = Math.Round(zoomTimes, 2);
                Invalidate();
            }
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.MouseLeave" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.EventArgs" />。</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MainToolTip.SetToolTip(this, null);
            if (needDrawMarkLine)
            {
                needDrawMarkLine = false;
                Invalidate();
            }
        }

        /// <summary>
        /// Initializes the chart.
        /// </summary>
        private void InitializeChart()
        {
            foreach (SeriesBase item in _series)
            {
                item.Chart = this;
                item.Points.Chart = this;
                item.Points.Series = item;
                foreach (ChartPoint point in item.Points)
                {
                    point.Chart = this;
                    point.Series = item;
                }
            }
            foreach (Axis item2 in _axisX)
            {
                item2.Chart = this;
                item2.Type = AxisType.X;
            }
            foreach (Axis item3 in _axisY)
            {
                item3.Chart = this;
                item3.Type = AxisType.Y;
            }
        }

        /// <summary>
        /// Updates the axis range.
        /// </summary>
        private void UpdateAxisRange()
        {
            foreach (Axis item in _axisX)
            {
                item.ResetRange();
            }
            foreach (Axis item2 in _axisY)
            {
                item2.ResetRange();
            }
            foreach (SeriesBase item3 in _series)
            {
                if (item3.ScalesXAt >= 0 && item3.ScalesXAt < _axisX.Count)
                {
                    Axis axis = _axisX[item3.ScalesXAt];
                    axis.UpdateRange(item3, AxisType.X, _verticalSeparatorSum);
                }
                if (item3.ScalesYAt >= 0 && item3.ScalesYAt < _axisY.Count)
                {
                    Axis axis2 = _axisY[item3.ScalesYAt];
                    axis2.UpdateRange(item3, AxisType.Y, _horizontalSeparatorSum);
                }
            }
            foreach (Axis item4 in _axisX)
            {
                item4.UpdateZoom(zoomTimes);
            }
            foreach (Axis item5 in _axisY)
            {
                item5.UpdateZoom(zoomTimes);
            }
        }

        /// <summary>
        /// Updates the chart border.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="size">The size.</param>
        private void UpdateChartBorder(Graphics g, Size size)
        {
            float num = 0f;
            float num2 = 0f;
            float num3 = 0f;
            float num4 = 0f;
            foreach (Axis item in _axisX)
            {
                item.UpdateLabel(_verticalSeparatorSum);
                item.UpdateSize1(g, Font);
                if (item.Position == AxisPosition.LeftBottom)
                {
                    num2 += item.Height;
                }
                else
                {
                    num += item.Height;
                }
            }
            foreach (Axis item2 in _axisY)
            {
                item2.UpdateLabel(_horizontalSeparatorSum);
                item2.UpdateSize1(g, Font);
                if (item2.Position == AxisPosition.LeftBottom)
                {
                    num3 += item2.Width;
                }
                else
                {
                    num4 += item2.Width;
                }
            }
            num += (float)base.Padding.Top;
            num2 += (float)base.Padding.Bottom;
            num3 += (float)base.Padding.Left;
            num4 += (float)base.Padding.Right;
            int num5 = (int)num3;
            int num6 = (int)num;
            int num7 = (int)((float)size.Width - num3 - num4);
            int num8 = (int)((float)size.Height - num - num2);
            if (LegendPanel.Visible)
            {
                switch (LegendPanel.Dock)
                {
                    case DockStyle.Top:
                        LegendPanel.Padding = new Padding(num5 + 3, base.Padding.Top, (int)num4 + 3, 0);
                        num6 += LegendPanel.Height + 3;
                        num8 -= LegendPanel.Height + 3;
                        break;
                    case DockStyle.Bottom:
                        LegendPanel.Padding = new Padding(num5 + 3, 0, (int)num4 + 3, base.Padding.Bottom);
                        num8 -= LegendPanel.Height + 3;
                        break;
                    case DockStyle.Left:
                        LegendPanel.Padding = new Padding(base.Padding.Left, num6 + 3, 0, (int)num2 + 3);
                        num5 += LegendPanel.Width + 3;
                        num7 -= LegendPanel.Width + 3;
                        break;
                    case DockStyle.Right:
                        LegendPanel.Padding = new Padding(0, num6 + 3, base.Padding.Right, (int)num2 + 3);
                        num7 -= LegendPanel.Width + 3;
                        break;
                }
            }
            _border = new Rectangle(num5, num6, num7, num8);
        }

        /// <summary>
        /// Updates the size of the axis.
        /// </summary>
        private void UpdateAxisSize()
        {
            foreach (Axis item in _axisX)
            {
                item.UpdateSize2(_border, _verticalSeparatorSum);
                item.UpdateOffset(_verticalSeparatorSum, _offsetX);
            }
            foreach (Axis item2 in _axisY)
            {
                item2.UpdateSize2(_border, _horizontalSeparatorSum);
                item2.UpdateOffset(_horizontalSeparatorSum, -_offsetY);
            }
        }

        /// <summary>
        /// Draws the frame.
        /// </summary>
        /// <param name="g">The g.</param>
        internal void DrawFrame(Graphics g)
        {
            Pen pen = new Pen(Color.FromArgb(111, ForeColor));
            Pen pen2 = new Pen(Color.FromArgb(58, ForeColor));
            Pen pen3 = new Pen(Color.FromArgb(53, ForeColor))
            {
                DashStyle = _miniGridDashStyle
            };
            g.DrawRectangle(pen, _border);
            pen.Dispose();
            if (_horizontalGridVisible)
            {
                int left = _border.Left;
                int right = _border.Right;
                float num = _border.Height;
                float num2 = num / (float)_horizontalSeparatorSum;
                float num3 = (float)_offsetY % num2;
                float num4 = (float)_border.Top + num3;
                for (int i = 0; i < _horizontalSeparatorSum + 1; i++)
                {
                    if (_border.Contains(_border.Left, (int)num4))
                    {
                        g.DrawLine(pen2, left, num4, right, num4);
                    }
                    num4 += num2;
                }
                if (_miniGridVisible)
                {
                    float num5 = num2 / 5f;
                    num3 = (float)_offsetY % num5;
                    num4 = (float)_border.Top + num3;
                    for (int j = 0; j < _horizontalSeparatorSum * 5 + 1; j++)
                    {
                        if (_border.Contains(_border.Left, (int)num4))
                        {
                            g.DrawLine(pen3, left, num4, right, num4);
                        }
                        num4 += num5;
                    }
                }
            }
            if (_verticalGridVisible)
            {
                int top = _border.Top;
                int bottom = _border.Bottom;
                float num6 = _border.Width;
                float num7 = num6 / (float)_verticalSeparatorSum;
                float num8 = (float)_offsetX % num7;
                float num9 = (float)_border.Left + num8;
                for (int k = 0; k < _verticalSeparatorSum + 1; k++)
                {
                    if (_border.Contains((int)num9, _border.Top))
                    {
                        g.DrawLine(pen2, num9, top, num9, bottom);
                    }
                    num9 += num7;
                }
                if (_miniGridVisible)
                {
                    float num10 = num7 / 5f;
                    num8 = (float)_offsetX % num10;
                    num9 = (float)_border.Left + num8;
                    for (int l = 0; l < _verticalSeparatorSum * 5 + 1; l++)
                    {
                        if (_border.Contains((int)num9, _border.Top))
                        {
                            g.DrawLine(pen3, num9, top, num9, bottom);
                        }
                        num9 += num10;
                    }
                }
            }
            pen2.Dispose();
            pen3.Dispose();
        }

        /// <summary>
        /// Draws the axis.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawAxis(Graphics g)
        {
            DrawAxisX(g);
            DrawAxisY(g);
        }

        /// <summary>
        /// Draws the axis x.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawAxisX(Graphics g)
        {
            float top = base.Padding.Top;
            float bottom = 0f;
            if (LegendPanel.Visible)
            {
                switch (LegendPanel.Dock)
                {
                    case DockStyle.Top:
                        top += (float)LegendPanel.Height + 3f;
                        break;
                }
            }
            foreach (Axis item in _axisX)
            {
                item.DrawAxisX(g, Font, _border, _offsetX, ref top, ref bottom);
            }
        }

        /// <summary>
        /// Draws the axis y.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawAxisY(Graphics g)
        {
            float left = base.Padding.Left;
            float right = 0f;
            if (LegendPanel.Visible)
            {
                switch (LegendPanel.Dock)
                {
                    case DockStyle.Left:
                        left += (float)LegendPanel.Width + 3f;
                        break;
                }
            }
            foreach (Axis item in _axisY)
            {
                item.DrawAxisY(g, Font, _border, _offsetY, ref left, ref right);
            }
        }

        /// <summary>
        /// Draws the series.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawSeries(Graphics g)
        {
            foreach (SeriesBase item in _series)
            {
                if (item.Visible)
                {
                    item.Draw(g);
                }
            }
            List<ColumnSeries> list = new List<ColumnSeries>();
            foreach (SeriesBase item2 in _series)
            {
                ColumnSeries columnSeries = item2 as ColumnSeries;
                if (columnSeries != null)
                {
                    list.Add(columnSeries);
                }
            }
            if (list != null && list.Count() > 0)
            {
                ColumnSeries.Draw(g, _border, _verticalSeparatorSum, list.ToArray());
            }
        }

        /// <summary>
        /// Draws the mark line.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawMarkLine(Graphics g)
        {
            if (needDrawMarkLine && !isDraging)
            {
                g.DrawLine(_markLinePen, markLineLocation.X, _border.Top, markLineLocation.X, _border.Bottom);
            }
        }

        /// <summary>
        /// Selects the points.
        /// </summary>
        /// <param name="location">The location.</param>
        private void SelectPoints(Point location)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ChartPoint[] array = null;
            string content = null;
            switch (SelectMode)
            {
                case SelectMode.Both:
                    array = SelectPointsByLocation(location, 4);
                    if (array != null)
                    {
                        content = GetPointsContent1(array);
                    }
                    break;
                case SelectMode.X:
                    array = SelectPointsByX(AxisXIndexForSelect, location.X, 4);
                    if (array != null)
                    {
                        content = GetPointsContent2(array);
                    }
                    break;
                case SelectMode.Y:
                    array = SelectPointsByY(AxisYIndexForSelect, location.Y, 4);
                    if (array != null)
                    {
                        content = GetPointsContent3(array);
                    }
                    break;
            }
            if (array != null)
            {
                ChartPointEventArgs chartPointEventArgs = new ChartPointEventArgs(array, content);
                OnGotChartPoint(chartPointEventArgs);
                MainToolTip.SetToolTip(this, chartPointEventArgs.Content);
            }
            stopwatch.Stop();
            Debug.WriteLine("It took {stopwatch.ElapsedMilliseconds} to find the data.");
        }

        /// <summary>
        /// Gets the point location.
        /// </summary>
        /// <param name="scalesXAt">The scales x at.</param>
        /// <param name="scalesYAt">The scales y at.</param>
        /// <param name="cp">The cp.</param>
        /// <returns>PointF.</returns>
        public PointF GetPointLocation(int scalesXAt, int scalesYAt, ChartPoint cp)
        {
            return new PointF(CountLeft(scalesXAt, cp.X), CountTop(scalesYAt, cp.Y));
        }

        /// <summary>
        /// Counts the left.
        /// </summary>
        /// <param name="scalesXAt">The scales x at.</param>
        /// <param name="xValue">The x value.</param>
        /// <returns>System.Single.</returns>
        public float CountLeft(int scalesXAt, double xValue)
        {
            double num = _border.Width;
            double num2 = num / _axisX[scalesXAt].Range;
            double num3 = (xValue - _axisX[scalesXAt].MinValue) * num2;
            if (_axisX[scalesXAt].IsReverse)
            {
                num3 = num - num3;
            }
            num3 += (double)_border.Left;
            return Convert.ToSingle(num3);
        }

        /// <summary>
        /// Counts the top.
        /// </summary>
        /// <param name="scalesYAt">The scales y at.</param>
        /// <param name="yValue">The y value.</param>
        /// <returns>System.Single.</returns>
        public float CountTop(int scalesYAt, double yValue)
        {
            double num = _border.Height;
            double num2 = num / _axisY[scalesYAt].Range;
            double num3 = (yValue - _axisY[scalesYAt].MinValue) * num2;
            if (!_axisY[scalesYAt].IsReverse)
            {
                num3 = num - num3;
            }
            num3 += (double)_border.Top;
            return Convert.ToSingle(num3);
        }

        /// <summary>
        /// Counts the value x.
        /// </summary>
        /// <param name="scalesXAt">The scales x at.</param>
        /// <param name="xLocation">The x location.</param>
        /// <returns>System.Double.</returns>
        public double CountValueX(int scalesXAt, double xLocation)
        {
            double num = _border.Width;
            double num2 = _axisX[scalesXAt].Range / num;
            double num3 = (xLocation - (double)_border.Left) * num2;
            if (_axisX[scalesXAt].IsReverse)
            {
                num3 = _axisX[scalesXAt].Range - num3;
            }
            return num3 - Math.Abs(_axisX[scalesXAt].MinValue);
        }

        /// <summary>
        /// Counts the value y.
        /// </summary>
        /// <param name="scalesYAt">The scales y at.</param>
        /// <param name="yLocation">The y location.</param>
        /// <returns>System.Double.</returns>
        public double CountValueY(int scalesYAt, double yLocation)
        {
            double num = _border.Height;
            double num2 = _axisY[scalesYAt].Range / num;
            double num3 = (yLocation - (double)_border.Top) * num2;
            if (!_axisY[scalesYAt].IsReverse)
            {
                num3 = _axisY[scalesYAt].Range - num3;
            }
            return num3 - Math.Abs(_axisY[scalesYAt].MinValue);
        }

        /// <summary>
        /// Gets the mouse value string.
        /// </summary>
        /// <param name="mouseLocation">The mouse location.</param>
        /// <returns>System.String.</returns>
        public string GetMouseValueStr(Point mouseLocation)
        {
            string text = "";
            int count = _axisX.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (!_axisX[i].IsCustomLabels)
                    {
                        double value = CountValueX(i, mouseLocation.X);
                        text += "{_axisX[i].Title}:{Math.Round(value, 2)}\r\n";
                    }
                }
            }
            int count2 = _axisY.Count;
            if (count2 > 0)
            {
                for (int j = 0; j < count2; j++)
                {
                    if (!_axisY[j].IsCustomLabels)
                    {
                        double value2 = CountValueY(j, mouseLocation.Y);
                        text += "{_axisY[j].Title}:{Math.Round(value2, 2)}\r\n";
                    }
                }
            }
            return text;
        }

        /// <summary>
        /// Draws to bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        public void DrawToBitmap(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                Size size = base.Size;
                Point location = base.Location;
                DockStyle dock = Dock;
                Dock = DockStyle.None;
                base.Size = bitmap.Size;
                DrawToBitmap(bitmap, base.ClientRectangle);
                base.Size = size;
                base.Location = location;
                Dock = dock;
            }
        }

        /// <summary>
        /// Sets the offset.
        /// </summary>
        /// <param name="offsetX">The offset x.</param>
        /// <param name="offsetY">The offset y.</param>
        public void SetOffset(int offsetX, int offsetY)
        {
            _offsetX = offsetX;
            _offsetY = offsetY;
            Invalidate();
        }

        /// <summary>
        /// Sets the zoom times.
        /// </summary>
        /// <param name="times">The times.</param>
        public void SetZoomTimes(double times)
        {
            if (times < -2.0)
            {
                zoomTimes = -2.0;
            }
            else if (times > 0.5)
            {
                zoomTimes = 0.5;
            }
            else
            {
                zoomTimes = times;
            }
            zoomTimes = Math.Round(zoomTimes, 2);
            Invalidate();
        }

        /// <summary>
        /// Begins the update.
        /// </summary>
        public void BeginUpdate()
        {
            updateFlag = false;
        }

        /// <summary>
        /// Ends the update.
        /// </summary>
        public void EndUpdate()
        {
            updateFlag = true;
            Invalidate();
        }

        /// <summary>
        /// Selects the points by location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="range">The range.</param>
        /// <returns>ChartPoint[].</returns>
        public ChartPoint[] SelectPointsByLocation(Point location, int range)
        {
            List<ChartPoint> list = new List<ChartPoint>();
            foreach (SeriesBase item in Series)
            {
                ChartPoint chartPoint = item.Select(location.X, location.Y, range);
                if (chartPoint != null)
                {
                    list.Add(chartPoint);
                }
            }
            if (list.Count > 0)
            {
                return list.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Selects the points by x.
        /// </summary>
        /// <param name="indexOfAxisX">The index of axis x.</param>
        /// <param name="x">The x.</param>
        /// <param name="range">The range.</param>
        /// <returns>ChartPoint[].</returns>
        public ChartPoint[] SelectPointsByX(int indexOfAxisX, int x, int range)
        {
            List<ChartPoint> list = new List<ChartPoint>();
            foreach (SeriesBase item in _series)
            {
                if (item.ScalesXAt == indexOfAxisX)
                {
                    ChartPoint chartPoint = item.SelectByX(x, range);
                    if (chartPoint != null)
                    {
                        if (list.Count == 0)
                        {
                            list.Add(chartPoint);
                        }
                        else if (chartPoint.X == list[0].X)
                        {
                            list.Add(chartPoint);
                        }
                    }
                }
            }
            if (list.Count > 0)
            {
                return list.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Selects the points by y.
        /// </summary>
        /// <param name="indexOfAxisY">The index of axis y.</param>
        /// <param name="y">The y.</param>
        /// <param name="range">The range.</param>
        /// <returns>ChartPoint[].</returns>
        public ChartPoint[] SelectPointsByY(int indexOfAxisY, int y, int range)
        {
            List<ChartPoint> list = new List<ChartPoint>();
            foreach (SeriesBase item in _series)
            {
                if (item.ScalesYAt == indexOfAxisY)
                {
                    ChartPoint chartPoint = item.SelectByY(y, range);
                    if (chartPoint != null)
                    {
                        if (list.Count == 0)
                        {
                            list.Add(chartPoint);
                        }
                        else if (chartPoint.Y == list[0].Y)
                        {
                            list.Add(chartPoint);
                        }
                    }
                }
            }
            if (list.Count > 0)
            {
                return list.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the points content1.
        /// </summary>
        /// <param name="pts">The PTS.</param>
        /// <returns>System.String.</returns>
        public string GetPointsContent1(ChartPoint[] pts)
        {
            string text = "";
            foreach (ChartPoint chartPoint in pts)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    text += "\r";
                }
                text = text + chartPoint.Series.Title + "(" + chartPoint.GetLabelFromAxisX() + " , " + chartPoint.GetLabelFromAxisY() + ")";
            }
            return text;
        }

        /// <summary>
        /// Gets the points content2.
        /// </summary>
        /// <param name="pts">The PTS.</param>
        /// <returns>System.String.</returns>
        public string GetPointsContent2(ChartPoint[] pts)
        {
            string text = pts[0].GetLabelFromAxisX() ?? "";
            foreach (ChartPoint chartPoint in pts)
            {
                text = text + "\r" + chartPoint.Series.Title + " : " + chartPoint.GetLabelFromAxisY();
            }
            return text;
        }

        /// <summary>
        /// Gets the points content3.
        /// </summary>
        /// <param name="pts">The PTS.</param>
        /// <returns>System.String.</returns>
        public string GetPointsContent3(ChartPoint[] pts)
        {
            string text = pts[0].GetLabelFromAxisY() ?? "";
            foreach (ChartPoint chartPoint in pts)
            {
                text = text + "\r" + chartPoint.Series.Title + " : " + chartPoint.GetLabelFromAxisX();
            }
            return text;
        }

        /// <summary>
        /// Sets the tool tip.
        /// </summary>
        /// <param name="caption">The caption.</param>
        public void SetToolTip(string caption)
        {
            MainToolTip.SetToolTip(this, caption);
        }

        /// <summary>
        /// 将 <see cref="P:System.Windows.Forms.Control.RightToLeft" /> 属性重置为其默认值。
        /// </summary>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [Bindable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ResetRightToLeft()
        {
            base.ResetRightToLeft();
        }
    }
}
