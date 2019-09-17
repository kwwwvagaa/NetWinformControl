// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="ChartPointEventArgs.cs">
//     Copyright by Huang Zhenghui(»ÆÕý»Ô) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub£ºhttps://github.com/kwwwvagaa/NetWinformControl
// gitee£ºhttps://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class ChartPointEventArgs.
    /// Implements the <see cref="System.EventArgs" />
    /// </summary>
    /// <seealso cref="System.EventArgs" />
	public class ChartPointEventArgs : EventArgs
	{
        /// <summary>
        /// Gets the point.
        /// </summary>
        /// <value>The point.</value>
		public ChartPoint[] Point
		{
			get;
			private set;
		}

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
		public string Content
		{
			get;
			set;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartPointEventArgs"/> class.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="content">The content.</param>
		public ChartPointEventArgs(ChartPoint[] point = null, string content = null)
		{
			Point = point;
			Content = content;
		}
	}
}
