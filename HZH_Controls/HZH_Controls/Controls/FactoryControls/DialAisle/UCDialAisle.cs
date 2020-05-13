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
    public partial class UCDialAisle : UserControl
    {
        [Description("点击项目事件，sender为项目序号，如果是-1，则表示按下的是C键"), Category("自定义")]
        public event EventHandler ClickItemEvent;

        [Description("连通项目事件，sender为一个数组，表示已连通的项目，数组内容为项目序号，如果数组长度为0则表示当前没有任何连通，如果长度为1则表示单方连通"), Category("自定义")]
        public event EventHandler LineItemEvent;
        private Color dialColor = Color.FromArgb(236, 219, 209);

        [Description("圆盘颜色"), Category("自定义")]
        public Color DialColor
        {
            get { return dialColor; }
            set
            {
                dialColor = value;
                Refresh();
            }
        }

        private string[] itemTexts;

        [Description("转盘项目文字"), Category("自定义")]
        public string[] ItemTexts
        {
            get { return itemTexts; }
            set
            {
                if (value == null || value.Length < 2)
                    return;
                itemTexts = value;
                Refresh();
            }
        }

        Dictionary<int, RectangleF> m_lstItemRectCache = new Dictionary<int, RectangleF>();

        private Color itemColor = Color.FromArgb(215, 221, 224);

        [Description("项目颜色"), Category("自定义")]
        public Color ItemColor
        {
            get { return itemColor; }
            set
            {
                itemColor = value;
                Refresh();
            }
        }

        private Color itemForeColor = Color.Black;

        [Description("项目文字颜色"), Category("自定义")]
        public Color ItemForeColor
        {
            get { return itemForeColor; }
            set
            {
                itemForeColor = value;
                Refresh();
            }
        }

        private Color itemSelectColor = Color.Green;

        [Description("项目选中时颜色"), Category("自定义")]
        public Color ItemSelectColor
        {
            get { return itemSelectColor; }
            set
            {
                itemSelectColor = value;
                Refresh();
            }
        }

        private Color itemSelectForeColor = Color.White;

        [Description("项目选中时文字颜色"), Category("自定义")]
        public Color ItemSelectForeColor
        {
            get { return itemSelectForeColor; }
            set
            {
                itemSelectForeColor = value;
                Refresh();
            }
        }

        private Color linkColor = Color.FromArgb(255, 77, 59);

        [Description("链接管道颜色"), Category("自定义")]
        public Color LinkColor
        {
            get { return linkColor; }
            set
            {
                linkColor = value;
                Refresh();
            }
        }

        private bool enabledClick = false;

        [Description("是否启用点击"), Category("自定义")]
        public bool EnabledClick
        {
            get { return enabledClick; }
            set { enabledClick = value; }
        }

        private List<int> m_lstSelectItemIndex = new List<int>();

        Rectangle m_rectWorking;
        public UCDialAisle()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ItemTexts = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            UCDialAisle_SizeChanged(null, null);
            this.SizeChanged += UCDialAisle_SizeChanged;
            this.MouseClick += UCDialAisle_MouseClick;
        }

        void UCDialAisle_MouseClick(object sender, MouseEventArgs e)
        {
            if (!enabledClick)
                return;
            foreach (var item in m_lstItemRectCache)
            {
                if (ClickItemEvent != null)
                {
                    ClickItemEvent(item.Key, e);
                }
                if (item.Value.Contains(e.Location))
                {
                    if (item.Key == -1)
                    {
                        m_lstSelectItemIndex.Clear();
                        Refresh();
                    }
                    else
                    {
                        if (m_lstSelectItemIndex.Contains(item.Key))
                        {
                            m_lstSelectItemIndex.Remove(item.Key);
                            Refresh();
                        }
                        else if (m_lstSelectItemIndex.Count < 2)
                        {
                            m_lstSelectItemIndex.Add(item.Key);
                            Refresh();
                        }
                    }
                    if (LineItemEvent != null)
                    {
                        LineItemEvent(m_lstSelectItemIndex.ToArray(), e);
                    }
                }
            }
        }


        void UCDialAisle_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width < 120)
            {
                this.Width = 120;
                return;
            }
            if (this.Height < 120)
            {
                this.Height = 120;
                return;
            }
            int min = Math.Min(this.Width, this.Height);
            m_rectWorking = new Rectangle((this.Width - min) / 2, (this.Height - min) / 2, min, min);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(m_rectWorking);
            this.Region = new System.Drawing.Region(path);
            m_lstItemRectCache.Clear();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();
            g.FillEllipse(new SolidBrush(dialColor), m_rectWorking);

            //分割线
            int _splitCount = itemTexts.Length;
            float fltSplitValue = (float)360 / (float)_splitCount;
            var rectc = new RectangleF(m_rectWorking.Left + m_rectWorking.Width / 2 - 12.5f, m_rectWorking.Top + m_rectWorking.Height / 2 - 12.5f, 25, 25);

            for (int i = 0; i < _splitCount; i++)
            {
                float fltAngle = (fltSplitValue * i + 90) % 360;
                float fltY1 = (float)(m_rectWorking.Top + m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                float fltX1 = (float)(m_rectWorking.Left + (m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));
                float fltY2 = 0;
                float fltX2 = 0;

                fltY2 = (float)(m_rectWorking.Top + m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 10) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                fltX2 = (float)(m_rectWorking.Left + (m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 10) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));

                var txtSize = new Size(25, 25);
                float fltFY1 = (float)(m_rectWorking.Top - txtSize.Height / 2 + m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 20) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                float fltFX1 = (float)(m_rectWorking.Left - txtSize.Width / 2 + (m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 20) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));
                var rect = new RectangleF(fltFX1, fltFY1, 25, 25);
                if (m_lstSelectItemIndex.Contains(i))
                {
                    g.DrawLine(new Pen(new SolidBrush(linkColor), 9), new PointF(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2), new PointF(rectc.Left + rectc.Width / 2, rectc.Top + rectc.Height / 2));
                    g.FillEllipse(new SolidBrush(itemSelectColor), rect);
                    g.DrawString(itemTexts[i], new Font("微软雅黑", 10), new SolidBrush(itemSelectForeColor), rect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                else
                {
                    g.FillEllipse(new SolidBrush(itemColor), rect);
                    g.DrawString(itemTexts[i], new Font("微软雅黑", 10), new SolidBrush(itemForeColor), rect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                if (!m_lstItemRectCache.ContainsKey(i))
                {
                    m_lstItemRectCache[i] = rect;
                }
            }
            g.FillEllipse(new SolidBrush(itemColor), rectc);
            g.DrawString("C", new Font("微软雅黑", 10), new SolidBrush(itemForeColor), new RectangleF(m_rectWorking.Left + m_rectWorking.Width / 2 - 12.5f, m_rectWorking.Top + m_rectWorking.Height / 2 - 12.5f, 25, 25), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            if (!m_lstItemRectCache.ContainsKey(-1))
            {
                m_lstItemRectCache[-1] = rectc;
            }
        }
        /// <summary>
        /// 添加一个链接
        /// </summary>
        /// <param name="index">链接下标</param>
        /// <returns>是否成功</returns>
        public bool AddLink(int index)
        {
            if (index >= itemTexts.Length)
                return false;
            if (m_lstSelectItemIndex.Count < 2)
            {
                m_lstSelectItemIndex.Add(index);
                Refresh();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 移除一个链接
        /// </summary>
        /// <param name="index">链接下标</param>
        /// <returns>是否成功</returns>
        public bool RemoveLink(int index)
        {
            if (index >= itemTexts.Length)
                return false;
            if (m_lstSelectItemIndex.Count <= 0)
            {
                return false;
            }
            else
            {
                if (m_lstSelectItemIndex.Contains(index))
                {
                    m_lstSelectItemIndex.Remove(index);
                    Refresh();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 清空所有链接
        /// </summary>
        public void ClearAllLink()
        {
            m_lstSelectItemIndex.Clear();
            Refresh();
        }
    }
}
