// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：DataGridViewCellEventHandler.cs
// 创建日期：2019-08-15 15:59:13
// 功能描述：DataGridView
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HZH_Controls.Controls
{
    [Serializable]
    [ComVisible(true)]
    public delegate void DataGridViewEventHandler(object sender, DataGridViewEventArgs e);
}
