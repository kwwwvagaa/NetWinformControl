// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-23-2019
//
// ***********************************************************************
// <copyright file="UCDataGridViewTreeRow.cs">
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
    /// Class UCDataGridViewTreeRow.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// Implements the <see cref="HZH_Controls.Controls.IDataGridViewRow" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    /// <seealso cref="HZH_Controls.Controls.IDataGridViewRow" />
    [ToolboxItem(false)]
    public partial class UCDataGridViewTreeRow : UserControl, IDataGridViewRow
    {
        #region 属性
        /// <summary>
        /// CheckBox选中事件
        /// </summary>
        public event DataGridViewEventHandler CheckBoxChangeEvent;

        /// <summary>
        /// 点击单元格事件
        /// </summary>
        public event DataGridViewEventHandler CellClick;

        /// <summary>
        /// 数据源改变事件
        /// </summary>
        public event DataGridViewEventHandler SourceChanged;
        /// <summary>
        /// Occurs when [row custom event].
        /// </summary>
        public event DataGridViewRowCustomEventHandler RowCustomEvent;
        /// <summary>
        /// 列参数，用于创建列数和宽度
        /// </summary>
        /// <value>The columns.</value>
        public List<DataGridViewColumnEntity> Columns
        {
            get;
            set;
        }

        /// <summary>
        /// 数据源
        /// </summary>
        /// <value>The data source.</value>
        public object DataSource
        {
            get;
            set;
        }

        private int rowLevel = 0;
        /// <summary>
        /// 折叠的第几层，用于缩进
        /// </summary>
        public int RowLevel
        {
            get { return rowLevel; }
            set
            {
                rowLevel = value;
                this.Padding = new Padding(this.panLeft.Width / 2 * value, this.Padding.Top, this.panLeft.Right, this.Padding.Bottom);
                this.ucSplitLine_V1.Visible = value > 0;
            }
        }

        /// <summary>
        /// 行号，树状图目前没有给予行号
        /// </summary>
        /// <value>The Index of the row.</value>
        public int RowIndex { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is show CheckBox.
        /// </summary>
        /// <value><c>true</c> if this instance is show CheckBox; otherwise, <c>false</c>.</value>
        public bool IsShowCheckBox
        {
            get;
            set;
        }
        /// <summary>
        /// The m is checked
        /// </summary>
        private bool m_isChecked;
        /// <summary>
        /// 是否选中
        /// </summary>
        /// <value><c>true</c> if this instance is checked; otherwise, <c>false</c>.</value>
        public bool IsChecked
        {
            get
            {
                return m_isChecked;
            }

            set
            {
                if (m_isChecked != value)
                {
                    m_isChecked = value;
                    (this.panCells.Controls.Find("check", false)[0] as UCCheckBox).Checked = value;
                }
            }
        }

        /// <summary>
        /// The m row height
        /// </summary>
        int m_rowHeight = 40;
        /// <summary>
        /// 行高
        /// </summary>
        /// <value>The height of the row.</value>
        public int RowHeight
        {
            get
            {
                return m_rowHeight;
            }
            set
            {
                m_rowHeight = value;
                this.Height = value;
            }
        }
        private List<UCDataGridViewTreeRow> childrenRows = new List<UCDataGridViewTreeRow>();

        public List<UCDataGridViewTreeRow> ChildrenRows
        {
            get { return childrenRows; }
            set { childrenRows = value; }
        }
        private bool? isOpened = false;
        /// <summary>
        /// 是否打开状态
        /// </summary>
        public bool? IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                if (value.HasValue)
                {
                    panLeft.Enabled = true;
                    if (value.Value)
                    {
                        panLeft.BackgroundImage = Properties.Resources.caret_down;
                    }
                    else
                    {
                        panLeft.BackgroundImage = Properties.Resources.caret_right;
                    }
                }
                else
                {
                    panLeft.BackgroundImage = null;
                    panLeft.Enabled = false;
                }
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="UCDataGridViewTreeRow" /> class.
        /// </summary>
        public UCDataGridViewTreeRow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定数据到Cell
        /// </summary>
        public void BindingCellData()
        {
            for (int i = 0; i < Columns.Count; i++)
            {
                DataGridViewColumnEntity com = Columns[i];
                var cs = this.panCells.Controls.Find("lbl_" + com.DataField, false);
                if (cs != null && cs.Length > 0)
                {
                    var pro = DataSource.GetType().GetProperty(com.DataField);
                    if (pro != null)
                    {
                        var value = pro.GetValue(DataSource, null);
                        if (com.Format != null)
                        {
                            cs[0].Text = com.Format(value);
                        }
                        else
                        {
                            cs[0].Text = value.ToStringExt();
                        }
                    }
                }
            }
            foreach (Control item in this.panCells.Controls)
            {
                if (item is IDataGridViewCustomCell)
                {
                    IDataGridViewCustomCell cell = item as IDataGridViewCustomCell;
                    cell.RowCustomEvent += cell_RowCustomEvent;
                    cell.SetBindSource(DataSource);
                }
            }
            IsOpened = false;
            var proChildrens = DataSource.GetType().GetProperty("Childrens");
            if (proChildrens != null)
            {
                var value = proChildrens.GetValue(DataSource, null);
                if (value != null)
                {
                }
                else
                {
                    IsOpened = null;
                }
            }
            else
            {
                IsOpened = null;
            }
        }

        void cell_RowCustomEvent(object sender, DataGridViewRowCustomEventArgs e)
        {
            if (RowCustomEvent != null)
                RowCustomEvent(sender, e);
        }

        /// <summary>
        /// Handles the MouseDown event of the Item control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        void Item_MouseDown(object sender, MouseEventArgs e)
        {
            if (CellClick != null)
            {
                CellClick(this, new DataGridViewEventArgs()
                {
                    CellControl = this,
                    CellIndex = (sender as Control).Tag.ToInt()
                });
            }
        }

        /// <summary>
        /// 设置选中状态，通常为设置颜色即可
        /// </summary>
        /// <param name="blnSelected">是否选中</param>
        public void SetSelect(bool blnSelected)
        {
            if (blnSelected)
            {
                this.panMain.BackColor = Color.FromArgb(255, 247, 245);
            }
            else
            {
                this.panMain.BackColor = Color.Transparent;
            }
        }

        /// <summary>
        /// 添加单元格元素，仅做添加控件操作，不做数据绑定，数据绑定使用BindingCells
        /// </summary>
        public void ReloadCells()
        {
            try
            {
                ControlHelper.FreezeControl(this, true);
                this.panCells.Controls.Clear();
                this.panCells.ColumnStyles.Clear();

                int intColumnsCount = Columns.Count();
                if (Columns != null && intColumnsCount > 0)
                {
                    if (IsShowCheckBox)
                    {
                        intColumnsCount++;
                    }
                    this.panCells.ColumnCount = intColumnsCount;
                    bool blnFirst = true;
                    for (int i = 0; i < intColumnsCount; i++)
                    {
                        Control c = null;
                        if (i == 0 && IsShowCheckBox)
                        {
                            this.panCells.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Absolute, 30F));

                            UCCheckBox box = new UCCheckBox();
                            box.Name = "check";
                            box.TextValue = "";
                            box.Size = new Size(30, 30);
                            box.Dock = DockStyle.Fill;
                            box.CheckedChangeEvent += box_CheckedChangeEvent;
                            c = box;
                        }
                        else
                        {
                            var item = Columns[i - (IsShowCheckBox ? 1 : 0)];
                            var w = item.Width - (blnFirst ? (this.panLeft.Width / 2 * rowLevel) : 0);
                            if (w < 5)
                                w = 5;
                            this.panCells.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(item.WidthType, w));
                            blnFirst = false;
                            if (item.CustomCellType == null)
                            {
                                Label lbl = new Label();
                                lbl.Tag = i - (IsShowCheckBox ? 1 : 0);
                                lbl.Name = "lbl_" + item.DataField;
                                lbl.Font = new Font("微软雅黑", 12);
                                lbl.ForeColor = Color.Black;
                                lbl.AutoSize = false;
                                lbl.Dock = DockStyle.Fill;
                                lbl.TextAlign = item.TextAlign;
                                lbl.MouseDown += (a, b) =>
                                {
                                    Item_MouseDown(a, b);
                                };
                                c = lbl;
                            }
                            else
                            {
                                Control cc = (Control)Activator.CreateInstance(item.CustomCellType);
                                cc.Dock = DockStyle.Fill;
                                c = cc;
                            }
                        }
                        this.panCells.Controls.Add(c, i, 0);
                    }

                }
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }

        void box_CheckedChangeEvent(object sender, EventArgs e)
        {
            IsChecked = ((UCCheckBox)sender).Checked;
        }



        /// <summary>
        /// Handles the MouseDown event of the panLeft control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void panLeft_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (!IsOpened.HasValue)
                    return;
                ControlHelper.FreezeControl(this.FindForm(), true);
                if (!IsOpened.Value)
                {

                    IsOpened = !IsOpened;
                    if (childrenRows.Count > 0)
                    {
                        childrenRows.ForEach(p =>
                        {
                            p.IsChecked = IsChecked;
                            p.Visible = true;
                        });
                    }
                    else
                    {
                        var proChildrens = DataSource.GetType().GetProperty("Childrens");
                        if (proChildrens != null)
                        {
                            var value = proChildrens.GetValue(DataSource, null);
                            int intSourceCount = 0;
                            if (value is DataTable)
                            {
                                intSourceCount = (value as DataTable).Rows.Count;
                            }
                            else if (typeof(IList).IsAssignableFrom(value.GetType()))
                            {
                                intSourceCount = (value as IList).Count;
                            }
                            for (int i = intSourceCount - 1; i >= 0; i--)
                            {
                                UCDataGridViewTreeRow row = new UCDataGridViewTreeRow();
                                if (value is DataTable)
                                {
                                    row.DataSource = (value as DataTable).Rows[i];
                                }
                                else
                                {
                                    row.DataSource = (value as IList)[i];
                                }
                                row.RowLevel = RowLevel + 1;
                                row.Columns = Columns;
                                row.IsShowCheckBox = IsShowCheckBox;
                                row.ReloadCells();
                                row.BindingCellData();

                                Control rowControl = (row as Control);
                                row.RowHeight = m_rowHeight;
                                rowControl.Width = this.Width;
                                //rowControl.Dock = DockStyle.Top;
                                row.CellClick += (a, b) => { CellClick(rowControl, b); };
                                row.CheckBoxChangeEvent += (a, b) => { CheckBoxChangeEvent(rowControl, b); };
                                row.RowCustomEvent += (a, b) => { if (RowCustomEvent != null) { RowCustomEvent(a, b); } };
                                row.SourceChanged += SourceChanged;
                                ChildrenRows.Add(row);
                                row.RowIndex = ChildrenRows.IndexOf(row);

                                this.Parent.Controls.Add(rowControl);
                                var index = this.Parent.Controls.GetChildIndex(this);
                                this.Parent.Controls.SetChildIndex(row, index+1);

                            }
                        }
                    }
                }
                else
                {
                    HideChildrenRows(this);
                    this.Height = m_rowHeight;
                }
            }
            finally
            {
                ControlHelper.FreezeControl(this.FindForm(), false);
            }
        }

        private void HideChildrenRows(UCDataGridViewTreeRow row)
        {
            if (row.ChildrenRows.Count > 0)
            {
                foreach (var item in row.ChildrenRows)
                {
                    HideChildrenRows(item);
                    item.Hide();
                }
                row.IsOpened = false;
            }
        }
    }
}
