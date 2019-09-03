// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-22-2019
//
// ***********************************************************************
// <copyright file="IListViewItem.cs">
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
    /// Interface IListViewItem
    /// </summary>
    public interface IListViewItem
    {
        /// <summary>
        /// 数据源
        /// </summary>
        /// <value>The data source.</value>
        object DataSource { get; set; }
        /// <summary>
        /// 选中项事件
        /// </summary>
        event EventHandler SelectedItemEvent;
        /// <summary>
        /// 选中处理，一般用以更改选中效果
        /// </summary>
        /// <param name="blnSelected">是否选中</param>
        void SetSelected(bool blnSelected);
    }
}
