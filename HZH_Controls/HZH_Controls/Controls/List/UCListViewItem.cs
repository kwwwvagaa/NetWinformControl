// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCListViewItem.cs
// 作　　者：HZH
// 创建日期：2019-08-31 16:03:51
// 功能描述：UCListViewItem    English:UCListViewItem
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

namespace HZH_Controls.Controls
{
    [ToolboxItem(false)]
    public partial class UCListViewItem : UCControlBase, IListViewItem
    {
        private object m_dataSource;
        public object DataSource
        {
            get
            {
                return m_dataSource;
            }
            set
            {
                m_dataSource = value;
                lblTitle.Text = value.ToString();
            }
        }

        public event EventHandler SelectedItemEvent;
        public UCListViewItem()
        {
            InitializeComponent();
            lblTitle.MouseDown += lblTitle_MouseDown;
        }

        void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedItemEvent != null)
            {
                SelectedItemEvent(this, e);
            }
        }

        public void SetSelected(bool blnSelected)
        {
            if (blnSelected)
                this.FillColor = Color.FromArgb(255, 247, 245);
            else
                this.FillColor = Color.White;
            this.Refresh();
        }
    }
}
