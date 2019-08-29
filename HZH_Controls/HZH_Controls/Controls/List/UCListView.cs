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
    [DefaultEvent("SelectedItemEvent")]
    public partial class UCListView : UserControl
    {
        int m_intCellWidth = 130;//单元格宽度
        int m_intCellHeight = 120;//单元格高度

        private Type m_itemType = typeof(UCListViewItem);

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

        private UCPagerControlBase m_page = null;
        /// <summary>
        /// 翻页控件
        /// </summary>
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



        private object m_dataSource = null;

        [Description("数据源,如果使用翻页控件，请使用翻页控件的DataSource"), Category("自定义")]
        public object DataSource
        {
            get { return m_dataSource; }
            set
            {
                if (value == null)
                    return;
                if (!typeof(IList).IsAssignableFrom(value.GetType()))
                {
                    throw new Exception("数据源不是有效的数据类型，列表");
                }
                m_dataSource = value;
                ReloadSource();
            }
        }

        int m_intCellCount = 0;//单元格总数
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

        private List<object> m_selectedSource = new List<object>();

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

        private bool m_isMultiple = true;

        [Description("是否多选"), Category("自定义")]
        public bool IsMultiple
        {
            get { return m_isMultiple; }
            set { m_isMultiple = value; }
        }

        [Description("选中项事件"), Category("自定义")]
        public event EventHandler SelectedItemEvent;
        public delegate void ReloadGridStyleEventHandle(int intCellCount);
        /// <summary>
        /// 样式改变事件
        /// </summary>
        [Description("样式改变事件"), Category("自定义")]
        public event ReloadGridStyleEventHandle ReloadGridStyleEvent;
        public UCListView()
        {
            InitializeComponent();
        }
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
            ControlHelper.FreezeControl(this, false);
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
                if (((IList)m_dataSource).Count > intCount)
                {
                    intXCount = (this.panMain.Width - 10 - 20) / (item.Width + 10);
                    m_intCellWidth = item.Width + ((this.panMain.Width - 10 - 20) % (item.Width + 10)) / intXCount;
                }
                intCount = Math.Max(intCount, ((IList)m_dataSource).Count);
            }

            CellCount = intCount;
        }
        #endregion

        private void panMain_Resize(object sender, EventArgs e)
        {
            ReloadGridStyle();
        }

        private void UCListView_Load(object sender, EventArgs e)
        {

        }
    }
}
