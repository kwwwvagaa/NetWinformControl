using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Controls;

namespace Test.UC
{
    [ToolboxItem(false)]
    public partial class UCTestListView : UserControl
    {
        public UCTestListView()
        {
            InitializeComponent();
            this.ucListView1.SizeChanged += ucListView1_SizeChanged;
        }

        void ucListView1_SizeChanged(object sender, EventArgs e)
        {
            if (this.ucListView1.Page != null)
            {
                this.ucListView1.DataSource = this.ucListView1.Page.GetCurrentSource();
            }
        }

        private void UCTestListView_Load(object sender, EventArgs e)
        {
            List<object> lstSource = new List<object>();
            for (int i = 0; i < 200; i++)
            {
                lstSource.Add("项-" + i);
            }

            #region 使用分页控件    English:Using Paging Control
            var page = new UCPagerControl2();
            this.ucListView1.Page = page;
            page.DataSource = lstSource;
            #endregion

            #region 不使用分页控件    English:Do not use paging controls
            //this.ucListView1.DataSource = lstSource;
            #endregion
        }
    }
}
