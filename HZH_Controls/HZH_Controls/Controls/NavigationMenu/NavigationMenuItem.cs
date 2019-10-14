// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-10-08
//
// ***********************************************************************
// <copyright file="NavigationMenuItem.cs">
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
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class NavigationMenuItem.
    /// </summary>
    public class NavigationMenuItem : NavigationMenuItemBase
    {
        /// <summary>
        /// The items
        /// </summary>
        private NavigationMenuItem[] items;
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [Description("子项列表")]
        public NavigationMenuItem[] Items
        {
            get { return items; }
            set
            {
                items = value;
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        item.ParentItem = this;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has split lint at top.
        /// </summary>
        /// <value><c>true</c> if this instance has split lint at top; otherwise, <c>false</c>.</value>
        [Description("是否在此项顶部显示一个分割线")]
        public bool HasSplitLintAtTop { get; set; }

        /// <summary>
        /// Gets the parent item.
        /// </summary>
        /// <value>The parent item.</value>
        [Description("父节点")]
        public NavigationMenuItem ParentItem { get; private set; }
    }


}
