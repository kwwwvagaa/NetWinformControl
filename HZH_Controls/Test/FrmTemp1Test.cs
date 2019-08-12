using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Controls;

namespace Test
{
    public partial class FrmTemp1Test : HZH_Controls.Forms.FrmTemp1
    {
        public FrmTemp1Test()
        {
            InitializeComponent();
        }

        private void FrmTemp1Test_Load(object sender, EventArgs e)
        {           
            List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "编号", Width = 70, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "姓名", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Age", HeadText = "年龄", Width = 50, WidthType = SizeType.Percent });
            this.ucDataGridView1.Columns = lstCulumns;
            this.ucDataGridView1.IsShowCheckBox = true;
            List<object> lstSource = new List<object>();
            for (int i = 0; i < 20; i++)
            {
                TestModel model = new TestModel()
                {
                    ID = i.ToString(),
                    Age = 3 * i,
                    Name = "姓名——" + i
                };
                lstSource.Add(model);
            }

            UCPagerControl page = new UCPagerControl();
            page.DataSource = lstSource;
            this.ucDataGridView1.Page = page;
            this.ucDataGridView1.First();
        }
    }

    public class TestModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
