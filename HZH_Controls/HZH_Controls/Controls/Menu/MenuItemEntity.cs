// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：MenuItemEntity.cs
// 创建日期：2019-08-15 16:02:18
// 功能描述：Menu
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
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
        private List<MenuItemEntity> m_childrens = new List<MenuItemEntity>();
        /// <summary>
        /// 子节点
        /// </summary>
        public List<MenuItemEntity> Childrens
        {
            get
            {
                return m_childrens ?? (new List<MenuItemEntity>());
            }
            set
            {
                m_childrens = value;
            }
        }
        /// <summary>
        /// 自定义数据源，一般用于扩展展示，比如定义节点图片等
        /// </summary>
        public object DataSource { get; set; }

    }
}
