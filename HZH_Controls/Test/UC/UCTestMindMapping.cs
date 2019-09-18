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
    public partial class UCTestMindMapping : UserControl
    {
        public UCTestMindMapping()
        {
            InitializeComponent();
        }

        private void UCTestMindMapping_Load(object sender, EventArgs e)
        {
            try
            {
                MindMappingItemEntity entity = new MindMappingItemEntity()
                {
                    ID = "1",
                    Text = "节点1",
                    ForeColor = Color.White,
                    IsExpansion = true
                };
                MindMappingItemEntity[] cs1 = new MindMappingItemEntity[5];
                for (int i = 0; i < 5; i++)
                {
                    cs1[i] = new MindMappingItemEntity()
                    {
                        ID = "1_" + i,
                        Text = "子节点" + i,

                        ForeColor = Color.White,
                        IsExpansion = (i % 2) == 0
                    };
                    MindMappingItemEntity[] cs2 = new MindMappingItemEntity[5];
                    for (int j = 0; j < 5; j++)
                    {
                        cs2[j] = new MindMappingItemEntity()
                        {
                            ID = "1_" + i + "_" + j,
                            Text = "孙节点" + i,
                            BackColor = Color.Green,
                            ForeColor = Color.White
                        };
                    }
                    cs1[i].Childrens = cs2;
                }
                entity.Childrens = cs1;
                this.ucMindMappingPanel1.DataSource = entity;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "错误");
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucMindMappingPanel1.SelectEntity.Text = "测试随机文字" + Guid.NewGuid().ToString();
            ucMindMappingPanel1.Refresh();
        }
    }
}
