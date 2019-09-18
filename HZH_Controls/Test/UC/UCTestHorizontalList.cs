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
    public partial class UCTestHorizontalList : UserControl
    {
        public UCTestHorizontalList()
        {
            InitializeComponent();
        }

        private void UCTestHorizontalList_Load(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> lstHL = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < 30; i++)
            {
                lstHL.Add(new KeyValuePair<string, string>(i.ToString(), "选项" + i));
            }

            this.ucHorizontalList1.DataSource = lstHL;
            this.ucHorizontalList2.DataSource = lstHL;
        }
    }
}
