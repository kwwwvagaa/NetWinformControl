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
