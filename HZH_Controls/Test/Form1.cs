using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Controls;
using HZH_Controls.Forms;
using HZH_Controls;
using System.Threading;

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
            for (int i = 0; i < 5; i++)
            {
                TreeNode tn = new TreeNode("  父节点" + i);
                for (int j = 0; j < 5; j++)
                {
                    tn.Nodes.Add("    子节点" + j);
                }
                this.treeViewEx1.Nodes.Add(tn);
            }

            List<KeyValuePair<string, string>> lstCom = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < 5; i++)
            {
                lstCom.Add(new KeyValuePair<string, string>(i.ToString(), "选项" + i));
            }

            this.ucComboBox1.Source = lstCom;
            this.ucComboBox2.Source = lstCom;
            this.ucComboBox1.SelectedIndex = 1;
            this.ucComboBox2.SelectedIndex = 1;


            List<ListEntity> lst = new List<ListEntity>();
            for (int i = 0; i < 5; i++)
            {
                lst.Add(new ListEntity()
                {
                    ID = i.ToString(),
                    Title = "选项" + i,
                    ShowMoreBtn = true,
                    Source = i
                });
            }
            this.ucListExt1.SetList(lst);

            List<KeyValuePair<string, string>> lstHL = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < 30; i++)
            {
                lstHL.Add(new KeyValuePair<string, string>(i.ToString(), "选项" + i));
            }

            this.ucHorizontalList1.DataSource = lstHL;

            List<MenuItemEntity> lstMenu = new List<MenuItemEntity>();
            for (int i = 0; i < 20; i++)
            {
                MenuItemEntity item = new MenuItemEntity()
                {
                    Key = "p" + i.ToString(),
                    Text = "菜单项" + i,
                    DataSource = "这里编写一些自定义的数据源，用于扩展"
                };
                item.Childrens = new List<MenuItemEntity>();
                for (int j = 0; j < 20; j++)
                {
                    MenuItemEntity item2 = new MenuItemEntity()
                    {
                        Key = "c" + i.ToString(),
                        Text = "菜单子项" + i + "-" + j,
                        DataSource = "这里编写一些自定义的数据源，用于扩展"
                    };
                    item.Childrens.Add(item2);
                }
                lstMenu.Add(item);
            }
            this.ucMenu1.MenuStyle = MenuStyle.Top;  
            this.ucMenu1.DataSource = lstMenu;


            List<object> lstPage2 = new List<object>();
            for (int i = 0; i < 100; i++)
            {
                lstPage2.Add(i);
            }
            ucPagerControl21.PageSize = 10;
            ucPagerControl21.DataSource = lstPage2;

            ucBtnsGroup1.DataSource = new Dictionary<string, string>() { { "1", "男" }, { "0", "女" } };
            ucBtnsGroup2.IsMultiple = true;
            ucBtnsGroup2.DataSource = new Dictionary<string, string>() { { "1", "河南" }, { "2", "北京" }, { "3", "湖南" }, { "4", "上海" } };
            ucBtnsGroup2.SelectItem = new List<string>() { "2","3"};
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (FrmDialog.ShowDialog(this, "是否再显示一个没有取消按钮的提示框？", "模式窗体测试", true) == System.Windows.Forms.DialogResult.OK)
            {
                FrmDialog.ShowDialog(this, "这是一个没有取消按钮的提示框", "模式窗体测试");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmInputs frm = new FrmInputs("动态多输入窗体测试",
                new string[] { "姓名", "电话", "身份证号", "住址" },
                new Dictionary<string, HZH_Controls.TextInputType>() { { "电话", HZH_Controls.TextInputType.Regex }, { "身份证号", HZH_Controls.TextInputType.Regex } },
                new Dictionary<string, string>() { { "电话", "^1\\d{10}$" }, { "身份证号", "^\\d{18}$" } },
                new Dictionary<string, KeyBoardType>() { { "电话", KeyBoardType.UCKeyBorderNum }, { "身份证号", KeyBoardType.UCKeyBorderNum } },
                new List<string>() { "姓名", "电话", "身份证号" });
            frm.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmTips.ShowTipsError(this, "Error提示信息");
            FrmTips.ShowTipsInfo(this, "Info提示信息");
            FrmTips.ShowTipsSuccess(this, "Success提示信息");
            FrmTips.ShowTipsWarning(this, "Warning提示信息");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmTemp1Test frm = new FrmTemp1Test();
            frm.ShowDialog(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ControlHelper.ThreadRunExt(this, () =>
            {
                Thread.Sleep(5000);
                ControlHelper.ThreadInvokerControl(this, () =>
                {
                    FrmTips.ShowTipsSuccess(this, "FrmWaiting测试");
                });
            }, null, this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmOKCancel1Test frm = new FrmOKCancel1Test();
            frm.ShowDialog(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmOKCancel2Test frm = new FrmOKCancel2Test();
            frm.ShowDialog(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmWithTitleTest frm = new FrmWithTitleTest();
            frm.ShowDialog(this);
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

    }
}
