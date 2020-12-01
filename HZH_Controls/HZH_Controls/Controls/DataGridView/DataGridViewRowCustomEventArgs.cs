// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-27-2019
//
// ***********************************************************************
// <copyright file="DataGridViewRowCustomEventArgs.cs">
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
    /// Class DataGridViewRowCustomEventArgs.
    /// Implements the <see cref="System.EventArgs" />
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class DataGridViewRowCustomEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        /// <value>The name of the event.</value>
        public string EventName { get; set; }

        public object Data { get; set; }

    }
}
