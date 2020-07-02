using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.UC
{
    [ToolboxItem(false)]
    public partial class UCTestScrollbar : UserControl
    {
        Point pt;
        public UCTestScrollbar()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            for (int i = 0; i < 10; i++)
            {
                dt.Columns.Add(i.ToString());
            }
            for (int i = 0; i < 50; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < 10; j++)
                {
                    dr[j] =i+""+ j;
                }
                dt.Rows.Add(dr);
            }
            this.dataGridView1.DataSource = dt;
        }

        private void UCTestScrollbar_Load(object sender, EventArgs e)
        {

        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {

        }

    }
}
