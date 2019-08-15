// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：DataGridViewCellEventArgs.cs
// 创建日期：2019-08-15 15:59:10
// 功能描述：DataGridView
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    public class DataGridViewEventArgs : EventArgs
    {
        public Control CellControl { get; set; }
        public int CellIndex { get; set; }
        public int RowIndex { get; set; }


    }
}
