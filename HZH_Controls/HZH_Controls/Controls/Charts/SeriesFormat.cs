// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="SeriesFormat.cs">
//     Copyright by Huang Zhenghui(»ÆÕý»Ô) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub£ºhttps://github.com/kwwwvagaa/NetWinformControl
// gitee£ºhttps://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System.Drawing;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class SeriesFormat.
    /// </summary>
	public class SeriesFormat
	{
        /// <summary>
        /// The label format
        /// </summary>
       static StringFormat labelFormat=new StringFormat
		{
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Far
		};
       /// <summary>
       /// Gets or sets the label format.
       /// </summary>
       /// <value>The label format.</value>
		public static StringFormat LabelFormat
		{
            get { return labelFormat; }
            set { labelFormat = value; }
		} 

	}
}
