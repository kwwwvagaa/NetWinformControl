// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="TextInputType.cs">
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
using System.Linq;
using System.Text;

namespace HZH_Controls
{
    /// <summary>
    /// 功能描述:文本控件输入类型
    /// 作　　者:HZH
    /// 创建日期:2019-02-28 10:09:00
    /// </summary>
    public enum TextInputType
    {
        /// <summary>
        /// 不控制输入
        /// </summary>
        [Description("不控制输入")]
        NotControl = 1,
        /// <summary>
        /// 任意数字
        /// </summary>
        [Description("任意数字")]
        Number = 2,
        /// <summary>
        /// 非负数
        /// </summary>
        [Description("非负数")]
        UnsignNumber = 4,
        /// <summary>
        /// 正数
        /// </summary>
        [Description("正数")]
        PositiveNumber = 8,
        /// <summary>
        /// 整数
        /// </summary>
        [Description("整数")]
        Integer = 16,
        /// <summary>
        /// 非负整数
        /// </summary>
        [Description("非负整数")]
        PositiveInteger = 32,
        /// <summary>
        /// 正则验证
        /// </summary>
        [Description("正则验证")]
        Regex = 64
    }
}
