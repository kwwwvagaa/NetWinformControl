// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="PointSeries.cs">
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
    /// Class PointSeries.
    /// Implements the <see cref="HZH_Controls.Controls.SeriesBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.SeriesBase" />
	public class PointSeries : SeriesBase
	{
        /// <summary>
        /// The width
        /// </summary>
		private int _width = 8;

        /// <summary>
        /// The height
        /// </summary>
		private int _height = 8;

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
		[Category("自定义")]
		[Description("图形宽度。")]
		[DefaultValue(8)]
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
		[DefaultValue(8)]
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
        /// Draws the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
		internal override void Draw(Graphics g)
		{
			if (base.Points.Count > 0)
			{
				using (SolidBrush brush = new SolidBrush(base.Color))
				{
					foreach (ChartPoint point in base.Points)
					{
						float x = (float)point.Left - (float)_width / 2f;
						float y = (float)point.Top - (float)_height / 2f;
						g.FillEllipse(brush, x, y, _width, _height);
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
			using (SolidBrush brush = new SolidBrush(base.Color))
			{
				e.Graphics.FillEllipse(brush, 2f, (float)(base.Legend.Height - 8) / 2f, 8f, 8f);
			}
		}
	}
}
