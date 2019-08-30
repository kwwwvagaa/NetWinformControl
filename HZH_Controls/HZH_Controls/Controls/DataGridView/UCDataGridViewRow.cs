// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCDataGridViewRow.cs
// 创建日期：2019-08-15 15:59:31
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

namespace HZH_Controls.Controls
{
    [ToolboxItem(false)]
    public partial class UCDataGridViewRow : UserControl, IDataGridViewRow
    {

        #region 属性
        public event DataGridViewEventHandler CheckBoxChangeEvent;
        public event DataGridViewRowCustomEventHandler RowCustomEvent;
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

        public UCDataGridViewRow()
        {
            InitializeComponent();
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
                this.BackColor = Color.FromArgb(255, 247, 245);
            }
            else
            {
                this.BackColor = Color.Transparent;
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

    }
}
