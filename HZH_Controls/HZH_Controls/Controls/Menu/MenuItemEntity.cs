// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-15-2019
//
// ***********************************************************************
// <copyright file="MenuItemEntity.cs">
//     Copyright by Huang Zhenghui(黄正辉) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub：https://github.com/kwwwvagaa/NetWinformControl
// gitee：https://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class MenuItemEntity.
    /// </summary>
    [Serializable]
    public class MenuItemEntity
    {
        /// <summary>
        /// 键
        /// </summary>
        /// <value>The key.</value>
        public string Key { get; set; }
        /// <summary>
        /// 文字
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }
        /// <summary>
        /// The m childrens
        /// </summary>
        private List<MenuItemEntity> m_childrens = new List<MenuItemEntity>();
        /// <summary>
        /// 子节点
        /// </summary>
        /// <value>The childrens.</value>
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
        /// <value>The data source.</value>
        public object DataSource { get; set; }

    }
}
