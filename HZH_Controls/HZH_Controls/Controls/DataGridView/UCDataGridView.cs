// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-09-2019
//
// ***********************************************************************
// <copyright file="UCDataGridView.cs">
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
    /// Class UCDataGridView.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class UCDataGridView : UserControl
    {
        #region 属性
        /// <summary>
        /// The m head pading left
        /// </summary>
        private int m_headPadingLeft = 0;

        /// <summary>
        /// Gets or sets the head pading left.
        /// </summary>
        /// <value>The head pading left.</value>
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

        /// <summary>
        /// The m head font
        /// </summary>
        private Font m_headFont = new Font("微软雅黑", 12F);
        /// <summary>
        /// 标题字体
        /// </summary>
        /// <value>The head font.</value>
        [Description("标题字体"), Category("自定义")]
        public Font HeadFont
        {
            get { return m_headFont; }
            set { m_headFont = value; }
        }
        /// <summary>
        /// The m head text color
        /// </summary>
        private Color m_headTextColor = Color.Black;
        /// <summary>
        /// 标题字体颜色
        /// </summary>
        /// <value>The color of the head text.</value>
        [Description("标题文字颜色"), Category("自定义")]
        public Color HeadTextColor
        {
            get { return m_headTextColor; }
            set { m_headTextColor = value; }
        }

        /// <summary>
        /// The m is show head
        /// </summary>
        private bool m_isShowHead = true;
        /// <summary>
        /// 是否显示标题
        /// </summary>
        /// <value><c>true</c> if this instance is show head; otherwise, <c>false</c>.</value>
        [Description("是否显示标题"), Category("自定义")]
        public bool IsShowHead
        {
            get { return m_isShowHead; }
            set
            {
                m_isShowHead = value;
                panHead.Visible = value;
            }
        }
        /// <summary>
        /// The m head height
        /// </summary>
        private int m_headHeight = 40;
        /// <summary>
        /// 标题高度
        /// </summary>
        /// <value>The height of the head.</value>
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

        /// <summary>
        /// The m is show CheckBox
        /// </summary>
        private bool m_isShowCheckBox = false;
        /// <summary>
        /// 是否显示复选框
        /// </summary>
        /// <value><c>true</c> if this instance is show CheckBox; otherwise, <c>false</c>.</value>
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

        /// <summary>
        /// The m row height
        /// </summary>
        private int m_rowHeight = 40;
        /// <summary>
        /// 行高
        /// </summary>
        /// <value>The height of the row.</value>
        [Description("数据行高"), Category("自定义")]
        public int RowHeight
        {
            get { return m_rowHeight; }
            set { m_rowHeight = value; }
        }


        /// <summary>
        /// Gets the show count.
        /// </summary>
        /// <value>The show count.</value>
        [Description("当前高度可显示行个数"), Category("自定义")]
        public int ShowCount
        {
            get
            {
                return this.panRow.Height / (m_rowHeight);
            }
        }

        /// <summary>
        /// The m columns
        /// </summary>
        private List<DataGridViewColumnEntity> m_columns = null;
        /// <summary>
        /// 列
        /// </summary>
        /// <value>The columns.</value>
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

        /// <summary>
        /// The m data source
        /// </summary>
        private object m_dataSource = null;
        /// <summary>
        /// 数据源,支持列表或table，如果使用翻页控件，请使用翻页控件的DataSource
        /// </summary>
        /// <value>The data source.</value>
        /// <exception cref="Exception">数据源不是有效的数据类型，请使用Datatable或列表</exception>
        /// <exception cref="System.Exception">数据源不是有效的数据类型，请使用Datatable或列表</exception>
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
                if (BindingSourceEvent != null)
                {
                    BindingSourceEvent(this, null);
                }
            }
        }

        /// <summary>
        /// Gets the rows.
        /// </summary>
        /// <value>The rows.</value>
        public List<IDataGridViewRow> Rows { get; private set; }

        /// <summary>
        /// The m row type
        /// </summary>
        private Type m_rowType = typeof(UCDataGridViewRow);
        /// <summary>
        /// 行元素类型，默认UCDataGridViewItem
        /// </summary>
        /// <value>The type of the row.</value>
        /// <exception cref="Exception">行控件没有实现IDataGridViewRow接口</exception>
        /// <exception cref="System.Exception">行控件没有实现IDataGridViewRow接口</exception>
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
                if (m_columns != null && m_columns.Count > 0)
                    ReloadSource();
            }
        }
      
        /// <summary>
        /// The m select row
        /// </summary>
        IDataGridViewRow m_selectRow = null;
        /// <summary>
        /// 选中的节点
        /// </summary>
        /// <value>The select row.</value>
        [Description("选中行"), Category("自定义")]
        public IDataGridViewRow SelectRow
        {
            get { return m_selectRow; }
            private set { m_selectRow = value; }
        }


        /// <summary>
        /// 选中的行，如果显示CheckBox，则以CheckBox选中为准
        /// </summary>
        /// <value>The select rows.</value>
        [Description("选中的行，如果显示CheckBox，则以CheckBox选中为准"), Category("自定义")]
        public List<IDataGridViewRow> SelectRows
        {
            get
            {
                return GetSelectRows();
            }
        }

        /// <summary>
        /// Gets the select rows.
        /// </summary>
        /// <returns>List&lt;IDataGridViewRow&gt;.</returns>
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
                    if (grid != null)
                        lst.AddRange(grid.SelectRows);
                }
            }
            return lst;
        }

        /// <summary>
        /// Finds the child grid.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>UCDataGridView.</returns>
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
              
        #region 事件
        /// <summary>
        /// The head CheckBox change event
        /// </summary>
        [Description("选中标题选择框事件"), Category("自定义")]
        public EventHandler HeadCheckBoxChangeEvent;
        /// <summary>
        /// The head column click event
        /// </summary>
        [Description("标题点击事件"), Category("自定义")]
        public EventHandler HeadColumnClickEvent;
        /// <summary>
        /// Occurs when [item click].
        /// </summary>
        [Description("项点击事件"), Category("自定义")]
        public event DataGridViewEventHandler ItemClick;
        /// <summary>
        /// Occurs when [source changed].
        /// </summary>
        [Description("行数据源改变事件"), Category("自定义")]
        public event DataGridViewEventHandler RowSourceChangedEvent;
        /// <summary>
        /// Occurs when [row custom event].
        /// </summary>
        [Description("预留的自定义的事件，比如你需要在行上放置删改等按钮时，可以通过此事件传递出来"), Category("自定义")]
        public event DataGridViewRowCustomEventHandler RowCustomEvent;
        [Description("绑定数据源后事件"), Category("自定义")]
        public event EventHandler BindingSourceEvent;
        #endregion
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="UCDataGridView" /> class.
        /// </summary>
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
                ControlHelper.FreezeControl(this, true);              
                Rows = new List<IDataGridViewRow>();
                if (m_columns == null || m_columns.Count <= 0)
                    return;
                if (m_dataSource != null)
                {
                    int intIndex = 0;
                   
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
                            row.RowHeight = m_rowHeight;
                            rowControl.Dock = DockStyle.Top;
                            row.CellClick += (a, b) => { SetSelectRow(rowControl, b); };
                            row.CheckBoxChangeEvent += (a, b) => { SetSelectRow(rowControl, b); };
                            row.RowCustomEvent += (a, b) => { if (RowCustomEvent != null) { RowCustomEvent(a, b); } };
                            row.SourceChanged += RowSourceChanged;
                            Rows.Add(row);
                            this.panRow.Controls.Add(rowControl);
                            rowControl.BringToFront();
                        
                        }
                    }                 
                }
                else
                {
                    foreach (Control item in this.panRow.Controls)
                    {
                        item.Visible = false;
                    }
                }
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }
      
        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="msg">通过引用传递的 <see cref="T:System.Windows.Forms.Message" />，它表示要处理的窗口消息。</param>
        /// <param name="keyData"><see cref="T:System.Windows.Forms.Keys" /> 值之一，它表示要处理的键。</param>
        /// <returns>如果字符已由控件处理，则为 true；否则为 false。</returns>
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
        /// <summary>
        /// Rows the source changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewEventArgs" /> instance containing the event data.</param>
        void RowSourceChanged(object sender, DataGridViewEventArgs e)
        {
            if (RowSourceChangedEvent != null)
                RowSourceChangedEvent(sender, e);
        }
        /// <summary>
        /// Sets the select row.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="e">The <see cref="DataGridViewEventArgs" /> instance containing the event data.</param>
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
      
        #endregion
    
    }
}
