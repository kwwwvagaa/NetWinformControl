// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-11
//
// ***********************************************************************
// <copyright file="UCMindMapping.cs">
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCMindMapping.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    internal class UCMindMapping : UserControl
    {
        /// <summary>
        /// The item context menu strip
        /// </summary>
        private ContextMenuStrip itemContextMenuStrip;

        /// <summary>
        /// Gets or sets the item context menu strip.
        /// </summary>
        /// <value>The item context menu strip.</value>
        [Description("节点关联的右键菜单"), Category("自定义")]
        public ContextMenuStrip ItemContextMenuStrip
        {
            get { return itemContextMenuStrip; }
            set { itemContextMenuStrip = value; }
        }
        /// <summary>
        /// The item backcolor
        /// </summary>
        private Color itemBackcolor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the item backcolor.
        /// </summary>
        /// <value>The item backcolor.</value>
        [Description("节点背景色，优先级小于数据源中设置的背景色"), Category("自定义")]
        public Color ItemBackcolor
        {
            get { return itemBackcolor; }
            set
            {
                itemBackcolor = value;
                Refresh();
            }
        }
        /// <summary>
        /// The line color
        /// </summary>
        private Color lineColor = Color.Black;

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        [Description("线条颜色"), Category("自定义")]
        public Color LineColor
        {
            get { return lineColor; }
            set
            {
                lineColor = value;
                Refresh();
            }
        }
        /// <summary>
        /// The split width
        /// </summary>
        private int splitWidth = 50;
        // private int itemHeight = 20;
        /// <summary>
        /// The padding
        /// </summary>
        private int padding = 20;

        /// <summary>
        /// The m rect working
        /// </summary>
        Rectangle m_rectWorking = Rectangle.Empty;
        /// <summary>
        /// Occurs when [item clicked].
        /// </summary>
        public event EventHandler ItemClicked;
        /// <summary>
        /// The data source
        /// </summary>
        private MindMappingItemEntity dataSource;

        /// <summary>
        /// The select entity
        /// </summary>
        private MindMappingItemEntity selectEntity;
        /// <summary>
        /// Gets the select entity.
        /// </summary>
        /// <value>The select entity.</value>
        [Description("选中的数据源"), Category("自定义")]
        public MindMappingItemEntity SelectEntity
        {
            get { return selectEntity; }
           private set { selectEntity = value; }
        }
        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        [Description("数据源"), Category("自定义")]
        public MindMappingItemEntity DataSource
        {
            get { return dataSource; }
            set
            {
                dataSource = value;

                ResetSize();
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UCMindMapping" /> class.
        /// </summary>
        public UCMindMapping()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Click += UCMindMapping_Click;
            this.DoubleClick += UCMindMapping_DoubleClick;
            this.Load += UCMindMapping_Load;
            this.MouseClick += UCMindMapping_MouseClick;
        }



        /// <summary>
        /// Handles the Load event of the UCMindMapping control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void UCMindMapping_Load(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                //父控件大小改变时重置大小和位置
                this.Parent.SizeChanged += (a, b) =>
                {
                    ResetSize();
                };
            }
        }

        /// <summary>
        /// 双击处理，主要用于检测节点双击展开折叠
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void UCMindMapping_DoubleClick(object sender, EventArgs e)
        {
            var mouseLocation = this.PointToClient(Control.MousePosition);

            bool bln = CheckDrawRectClick(dataSource, mouseLocation);
            if (bln)
            {
                ResetSize();
                this.Parent.Refresh();
            }
        }

        /// <summary>
        /// 单击处理，主要用于单击节点事件和，展开关闭圆圈处理
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void UCMindMapping_Click(object sender, EventArgs e)
        {
            var mouseLocation = this.PointToClient(Control.MousePosition);

            bool bln = CheckExpansionClick(dataSource, mouseLocation);
            if (bln)
            {
                ResetSize();
                this.Parent.Refresh();
            }
        }

        /// <summary>
        /// Handles the MouseClick event of the UCMindMapping control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void UCMindMapping_MouseClick(object sender, MouseEventArgs e)
        {
            if (itemContextMenuStrip != null && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                bool bln = CheckDrawRectClick(dataSource, e.Location, false);
                if (bln)
                {
                    itemContextMenuStrip.Show(this.PointToScreen(e.Location));
                }
            }
        }

        /// <summary>
        /// 双击检查
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="mouseLocation">The mouse location.</param>
        /// <param name="blnDoExpansion">if set to <c>true</c> [BLN do expansion].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CheckDrawRectClick(MindMappingItemEntity item, Point mouseLocation, bool blnDoExpansion = true)
        {
            if (item == null)
                return false;
            else
            {
                if (item.DrawRectangle.Contains(mouseLocation))
                {
                    if (blnDoExpansion)
                        item.IsExpansion = !item.IsExpansion;
                    return true;
                }
                if (item.Childrens != null && item.Childrens.Length > 0)
                {
                    foreach (var child in item.Childrens)
                    {
                        var bln = CheckDrawRectClick(child, mouseLocation, blnDoExpansion);
                        if (bln)
                            return bln;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 单击检查
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="mouseLocation">The mouse location.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CheckExpansionClick(MindMappingItemEntity item, Point mouseLocation)
        {
            if (item == null)
                return false;
            else
            {
                if (item.DrawRectangle.Contains(mouseLocation))
                {
                    selectEntity = item;
                    if (ItemClicked != null )
                    {
                        ItemClicked(item, null);
                    }
                }
               
                if (item.ExpansionRectangle.Contains(mouseLocation))
                {
                    item.IsExpansion = !item.IsExpansion;
                    return true;
                }
                if (item.Childrens != null && item.Childrens.Length > 0)
                {
                    foreach (var child in item.Childrens)
                    {
                        var bln = CheckExpansionClick(child, mouseLocation);
                        if (bln)
                            return bln;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
                if (m_rectWorking == Rectangle.Empty || m_rectWorking == null)
                    return;
                var g = e.Graphics;
                g.SetGDIHigh();

                int intHeight = dataSource.AllChildrensMaxShowHeight;
                dataSource.WorkingRectangle = new RectangleF(m_rectWorking.Left, m_rectWorking.Top + (m_rectWorking.Height - intHeight) / 2, m_rectWorking.Width, intHeight);

                DrawItem(dataSource, g);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "错误");
            }
        }

        /// <summary>
        /// 画节点
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="g">The g.</param>
        private void DrawItem(MindMappingItemEntity item, Graphics g)
        {
            //节点
            var size = g.MeasureString(item.Text, item.Font);
            item.DrawRectangle = new RectangleF(item.WorkingRectangle.Left + 2, item.WorkingRectangle.Top + (item.WorkingRectangle.Height - size.Height) / 2 + 2, size.Width + 4, size.Height + 4);
            GraphicsPath drawPath = item.DrawRectangle.CreateRoundedRectanglePath(5);
            if (item.BackColor.HasValue)
                g.FillPath(new SolidBrush(item.BackColor.Value), drawPath);
            else
                g.FillPath(new SolidBrush(itemBackcolor), drawPath);

            g.DrawString(item.Text, item.Font, new SolidBrush(item.ForeColor), item.DrawRectangle.Location.X + 2, item.DrawRectangle.Location.Y + 2);
            //子节点
            if (item.Childrens != null && item.IsExpansion)
            {
                for (int i = 0; i < item.Childrens.Length; i++)
                {
                    var child = item.Childrens[i];
                    if (i == 0)
                    {
                        child.WorkingRectangle = new RectangleF(item.DrawRectangle.Right + splitWidth, item.WorkingRectangle.Top, item.WorkingRectangle.Width - (item.DrawRectangle.Width + splitWidth), child.AllChildrensMaxShowHeight);
                    }
                    else
                    {
                        child.WorkingRectangle = new RectangleF(item.DrawRectangle.Right + splitWidth, item.Childrens[i - 1].WorkingRectangle.Bottom, item.WorkingRectangle.Width - (item.DrawRectangle.Width + splitWidth), child.AllChildrensMaxShowHeight);
                    }
                    DrawItem(child, g);
                }
            }
            //连线
            if (item.ParentItem != null)
            {
                g.DrawLines(new Pen(new SolidBrush(lineColor), 1), new PointF[] 
                { 
                    new PointF(item.ParentItem.DrawRectangle.Right,item.ParentItem.DrawRectangle.Top+item.ParentItem.DrawRectangle.Height/2),
                    new PointF(item.ParentItem.DrawRectangle.Right+12,item.ParentItem.DrawRectangle.Top+item.ParentItem.DrawRectangle.Height/2),
                    //new PointF(item.ParentItem.DrawRectangle.Right+12,item.DrawRectangle.Top+item.DrawRectangle.Height/2),                    
                    new PointF(item.DrawRectangle.Left-12,item.DrawRectangle.Top+item.DrawRectangle.Height/2),                 
                    new PointF(item.DrawRectangle.Left,item.DrawRectangle.Top+item.DrawRectangle.Height/2),
                });
            }
            //展开折叠按钮
            if (item.Childrens != null && item.Childrens.Length > 0)
            {
                RectangleF _rect = new RectangleF(item.DrawRectangle.Right + 1, item.DrawRectangle.Top + (item.DrawRectangle.Height - 10) / 2, 10, 10);
                item.ExpansionRectangle = _rect;
                g.FillEllipse(new SolidBrush(this.BackColor), _rect);
                g.DrawEllipse(new Pen(new SolidBrush(Color.Black)), _rect);
                g.DrawLine(new Pen(new SolidBrush(lineColor)), _rect.Left + 2, _rect.Y + _rect.Height / 2, _rect.Right - 2, _rect.Y + _rect.Height / 2);
                if (!item.IsExpansion)
                {
                    g.DrawLine(new Pen(new SolidBrush(lineColor)), _rect.Left + _rect.Width / 2, _rect.Top + 2, _rect.Left + _rect.Width / 2, _rect.Bottom - 2);
                }
            }
        }


        /// <summary>
        /// 重置大小
        /// </summary>
        private void ResetSize()
        {
            if (this.Parent == null)
                return;
            try
            {
                ControlHelper.FreezeControl(this, true);
                if (dataSource == null)
                {
                    m_rectWorking = Rectangle.Empty;
                    this.Size = this.Parent.Size;
                }
                else
                {
                    int intWidth = dataSource.AllChildrensMaxShowWidth;
                    int intHeight = dataSource.AllChildrensMaxShowHeight;
                    this.Width = intWidth + padding * 2;
                    this.Height = intHeight + padding * 2;
                    if (this.Width < this.Parent.Width)
                        this.Width = this.Parent.Width;
                    m_rectWorking = new Rectangle(padding, padding, intWidth, intHeight);
                    if (this.Height > this.Parent.Height)
                    {
                        //this.Location = new Point(0, 0);
                    }
                    else
                        this.Location = new Point(0, (this.Parent.Height - this.Height) / 2);
                }
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }
    }
}
