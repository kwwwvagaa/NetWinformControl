// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="LabelSeries.cs">
//     Copyright by Huang Zhenghui(黄正辉) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub：https://github.com/kwwwvagaa/NetWinformControl
// gitee：https://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class LabelSeries.
    /// Implements the <see cref="HZH_Controls.Controls.SeriesBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.SeriesBase" />
	public class LabelSeries : SeriesBase
	{
        /// <summary>
        /// The width
        /// </summary>
		private int _width = 12;

        /// <summary>
        /// The height
        /// </summary>
		private int _height = 12;

        /// <summary>
        /// The font
        /// </summary>
		private Font _font = new Font("微软雅黑", 10f);

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
		[Category("自定义")]
		[Description("图形宽度。")]
		[DefaultValue(12)]
		public int Width
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
			}
		}

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
		[Category("自定义")]
		[Description("图形高度。")]
		[DefaultValue(12)]
		public int Height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
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
			if (base.Points.Count > 0)
			{
				using (SolidBrush brush = new SolidBrush(base.Color))
				{
					foreach (ChartPoint point2 in base.Points)
					{
						int left = point2.Left;
						int top = point2.Top;
						Point[] points = new Point[3]
						{
							new Point(left, top),
							new Point(left - _width / 2, top - _height),
							new Point(left + _width / 2, top - _height)
						};
						g.FillPolygon(brush, points);
						if (!string.IsNullOrEmpty(point2.Label))
						{
							g.DrawString(point: new Point(left, top - _height), s: point2.Label, font: _font, brush: brush, format: SeriesFormat.LabelFormat);
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
			float num = ((float)base.Legend.Height - 12f) / 2f;
			PointF[] points = new PointF[3]
			{
				new PointF(0f, num),
				new PointF(12f, num),
				new PointF(6f, num + 12f)
			};
			using (SolidBrush brush = new SolidBrush(base.Color))
			{
				e.Graphics.FillPolygon(brush, points);
			}
		}
	}
}
