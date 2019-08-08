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
    [DefaultEvent("ItemClick")]
    public partial class UCListExt : UserControl
    {
        private Font _titleFont = new Font("微软雅黑", 15F);
        [Description("标题字体"), Category("自定义")]
        public Font TitleFont
        {
            get { return _titleFont; }
            set { _titleFont = value; }
        }
        private Font _title2Font = new Font("微软雅黑", 14F);
        [Description("副标题字体"), Category("自定义")]
        public Font Title2Font
        {
            get { return _title2Font; }
            set { _title2Font = value; }
        }

        private Color _itemBackColor = Color.White;
        [Description("标题背景色"), Category("自定义")]
        public Color ItemBackColor
        {
            get { return _itemBackColor; }
            set { _itemBackColor = value; }
        }

        private Color _itemSelectedBackColor = Color.FromArgb(73, 119, 232);

        [Description("标题选中背景色"), Category("自定义")]
        public Color ItemSelectedBackColor
        {
            get { return _itemSelectedBackColor; }
            set { _itemSelectedBackColor = value; }
        }

        private Color _itemForeColor = Color.Black;

        [Description("标题文本色"), Category("自定义")]
        public Color ItemForeColor
        {
            get { return _itemForeColor; }
            set { _itemForeColor = value; }
        }
        private Color _itemSelectedForeColor = Color.White;

        [Description("标题选中文本色"), Category("自定义")]
        public Color ItemSelectedForeColor
        {
            get { return _itemSelectedForeColor; }
            set { _itemSelectedForeColor = value; }
        }
        private Color _itemForeColor2 = Color.FromArgb(73, 119, 232);

        [Description("副标题文本色"), Category("自定义")]
        public Color ItemForeColor2
        {
            get { return _itemForeColor2; }
            set { _itemForeColor2 = value; }
        }
        private Color _itemSelectedForeColor2 = Color.White;

        [Description("副标题选中文本色"), Category("自定义")]
        public Color ItemSelectedForeColor2
        {
            get { return _itemSelectedForeColor2; }
            set { _itemSelectedForeColor2 = value; }
        }

        private int _itemHeight = 60;

        [Description("项高度"), Category("自定义")]
        public int ItemHeight
        {
            get { return _itemHeight; }
            set { _itemHeight = value; }
        }

        private bool _autoSelectFirst = true;
        [Description("自动选中第一项"), Category("自定义")]
        public bool AutoSelectFirst
        {
            get { return _autoSelectFirst; }
            set { _autoSelectFirst = value; }
        }
        public delegate void ItemClickEvent(UCListItemExt item);
        [Description("选中项事件"), Category("自定义")]
        public event ItemClickEvent ItemClick;

        private bool _selectedCanClick = false;
        [Description("选中后是否可以再次触发点击事件"), Category("自定义")]
        public bool SelectedCanClick
        {
            get { return _selectedCanClick; }
            set { _selectedCanClick = value; }
        }

        /// <summary>
        /// 选中的节点
        /// </summary>
        public UCListItemExt SelectItem
        {
            get { return _current; }
        }
        UCListItemExt _current = null;
        public UCListExt()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

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
        public string ID { get; set; }
        /// <summary>
        /// 大标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 右侧更多按钮
        /// </summary>
        public bool ShowMoreBtn { get; set; }
        /// <summary>
        /// 右侧副标题
        /// </summary>
        public string Title2 { get; set; }
        /// <summary>
        /// 关联的数据源
        /// </summary>
        public object Source { get; set; }
    }
}
