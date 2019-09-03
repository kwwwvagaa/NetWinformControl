// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 09-02-2019
//
// ***********************************************************************
// <copyright file="UCLEDDataTime.cs">
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
    /// Class UCLEDDataTime.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class UCLEDDataTime : UserControl
    {
        /// <summary>
        /// The m value
        /// </summary>
        private DateTime m_value;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Description("值"), Category("自定义")]
        public DateTime Value
        {
            get { return m_value; }
            set
            {
                m_value = value;
                string str = value.ToString("yyyy-MM-dd HH:mm:ss");
                for (int i = 0; i < str.Length; i++)
                {
                    if (i == 10)
                        continue;
                    ((UCLEDNum)this.tableLayoutPanel1.Controls.Find("D" + (i + 1), false)[0]).Value = str[i];
                }
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
                foreach (UCLEDNum c in this.tableLayoutPanel1.Controls)
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
                foreach (UCLEDNum c in this.tableLayoutPanel1.Controls)
                {
                    c.ForeColor = value;
                }
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UCLEDDataTime" /> class.
        /// </summary>
        public UCLEDDataTime()
        {
            InitializeComponent();
            Value = DateTime.Now;
        }
    }
}
