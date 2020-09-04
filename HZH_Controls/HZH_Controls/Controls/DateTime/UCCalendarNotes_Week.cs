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
    [DefaultEvent("ClickNote")]
    public partial class UCCalendarNotes_Week : UserControl
    {
        /// <summary>
        /// 点击节点委托
        /// </summary>
        /// <param name="note">节点</param>
        /// <returns>是否刷新列表显示</returns>
        public delegate bool ClickNoteEvent(NoteEntity note);
        public delegate void AddNoteEvent(DateTime beginTime);
        /// <summary>
        /// 点击节点时间
        /// </summary>
        [Description("点击节点事件"), Category("自定义")]
        public event ClickNoteEvent ClickNote;

        [Description("点击关闭按钮事件"), Category("自定义")]
        public event EventHandler CloseClick;

        [Description("点击添加按钮事件"), Category("自定义")]
        public event AddNoteEvent AddClick;
        private object dataSource;

        List<NoteEntity> _dataSource;
        List<NoteEntity> _currentDataSource;
        /// <summary>
        /// 每个时间点的数据
        /// </summary>
        Dictionary<int, List<NoteEntity>> m_lstHourSource = new Dictionary<int, List<NoteEntity>>();
        Dictionary<int, Rectangle> m_lstAddRect = new Dictionary<int, Rectangle>();
        Dictionary<NoteEntity, Rectangle> m_lstRects = new Dictionary<NoteEntity, Rectangle>();
        int maxSplit = 1;
        int splitWidth = 1;
        [Description("数据源List<NoteEntity>"), Category("自定义")]
        public object DataSource
        {
            get { return dataSource; }
            set
            {
                dataSource = value;
                if (value != null)
                {
                    if (value is List<NoteEntity>)
                    {
                        _dataSource = (List<NoteEntity>)value;
                        ResetCurrentDataSource();
                        Invalidate();
                    }
                    else
                    {
                        throw new Exception("不是有效的数据源类型");
                    }
                }
            }
        }
        [Description("是否显示关闭按钮"), Category("自定义")]
        public bool ShowCloseButton { get { return lblClose.Visible; } set { lblClose.Visible = value; } }
        [Description("是否显示添加按钮"), Category("自定义")]
        public bool ShowAddButton { get { return lblAdd.Visible; } set { lblAdd.Visible = value; } }
        DateTime m_dt = DateTime.Now;

        [Description("当前日期"), Category("自定义")]
        public DateTime CurrentTime
        {
            get { return m_dt; }
            set
            {
                string old = m_dt.ToString("yyyy-MM-dd");
                string newStr = value.ToString("yyyy-MM-dd");
                bool blnRefresh = false;
                if (old != newStr)
                {
                    blnRefresh = true;
                }
                m_dt = value;
                SetTimeToControl();
                ResetCurrentDataSource();
                if (blnRefresh)
                    panMain.Invalidate();
            }
        }

        private Color splitLineColor = Color.FromArgb(153, 153, 153);

        [Description("分割线颜色"), Category("自定义")]
        public Color SplitLineColor
        {
            get { return splitLineColor; }
            set
            {
                splitLineColor = value;
                Invalidate();
            }
        }

        private Color splitTimeForeColor = Color.FromArgb(153, 153, 153);

        [Description("分割时间文字颜色"), Category("自定义")]
        public Color SplitTimeForeColor
        {
            get { return splitTimeForeColor; }
            set
            {
                splitTimeForeColor = value;
                Invalidate();
            }
        }

        private void ResetCurrentDataSource()
        {
            string newStr = m_dt.ToString("yyyy-MM-dd");
            m_lstHourSource.Clear();
            m_lstRects.Clear();
            maxSplit = 1;
            if (_dataSource != null)
            {
                _currentDataSource = _dataSource.FindAll(p => p.BeginTimeStr == newStr || p.EndTimeStr == newStr || (CurrentTime >= p.BeginTime && CurrentTime <= p.EndTime));
                foreach (var item in _currentDataSource)
                {
                    DateTime dt2 = DateTime.Parse(item.EndTime.Value.ToString("yyyy-MM-dd") + " " + item.EndTime.Value.Hour + ":00:00");
                    int beginHour = 0;
                    if (item.BeginTime.Day == CurrentTime.Day)
                        beginHour = item.BeginTime.Hour;
                    for (int i = beginHour; i < 24; i++)
                    {
                        DateTime dt1 = DateTime.Parse(item.BeginTime.ToString("yyyy-MM-dd") + " " + i + ":00:00");
                        if (dt1 <= dt2)
                        {
                            if (!m_lstHourSource.ContainsKey(i))
                                m_lstHourSource[i] = new List<NoteEntity>();
                            m_lstHourSource[i].Add(item);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (m_lstHourSource.Count > 0)
                    maxSplit = m_lstHourSource.Max(p => p.Value.Count);
                CheckCom();
            }
        }



        public UCCalendarNotes_Week()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SizeChanged += UCCalendarNotes_Week_SizeChanged;
        }

        void UCCalendarNotes_Week_SizeChanged(object sender, EventArgs e)
        {
            splitWidth = this.Width / maxSplit;
            CheckCom();
        }

        private void CheckCom()
        {
            splitWidth = this.Width / maxSplit;
            for (int i = 0; i < 24; i++)
            {
                if (m_lstHourSource.ContainsKey(i))
                {
                    int index = 0;
                    var lst = m_lstHourSource[i].OrderBy(p => p.BeginTime);
                    foreach (var item in lst)
                    {
                        if ((item.BeginTime.Hour == i && item.BeginTime.Day == CurrentTime.Day) || i == 0)//如果开始时间在当前区间测画矩形
                        {
                            int y1 = (int)((item.BeginTime.Day == CurrentTime.Day ? item.BeginTime.Minute : 0) / 60.000f * 50.0000f);
                            int rectY = 10 + i * 50 + 1 + y1;
                            int h1 = (int)((item.EndTime.Value - (item.BeginTime.Day == CurrentTime.Day ? item.BeginTime : DateTime.Parse(CurrentTime.ToString("yyyy-MM-dd 00:00:00")))).TotalMinutes);
                            int h2 = (int)((DateTime.Parse(CurrentTime.ToString("yyyy-MM-dd 23:59:59")) - (item.BeginTime.Day == CurrentTime.Day ? item.BeginTime : DateTime.Parse(CurrentTime.ToString("yyyy-MM-dd 00:00:00")))).TotalMinutes);
                            int h = h1;
                            if (h1 > h2)
                                h = h2;
                            int height = (int)(h / 60.000f * 50.0000f);
                            m_lstRects[item] = new Rectangle(40 + index * splitWidth, rectY, splitWidth - 5, height);
                        }
                        index++;
                    }
                }

                Rectangle rectAdd = new Rectangle(5, 20 + i * 50, 35, 30);
                m_lstAddRect[i] = rectAdd;
            }
        }



        private void SetTimeToControl()
        {
            int week = (int)m_dt.DayOfWeek;
            DateTime _dt = m_dt.AddDays(-week);

            lblWeek_1.Text = "周日\n\r" + _dt.ToString("M-d");
            lblWeek_1.Tag = _dt;
            _dt = _dt.AddDays(1);
            lblWeek_2.Text = "周一\n\r" + _dt.ToString("M-d");
            lblWeek_2.Tag = _dt;
            _dt = _dt.AddDays(1);
            lblWeek_3.Text = "周二\n\r" + _dt.ToString("M-d");
            lblWeek_3.Tag = _dt;
            _dt = _dt.AddDays(1);
            lblWeek_4.Text = "周三\n\r" + _dt.ToString("M-d");
            lblWeek_4.Tag = _dt;
            _dt = _dt.AddDays(1);
            lblWeek_5.Text = "周四\n\r" + _dt.ToString("M-d");
            lblWeek_5.Tag = _dt;
            _dt = _dt.AddDays(1);
            lblWeek_6.Text = "周五\n\r" + _dt.ToString("M-d");
            lblWeek_6.Tag = _dt;
            _dt = _dt.AddDays(1);
            lblWeek_7.Text = "周六\n\r" + _dt.ToString("M-d");
            lblWeek_7.Tag = _dt;

            foreach (Control item in this.panWeek.Controls)
            {
                if (item.Name.StartsWith("lblWeek_"))
                {
                    if (item.Name == "lblWeek_" + (week + 1))
                    {
                        item.ForeColor = Color.White;
                        item.BackColor = Color.FromArgb(255, 77, 59);
                    }
                    else
                    {
                        item.BackColor = Color.White;
                        item.ForeColor = Color.FromArgb(255, 77, 59);
                    }
                }
            }
        }
        private void panMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SetGDIHigh();
            //画基础线
            for (int i = 0; i < 24; i++)
            {
                g.DrawString(i.ToString().PadLeft(2, '0') + ":00", new Font("Arial Unicode MS", 9), new SolidBrush(splitTimeForeColor), new PointF(5, 2 + i * 50));
                g.DrawLine(new Pen(new SolidBrush(splitLineColor), 1), new Point(40, 10 + i * 50), new Point(panMain.Width, 10 + i * 50));

            }
            g.DrawString("00:00", new Font("Arial Unicode MS", 9), new SolidBrush(splitTimeForeColor), new PointF(5, 2 + 24 * 50));
            g.DrawLine(new Pen(new SolidBrush(splitLineColor), 1), new Point(40, 10 + 24 * 50), new Point(panMain.Width, 10 + 24 * 50));

            foreach (var item in m_lstRects)
            {
                g.FillPath(new SolidBrush(item.Key.NoteColor), item.Value.CreateRoundedRectanglePath(5));
                g.DrawLine(new Pen(new SolidBrush(item.Key.NoteLeftLineColor), 2), new Point(item.Value.Left + 1, item.Value.Top + 2), new Point(item.Value.Left + 1, item.Value.Bottom - 2));
                g.DrawString(item.Key.Title, new Font("微软雅黑", 9), new SolidBrush(item.Key.NoteForeColor), new Rectangle(item.Value.Left + 4, item.Value.Top + 1, item.Value.Width - 4, item.Value.Height - 1));
            }

            foreach (var item in m_lstAddRect)
            {
                g.DrawString("+", new Font("微软雅黑", 15), new SolidBrush(splitTimeForeColor), item.Value, new StringFormat() {  Alignment= StringAlignment.Center, LineAlignment= StringAlignment.Center});
            }
        }

        private void lblLeft_MouseClick(object sender, MouseEventArgs e)
        {
            CurrentTime = CurrentTime.AddDays(-7);
        }

        private void lblRight_MouseClick(object sender, MouseEventArgs e)
        {
            CurrentTime = CurrentTime.AddDays(7);
        }

        private void panMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (!this.panMain.Focused)
            {
                //this.FindForm().ActiveControl = this;
                //this.ActiveControl = panMain;
                panMain.Focus();
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                foreach (var item in m_lstAddRect)
                {
                    if (item.Value.Contains(e.Location))
                    {
                        if (AddClick != null)
                        {
                            AddClick(DateTime.Parse(CurrentTime.ToString("yyyy-MM-dd") + " " + item.Key + ":00:00"));
                            panMain.Invalidate();
                        }
                        return;
                    }
                }

                foreach (var item in m_lstRects)
                {
                    if (item.Value.Contains(e.Location))
                    {
                        if (ClickNote != null)
                        {
                            int y = panel1.VerticalScroll.Value;
                            ControlHelper.FreezeControl(panel1, true);
                            if (ClickNote(item.Key))
                            {
                                panMain.Invalidate();
                            }
                            if (y != panel1.VerticalScroll.Value)
                            {
                                panel1.VerticalScroll.Value = y;
                                panel1.VerticalScroll.Value = y;
                            }
                            ControlHelper.FreezeControl(panel1, false);
                        }
                        return;
                    }
                }
            }
        }

        private void lblWeek_Click(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            CurrentTime = (DateTime)c.Tag;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            if (CloseClick != null)
                CloseClick(this, e);
        }

        private void UCCalendarNotes_Week_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //this.FindForm().ActiveControl = this;
                //this.ActiveControl = panMain;
                panMain.Focus();
            }
        }

        private void lblAdd_Click(object sender, EventArgs e)
        {
            if (AddClick != null)
            {
                AddClick(DateTime.Parse(CurrentTime.ToString("yyyy-MM-dd")));
                panMain.Invalidate();
            }
        }
    }
}
