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
    public partial class UCTestPieCharts : UserControl
    {
        public UCTestPieCharts()
        {
            InitializeComponent();
        }

        private void UCTestPieCharts_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            var pieItems = new PieItem[5];

            for (int i = 0; i < 5; i++)
            {
                pieItems[i] = new PieItem
                {
                    Name = "Source" + (i + 1),
                    Value = r.Next(10, 100)
                };
            }
            this.ucPieChart1.SetDataSource(pieItems);
            this.ucPieChart2.SetDataSource(pieItems);
        }
    }
}
