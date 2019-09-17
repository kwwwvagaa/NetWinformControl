// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="BarChartItem.cs">
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class BarChartItem.
    /// </summary>
    public class BarChartItem
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="BarChartItem"/> class.
        /// </summary>
        /// <param name="_barBackColor">Color of the bar back.</param>
        /// <param name="_itemName">Name of the item.</param>
        /// <param name="_barPercentWidth">柱状图占平均宽度的百分比，默认0.8，即80%.</param>
        public BarChartItem(
            string _itemName = "",
            Color? _barBackColor = null,
            float _barPercentWidth = 0.9f)
        {
            barBackColor = _barBackColor;
            itemName = _itemName;
            barPercentWidth = _barPercentWidth;
        }
        /// <summary>
        /// The bar back color
        /// </summary>
        private Color? barBackColor ;

        /// <summary>
        /// Gets or sets the color of the bar back.
        /// </summary>
        /// <value>The color of the bar back.</value>
        public Color? BarBackColor
        {
            get { return barBackColor; }
            set { barBackColor = value; }
        }

        /// <summary>
        /// The bar percent width
        /// </summary>
        private float barPercentWidth = 0.9f;

        /// <summary>
        /// 获取或设置柱状图占平均宽度的百分比，默认0.9，即90%
        /// </summary>
        /// <value>The width of the bar percent.</value>
        public float BarPercentWidth
        {
            get { return barPercentWidth; }
            set { barPercentWidth = value; }
        }

        /// <summary>
        /// The item name
        /// </summary>
        private string itemName;

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>The name of the item.</value>
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
    }
}
