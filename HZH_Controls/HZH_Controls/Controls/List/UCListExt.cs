// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="UCListExt.cs">
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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCListExt.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DefaultEvent("ItemClick")]
    public partial class UCListExt : UserControl
    {
        /// <summary>
        /// The title font
        /// </summary>
        private Font _titleFont = new Font("微软雅黑", 15F);
        /// <summary>
        /// Gets or sets the title font.
        /// </summary>
        /// <value>The title font.</value>
        [Description("标题字体"), Category("自定义")]
        public Font TitleFont
        {
            get { return _titleFont; }
            set { _titleFont = value; }
        }
        /// <summary>
        /// The title2 font
        /// </summary>
        private Font _title2Font = new Font("微软雅黑", 14F);
        /// <summary>
        /// Gets or sets the title2 font.
        /// </summary>
        /// <value>The title2 font.</value>
        [Description("副标题字体"), Category("自定义")]
        public Font Title2Font
        {
            get { return _title2Font; }
            set { _title2Font = value; }
        }

        /// <summary>
        /// The item back color
        /// </summary>
        private Color _itemBackColor = Color.White;
        /// <summary>
        /// Gets or sets the color of the item back.
        /// </summary>
        /// <value>The color of the item back.</value>
        [Description("标题背景色"), Category("自定义")]
        public Color ItemBackColor
        {
            get { return _itemBackColor; }
            set { _itemBackColor = value; }
        }

        /// <summary>
        /// The item selected back color
        /// </summary>
        private Color _itemSelectedBackColor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the color of the item selected back.
        /// </summary>
        /// <value>The color of the item selected back.</value>
        [Description("标题选中背景色"), Category("自定义")]
        public Color ItemSelectedBackColor
        {
            get { return _itemSelectedBackColor; }
            set { _itemSelectedBackColor = value; }
        }

        /// <summary>
        /// The item fore color
        /// </summary>
        private Color _itemForeColor = Color.Black;

        /// <summary>
        /// Gets or sets the color of the item fore.
        /// </summary>
        /// <value>The color of the item fore.</value>
        [Description("标题文本色"), Category("自定义")]
        public Color ItemForeColor
        {
            get { return _itemForeColor; }
            set { _itemForeColor = value; }
        }
        /// <summary>
        /// The item selected fore color
        /// </summary>
        private Color _itemSelectedForeColor = Color.White;

        /// <summary>
        /// Gets or sets the color of the item selected fore.
        /// </summary>
        /// <value>The color of the item selected fore.</value>
        [Description("标题选中文本色"), Category("自定义")]
        public Color ItemSelectedForeColor
        {
            get { return _itemSelectedForeColor; }
            set { _itemSelectedForeColor = value; }
        }
        /// <summary>
        /// The item fore color2
        /// </summary>
        private Color _itemForeColor2 = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the item fore color2.
        /// </summary>
        /// <value>The item fore color2.</value>
        [Description("副标题文本色"), Category("自定义")]
        public Color ItemForeColor2
        {
            get { return _itemForeColor2; }
            set { _itemForeColor2 = value; }
        }
        /// <summary>
        /// The item selected fore color2
        /// </summary>
        private Color _itemSelectedForeColor2 = Color.White;

        /// <summary>
        /// Gets or sets the item selected fore color2.
        /// </summary>
        /// <value>The item selected fore color2.</value>
        [Description("副标题选中文本色"), Category("自定义")]
        public Color ItemSelectedForeColor2
        {
            get { return _itemSelectedForeColor2; }
            set { _itemSelectedForeColor2 = value; }
        }

        /// <summary>
        /// The item height
        /// </summary>
        private int _itemHeight = 60;

        /// <summary>
        /// Gets or sets the height of the item.
        /// </summary>
        /// <value>The height of the item.</value>
        [Description("项高度"), Category("自定义")]
        public int ItemHeight
        {
            get { return _itemHeight; }
            set { _itemHeight = value; }
        }

        /// <summary>
        /// The automatic select first
        /// </summary>
        private bool _autoSelectFirst = true;
        /// <summary>
        /// Gets or sets a value indicating whether [automatic select first].
        /// </summary>
        /// <value><c>true</c> if [automatic select first]; otherwise, <c>false</c>.</value>
        [Description("自动选中第一项"), Category("自定义")]
        public bool AutoSelectFirst
        {
            get { return _autoSelectFirst; }
            set { _autoSelectFirst = value; }
        }
        /// <summary>
        /// Delegate ItemClickEvent
        /// </summary>
        /// <param name="item">The item.</param>
        public delegate void ItemClickEvent(UCListItemExt item);
        /// <summary>
        /// Occurs when [item click].
        /// </summary>
        [Description("选中项事件"), Category("自定义")]
        public event ItemClickEvent ItemClick;

        /// <summary>
        /// The selected can click
        /// </summary>
        private bool _selectedCanClick = false;
        /// <summary>
        /// Gets or sets a value indicating whether [selected can click].
        /// </summary>
        /// <value><c>true</c> if [selected can click]; otherwise, <c>false</c>.</value>
        [Description("选中后是否可以再次触发点击事件"), Category("自定义")]
        public bool SelectedCanClick
        {
            get { return _selectedCanClick; }
            set { _selectedCanClick = value; }
        }

        private Color splitColor = Color.FromArgb(238, 238, 238);
        [Description("分割线颜色"), Category("自定义"), Browsable(true)]
        public Color SplitColor
        {
            get { return splitColor; }
            set { splitColor = value; }
        }
        /// <summary>
        /// 选中的节点
        /// </summary>
        /// <value>The select item.</value>
        public UCListItemExt SelectItem
        {
            get { return _current; }
        }
        /// <summary>
        /// The current
        /// </summary>
        UCListItemExt _current = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="UCListExt" /> class.
        /// </summary>
        public UCListExt()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        /// <summary>
        /// Sets the list.
        /// </summary>
        /// <param name="lst">The LST.</param>
        public void SetList(List<ListEntity> lst)
        {
            try
            {
                ControlHelper.FreezeControl(this, true);
                this.Controls.Clear();
                this.SuspendLayout();
                UCListItemExt _first = null;
                for (int i = lst.Count - 1; i >= 0; i--)
                {
                    var item = lst[i];
                    UCListItemExt li = new UCListItemExt();
                    li.SplitColor = splitColor;
                    li.Height = _itemHeight;
                    li.TitleFont = _titleFont;
                    li.Title2Font = _title2Font;
                    li.ItemBackColor = _itemBackColor;
                    li.ItemForeColor = _itemForeColor;
                    li.ItemForeColor2 = _itemForeColor2;
                    li.Dock = DockStyle.Top;
                    li.SetData(item);
                    li.ItemClick += (s, e) => { SelectLabel((UCListItemExt)s); };
                    this.Controls.Add(li);
                    _first = li;
                }
                if (_autoSelectFirst)
                    SelectLabel(_first);
                this.ResumeLayout(false);

                Timer timer = new Timer();
                timer.Interval = 10;
                timer.Tick += (a, b) =>
                {
                    timer.Enabled = false;
                    this.VerticalScroll.Value = 1;
                    this.VerticalScroll.Value = 0;
                    this.Refresh();
                };
                timer.Enabled = true;
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }

        /// <summary>
        /// Selects the label.
        /// </summary>
        /// <param name="li">The li.</param>
        private void SelectLabel(UCListItemExt li)
        {
            try
            {
                HZH_Controls.ControlHelper.FreezeControl(this, true);
                this.FindForm().ActiveControl = this;
                if (_current != null)
                {
                    if (_current == li && !_selectedCanClick)
                        return;
                    _current.ItemBackColor = _itemBackColor;
                    _current.ItemForeColor = _itemForeColor;
                    _current.ItemForeColor2 = _itemForeColor2;
                }
                li.ItemBackColor = _itemSelectedBackColor;
                li.ItemForeColor = _itemSelectedForeColor;
                li.ItemForeColor2 = _itemSelectedForeColor2;

                _current = li;
                if (ItemClick != null)
                {
                    ItemClick(li);
                }
            }
            finally
            {
                HZH_Controls.ControlHelper.FreezeControl(this, false);
            }
        }

    }

    /// <summary>
    /// 列表实体
    /// </summary>
    [Serializable]
    public class ListEntity
    {
        /// <summary>
        /// 编码，唯一值
        /// </summary>
        /// <value>The identifier.</value>
        public string ID { get; set; }
        /// <summary>
        /// 大标题
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// 右侧更多按钮
        /// </summary>
        /// <value><c>true</c> if [show more BTN]; otherwise, <c>false</c>.</value>
        public bool ShowMoreBtn { get; set; }
        /// <summary>
        /// 右侧副标题
        /// </summary>
        /// <value>The title2.</value>
        public string Title2 { get; set; }
        /// <summary>
        /// 关联的数据源
        /// </summary>
        /// <value>The source.</value>
        public object Source { get; set; }
    }
}
