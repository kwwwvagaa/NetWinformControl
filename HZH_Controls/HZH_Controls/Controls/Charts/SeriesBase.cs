// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="SeriesBase.cs">
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
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class SeriesBase.
    /// </summary>
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public abstract class SeriesBase
	{
        /// <summary>
        /// The chart
        /// </summary>
		private UCChart _chart;

        /// <summary>
        /// The title
        /// </summary>
		private string _title = "Series";

        /// <summary>
        /// The points
        /// </summary>
		private ChartPointCollection _points = new ChartPointCollection();

        /// <summary>
        /// The scales x at
        /// </summary>
		private int _scalesXAt = 0;

        /// <summary>
        /// The scales y at
        /// </summary>
		private int _scalesYAt = 0;

        /// <summary>
        /// The color
        /// </summary>
		private Color _color = Color.FromArgb(232, 17, 35);

        /// <summary>
        /// The visible
        /// </summary>
		private bool _visible = true;

        /// <summary>
        /// The legend
        /// </summary>
		private Label _legend;

        /// <summary>
        /// The legend visible
        /// </summary>
		private bool _legendVisible = true;

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
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
		[Category("自定义")]
		[Description("标题。")]
		[DefaultValue("Series")]
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
				_legend.Text = _title;
			}
		}

        /// <summary>
        /// Gets the points.
        /// </summary>
        /// <value>The points.</value>
		[Category("自定义")]
		[Description("数据点。")]
		[TypeConverter(typeof(CollectionConverter))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ChartPointCollection Points
		{
			get
			{
				return _points;
			}
			private set
			{
				_points = value;
			}
		}

        /// <summary>
        /// Gets the maximum value x.
        /// </summary>
        /// <value>The maximum value x.</value>
		[Browsable(false)]
		public double? MaxValueX
		{
			get
			{
				if (_points == null || _points.Count < 1)
				{
					return null;
				}
				IEnumerable<double> source = from cp in _points
					select cp.X;
				return source.Max();
			}
		}

        /// <summary>
        /// Gets the minimum value x.
        /// </summary>
        /// <value>The minimum value x.</value>
		[Browsable(false)]
		public double? MinValueX
		{
			get
			{
				if (_points == null || _points.Count < 1)
				{
					return null;
				}
				IEnumerable<double> source = from cp in _points
					select cp.X;
				return source.Min();
			}
		}

        /// <summary>
        /// Gets the maximum value y.
        /// </summary>
        /// <value>The maximum value y.</value>
		[Browsable(false)]
		public double? MaxValueY
		{
			get
			{
				if (_points == null || _points.Count < 1)
				{
					return null;
				}
				IEnumerable<double> source = from cp in _points
					select cp.Y;
				return source.Max();
			}
		}

        /// <summary>
        /// Gets the minimum value y.
        /// </summary>
        /// <value>The minimum value y.</value>
		[Browsable(false)]
		public double? MinValueY
		{
			get
			{
				if (_points == null || _points.Count < 1)
				{
					return null;
				}
				IEnumerable<double> source = from cp in _points
					select cp.Y;
				return source.Min();
			}
		}

        /// <summary>
        /// Gets or sets the scales x at.
        /// </summary>
        /// <value>The scales x at.</value>
		[Category("自定义")]
		[Description("附着的X轴序号。")]
		[DefaultValue(0)]
		public int ScalesXAt
		{
			get
			{
				return _scalesXAt;
			}
			set
			{
				if (value < 0)
				{
					_scalesXAt = 0;
				}
				else
				{
					_scalesXAt = value;
				}
			}
		}

        /// <summary>
        /// Gets the parent axis x.
        /// </summary>
        /// <value>The parent axis x.</value>
		[Browsable(false)]
		public Axis ParentAxisX
		{
			get
			{
				if (_chart != null && _scalesXAt < _chart.AxisX.Count)
				{
					return _chart.AxisX[_scalesXAt];
				}
				return null;
			}
		}

        /// <summary>
        /// Gets or sets the scales y at.
        /// </summary>
        /// <value>The scales y at.</value>
		[Category("自定义")]
		[Description("附着的Y轴序号。")]
		[DefaultValue(0)]
		public int ScalesYAt
		{
			get
			{
				return _scalesYAt;
			}
			set
			{
				if (value < 0)
				{
					_scalesYAt = 0;
				}
				else
				{
					_scalesYAt = value;
				}
			}
		}

        /// <summary>
        /// Gets the parent axis y.
        /// </summary>
        /// <value>The parent axis y.</value>
		[Browsable(false)]
		public Axis ParentAxisY
		{
			get
			{
				if (_chart != null && _scalesYAt < _chart.AxisY.Count)
				{
					return _chart.AxisY[_scalesYAt];
				}
				return null;
			}
		}

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
		[Category("自定义")]
		[Description("颜色。")]
		public Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SeriesBase"/> is visible.
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
        /// Gets or sets the legend.
        /// </summary>
        /// <value>The legend.</value>
		[Browsable(false)]
		internal Label Legend
		{
			get
			{
				return _legend;
			}
			set
			{
				_legend = value;
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
				_legend.Visible = _legendVisible;
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="SeriesBase"/> class.
        /// </summary>
		public SeriesBase()
		{
			_color = GetColorByIndex(UCChart.ColorIndex);
			UCChart.ColorIndex++;
			_legend = new Label
			{
				AutoSize = true,
				Padding = new Padding(12, 0, 0, 0),
				Text = Title
			};
			_legend.Paint += PaintLegend;
		}

        /// <summary>
        /// Gets the index of the color by.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Color.</returns>
		public static Color GetColorByIndex(int index)
		{
			return UCChart.Colors[index - UCChart.Colors.Count * (index / UCChart.Colors.Count)];
		}

        /// <summary>
        /// Counts the left.
        /// </summary>
        /// <param name="xValue">The x value.</param>
        /// <returns>System.Single.</returns>
		public float CountLeft(double xValue)
		{
			double num = _chart.Border.Width;
			double num2 = num / ParentAxisX.Range;
			double num3 = (xValue - ParentAxisX.MinValue) * num2;
			if (ParentAxisX.IsReverse)
			{
				num3 = num - num3;
			}
			num3 += (double)_chart.Border.Left;
			return Convert.ToSingle(num3);
		}

        /// <summary>
        /// Counts the top.
        /// </summary>
        /// <param name="yValue">The y value.</param>
        /// <returns>System.Single.</returns>
		public float CountTop(double yValue)
		{
			double num = _chart.Border.Height;
			double num2 = num / ParentAxisY.Range;
			double num3 = (yValue - ParentAxisY.MinValue) * num2;
			if (!ParentAxisY.IsReverse)
			{
				num3 = num - num3;
			}
			num3 += (double)_chart.Border.Top;
			return Convert.ToSingle(num3);
		}

        /// <summary>
        /// Gets the location array.
        /// </summary>
        /// <returns>PointF[].</returns>
		public PointF[] GetLocationArray()
		{
			if (_points != null || _points.Count > 0)
			{
				PointF[] array = new PointF[_points.Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = new PointF(_points[i].Left, _points[i].Top);
				}
				return array;
			}
			return null;
		}

        /// <summary>
        /// Sets the values y.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="startValue">The start value.</param>
        /// <param name="valueStep">The value step.</param>
		public void SetValuesY(double[] values, double startValue = 0.0, double valueStep = 0.1)
		{
			_points.Clear();
			if (values != null && values.Length != 0)
			{
				_chart.BeginUpdate();
				for (int i = 0; i < values.Length; i++)
				{
					_points.Add(new ChartPoint((double)i * valueStep + startValue, values[i]));
				}
				_chart.EndUpdate();
			}
		}

        /// <summary>
        /// Sets the values x.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="startValue">The start value.</param>
        /// <param name="valueStep">The value step.</param>
		public void SetValuesX(double[] values, double startValue = 0.0, double valueStep = 0.1)
		{
			_points.Clear();
			if (values != null && values.Length != 0)
			{
				_chart.BeginUpdate();
				for (int i = 0; i < values.Length; i++)
				{
					_points.Add(new ChartPoint(values[i], (double)i * valueStep + startValue));
				}
				_chart.EndUpdate();
			}
		}

        /// <summary>
        /// Selects all by x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="range">The range.</param>
        /// <returns>ChartPoint[].</returns>
		public ChartPoint[] SelectAllByX(int x, float range = 0f)
		{
            var lst=(from cp in _points
				where (float)cp.Left >= (float)x - range && (float)cp.Left <= (float)x + range
				select cp);
            if(lst!=null)
                return lst.ToArray();
            else 
                return null;
		}

        /// <summary>
        /// Selects the by x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="range">The range.</param>
        /// <returns>ChartPoint.</returns>
		public ChartPoint SelectByX(int x, float range = 0f)
		{
			ChartPoint[] array = SelectAllByX(x, range);
			if (array == null)
			{
				return null;
			}
			int num = int.MaxValue;
			ChartPoint result = null;
			ChartPoint[] array2 = array;
			foreach (ChartPoint chartPoint in array2)
			{
				int num2 = Math.Abs(x - chartPoint.Left);
				if (num2 < num)
				{
					result = chartPoint;
					num = num2;
				}
			}
			return result;
		}

        /// <summary>
        /// Selects all by y.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="range">The range.</param>
        /// <returns>ChartPoint[].</returns>
		public ChartPoint[] SelectAllByY(int y, float range = 0f)
		{
            var lst=(from cp in _points
				where (float)cp.Top >= (float)y - range && (float)cp.Top <= (float)y + range
				select cp);
            if (lst != null)
                return lst.ToArray();
            else
                return null;
		}

        /// <summary>
        /// Selects the by y.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="range">The range.</param>
        /// <returns>ChartPoint.</returns>
		public ChartPoint SelectByY(int y, float range = 0f)
		{
			ChartPoint[] array = SelectAllByY(y, range);
			if (array == null)
			{
				return null;
			}
			int num = int.MaxValue;
			ChartPoint result = null;
			ChartPoint[] array2 = array;
			foreach (ChartPoint chartPoint in array2)
			{
				int num2 = Math.Abs(y - chartPoint.Top);
				if (num2 < num)
				{
					result = chartPoint;
					num = num2;
				}
			}
			return result;
		}

        /// <summary>
        /// Selects all.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="range">The range.</param>
        /// <returns>ChartPoint[].</returns>
		public ChartPoint[] SelectAll(int x, int y, float range = 0f)
		{
            var lst=(from cp in _points
				where (float)cp.Left >= (float)x - range && (float)cp.Left <= (float)x + range && (float)cp.Top >= (float)y - range && (float)cp.Top <= (float)y + range
				select cp);
            if(lst!=null)
                return lst.ToArray();
            else 
                return null;
		}

        /// <summary>
        /// Selects the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="range">The range.</param>
        /// <returns>ChartPoint.</returns>
		public ChartPoint Select(int x, int y, float range = 0f)
		{
			ChartPoint[] array = SelectAll(x, y, range);
			if (array == null)
			{
				return null;
			}
			int num = int.MaxValue;
			ChartPoint result = null;
			ChartPoint[] array2 = array;
			foreach (ChartPoint chartPoint in array2)
			{
				int num2 = Math.Abs(x - chartPoint.Left) + Math.Abs(y - chartPoint.Top);
				if (num2 < num)
				{
					result = chartPoint;
					num = num2;
				}
			}
			return result;
		}

        /// <summary>
        /// Draws the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
		internal virtual void Draw(Graphics g)
		{
		}

        /// <summary>
        /// Paints the legend.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
		protected virtual void PaintLegend(object sender, PaintEventArgs e)
		{
		}
	}
}
