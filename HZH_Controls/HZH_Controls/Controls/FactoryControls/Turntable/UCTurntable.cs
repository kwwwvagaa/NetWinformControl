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
    public partial class UCTurntable : UserControl
    {
        private int rouletteHeight = 40;

        [Description("轮盘高度"), Category("自定义")]
        public int RouletteHeight
        {
            get { return rouletteHeight; }
            set { rouletteHeight = value; }
        }

        private Color rouletteColor = Color.FromArgb(63, 63, 70);

        [Description("轮盘颜色"), Category("自定义")]
        public Color RouletteColor
        {
            get { return rouletteColor; }
            set { rouletteColor = value; }
        }

        private int itemWidth = 35;

        [Description("节点宽度"), Category("自定义")]
        public int ItemWidth
        {
            get { return itemWidth; }
            set
            {
                itemWidth = value;
                if (items != null)
                {
                    foreach (var i in items)
                    {
                        i.Value.Width = itemWidth;
                    }
                }
            }
        }

        private Color emptyItemColor = Color.FromArgb(214, 157, 113);

        [Description("节点无内容时颜色"), Category("自定义")]
        public Color EmptyItemColor
        {
            get { return emptyItemColor; }
            set { emptyItemColor = value; }
        }

        private int showItemCount = 4;

        [Description("显示的节点个数，必须小于等于总节点数量"), Category("自定义")]
        public int ShowItemCount
        {
            get { return showItemCount; }
            set { showItemCount = value; }
        }
        //显示节点左上角位置
        private Dictionary<int, Point> lstShowItemPoints = new Dictionary<int, Point>();

        private int itemCount = 10;

        [Description("节点总数，必须大于等于ShowItemCount"), Category("自定义")]
        public int ItemCount
        {
            get { return itemCount; }
            set { itemCount = value; }
        }

        private Dictionary<int, UCBottle> items = new Dictionary<int, UCBottle>();

        public void SetItems(Dictionary<int, UCBottle> value)
        {
            items = value;
            if (value != null)
            {
                foreach (var i in value)
                {
                    i.Value.Width = itemWidth;
                    i.Value.Height = this.Height - 10;
                }
            }
            ReloadControls();
        }


        private int indexNum = 0;
        public UCTurntable()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.SizeChanged += UCTurntable_SizeChanged;
            UCTurntable_SizeChanged(null, null);
        }

        void UCTurntable_SizeChanged(object sender, EventArgs e)
        {
            ReloadItemsLocation();
            if (items != null)
            {
                foreach (var i in items)
                {
                    i.Value.Height = this.Height - 10;
                }
            }
            ReloadControls();
        }

        private void ReloadControls()
        {
            this.Controls.Clear();
            if (items != null)
            {
                for (int i = 0; i < showItemCount; i++)
                {
                    if (items.ContainsKey((i + indexNum) % (itemCount)))
                    {
                        items[(i + indexNum) % (itemCount)].Location = new Point(lstShowItemPoints[i].X, 5);
                        this.Controls.Add(items[(i + indexNum) % (itemCount)]);
                    }
                }
            }
        }

        private void ReloadItemsLocation()
        {
            int split = (this.Width - 10 * 2 - itemWidth) / (showItemCount - 1);
            for (int i = 0; i < showItemCount; i++)
            {
                lstShowItemPoints[i] = new Point(10 + split * i, (this.Height - rouletteHeight) / 2);
            }
            ReloadControls();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.FillRectangle(new SolidBrush(rouletteColor), new Rectangle(0, (this.Height - rouletteHeight) / 2, this.Width, rouletteHeight));
            foreach (var item in lstShowItemPoints)
            {
                g.FillRectangle(new SolidBrush(emptyItemColor), new Rectangle(item.Value, new Size(itemWidth, rouletteHeight)));
            }
            //渐变色
            int _intPenWidth = rouletteHeight;
           
            int intCount = _intPenWidth / 2 / 4;
            for (int i = 0; i < intCount; i++)
            {
                int _penWidth = _intPenWidth / 2 - 4 * i;
                if (_penWidth <= 0)
                    _penWidth = 1;
                g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(40, Color.White.R, Color.White.G, Color.White.B)), _penWidth),new Point(0,this.Height/2),new Point(this.Width,this.Height/2));
                if (_penWidth == 1)
                    break;
            }
        }

        public void LeftItem()
        {
            indexNum--;
            if (indexNum < 0)
                indexNum = itemCount - 1;
            ReloadControls();
        }

        public void RightItem()
        {
            indexNum++;
            if (indexNum >= itemCount)
                indexNum = 0;
            ReloadControls();
        }

        public void AddItem(int index, UCBottle item)
        {
            item.Width = itemWidth;
            item.Height = this.Height - 10;

            items[index] = item;
            ReloadControls();
        }

        public void RemoveItem(int index)
        {
            if (items.ContainsKey(index))
            {
                this.Controls.Remove(items[index]);
                items.Remove(index);
                ReloadControls();
            }
        }


        public void RemoveItem(UCBottle item)
        {
            if (items.ContainsValue(item))
            {
                items.Remove(items.FirstOrDefault(p => p.Value == item).Key);
                this.Controls.Remove(item);
                ReloadControls();
            }
        }
    }
}
