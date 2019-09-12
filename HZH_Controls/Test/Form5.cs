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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                MindMappingItemEntity entity = new MindMappingItemEntity()
                {
                    ID = "1",
                    Text = "根节点超长占位符超长占位符超长占位符超长占位符\n节点1",
                                      ForeColor = Color.White,
                    IsExpansion = true
                };
                MindMappingItemEntity[] cs1 = new MindMappingItemEntity[5];
                for (int i = 0; i < 5; i++)
                {
                    cs1[i] = new MindMappingItemEntity()
                    {
                        ID = "1_" + i,
                        Text = "子节点\n节点1_" + i + ((i % 2) == 0 ? "超长占位符超长占位符" : "超长占位符超长占位符超长占位符超长占位符"),
                      
                        ForeColor = Color.White,
                        IsExpansion = (i % 2) == 0
                    };
                    MindMappingItemEntity[] cs2 = new MindMappingItemEntity[5];
                    for (int j = 0; j < 5; j++)
                    {
                        cs2[j] = new MindMappingItemEntity()
                        {
                            ID = "1_" + i + "_" + j,
                            Text = "孙节点\n节点1_" + i + "_" + j + ((j % 2) == 0 ? "超长占位符超长占位符" : "超长占位符超长占位符超长占位符超长占位符"),
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

        private void ucMindMappingPanel1_ItemClicked(object sender, EventArgs e)
        {
            HZH_Controls.Forms.FrmTips.ShowTipsSuccess(this, ucMindMappingPanel1.SelectEntity.Text);
        }

        private void aaaaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucMindMappingPanel1.SelectEntity.Text = Guid.NewGuid().ToString();
            ucMindMappingPanel1.Refresh();
        }
    }
}
