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
        void SetSelectedStyle(bool blnSelected);
    }
}
