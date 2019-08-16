# NetWinform自定义控件

#### 介绍

c#winfrom自定义控件，`对触屏具有更好的操作支持`，项目是基于framework4.0，完全原生控件开发，`没有使用任何第三方控件`，你可以放心的用在你的项目中。

博客地址：[https://www.cnblogs.com/bfyx](https://www.cnblogs.com/bfyx)

欢迎前来交流探讨： 企鹅群568015492 [![企鹅群568015492](//pub.idqqimg.com/wpa/images/group.png "企鹅群568015492")](//shang.qq.com/wpa/qunwpa?idkey=6e08741ef16fe53bf0314c1c9e336c4f626047943a8b76bac062361bab6b4f8d)

#### 如果我的代码对您有用，请打赏一点吧，谢谢，您的打赏是我的动力

#### 源码仅用于交流学习，开源协议为[GPL-3.0](https://gitee.com/kwwwvagaa/net_winform_custom_control/blob/master/LICENSE)，如商业使用请进群联系群主授权

#### 样例

##### 1、提示窗效果图

![样例图片](https://images.gitee.com/uploads/images/2019/0808/142043_887cb342_301547.png "提示框1.png")
![样例图片](https://images.gitee.com/uploads/images/2019/0808/142050_1f5588a0_301547.png "提示框2.png")

``` csharp
if (FrmDialog.ShowDialog(this, "是否再显示一个没有取消按钮的提示框？", "模式窗体测试", true) == System.Windows.Forms.DialogResult.OK)
{
    FrmDialog.ShowDialog(this, "这是一个没有取消按钮的提示框", "模式窗体测试");
}
```

##### 2、多输入窗体

![样例图片](https://images.gitee.com/uploads/images/2019/0808/142218_4c506097_301547.png "多输入窗体.png")

``` csharp
 FrmInputs frm = new FrmInputs("动态多输入窗体测试",
                new string[] { "姓名", "电话", "身份证号", "住址" },
                new Dictionary<string, HZH_Controls.TextInputType>() { { "电话", HZH_Controls.TextInputType.Regex }, { "身份证号", HZH_Controls.TextInputType.Regex } },
                new Dictionary<string, string>() { { "电话", "^1\\d{10}$" }, { "身份证号", "^\\d{18}$" } },
                new Dictionary<string, KeyBoardType>() { { "电话", KeyBoardType.UCKeyBorderNum }, { "身份证号", KeyBoardType.UCKeyBorderNum } },
                new List<string>() { "姓名", "电话", "身份证号" });
frm.ShowDialog(this);
```

``` csharp
/// <summary>
/// 功能描述:构造函数
/// 作　　者:HZH
/// 创建日期:2019-08-05 10:57:26
/// 任务编号:POS
/// </summary>
/// <param name="strTitle">窗体标题</param>
/// <param name="args">输入项名称</param>
/// <param name="inTypes">输入项对应输入类型，key:输入项名称，如不设置默认不控制输入</param>
/// <param name="regexs">输入项对应正则规则，当imTypes=Regex时有效，key:输入项名称，如不设置默认不控制输入</param>
/// <param name="keyBoards">文本框键盘，key:输入项名称，如不设置默认英文键盘</param>
/// <param name="mastInputs">必填输入项名称</param>
/// <param name="defaultValues">输入项默认值，key:输入项名称</param>
public FrmInputs(
    string strTitle,
    string[] inPutLabels,
    Dictionary<string, TextInputType> inTypes = null,
    Dictionary<string, string> regexs = null,
    Dictionary<string, HZH_Controls.Controls.KeyBoardType> keyBoards = null,
    List<string> mastInputs = null,
    Dictionary<string, string> defaultValues = null)
```

##### 3、Temp1窗体

![样例图片](https://images.gitee.com/uploads/images/2019/0808/143753_15610b9f_301547.png "temp.png")

``` csharp
//新建窗体FrmTemp1Test继承HZH_Controls.Forms.FrmTemp1
FrmTemp1Test frm = new FrmTemp1Test();
frm.ShowDialog(this);
```

##### 4、有确定取消的窗体1

![样例图片](https://images.gitee.com/uploads/images/2019/0808/144723_55252cf2_301547.png "oc1.png")

``` csharp
//新建窗体FrmOKCancel1Test继承HZH_Controls.Forms.FrmWithOKCancel1
FrmOKCancel1Test frm = new FrmOKCancel1Test();
frm.ShowDialog(this);
```

##### 5、有确定取消的窗体2

![样例图片](https://images.gitee.com/uploads/images/2019/0808/145516_07d73ec0_301547.png "oc2.png")

``` csharp
//新建窗体FrmOKCancel2Test继承HZH_Controls.Forms.FrmWithOKCancel2
FrmOKCancel2Test frm = new FrmOKCancel2Test();
frm.ShowDialog(this);
```

##### 6、单标题窗体

![样例图片](https://images.gitee.com/uploads/images/2019/0808/145718_ff035712_301547.png "t.png")

``` csharp
//新建窗体FrmWithTitleTest继承HZH_Controls.Forms.FrmWithTitle
FrmWithTitleTest frm = new FrmWithTitleTest();
frm.ShowDialog(this);
```

##### 7、控件

![样例图片](https://images.gitee.com/uploads/images/2019/0808/153338_6d1de6b3_301547.png "control.png")

*文本框键盘效果*

![样例图片](https://images.gitee.com/uploads/images/2019/0808/153812_40d919ea_301547.png "k1.png")
![样例图片](https://images.gitee.com/uploads/images/2019/0808/153820_31e8fea6_301547.png "k2.png")
![样例图片](https://images.gitee.com/uploads/images/2019/0808/153829_37e4dff5_301547.png "k3.png")

*时间控件效果*

![样例图片](https://images.gitee.com/uploads/images/2019/0808/160404_b8cf7353_301547.png "time1.png")
![样例图片](https://images.gitee.com/uploads/images/2019/0808/160411_902d4f6d_301547.png "time2.png")
![样例图片](https://images.gitee.com/uploads/images/2019/0808/160418_c92391ba_301547.png "time3.png")

*下拉列表数据绑定*

``` csharp
//使用方法同原生ComboBox类似
List<KeyValuePair<string, string>> lstCom = new List<KeyValuePair<string, string>>();
for (int i = 0; i < 5; i++)
{
    lstCom.Add(new KeyValuePair<string, string>(i.ToString(), "选项" + i));
}

this.ucComboBox1.Source = lstCom;
this.ucComboBox2.Source = lstCom;
this.ucComboBox1.SelectedIndex = 1;
this.ucComboBox2.SelectedIndex = 1;
```

*树数据绑定*

``` csharp
//使用方法同原生Treeview相同，设置属性IsShowByCustomModel=true则启用自定义模式，否则为原始树
for (int i = 0; i < 5; i++)
{
    TreeNode tn = new TreeNode("  父节点" + i);
    for (int j = 0; j < 5; j++)
    {
        tn.Nodes.Add("    子节点" + j);
    }
    this.treeViewEx1.Nodes.Add(tn);
}
```

*列表数据绑定*

``` csharp
//可自定义颜色字体等
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
```

*横向列表数据绑定*

``` csharp
List<KeyValuePair<string, string>> lstHL = new List<KeyValuePair<string, string>>();
for (int i = 0; i < 30; i++)
{
    lstHL.Add(new KeyValuePair<string, string>(i.ToString(), "选项" + i));
}

this.ucHorizontalList1.DataSource = lstHL;
```

##### 8、Datagridview

![样例图片](https://images.gitee.com/uploads/images/2019/0812/105558_55920c3b_301547.png "table.png")

``` csharp
List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "编号", Width = 70, WidthType = SizeType.Absolute });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "姓名", Width = 50, WidthType = SizeType.Percent });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Age", HeadText = "年龄", Width = 50, WidthType = SizeType.Percent });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Birthday", HeadText = "生日", Width = 50, WidthType = SizeType.Percent, Format = (a) => { return ((DateTime)a).ToString("yyyy-MM-dd"); } });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Sex", HeadText = "性别", Width = 50, WidthType = SizeType.Percent, Format = (a) => { return ((int)a) == 0 ? "女" : "男"; } });
this.ucDataGridView1.Columns = lstCulumns;
this.ucDataGridView1.IsShowCheckBox = true;
List<object> lstSource = new List<object>();
for (int i = 0; i < 20; i++)
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
}

this.ucDataGridView1.DataSource = lstSource;
this.ucDataGridView1.First();
```

>当使用分页控件时，不再需要指定DataSource数据源属性，只需要指定翻页控件的DataSource属性即可

>如果预置的表格行无法满足你的需求，你还可以自定义行控件，具体做法为：
1. 新增自定义控件，实现接口IDataGridViewRow
2. 参照UCDataGridViewRow实现你自定义的行
3. 设置datagridview的RowType属性即可

>Page属性定义了翻页控件，如果UCPagerControl不满足你的需求，请自定义翻页控件并继承UCPagerControlBase，
当为空时不启用翻页控件，当启用翻页控件时每页将显示适当的数据，不再出现滚动条。

##### 9、翻页控件

![样例图片](https://images.gitee.com/uploads/images/2019/0812/105558_55920c3b_301547.png "table.png")

>另一种分页控件样式

![样例图片](https://images.gitee.com/uploads/images/2019/0815/164510_06392eeb_301547.png "page.png")

``` csharp
List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "编号", Width = 70, WidthType = SizeType.Absolute });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "姓名", Width = 50, WidthType = SizeType.Percent });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Age", HeadText = "年龄", Width = 50, WidthType = SizeType.Percent });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Birthday", HeadText = "生日", Width = 50, WidthType = SizeType.Percent, Format = (a) => { return ((DateTime)a).ToString("yyyy-MM-dd"); } });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Sex", HeadText = "性别", Width = 50, WidthType = SizeType.Percent, Format = (a) => { return ((int)a) == 0 ? "女" : "男"; } });
this.ucDataGridView1.Columns = lstCulumns;
this.ucDataGridView1.IsShowCheckBox = true;
List<object> lstSource = new List<object>();
for (int i = 0; i < 20; i++)
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
}

UCPagerControl page = new UCPagerControl();
//UCPagerControl2 page = new UCPagerControl2();
page.DataSource = lstSource;
this.ucDataGridView1.Page = page;
this.ucDataGridView1.First();
```

>如果UCPagerControl不满足你的需求，请自定义翻页控件并继承UCPagerControlBase，比如改变样式，增加逻辑等等

>如果需要下标从10开始的一页数据，可以设置StartIndex=10，然后调用GetCurrentSource（）即可，用法如下：

``` csharp
m_page.DataSource=lstSource;
m_page.PageSize = ShowCount;
m_page.StartIndex=10;
this.dgv.DataSource = m_page.GetCurrentSource();
```

>翻页控件可用于任何列表形式的控件，以上代码示例仅以datagridview说明用法,用法如下：
1. 设置属性DataSource数据源 
2. 设置属性PageSize每页显示数据量
3. 设置时间ShowSourceChanged，在时间中向目标控件设置当前页数据源
4. 如果页面加载后没有显示第一页数据，可以手动调用一下GetCurrentSource（）并赋值给目标控件即可，例如：

``` csharp
m_page.DataSource=lstSource;
m_page.PageSize = ShowCount;
this.dgv.DataSource = m_page.GetCurrentSource();
```

##### 10、气泡提示效果图(5种内置及自定义样式)

![样例图片](https://images.gitee.com/uploads/images/2019/0812/112144_6af9389c_301547.png "tips.png")

``` csharp
FrmTips.ShowTipsError(this, "Error提示信息");
FrmTips.ShowTipsInfo(this, "Info提示信息");
FrmTips.ShowTipsSuccess(this, "Success提示信息");
FrmTips.ShowTipsWarning(this, "Warning提示信息");
/*自定义可使用      
public static FrmTips ShowTips(
            Form frm,
            string strMsg,
            int intAutoColseTime = 0,
            bool blnShowCoseBtn = true,
            ContentAlignment align = ContentAlignment.BottomLeft,
            Point? point = null,
            TipsSizeMode mode = TipsSizeMode.Small,
            Size? size = null,
            TipsState state = TipsState.Default)
*/
```

##### 11、多线程操作等待

![样例图片](https://images.gitee.com/uploads/images/2019/0808/144201_932c5259_301547.png "waiting.png")
``` csharp
//此窗体一般用在耗时线程操作时显示等待动图，如下为多线程耗时操作时样例
ControlHelper.ThreadRunExt(this, () =>
{
    Thread.Sleep(5000);
    ControlHelper.ThreadInvokerControl(this, () =>
    {
        FrmTips.ShowTipsSuccess(this, "FrmWaiting测试");
    });
}, null, this);
//ControlHelper.ThreadRunExt为开启一个线程执行任务
//ControlHelper.ThreadInvokerControl为异步委托 调用控件
```

``` csharp
/// <summary>
/// 使用一个线程执行一个操作
/// </summary>
/// <param name="parent">父控件</param>
/// <param name="func">执行内容</param>
/// <param name="callback">执行后回调</param>
/// <param name="enableControl">执行期间禁用控件列表</param>
/// <param name="blnShowSplashScreen">执行期间是否显示等待提示</param>
/// <param name="strMsg">执行期间等待提示内容，默认为“正在处理，请稍候...”</param>
/// <param name="intSplashScreenDelayTime">延迟显示等待提示时间</param>
public static void ThreadRunExt(
    Control parent,
    Action func,
    Action<object> callback,
    Control[] enableControl = null,
    bool blnShowSplashScreen = true,
    string strMsg = null,
    int intSplashScreenDelayTime = 200)
```

##### 12、菜单导航控件

![样例图片](https://images.gitee.com/uploads/images/2019/0815/103949_9fdb0d12_301547.png "menu.png")

``` csharp
List<MenuItemEntity> lstMenu = new List<MenuItemEntity>();
for (int i = 0; i < 5; i++)
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
this.ucMenu1.DataSource = lstMenu;
```

>如果预置的样式无法满足你的需求，你还可以自定义节点控件，具体做法为：
1. 新增自定义控件，实现接口IMenuItem，可分别定义父节点和子节点
2. 参照UCMenuChildrenItem或UCMenuParentItem实现你自定义的节点
3. 设置UCMenu的父节点ParentItemType属性和子节点ChildrenItemType属性即可

>如果要修改节点样式，比如背景色等，可使用UCMenu的ParentItemStyles或ChildrenItemStyles，比如

``` csharp
this.ucMenu1.ParentItemStyles = new Dictionary<string, object>() { {"BackColor",Color.Red } }; 
this.ucMenu1.ChildrenItemStyles = new Dictionary<string, object>() { {"BackColor",Color.Yellow } }; 
```

>菜单默认显示样式为Fill，当菜单项较多时会导致子项无法显示，此时你应修改菜单样式为Top即可

``` csharp
this.ucMenu1.MenuStyle = MenuStyle.Top; 
```
 
##### 13、按钮组

![样例图片](https://images.gitee.com/uploads/images/2019/0815/155103_ced4e03c_301547.png "btnGroup.png")

``` csharp
ucBtnsGroup1.DataSource = new Dictionary<string, string>() { { "1", "男" }, { "0", "女" } };
ucBtnsGroup2.IsMultiple = true;
ucBtnsGroup2.DataSource = new Dictionary<string, string>() { { "1", "河南" }, { "2", "北京" }, { "3", "湖南" }, { "4", "上海" } };
ucBtnsGroup2.SelectItem = new List<string>() { "2","3"};
```


#### 整体样例效果

##### 1、效果1

![样例图片](https://images.gitee.com/uploads/images/2019/0808/115531_8a10e14a_301547.png "样例图片2.png")

##### 2、效果2

![样例图片](https://images.gitee.com/uploads/images/2019/0808/153522_8dacb90c_301547.png "xiaoguo.png")

##### 3、效果3

![样例图片](https://images.gitee.com/uploads/images/2019/0808/154011_3f4e0fb8_301547.png "xiaoguo2.png")

#### 最后的话

最后，喜欢请点下stars，如果有其他一些什么常用的控件可以在留言哦

对你有用的话请打赏一下吧，谢谢。
