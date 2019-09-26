// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-26
//
// ***********************************************************************
// <copyright file="FunelChartItem.cs">
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

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class FunelChartItem.
    /// </summary>
    public class FunelChartItem
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public float Value { get; set; }
        /// <summary>
        /// Gets or sets the color of the value.
        /// </summary>
        /// <value>The color of the value.</value>
        public System.Drawing.Color? ValueColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the text fore.
        /// </summary>
        /// <value>The color of the text fore.</value>
        public System.Drawing.Color? TextForeColor { get; set; }
    }
}
