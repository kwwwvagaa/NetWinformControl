// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="UCBtnFillet.cs">
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
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCBtnFillet.
    /// Implements the <see cref="HZH_Controls.Controls.UCControlBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.UCControlBase" />
    [DefaultEvent("BtnClick")]
    public partial class UCBtnFillet : UCControlBase
    {
        /// <summary>
        /// 按钮点击事件
        /// </summary>
        [Description("按钮点击事件"), Category("自定义")]
        public event EventHandler BtnClick;
        /// <summary>
        /// 按钮图片
        /// </summary>
        /// <value>The BTN image.</value>
        [Description("按钮图片"), Category("自定义")]
        public Image BtnImage
        {
            get
            {
                return lbl.Image;
            }
            set
            {
                lbl.Image = value;
            }
        }
        /// <summary>
        /// 按钮文字
        /// </summary>
        /// <value>The BTN text.</value>
        [Description("按钮文字"), Category("自定义")]
        public string BtnText
        {
            get { return lbl.Text; }
            set
            {
                lbl.Text = value;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UCBtnFillet" /> class.
        /// </summary>
        public UCBtnFillet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the MouseDown event of the lbl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void lbl_MouseDown(object sender, MouseEventArgs e)
        {
            if (BtnClick != null)
                BtnClick(this, e);
        }
    }
}
