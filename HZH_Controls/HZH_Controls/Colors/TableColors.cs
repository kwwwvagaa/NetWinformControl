// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-30
//
// ***********************************************************************
// <copyright file="TableColors.cs">
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

namespace HZH_Controls
{
    /// <summary>
    /// Class TableColors.
    /// </summary>
    public class TableColors
    {
        /// <summary>
        /// The green
        /// </summary>
        private static Color green = ColorTranslator.FromHtml("#c2e7b0");

        /// <summary>
        /// Gets the green.
        /// </summary>
        /// <value>The green.</value>
        public static Color Green
        {
            get { return green; }
            internal set { green = value; }
        }
        /// <summary>
        /// The blue
        /// </summary>
        private static Color blue = ColorTranslator.FromHtml("#a3d0fd");

        /// <summary>
        /// Gets the blue.
        /// </summary>
        /// <value>The blue.</value>
        public static Color Blue
        {
            get { return blue; }
            internal set { blue = value; }
        }
        /// <summary>
        /// The red
        /// </summary>
        private static Color red = ColorTranslator.FromHtml("#fbc4c4");

        /// <summary>
        /// Gets the red.
        /// </summary>
        /// <value>The red.</value>
        public static Color Red
        {
            get { return red; }
            internal set { red = value; }
        }
        /// <summary>
        /// The yellow
        /// </summary>
        private static Color yellow = ColorTranslator.FromHtml("#f5dab1");

        /// <summary>
        /// Gets the yellow.
        /// </summary>
        /// <value>The yellow.</value>
        public static Color Yellow
        {
            get { return yellow; }
            internal set { yellow = value; }
        }
        /// <summary>
        /// The gray
        /// </summary>
        private static Color gray = ColorTranslator.FromHtml("#d3d4d6");

        /// <summary>
        /// Gets the gray.
        /// </summary>
        /// <value>The gray.</value>
        public static Color Gray
        {
            get { return gray; }
            internal set { gray = value; }
        }
    }
}
