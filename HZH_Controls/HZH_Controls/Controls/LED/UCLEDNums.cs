// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 09-02-2019
//
// ***********************************************************************
// <copyright file="UCLEDNums.cs">
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
    /// Class UCLEDNums.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class UCLEDNums : UserControl
    {
        /// <summary>
        /// The m value
        /// </summary>
        private string m_value;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Description("值"), Category("自定义")]
        public string Value
        {
            get { return m_value; }
            set
            {
                m_value = value;
                ReloadValue();
            }
        }

        /// <summary>
        /// The m line width
        /// </summary>
        private int m_lineWidth = 8;

        /// <summary>
        /// Gets or sets the width of the line.
        /// </summary>
        /// <value>The width of the line.</value>
        [Description("线宽度，为了更好的显示效果，请使用偶数"), Category("自定义")]
        public int LineWidth
        {
            get { return m_lineWidth; }
            set
            {
                m_lineWidth = value;
                foreach (UCLEDNum c in this.Controls)
                {
                    c.LineWidth = value;
                }
            }
        }

        /// <summary>
        /// 获取或设置控件的前景色。
        /// </summary>
        /// <value>The color of the fore.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [Description("颜色"), Category("自定义")]
        public override System.Drawing.Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                foreach (UCLEDNum c in this.Controls)
                {
                    c.ForeColor = value;
                }
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否将控件的元素对齐以支持使用从右向左的字体的区域设置。
        /// </summary>
        /// <value>The right to left.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
                ReloadValue();
            }
        }

        /// <summary>
        /// Reloads the value.
        /// </summary>
        private void ReloadValue()
        {
            try
            {
                ControlHelper.FreezeControl(this, true);
                this.Controls.Clear();
                foreach (var item in m_value)
                {
                    UCLEDNum uc = new UCLEDNum();
                    if (RightToLeft == System.Windows.Forms.RightToLeft.Yes)
                        uc.Dock = DockStyle.Right;
                    else
                        uc.Dock = DockStyle.Left;
                    uc.Value = item;
                    uc.ForeColor = ForeColor;
                    uc.LineWidth = m_lineWidth;
                    this.Controls.Add(uc);
                    if (RightToLeft == System.Windows.Forms.RightToLeft.Yes)
                        uc.SendToBack();
                    else
                        uc.BringToFront();
                }
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UCLEDNums" /> class.
        /// </summary>
        public UCLEDNums()
        {
            InitializeComponent();
            Value = "0.00";
        }
    }
}
