# NetWinformCustom Controls

# My english is poor. The English below is from Google Translate. Please forgive me.

### [中文README.md(github)](https://github.com/kwwwvagaa/NetWinformControl/blob/master/README_CN.md)

### [中文README.md(码云)](https://gitee.com/kwwwvagaa/net_winform_custom_control/blob/master/README_CN.md)

#### Introduction

c#winfrom custom control, `has better operation support for touch screen`, the project is based on framework4.0, completely native control development, `do not use any third-party controls`, you can use it safely in your project .

Blog address: [https://www.cnblogs.com/bfyx](https://www.cnblogs.com/bfyx/p/11364884.html)

GitHub: [https://github.com/kwwwvagaa/NetWinformControl](https://github.com/kwwwvagaa/NetWinformControl)

Code Cloud: [https://gitee.com/kwwwvagaa/net_winform_custom_control.git](https://gitee.com/kwwwvagaa/net_winform_custom_control.git)

Welcome to exchange discussion: [Click to join QQ group 568015492](//shang.qq.com/wpa/qunwpa?idkey=6e08741ef16fe53bf0314c1c9e336c4f626047943a8b76bac062361bab6b4f8d)

#### If my code is useful to you, please reward me, thank you, your reward is my motivation.

![输入图片说明](https://images.gitee.com/uploads/images/2019/0905/180337_91c70c54_301547.jpeg "zanshangma.jpg")
![输入图片说明](https://images.gitee.com/uploads/images/2019/0905/180345_49207d1d_301547.jpeg "zfb1.jpg")

#### The source code is only for exchange learning. The open source agreement is [GPL-3.0](https://gitee.com/kwwwvagaa/net_winform_custom_control/blob/master/LICENSE). For commercial use, please contact the group owner.

#### Come here, come to a `Star` and let's go.

#### NuGet

``` csharp
Install-Package HZH_Controls
```

![输入图片说明](https://images.gitee.com/uploads/images/2019/0903/084635_85b9e4a3_301547.gif "1.gif")
![输入图片说明](https://images.gitee.com/uploads/images/2019/0903/084848_9aaca7d2_301547.gif "3.gif")

#### Sample

##### 1, prompt window renderings

![sample image](https://images.gitee.com/uploads/images/2019/0808/142043_887cb342_301547.png "tip box 1.png")
![sample image](https://images.gitee.com/uploads/images/2019/0808/142050_1f5588a0_301547.png "tip box 2.png")

``` csharp
If (FrmDialog.ShowDialog(this, "Do you want to display a prompt box without a cancel button?", "Mode Form Test", true) == System.Windows.Forms.DialogResult.OK)
{
    FrmDialog.ShowDialog(this, "This is a prompt box without a cancel button", "Mode Form Test");
}
```

##### 2, multiple input form

![sample image](https://images.gitee.com/uploads/images/2019/0808/142218_4c506097_301547.png "Multiple input form.png")

``` csharp
 FrmInputs frm = new FrmInputs("Dynamic Multi-Input Form Test",
                New string[] { "name", "telephone", "ID number", "address" },
                New Dictionary<string, HZH_Controls.TextInputType>() { { "Phone", HZH_Controls.TextInputType.Regex }, { "ID number", HZH_Controls.TextInputType.Regex } },
                New Dictionary<string, string>() { { "phone", "^1\\d{10}$" }, { "ID number", "^\\d{18}$" } },
                New Dictionary<string, KeyBoardType>() { { "phone", KeyBoardType.UCKeyBorderNum }, { "ID number", KeyBoardType.UCKeyBorderNum } },
                New List<string>() { "name", "telephone", "identity number" });
frm.ShowDialog(this);
```

``` csharp
/// <summary>
/// Function Description: Constructor
/// Author: HZH
/// Creation date: 2019-08-05 10:57:26
/// Task number: POS
/// </summary>
/// <param name="strTitle">form title</param>
/// <param name="args">Input name</param>
/// <param name="inTypes">Input type corresponds to input type, key: input item name, if no default control input is not set </param>
/// <param name="regexs">The input item corresponds to the regular rule, valid when imTypes=Regex, key: input item name, if you do not set the default no control input </param>
/// <param name="keyBoards"> text box keyboard, key: input item name, if you do not set the default English keyboard </param>
/// <param name="mastInputs">Required entry name</param>
/// <param name="defaultValues">Input default value, key: input name </param>
Public FrmInputs(
    String strTitle,
    String[] inPutLabels,
    Dictionary<string, TextInputType> inTypes = null,
    Dictionary<string, string> regexs = null,
    Dictionary<string, HZH_Controls.Controls.KeyBoardType> keyBoards = null,
    List<string> mastInputs = null,
    Dictionary<string, string> defaultValues ​​= null)
```

##### 3, Temp1 form

![sample image](https://images.gitee.com/uploads/images/2019/0808/143753_15610b9f_301547.png "temp.png")

``` csharp
/ / New form FrmTemp1Test inherits HZH_Controls.Forms.FrmTemp1
FrmTemp1Test frm = new FrmTemp1Test();
frm.ShowDialog(this);
```

##### 4, there is a form to confirm cancellation 1

![sample image](https://images.gitee.com/uploads/images/2019/0808/144723_55252cf2_301547.png "oc1.png")

``` csharp
/ / New form FrmOKCancel1Test inherits HZH_Controls.Forms.FrmWithOKCancel1
FrmOKCancel1Test frm = new FrmOKCancel1Test();
frm.ShowDialog(this);
```

##### 5, there is a form to confirm cancellation 2

![sample image](https://images.gitee.com/uploads/images/2019/0808/145516_07d73ec0_301547.png "oc2.png")

``` csharp
/ / New form FrmOKCancel2Test inherits HZH_Controls.Forms.FrmWithOKCancel2
FrmOKCancel2Test frm = new FrmOKCancel2Test();
frm.ShowDialog(this);
```

##### 6, single title form

![sample image](https://images.gitee.com/uploads/images/2019/0808/145718_ff035712_301547.png "t.png")

``` csharp
/ / New form FrmWithTitleTest inherits HZH_Controls.Forms.FrmWithTitle
FrmWithTitleTest frm = new FrmWithTitleTest();
frm.ShowDialog(this);
```

##### 7, control

![输入图片说明](https://images.gitee.com/uploads/images/2019/0827/113624_6e3e98ca_301547.png "1.png")

*Text box keyboard effect*

![sample image](https://images.gitee.com/uploads/images/2019/0808/153812_40d919ea_301547.png "k1.png")
![sample image](https://images.gitee.com/uploads/images/2019/0808/153820_31e8fea6_301547.png "k2.png")
![sample image](https://images.gitee.com/uploads/images/2019/0808/153829_37e4dff5_301547.png "k3.png")

`Handwriting input requires the handwriting support of Sogou, please copy the HandInput folder to the running directory.

*Time control effect*

![sample image](https://images.gitee.com/uploads/images/2019/0808/160404_b8cf7353_301547.png "time1.png")
![sample image](https://images.gitee.com/uploads/images/2019/0808/160411_902d4f6d_301547.png "time2.png")
![sample image](https://images.gitee.com/uploads/images/2019/0808/160418_c92391ba_301547.png "time3.png")

* Drop-down list data binding *

``` csharp
/ / Use the method is similar to the native ComboBox
List<KeyValuePair<string, string>> lstCom = new List<KeyValuePair<string, string>>();
For (int i = 0; i < 5; i++)
{
    lstCom.Add(new KeyValuePair<string, string>(i.ToString(), "options" + i));
}

this.ucComboBox1.Source = lstCom;
this.ucComboBox2.Source = lstCom;
this.ucComboBox1.SelectedIndex = 1;
this.ucComboBox2.SelectedIndex = 1;
```

*Tree data binding*

``` csharp
/ / Use the same method as the native Treeview, set the property IsShowByCustomModel = true to enable the custom mode, otherwise the original tree
For (int i = 0; i < 5; i++)
{
    TreeNode tn = new TreeNode("parent node" + i);
    For (int j = 0; j < 5; j++)
    {
        tn.Nodes.Add("child node" + j);
    }
    this.treeViewEx1.Nodes.Add(tn);
}
```

*List data binding*

``` csharp
/ / Customizable color fonts, etc.
List<ListEntity> lst = new List<ListEntity>();
For (int i = 0; i < 5; i++)
{
    lst.Add(new ListEntity()
    {
        ID = i.ToString(),
        Title = "options" + i,
        ShowMoreBtn = true,
        Source = i
    });
}
this.ucListExt1.SetList(lst);
```

* Horizontal list data binding*

``` csharp
List<KeyValuePair<string, string>> lstHL = new List<KeyValuePair<string, string>>();
For (int i = 0; i < 30; i++)
{
    lstHL.Add(new KeyValuePair<string, string>(i.ToString(), "options" + i));
}

this.ucHorizontalList1.DataSource = lstHL;
```

##### 8, Datagridview

![sample image](https://images.gitee.com/uploads/images/2019/0812/105558_55920c3b_301547.png "table.png")

``` csharp
List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "Number", Width = 70, WidthType = SizeType.Absolute });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "Name", Width = 50, WidthType = SizeType.Percent });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Age", HeadText = "Age", Width = 50, WidthType = SizeType.Percent });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Birthday", HeadText = "Birthday", Width = 50, WidthType = SizeType.Percent, Format = (a) => { return ((DateTime)a).ToString(" yyyy-MM-dd"); } });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Sex", HeadText = "Gender", Width = 50, WidthType = SizeType.Percent, Format = (a) => { return ((int)a) == 0 ? "female": "male"; } });
this.ucDataGridView1.Columns = lstCulumns;
this.ucDataGridView1.IsShowCheckBox = true;
List<object> lstSource = new List<object>();
For (int i = 0; i < 20; i++)
{
    TestModel model = new TestModel()
    {
        ID = i.ToString(),
        Age = 3 * i,
        Name = "name -" + i,
        Birthday = DateTime.Now.AddYears(-10),
        Sex = i % 2
    };
    lstSource.Add(model);
}

this.ucDataGridView1.DataSource = lstSource;
this.ucDataGridView1.First();
```

> When using the paging control, you no longer need to specify the DataSource data source property, just specify the DataSource property of the page turning control

> If the preset table row does not meet your needs, you can also customize the row control by:
1. Add a custom control to implement the interface IDataGridViewRow
2. Implement your custom line with UCDataGridViewRow
3. Set the RowType property of the datagridview.

>Page property defines the page turning control. If UCPagerControl does not meet your needs, please customize the page turning control and inherit UCPagerControlBase.
When the page flip control is not enabled when it is empty, the appropriate data will be displayed on each page when the page flip control is enabled, and the scroll bar no longer appears.

##### 9, page turning control

![sample image](https://images.gitee.com/uploads/images/2019/0812/105558_55920c3b_301547.png "table.png")

>Another paging control style

![sample image](https://images.gitee.com/uploads/images/2019/0815/164510_06392eeb_301547.png "page.png")

``` csharp
List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "Number", Width = 70, WidthType = SizeType.Absolute });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "Name", Width = 50, WidthType = SizeType.Percent });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Age", HeadText = "Age", Width = 50, WidthType = SizeType.Percent });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Birthday", HeadText = "Birthday", Width = 50, WidthType = SizeType.Percent, Format = (a) => { return ((DateTime)a).ToString(" yyyy-MM-dd"); } });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Sex", HeadText = "Gender", Width = 50, WidthType = SizeType.Percent, Format = (a) => { return ((int)a) == 0 ? "female": "male"; } });
this.ucDataGridView1.Columns = lstCulumns;
this.ucDataGridView1.IsShowCheckBox = true;
List<object> lstSource = new List<object>();
For (int i = 0; i < 20; i++)
{
    TestModel model = new TestModel()
    {
        ID = i.ToString(),
        Age = 3 * i,
        Name = "name -" + i,
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

>If UCPagerControl does not meet your needs, please customize the page flip control and inherit UCPagerControlBase, such as changing the style, adding logic, etc.

> If you need to subscript a page of data starting from 10, you can set StartIndex = 10, then call GetCurrentSource (), the usage is as follows:

``` csharp
m_page.DataSource=lstSource;
m_page.PageSize = ShowCount;
m_page.StartIndex=10;
this.dgv.DataSource = m_page.GetCurrentSource();
```

> The page flip control can be used for any list-type control. The above code example only uses the datagridview to illustrate usage. The usage is as follows:
1. Set the property DataSource data source
2. Set the property PageSize to display the amount of data per page.
3. Set the time ShowSourceChanged to set the current page data source to the target control in time.
4. If the first page of data is not displayed after the page is loaded, you can manually call GetCurrentSource() and assign it to the target control, for example:

``` csharp
m_page.DataSource=lstSource;
m_page.PageSize = ShowCount;
this.dgv.DataSource = m_page.GetCurrentSource();
```

##### 10, bubble tips renderings (5 built-in and custom styles)

![sample image](https://images.gitee.com/uploads/images/2019/0812/112144_6af9389c_301547.png "tips.png")

``` csharp
FrmTips.ShowTipsError(this, "Error prompt message");
FrmTips.ShowTipsInfo(this, "Info prompt information");
FrmTips.ShowTipsSuccess(this, "Success prompt information");
FrmTips.ShowTipsWarning(this, "Warning prompt information");
/*Customize can be used
Public static FrmTips ShowTips(
            Form frm,
            String strMsg,
            Int intAutoColseTime = 0,
            Bool blnShowCoseBtn = true,
            ContentAlignment align = ContentAlignment.BottomLeft,
            Point? point = null,
            TipsSizeMode mode = TipsSizeMode.Small,
            Size? size = null,
            TipsState state = TipsState.Default)
*/
```

##### 11, multi-threaded operation waiting

![sample image](https://images.gitee.com/uploads/images/2019/0808/144201_932c5259_301547.png "waiting.png")
``` csharp
/ / This form is generally used in the time-consuming thread operation to display the waiting animation, the following is a multi-threaded time-consuming operation example
ControlHelper.ThreadRunExt(this, () =>
{
    Thread.Sleep(5000);
    ControlHelper.ThreadInvokerControl(this, () =>
    {
        FrmTips.ShowTipsSuccess(this, "FrmWaiting test");
    });
}, null, this);
//ControlHelper.ThreadRunExt to open a thread to perform tasks
//ControlHelper.ThreadInvokerControl is an asynchronous delegate call control
```

``` csharp
/// <summary>
/// Use one thread to perform an operation
/// </summary>
/// <param name="parent">parent control</param>
/// <param name="func">Execution content</param>
/// <param name="callback">post-execution callback</param>
/// <param name="enableControl">Disable control list during execution</param>
/// <param name="blnShowSplashScreen">Whether waiting for a prompt is displayed during execution</param>
/// <param name="strMsg">When waiting for the prompt during execution, the default is "Processing, please wait..."</param>
/// <param name="intSplashScreenDelayTime">Delayed display waiting reminder time</param>
Public static void ThreadRunExt(
    Control parent,
    Action func,
    Action<object> callback,
    Control[] enableControl = null,
    Bool blnShowSplashScreen = true,
    String strMsg = null,
    Int intSplashScreenDelayTime = 200)
```

##### 12, menu navigation control

![sample image](https://images.gitee.com/uploads/images/2019/0815/103949_9fdb0d12_301547.png "menu.png")

``` csharp
List<MenuItemEntity> lstMenu = new List<MenuItemEntity>();
For (int i = 0; i < 5; i++)
{
    MenuItemEntity item = new MenuItemEntity()
    {
        Key = "p" + i.ToString(),
        Text = "menu item" + i,
        DataSource = "Have some custom data sources for extension here"
    };
    item.Childrens = new List<MenuItemEntity>();
    For (int j = 0; j < 5; j++)
    {
        MenuItemEntity item2 = new MenuItemEntity()
        {
            Key = "c" + i.ToString(),
            Text = "menu item" + i + "-" + j,
            DataSource = "Have some custom data sources for extension here"
        };
        item.Childrens.Add(item2);
    }
    lstMenu.Add(item);
}
this.ucMenu1.DataSource = lstMenu;
```

> If the preset style does not meet your needs, you can also customize the node control by:
1. Add a custom control to implement the interface IMenuItem, which can define the parent node and the child node respectively.
2. Implement your custom node with reference to UCMenuChildrenItem or UCMenuParentItem
3. Set the parent node ParentItemType property of the UCMenu and the childItemChildItemType property.

> If you want to modify the node style, such as the background color, you can use UCMenu's ParentItemStyles or ChildrenItemStyles, such as

``` csharp
this.ucMenu1.ParentItemStyles = new Dictionary<string, object>() { {"BackColor",Color.Red } };
this.ucMenu1.ChildrenItemStyles = new Dictionary<string, object>() { {"BackColor",Color.Yellow } };
```

> The default display style of the menu is Fill. When there are more menu items, the sub-items cannot be displayed. In this case, you should modify the menu style to Top.

``` csharp
this.ucMenu1.MenuStyle = MenuStyle.Top;
```
 
##### 13, button group

![sample image](https://images.gitee.com/uploads/images/2019/0815/155103_ced4e03c_301547.png "btnGroup.png")

``` csharp
ucBtnsGroup1.DataSource = new Dictionary<string, string>() { { "1", "male" }, { "0", "female" } };
ucBtnsGroup2.IsMultiple = true;
ucBtnsGroup2.DataSource = new Dictionary<string, string>() { { "1", "Henan" }, { "2", "Beijing" }, { "3", "Hunan" }, { "4", " Shanghai" } };
ucBtnsGroup2.SelectItem = new List<string>() { "2","3"};
```

##### 14, Tab page

![sample image](https://images.gitee.com/uploads/images/2019/0817/104555_cc0b40fc_301547.png "tab.png")

##### 15, step control

![sample image](https://images.gitee.com/uploads/images/2019/0817/162039_98824330_301547.png "1.png")
![sample image](https://images.gitee.com/uploads/images/2019/0819/091013_f4ab8661_301547.png "2.png")

##### 16, panel with title

![sample image](https://images.gitee.com/uploads/images/2019/0817/162107_8a576e36_301547.png "2.png")

##### 17, progress bar

Progress bar supports ring or fan display, support for percentage and value display

![sample image](https://images.gitee.com/uploads/images/2019/0819/083846_335ab0b5_301547.gif "1.gif")
![sample image](https://images.gitee.com/uploads/images/2019/0819/083853_94e1f3f6_301547.gif "2.gif")

![sample image](https://images.gitee.com/uploads/images/2019/0820/115413_8a6564c5_301547.gif "2.gif")

![sample image](https://images.gitee.com/uploads/images/2019/0822/085500_2943930c_301547.gif "1.gif")

![输入图片说明](https://images.gitee.com/uploads/images/2019/0823/133831_0cf0344d_301547.gif "5.gif")

##### 18, breadcrumb navigation

![sample image](https://images.gitee.com/uploads/images/2019/0819/111929_25c71140_301547.png "1.png")

##### 19, switch

![sample image](https://images.gitee.com/uploads/images/2019/0819/160415_121416e0_301547.png "switch.png")

##### 20、ListView

![sample image](https://images.gitee.com/uploads/images/2019/0822/113629_bfa4fbc2_301547.png "listview.png")
![sample image](https://images.gitee.com/uploads/images/2019/0822/113641_3cd8df3f_301547.png "listview2.png")

The ListView item element provides an interface implementation. When you feel that the sub-items I wrote don't meet your needs, you can add a control, implement the interface, and then assign your control to the ListItem's property ItemType.

Similarly, I also provide a page turning control, property Page, as long as the page flip control that inherits UCPagerControlBase can be compatible, of course, you can also use the page turning control.

Take a look at the call.

``` csharp
List<object> lstSource = new List<object>();
For (int i = 0; i < 200; i++)
{
     lstSource.Add("item-" + i);
}
/ / Use the paging control
Var page = new UCPagerControl2();
page.DataSource = lstSource;
this.ucListView1.Page = page;
/ / Do not use paging controls
//this.ucListView1.DataSource = lstSource;
```

##### 21, water wave

![sample image](https://images.gitee.com/uploads/images/2019/0823/090215_71d3c692_301547.gif "2.gif")

##### 22, waveform chart

![sample image](https://images.gitee.com/uploads/images/2019/0823/090247_789712bc_301547.gif "1.gif")

``` csharp
//Timer randomly adds numbers at regular intervals
Random r = new Random();
Int i = r.Next(100, 1000);
this.ucWaveWithSource1.AddSource(i.ToString(), i);
```

##### 23, TreeGrid

![Enter image description](https://images.gitee.com/uploads/images/2019/0826/154617_e0b57ff6_301547.png "treegrid.png")

``` csharp
 Private void FrmTemp1Test_Load(object sender, EventArgs e)
        {
            this.ucDataGridView1.RowType = typeof(UCDataGridViewTreeRow);
            this.ucDataGridView1.IsAutoHeight = true;

            List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "Number", Width = 70, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "Name", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Age", HeadText = "Age", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Birthday", HeadText = "Birthday", Width = 50, WidthType = SizeType.Percent, Format = (a) => { return ((DateTime)a).ToString(" yyyy-MM-dd"); } });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Sex", HeadText = "Gender", Width = 50, WidthType = SizeType.Percent, Format = (a) => { return ((int)a) == 0 ? "female": "male"; } });
            this.ucDataGridView1.Columns = lstCulumns;
            this.ucDataGridView1.IsShowCheckBox = true;
            List<object> lstSource = new List<object>();
            For (int i = 0; i < 200; i++)
            {
                TestModel model = new TestModel()
                {
                    ID = i.ToString(),
                    Age = 3 * i,
                    Name = "name -" + i,
                    Birthday = DateTime.Now.AddYears(-10),
                    Sex = i % 2
                };
                lstSource.Add(model);
                AddChilds(model, 5);
            }

            Var page = new UCPagerControl2();
            page.DataSource = lstSource;
            this.ucDataGridView1.Page = page;
            this.ucDataGridView1.First();
        }

        Private void AddChilds(TestModel tm, int intCount)
        {
            If (intCount <= 0)
                Return;
            tm.Childrens = new List<TestModel>();
            For (int i = 0; i < 5; i++)
            {
                TestModel model = new TestModel()
                {
                    ID = i.ToString(),
                    Age = 3 * i,
                    Name = intCount + "-" + i,
                    Birthday = DateTime.Now.AddYears(-10),
                    Sex = i % 2
                };
                tm.Childrens.Add(model);
                AddChilds(model, intCount - 1);
            }
        }
```

##### 24, table drop-down box

![Enter image description](https://images.gitee.com/uploads/images/2019/0828/174756_ecc838e5_301547.png "dropdowngrid.png")

``` csharp
List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "Number", Width = 70, WidthType = SizeType.Absolute });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "Name", Width = 100, WidthType = SizeType.Absolute });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Age", HeadText = "Age", Width = 100, WidthType = SizeType.Absolute });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Birthday", HeadText = "Birthday", Width = 120, WidthType = SizeType.Absolute, Format = (a) => { return ((DateTime)a).ToString(" yyyy-MM-dd"); } });
lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Sex", HeadText = "Gender", Width = 100, WidthType = SizeType.Absolute, Format = (a) => { return ((int)a) == 0 ? "female": "male"; } });
this.ucComboxGrid1.GridColumns = lstCulumns;
List<object> lstSourceGrid = new List<object>();
For (int i = 0; i < 100; i++)
{
    TestModel model = new TestModel()
    {
        ID = i.ToString(),
        Age = 3 * i,
        Name = "name -" + i,
        Birthday = DateTime.Now.AddYears(-10),
        Sex = i % 2
    };
    lstSourceGrid.Add(model);
}
this.ucComboxGrid1.GridDataSource = lstSourceGrid;
```
##### 25, TrackBar

![Enter image description](https://images.gitee.com/uploads/images/2019/0829/112813_d4d2a09b_301547.gif "1.gif")

![输入图片说明](https://images.gitee.com/uploads/images/2019/0830/102356_7cbfed3b_301547.gif "2.gif")

##### 26, toolTips (toolTips)

![Enter image description](https://images.gitee.com/uploads/images/2019/0829/154507_199fdff5_301547.png "anchorTips.png")

``` csharp
HZH_Controls.Forms.FrmAnchorTips.ShowTips(button1, "test prompt information \nLEFT", AnchorTipsLocation.LEFT);
HZH_Controls.Forms.FrmAnchorTips.ShowTips(button1, "Test prompt information \nRIGHT", AnchorTipsLocation.RIGHT);
HZH_Controls.Forms.FrmAnchorTips.ShowTips(button1, "Test prompt information \nTOP", AnchorTipsLocation.TOP);
HZH_Controls.Forms.FrmAnchorTips.ShowTips(button1, "Test prompt information \nBOTTOM", AnchorTipsLocation.BOTTOM);
```

##### 26、LED Number

![输入图片说明](https://images.gitee.com/uploads/images/2019/0902/181109_92cf14c4_301547.gif "1.gif")

##### 27, scrolling text

![Enter picture description](https://images.gitee.com/uploads/images/2019/0903/100148_7d7f8980_301547.gif "4.gif")
![Enter image description](https://images.gitee.com/uploads/images/2019/0903/100217_d09dff79_301547.gif "5.gif")
![Enter image description](https://images.gitee.com/uploads/images/2019/0903/100225_6cf0a534_301547.gif "6.gif")

##### 28, instrument

![Enter image description](https://images.gitee.com/uploads/images/2019/0904/095910_0dd8ec1e_301547.png "yibiao.png")

##### 29, Pipeline

![Enter image description](https://images.gitee.com/uploads/images/2019/0904/181918_43024834_301547.gif "1.gif")

##### 30, bottle

![Enter image description](https://images.gitee.com/uploads/images/2019/0905/152444_d1b13c6d_301547.png "pingzi.png")

##### 31, conveyor belt

![Enter picture description](https://images.gitee.com/uploads/images/2019/0905/152454_bd9c45cf_301547.gif "3.gif")

##### 32、Valve

![输入图片说明](https://images.gitee.com/uploads/images/2019/0906/165031_e365fd63_301547.gif "5.gif")
![输入图片说明](https://images.gitee.com/uploads/images/2019/0906/165040_4ad642d8_301547.gif "6.gif")

##### 33、Blower

![输入图片说明](https://images.gitee.com/uploads/images/2019/0909/134327_6e99dd33_301547.png "fj.png")

##### 34, signal light

![Enter picture description](https://images.gitee.com/uploads/images/2019/0909/162334_5a8c6b42_301547.gif "1.gif")

##### 35、Alarm Lamp

![输入图片说明](https://images.gitee.com/uploads/images/2019/0910/094631_ab30696f_301547.gif "2.gif")

##### 36、Temperature

![输入图片说明](https://images.gitee.com/uploads/images/2019/0910/163155_5bee72e6_301547.png "wdj.png")

##### 37、Mind Mapping

![输入图片说明](https://images.gitee.com/uploads/images/2019/0911/143628_cfaee8b4_301547.gif "1.gif")

#### The last words

Finally, please like to click on the stars, if there are other commonly used controls, you can leave a message.

If you are useful to you, please reward me, thank you.
