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
    public class NavigationMenuItem
    {
        /// <summary>
        /// The icon
        /// </summary>
        private Image icon;
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        [Description("图标，仅顶级节点有效")]
        public Image Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        /// <summary>
        /// The text
        /// </summary>
        private string text;
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>

        [Description("文本")]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        /// <summary>
        /// The show tip
        /// </summary>
        private bool showTip;
        /// <summary>
        /// Gets or sets a value indicating whether [show tip].当TipText为空时只显示一个小圆点，否则显示TipText文字
        /// </summary>
        /// <value><c>true</c> if [show tip]; otherwise, <c>false</c>.</value>
        [Description("是否显示角标，仅顶级节点有效")]
        public bool ShowTip
        {
            get { return showTip; }
            set { showTip = value; }
        }

        /// <summary>
        /// The tip text
        /// </summary>
        private string tipText;
        /// <summary>
        /// Gets or sets the tip text
        /// </summary>
        /// <value>The tip text.</value>
        [Description("角标文字，仅顶级节点有效")]
        public string TipText
        {
            get { return tipText; }
            set { tipText = value; }
        }
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
        /// The anchor right
        /// </summary>
        private bool anchorRight;

        /// <summary>
        /// Gets or sets a value indicating whether [anchor right].
        /// </summary>
        /// <value><c>true</c> if [anchor right]; otherwise, <c>false</c>.</value>
        [Description("是否靠右对齐")]
        public bool AnchorRight
        {
            get { return anchorRight; }
            set { anchorRight = value; }
        }

        /// <summary>
        /// The item width
        /// </summary>
        private int itemWidth = 100;

        /// <summary>
        /// Gets or sets the width of the item.
        /// </summary>
        /// <value>The width of the item.</value>
        [Description("宽度")]
        public int ItemWidth
        {
            get { return itemWidth; }
            set { itemWidth = value; }
        }

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        [Description("数据源")]
        public object DataSource { get; set; }
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
