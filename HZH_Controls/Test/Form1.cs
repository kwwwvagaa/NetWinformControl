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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                TreeNode tr = new TreeNode("父节点" + i);
                this.treeViewEx1.Nodes.Add(tr);
                for (int j = 0; j < 5; j++)
                {
                    tr.Nodes.Add("  子节点" + j);
                }
            }

            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < 10; i++)
            {
                lst.Add(new KeyValuePair<string, string>(i.ToString(), "元素" + i));
            }

            this.ucComboBox1.Source = lst;
            this.ucComboBox1.SelectedIndex = 1;
            this.ucComboBox2.Source = lst;
            this.ucComboBox2.SelectedIndex = 2;


            this.ucHorizontalList1.DataSource = lst;

            List<ListEntity> lstList = new List<ListEntity>();
            for (int i = 0; i < 10; i++)
            {
                lstList.Add(new ListEntity()
                {
                    ID = i.ToString(),
                    ShowMoreBtn = false,
                    Source = i,
                    Title = "大标题" + i,
                    Title2 = "小标题" + i
                });
            }
            this.ucListExt1.SetList(lstList);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.processExt1.Value++;
            if (this.processExt1.Value == 100)
                this.processExt1.Value = 0;
        }

        private void treeViewEx1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            HZH_Controls.Forms.FrmTips.ShowTipsInfo(this, "你选中了" + e.Node.Text);
        }

        private void ucListExt1_ItemClick(UCListItemExt item)
        {
            HZH_Controls.Forms.FrmTips.ShowTipsInfo(this, "你选中了" + item.Title);

        }

        private void ucComboBox2_SelectedChangedEvent(object sender, EventArgs e)
        {
            HZH_Controls.Forms.FrmTips.ShowTipsInfo(this, "你选中了" + ucComboBox2.SelectedText);

        }
    }
}
