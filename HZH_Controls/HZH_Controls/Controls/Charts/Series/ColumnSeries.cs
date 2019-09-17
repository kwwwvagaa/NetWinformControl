// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="ColumnSeries.cs">
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
using System.Linq;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class ColumnSeries.
    /// Implements the <see cref="HZH_Controls.Controls.SeriesBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.SeriesBase" />
	public class ColumnSeries : SeriesBase
	{
        /// <summary>
        /// The width
        /// </summary>
		private int _width = 24;

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
		[Category("自定义")]
		[Description("图形宽度。")]
		[DefaultValue(24)]
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
        /// Paints the legend.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
		protected override void PaintLegend(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			using (SolidBrush brush = new SolidBrush(base.Color))
			{
				e.Graphics.FillRectangle(brush, 2f, ((float)base.Legend.Height - 16f) / 2f, 12f, 16f);
			}
		}

        /// <summary>
        /// Draws the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="border">The border.</param>
        /// <param name="sum">The sum.</param>
        /// <param name="series">The series.</param>
		internal static void Draw(Graphics g, Rectangle border, int sum, ColumnSeries[] series)
		{
			int num = series.Count();
			float num2 = 0f;
			for (int i = 0; i < num; i++)
			{
				num2 += (float)series[i].Width;
			}
			if (!(num2 > 0f))
			{
				return;
			}
			num2 += (float)(num - 1) * 3f;
			float num3 = border.Width;
			float num4 = num3 / (float)sum;
			float num5 = (float)border.Left + num4 - num2 / 2f;
			for (int j = 0; j < num; j++)
			{
				if (series[j].Visible)
				{
					PointF[] locationArray = series[j].GetLocationArray();
					if (locationArray != null && locationArray.Length != 0)
					{
						using (SolidBrush brush = new SolidBrush(series[j].Color))
						{
							for (int k = 0; k < locationArray.Length; k++)
							{
								float x = num5 + num4 * (float)k;
								float y = locationArray[k].Y;
								float width = series[j].Width;
								float height = (float)border.Bottom - locationArray[k].Y - 1f;
								RectangleF rect = new RectangleF(x, y, width, height);
								g.FillRectangle(brush, rect);
							}
						}
					}
					num5 += (float)series[j].Width + 3f;
				}
			}
		}
	}
}
