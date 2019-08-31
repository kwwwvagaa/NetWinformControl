// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：IListViewItem.cs
// 作　　者：HZH
// 创建日期：2019-08-31 16:03:22
// 功能描述：IListViewItem    English:IListViewItem
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
// 项目地址：https://github.com/kwwwvagaa/NetWinformControl
// 如果你使用了此类，请保留以上说明
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HZH_Controls.Controls
{
    public interface IListViewItem
    {
        /// <summary>
        /// 数据源
        /// </summary>
        object DataSource { get; set; }
        /// <summary>
        /// 选中项事件
        /// </summary>
        event EventHandler SelectedItemEvent;
        /// <summary>
        /// 选中处理，一般用以更改选中效果
        /// </summary>
        /// <param name="blnSelected">是否选中</param>
        void SetSelected(bool blnSelected);
    }
}
