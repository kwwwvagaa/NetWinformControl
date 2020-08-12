using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace HZH_Controls.Controls
{
    public partial class UCEllipseDialAisle : UserControl
    {
        [Description("点击项目事件，sender为项目序号，如果是-1，则表示按下的是中心键"), Category("自定义")]
        public event EventHandler ClickItemEvent;
        private List<EllipseDialAisleItem> items = new List<EllipseDialAisleItem>();

        [Description("节点"), Category("自定义")]
        public EllipseDialAisleItem[] Items
        {
            get { return items.ToArray(); }
            set
            {
                if (value == null)
                    items = new List<EllipseDialAisleItem>();
                else
                    items = value.ToList();
            }
        }

        private EllipseDialAisleItem centreItem;
        [Description("中心节点"), Category("自定义")]
        public EllipseDialAisleItem CentreItem
        {
            get { return centreItem; }
            set { centreItem = value; }
        }

        private bool enabledClick = true;

        [Description("是否启用点击"), Category("自定义")]
        public bool EnabledClick
        {
            get { return enabledClick; }
            set { enabledClick = value; }
        }

        private int itemSize = 30;

        [Description("节点大小"), Category("自定义")]
        public int ItemSize
        {
            get { return itemSize; }
            set { itemSize = value; }
        }

        private Color borderColor = Color.Red;

        [Description("边框颜色"), Category("自定义")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        Dictionary<EllipseDialAisleItem, RectangleF> m_lstItemRectCache = new Dictionary<EllipseDialAisleItem, RectangleF>();
        RectangleF centreRect;
        public UCEllipseDialAisle()
        {
            InitializeComponent();
            this.SizeChanged += UCEllipseDialAisle_SizeChanged;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            items = new List<EllipseDialAisleItem>();
            items.Add(new EllipseDialAisleItem() { Text = "1" });
            items.Add(new EllipseDialAisleItem() { Text = "2" });
            items.Add(new EllipseDialAisleItem() { Text = "3" });
            items.Add(new EllipseDialAisleItem() { Text = "4" });
            items.Add(new EllipseDialAisleItem() { Text = "5" });
            items.Add(new EllipseDialAisleItem() { Text = "6" });
            items.Add(new EllipseDialAisleItem() { Text = "7" });
            items.Add(new EllipseDialAisleItem() { Text = "8" });
            items.Add(new EllipseDialAisleItem() { Text = "9" });
            items.Add(new EllipseDialAisleItem() { Text = "10" });
            items.Add(new EllipseDialAisleItem() { Text = "11" });
            items.Add(new EllipseDialAisleItem() { Text = "12" });
            centreItem = new EllipseDialAisleItem() { Text = "-1" };
            UCEllipseDialAisle_SizeChanged(null, null);
            this.MouseClick += UCEllipseDialAisle_MouseClick;
        }
        void UCEllipseDialAisle_MouseClick(object sender, MouseEventArgs e)
        {
            if (!enabledClick)
                return;

            if (centreRect != null && centreRect.Contains(e.Location))
            {
                centreItem.Selected = !centreItem.Selected;
                if (ClickItemEvent != null)
                {
                    ClickItemEvent(centreItem, e);
                }
                Invalidate();
                return;
            }

            foreach (var item in m_lstItemRectCache)
            {
                if (item.Value.Contains(e.Location))
                {
                    item.Key.Selected = !item.Key.Selected;
                    if (ClickItemEvent != null)
                    {
                        ClickItemEvent(item.Key, e);
                    }
                    Invalidate();
                    break;
                }
            }
        }

        void UCEllipseDialAisle_SizeChanged(object sender, EventArgs e)
        {
            m_lstItemRectCache.Clear();
            if (items == null || items.Count <= 0)
                return;
            centreRect = new RectangleF((float)(this.Width - itemSize * 1.5) / 2f, (float)(this.Height - itemSize * 1.5) / 2f, (float)itemSize * 1.5f, (float)itemSize * 1.5f);
            var zhijing = this.Width > this.Height ? this.Height : this.Width;
            var yuanzhouchang = Math.PI * zhijing;
            var zongZhouChang = yuanzhouchang;
            if (this.Width > this.Height)
            {
                zongZhouChang += (this.Width - zhijing) * 2;
            }
            else
            {
                zongZhouChang += (this.Height - zhijing) * 2;
            }
            var sp = (float)(zongZhouChang / items.Count);

            int c1 = (int)(yuanzhouchang / 2 / sp);//计算半个圆可以放几个
            int c2 = items.Count / 2 - c1;//半个横线放几个
            if (this.Width > this.Height)
            {
                int index = 0;
                //上
                for (int i = 0; i < c2; i++)
                {
                    var rect = new RectangleF(this.Height / 2 + (this.Width - this.Height) / c2 / 2 + i * ((this.Width - this.Height) / c2) - itemSize / 2, 5f, itemSize, itemSize);
                    m_lstItemRectCache[items[index]] = rect;
                    index++;
                }
                //右
                float fltSplitValue = (float)180 / (float)c1;
                for (int i = 0; i < c1; i++)
                {
                    float fltAngle = (fltSplitValue * i + 90 + fltSplitValue / 2) % 360;
                    float fltFY1 = (float)(0 - itemSize / 2 + this.Height / 2 - ((this.Height / 2 - 15) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                    float fltFX1 = (float)(this.Width - this.Height / 2 - itemSize - ((this.Height / 2 - 10) * Math.Cos(Math.PI * (fltAngle / 180.00F))));
                    var rect = new RectangleF(fltFX1, fltFY1, itemSize, itemSize);
                    m_lstItemRectCache[items[index]] = rect;
                    index++;
                }

                //下
                for (int i = c2 - 1; i >= 0; i--)
                {
                    var rect = new RectangleF(this.Height / 2 + (this.Width - this.Height) / c2 / 2 + i * ((this.Width - this.Height) / c2) - itemSize / 2, this.Height - 5f - itemSize, itemSize, itemSize);
                    m_lstItemRectCache[items[index]] = rect;
                    index++;
                }
                //左
                for (int i = 0; i < c1; i++)
                {
                    float fltAngle = (fltSplitValue * i + 90 + 180 + fltSplitValue / 2) % 360;
                    float fltFY1 = (float)(0 - itemSize / 2 + this.Height / 2 - ((this.Height / 2 - 15) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                    float fltFX1 = (float)(this.Height / 2 - (((this.Height / 2 - 10) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));
                    var rect = new RectangleF(fltFX1, fltFY1, itemSize, itemSize);
                    m_lstItemRectCache[items[index]] = rect;
                    index++;
                }
            }
            else
            {
                int index = 0;
                float fltSplitValue = (float)180 / (float)c1;
                //上
                for (int i = 0; i < c1; i++)
                {
                    float fltAngle = (fltSplitValue * i  + fltSplitValue / 2) % 360;
                    float fltFY1 = (float)(this.Width / 2  - ((this.Width / 2 - 15) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                    float fltFX1 = (float)(this.Width / 2 - itemSize / 2 - ((this.Width / 2 - 10) * Math.Cos(Math.PI * (fltAngle / 180.00F))));
                    var rect = new RectangleF(fltFX1, fltFY1, itemSize, itemSize);
                    m_lstItemRectCache[items[index]] = rect;
                    index++;
                }
                //右
                for (int i = 0; i < c2; i++)
                {
                    var rect = new RectangleF(this.Width - itemSize - 5, this.Width / 2+(this.Height-this.Width)/c2/2+ i * ((this.Height-this.Width) / c2)-itemSize/2, itemSize, itemSize);
                    m_lstItemRectCache[items[index]] = rect;
                    index++;
                }
                //下
                for (int i = 0; i < c1; i++)
                {
                    float fltAngle = (fltSplitValue * i+180 + fltSplitValue / 2) % 360;
                    float fltFY1 = (float)(this.Height - this.Width/2  - itemSize  - ((this.Width / 2 - 15) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                    float fltFX1 = (float)(this.Width / 2 - itemSize / 2 - ((this.Width / 2 - 10) * Math.Cos(Math.PI * (fltAngle / 180.00F))));
                    var rect = new RectangleF(fltFX1, fltFY1, itemSize, itemSize);
                    m_lstItemRectCache[items[index]] = rect;
                    index++;
                }
                //左
                for (int i = c2-1; i >=0; i--)
                {
                    var rect = new RectangleF(5, this.Width / 2 + (this.Height - this.Width) / c2 / 2 + i * ((this.Height - this.Width) / c2) - itemSize / 2, itemSize, itemSize);
                    m_lstItemRectCache[items[index]] = rect;
                    index++;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();
            GraphicsPath path = new GraphicsPath();
            GraphicsPath borderpath = new GraphicsPath();


            if (this.Width > this.Height)
            {
                borderpath.AddArc(new Rectangle(1, 1, this.Height, this.Height-2), 90, 180);
                borderpath.AddArc(new Rectangle(this.Width - this.Height-2, 1, this.Height, this.Height-2), 270, 180);
                borderpath.CloseAllFigures();
                path.AddArc(new Rectangle(0, 0, this.Height, this.Height), 90, 180);
                path.AddArc(new Rectangle(this.Width - this.Height, 0, this.Height, this.Height), 270, 180);
                path.CloseAllFigures();
            }
            else
            {
                borderpath.AddArc(new Rectangle(1, 1, this.Width-2, this.Width), 180, 180);
                borderpath.AddArc(new Rectangle(1, this.Height - this.Width-2, this.Width-2, this.Width), 0, 180);
                borderpath.CloseAllFigures();

                path.AddArc(new Rectangle(0, 0, this.Width, this.Width), 180, 180);
                path.AddArc(new Rectangle(0, this.Height - this.Width, this.Width, this.Width), 0, 180);
                path.CloseAllFigures();
            }
            base.Region = new Region(path);

           
            foreach (var item in m_lstItemRectCache)
            {
                if (item.Key.Selected)
                {
                    g.FillEllipse(new SolidBrush(item.Key.SelectedBGColor), item.Value);
                    g.DrawString(item.Key.Text, item.Key.Font, new SolidBrush(item.Key.SelectedForeColor), item.Value, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                else
                {
                    g.FillEllipse(new SolidBrush(item.Key.BGColor), item.Value);
                    g.DrawString(item.Key.Text, item.Key.Font, new SolidBrush(item.Key.ForeColor), item.Value, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
            }

            if (centreRect != null && centreItem != null)
            {
                if (centreItem.Selected)
                {
                    g.FillEllipse(new SolidBrush(centreItem.SelectedBGColor), centreRect);
                    g.DrawString(centreItem.Text, centreItem.Font, new SolidBrush(centreItem.SelectedForeColor), centreRect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                else
                {
                    g.FillEllipse(new SolidBrush(centreItem.BGColor), centreRect);
                    g.DrawString(centreItem.Text, centreItem.Font, new SolidBrush(centreItem.ForeColor), centreRect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
            }

            g.DrawPath(new Pen(new SolidBrush(borderColor), 2), borderpath);
        }
    }
    [Serializable]
    public class EllipseDialAisleItem
    {
        public string Key { get; set; }
        public string Text { get; set; }
        Color bGColor = Color.FromArgb(255, 77, 59);
        /// <summary>
        /// 背景色
        /// </summary>
        public Color BGColor { get { return bGColor; } set { bGColor = value; } }
        Color selectedBGColor = Color.FromArgb(78, 201, 176);
        /// <summary>
        /// 选中时背景色
        /// </summary>
        public Color SelectedBGColor { get { return selectedBGColor; } set { selectedBGColor = value; } }
        Color foreColor = Color.White;
        /// <summary>
        /// 文字颜色
        /// </summary>
        public Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }
        Color selectedForeColor = Color.White;
        /// <summary>
        /// 选中时文字颜色
        /// </summary>
        public Color SelectedForeColor
        {
            get { return selectedForeColor; }
            set { selectedForeColor = value; }
        }
        Font font = new Font("微软雅黑", 10);
        /// <summary>
        /// 字体
        /// </summary>
        public Font Font { get { return font; } set { font = value; } }
        /// <summary>
        /// 关联的数据
        /// </summary>
        public object DataSource { get; set; }
        public bool Selected { get; set; }
    }
}
