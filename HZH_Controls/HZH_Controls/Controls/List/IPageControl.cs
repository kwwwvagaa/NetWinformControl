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
        event PageControlEventHandler ShowChanged;
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
    }
}
