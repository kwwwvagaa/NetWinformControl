// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-27
//
// ***********************************************************************
// <copyright file="VerificationAttribute.cs">
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
    /// Class VerificationAttribute.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public class VerificationAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VerificationAttribute"/> class.
        /// </summary>
        /// <param name="strRegex">The string regex.</param>
        /// <param name="strErrorMsg">The string error MSG.</param>
        public VerificationAttribute(string strRegex = "", string strErrorMsg = "")
        {
            Regex = strRegex;
            ErrorMsg = strErrorMsg;
        }
        /// <summary>
        /// Gets or sets the regex.
        /// </summary>
        /// <value>The regex.</value>
        public string Regex { get; set; }
        /// <summary>
        /// Gets or sets the error MSG.
        /// </summary>
        /// <value>The error MSG.</value>
        public string ErrorMsg { get; set; }

    }
}
