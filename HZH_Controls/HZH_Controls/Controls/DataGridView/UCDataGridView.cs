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
        private Font m_headFont = new Font("微软雅黑", 12F);
        /// <summary>
        /// 标题字体
        /// </summary>
        public Font HeadFont
        {
            get { return m_headFont; }
            set { m_headFont = value; }
        }
        private Color m_headTextColor = Color.Black;
        /// <summary>
        /// 标题字体颜色
        /// </summary>
        public Color HeadTextColor
        {
            get { return m_headTextColor; }
            set { m_headTextColor = value; }
        }

        private bool m_isShowHead = true;
        /// <summary>
        /// 是否显示标题
        /// </summary>
        public bool IsShowHead
        {
            get { return m_isShowHead; }
            set
            {
                m_isShowHead = value;
                panHead.Visible = value;
            }
        }
        private int m_headHeight = 40;
        /// <summary>
        /// 标题高度
        /// </summary>
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
        public int RowHeight
        {
            get { return m_rowHeight; }
            set { m_rowHeight = value; }
        }

        private int m_showCount = 0;
        /// <summary>
        /// 
        /// </summary>
        public int ShowCount
        {
            get { return m_showCount; }
        }

        private List<DataGridViewColumnEntity> m_columns;
        /// <summary>
        /// 列
        /// </summary>
        public List<DataGridViewColumnEntity> Columns
        {
            get { return m_columns; }
            set
            {
                m_columns = value;
                LoadColumns();
            }
        }


        private object m_dataSource;
        /// <summary>
        /// 数据源,支持列表或table，如果使用翻页控件，请使用翻页控件的DataSource
        /// </summary>
        public object DataSource
        {
            get { return m_dataSource; }
            set
            {
                if (value == null)
                    return;
                if (!(m_dataSource is DataTable) && (!typeof(IList).IsAssignableFrom(value.GetType())))
                {
                    throw new Exception("数据源不是有效的数据类型，请使用Datatable或列表");
                }

                m_dataSource = value;
                ReloadSource();
            }
        }

        public List<IDataGridViewRow> Rows { get; private set; }

        private Type m_rowType = typeof(UCDataGridViewRow);
        /// <summary>
        /// 行元素类型，默认UCDataGridViewItem
        /// </summary>
        public Type RowType
        {
            get { return m_rowType; }
            set
            {
                if (!typeof(IDataGridViewRow).IsAssignableFrom(value) || !value.IsSubclassOf(typeof(Control)))
                    throw new Exception("行控件没有实现IDataGridViewRow接口");
                m_rowType = value;
            }
        }
        IDataGridViewRow m_selectRow = null;
        /// <summary>
        /// 选中的节点
        /// </summary>
        public IDataGridViewRow SelectRow
        {
            get { return m_selectRow; }
            private set { m_selectRow = value; }
        }


        /// <summary>
        /// 选中的行，如果显示CheckBox，则以CheckBox选中为准
        /// </summary>
        public List<IDataGridViewRow> SelectRows
        {
            get
            {
                if (m_isShowCheckBox)
                {
                    return Rows.FindAll(p => p.IsChecked);
                }
                else
                    return new List<IDataGridViewRow>() { m_selectRow };
            }
        }
        #region 事件
        public EventHandler HeadCheckBoxChangeEvent;

        public EventHandler HeadColumnClickEvent;
        [Description("项点击事件"), Category("自定义")]
        public event DataGridViewCellEventHandler ItemClick;
        [Description("数据源改变事件"), Category("自定义")]
        public event DataGridViewCellEventHandler SourceChanged;
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
            m_showCount = this.Height / (m_rowHeight);
            int intCha = this.Height % (m_rowHeight);
            m_rowHeight += intCha / m_showCount;
        }
        #endregion

        #region 公共函数

        public void ReloadSource()
        {
            if (DesignMode)
            { return; }
            try
            {
                if (m_columns == null || m_columns.Count <= 0)
                    return;

                ControlHelper.FreezeControl(this.panRow, true);
                this.panRow.Controls.Clear();
                Rows = new List<IDataGridViewRow>();
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
                            item.Height = m_rowHeight;
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
                            rowControl.Height = m_rowHeight;
                            this.panRow.Controls.Add(rowControl);
                            rowControl.Dock = DockStyle.Top;
                            row.CellClick += (a, b) => { SetSelectRow(rowControl, b); };
                            row.CheckBoxChangeEvent += (a, b) => { SetSelectRow(rowControl, b); };
                            row.SourceChanged += RowSourceChanged;
                            rowControl.BringToFront();
                            Rows.Add(row);

                            if (lastItem == null)
                                lastItem = rowControl;
                        }
                    }
                    if (lastItem != null && intSourceCount == m_showCount)
                    {
                        lastItem.Height = this.Height - (m_showCount - 1) * m_rowHeight;
                    }
                }
            }
            finally
            {
                ControlHelper.FreezeControl(this.panRow, false);
            }
        }

      

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
            SetSelectRow(c, new DataGridViewCellEventArgs() { RowIndex = 0 });
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
                SetSelectRow(c, new DataGridViewCellEventArgs() { RowIndex = index - 1 });
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
                SetSelectRow(c, new DataGridViewCellEventArgs() { RowIndex = index + 1 });
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
            SetSelectRow(c, new DataGridViewCellEventArgs() { RowIndex = Rows.Count - 1 });
        }

        #endregion

        #region 事件
        void RowSourceChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (SourceChanged != null)
                SourceChanged(sender, e);
        }
        private void SetSelectRow(Control item, DataGridViewCellEventArgs e)
        {
            if (item == null)
                return;
            if (item.Visible == false)
                return;
            this.FindForm().ActiveControl = this;
            this.FindForm().ActiveControl = item;
            if (m_selectRow != null)
            {
                if (m_selectRow == item)
                    return;
                m_selectRow.SetSelect(false);
            }
            m_selectRow = item as IDataGridViewRow;
            m_selectRow.SetSelect(true);
            if (ItemClick != null)
            {
                ItemClick(item, e);
            }
            this.panRow.AutoScrollPosition = new Point(0, item.Location.Y);
        }
        private void UCDataGridView_Resize(object sender, EventArgs e)
        {
            ResetShowCount();
            ReloadSource();
        }
        #endregion
    }
}
