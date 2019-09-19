// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="UCKeyBorderAll.cs">
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
    /// Class UCKeyBorderAll.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DefaultEvent("KeyDown")]
    public partial class UCKeyBorderAll : UserControl
    {
        /// <summary>
        /// The character type
        /// </summary>
        private KeyBorderCharType _charType = KeyBorderCharType.CHAR;

        /// <summary>
        /// Gets or sets the type of the character.
        /// </summary>
        /// <value>The type of the character.</value>
        [Description("默认显示样式"), Category("自定义")]
        public KeyBorderCharType CharType
        {
            get { return _charType; }
            set
            {
                _charType = value;
                if (value == KeyBorderCharType.CHAR)
                {
                    if (label37.Text.ToLower() == "abc.")
                    {
                        CharOrNum();
                    }
                }
                else
                {
                    if (label37.Text.ToLower() == "?123")
                    {
                        CharOrNum();
                    }
                }
            }
        }
        /// <summary>
        /// Occurs when [key click].
        /// </summary>
        [Description("按键点击事件"), Category("自定义")]
        public event EventHandler KeyClick;
        /// <summary>
        /// Occurs when [enter click].
        /// </summary>
        [Description("回车点击事件"), Category("自定义")]
        public event EventHandler EnterClick;
        /// <summary>
        /// Occurs when [backspace clike].
        /// </summary>
        [Description("删除点击事件"), Category("自定义")]
        public event EventHandler BackspaceClike;
        /// <summary>
        /// Occurs when [retract clike].
        /// </summary>
        [Description("收起点击事件"), Category("自定义")]
        public event EventHandler RetractClike;
        /// <summary>
        /// Initializes a new instance of the <see cref="UCKeyBorderAll" /> class.
        /// </summary>
        public UCKeyBorderAll()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the MouseDown event of the KeyDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void KeyDown_MouseDown(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            if (string.IsNullOrEmpty(lbl.Text))
            {
                return;
            }
            if (lbl.Text == "大写")
            {
                ToUper(true);
                lbl.Text = "小写";
            }
            else if (lbl.Text == "小写")
            {
                ToUper(false);
                lbl.Text = "大写";
            }
            else if (lbl.Text == "?123" || lbl.Text == "abc.")
            {
                CharOrNum();
            }
            else if (lbl.Text == "空格")
            {
                SendKeys.Send(" ");
            }
            else if (lbl.Text == "删除")
            {
                SendKeys.Send("{BACKSPACE}");
                if (BackspaceClike != null)
                    BackspaceClike(sender, e);
            }
            else if (lbl.Text == "回车")
            {
                SendKeys.Send("{ENTER}");
                if (EnterClick != null)
                    EnterClick(sender, e);
            }
            else if (lbl.Text == "收起")
            {
                if (RetractClike != null)
                    RetractClike(sender, e);
            }
            else
            {
                string Str = "{"+ lbl.Text + "}";
                SendKeys.Send(lbl.Text);
            }
            if (KeyClick != null)
                KeyClick(sender, e);
        }

        /// <summary>
        /// Converts to uper.
        /// </summary>
        /// <param name="bln">if set to <c>true</c> [BLN].</param>
        private void ToUper(bool bln)
        {
            foreach (Control item in this.tableLayoutPanel2.Controls)
            {
                if (item is Panel)
                {
                    foreach (Control pc in item.Controls)
                    {
                        if (pc is Label)
                        {
                            if (pc.Text == "abc.")
                                break;
                            if (bln)
                            {
                                pc.Text = pc.Text.ToUpper();
                            }
                            else
                            {
                                pc.Text = pc.Text.ToLower();
                            }
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Characters the or number.
        /// </summary>
        private void CharOrNum()
        {
            foreach (Control item in this.tableLayoutPanel2.Controls)
            {
                if (item is Panel)
                {
                    foreach (Control pc in item.Controls)
                    {
                        if (pc is Label)
                        {
                            string strTag = pc.Text;
                            pc.Text = pc.Tag.ToString();
                            pc.Tag = strTag;
                            break;
                        }
                    }
                }
            }
        }
    }
    /// <summary>
    /// Enum KeyBorderCharType
    /// </summary>
    public enum KeyBorderCharType
    {
        /// <summary>
        /// The character
        /// </summary>
        CHAR = 1,
        /// <summary>
        /// The number
        /// </summary>
        NUMBER = 2
    }
}
