// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-25
//
// ***********************************************************************
// <copyright file="RadarLine.cs">
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
using System.Drawing;
using System.Linq;
using System.Text;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class RadarLine.
    /// </summary>
    public class RadarLine
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>The values.</value>
        public double[] Values { get; set; }
        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        public Color? LineColor { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show value text].
        /// </summary>
        /// <value><c>true</c> if [show value text]; otherwise, <c>false</c>.</value>
        public bool ShowValueText { get; set; }
        /// <summary>
        /// Gets or sets the color of the fill.
        /// </summary>
        /// <value>The color of the fill.</value>
        public Color? FillColor { get; set; }
    }
}
