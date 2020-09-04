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
    public partial class UCTestTreeGridTable : UserControl
    {
        public UCTestTreeGridTable()
        {
            InitializeComponent();
        }


        private void UCTestTreeGridTable_Load(object sender, EventArgs e)
        {
            this.ucDataGridView1.RowType = typeof(UCDataGridViewTreeRow);
            List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "编号", Width = 100, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "姓名", Width = 150, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Age", HeadText = "年龄", Width = 150, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Birthday", HeadText = "生日", Width = 150, WidthType = SizeType.Absolute, Format = (a) => { return ((DateTime)a).ToString("yyyy-MM-dd"); } });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Sex", HeadText = "性别", Width = 150, WidthType = SizeType.Absolute, Format = (a) => { return ((int)a) == 0 ? "女" : "男"; } });
            this.ucDataGridView1.Columns = lstCulumns;
            this.ucDataGridView1.IsShowCheckBox = true;
            List<object> lstSource = new List<object>();
            for (int i = 0; i < 50; i++)
            {
                TestGridModel model = new TestGridModel()
                {
                    ID = i.ToString(),
                    Age = 3 * i,
                    Name = "姓名——" + i,
                    Birthday = DateTime.Now.AddYears(-10),
                    Sex = i % 2
                };
                lstSource.Add(model);
                AddChilds(model, 5);
            }

            this.ucDataGridView1.DataSource = lstSource;
        }

        private void AddChilds(TestGridModel tm, int intCount)
        {
            if (intCount <= 0)
                return;
            tm.Childrens = new List<TestGridModel>();
            for (int i = 0; i < 5; i++)
            {
                TestGridModel model = new TestGridModel()
                {
                    ID = i.ToString(),
                    Age = 3 * i,
                    Name = "姓名——" + i,
                    Birthday = DateTime.Now.AddYears(-10),
                    Sex = i % 2
                };
                tm.Childrens.Add(model);
                AddChilds(model, intCount - 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c = this.ucDataGridView1.SelectRows.Count;
        }
    }
}
