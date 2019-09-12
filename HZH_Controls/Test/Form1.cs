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
          var bit=  HZH_Controls.FontImages.GetImage(FontIcons.A_fa_adn, 32, Color.FromArgb(255, 77, 59));
          bit.Save("d:\\3.jpg");
            for (int i = 0; i < 3; i++)
            {
                TreeNode tn = new TreeNode("  父节点" + i);
                for (int j = 0; j < 3; j++)
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
                lstMenu.Add(item);
            }
            for (int i = 2; i < 4; i++)
            {
                MenuItemEntity item = new MenuItemEntity()
                {
                    Key = "p" + i.ToString(),
                    Text = "菜单项" + i,
                    DataSource = "这里编写一些自定义的数据源，用于扩展"
                };
                lstMenu.Add(item);
            }
            this.ucMenu1.MenuStyle = MenuStyle.Top;
            this.ucMenu1.DataSource = lstMenu;


            List<object> lstPage2 = new List<object>();
            for (int i = 0; i < 1000; i++)
            {
                lstPage2.Add(i);
            }
            ucPagerControl21.PageSize = 10;
            ucPagerControl21.DataSource = lstPage2;

            ucBtnsGroup1.DataSource = new Dictionary<string, string>() { { "1", "男" }, { "0", "女" } };
            ucBtnsGroup2.IsMultiple = true;
            ucBtnsGroup2.DataSource = new Dictionary<string, string>() { { "1", "河南" }, { "2", "北京" }, { "3", "湖南" }, { "4", "上海" } };
            ucBtnsGroup2.SelectItem = new List<string>() { "2", "3" };


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
                TestModel model = new TestModel()
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
                new Dictionary<string, string>() { { "电话", "^1\\d{0,10}$" }, { "身份证号", "^\\d{0,18}$" } },
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
            new Form2().Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new FrmTestListView().Show();
        }

        private void ucDropDownBtn1_BtnClick(object sender, EventArgs e)
        {
            HZH_Controls.Forms.FrmTips.ShowTipsSuccess(this, sender.ToString());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new Form4().Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            new Form6().Show();
        }

    }
}
