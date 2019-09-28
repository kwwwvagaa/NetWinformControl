// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-27
//
// ***********************************************************************
// <copyright file="VerificationModel.cs">
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

namespace HZH_Controls.Controls
{
    /// <summary>
    /// 验证规则
    /// </summary>
    public enum VerificationModel
    {
        /// <summary>
        /// 无
        /// </summary>
        [Description("无"), VerificationAttribute()]
        None = 1,
        /// <summary>
        /// 任意字母数字下划线
        /// </summary>
        [Description("任意字母数字下划线"), VerificationAttribute(@"^[a-zA-Z_0-1]*$", "请输入任意字母数字下划线")]
        AnyChar = 2,
        /// <summary>
        /// 任意数字
        /// </summary>
        [Description("任意数字"), VerificationAttribute(@"^[\-\+]?\d+(\.\d+)?$", "请输入任意数字")]
        Number = 4,
        /// <summary>
        /// 非负数
        /// </summary>
        [Description("非负数"), VerificationAttribute(@"^(\+)?\d+(\.\d+)?$", "请输入非负数")]
        UnsignNumber = 8,
        /// <summary>
        /// 正数
        /// </summary>
        [Description("正数"), VerificationAttribute(@"(\+)?([1-9][0-9]*(\.\d{1,2})?)|(0\.\d{1,2})", "请输入正数")]
        PositiveNumber = 16,
        /// <summary>
        /// 整数
        /// </summary>
        [Description("整数"), VerificationAttribute(@"^[\+\-]?\d+$", "请输入整数")]
        Integer = 32,
        /// <summary>
        /// 非负整数
        /// </summary>
        [Description("非负整数"), VerificationAttribute(@"^(\+)?\d+$", "请输入非负整数")]
        UnsignIntegerNumber = 64,
        /// <summary>
        /// 正整数
        /// </summary>
        [Description("正整数"), VerificationAttribute(@"^[0-9]*[1-9][0-9]*$", "请输入正整数")]
        PositiveIntegerNumber = 128,
        /// <summary>
        /// 邮箱
        /// </summary>
        [Description("邮箱"), VerificationAttribute(@"^(([0-9a-zA-Z]+)|([0-9a-zA-Z]+[_.0-9a-zA-Z-]*[0-9a-zA-Z]+))@([a-zA-Z0-9-]+[.])+([a-zA-Z]{2}|net|NET|com|COM|gov|GOV|mil|MIL|org|ORG|edu|EDU|int|INT)$", "请输入正确的邮箱地址")]
        Email = 256,
        /// <summary>
        /// 手机
        /// </summary>
        [Description("手机"), VerificationAttribute(@"^(\+?86)?1\d{10}$", "请输入正确的手机号")]
        Phone = 512,
        /// <summary>
        /// IP
        /// </summary>
        [Description("IP"), VerificationAttribute(@"(?=(\b|\D))(((\d{1,2})|(1\d{1,2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{1,2})|(2[0-4]\d)|(25[0-5]))(?=(\b|\D))", "请输入正确的IP地址")]
        IP = 1024,
        /// <summary>
        /// Url
        /// </summary>
        [Description("Url"), VerificationAttribute(@"^[a-zA-z]+://(//w+(-//w+)*)(//.(//w+(-//w+)*))*(//?//S*)?$", "请输入正确的网址")]
        URL = 2048,
        /// <summary>
        /// 身份证号
        /// </summary>
        [Description("身份证号"), VerificationAttribute(@"^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$", "请输入正确的身份证号")]
        IDCardNo = 4096,
        /// <summary>
        /// 正则验证
        /// </summary>
        [Description("自定义正则表达式"), VerificationAttribute()]
        Custom = 8192,
    }
}
