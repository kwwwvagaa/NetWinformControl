// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCDataGridView.cs
// 创建日期：2019-08-15 15:59:25
// 功能描述：DataGridView
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
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
    public partial class UCDataGridView : UserControl
    {
        #region 属性
        private int m_headPadingLeft = 0;

        [Description("标题左侧间距"), Category("自定义")]
        public int HeadPadingLeft
        {
            get { return m_headPadingLeft; }
            set
            {
                m_headPadingLeft = value;
                this.panHeadLeft.Width = m_headPadingLeft;
            }
        }

        private Font m_headFont = new Font("微软雅黑", 12F);
        /// <summary>
        /// 标题字体
        /// </summary>
        [Description("标题字体"), Category("自定义")]
        public Font HeadFont
        {
            get { return m_headFont; }
            set { m_headFont = value; }
        }
        private Color m_headTextColor = Color.Black;
        /// <summary>
        /// 标题字体颜色
        /// </summary>
        [Description("标题文字颜色"), Category("自定义")]
        public Color HeadTextColor
        {
            get { return m_headTextColor; }
            set { m_headTextColor = value; }
        }

        private bool m_isShowHead = true;
        /// <summary>
        /// 是否显示标题
        /// </summary>
        [Description("是否显示标题"), Category("自定义")]
        public bool IsShowHead
        {
            get { return m_isShowHead; }
            set
            {
                m_isShowHead = value;
                panHead.Visible = value;
                if (m_page != null)
                {
                    ResetShowCount();
                    m_page.PageSize = m_showCount;
                }
            }
        }
        private int m_headHeight = 40;
        /// <summary>
        /// 标题高度
        /// </summary>
        [Description("标题高度"), Category("自定义")]
        public int HeadHeight
        {
            get { return m_headHeight; }
            set
            {
                m_headHeight = value;
                panHead.Height = value;
            }
        }

        private bool m_isShowCheckBox = false;
        /// <summary>
        /// 是否显示复选框
        /// </summary>
        [Description("是否显示选择框"), Category("自定义")]
        public bool IsShowCheckBox
        {
            get { return m_isShowCheckBox; }
            set
            {
                if (value != m_isShowCheckBox)
                {
                    m_isShowCheckBox = value;
                    LoadColumns();
                }
            }
        }

        private int m_rowHeight = 40;
        /// <summary>
        /// 行高
        /// </summary>
        [Description("数据行高"), Category("自定义")]
        public int RowHeight
        {
            get { return m_rowHeight; }
            set { m_rowHeight = value; }
        }

        private int m_showCount = 0;
        /// <summary>
        /// 
        /// </summary>
        [Description("可显示个数"), Category("自定义")]
        public int ShowCount
        {
            get { return m_showCount; }
            private set
            {
                m_showCount = value;
                if (m_page != null)
                {
                    m_page.PageSize = value;
                }
            }
        }

        private List<DataGridViewColumnEntity> m_columns = null;
        /// <summary>
        /// 列
        /// </summary>
        [Description("列"), Category("自定义")]
        public List<DataGridViewColumnEntity> Columns
        {
            get { return m_columns; }
            set
            {
                m_columns = value;
                LoadColumns();
            }
        }

        private object m_dataSource = null;
        /// <summary>
        /// 数据源,支持列表或table，如果使用翻页控件，请使用翻页控件的DataSource
        /// </summary>
        [Description("数据源,支持列表或table，如果使用翻页控件，请使用翻页控件的DataSource"), Category("自定义")]
        public object DataSource
        {
            get { return m_dataSource; }
            set
            {
                if (value != null)
                {
                    if (!(m_dataSource is DataTable) && (!typeof(IList).IsAssignableFrom(value.GetType())))
                    {
                        throw new Exception("数据源不是有效的数据类型，请使用Datatable或列表");
                    }
                }
                m_dataSource = value;
                if (m_columns != null && m_columns.Count > 0)
                {
                    ReloadSource();
                }
            }
        }

        public List<IDataGridViewRow> Rows { get; private set; }

        private Type m_rowType = typeof(UCDataGridViewRow);
        /// <summary>
        /// 行元素类型，默认UCDataGridViewItem
        /// </summary>
        [Description("行控件类型，默认UCDataGridViewRow，如果不满足请自定义行控件实现接口IDataGridViewRow"), Category("自定义")]
        public Type RowType
        {
            get { return m_rowType; }
            set
            {
                if (value == null)
                    return;
                if (!typeof(IDataGridViewRow).IsAssignableFrom(value) || !value.IsSubclassOf(typeof(Control)))
                    throw new Exception("行控件没有实现IDataGridViewRow接口");
                m_rowType = value;
                ResetShowCount();
                if (m_columns != null && m_columns.Count > 0)
                    ReloadSource();
            }
        }
        IDataGridViewRow m_selectRow = null;
        /// <summary>
        /// 选中的节点
        /// </summary>
        [Description("选中行"), Category("自定义")]
        public IDataGridViewRow SelectRow
        {
            get { return m_selectRow; }
            private set { m_selectRow = value; }
        }


        /// <summary>
        /// 选中的行，如果显示CheckBox，则以CheckBox选中为准
        /// </summary>
        [Description("选中的行，如果显示CheckBox，则以CheckBox选中为准"), Category("自定义")]
        public List<IDataGridViewRow> SelectRows
        {
            get
            {
                return GetSelectRows();
            }
        }

        private List<IDataGridViewRow> GetSelectRows()
        {
            List<IDataGridViewRow> lst = new List<IDataGridViewRow>();
            if (m_isShowCheckBox)
            {
                if (Rows != null && Rows.Count > 0)
                    lst.AddRange(Rows.FindAll(p => p.IsChecked));
            }
            else
            {
                if (m_selectRow != null)
                    lst.AddRange(new List<IDataGridViewRow>() { m_selectRow });
            }
            if (Rows != null && Rows.Count > 0)
            {
                foreach (var row in Rows)
                {
                    Control c = row as Control;
                    UCDataGridView grid = FindChildGrid(c);
                    lst.AddRange(grid.SelectRows);
                }
            }
            return lst;
        }

        private UCDataGridView FindChildGrid(Control c)
        {
            foreach (Control item in c.Controls)
            {
                if (item is UCDataGridView)
                    return item as UCDataGridView;
                else if (item.Controls.Count > 0)
                {
                    var grid = FindChildGrid(item);
                    if (grid != null)
                        return grid;
                }
            }
            return null;
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
                    panPage.Visible = value != null;
                    m_page.ShowSourceChanged += page_ShowSourceChanged;
                    m_page.Dock = DockStyle.Fill;
                    //this.panPage.Height = value.Height;
                    this.panPage.Controls.Clear();
                    this.panPage.Controls.Add(m_page);
                    ResetShowCount();
                    m_page.PageSize = ShowCount;
                    this.DataSource = m_page.GetCurrentSource();
                }
                else
                {
                    m_page = null;
                }
            }
        }

        private bool m_isAutoHeight = false;
        /// <summary>
        /// 自动适应最大高度(当为true时，需要手动计算高度，请慎用)
        /// </summary>
        [Browsable(false)]
        public bool IsAutoHeight
        {
            get { return m_isAutoHeight; }
            set
            {
                m_isAutoHeight = value;
                this.AutoScroll = value;
            }
        }

        void page_ShowSourceChanged(object currentSource)
        {
            this.DataSource = currentSource;
        }

        #region 事件
        [Description("选中标题选择框事件"), Category("自定义")]
        public EventHandler HeadCheckBoxChangeEvent;
        [Description("标题点击事件"), Category("自定义")]
        public EventHandler HeadColumnClickEvent;
        [Description("项点击事件"), Category("自定义")]
        public event DataGridViewEventHandler ItemClick;
        [Description("数据源改变事件"), Category("自定义")]
        public event DataGridViewEventHandler SourceChanged;
        [Description("预留的自定义的事件，比如你需要在行上放置删改等按钮时，可以通过此事件传递出来"), Category("自定义")]
        public event DataGridViewRowCustomEventHandler RowCustomEvent;
        #endregion
        #endregion

        public UCDataGridView()
        {
            InitializeComponent();
        }

        #region 私有方法
        #region 加载column
        /// <summary>
        /// 功能描述:加载column
        /// 作　　者:HZH
        /// 创建日期:2019-08-08 17:51:50
        /// 任务编号:POS
        /// </summary>
        private void LoadColumns()
        {
            try
            {
                if (DesignMode)
                { return; }

                ControlHelper.FreezeControl(this.panHead, true);
                this.panColumns.Controls.Clear();
                this.panColumns.ColumnStyles.Clear();

                if (m_columns != null && m_columns.Count() > 0)
                {
                    int intColumnsCount = m_columns.Count();
                    if (m_isShowCheckBox)
                    {
                        intColumnsCount++;
                    }
                    this.panColumns.ColumnCount = intColumnsCount;
                    for (int i = 0; i < intColumnsCount; i++)
                    {
                        Control c = null;
                        if (i == 0 && m_isShowCheckBox)
                        {
                            this.panColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Absolute, 30F));

                            UCCheckBox box = new UCCheckBox();
                            box.TextValue = "";
                            box.Size = new Size(30, 30);
                            box.CheckedChangeEvent += (a, b) =>
                            {
                                Rows.ForEach(p => p.IsChecked = box.Checked);
                                if (HeadCheckBoxChangeEvent != null)
                                {
                                    HeadCheckBoxChangeEvent(a, b);
                                }
                            };
                            c = box;
                        }
                        else
                        {
                            var item = m_columns[i - (m_isShowCheckBox ? 1 : 0)];
                            this.panColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(item.WidthType, item.Width));
                            Label lbl = new Label();
                            lbl.Name = "dgvColumns_" + i;
                            lbl.Text = item.HeadText;
                            lbl.Font = m_headFont;
                            lbl.ForeColor = m_headTextColor;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.AutoSize = false;
                            lbl.Dock = DockStyle.Fill;
                            lbl.MouseDown += (a, b) =>
                            {
                                if (HeadColumnClickEvent != null)
                                {
                                    HeadColumnClickEvent(a, b);
                                }
                            };
                            c = lbl;
                        }
                        this.panColumns.Controls.Add(c, i, 0);
                    }

                }
            }
            finally
            {
                ControlHelper.FreezeControl(this.panHead, false);
            }
        }
        #endregion

        /// <summary>
        /// 功能描述:获取显示个数
        /// 作　　者:HZH
        /// 创建日期:2019-03-05 10:02:58
        /// 任务编号:POS
        /// </summary>
        /// <returns>返回值</returns>
        private void ResetShowCount()
        {
            if (DesignMode)
            { return; }
            if (this.Height <= 0)
                return;
            ShowCount = this.panRow.Height / (m_rowHeight);
            int intCha = this.panRow.Height % (m_rowHeight);
            m_rowHeight += intCha / ShowCount;
        }
        #endregion

        #region 公共函数
        /// <summary>
        /// 刷新数据
        /// </summary>
        public void ReloadSource()
        {
            if (DesignMode)
            { return; }
            try
            {


                ControlHelper.FreezeControl(this.panRow, true);
                this.panRow.Controls.Clear();
                Rows = new List<IDataGridViewRow>();
                if (m_columns == null || m_columns.Count <= 0)
                    return;
                if (m_dataSource != null)
                {
                    int intIndex = 0;
                    Control lastItem = null;

                    int intSourceCount = 0;
                    if (m_dataSource is DataTable)
                    {
                        intSourceCount = (m_dataSource as DataTable).Rows.Count;
                    }
                    else if (typeof(IList).IsAssignableFrom(m_dataSource.GetType()))
                    {
                        intSourceCount = (m_dataSource as IList).Count;
                    }

                    foreach (Control item in this.panRow.Controls)
                    {
                        if (intIndex >= intSourceCount)
                        {
                            item.Visible = false;
                        }
                        else
                        {
                            var row = (item as IDataGridViewRow);
                            row.IsShowCheckBox = m_isShowCheckBox;
                            if (m_dataSource is DataTable)
                            {
                                row.DataSource = (m_dataSource as DataTable).Rows[intIndex];
                            }
                            else
                            {
                                row.DataSource = (m_dataSource as IList)[intIndex];
                            }
                            row.BindingCellData();
                            if (row.RowHeight != m_rowHeight)
                                row.RowHeight = m_rowHeight;
                            item.Visible = true;
                            item.BringToFront();
                            if (lastItem == null)
                                lastItem = item;
                            Rows.Add(row);
                        }
                        intIndex++;
                    }

                    if (intIndex < intSourceCount)
                    {
                        for (int i = intIndex; i < intSourceCount; i++)
                        {
                            IDataGridViewRow row = (IDataGridViewRow)Activator.CreateInstance(m_rowType);
                            if (m_dataSource is DataTable)
                            {
                                row.DataSource = (m_dataSource as DataTable).Rows[i];
                            }
                            else
                            {
                                row.DataSource = (m_dataSource as IList)[i];
                            }
                            row.Columns = m_columns;
                            List<Control> lstCells = new List<Control>();
                            row.IsShowCheckBox = m_isShowCheckBox;
                            row.ReloadCells();
                            row.BindingCellData();


                            Control rowControl = (row as Control);
                            this.panRow.Controls.Add(rowControl);
                            row.RowHeight = m_rowHeight;
                            rowControl.Dock = DockStyle.Top;
                            row.CellClick += (a, b) => { SetSelectRow(rowControl, b); };
                            row.CheckBoxChangeEvent += (a, b) => { SetSelectRow(rowControl, b); };
                            row.RowCustomEvent += (a, b) => { if (RowCustomEvent != null) { RowCustomEvent(a, b); } };
                            row.SourceChanged += RowSourceChanged;
                            rowControl.BringToFront();
                            Rows.Add(row);

                            if (lastItem == null)
                                lastItem = rowControl;
                        }
                    }
                    if (lastItem != null && intSourceCount == m_showCount)
                    {
                        lastItem.Height = this.panRow.Height - (m_showCount - 1) * m_rowHeight;
                    }
                }
            }
            finally
            {
                ControlHelper.FreezeControl(this.panRow, false);
            }
        }

        //void rowControl_SizeChanged(object sender, EventArgs e)
        //{
        //    if (m_isAutoHeight)
        //    {
        //        int intHeightCount = 0;
        //        intHeightCount += (IsShowHead ? this.panHead.Height : 0) + (Page != null ? this.panPage.Height : 0);
        //        foreach (Control item in this.panRow.Controls)
        //        {
        //            intHeightCount += item.Height;
        //        }
        //        if (this.Parent.Name == "panChildGrid")
        //        {
        //            if (this.Parent.Height != intHeightCount)
        //                this.Parent.Height = intHeightCount;
        //        }
        //        else
        //        {
        //            if (this.Height != intHeightCount)
        //                this.Height = intHeightCount;
        //        }
        //    }
        //}


        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                Previous();
            }
            else if (keyData == Keys.Down)
            {
                Next();
            }
            else if (keyData == Keys.Home)
            {
                First();
            }
            else if (keyData == Keys.End)
            {
                End();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// 选中第一个
        /// </summary>
        public void First()
        {
            if (Rows == null || Rows.Count <= 0)
                return;
            Control c = null;
            c = (Rows[0] as Control);
            SetSelectRow(c, new DataGridViewEventArgs() { RowIndex = 0 });
        }
        /// <summary>
        /// 选中上一个
        /// </summary>
        public void Previous()
        {
            if (Rows == null || Rows.Count <= 0)
                return;
            Control c = null;

            int index = Rows.IndexOf(m_selectRow);
            if (index - 1 >= 0)
            {
                c = (Rows[index - 1] as Control);
                SetSelectRow(c, new DataGridViewEventArgs() { RowIndex = index - 1 });
            }
        }
        /// <summary>
        /// 选中下一个
        /// </summary>
        public void Next()
        {
            if (Rows == null || Rows.Count <= 0)
                return;
            Control c = null;

            int index = Rows.IndexOf(m_selectRow);
            if (index + 1 < Rows.Count)
            {
                c = (Rows[index + 1] as Control);
                SetSelectRow(c, new DataGridViewEventArgs() { RowIndex = index + 1 });
            }
        }
        /// <summary>
        /// 选中最后一个
        /// </summary>
        public void End()
        {
            if (Rows == null || Rows.Count <= 0)
                return;
            Control c = null;
            c = (Rows[Rows.Count - 1] as Control);
            SetSelectRow(c, new DataGridViewEventArgs() { RowIndex = Rows.Count - 1 });
        }

        #endregion

        #region 事件
        void RowSourceChanged(object sender, DataGridViewEventArgs e)
        {
            if (SourceChanged != null)
                SourceChanged(sender, e);
        }
        private void SetSelectRow(Control item, DataGridViewEventArgs e)
        {
            try
            {
                ControlHelper.FreezeControl(this, true);
                if (item == null)
                    return;
                if (item.Visible == false)
                    return;
                this.FindForm().ActiveControl = this;
                this.FindForm().ActiveControl = item;
                if (m_selectRow != item)
                {
                    if (m_selectRow != null)
                    {
                        m_selectRow.SetSelect(false);
                    }
                    m_selectRow = item as IDataGridViewRow;
                    m_selectRow.SetSelect(true);

                    if (this.panRow.Controls.Count > 0)
                    {
                        if (item.Location.Y < 0)
                        {
                            this.panRow.AutoScrollPosition = new Point(0, Math.Abs(this.panRow.Controls[this.panRow.Controls.Count - 1].Location.Y) + item.Location.Y);
                        }
                        else if (item.Location.Y + m_rowHeight > this.panRow.Height)
                        {
                            this.panRow.AutoScrollPosition = new Point(0, Math.Abs(this.panRow.AutoScrollPosition.Y) + item.Location.Y - this.panRow.Height + m_rowHeight);
                        }
                    }
                }


                if (ItemClick != null)
                {
                    ItemClick(item, e);
                }
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }
        private void UCDataGridView_Resize(object sender, EventArgs e)
        {
            if (this.Height <= 0)
                return;
            if (m_isAutoHeight)
                return;
            ResetShowCount();
            ReloadSource();
        }
        #endregion

        private void panRow_SizeChanged(object sender, EventArgs e)
        {
            //if (m_isAutoHeight)
            //{
            //    int intHeightCount = (IsShowHead ? this.panHead.Height : 0) + (Page != null ? this.panPage.Height : 0) + panRow.Height;
            //    if (this.Height != intHeightCount)
            //        this.Height = intHeightCount;
            //}
        }
    }
}
