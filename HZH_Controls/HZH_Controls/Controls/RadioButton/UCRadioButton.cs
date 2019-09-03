// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="UCRadioButton.cs">
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
    /// Class UCRadioButton.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DefaultEvent("CheckedChangeEvent")]
    public partial class UCRadioButton : UserControl
    {
        /// <summary>
        /// Occurs when [checked change event].
        /// </summary>
        [Description("选中改变事件"), Category("自定义")]
        public event EventHandler CheckedChangeEvent;

        /// <summary>
        /// The font
        /// </summary>
        private Font _Font = new Font("微软雅黑", 12);
        /// <summary>
        /// 获取或设置控件显示的文字的字体。
        /// </summary>
        /// <value>The font.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [Description("字体"), Category("自定义")]
        public new Font Font
        {
            get { return _Font; }
            set
            {
                _Font = value;
                label1.Font = value;
            }
        }

        /// <summary>
        /// The fore color
        /// </summary>
        private Color _ForeColor = Color.FromArgb(62, 62, 62);
        /// <summary>
        /// 获取或设置控件的前景色。
        /// </summary>
        /// <value>The color of the fore.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [Description("字体颜色"), Category("自定义")]
        public new Color ForeColor
        {
            get { return _ForeColor; }
            set
            {
                label1.ForeColor = value;
                _ForeColor = value;
            }
        }
        /// <summary>
        /// The text
        /// </summary>
        private string _Text = "单选按钮";
        /// <summary>
        /// Gets or sets the text value.
        /// </summary>
        /// <value>The text value.</value>
        [Description("文本"), Category("自定义")]
        public string TextValue
        {
            get { return _Text; }
            set
            {
                label1.Text = value;
                _Text = value;
            }
        }
        /// <summary>
        /// The checked
        /// </summary>
        private bool _checked = false;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UCRadioButton" /> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        [Description("是否选中"), Category("自定义")]
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                if (_checked != value)
                {
                    _checked = value;
                    if (base.Enabled)
                    {
                        if (_checked)
                        {
                            panel1.BackgroundImage = Properties.Resources.radioButton1;
                        }
                        else
                        {
                            panel1.BackgroundImage = Properties.Resources.radioButton0;
                        }
                    }
                    else
                    {
                        if (_checked)
                        {
                            panel1.BackgroundImage = Properties.Resources.radioButton10;
                        }
                        else
                        {
                            panel1.BackgroundImage = Properties.Resources.radioButton00;
                        }
                    }
                    SetCheck(value);

                    if (CheckedChangeEvent != null)
                    {
                        CheckedChangeEvent(this, null);
                    }
                }
            }
        }

        /// <summary>
        /// The group name
        /// </summary>
        private string _groupName;

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        /// <value>The name of the group.</value>
        [Description("分组名称"), Category("自定义")]
        public string GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示控件是否可以对用户交互作出响应。
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
                if (value)
                {
                    if (_checked)
                    {
                        panel1.BackgroundImage = Properties.Resources.radioButton1;
                    }
                    else
                    {
                        panel1.BackgroundImage = Properties.Resources.radioButton0;
                    }
                }
                else
                {
                    if (_checked)
                    {
                        panel1.BackgroundImage = Properties.Resources.radioButton10;
                    }
                    else
                    {
                        panel1.BackgroundImage = Properties.Resources.radioButton00;
                    }
                }
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UCRadioButton" /> class.
        /// </summary>
        public UCRadioButton()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the check.
        /// </summary>
        /// <param name="bln">if set to <c>true</c> [BLN].</param>
        private void SetCheck(bool bln)
        {
            if (!bln)
                return;
            if (this.Parent != null)
            {
                foreach (Control c in this.Parent.Controls)
                {
                    if (c is UCRadioButton && c != this)
                    {
                        UCRadioButton uc = (UCRadioButton)c;
                        if (_groupName == uc.GroupName && uc.Checked)
                        {
                            uc.Checked = false;
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the Radio control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void Radio_MouseDown(object sender, MouseEventArgs e)
        {
            this.Checked = true;
        }

        /// <summary>
        /// Handles the Load event of the UCRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void UCRadioButton_Load(object sender, EventArgs e)
        {
            if (this.Parent != null && this._checked)
            {
                foreach (Control c in this.Parent.Controls)
                {
                    if (c is UCRadioButton && c != this)
                    {
                        UCRadioButton uc = (UCRadioButton)c;
                        if (_groupName == uc.GroupName && uc.Checked)
                        {
                            Checked = false;
                            return;
                        }
                    }
                }
            }
        }
    }
}
