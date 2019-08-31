// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：uccomboxgrid.cs
// 作　　者：HZH
// 创建日期：2019-08-31 16:01:55
// 功能描述：UCDropDownBtn    English:UCDropDownBtn
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
// 项目地址：https://github.com/kwwwvagaa/NetWinformControl
// 如果你使用了此类，请保留以上说明
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Controls;

namespace HZH_Controls.Controls.ComboBox
{
    public partial class UCComboxGrid : UCCombox
    {

        private Type m_rowType = typeof(UCDataGridViewRow);

        [Description("表格行类型"), Category("自定义")]
        public Type GridRowType
        {
            get { return m_rowType; }
            set
            {
                m_rowType = value;
            }
        }
        int intWidth = 0;

        private List<DataGridViewColumnEntity> m_columns = null;

        [Description("表格列"), Category("自定义")]
        public List<DataGridViewColumnEntity> GridColumns
        {
            get { return m_columns; }
            set
            {
                m_columns = value;
                if (value != null)
                    intWidth = value.Sum(p => p.WidthType == SizeType.Absolute ? p.Width : (p.Width < 80 ? 80 : p.Width));
            }
        }
        private List<object> m_dataSource = null;

        [Description("表格数据源"), Category("自定义")]
        public List<object> GridDataSource
        {
            get { return m_dataSource; }
            set { m_dataSource = value; }
        }

        private string m_textField;

        [Description("显示值字段名称"), Category("自定义")]
        public string TextField
        {
            get { return m_textField; }
            set
            {
                m_textField = value;
                SetText();
            }
        }
        [Obsolete("不再可用的属性")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        private new ComboBoxStyle BoxStyle
        {
            get;
            set;
        }
        private object selectSource = null;

        [Description("选中的数据源"), Category("自定义")]
        public object SelectSource
        {
            get { return selectSource; }
            set
            {
                selectSource = value;
                SetText();
                if (SelectedChangedEvent != null)
                {
                    SelectedChangedEvent(value, null);
                }
            }
        }



        [Description("选中数据源改变事件"), Category("自定义")]
        public new event EventHandler SelectedChangedEvent;
        public UCComboxGrid()
        {
            InitializeComponent();
        }
        UCComboxGridPanel m_ucPanel = null;
        Forms.FrmAnchor _frmAnchor;
        protected override void click_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_columns == null || m_columns.Count <= 0)
                return;
            if (m_ucPanel == null)
            {
                var p = this.Parent.PointToScreen(this.Location);
                int intScreenHeight = Screen.PrimaryScreen.Bounds.Height;
                int intHeight = Math.Max(p.Y, intScreenHeight - p.Y - this.Height);
                intHeight -= 100;
                m_ucPanel = new UCComboxGridPanel();
                m_ucPanel.ItemClick += m_ucPanel_ItemClick;
                m_ucPanel.Height = intHeight;
                m_ucPanel.Width = intWidth;
                m_ucPanel.Columns = m_columns;
                m_ucPanel.RowType = m_rowType;
                if (m_dataSource != null && m_dataSource.Count > 0)
                {
                    int _intHeight = Math.Min(110 + m_dataSource.Count * 36, m_ucPanel.Height);
                    m_ucPanel.Height = _intHeight;
                }
            }
            m_ucPanel.DataSource = m_dataSource;
            if (_frmAnchor == null || _frmAnchor.IsDisposed || _frmAnchor.Visible == false)
            {
                _frmAnchor = new Forms.FrmAnchor(this, m_ucPanel, isNotFocus: false);
                _frmAnchor.Show(this.FindForm());
            }

        }

        void m_ucPanel_ItemClick(object sender, DataGridViewEventArgs e)
        {
            _frmAnchor.Hide();
            SelectSource = sender;
        }

        private void SetText()
        {
            if (!string.IsNullOrEmpty(m_textField) && selectSource != null)
            {
                var pro = selectSource.GetType().GetProperty(m_textField);
                if (pro != null)
                {
                    TextValue = pro.GetValue(selectSource, null).ToStringExt();
                }
            }
        }
    }
}
