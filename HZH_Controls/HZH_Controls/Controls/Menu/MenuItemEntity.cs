using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HZH_Controls.Controls
{
    [Serializable]
    public class MenuItemEntity
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 文字
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        public List<MenuItemEntity> Childrens { get; set; }
        /// <summary>
        /// 自定义数据源，一般用于扩展展示，比如定义节点图片等
        /// </summary>
        public object DataSource { get; set; }

    }
}
