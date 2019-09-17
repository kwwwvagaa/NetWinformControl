// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="LineSeries.cs">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class LineSeries.
    /// Implements the <see cref="HZH_Controls.Controls.SeriesBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.SeriesBase" />
	public class LineSeries : SeriesBase
	{
        /// <summary>
        /// The thickness
        /// </summary>
		private float _thickness = 1.8f;

        /// <summary>
        /// The curve tension
        /// </summary>
		private float _curveTension = 0f;

        /// <summary>
        /// The fill graph
        /// </summary>
		private bool _fillGraph = true;

        /// <summary>
        /// The point visible
        /// </summary>
		private bool _pointVisible = false;

        /// <summary>
        /// The value visible
        /// </summary>
		private bool _valueVisible = false;

        /// <summary>
        /// The font
        /// </summary>
		private Font _font = new Font("微软雅黑", 10f);

        /// <summary>
        /// Gets or sets the thickness.
        /// </summary>
        /// <value>The thickness.</value>
		[Category("自定义")]
		[Description("图形宽度。")]
		[DefaultValue(1.8f)]
		public float Thickness
		{
			get
			{
				return _thickness;
			}
			set
			{
				_thickness = value;
			}
		}

        /// <summary>
        /// Gets or sets the curve tension.
        /// </summary>
        /// <value>The curve tension.</value>
		[Category("自定义")]
		[Description("曲线张力。")]
		[DefaultValue(0f)]
		public float CurveTension
		{
			get
			{
				return _curveTension;
			}
			set
			{
				_curveTension = value;
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether [fill graph].
        /// </summary>
        /// <value><c>true</c> if [fill graph]; otherwise, <c>false</c>.</value>
		[Category("自定义")]
		[Description("是否填充图形。")]
		[DefaultValue(true)]
		public bool FillGraph
		{
			get
			{
				return _fillGraph;
			}
			set
			{
				_fillGraph = value;
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether [point visible].
        /// </summary>
        /// <value><c>true</c> if [point visible]; otherwise, <c>false</c>.</value>
		[Category("自定义")]
		[Description("显示/隐藏点状图形。")]
		[DefaultValue(false)]
		public bool PointVisible
		{
			get
			{
				return _pointVisible;
			}
			set
			{
				_pointVisible = value;
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether [value visible].
        /// </summary>
        /// <value><c>true</c> if [value visible]; otherwise, <c>false</c>.</value>
		[Category("自定义")]
		[Description("显示/隐藏当前值。")]
		[DefaultValue(false)]
		public bool ValueVisible
		{
			get
			{
				return _valueVisible;
			}
			set
			{
				_valueVisible = value;
			}
		}

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
		[Category("自定义")]
		[Description("字体。")]
		public Font Font
		{
			get
			{
				return _font;
			}
			set
			{
				_font = value;
			}
		}

        /// <summary>
        /// Draws the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
		internal override void Draw(Graphics g)
		{
			PointF[] locationArray = GetLocationArray();
			if (locationArray != null && locationArray.Length > 1)
			{
				using (Pen pen = new Pen(base.Color, Thickness))
				{
					if (CurveTension > 0f)
					{
						g.DrawCurve(pen, locationArray, CurveTension);
					}
					else
					{
						g.DrawLines(pen, locationArray);
					}
				}
				if (FillGraph && base.ParentAxisY != null)
				{
					double yValue = base.ParentAxisY.IsReverse ? base.ParentAxisY.MaxValue : base.ParentAxisY.MinValue;
					int num = (int)Math.Round(CountTop(yValue));
					PointF[] array = new PointF[locationArray.Length + 2];
					locationArray.CopyTo(array, 0);
					array[array.Length - 1] = new PointF(locationArray[0].X, num);
					array[array.Length - 2] = new PointF(locationArray[locationArray.Length - 1].X, num);
					using (SolidBrush brush = new SolidBrush(Color.FromArgb(50, base.Color)))
					{
						g.FillPolygon(brush, array);
					}
				}
			}
			if (base.Points.Count > 0 && (_pointVisible || _valueVisible))
			{
				using (SolidBrush brush2 = new SolidBrush(base.Color))
				{
					if (_pointVisible)
					{
						float num2 = 4f * _thickness;
						foreach (ChartPoint point in base.Points)
						{
							int num3 = (int)Math.Round((float)point.Left - 2f * _thickness);
							int num4 = (int)Math.Round((float)point.Top - 2f * _thickness);
							g.FillEllipse(brush2, num3, num4, num2, num2);
						}
					}
					if (_valueVisible)
					{
						ChartPoint chartPoint = base.Points.Last();
						string text = chartPoint.Y.ToString();
						if (!string.IsNullOrEmpty(text))
						{
							g.DrawString(text, _font, brush2, new Point(chartPoint.Left, chartPoint.Top), SeriesFormat.LabelFormat);
						}
					}
				}
			}
		}

        /// <summary>
        /// Paints the legend.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
		protected override void PaintLegend(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			float num = ((float)base.Legend.Height - _thickness) / 2f;
			using (Pen pen = new Pen(base.Color, _thickness))
			{
				e.Graphics.DrawLine(pen, 0f, num, 12f, num);
			}
		}
	}
}
