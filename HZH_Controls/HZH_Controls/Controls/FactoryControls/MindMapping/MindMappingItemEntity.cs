// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-11
//
// ***********************************************************************
// <copyright file="MindMappingItemEntity.cs">
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
    /// Class MindMappingItemEntity.
    /// </summary>
    public class MindMappingItemEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string ID { get; set; }
        /// <summary>
        /// The text
        /// </summary>
        private string _text;
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                ResetSize();
            }
        }
        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        public object DataSource { get; set; }
        /// <summary>
        /// The childrens
        /// </summary>
        private MindMappingItemEntity[] _Childrens;
        /// <summary>
        /// Gets or sets the childrens.
        /// </summary>
        /// <value>The childrens.</value>
        public MindMappingItemEntity[] Childrens
        {
            get { return _Childrens; }
            set
            {
                _Childrens = value;
                if (value != null && value.Length > 0)
                {
                    value.ToList().ForEach(p => { if (p != null) { p.ParentItem = this; } });
                }
            }
        }
        /// <summary>
        /// The back color
        /// </summary>
        private Color? backColor;

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color? BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }

        /// <summary>
        /// The font
        /// </summary>
        private Font font = new Font("微软雅黑", 10);

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font Font
        {
            get { return font; }
            set
            {
                font = value;
                ResetSize();
            }
        }

        /// <summary>
        /// The fore color
        /// </summary>
        private Color foreColor = Color.Black;

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }
        /// <summary>
        /// The is expansion
        /// </summary>
        private bool _IsExpansion = false;
        /// <summary>
        /// Gets or sets a value indicating whether the instance is expanded.
        /// </summary>
        /// <value><c>true</c> if this instance is expansion; otherwise, <c>false</c>.</value>
        public bool IsExpansion
        {
            get
            {
                return _IsExpansion;
            }
            set
            {
                if (value == _IsExpansion)
                    return;
                _IsExpansion = value;
                if (!value && _Childrens != null && _Childrens.Length > 0)
                {
                    _Childrens.ToList().ForEach(p => { if (p != null) { p.IsExpansion = false; } });
                }

            }
        }

        /// <summary>
        /// Gets the parent item.
        /// </summary>
        /// <value>The parent item.</value>
        public MindMappingItemEntity ParentItem { get; private set; }
        /// <summary>
        /// Gets all childrens maximum show count.
        /// </summary>
        /// <value>All childrens maximum show count.</value>
        public int AllChildrensMaxShowHeight { get { return GetAllChildrensMaxShowHeight(); } }
        /// <summary>
        /// Gets the maximum level.
        /// </summary>
        /// <value>The maximum level.</value>
        public int AllChildrensMaxShowWidth { get { return GetAllChildrensMaxShowWidth(); } }

        /// <summary>
        /// Gets all childrens maximum show count.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int GetAllChildrensMaxShowHeight()
        {
            if (!_IsExpansion || _Childrens == null || _Childrens.Length <= 0)
                return ItemHeight + 10;
            else
            {
                return _Childrens.Sum(p => p == null ? 0 : p.AllChildrensMaxShowHeight);
            }
        }
        /// <summary>
        /// Gets the maximum level.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int GetAllChildrensMaxShowWidth()
        {
            if (!_IsExpansion || _Childrens == null || _Childrens.Length <= 0)
                return ItemWidth + 50;
            else
            {
                return ItemWidth + 50 + _Childrens.Max(p => p == null ? 0 : p.AllChildrensMaxShowWidth);
            }
        }
        /// <summary>
        /// Gets or sets the working rectangle.
        /// </summary>
        /// <value>The working rectangle.</value>
        internal RectangleF WorkingRectangle { get; set; }
        /// <summary>
        /// Gets or sets the draw rectangle.
        /// </summary>
        /// <value>The draw rectangle.</value>
        internal RectangleF DrawRectangle { get; set; }
        /// <summary>
        /// Gets or sets the expansion rectangle.
        /// </summary>
        /// <value>The expansion rectangle.</value>
        internal RectangleF ExpansionRectangle { get; set; }
        /// <summary>
        /// Gets the height of the item.
        /// </summary>
        /// <value>The height of the item.</value>
        int ItemHeight { get; set; }
        /// <summary>
        /// Gets the width of the item.
        /// </summary>
        /// <value>The width of the item.</value>
        int ItemWidth { get; set; }
        /// <summary>
        /// Resets the size.
        /// </summary>
        private void ResetSize()
        {
            string _t = _text;
            if (string.IsNullOrEmpty(_t))
            {
                _t = "aaaa";
            }
            Bitmap bit = new Bitmap(1, 1);
            var g = Graphics.FromImage(bit);
            var size = g.MeasureString(_t, font);
            g.Dispose();
            bit.Dispose();
            ItemHeight = (int)size.Height;
            ItemWidth = (int)size.Width;
        }
    }
}
