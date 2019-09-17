using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class FrmBarCharts : Form
    {
        public FrmBarCharts()
        {
            InitializeComponent();
        }
        private Random random = new Random();
        private void FrmBarCharts_Load(object sender, EventArgs e)
        {
            this.ucBarChart1.SetDataSource(new double[] { random.Next(50, 100), random.Next(50, 100), random.Next(50, 100), random.Next(50, 100), random.Next(50, 100) });
            this.ucBarChart2.SetDataSource(new double[] { random.Next(50, 100), random.Next(50, 100), random.Next(50, 100), random.Next(50, 100), random.Next(50, 100) }, new string[] { "张三", "李四", "王五", "赵六", "田七" });
            this.ucBarChart3.SetDataSource(new double[] { random.Next(50, 100), random.Next(50, 100), random.Next(50, 100), random.Next(50, 100), random.Next(50, 100) }, new string[] { "张三", "李四", "王五", "赵六", "田七" });

            this.ucBarChart4.SetDataSource(new double[] { random.Next(50, 100), random.Next(50, 100), random.Next(50, 100), random.Next(50, 100), random.Next(50, 100) }, new string[] { "张三", "李四", "王五", "赵六", "田七" });
            this.ucBarChart4.AddAuxiliaryLine(60, Color.Red, "及格线超长占位符");

            this.ucBarChart5.SetDataSource(new double[] { random.Next(50, 100), random.Next(50, 100), random.Next(50, 100), random.Next(50, 100), random.Next(50, 100) }, new string[] { "张三", "李四", "王五", "赵六", "田七" });
            this.ucBarChart5.AddAuxiliaryLine(50, Color.Black, "及格线");

           
            var ds = new double[5][];
            for (int i = 0; i < ds.Length; i++)
            {
                ds[i] = new double[] { random.Next(50, 100), random.Next(50, 100), random.Next(50, 100) };
            }
            this.ucBarChart6.BarChartItems = new HZH_Controls.Controls.BarChartItem[] { new HZH_Controls.Controls.BarChartItem(Color.Red, "语文"), new HZH_Controls.Controls.BarChartItem(Color.Blue, "英语"), new HZH_Controls.Controls.BarChartItem(Color.Orange, "数学") };
            this.ucBarChart6.SetDataSource(ds, new string[] { "张三", "李四", "王五", "赵六", "田七" });
            this.ucBarChart6.AddAuxiliaryLine(60, Color.Black);

            var ds2 = new List<double[]>();
            for (int i = 0; i < 20; i++)
            {
                ds2.Add(new double[] { random.Next(800, 2000), random.Next(100, 200) });
            }
            var titles = new List<string>();
            double dblSum = ds2.Sum(p=>p[0]);
            for (int i = 0; i < ds2.Count; i++)
            {
                titles.Add("员工" + (i + 1) + "\n" + (ds2[i][0] / dblSum).ToString("0.0%"));
            }
            this.ucBarChart7.BarChartItems = new HZH_Controls.Controls.BarChartItem[] { new HZH_Controls.Controls.BarChartItem(Color.Green, "合格"), new HZH_Controls.Controls.BarChartItem(Color.Red, "次品") };
            this.ucBarChart7.SetDataSource(ds2.ToArray(), titles.ToArray());
            this.ucBarChart7.AddAuxiliaryLine(1000, Color.Black, "标准线");
        }
    }
}
