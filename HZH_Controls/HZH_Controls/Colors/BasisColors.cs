// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-30
//
// ***********************************************************************
// <copyright file="BasisColors.cs">
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

namespace HZH_Controls
{
    /// <summary>
    /// Class BasisColors.
    /// </summary>
    public class BasisColors
    {
        /// <summary>
        /// The light
        /// </summary>
        private static Color light = ColorTranslator.FromHtml("#f5f7fa");

        /// <summary>
        /// Gets the light.
        /// </summary>
        /// <value>The light.</value>
        public static Color Light
        {
            get { return light; }
            internal set { light = value; }
        }
        /// <summary>
        /// The medium
        /// </summary>
        private static Color medium = ColorTranslator.FromHtml("#f0f2f5");

        /// <summary>
        /// Gets the medium.
        /// </summary>
        /// <value>The medium.</value>
        public static Color Medium
        {
            get { return medium; }
            internal set { medium = value; }
        }
        /// <summary>
        /// The dark
        /// </summary>
        private static Color dark = ColorTranslator.FromHtml("#000000");

        /// <summary>
        /// Gets the dark.
        /// </summary>
        /// <value>The dark.</value>
        public static Color Dark
        {
            get { return dark; }
            internal set { dark = value; }
        }
      
    }
}
