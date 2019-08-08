# NetWinform自定义控件

#### 介绍
c#winfrom自定义控件

#### 软件架构
framework4.0，完全基于原生控件开发，没有使用任何第三方控件，你可以放心的用在你的项目中。

#### 使用

1. 添加引用即可
2. 如果要用到手写需要将HandInput文件夹复制到执行文件目录下

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

##### 5、气泡提示效果图(5种内置及自定义样式)

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

##### 6、多线程操作等待

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

##### 1、登录效果

![样例图片](https://images.gitee.com/uploads/images/2019/0808/115531_8a10e14a_301547.png "样例图片2.png")

##### 2、表单效果

![样例图片](https://images.gitee.com/uploads/images/2019/0808/115540_eeecc755_301547.png "样例图片3.png")

#### 最后的话

最后，喜欢请点下stars

对你有用的吗请打赏一下吧，谢谢。

![打赏](https://images.gitee.com/uploads/images/2019/0808/120103_7e69fe7c_301547.jpeg "1.jpg")
![打赏](https://images.gitee.com/uploads/images/2019/0808/120112_04613892_301547.jpeg "2.jpg")
