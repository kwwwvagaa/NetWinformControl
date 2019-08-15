// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCMenu.cs
// 创建日期：2019-08-15 16:02:22
// 功能描述：Menu
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
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
    public partial class UCMenu : UserControl
    {
        /// <summary>
        /// 选中项事件
        /// </summary>
        public event EventHandler SelectedItem;
        private Type m_parentItemType = typeof(UCMenuParentItem);
        /// <summary>
        /// 父类节点类型
        /// </summary>
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

        private Type m_childrenItemType = typeof(UCMenuChildrenItem);
        /// <summary>
        /// 子类节点类型
        /// </summary>
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

        private Dictionary<string, object> m_parentItemStyles;
        /// <summary>
        /// 父类节点样式设置，key：属性名称，value：属性值
        /// </summary>
        public Dictionary<string, object> ParentItemStyles
        {
            get { return m_parentItemStyles; }
            set { m_parentItemStyles = value; }
        }

        private Dictionary<string, object> m_childrenItemStyles;
        /// <summary>
        /// 子类节点样式设置，key：属性名称，value：属性值
        /// </summary>
        public Dictionary<string, object> ChildrenItemStyles
        {
            get { return m_childrenItemStyles; }
            set { m_childrenItemStyles = value; }
        }

        private List<MenuItemEntity> m_dataSource;
        /// <summary>
        /// 数据源
        /// </summary>
        public List<MenuItemEntity> DataSource
        {
            get { return m_dataSource; }
            set
            {
                m_dataSource = value;

                ReloadItems();
            }
        }
        private bool m_isShowFirstItem = true;
        /// <summary>
        /// 是否自动展开第一个节点
        /// </summary>
        public bool IsShowFirstItem
        {
            get { return m_isShowFirstItem; }
            set { m_isShowFirstItem = value; }
        }

        private MenuStyle m_menuStyle = MenuStyle.Fill;
        /// <summary>
        /// 菜单样式
        /// </summary>
        public MenuStyle MenuStyle
        {
            get { return m_menuStyle; }
            set { m_menuStyle = value; }
        }

        private List<Control> m_lstParentItems = new List<Control>();

        private IMenuItem m_selectParentItem = null;
        private IMenuItem m_selectChildrenItem = null;

        private Panel m_panChildren = null;

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

        void parentItem_SelectedItem(object sender, EventArgs e)
        {
            this.FindForm().ActiveControl = this;
            IMenuItem item = sender as IMenuItem;
            if (m_lstParentItems.Contains(sender as Control))
            {
                if (m_selectParentItem != item)
                {
                    if (m_selectParentItem != null)
                    {
                        m_selectParentItem.SetSelectedStyle(false);
                    }
                    m_selectParentItem = item;
                    m_selectParentItem.SetSelectedStyle(true);
                    SetChildrenControl(m_selectParentItem);
                }
                else
                {
                    m_selectParentItem.SetSelectedStyle(false);
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
                        m_selectChildrenItem.SetSelectedStyle(false);
                    }
                    m_selectChildrenItem = item;
                    m_selectChildrenItem.SetSelectedStyle(true);
                }
            }
            if (SelectedItem != null)
            {
                SelectedItem(sender, e);
            }
        }

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
                            this.Controls.SetChildIndex(m_lstParentItems[i], 1);
                        }
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
                            this.Controls.SetChildIndex(item, 1);
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

        public UCMenu()
        {
            InitializeComponent();
        }
    }

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
