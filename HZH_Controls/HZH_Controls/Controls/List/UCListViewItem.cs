// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-22-2019
//
// ***********************************************************************
// <copyright file="UCListViewItem.cs">
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
    /// Class UCListViewItem.
    /// Implements the <see cref="HZH_Controls.Controls.UCControlBase" />
    /// Implements the <see cref="HZH_Controls.Controls.IListViewItem" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.UCControlBase" />
    /// <seealso cref="HZH_Controls.Controls.IListViewItem" />
    [ToolboxItem(false)]
    public partial class UCListViewItem : UCControlBase, IListViewItem
    {
        /// <summary>
        /// The m data source
        /// </summary>
        private object m_dataSource;
        /// <summary>
        /// 数据源
        /// </summary>
        /// <value>The data source.</value>
        public object DataSource
        {
            get
            {
                return m_dataSource;
            }
            set
            {
                m_dataSource = value;
                lblTitle.Text = value.ToString();
            }
        }

        /// <summary>
        /// 选中项事件
        /// </summary>
        public event EventHandler SelectedItemEvent;
        /// <summary>
        /// Initializes a new instance of the <see cref="UCListViewItem" /> class.
        /// </summary>
        public UCListViewItem()
        {
            InitializeComponent();
            lblTitle.MouseDown += lblTitle_MouseDown;
        }

        /// <summary>
        /// Handles the MouseDown event of the lblTitle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedItemEvent != null)
            {
                SelectedItemEvent(this, e);
            }
        }

        /// <summary>
        /// Sets the selected.
        /// </summary>
        /// <param name="blnSelected">if set to <c>true</c> [BLN selected].</param>
        public void SetSelected(bool blnSelected)
        {
            if (blnSelected)
                this.FillColor = Color.FromArgb(255, 247, 245);
            else
                this.FillColor = Color.White;
            this.Refresh();
        }
    }
}
