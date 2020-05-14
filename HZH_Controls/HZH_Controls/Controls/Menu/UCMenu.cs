// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-15-2019
//
// ***********************************************************************
// <copyright file="UCMenu.cs">
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
    /// Class UCMenu.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class UCMenu : UserControl
    {
        /// <summary>
        /// 选中项事件
        /// </summary>
        public event EventHandler SelectedItem;
        /// <summary>
        /// The m parent item type
        /// </summary>
        private Type m_parentItemType = typeof(UCMenuParentItem);
        /// <summary>
        /// 父类节点类型
        /// </summary>
        /// <value>The type of the parent item.</value>
        /// <exception cref="System.Exception">节点控件没有实现IMenuItem接口</exception>
        /// <exception cref="Exception">节点控件没有实现IMenuItem接口</exception>
        public Type ParentItemType
        {
            get { return m_parentItemType; }
            set
            {
                if (value == null)
                    return;
                if (!typeof(IMenuItem).IsAssignableFrom(value) || !value.IsSubclassOf(typeof(Control)))
                    throw new Exception("节点控件没有实现IMenuItem接口");
                m_parentItemType = value;

            }
        }

        /// <summary>
        /// The m children item type
        /// </summary>
        private Type m_childrenItemType = typeof(UCMenuChildrenItem);
        /// <summary>
        /// 子类节点类型
        /// </summary>
        /// <value>The type of the children item.</value>
        /// <exception cref="System.Exception">节点控件没有实现IMenuItem接口</exception>
        /// <exception cref="Exception">节点控件没有实现IMenuItem接口</exception>
        public Type ChildrenItemType
        {
            get { return m_childrenItemType; }
            set
            {
                if (value == null)
                    return;
                if (!typeof(IMenuItem).IsAssignableFrom(value) || !value.IsSubclassOf(typeof(Control)))
                    throw new Exception("节点控件没有实现IMenuItem接口");
                m_childrenItemType = value;
            }
        }

        /// <summary>
        /// The m parent item styles
        /// </summary>
        private Dictionary<string, object> m_parentItemStyles;
        /// <summary>
        /// 父类节点样式设置，key：属性名称，value：属性值
        /// </summary>
        /// <value>The parent item styles.</value>
        public Dictionary<string, object> ParentItemStyles
        {
            get { return m_parentItemStyles; }
            set { m_parentItemStyles = value; }
        }

        /// <summary>
        /// The m children item styles
        /// </summary>
        private Dictionary<string, object> m_childrenItemStyles;
        /// <summary>
        /// 子类节点样式设置，key：属性名称，value：属性值
        /// </summary>
        /// <value>The children item styles.</value>
        public Dictionary<string, object> ChildrenItemStyles
        {
            get { return m_childrenItemStyles; }
            set { m_childrenItemStyles = value; }
        }

        /// <summary>
        /// The m data source
        /// </summary>
        private List<MenuItemEntity> m_dataSource;
        /// <summary>
        /// 数据源
        /// </summary>
        /// <value>The data source.</value>
        public List<MenuItemEntity> DataSource
        {
            get { return m_dataSource; }
            set
            {
                m_dataSource = value;

                ReloadItems();
            }
        }
        /// <summary>
        /// The m is show first item
        /// </summary>
        private bool m_isShowFirstItem = true;
        /// <summary>
        /// 是否自动展开第一个节点
        /// </summary>
        /// <value><c>true</c> if this instance is show first item; otherwise, <c>false</c>.</value>
        public bool IsShowFirstItem
        {
            get { return m_isShowFirstItem; }
            set { m_isShowFirstItem = value; }
        }

        /// <summary>
        /// The m menu style
        /// </summary>
        private MenuStyle m_menuStyle = MenuStyle.Fill;
        /// <summary>
        /// 菜单样式
        /// </summary>
        /// <value>The menu style.</value>
        public MenuStyle MenuStyle
        {
            get { return m_menuStyle; }
            set { m_menuStyle = value; }
        }

        /// <summary>
        /// The m LST parent items
        /// </summary>
        private List<Control> m_lstParentItems = new List<Control>();

        /// <summary>
        /// The m select parent item
        /// </summary>
        private IMenuItem m_selectParentItem = null;
        /// <summary>
        /// The m select children item
        /// </summary>
        private IMenuItem m_selectChildrenItem = null;

        /// <summary>
        /// The m pan children
        /// </summary>
        private Panel m_panChildren = null;

        /// <summary>
        /// Reloads the items.
        /// </summary>
        private void ReloadItems()
        {
            try
            {
                ControlHelper.FreezeControl(this, true);
                this.Controls.Clear();
                m_lstParentItems.Clear();
                if (m_dataSource != null && m_dataSource.Count > 0)
                {
                    foreach (var parent in m_dataSource)
                    {
                        IMenuItem parentItem = (IMenuItem)Activator.CreateInstance(m_parentItemType);
                        parentItem.DataSource = parent;
                        if (m_parentItemStyles != null)
                            parentItem.SetStyle(m_parentItemStyles);
                        parentItem.SelectedItem += parentItem_SelectedItem;
                        Control c = parentItem as Control;
                        c.Dock = DockStyle.Top;
                        if (parent.Childrens.Count <= 0)
                        {
                            parentItem.SetSelectedStyle(null);
                        }
                        this.Controls.Add(c);
                        this.Controls.SetChildIndex(c, 0);
                        m_lstParentItems.Add(c);
                    }
                }
                m_panChildren = new Panel();
                if (m_menuStyle == HZH_Controls.Controls.MenuStyle.Fill)
                {
                    m_panChildren.Dock = DockStyle.Fill;
                    m_panChildren.Height = 0;
                }
                else
                {
                    m_panChildren.Dock = DockStyle.Top;
                    m_panChildren.Height = 0;
                }
                m_panChildren.AutoScroll = true;
                this.Controls.Add(m_panChildren);
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }

            if (m_isShowFirstItem && m_lstParentItems != null && m_lstParentItems.Count > 0)
            {
                parentItem_SelectedItem(m_lstParentItems[0], null);

            }
        }

        /// <summary>
        /// Handles the SelectedItem event of the parentItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void parentItem_SelectedItem(object sender, EventArgs e)
        {
            this.FindForm().ActiveControl = this;
            IMenuItem item = sender as IMenuItem;
            bool? blnNull = null;
            if (m_lstParentItems.Contains(sender as Control))
            {
                if (m_selectParentItem != item)
                {
                    if (m_selectParentItem != null)
                    {
                        m_selectParentItem.SetSelectedStyle((m_selectParentItem.DataSource == null || m_selectParentItem.DataSource.Childrens == null || m_selectParentItem.DataSource.Childrens.Count <= 0) ? blnNull : false);
                    }
                    m_selectParentItem = item;
                    m_selectParentItem.SetSelectedStyle((m_selectParentItem.DataSource == null || m_selectParentItem.DataSource.Childrens == null || m_selectParentItem.DataSource.Childrens.Count <= 0) ? blnNull : true);
                    SetChildrenControl(m_selectParentItem);
                }
                else
                {
                    m_selectParentItem.SetSelectedStyle((m_selectParentItem.DataSource == null || m_selectParentItem.DataSource.Childrens == null || m_selectParentItem.DataSource.Childrens.Count <= 0) ? blnNull : false);
                    m_selectParentItem = null;
                    SetChildrenControl(m_selectParentItem, false);
                }
            }
            else if (m_panChildren.Controls.Contains(sender as Control))
            {
                if (m_selectChildrenItem != item)
                {
                    if (m_selectChildrenItem != null)
                    {
                        m_selectChildrenItem.SetSelectedStyle((m_selectParentItem.DataSource == null || m_selectParentItem.DataSource.Childrens == null || m_selectParentItem.DataSource.Childrens.Count <= 0) ? blnNull : false);
                    }
                    m_selectChildrenItem = item;
                    m_selectChildrenItem.SetSelectedStyle((m_selectParentItem.DataSource == null || m_selectParentItem.DataSource.Childrens == null || m_selectParentItem.DataSource.Childrens.Count <= 0) ? blnNull : true);
                }
            }
            if (SelectedItem != null)
            {
                SelectedItem(sender, e);
            }
        }

        /// <summary>
        /// Sets the children control.
        /// </summary>
        /// <param name="menuitem">The menuitem.</param>
        /// <param name="blnChildren">if set to <c>true</c> [BLN children].</param>
        private void SetChildrenControl(IMenuItem menuitem, bool blnChildren = true)
        {
            try
            {
                ControlHelper.FreezeControl(this, true);
                if (m_menuStyle == HZH_Controls.Controls.MenuStyle.Fill)
                {
                    if (blnChildren)
                    {
                        Control cMenu = menuitem as Control;
                        int index = m_lstParentItems.IndexOf(cMenu);                       

                        for (int i = 0; i <= index; i++)
                        {
                            m_lstParentItems[i].Dock = DockStyle.Top;
                            this.Controls.SetChildIndex(m_lstParentItems[i], 0);
                        }
                        this.Controls.SetChildIndex(m_panChildren, 0);
                        

                        for (int i = index + 1; i < m_lstParentItems.Count; i++)
                        {
                            m_lstParentItems[i].Dock = DockStyle.Bottom;
                            this.Controls.SetChildIndex(m_lstParentItems[i], m_lstParentItems.Count);
                        }
                        m_panChildren.Controls.Clear();
                        int intItemHeigth = 0;
                        foreach (var item in menuitem.DataSource.Childrens)
                        {
                            IMenuItem parentItem = (IMenuItem)Activator.CreateInstance(m_childrenItemType);
                            parentItem.DataSource = item;
                            if (m_childrenItemStyles != null)
                                parentItem.SetStyle(m_childrenItemStyles);
                            parentItem.SelectedItem += parentItem_SelectedItem;
                            Control c = parentItem as Control;
                            if (intItemHeigth == 0)
                                intItemHeigth = c.Height;
                            c.Dock = DockStyle.Top;
                            m_panChildren.Controls.Add(c);
                            m_panChildren.Controls.SetChildIndex(c, 0);
                        }
                        //m_panChildren.MinimumSize = new Size(0, menuitem.DataSource.Childrens.Count * intItemHeigth);
                    }
                    else
                    {
                        m_panChildren.Controls.Clear();
                        foreach (var item in m_lstParentItems)
                        {
                            item.Dock = DockStyle.Top;
                            this.Controls.SetChildIndex(item, 0);
                        }
                    }
                }
                else
                {
                    if (blnChildren)
                    {
                        Control cMenu = menuitem as Control;
                        int index = m_lstParentItems.IndexOf(cMenu);
                        this.Controls.SetChildIndex(m_panChildren, m_lstParentItems.Count - index - 1);
                        m_panChildren.Controls.Clear();
                        int intItemHeigth = 0;
                        foreach (var item in menuitem.DataSource.Childrens)
                        {
                            IMenuItem parentItem = (IMenuItem)Activator.CreateInstance(m_childrenItemType);
                            parentItem.DataSource = item;
                            if (m_childrenItemStyles != null)
                                parentItem.SetStyle(m_childrenItemStyles);
                            parentItem.SelectedItem += parentItem_SelectedItem;
                            Control c = parentItem as Control;
                            if (intItemHeigth == 0)
                                intItemHeigth = c.Height;
                            c.Dock = DockStyle.Top;
                            m_panChildren.Controls.Add(c);
                            m_panChildren.Controls.SetChildIndex(c, 0);
                        }
                        m_panChildren.Height = menuitem.DataSource.Childrens.Count * intItemHeigth;
                    }
                    else
                    {
                        m_panChildren.Controls.Clear();
                        m_panChildren.Height = 0;
                    }
                }
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCMenu" /> class.
        /// </summary>
        public UCMenu()
        {
            InitializeComponent();
        }
    }

    /// <summary>
    /// Enum MenuStyle
    /// </summary>
    public enum MenuStyle
    {
        /// <summary>
        /// 平铺
        /// </summary>
        Fill = 1,
        /// <summary>
        /// 顶部对齐
        /// </summary>
        Top = 2,
    }

}
