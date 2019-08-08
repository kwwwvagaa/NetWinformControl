# NetWinform自定义控件

#### 介绍

c#winfrom自定义控件，项目是基于framework4.0，完全原生控件开发，没有使用任何第三方控件，你可以放心的用在你的项目中。

#### 使用

1. 添加引用
2. 如果要用到手写需要将HandInput文件夹复制到执行文件目录下（搜狗手写）

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


##### 8、气泡提示效果图(5种内置及自定义样式)

![输入图片说明](https://images.gitee.com/uploads/images/2019/0808/143309_b71c7e49_301547.png "气泡.png")

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

##### 9、多线程操作等待

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

#### 整体样例效果

##### 1、效果1

![样例图片](https://images.gitee.com/uploads/images/2019/0808/115531_8a10e14a_301547.png "样例图片2.png")

##### 2、效果2

![样例图片](https://images.gitee.com/uploads/images/2019/0808/153522_8dacb90c_301547.png "xiaoguo.png")

##### 3、效果3

![样例图片](https://images.gitee.com/uploads/images/2019/0808/154011_3f4e0fb8_301547.png "xiaoguo2.png")

#### 最后的话

最后，喜欢请点下stars，如果有其他一些什么常用的控件可以在留言哦

对你有用的吗请打赏一下吧，谢谢。
