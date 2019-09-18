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
    public partial class UCTestMenu : UserControl
    {
        public UCTestMenu()
        {
            InitializeComponent();
        }

        private void UCTestMenu_Load(object sender, EventArgs e)
        {
            List<MenuItemEntity> lstMenu1 = new List<MenuItemEntity>();
            for (int i = 0; i < 2; i++)
            {
                MenuItemEntity item = new MenuItemEntity()
                {
                    Key = "p" + i.ToString(),
                    Text = "菜单项" + i,
                    DataSource = "这里编写一些自定义的数据源，用于扩展"
                };
                item.Childrens = new List<MenuItemEntity>();
                for (int j = 0; j < 5; j++)
                {
                    MenuItemEntity item2 = new MenuItemEntity()
                    {
                        Key = "c" + i.ToString(),
                        Text = "菜单子项" + i + "-" + j,
                        DataSource = "这里编写一些自定义的数据源，用于扩展"
                    };
                    item.Childrens.Add(item2);
                }
                lstMenu1.Add(item);
            }
            for (int i = 2; i < 4; i++)
            {
                MenuItemEntity item = new MenuItemEntity()
                {
                    Key = "p" + i.ToString(),
                    Text = "菜单项" + i,
                    DataSource = "这里编写一些自定义的数据源，用于扩展"
                };
                lstMenu1.Add(item);
            }
            this.ucMenu1.DataSource = lstMenu1;

            this.ucMenu2.DataSource = lstMenu1;
        }
    }
}
