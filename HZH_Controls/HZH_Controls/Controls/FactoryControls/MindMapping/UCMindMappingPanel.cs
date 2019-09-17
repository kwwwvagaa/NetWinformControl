// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-11
//
// ***********************************************************************
// <copyright file="UCMindMappingPanel.cs">
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
    /// Class UCMindMappingPanel.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DefaultEvent("ItemClicked")]
    public partial class UCMindMappingPanel : UserControl
    {

        /// <summary>
        /// The item context menu strip
        /// </summary>
        private ContextMenuStrip itemContextMenuStrip;

        /// <summary>
        /// Gets or sets the item context menu strip.
        /// </summary>
        /// <value>The item context menu strip.</value>
        [Description("节点关联的右键菜单"), Category("自定义")]
        public ContextMenuStrip ItemContextMenuStrip
        {
            get { return itemContextMenuStrip; }
            set
            {
                itemContextMenuStrip = value;
                this.ucMindMapping1.ItemContextMenuStrip = value;
            }
        }

        /// <summary>
        /// The item backcolor
        /// </summary>
        private Color itemBackcolor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the item backcolor.
        /// </summary>
        /// <value>The item backcolor.</value>
        [Description("节点背景色，优先级小于数据源中设置的背景色"), Category("自定义")]
        public Color ItemBackcolor
        {
            get { return itemBackcolor; }
            set
            {
                itemBackcolor = value;
                this.ucMindMapping1.ItemBackcolor = value;
            }
        }
        /// <summary>
        /// The data source
        /// </summary>
        private MindMappingItemEntity dataSource;

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        [Description("数据源"), Category("自定义")]
        public MindMappingItemEntity DataSource
        {
            get { return dataSource; }
            set
            {
                dataSource = value;
                this.ucMindMapping1.DataSource = value;
            }
        }
        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        [Description("数据源"), Category("自定义")]
        public event EventHandler ItemClicked;

        /// <summary>
        /// The line color
        /// </summary>
        private Color lineColor = Color.Black;

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        [Description("线条颜色"), Category("自定义")]
        public Color LineColor
        {
            get { return lineColor; }
            set
            {
                lineColor = value;
                this.ucMindMapping1.LineColor = value;
            }
        }


        /// <summary>
        /// Gets the select entity.
        /// </summary>
        /// <value>The select entity.</value>
        [Description("选中的数据源"), Category("自定义")]
        public MindMappingItemEntity SelectEntity
        {
            get { return ucMindMapping1.SelectEntity; }

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UCMindMappingPanel" /> class.
        /// </summary>
        public UCMindMappingPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            InitializeComponent();
            ucMindMapping1.ItemClicked += ucMindMapping1_ItemClicked;
        }

        /// <summary>
        /// Handles the ItemClicked event of the ucMindMapping1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void ucMindMapping1_ItemClicked(object sender, EventArgs e)
        {
            if (ItemClicked != null)
            {
                ItemClicked(sender, e);
            }
        }
    }
}
