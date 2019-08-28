using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls.ComboBox
{
    [ToolboxItem(false)]
    public partial class UCComboxGridPanel : UserControl
    {
        [Description("项点击事件"), Category("自定义")]
        public event DataGridViewEventHandler ItemClick;
        private Type m_rowType = typeof(UCDataGridViewRow);

        public Type RowType
        {
            get { return m_rowType; }
            set
            {
                m_rowType = value;
                this.ucDataGridView1.RowType = m_rowType;
            }
        }

        private List<DataGridViewColumnEntity> m_columns = null;

        public List<DataGridViewColumnEntity> Columns
        {
            get { return m_columns; }
            set
            {
                m_columns = value;
                this.ucDataGridView1.Columns = value;
            }
        }
        private List<object> m_dataSource = null;

        public List<object> DataSource
        {
            get { return m_dataSource; }
            set { m_dataSource = value; }
        }

        private string strLastSearchText = string.Empty;
        UCPagerControl m_page = new UCPagerControl();

        public UCComboxGridPanel()
        {
            InitializeComponent();
            this.ucDataGridView1.Page = m_page;
            this.ucDataGridView1.IsAutoHeight = false;
            this.txtSearch.txtInput.TextChanged += txtInput_TextChanged;
            this.ucDataGridView1.ItemClick += ucDataGridView1_ItemClick;
        }

        void ucDataGridView1_ItemClick(object sender, DataGridViewEventArgs e)
        {
            if (ItemClick != null)
            {
                ItemClick((sender as IDataGridViewRow).DataSource, null);
            }
        }

        void txtInput_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Enabled = true;
        }

        private void UCComboxGridPanel_Load(object sender, EventArgs e)
        {
            m_page.DataSource = m_dataSource;
            this.ucDataGridView1.DataSource = m_page.GetCurrentSource();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (strLastSearchText == txtSearch.InputText)
            {
                timer1.Enabled = false;
            }
            else
            {
                strLastSearchText = txtSearch.InputText;
                Search(txtSearch.InputText);
            }
        }

        private void Search(string strText)
        {
            m_page.StartIndex = 0;
            if (!string.IsNullOrEmpty(strText))
            {
                strText = strText.ToLower();
                List<object> lst = m_dataSource.FindAll(p => m_columns.Any(c => (c.Format == null ? (p.GetType().GetProperty(c.DataField).GetValue(p, null).ToStringExt()) : c.Format(p.GetType().GetProperty(c.DataField).GetValue(p, null))).ToLower().Contains(strText)));
                m_page.DataSource = lst;
            }
            else
            {
                m_page.DataSource = m_dataSource;
            }
            m_page.Reload();
        }
    }
}
