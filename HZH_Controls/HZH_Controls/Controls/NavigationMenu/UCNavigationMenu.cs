// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-10-08
//
// ***********************************************************************
// <copyright file="UCNavigationMenu.cs">
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
    /// Class UCNavigationMenu.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DefaultEvent("ClickItemed")]
    public partial class UCNavigationMenu : UserControl
    {
        /// <summary>
        /// Occurs when [click itemed].
        /// </summary>
        [Description("点击节点事件"), Category("自定义")]

        public event EventHandler ClickItemed;
        /// <summary>
        /// The select item
        /// </summary>
        private NavigationMenuItem selectItem = null;

        /// <summary>
        /// Gets the select item.
        /// </summary>
        /// <value>The select item.</value>
        [Description("选中的节点"), Category("自定义")]
        public NavigationMenuItem SelectItem
        {
            get { return selectItem; }
            private set { selectItem = value; }
        }


        /// <summary>
        /// The items
        /// </summary>
        NavigationMenuItem[] items;

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [Description("节点列表"), Category("自定义")]
        public NavigationMenuItem[] Items
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
        Dictionary<NavigationMenuItem, FrmAnchor> m_lstAnchors = new Dictionary<NavigationMenuItem, FrmAnchor>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UCNavigationMenu"/> class.
        /// </summary>
        public UCNavigationMenu()
        {
            InitializeComponent();
            items = new NavigationMenuItem[0];
            if (ControlHelper.IsDesignMode())
            {
                items = new NavigationMenuItem[4];
                for (int i = 0; i < 4; i++)
                {
                    items[i] = new NavigationMenuItem()
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
                        var menu = (NavigationMenuItem)item;
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
                var menu = (NavigationMenuItem)lbl.Tag;
                if (menu.Items == null || menu.Items.Length <= 0)
                {
                    selectItem = menu;

                    while (m_lstAnchors.Count > 0)
                    {
                        try
                        {
                            foreach (var item in m_lstAnchors)
                            {
                                item.Value.Close();
                                m_lstAnchors.Remove(item.Key);
                            }
                        }
                        catch { }
                    }

                    if (ClickItemed != null)
                    {
                        ClickItemed(this, e);
                    }
                }
                else
                {
                    CloseList(menu);
                    if (m_lstAnchors.ContainsKey(menu))
                    {
                        if (m_lstAnchors[menu] != null && !m_lstAnchors[menu].IsDisposed)
                        {
                            m_lstAnchors[menu].Close();
                        }
                        m_lstAnchors.Remove(menu);
                    }
                    ShowMoreMenu(lbl);
                }
            }
        }

        /// <summary>
        /// Handles the MouseEnter event of the lbl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void lbl_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            ShowMoreMenu(lbl);
        }

        /// <summary>
        /// Checks the show.
        /// </summary>
        /// <param name="menu">The menu.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CheckShow(NavigationMenuItem menu)
        {
            //检查已经打开的节点
            if (m_lstAnchors.ContainsKey(menu))
            {
                CloseList(menu);
                return false;
            }
            if (HasInCacheChild(menu))
            {
                if (m_lstAnchors.ContainsKey(menu.ParentItem))
                {
                    CloseList(menu.ParentItem);
                    return true;
                }
                return false;
            }
            else
            {
                for (int i = 0; i < 1; )
                {
                    try
                    {
                        foreach (var item in m_lstAnchors)
                        {
                            if (m_lstAnchors[item.Key] != null && !m_lstAnchors[item.Key].IsDisposed)
                            {
                                m_lstAnchors[item.Key].Close();
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                    i++;
                }
                m_lstAnchors.Clear();
                return true;
            }
        }

        /// <summary>
        /// Determines whether [has in cache child] [the specified menu].
        /// </summary>
        /// <param name="menu">The menu.</param>
        /// <returns><c>true</c> if [has in cache child] [the specified menu]; otherwise, <c>false</c>.</returns>
        private bool HasInCacheChild(NavigationMenuItem menu)
        {
            foreach (var item in m_lstAnchors)
            {
                if (item.Key == menu)
                {
                    return true;
                }
                else
                {
                    if (item.Key.Items != null)
                    {
                        if (item.Key.Items.Contains(menu))
                            return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Closes the list.
        /// </summary>
        /// <param name="menu">The menu.</param>
        private void CloseList(NavigationMenuItem menu)
        {
            if (menu.Items != null)
            {
                foreach (var item in menu.Items)
                {
                    CloseList(item);
                    if (m_lstAnchors.ContainsKey(item))
                    {
                        if (m_lstAnchors[item] != null && !m_lstAnchors[item].IsDisposed)
                        {
                            m_lstAnchors[item].Close();
                            m_lstAnchors[item] = null;
                            m_lstAnchors.Remove(item);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Shows the more menu.
        /// </summary>
        /// <param name="lbl">The label.</param>
        private void ShowMoreMenu(Label lbl)
        {
            var menu = (NavigationMenuItem)lbl.Tag;
            if (CheckShow(menu))
            {
                if (menu.Items != null && menu.Items.Length > 0)
                {
                    Panel panel = new Panel();
                    panel.BackColor = Color.White;
                    panel.Paint += panel_Paint;
                    panel.Padding = new System.Windows.Forms.Padding(1);
                    Size size = GetItemsSize(menu.Items);
                    var height = size.Height * menu.Items.Length + 2;
                    height += menu.Items.Count(p => p.HasSplitLintAtTop);//分割线
                    if (size.Width < lbl.Width)
                        size.Width = lbl.Width;
                    panel.Size = new Size(size.Width, height);

                    foreach (var item in menu.Items)
                    {
                        if (item.HasSplitLintAtTop)
                        {
                            UCSplitLine_H line = new UCSplitLine_H();
                            line.Dock = DockStyle.Top;
                            panel.Controls.Add(line);
                            line.BringToFront();
                        }
                        Label _lbl = new Label();
                        _lbl.Font = Font;
                        _lbl.ForeColor = this.BackColor;
                        _lbl.AutoSize = false;
                        _lbl.TextAlign = ContentAlignment.MiddleCenter;
                        _lbl.Height = size.Height;
                        _lbl.Text = item.Text;
                        _lbl.Dock = DockStyle.Top;
                        _lbl.BringToFront();
                        _lbl.Paint += lbl_Paint;
                        _lbl.MouseEnter += lbl_MouseEnter;
                        _lbl.Tag = item;
                        _lbl.Click += lbl_Click;
                        _lbl.Size = new System.Drawing.Size(size.Width, size.Height);
                        panel.Controls.Add(_lbl);
                        _lbl.BringToFront();
                    }
                    Point point = Point.Empty;

                    if (menu.ParentItem != null)
                    {
                        Point p = lbl.Parent.PointToScreen(lbl.Location);
                        if (p.X + lbl.Width + panel.Width > Screen.PrimaryScreen.Bounds.Width)
                        {
                            point = new Point(-1 * panel.Width - 2, -1 * lbl.Height);
                        }
                        else
                        {
                            point = new Point(panel.Width + 2, -1 * lbl.Height);
                        }
                    }
                    m_lstAnchors[menu] = new FrmAnchor(lbl, panel, point);
                    m_lstAnchors[menu].FormClosing += UCNavigationMenu_FormClosing;
                    m_lstAnchors[menu].Show(this);
                    m_lstAnchors[menu].Size = new Size(size.Width, height);
                }
            }

        }

        /// <summary>
        /// Handles the FormClosing event of the UCNavigationMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        void UCNavigationMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmAnchor frm = sender as FrmAnchor;
            if (m_lstAnchors.ContainsValue(frm))
            {
                foreach (var item in m_lstAnchors)
                {
                    if (item.Value == frm)
                    {
                        m_lstAnchors.Remove(item.Key);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Paint event of the panel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        void panel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetGDIHigh();
            Rectangle rect = new Rectangle(0, 0, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            var path = rect.CreateRoundedRectanglePath(2);
            e.Graphics.DrawPath(new Pen(new SolidBrush(LineColors.Light)), path);
        }



        /// <summary>
        /// Gets the size of the items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Size.</returns>
        private Size GetItemsSize(NavigationMenuItem[] items)
        {
            Size size = Size.Empty;
            if (items != null && items.Length > 0)
            {
                using (var g = this.CreateGraphics())
                {
                    foreach (NavigationMenuItem item in items)
                    {
                        var s = g.MeasureString(item.Text, Font);
                        if (s.Width + 25 > size.Width)
                        {
                            size.Width = (int)s.Width + 25;
                        }
                        if (s.Height + 10 > size.Height)
                        {
                            size.Height = (int)s.Height + 10;
                        }
                    }
                }
            }
            return size;
        }


        /// <summary>
        /// Handles the Paint event of the lbl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        void lbl_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl.Tag != null)
            {
                var menu = (NavigationMenuItem)lbl.Tag;
                e.Graphics.SetGDIHigh();
                if (menu.ParentItem == null)//顶级节点支持图标和角标
                {
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
                if (menu.ParentItem != null && menu.Items != null && menu.Items.Length > 0)
                {
                    ControlHelper.PaintTriangle(e.Graphics, new SolidBrush(this.BackColor), new Point(lbl.Width - 11, (lbl.Height - 5) / 2), 5, GraphDirection.Rightward);
                }
            }
        }
    }
}
