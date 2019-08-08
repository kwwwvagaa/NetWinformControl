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
    public partial class UCPagerControl : UserControl
    {
        public delegate void PageClickEvent(List<object> currentSource);
        /// <summary>
        /// 关联的数据源
        /// </summary>
        public List<object> Source { get; set; }
        public event PageClickEvent LeftClick;
        public event PageClickEvent RightClick;
        public event PageClickEvent ShowChanged;
        private int showCount = 1;
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        private int startIndex = 0;
        /// <summary>
        /// 开始的下标
        /// </summary>
        public int StartIndex
        {
            get { return startIndex; }
            set
            {
                startIndex = value;
                if (startIndex <= 0)
                    startIndex = 0;
            }
        }

        public UCPagerControl()
        {
            InitializeComponent();
        }

        public void NextPage()
        {
            if (startIndex + showCount >= Source.Count)
            {
                return;
            }
            startIndex += showCount;
            if (startIndex < 0)
                startIndex = 0;
            var s = GetCurrentSoutce();
            if (RightClick != null)
            {
                RightClick(s);
            }
            if (ShowChanged != null)
            {
                ShowChanged(s);
            }
        }

        public void LastPage()
        {
            if (startIndex == 0)
                return;
            startIndex -= showCount;
            if (startIndex < 0)
                startIndex = 0;
            var s = GetCurrentSoutce();
            if (LeftClick != null)
            {
                LeftClick(s);
            }
            if (ShowChanged != null)
            {
                ShowChanged(s);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            LastPage();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            NextPage();
        }
        public void Reload()
        {
            var s = GetCurrentSoutce();
            if (ShowChanged != null)
            {
                ShowChanged(s);
            }
        }
        public List<object> GetCurrentSoutce()
        {
            int intShowCount = showCount;
            if (intShowCount + startIndex > Source.Count)
                intShowCount = Source.Count - startIndex;
            object[] objs = new object[intShowCount];
            Source.CopyTo(startIndex, objs, 0, intShowCount);
            var lst = objs.ToList();

            if (lst.Count > 0)
            {
                if (Source.IndexOf(lst[0]) > 0)
                {
                    panel1.Visible = true;
                }
                else
                {
                    panel1.Visible = false;
                }
                if (Source.IndexOf(lst[lst.Count - 1]) >= Source.Count - 1)
                {
                    panel2.Visible = false;
                }
                else
                {
                    panel2.Visible = true;
                }
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = false;
            }




            return lst;
        }
    }
}
