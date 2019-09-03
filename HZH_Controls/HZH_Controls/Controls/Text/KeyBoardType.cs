// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="KeyBoardType.cs">
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
    /// Enum KeyBoardType
    /// </summary>
    public enum KeyBoardType
    {
        /// <summary>
        /// The null
        /// </summary>
        Null = 1,
        /// <summary>
        /// The uc key border all en
        /// </summary>
        UCKeyBorderAll_EN = 2,
        /// <summary>
        /// The uc key border all number
        /// </summary>
        UCKeyBorderAll_Num = 4,
        /// <summary>
        /// The uc key border number
        /// </summary>
        UCKeyBorderNum = 8,
        /// <summary>
        /// The uc key border hand
        /// </summary>
        UCKeyBorderHand = 16
    }
}
