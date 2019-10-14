// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-10-11
//
// ***********************************************************************
// <copyright file="UCNavigationMenuExt.cs">
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
using HZH_Controls.Forms;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCNavigationMenuExt.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DefaultEvent("ClickItemed")]
    public partial class UCNavigationMenuExt : UserControl
    {
        /// <summary>
        /// Occurs when [click itemed].
        /// </summary>
        [Description("点击节点事件"), Category("自定义")]

        public event EventHandler ClickItemed;
        /// <summary>
        /// The select item
        /// </summary>
        private NavigationMenuItemExt selectItem = null;

        /// <summary>
        /// Gets the select item.
        /// </summary>
        /// <value>The select item.</value>
        [Description("选中的节点"), Category("自定义")]
        public NavigationMenuItemExt SelectItem
        {
            get { return selectItem; }
            private set { selectItem = value; }
        }

        /// <summary>
        /// The items
        /// </summary>
        NavigationMenuItemExt[] items;

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [Description("节点列表"), Category("自定义")]
        public NavigationMenuItemExt[] Items
        {
            get { return items; }
            set
            {
                items = value;
                ReloadMenu();
            }
        }
        /// <summary>
        /// The tip color
        /// </summary>
        private Color tipColor = Color.FromArgb(255, 87, 34);

        /// <summary>
        /// Gets or sets the color of the tip.
        /// </summary>
        /// <value>The color of the tip.</value>
        [Description("角标颜色"), Category("自定义")]
        public Color TipColor
        {
            get { return tipColor; }
            set { tipColor = value; }
        }

        /// <summary>
        /// 获取或设置控件的前景色。
        /// </summary>
        /// <value>The color of the fore.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public override System.Drawing.Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                foreach (Control c in this.Controls)
                {
                    c.ForeColor = value;
                }
            }
        }
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
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                foreach (Control c in this.Controls)
                {
                    c.Font = value;
                }
            }
        }

        /// <summary>
        /// The m LST anchors
        /// </summary>
        Dictionary<NavigationMenuItemExt, FrmAnchor> m_lstAnchors = new Dictionary<NavigationMenuItemExt, FrmAnchor>();
        /// <summary>
        /// Initializes a new instance of the <see cref="UCNavigationMenuExt"/> class.
        /// </summary>
        public UCNavigationMenuExt()
        {
            InitializeComponent();
            items = new NavigationMenuItemExt[0];
            if (ControlHelper.IsDesignMode())
            {
                items = new NavigationMenuItemExt[4];
                for (int i = 0; i < 4; i++)
                {
                    items[i] = new NavigationMenuItemExt()
                    {
                        Text = "菜单" + (i + 1),
                        AnchorRight = i >= 2
                    };
                }
            }
        }

        /// <summary>
        /// Reloads the menu.
        /// </summary>
        private void ReloadMenu()
        {
            try
            {
                ControlHelper.FreezeControl(this, true);
                this.Controls.Clear();
                if (items != null && items.Length > 0)
                {
                    foreach (var item in items)
                    {
                        var menu = (NavigationMenuItemExt)item;
                        Label lbl = new Label();
                        lbl.AutoSize = false;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                        lbl.Width = menu.ItemWidth;
                        lbl.Text = menu.Text;

                        lbl.Font = Font;
                        lbl.ForeColor = ForeColor;

                        lbl.Paint += lbl_Paint;
                        lbl.MouseEnter += lbl_MouseEnter;
                        lbl.Tag = menu;
                        lbl.Click += lbl_Click;
                        if (menu.AnchorRight)
                        {
                            lbl.Dock = DockStyle.Right;
                        }
                        else
                        {
                            lbl.Dock = DockStyle.Left;
                        }
                        this.Controls.Add(lbl);

                        lbl.BringToFront();
                    }


                }
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }

        /// <summary>
        /// Handles the Click event of the lbl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void lbl_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl.Tag != null)
            {
                var menu = (NavigationMenuItemExt)lbl.Tag;
                if (menu.ShowControl == null)
                {
                    selectItem = menu;

                    if (ClickItemed != null)
                    {
                        ClickItemed(this, e);
                    }
                }
            }
        }
        /// <summary>
        /// Handles the MouseEnter event of the lbl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void lbl_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            var menu = lbl.Tag as NavigationMenuItemExt;
            foreach (var item in m_lstAnchors)
            {
                m_lstAnchors[item.Key].Hide();
            }
            if (menu.ShowControl != null)
            {
                if (!m_lstAnchors.ContainsKey(menu))
                {
                    m_lstAnchors[menu] = new FrmAnchor(lbl, menu.ShowControl);
                }
                m_lstAnchors[menu].Show(this);
                m_lstAnchors[menu].Size = menu.ShowControl.Size;
            }
        }
        /// <summary>
        /// Handles the Paint event of the lbl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs" /> instance containing the event data.</param>
        void lbl_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl.Tag != null)
            {
                var menu = (NavigationMenuItemExt)lbl.Tag;
                e.Graphics.SetGDIHigh();

                if (menu.ShowTip)
                {
                    if (!string.IsNullOrEmpty(menu.TipText))
                    {
                        var rect = new Rectangle(lbl.Width - 25, lbl.Height / 2 - 10, 20, 20);
                        var path = rect.CreateRoundedRectanglePath(5);
                        e.Graphics.FillPath(new SolidBrush(tipColor), path);
                        e.Graphics.DrawString(menu.TipText, new Font("微软雅黑", 8f), new SolidBrush(Color.White), rect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        e.Graphics.FillEllipse(new SolidBrush(tipColor), new Rectangle(lbl.Width - 20, lbl.Height / 2 - 10, 10, 10));
                    }
                }
                if (menu.Icon != null)
                {
                    e.Graphics.DrawImage(menu.Icon, new Rectangle(1, (lbl.Height - 25) / 2, 25, 25), 0, 0, menu.Icon.Width, menu.Icon.Height, GraphicsUnit.Pixel);
                }
            }
        }
    }
}
