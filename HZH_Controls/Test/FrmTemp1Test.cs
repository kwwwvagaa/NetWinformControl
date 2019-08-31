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
    public partial class FrmTemp1Test : HZH_Controls.Forms.FrmBack
    {
        public FrmTemp1Test()
        {
            InitializeComponent();
        }

        private void FrmTemp1Test_Load(object sender, EventArgs e)
        {
            this.ucDataGridView1.RowType = typeof(UCDataGridViewTreeRow);
            this.ucDataGridView1.IsAutoHeight = true;

            List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "编号", Width = 70, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "姓名", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Age", HeadText = "年龄", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Birthday", HeadText = "生日", Width = 50, WidthType = SizeType.Percent, Format = (a) => { return ((DateTime)a).ToString("yyyy-MM-dd"); } });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Sex", HeadText = "性别", Width = 50, WidthType = SizeType.Percent, Format = (a) => { return ((int)a) == 0 ? "女" : "男"; } });
            this.ucDataGridView1.Columns = lstCulumns;
            this.ucDataGridView1.IsShowCheckBox = true;
            List<object> lstSource = new List<object>();
            for (int i = 0; i < 50; i++)
            {
                TestModel model = new TestModel()
                {
                    ID = i.ToString(),
                    Age = 3 * i,
                    Name = "姓名——" + i,
                    Birthday = DateTime.Now.AddYears(-10),
                    Sex = i % 2
                };
                lstSource.Add(model);
                //AddChilds(model, 5);
            }

            var page = new UCPagerControl2();
            page.DataSource = lstSource;
            this.ucDataGridView1.Page = page;
            this.ucDataGridView1.First();

            //this.ucDataGridView1.DataSource = lstSource;
        }

        private void AddChilds(TestModel tm, int intCount)
        {
            if (intCount <= 0)
                return;
            tm.Childrens = new List<TestModel>();
            for (int i = 0; i < 5; i++)
            {
                TestModel model = new TestModel()
                {
                    ID = i.ToString(),
                    Age = 3 * i,
                    Name = intCount + "——" + i,
                    Birthday = DateTime.Now.AddYears(-10),
                    Sex = i % 2
                };
                tm.Childrens.Add(model);
                AddChilds(model, intCount - 1);
            }
        }

        private void FrmTemp1Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            var v = this.ucDataGridView1.SelectRows;
        }
    }

    public class TestModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public int Sex { get; set; }
        public List<TestModel> Childrens { get; set; }
    }
}
