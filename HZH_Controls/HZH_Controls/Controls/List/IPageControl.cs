// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：IPageControl.cs
// 创建日期：2019-08-15 16:00:24
// 功能描述：PageControl
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HZH_Controls.Controls
{
    public interface IPageControl
    {
        /// <summary>
        /// 数据源改变时发生
        /// </summary>
        event PageControlEventHandler ShowSourceChanged;
        /// <summary>
        /// 数据源
        /// </summary>
        List<object> DataSource { get; set; }
        /// <summary>
        /// 显示数量
        /// </summary>
        int PageSize { get; set; }
        /// <summary>
        /// 开始下标
        /// </summary>
        int StartIndex { get; set; }
        /// <summary>
        /// 第一页
        /// </summary>
        void FirstPage();
        /// <summary>
        /// 前一页
        /// </summary>
        void PreviousPage();
        /// <summary>
        /// 下一页
        /// </summary>
        void NextPage();
        /// <summary>
        /// 最后一页
        /// </summary>
        void EndPage();
        /// <summary>
        /// 重新加载
        /// </summary>
        void Reload();
        /// <summary>
        /// 获取当前页数据
        /// </summary>
        /// <returns></returns>
        List<object> GetCurrentSource();

        int PageCount { get; set; }
        int PageIndex { get; set; }
    }
}
