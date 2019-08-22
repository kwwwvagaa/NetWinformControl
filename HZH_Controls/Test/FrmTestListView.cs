using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Forms;
using HZH_Controls.Controls;

namespace Test
{
    public partial class FrmTestListView : FrmBack
    {
        public FrmTestListView()
        {
            InitializeComponent();
        }

        private void FrmTestListView_Load(object sender, EventArgs e)
        {
            List<object> lstSource = new List<object>();
            for (int i = 0; i < 200; i++)
            {
                lstSource.Add("项-" + i);
            }
            var page = new UCPagerControl2();
            page.DataSource = lstSource;
            this.ucListView1.Page = page;
            //this.ucListView1.DataSource = lstSource;
        }
    }
}
