// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-28-2019
//
// ***********************************************************************
// <copyright file="UCComboxGridPanel.cs">
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

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCComboxGridPanel.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public partial class UCComboxGridPanel : UserControl
    {
        /// <summary>
        /// 项点击事件
        /// </summary>
        [Description("项点击事件"), Category("自定义")]
        public event DataGridViewEventHandler ItemClick;
        /// <summary>
        /// The m row type
        /// </summary>
        private Type m_rowType = typeof(UCDataGridViewRow);
        /// <summary>
        /// 行类型
        /// </summary>
        /// <value>The type of the row.</value>
        [Description("行类型"), Category("自定义")]
        public Type RowType
        {
            get { return m_rowType; }
            set
            {
                m_rowType = value;
                this.ucDataGridView1.RowType = m_rowType;
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
                this.ucDataGridView1.Columns = value;
            }
        }
        /// <summary>
        /// The m data source
        /// </summary>
        private List<object> m_dataSource = null;
        /// <summary>
        /// 数据源
        /// </summary>
        /// <value>The data source.</value>
        [Description("数据源"), Category("自定义")]
        public List<object> DataSource
        {
            get { return m_dataSource; }
            set { m_dataSource = value; }
        }

        /// <summary>
        /// The string last search text
        /// </summary>
        private string strLastSearchText = string.Empty;
      
        /// <summary>
        /// Initializes a new instance of the <see cref="UCComboxGridPanel" /> class.
        /// </summary>
        public UCComboxGridPanel()
        {
            InitializeComponent();
            this.txtSearch.txtInput.TextChanged += txtInput_TextChanged;
            this.ucDataGridView1.ItemClick += ucDataGridView1_ItemClick;
            m_page.ShowSourceChanged += m_page_ShowSourceChanged;
        }

      

        /// <summary>
        /// Handles the ItemClick event of the ucDataGridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewEventArgs" /> instance containing the event data.</param>
        void ucDataGridView1_ItemClick(object sender, DataGridViewEventArgs e)
        {
            if (ItemClick != null)
            {
                ItemClick((sender as IDataGridViewRow).DataSource, null);
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtInput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void txtInput_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Enabled = true;
        }

        /// <summary>
        /// Handles the Load event of the UCComboxGridPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void UCComboxGridPanel_Load(object sender, EventArgs e)
        {
            m_page.DataSource = m_dataSource;
            this.ucDataGridView1.DataSource = m_page.GetCurrentSource();
        }

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Searches the specified string text.
        /// </summary>
        /// <param name="strText">The string text.</param>
        private void Search(string strText)
        {
            m_page.StartIndex = 0;
            if (!string.IsNullOrEmpty(strText))
            {
                strText = strText.ToLower().Trim();
                List<object> lst = m_dataSource.FindAll(p => m_columns.Any(c => (c.Format == null ? (p.GetType().GetProperty(c.DataField).GetValue(p, null).ToStringExt()) : c.Format(p.GetType().GetProperty(c.DataField).GetValue(p, null))).ToLower().Contains(strText)));
                m_page.DataSource = lst;
            }
            else
            {
                m_page.DataSource = m_dataSource;
            }
            m_page.Reload();
        }

        void m_page_ShowSourceChanged(object currentSource)
        {
            this.ucDataGridView1.DataSource = currentSource;
        }
    }
}
