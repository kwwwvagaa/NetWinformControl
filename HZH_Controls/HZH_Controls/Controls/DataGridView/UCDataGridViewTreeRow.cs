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
    [ToolboxItem(false)]
    public partial class UCDataGridViewTreeRow : UserControl, IDataGridViewRow
    {
        #region 属性
        public event DataGridViewEventHandler CheckBoxChangeEvent;

        public event DataGridViewEventHandler CellClick;

        public event DataGridViewEventHandler SourceChanged;

        public List<DataGridViewColumnEntity> Columns
        {
            get;
            set;
        }

        public object DataSource
        {
            get;
            set;
        }

        public bool IsShowCheckBox
        {
            get;
            set;
        }
        private bool m_isChecked;
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

        int m_rowHeight = 40;
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

        public UCDataGridViewTreeRow()
        {
            InitializeComponent();
            this.ucDGVChild.RowType = this.GetType();
            this.ucDGVChild.IsAutoHeight = true;
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

        void UCDataGridViewTreeRow_SizeChanged(object sender, EventArgs e)
        {
            if (this.Parent.Parent.Parent != null && this.Parent.Parent.Parent.Name == "panChildGrid" && this.panLeft.Tag.ToInt() == 1)
            {
                int intHeight = this.Parent.Parent.Controls[0].Controls.ToArray().Sum(p => p.Height);
                if (this.Parent.Parent.Parent.Height != intHeight)
                    this.Parent.Parent.Parent.Height = intHeight;
            }
        }


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
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
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

        private void panChildGrid_SizeChanged(object sender, EventArgs e)
        {
            int intHeight = RowHeight + panChildGrid.Height;
            if (panChildGrid.Height != 0)
                this.ucDGVChild.Height = panChildGrid.Height;
            if (this.Height != intHeight)
                this.Height = intHeight;
        }

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
                                this.ucDGVChild.Rows.ForEach(p => p.IsChecked =this.IsChecked);
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

        private void ucDGVChild_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
