// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-15-2019
//
// ***********************************************************************
// <copyright file="IMenuItem.cs">
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
    /// Interface IMenuItem
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// Occurs when [selected item].
        /// </summary>
        event EventHandler SelectedItem;
        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        MenuItemEntity DataSource { get; set; }
        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="styles">key:属性名称,value:属性值</param>
        void SetStyle(Dictionary<string, object> styles);
        /// <summary>
        /// 设置选中样式
        /// </summary>
        /// <param name="blnSelected">是否选中</param>
        void SetSelectedStyle(bool? blnSelected);
    }
}
