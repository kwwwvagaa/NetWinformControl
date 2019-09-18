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
    public partial class UCTestForms : UserControl
    {
        public UCTestForms()
        {
            InitializeComponent();
        }

        private void UCForms_Load(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> lstCom = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < 5; i++)
            {
                lstCom.Add(new KeyValuePair<string, string>(i.ToString(), "选项" + i));
            }

            this.ucComboBox1.Source = lstCom;
            this.ucComboBox2.Source = lstCom;
            this.ucComboBox1.SelectedIndex = 1;
            this.ucComboBox2.SelectedIndex = 1;

            List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "编号", Width = 70, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "姓名", Width = 100, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Age", HeadText = "年龄", Width = 100, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Birthday", HeadText = "生日", Width = 120, WidthType = SizeType.Absolute, Format = (a) => { return ((DateTime)a).ToString("yyyy-MM-dd"); } });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Sex", HeadText = "性别", Width = 100, WidthType = SizeType.Absolute, Format = (a) => { return ((int)a) == 0 ? "女" : "男"; } });
            this.ucComboxGrid1.GridColumns = lstCulumns;
            List<object> lstSourceGrid = new List<object>();
            for (int i = 0; i < 100; i++)
            {
                TestGridModel model = new TestGridModel()
                {
                    ID = i.ToString(),
                    Age = 3 * i,
                    Name = "姓名——" + i,
                    Birthday = DateTime.Now.AddYears(-10),
                    Sex = i % 2
                };
                lstSourceGrid.Add(model);
            }
            this.ucComboxGrid1.GridDataSource = lstSourceGrid;
        }
    }
}
