// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-09-2019
//
// ***********************************************************************
// <copyright file="DataGridViewColumnEntity.cs">
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
using System.Drawing;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class DataGridViewColumnEntity.
    /// </summary>
    public class DataGridViewColumnEntity
    {
        /// <summary>
        /// Gets or sets the head text.
        /// </summary>
        /// <value>The head text.</value>
        public string HeadText { get; set; }
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; set; }
        /// <summary>
        /// Gets or sets the type of the width.
        /// </summary>
        /// <value>The type of the width.</value>
        public System.Windows.Forms.SizeType WidthType { get; set; }
        /// <summary>
        /// Gets or sets the data field.
        /// </summary>
        /// <value>The data field.</value>
        public string DataField { get; set; }
        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        /// <value>The format.</value>
        public Func<object, string> Format { get; set; }
        /// <summary>
        /// The text align
        /// </summary>
        private ContentAlignment _TextAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// Gets or sets the text align.
        /// </summary>
        /// <value>The text align.</value>
        public ContentAlignment TextAlign { get { return _TextAlign; } set { _TextAlign = value; } }
        /// <summary>
        /// 自定义的单元格控件，一个实现IDataGridViewCustomCell的Control
        /// </summary>
        /// <value>The custom cell.</value>
        private Type customCellType = null;
        public Type CustomCellType
        {
            get
            {
                return customCellType;
            }
            set
            {
                if (!typeof(IDataGridViewCustomCell).IsAssignableFrom(value) || !value.IsSubclassOf(typeof(System.Windows.Forms.Control)))
                    throw new Exception("行控件没有实现IDataGridViewCustomCell接口");
                customCellType = value;
            }
        }
    }
}
