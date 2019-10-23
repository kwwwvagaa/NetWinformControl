// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-30
//
// ***********************************************************************
// <copyright file="TextColors.cs">
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
    /// Class TextColor.
    /// </summary>
    public class TextColors
    {
        /// <summary>
        /// The more light
        /// </summary>
        private static Color _MoreLight = ColorTranslator.FromHtml("#c0c4cc");

        /// <summary>
        /// Gets the more light.
        /// </summary>
        /// <value>The more light.</value>
        public static Color MoreLight
        {
            get { return _MoreLight; }
            internal set { _MoreLight = value; }
        }
        /// <summary>
        /// The light
        /// </summary>
        private static Color _Light = ColorTranslator.FromHtml("#909399");

        /// <summary>
        /// Gets the light.
        /// </summary>
        /// <value>The light.</value>
        public static Color Light
        {
            get { return _Light; }
            internal set { _Light = value; }
        }
        /// <summary>
        /// The dark
        /// </summary>
        private static Color _Dark = ColorTranslator.FromHtml("#606266");

        /// <summary>
        /// Gets the dark.
        /// </summary>
        /// <value>The dark.</value>
        public static Color Dark
        {
            get { return _Dark; }
            internal set { _Dark = value; }
        }
        /// <summary>
        /// The more dark
        /// </summary>
        private static Color _MoreDark = ColorTranslator.FromHtml("#303133");

        /// <summary>
        /// Gets the more dark.
        /// </summary>
        /// <value>The more dark.</value>
        public static Color MoreDark
        {
            get { return _MoreDark; }
            internal set { _MoreDark = value; }
        }
    }
}
