// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：IMenuItem.cs
// 创建日期：2019-08-15 16:02:14
// 功能描述：Menu
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HZH_Controls.Controls
{
    public interface IMenuItem
    {
        event EventHandler SelectedItem;
        MenuItemEntity DataSource { get; set; }
        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="styles">key:属性名称,value:属性值</param>
        void SetStyle(Dictionary<string, object> styles);
        /// <summary>
        /// 设置选中样式
        /// </summary>
        /// <param name="blnSelected">是否选中</param>
        void SetSelectedStyle(bool? blnSelected);
    }
}
