using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HZH_Controls.Controls
{
    public interface IDataGridViewCustomCell
    {
        /// <summary>
        /// 绑定行关联的数据
        /// </summary>
        /// <param name="obj">The object.</param>
        void SetBindSource(object obj);
        /// <summary>
        /// 自定义事件传递，用于单元格向行中传递此事件
        /// </summary>
        event DataGridViewRowCustomEventHandler RowCustomEvent;
        /// <summary>
        /// 关联数据源
        /// </summary>
        object DataSource { get; }
    }
}
