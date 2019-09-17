// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="SeriesCollection.cs">
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
using System.ComponentModel;
using System.Drawing.Design;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class SeriesCollection.
    /// Implements the <see cref="System.Collections.ObjectModel.Collection{HZH_Controls.Controls.SeriesBase}" />
    /// </summary>
    /// <seealso cref="System.Collections.ObjectModel.Collection{HZH_Controls.Controls.SeriesBase}" />
	[Editor(typeof(SeriesCollectionEditor), typeof(UITypeEditor))]
	public class SeriesCollection : Collection<SeriesBase>
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
        /// Inserts the item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
		protected override void InsertItem(int index, SeriesBase item)
		{
			base.InsertItem(index, item);
			item.Chart = Chart;
			item.Points.Chart = Chart;
			item.Points.Series = item;
			if (Chart != null)
			{
				Chart.LegendPanel.Controls.Add(item.Legend);
			}
			if(Chart!=null)Chart.Invalidate();
		}

        /// <summary>
        /// Sets the item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
		protected override void SetItem(int index, SeriesBase item)
		{
			if (Chart != null)
			{
				Chart.LegendPanel.Controls.Remove(base[index].Legend);
			}
			base.SetItem(index, item);
			item.Chart = Chart;
			item.Points.Chart = Chart;
			item.Points.Series = item;
			if (Chart != null)
			{
				Chart.LegendPanel.Controls.Add(item.Legend);
			}
			if(Chart!=null)Chart.Invalidate();
		}

        /// <summary>
        /// Clears the items.
        /// </summary>
		protected override void ClearItems()
		{
			if (Chart != null)
			{
				Chart.LegendPanel.Controls.Clear();
			}
			base.ClearItems();
			if(Chart!=null)Chart.Invalidate();
		}

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="index">The index.</param>
		protected override void RemoveItem(int index)
		{
			if (Chart != null)
			{
				Chart.LegendPanel.Controls.Remove(base[index].Legend);
			}
			base.RemoveItem(index);
			if(Chart!=null)Chart.Invalidate();
		}
	}
}
