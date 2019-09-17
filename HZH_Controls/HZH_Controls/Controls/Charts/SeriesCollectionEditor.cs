// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="SeriesCollectionEditor.cs">
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
using System.ComponentModel.Design;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class SeriesCollectionEditor.
    /// Implements the <see cref="System.ComponentModel.Design.CollectionEditor" />
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.CollectionEditor" />
	public class SeriesCollectionEditor : CollectionEditor
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="SeriesCollectionEditor"/> class.
        /// </summary>
        /// <param name="type">此编辑器要编辑的集合的类型。</param>
		public SeriesCollectionEditor(Type type)
			: base(type)
		{
		}

        /// <summary>
        /// 指示是否可一次选择多个集合项。
        /// </summary>
        /// <returns>如果可以同时选择多个集合成员，则为 true；否则，为 false。默认情况下，它将返回 true。</returns>
		protected override bool CanSelectMultipleInstances()
		{
			return true;
		}

        /// <summary>
        /// 获取此集合编辑器可包含的数据类型。
        /// </summary>
        /// <returns>此集合可包含的数据类型数组。</returns>
		protected override Type[] CreateNewItemTypes()
		{
			return new Type[6]
			{
				typeof(BezierSeries),
				typeof(ColumnSeries),
				typeof(LabelSeries),
				typeof(LineSeries),
				typeof(PointSeries),
				typeof(StandardLineSeries)
			};
		}

        /// <summary>
        /// 创建指定的集合项类型的新实例。
        /// </summary>
        /// <param name="itemType">要创建的项类型。</param>
        /// <returns>指定对象的新实例。</returns>
		protected override object CreateInstance(Type itemType)
		{
			if (itemType == typeof(BezierSeries))
			{
				return new BezierSeries();
			}
			if (itemType == typeof(ColumnSeries))
			{
				return new ColumnSeries();
			}
			if (itemType == typeof(LabelSeries))
			{
				return new LabelSeries();
			}
			if (itemType == typeof(LineSeries))
			{
				return new LineSeries();
			}
			if (itemType == typeof(PointSeries))
			{
				return new PointSeries();
			}
			if (itemType == typeof(StandardLineSeries))
			{
				return new StandardLineSeries();
			}
			return null;
		}
	}
}
