// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCListItemExt.cs
// 创建日期：2019-08-15 16:01:34
// 功能描述：List
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
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
    [ToolboxItem(false)]
    public partial class UCListItemExt : UserControl
    {
        [Description("标题"), Category("自定义")]
        public string Title
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        [Description("副标题"), Category("自定义")]
        public string Title2
        {
            get { return label3.Text; }
            set
            {
                label3.Text = value;
                label3.Visible = !string.IsNullOrEmpty(value);
            }
        }

        [Description("标题字体"), Category("自定义")]
        public Font TitleFont
        {
            get { return label1.Font; }
            set
            {
                label1.Font = value;
            }
        }

        [Description("副标题字体"), Category("自定义")]
        public Font Title2Font
        {
            get { return label3.Font; }
            set
            {
                label3.Font = value;
            }
        }

        [Description("背景色"), Category("自定义")]
        public Color ItemBackColor
        {
            get { return this.BackColor; }
            set
            {
                this.BackColor = value;
            }
        }

        [Description("标题文本色"), Category("自定义")]
        public Color ItemForeColor
        {
            get { return label1.ForeColor; }
            set { label1.ForeColor = value; }
        }

        [Description("副标题文本色"), Category("自定义")]
        public Color ItemForeColor2
        {
            get { return label3.ForeColor; }
            set { label3.ForeColor = value; }
        }

        [Description("是否显示右侧更多箭头"), Category("自定义")]
        public bool ShowMoreBtn
        {
            get { return label2.Visible; }
            set { label2.Visible = value; ; }
        }

        [Description("项选中事件"), Category("自定义")]
        public event EventHandler ItemClick;

        /// <summary>
        /// 数据源
        /// </summary>
        public ListEntity DataSource { get; private set; }

        public UCListItemExt()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        private void item_MouseDown(object sender, MouseEventArgs e)
        {
            if (ItemClick != null)
            {
                ItemClick(this, e);
            }
        }

        #region 设置数据
        /// <summary>
        /// 功能描述:设置数据
        /// 作　　者:HZH
        /// 创建日期:2019-02-27 11:52:52
        /// 任务编号:POS
        /// </summary>
        /// <param name="data">data</param>
        public void SetData(ListEntity data)
        {
            this.Title = data.Title;
            this.Title2 = data.Title2;
            this.ShowMoreBtn = data.ShowMoreBtn;
            DataSource = data;
        }
        #endregion
    }
}
