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
    public partial class UCNavigationMenuOffice : UserControl
    {
        private int mainMenuHeight = 25;

        [Description("主菜单高度，大于20的值"), Category("自定义")]
        public int MainMenuHeight
        {
            get { return mainMenuHeight; }
            set
            {
                if (value < 20)
                    return;
                mainMenuHeight = value;
                this.panMenu.Height = value;
            }
        }
        private int expandHeight = 125;
        [Description("展开后高度"), Category("自定义")]
        public int ExpandHeight
        {
            get { return expandHeight; }
            set { expandHeight = value; }
        }
        private bool isExpand = true;
        [Description("是否展开"), Category("自定义")]
        public bool IsExpand
        {
            get { return isExpand; }
            set
            {
                isExpand = value;
                if (value)
                {
                    this.Height = expandHeight;
                    ResetChildControl();
                }
                else
                {
                    this.Height = this.panMenu.Height;
                    this.panChilds.Controls.Clear();
                }
            }
        }
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
                if (value != null && value.Length > 0)
                {
                    selectItem = value[0];
                    ResetChildControl();
                }
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
        public UCNavigationMenuOffice()
        {
            InitializeComponent();
            this.SizeChanged += UCNavigationMenuOffice_SizeChanged;
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

        void UCNavigationMenuOffice_SizeChanged(object sender, EventArgs e)
        {
            if (isExpand)
            {
                expandHeight = this.Height;
            }
        }

        public void ResetChildControl()
        {
            if (isExpand)
            {
                if (selectItem != null)
                {
                    try
                    {
                        ControlHelper.FreezeControl(this, true);
                        this.panChilds.Controls.Clear();
                        if (selectItem.ShowControl != null)
                        {
                            HZH_Controls.Controls.UCSplitLine_H split = new UCSplitLine_H();
                            split.BackColor = Color.FromArgb(50, 197, 197, 197);
                            split.Dock = DockStyle.Top;
                            this.panChilds.Controls.Add(split);
                            split.BringToFront();
                            this.panChilds.Controls.Add(selectItem.ShowControl);
                            selectItem.ShowControl.Dock = DockStyle.Fill;
                        }
                    }
                    finally
                    {
                        ControlHelper.FreezeControl(this, false);
                    }
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
                this.panMenu.Controls.Clear();
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
                        lbl.DoubleClick += lbl_DoubleClick;
                        if (menu.AnchorRight)
                        {
                            lbl.Dock = DockStyle.Right;
                        }
                        else
                        {
                            lbl.Dock = DockStyle.Left;
                        }
                        this.panMenu.Controls.Add(lbl);

                        lbl.BringToFront();
                    }
                }
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }

        void lbl_DoubleClick(object sender, EventArgs e)
        {
            IsExpand = !IsExpand;
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
                else
                {
                    if (IsExpand)
                    {
                        selectItem = menu;
                        ResetChildControl();
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
            if (!IsExpand)
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
                        m_lstAnchors[menu] = new FrmAnchor(panMenu, menu.ShowControl, isNotFocus: false);

                    }
                    m_lstAnchors[menu].BackColor = this.BackColor;
                    m_lstAnchors[menu].Show(this);
                    m_lstAnchors[menu].Size = new Size(this.panChilds.Width, expandHeight - mainMenuHeight);
                }
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
