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
    public partial class UCTestTransfer : UserControl
    {
        public UCTestTransfer()
        {
            InitializeComponent();
        }

        private void UCTestTransfer_Load(object sender, EventArgs e)
        {
            DataGridViewColumnEntity[] lstLeftCulumns = new DataGridViewColumnEntity[1];
            lstLeftCulumns[0] = new DataGridViewColumnEntity() { DataField = "Value", HeadText = "列表一", TextAlign= ContentAlignment.MiddleLeft };

            DataGridViewColumnEntity[] lstRightCulumns = new DataGridViewColumnEntity[1];
            lstRightCulumns[0] = new DataGridViewColumnEntity() { DataField = "Value", HeadText = "列表二", TextAlign = ContentAlignment.MiddleLeft };

            this.ucTransfer1.LeftColumns = lstLeftCulumns;
            this.ucTransfer1.RightColumns = lstRightCulumns;

            var lstItems = new TestModel[5];
            for (int i = 0; i < 5; i++)
            {
                lstItems[i] = new TestModel() { Key = i, Value = "选择项" + i };
            }

            this.ucTransfer1.LeftDataSource = lstItems;
            this.ucTransfer1.RightDataSource = new TestModel[0];

        }

        private class TestModel
        {
            public int Key { get; set; }
            public string Value { get; set; }
        }
    }
}
