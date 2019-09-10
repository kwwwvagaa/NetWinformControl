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
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="UCDataGridViewTreeRow" /> class.
        /// </summary>
        public UCDataGridViewTreeRow()
        {
            InitializeComponent();
            this.ucDGVChild.RowType = this.GetType();
            this.ucDGVChild.IsCloseAutoHeight = true;
            this.SizeChanged += UCDataGridViewTreeRow_SizeChanged;
            this.ucDGVChild.ItemClick += (a, b) =>
            {
                if (CellClick != null)
                {
                    CellClick(a, new DataGridViewEventArgs()
                    {
                        CellControl = (a as Control),
                        CellIndex = (a as Control).Tag.ToInt()
                    });
                }
            };

        }

        /// <summary>
        /// Handles the SizeChanged event of the UCDataGridViewTreeRow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void UCDataGridViewTreeRow_SizeChanged(object sender, EventArgs e)
        {
            if (this.Parent.Parent.Parent != null && this.Parent.Parent.Parent.Name == "panChildGrid" && this.panLeft.Tag.ToInt() == 1)
            {
                int intHeight = this.Parent.Parent.Controls[0].Controls.ToArray().Sum(p => p.Height);
                if (this.Parent.Parent.Parent.Height != intHeight)
                    this.Parent.Parent.Parent.Height = intHeight;
            }
        }


        /// <summary>
        /// 绑定数据到Cell
        /// </summary>
        /// <returns>返回true则表示已处理过，否则将进行默认绑定（通常只针对有Text值的控件）</returns>
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
            panLeft.Tag = 0;
            var proChildrens = DataSource.GetType().GetProperty("Childrens");
            if (proChildrens != null)
            {
                var value = proChildrens.GetValue(DataSource, null);
                if (value != null)
                {
                    int intSourceCount = 0;
                    if (value is DataTable)
                    {
                        intSourceCount = (value as DataTable).Rows.Count;
                    }
                    else if (typeof(IList).IsAssignableFrom(value.GetType()))
                    {
                        intSourceCount = (value as IList).Count;
                    }
                    if (intSourceCount > 0)
                    {
                        panLeft.BackgroundImage = Properties.Resources.caret_right;
                        panLeft.Enabled = true;
                        panChildGrid.Tag = value;
                    }
                    else
                    {
                        panLeft.BackgroundImage = null;
                        panLeft.Enabled = false;
                        panChildGrid.Tag = null;
                    }
                }
                else
                {
                    panLeft.BackgroundImage = null;
                    panLeft.Enabled = false;
                    panChildGrid.Tag = null;
                }
            }
            else
            {
                panLeft.BackgroundImage = null;
                panLeft.Enabled = false;
                panChildGrid.Tag = null;
            }
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
                            box.CheckedChangeEvent += (a, b) =>
                            {
                                IsChecked = box.Checked;
                                this.ucDGVChild.Rows.ForEach(p => p.IsChecked = box.Checked);
                                if (CheckBoxChangeEvent != null)
                                {
                                    CheckBoxChangeEvent(a, new DataGridViewEventArgs()
                                    {
                                        CellControl = box,
                                        CellIndex = 0
                                    });
                                }
                            };
                            c = box;
                        }
                        else
                        {
                            var item = Columns[i - (IsShowCheckBox ? 1 : 0)];
                            this.panCells.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(item.WidthType, item.Width));

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
                        this.panCells.Controls.Add(c, i, 0);
                    }

                }
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }

        /// <summary>
        /// Handles the SizeChanged event of the panChildGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void panChildGrid_SizeChanged(object sender, EventArgs e)
        {
            int intHeight = RowHeight + panChildGrid.Height;
            if (panChildGrid.Height != 0)
                this.ucDGVChild.Height = panChildGrid.Height;
            if (this.Height != intHeight)
                this.Height = intHeight;
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
                ControlHelper.FreezeControl(this.FindForm(), true);
                if (panLeft.Tag.ToInt() == 0)
                {
                    var value = panChildGrid.Tag;
                    if (value != null)
                    {
                        panLeft.BackgroundImage = Properties.Resources.caret_down;
                        panLeft.Tag = 1;
                        int intSourceCount = 0;
                        if (value is DataTable)
                        {
                            intSourceCount = (value as DataTable).Rows.Count;
                        }
                        else if (typeof(IList).IsAssignableFrom(value.GetType()))
                        {
                            intSourceCount = (value as IList).Count;
                        }
                        this.panChildGrid.Height = RowHeight * intSourceCount;
                        if (panChildGrid.Height > 0)
                        {
                            if (value != this.ucDGVChild.DataSource)
                            {
                                this.ucDGVChild.Columns = Columns;
                                this.ucDGVChild.RowHeight = RowHeight;
                                this.ucDGVChild.HeadPadingLeft = this.panLeft.Width;
                                this.ucDGVChild.IsShowCheckBox = IsShowCheckBox;
                                this.ucDGVChild.DataSource = value;
                                this.ucDGVChild.Rows.ForEach(p => p.IsChecked = this.IsChecked);
                            }
                        }
                    }

                }
                else
                {
                    panLeft.Tag = 0;
                    panChildGrid.Height = 0;
                    panLeft.BackgroundImage = Properties.Resources.caret_right;
                }
            }
            finally
            {
                ControlHelper.FreezeControl(this.FindForm(), false);
            }
        }

        /// <summary>
        /// Handles the SizeChanged event of the ucDGVChild control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void ucDGVChild_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
