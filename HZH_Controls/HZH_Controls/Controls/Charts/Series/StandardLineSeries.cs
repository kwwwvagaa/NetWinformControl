// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="StandardLineSeries.cs">
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
    /// Class StandardLineSeries.
    /// Implements the <see cref="HZH_Controls.Controls.SeriesBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.SeriesBase" />
	public class StandardLineSeries : SeriesBase
	{
        /// <summary>
        /// The thickness
        /// </summary>
		private float _thickness = 1f;

        /// <summary>
        /// The horizontat line visible
        /// </summary>
		private bool _horizontatLineVisible = true;

        /// <summary>
        /// The vertical line visible
        /// </summary>
		private bool _verticalLineVisible = true;

        /// <summary>
        /// Gets or sets the thickness.
        /// </summary>
        /// <value>The thickness.</value>
		[Category("自定义")]
		[Description("图形宽度。")]
		[DefaultValue(1f)]
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
        /// Gets or sets a value indicating whether [horizontat line visible].
        /// </summary>
        /// <value><c>true</c> if [horizontat line visible]; otherwise, <c>false</c>.</value>
		[Category("自定义")]
		[Description("显示/隐藏横向基准线。")]
		[DefaultValue(true)]
		public bool HorizontatLineVisible
		{
			get
			{
				return _horizontatLineVisible;
			}
			set
			{
				_horizontatLineVisible = value;
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether [vertical line visible].
        /// </summary>
        /// <value><c>true</c> if [vertical line visible]; otherwise, <c>false</c>.</value>
		[Category("自定义")]
		[Description("显示/隐藏纵向基准线。")]
		[DefaultValue(true)]
		public bool VerticalLineVisible
		{
			get
			{
				return _verticalLineVisible;
			}
			set
			{
				_verticalLineVisible = value;
			}
		}

        /// <summary>
        /// Draws the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
		internal override void Draw(Graphics g)
		{
			PointF[] locationArray = GetLocationArray();
			if (locationArray != null && locationArray.Length != 0)
			{
				using (Pen pen = new Pen(base.Color, Thickness))
				{
					if (_horizontatLineVisible && base.ParentAxisX != null)
					{
						float x = CountLeft(base.ParentAxisX.MinValue);
						float x2 = CountLeft(base.ParentAxisX.MaxValue);
						PointF[] array = locationArray;
						for (int i = 0; i < array.Length; i++)
						{
							PointF pointF = array[i];
							g.DrawLine(pen, x, pointF.Y, x2, pointF.Y);
						}
					}
					if (_verticalLineVisible && base.ParentAxisY != null)
					{
						float y = CountTop(base.ParentAxisY.MinValue);
						float y2 = CountTop(base.ParentAxisY.MaxValue);
						PointF[] array2 = locationArray;
						for (int j = 0; j < array2.Length; j++)
						{
							PointF pointF2 = array2[j];
							g.DrawLine(pen, pointF2.X, y, pointF2.X, y2);
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
