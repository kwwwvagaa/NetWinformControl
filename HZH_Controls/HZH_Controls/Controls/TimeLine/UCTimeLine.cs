// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-10-09
//
// ***********************************************************************
// <copyright file="UCTimeLine.cs">
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
    /// Class UCTimeLine.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class UCTimeLine : UserControl
    {
        /// <summary>
        /// The line color
        /// </summary>
        private Color lineColor = TextColors.Light;

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        [Description("连接线颜色"), Category("自定义")]
        public Color LineColor
        {
            get { return lineColor; }
            set
            {
                lineColor = value;
                Invalidate();
            }
        }
        /// <summary>
        /// The title font
        /// </summary>
        private Font titleFont = new Font("微软雅黑", 14f);

        /// <summary>
        /// Gets or sets the title font.
        /// </summary>
        /// <value>The title font.</value>
        [Description("标题字体"), Category("自定义")]
        public Font TitleFont
        {
            get { return titleFont; }
            set
            {
                titleFont = value;
                ReloadItems();
            }
        }

        /// <summary>
        /// The title forcolor
        /// </summary>
        private Color titleForcolor = TextColors.MoreDark;

        /// <summary>
        /// Gets or sets the title forcolor.
        /// </summary>
        /// <value>The title forcolor.</value>
        [Description("标题颜色"), Category("自定义")]
        public Color TitleForcolor
        {
            get { return titleForcolor; }
            set
            {
                titleForcolor = value;
                ReloadItems();
            }
        }

        /// <summary>
        /// The details font
        /// </summary>
        private Font detailsFont = new Font("微软雅黑", 10);

        /// <summary>
        /// Gets or sets the details font.
        /// </summary>
        /// <value>The details font.</value>
        [Description("详情字体"), Category("自定义")]
        public Font DetailsFont
        {
            get { return detailsFont; }
            set
            {
                detailsFont = value;
                ReloadItems();
            }
        }

        /// <summary>
        /// The details forcolor
        /// </summary>
        private Color detailsForcolor = TextColors.Light;

        /// <summary>
        /// Gets or sets the details forcolor.
        /// </summary>
        /// <value>The details forcolor.</value>
        [Description("详情颜色"), Category("自定义")]
        public Color DetailsForcolor
        {
            get { return detailsForcolor; }
            set
            {
                detailsForcolor = value;
                ReloadItems();
            }
        }

        /// <summary>
        /// The items
        /// </summary>
        TimeLineItem[] items;

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [Description("项列表"), Category("自定义")]
        public TimeLineItem[] Items
        {
            get { return items; }
            set
            {
                items = value;
                ReloadItems();
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UCTimeLine"/> class.
        /// </summary>
        public UCTimeLine()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            InitializeComponent();
            items = new TimeLineItem[0];
            if (ControlHelper.IsDesignMode())
            {
                items = new TimeLineItem[4];
                for (int i = 0; i < 4; i++)
                {
                    items[i] = new TimeLineItem()
                    {
                        Title = DateTime.Now.AddMonths(-1 * (3 - i)).ToString("yyyy年MM月"),
                        Details = DateTime.Now.AddMonths(-1 * (3 - i)).ToString("yyyy年MM月") + "发生了一件大事，咔嚓一声打了一个炸雷，咔嚓一声打了一个炸雷，咔嚓一声打了一个炸雷，咔嚓一声打了一个炸雷，咔嚓一声打了一个炸雷，咔嚓一声打了一个炸雷，咔嚓一声打了一个炸雷，咔嚓一声打了一个炸雷，咔嚓一声打了一个炸雷，然后王二麻子他爹王咔嚓出生了。"
                    };
                }
                ReloadItems();
            }
        }

        /// <summary>
        /// Reloads the items.
        /// </summary>
        private void ReloadItems()
        {
            try
            {
                ControlHelper.FreezeControl(this, true);
                this.Controls.Clear();
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        FlowLayoutPanel panelTitle = new FlowLayoutPanel();
                        panelTitle.Dock = DockStyle.Top;
                        panelTitle.AutoScroll = false;
                        panelTitle.Padding = new System.Windows.Forms.Padding(5);
                        panelTitle.Name = "title_" + Guid.NewGuid().ToString();

                        Label lblTitle = new Label();
                        lblTitle.Dock = DockStyle.Top;
                        lblTitle.AutoSize = true;
                        lblTitle.Font = titleFont;
                        lblTitle.ForeColor = titleForcolor;
                        lblTitle.Text = item.Title;
                        lblTitle.SizeChanged += item_SizeChanged;
                        panelTitle.Controls.Add(lblTitle);
                        this.Controls.Add(panelTitle);
                        panelTitle.BringToFront();


                        FlowLayoutPanel panelDetails = new FlowLayoutPanel();
                        panelDetails.Dock = DockStyle.Top;
                        panelDetails.AutoScroll = false;
                        panelDetails.Padding = new System.Windows.Forms.Padding(5);
                        panelDetails.Name = "details_" + Guid.NewGuid().ToString();
                        Label lblDetails = new Label();
                        lblDetails.AutoSize = true;
                        lblDetails.Dock = DockStyle.Top;
                        lblDetails.Font = detailsFont;
                        lblDetails.ForeColor = detailsForcolor;
                        lblDetails.Text = item.Details;
                        lblDetails.SizeChanged += item_SizeChanged;
                        panelDetails.Controls.Add(lblDetails);
                        this.Controls.Add(panelDetails);
                        panelDetails.BringToFront();

                    }
                }
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }

        /// <summary>
        /// Handles the SizeChanged event of the item control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void item_SizeChanged(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Parent.Height = lbl.Height + 10;
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();
            var lst = this.Controls.ToArray().Where(p => p.Name.StartsWith("title_")).ToList();
            for (int i = 0; i < lst.Count; i++)
            {
                //画圆
                g.DrawEllipse(new Pen(new SolidBrush(lineColor)), new Rectangle(7, lst[i].Location.Y + 10, 16, 16));
                //划线
                if (i != lst.Count - 1)
                {
                    g.DrawLine(new Pen(new SolidBrush(lineColor)), new Point(7 + 8, lst[i].Location.Y + 10 - 2), new Point(7 + 8, lst[i + 1].Location.Y + 10 + 16 + 2));
                }
            }
        }
    }

    /// <summary>
    /// Class TimeLineItem.
    /// </summary>
    public class TimeLineItem
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>The details.</value>
        public string Details { get; set; }
    }
}
