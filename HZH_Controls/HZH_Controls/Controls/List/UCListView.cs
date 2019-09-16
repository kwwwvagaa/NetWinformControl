// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-22-2019
//
// ***********************************************************************
// <copyright file="UCListView.cs">
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
using System.Collections;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCListView.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DefaultEvent("SelectedItemEvent")]
    public partial class UCListView : UserControl
    {
        /// <summary>
        /// The m int cell width
        /// </summary>
        int m_intCellWidth = 130;//单元格宽度
        /// <summary>
        /// The m int cell height
        /// </summary>
        int m_intCellHeight = 120;//单元格高度

        /// <summary>
        /// The m item type
        /// </summary>
        private Type m_itemType = typeof(UCListViewItem);

        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>The type of the item.</value>
        /// <exception cref="System.Exception">单元格控件没有继承实现接口IListViewItem</exception>
        /// <exception cref="Exception">单元格控件没有继承实现接口IListViewItem</exception>
        [Description("单元格类型，如果无法满足您的需求，你可以自定义单元格控件，并实现接口IListViewItem"), Category("自定义")]
        public Type ItemType
        {
            get { return m_itemType; }
            set
            {
                if (!typeof(IListViewItem).IsAssignableFrom(value) || !value.IsSubclassOf(typeof(Control)))
                    throw new Exception("单元格控件没有继承实现接口IListViewItem");
                m_itemType = value;
            }
        }

        /// <summary>
        /// The m page
        /// </summary>
        private UCPagerControlBase m_page = null;
        /// <summary>
        /// 翻页控件
        /// </summary>
        /// <value>The page.</value>
        /// <exception cref="System.Exception">翻页控件没有继承UCPagerControlBase</exception>
        /// <exception cref="Exception">翻页控件没有继承UCPagerControlBase</exception>
        [Description("翻页控件，如果UCPagerControl不满足你的需求，请自定义翻页控件并继承UCPagerControlBase"), Category("自定义")]
        public UCPagerControlBase Page
        {
            get { return m_page; }
            set
            {
                m_page = value;
                if (value != null)
                {
                    if (!typeof(IPageControl).IsAssignableFrom(value.GetType()) || !value.GetType().IsSubclassOf(typeof(UCPagerControlBase)))
                        throw new Exception("翻页控件没有继承UCPagerControlBase");
                    this.panMain.AutoScroll = false;
                    panPage.Visible = true;
                    this.Controls.SetChildIndex(panMain, 0);
                    m_page.ShowSourceChanged += m_page_ShowSourceChanged;
                    m_page.Dock = DockStyle.Fill;
                    this.panPage.Controls.Clear();
                    this.panPage.Controls.Add(m_page);
                    GetCellCount();
                    this.DataSource = m_page.GetCurrentSource();
                }
                else
                {
                    this.panMain.AutoScroll = true;
                    m_page = null;
                    panPage.Visible = false;
                }
            }
        }
        
        /// <summary>
        /// The m data source
        /// </summary>
        private object m_dataSource = null;

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        /// <exception cref="System.Exception">数据源不是有效的数据类型，列表</exception>
        /// <exception cref="Exception">数据源不是有效的数据类型，列表</exception>
        [Description("数据源,如果使用翻页控件，请使用翻页控件的DataSource"), Category("自定义")]
        public object DataSource
        {
            get { return m_dataSource; }
            set
            {
                if (value == null)
                {
                    m_dataSource = value;
                    ReloadSource();
                    return;
                }
                if (!typeof(IList).IsAssignableFrom(value.GetType()))
                {
                    throw new Exception("数据源不是有效的数据类型，列表");
                }
                m_dataSource = value;
                ReloadSource();
            }
        }

        /// <summary>
        /// The m int cell count
        /// </summary>
        int m_intCellCount = 0;//单元格总数
        /// <summary>
        /// Gets the cell count.
        /// </summary>
        /// <value>The cell count.</value>
        [Description("单元格总数"), Category("自定义")]
        public int CellCount
        {
            get { return m_intCellCount; }
            private set
            {
                m_intCellCount = value;
                if (value > 0 && m_page != null)
                {
                    m_page.PageSize = m_intCellCount;
                    m_page.Reload();
                }
            }
        }

        /// <summary>
        /// The m selected source
        /// </summary>
        private List<object> m_selectedSource = new List<object>();

        /// <summary>
        /// Gets or sets the selected source.
        /// </summary>
        /// <value>The selected source.</value>
        [Description("选中的数据"), Category("自定义")]
        public List<object> SelectedSource
        {
            get { return m_selectedSource; }
            set
            {
                m_selectedSource = value;
                ReloadSource();
            }
        }

        /// <summary>
        /// The m is multiple
        /// </summary>
        private bool m_isMultiple = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is multiple.
        /// </summary>
        /// <value><c>true</c> if this instance is multiple; otherwise, <c>false</c>.</value>
        [Description("是否多选"), Category("自定义")]
        public bool IsMultiple
        {
            get { return m_isMultiple; }
            set { m_isMultiple = value; }
        }

        /// <summary>
        /// Occurs when [selected item event].
        /// </summary>
        [Description("选中项事件"), Category("自定义")]
        public event EventHandler SelectedItemEvent;
        /// <summary>
        /// Delegate ReloadGridStyleEventHandle
        /// </summary>
        /// <param name="intCellCount">The int cell count.</param>
        public delegate void ReloadGridStyleEventHandle(int intCellCount);
        /// <summary>
        /// 样式改变事件
        /// </summary>
        [Description("样式改变事件"), Category("自定义")]
        public event ReloadGridStyleEventHandle ReloadGridStyleEvent;
        /// <summary>
        /// Initializes a new instance of the <see cref="UCListView" /> class.
        /// </summary>
        public UCListView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ms the page show source changed.
        /// </summary>
        /// <param name="currentSource">The current source.</param>
        void m_page_ShowSourceChanged(object currentSource)
        {
            this.DataSource = currentSource;
        }
        #region 重新加载数据源
        /// <summary>
        /// 功能描述:重新加载数据源
        /// 作　　者:HZH
        /// 创建日期:2019-06-27 16:47:32
        /// 任务编号:POS
        /// </summary>
        public void ReloadSource()
        {
            try
            {
                if (DesignMode)
                    return;
                ControlHelper.FreezeControl(this, true);

                if (this.panMain.Controls.Count <= 0)
                {
                    ReloadGridStyle();
                }
                if (m_dataSource == null || ((IList)m_dataSource).Count <= 0)
                {
                    for (int i = this.panMain.Controls.Count - 1; i >= 0; i--)
                    {
                        this.panMain.Controls[i].Visible = false;
                    }

                    return;
                }
                int intCount = Math.Min(((IList)m_dataSource).Count, this.panMain.Controls.Count);

                for (int i = 0; i < intCount; i++)
                {
                    ((IListViewItem)this.panMain.Controls[i]).DataSource = ((IList)m_dataSource)[i];
                    if (m_selectedSource.Contains(((IList)m_dataSource)[i]))
                    {
                        ((IListViewItem)this.panMain.Controls[i]).SetSelected(true);
                    }
                    else
                    {
                        ((IListViewItem)this.panMain.Controls[i]).SetSelected(false);
                    }
                    this.panMain.Controls[i].Visible = true;
                }

                for (int i = this.panMain.Controls.Count - 1; i >= intCount; i--)
                {
                    if (this.panMain.Controls[i].Visible)
                        this.panMain.Controls[i].Visible = false;
                }

            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }
        #endregion

        #region 刷新表格
        /// <summary>
        /// 功能描述:刷新表格样式
        /// 作　　者:HZH
        /// 创建日期:2019-06-27 16:35:25
        /// 任务编号:POS
        /// </summary>
        public void ReloadGridStyle()
        {
            if (DesignMode)
                return;
            Form frmMain = this.FindForm();
            if (frmMain != null && !frmMain.IsDisposed && frmMain.Visible && this.Visible)
            {
                GetCellCount();
                try
                {
                    ControlHelper.FreezeControl(this, true);
                    if (this.panMain.Controls.Count < m_intCellCount)
                    {
                        int intControlsCount = this.panMain.Controls.Count;
                        for (int i = 0; i < m_intCellCount - intControlsCount; i++)
                        {
                            Control uc = (Control)Activator.CreateInstance(m_itemType);
                            uc.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);

                            (uc as IListViewItem).SelectedItemEvent += UCListView_SelectedItemEvent;
                            uc.Visible = false;
                            this.panMain.Controls.Add(uc);
                        }
                    }
                    else if (this.panMain.Controls.Count > m_intCellCount)
                    {
                        int intControlsCount = this.panMain.Controls.Count;
                        for (int i = intControlsCount - 1; i > m_intCellCount - 1; i--)
                        {
                            this.panMain.Controls.RemoveAt(i);
                        }
                    }
                    foreach (Control item in this.panMain.Controls)
                    {
                        item.Size = new Size(m_intCellWidth, m_intCellHeight);
                    }
                }
                finally
                {
                    ControlHelper.FreezeControl(this, false);
                }
                if (ReloadGridStyleEvent != null)
                {
                    ReloadGridStyleEvent(m_intCellCount);
                }
            }

        }

        /// <summary>
        /// Handles the SelectedItemEvent event of the UCListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void UCListView_SelectedItemEvent(object sender, EventArgs e)
        {
            var selectedItem = sender as IListViewItem;

            if (m_selectedSource.Contains(selectedItem.DataSource))
            {
                m_selectedSource.Remove(selectedItem.DataSource);
                selectedItem.SetSelected(false);
            }
            else
            {
                if (m_isMultiple)
                {
                    m_selectedSource.Add(selectedItem.DataSource);
                    selectedItem.SetSelected(true);
                }
                else
                {
                    if (m_selectedSource.Count > 0)
                    {
                        int intCount = Math.Min(((IList)m_dataSource).Count, this.panMain.Controls.Count);
                        for (int i = 0; i < intCount; i++)
                        {
                            var item = ((IListViewItem)this.panMain.Controls[i]);
                            if (m_selectedSource.Contains(item.DataSource))
                            {
                                item.SetSelected(false);
                                break;
                            }
                        }
                    }

                    m_selectedSource = new List<object>() { selectedItem.DataSource };
                    selectedItem.SetSelected(true);

                }
            }

            if (SelectedItemEvent != null)
            {
                SelectedItemEvent(sender, e);
            }
        }
        #endregion

        #region 获取cell总数
        /// <summary>
        /// 功能描述:获取cell总数
        /// 作　　者:HZH
        /// 创建日期:2019-06-27 16:28:58
        /// 任务编号:POS
        /// </summary>
        private void GetCellCount()
        {
            if (DesignMode)
                return;
            if (this.panMain.Width == 0)
                return;
            Control item = (Control)Activator.CreateInstance(m_itemType);


            int intXCount = (this.panMain.Width - 10) / (item.Width + 10);
            m_intCellWidth = item.Width + ((this.panMain.Width - 10) % (item.Width + 10)) / intXCount;

            int intYCount = (this.panMain.Height - 10) / (item.Height + 10);
            m_intCellHeight = item.Height + ((this.panMain.Height - 10) % (item.Height + 10)) / intYCount;
            int intCount = intXCount * intYCount;

            if (Page == null)
            {
                if (m_dataSource == null)
                {
                    intCount = 0;
                }
                else
                {
                    if (((IList)m_dataSource).Count > intCount)
                    {
                        intXCount = (this.panMain.Width - 10 - 20) / (item.Width + 10);
                        m_intCellWidth = item.Width + ((this.panMain.Width - 10 - 20) % (item.Width + 10)) / intXCount;
                    }
                    intCount = Math.Max(intCount, ((IList)m_dataSource).Count);
                }
            }

            CellCount = intCount;
        }
        #endregion

        /// <summary>
        /// Handles the Resize event of the panMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void panMain_Resize(object sender, EventArgs e)
        {
            ReloadGridStyle();
        }

        /// <summary>
        /// Handles the Load event of the UCListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void UCListView_Load(object sender, EventArgs e)
        {

        }
    }
}
