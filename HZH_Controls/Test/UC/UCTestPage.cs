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
    public partial class UCTestPage : UserControl
    {
        public UCTestPage()
        {
            InitializeComponent();
        }

        private void UCTestPage_Load(object sender, EventArgs e)
        {
            List<object> lstPage2 = new List<object>();
            for (int i = 0; i < 1000; i++)
            {
                lstPage2.Add(i);
            }
            ucPagerControl21.PageSize = 10;
            ucPagerControl21.DataSource = lstPage2;

            this.ucPagerControl1.PageSize = 10;
            this.ucPagerControl1.StartIndex = 0;
            ucPagerControl1.DataSource = lstPage2;
            this.ucPagerControl1.FirstPage();


            ucPagerControl22.PageCount = 10;
            ucPagerControl22.PageIndex = 1;

            ucPagerControl2.PageCount = 10;
            ucPagerControl2.PageIndex = 1;
        }
    }
}
