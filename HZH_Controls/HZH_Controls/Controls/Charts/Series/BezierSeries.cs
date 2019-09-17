// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="BezierSeries.cs">
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
    /// Class BezierSeries.
    /// Implements the <see cref="HZH_Controls.Controls.SeriesBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.SeriesBase" />
	public class BezierSeries : SeriesBase
	{
        /// <summary>
        /// The thickness
        /// </summary>
		private float _thickness = 1.8f;

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
        /// Draws the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
		internal override void Draw(Graphics g)
		{
			PointF[] locationArray = GetLocationArray();
			if (locationArray != null && locationArray.Length > 3)
			{
				int num = locationArray.Length % 3;
				int num2 = locationArray.Length / 3;
				int num3 = (num != 0) ? 1 : (-2);
				PointF[] points = locationArray.Take(3 * num2 + num3).ToArray();
				using (Pen pen = new Pen(base.Color, Thickness))
				{
					g.DrawBeziers(pen, points);
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
			PointF[] points = new PointF[4]
			{
				new PointF(0f, (float)base.Legend.Height / 2f),
				new PointF(3f, 0f),
				new PointF(9f, base.Legend.Height),
				new PointF(12f, (float)base.Legend.Height / 2f)
			};
			using (Pen pen = new Pen(base.Color, _thickness))
			{
				e.Graphics.DrawBeziers(pen, points);
			}
		}
	}
}
