// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="AxisLabel.cs">
//     Copyright by Huang Zhenghui(»ÆÕý»Ô) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub£ºhttps://github.com/kwwwvagaa/NetWinformControl
// gitee£ºhttps://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System.ComponentModel;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class AxisLabel.
    /// </summary>
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class AxisLabel
	{
        /// <summary>
        /// The content
        /// </summary>
		private string _content;

        /// <summary>
        /// The value
        /// </summary>
		private double _value;

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
		public string Content
		{
			get
			{
				return _content;
			}
			set
			{
				_content = value;
			}
		}

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
		public double Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="AxisLabel"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
		public AxisLabel(double value)
		{
			_value = value;
			_content = _value.ToString();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="AxisLabel"/> class.
        /// </summary>
		public AxisLabel()
			: this(0.0)
		{
		}
	}
}
