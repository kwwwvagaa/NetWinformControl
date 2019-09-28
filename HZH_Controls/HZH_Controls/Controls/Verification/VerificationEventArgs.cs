// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-27
//
// ***********************************************************************
// <copyright file="VerificationEventArgs.cs">
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
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class VerificationEventArgs.
    /// Implements the <see cref="System.EventArgs" />
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class VerificationEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the verification control.
        /// </summary>
        /// <value>The verification control.</value>
        public Control VerificationControl { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [verify success].
        /// </summary>
        /// <value><c>true</c> if [verify success]; otherwise, <c>false</c>.</value>
        public bool IsVerifySuccess { get; set; }
        /// <summary>
        /// Gets or sets the verification model.
        /// </summary>
        /// <value>The verification model.</value>
        public VerificationModel VerificationModel { get; set; }
        /// <summary>
        /// 是否已处理，如果为true，则不再使用默认验证提示功能
        /// </summary>
        /// <value><c>true</c> if this instance is processed; otherwise, <c>false</c>.</value>
        public bool IsProcessed { get; set; }
        /// <summary>
        /// Gets or sets 正则表达式
        /// </summary>
        /// <value>The custom regex.</value>
        public string Regex { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="VerificationEventArgs"/> is required.
        /// </summary>
        /// <value><c>true</c> if required; otherwise, <c>false</c>.</value>
        public bool Required { get; set; }

        /// <summary>
        /// Gets or sets the error MSG.
        /// </summary>
        /// <value>The error MSG.</value>
        public string ErrorMsg { get; set; }
    }
}
