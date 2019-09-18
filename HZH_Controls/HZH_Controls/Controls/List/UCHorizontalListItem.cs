// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="UCHorizontalListItem.cs">
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
    /// Class UCHorizontalListItem.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public partial class UCHorizontalListItem : UserControl
    {
        /// <summary>
        /// Occurs when [selected item].
        /// </summary>
        public event EventHandler SelectedItem;
        /// <summary>
        /// The data source
        /// </summary>
        private KeyValuePair<string, string> _DataSource = new KeyValuePair<string, string>();
        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        public KeyValuePair<string, string> DataSource
        {
            get { return _DataSource; }
            set
            {
                _DataSource = value;
                var g = lblTitle.CreateGraphics();
                int intWidth = ControlHelper.GetStringWidth(value.Value, g, lblTitle.Font);
                g.Dispose();
                if (intWidth < 50)
                    intWidth = 50;
                this.Width = intWidth + 20;
                lblTitle.Text = value.Value;
                SetSelect(false);
            }
        }

        private Color selectedColor = Color.FromArgb(255, 77, 59);

        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UCHorizontalListItem" /> class.
        /// </summary>
        public UCHorizontalListItem()
        {
            InitializeComponent();
            this.Dock = DockStyle.Right;
            this.MouseDown += Item_MouseDown;
            this.lblTitle.MouseDown += Item_MouseDown;
            this.ucSplitLine_H1.MouseDown += Item_MouseDown;
        }

        /// <summary>
        /// Handles the MouseDown event of the Item control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        void Item_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null)
                SelectedItem(this, e);
        }

        /// <summary>
        /// Sets the select.
        /// </summary>
        /// <param name="bln">if set to <c>true</c> [BLN].</param>
        public void SetSelect(bool bln)
        {
            if (bln)
            {
                lblTitle.ForeColor = selectedColor;
                ucSplitLine_H1.BackColor = selectedColor;
                ucSplitLine_H1.Visible = true;
                this.lblTitle.Padding = new Padding(0, 0, 0, 5);
            }
            else
            {
                lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
                ucSplitLine_H1.Visible = false;
                this.lblTitle.Padding = new Padding(0, 0, 0, 0);
            }
        }
    }
}
