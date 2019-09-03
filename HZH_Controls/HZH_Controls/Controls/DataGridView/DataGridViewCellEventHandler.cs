// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-09-2019
//
// ***********************************************************************
// <copyright file="DataGridViewCellEventHandler.cs">
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
using System.Runtime.InteropServices;
using System.Text;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Delegate DataGridViewEventHandler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="DataGridViewEventArgs" /> instance containing the event data.</param>
    [Serializable]
    [ComVisible(true)]
    public delegate void DataGridViewEventHandler(object sender, DataGridViewEventArgs e);

    /// <summary>
    /// Delegate DataGridViewRowCustomEventHandler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="DataGridViewRowCustomEventArgs" /> instance containing the event data.</param>
    [Serializable]
    [ComVisible(true)]
    public delegate void DataGridViewRowCustomEventHandler(object sender, DataGridViewRowCustomEventArgs e);
}
