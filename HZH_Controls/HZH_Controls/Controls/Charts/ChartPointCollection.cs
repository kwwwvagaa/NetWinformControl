// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="ChartPointCollection.cs">
//     Copyright by Huang Zhenghui(»ÆÕý»Ô) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub£ºhttps://github.com/kwwwvagaa/NetWinformControl
// gitee£ºhttps://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System.Collections.ObjectModel;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class ChartPointCollection.
    /// Implements the <see cref="System.Collections.ObjectModel.Collection{HZH_Controls.Controls.ChartPoint}" />
    /// </summary>
    /// <seealso cref="System.Collections.ObjectModel.Collection{HZH_Controls.Controls.ChartPoint}" />
	public class ChartPointCollection : Collection<ChartPoint>
	{
        /// <summary>
        /// Gets the chart.
        /// </summary>
        /// <value>The chart.</value>
		public UCChart Chart
		{
			get;
			internal set;
		}

        /// <summary>
        /// Gets the series.
        /// </summary>
        /// <value>The series.</value>
		public SeriesBase Series
		{
			get;
			internal set;
		}

        /// <summary>
        /// Inserts the item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
		protected override void InsertItem(int index, ChartPoint item)
		{
			base.InsertItem(index, item);
			item.Chart = Chart;
			item.Series = Series;
			if(Chart!=null)Chart.Invalidate();
		}

        /// <summary>
        /// Sets the item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
		protected override void SetItem(int index, ChartPoint item)
		{
			base.SetItem(index, item);
			item.Chart = Chart;
			item.Series = Series;
			if(Chart!=null)Chart.Invalidate();
		}

        /// <summary>
        /// Clears the items.
        /// </summary>
		protected override void ClearItems()
		{
			base.ClearItems();
			if(Chart!=null)Chart.Invalidate();
		}

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="index">The index.</param>
		protected override void RemoveItem(int index)
		{
			base.RemoveItem(index);
			if(Chart!=null)Chart.Invalidate();
		}
	}
}
