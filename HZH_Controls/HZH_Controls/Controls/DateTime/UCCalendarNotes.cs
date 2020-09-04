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
    public partial class UCCalendarNotes : UserControl
    {
        /// <summary>
        /// 点击节点委托
        /// </summary>
        /// <param name="note">节点</param>
        /// <returns>是否刷新列表显示</returns>
        public delegate bool ClickNoteEvent(NoteEntity note);
        /// <summary>
        /// 点击节点时间
        /// </summary>
        [Description("点击节点事件"), Category("自定义")]
        public event ClickNoteEvent ClickNote;
        [Description("点击添加按钮事件"), Category("自定义")]
        public event UCCalendarNotes_Week.AddNoteEvent AddClick;
        private object dataSource;

        List<NoteEntity> _dataSource;

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
                        this.panDay.Invalidate();
                        this.ucCalendarNotes_Week1.DataSource = value;
                    }
                    else
                    {
                        throw new Exception("不是有效的数据源类型");
                    }
                }
            }
        }

        DateTime m_dt = DateTime.Now;

        /// <summary>
        /// Gets or sets the current time.
        /// </summary>
        /// <value>The current time.</value>
        [Description("当前日期"), Category("自定义")]
        public DateTime CurrentTime
        {
            get { return m_dt; }
            set
            {
                m_dt = value;
                SetTimeToControl();
                ucCalendarNotes_Week1.CurrentTime = value;
            }
        }
        private Color tipColor = Color.Green;

        [Description("Tip颜色"), Category("自定义")]
        public Color TipColor
        {
            get { return tipColor; }
            set { tipColor = value; }
        }

        private Color selectColor = Color.FromArgb(255, 77, 59);

        [Description("选中颜色"), Category("自定义")]
        public Color SelectColor
        {
            get { return selectColor; }
            set
            {
                selectColor = value;
                panTop.BackColor = value;
                foreach (Label lbl in panWeek.Controls)
                {
                    lbl.ForeColor = value;
                }
                panSelectYear.BackColor = value;
                panSelectMonth.BackColor = value;
                foreach (Control item in panTop.Controls)
                {
                    if (item is UCBtnExt)
                        ((UCBtnExt)item).FillColor = value;
                }
                ucSplitLine_H2.BackColor = value;
                ucSplitLine_V4.BackColor = value;
                ucSplitLine_V5.BackColor = value;
            }
        }

        [Description("文字字体"), Category("自定义")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                foreach (Label lblDay in panDay.Controls)
                {
                    lblDay.Font = Font;
                }
            }
        }
        public UCCalendarNotes()
        {
            InitializeComponent();
            foreach (Label lblDay in panDay.Controls)
            {
                lblDay.MouseClick += lblDay_MouseClick;
                lblDay.Paint += lblDay_Paint;
            }
            foreach (Label lblMonthItem in panSelectMonthList.Controls)
            {
                lblMonthItem.MouseClick += lblMonthItem_MouseClick;
            }
            foreach (Label lblYearItem in panSelectYearList.Controls)
            {
                lblYearItem.MouseClick += lblYearItem_MouseClick;
            }
        }


        void lblDay_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;
                string data = DateTime.Parse(m_dt.Year + "-" + lbl.Tag).ToString("yyyy-MM-dd");
                if (_dataSource != null && _dataSource.Count > 0)
                {
                    if (_dataSource.Any(p => p.BeginTimeStr == data || p.EndTimeStr == data))
                    {
                        e.Graphics.SetGDIHigh();
                        e.Graphics.FillEllipse(new SolidBrush(tipColor), new Rectangle(lbl.ClientRectangle.Right - 13, lbl.ClientRectangle.Top + 3, 10, 10));
                    }
                }
            }
            catch
            { }
        }
        void lblYearItem_MouseClick(object sender, MouseEventArgs e)
        {
            panSelectYear.Visible = false;
            CurrentTime = DateTime.Parse(((Label)sender).Tag + "-" + m_dt.Month + "-" + m_dt.Day);
        }

        void lblMonthItem_MouseClick(object sender, MouseEventArgs e)
        {
            panSelectMonth.Visible = false;
            CurrentTime = DateTime.Parse(m_dt.Year + "-" + ((Label)sender).Tag + "-" + m_dt.Day);
        }

        void lblDay_MouseClick(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            if (m_dt.Month + "-" + m_dt.Day != lbl.Tag.ToString())
            {
                CurrentTime = DateTime.Parse(m_dt.Year + "-" + lbl.Tag);
            }
            ucCalendarNotes_Week1.Visible = true;
            ucCalendarNotes_Week1.BringToFront();
        }
        private void SetTimeToControl()
        {
            if (lblYear.Tag.ToInt() != m_dt.Year)
            {
                lblYear.Tag = m_dt.Year;
                lblYear.Text = m_dt.Year + "年 ▼";
            }
            if (lblMouth.Tag.ToInt() != m_dt.Month)
            {
                lblMouth.Tag = m_dt.Month;
                lblMouth.Text = m_dt.Month.ToString().PadLeft(2, '0') + "月 ▼";
            }

            //if (panDay.Tag.ToInt() != m_dt.Day)
            //{
            panDay.Tag = m_dt.Day;
            panDay.Controls.ToArray().ToList().ForEach(p =>
            {
                Label lbl = (Label)p;
                if (p.Tag.ToStringExt() == (m_dt.Month + "-" + m_dt.Day))
                {
                    lbl.BackColor = selectColor;
                    lbl.ForeColor = Color.White;
                }
                else
                {
                    lbl.BackColor = Color.White;
                    if (p.Tag.ToStringExt().Split('-')[0].ToInt() != m_dt.Month)
                    {
                        lbl.ForeColor = Color.FromArgb(153, 153, 153);
                    }
                    else
                    {
                        lbl.ForeColor = selectColor;
                    }
                }
            });
            //}
            //btnDay.Tag = m_dt.Day;
            //btnDay.BtnText = m_dt.Day.ToString().PadLeft(2, '0') + "日";


        }
        private void lblYear_Click(object sender, EventArgs e)
        {
            panSelectMonth.Visible = false;
            panSelectYear.Visible = !panSelectYear.Visible;
        }

        private void panSelectYear_VisibleChanged(object sender, EventArgs e)
        {
            if (panSelectYear.Visible)
            {
                BindYearList(CurrentTime.Year);
            }
        }

        private void BindYearList(int year)
        {
            List<int> lst = new List<int>();
            for (int i = year - 7; i < year + 7; i++)
            {
                lst.Add(i);
            }
            for (int i = 0; i < lst.Count; i++)
            {
                ((Label)this.panSelectYearList.Controls[this.panSelectYearList.Controls.Count - i - 1]).Text = lst[i] + "年";
                this.panSelectYearList.Controls[this.panSelectYearList.Controls.Count - i - 1].Tag = lst[i];
            }
        }

        private void lblMouth_TextChanged(object sender, EventArgs e)
        {
            int mouth = ((Label)sender).Tag.ToInt();
            CurrentTime = DateTime.Parse(m_dt.Year + "-" + mouth + "-" + m_dt.Day);
            int intDayCount = DateTime.DaysInMonth(m_dt.Year, m_dt.Month);
            DateTime dtlastMonth = m_dt.AddMonths(-1);
            int intlasyMonthDayCount = DateTime.DaysInMonth(dtlastMonth.Year, dtlastMonth.Month);
            DateTime dt1 = DateTime.Parse(m_dt.Year + "-" + m_dt.Month + "-01");
            int intIndex = (int)(dt1.DayOfWeek);
            int haveLastDay = 0;//需要上月补充几天
            haveLastDay = intIndex;

            List<KeyValuePair<int, int>> lst = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < haveLastDay; i++)
            {
                lst.Add(new KeyValuePair<int, int>(dtlastMonth.Month, intlasyMonthDayCount - (haveLastDay - i) + 1));
            }
            for (int i = 0; i < intDayCount; i++)
            {
                lst.Add(new KeyValuePair<int, int>(mouth, i + 1));
            }
            if (lst.Count < 42)
            {
                DateTime dtNextMonth = m_dt.AddMonths(1);
                int cha = 42 - lst.Count;
                for (int i = 0; i < cha; i++)
                {
                    lst.Add(new KeyValuePair<int, int>(dtNextMonth.Month, i + 1));
                }
            }
            for (int i = 0; i < lst.Count; i++)
            {
                var lbl = (Label)this.panDay.Controls[this.panDay.Controls.Count - i - 1];
                lbl.Text = lst[i].Value.ToString();
                if (lst[i].Key != mouth)
                {
                    lbl.ForeColor = Color.FromArgb(153, 153, 153);
                }
                else
                {
                    lbl.ForeColor = selectColor;
                }
                if (lst[i].Key + ":" + lst[i].Value != m_dt.Month + "-" + m_dt.Day)
                {
                    lbl.BackColor = Color.White;
                }
                else
                {
                    lbl.BackColor = selectColor;
                    lbl.ForeColor = Color.White;
                }
                lbl.Tag = lst[i].Key + "-" + lst[i].Value;
            }
        }

        private void lblMouth_Click(object sender, EventArgs e)
        {
            panSelectMonth.Visible = !panSelectMonth.Visible;
            panSelectYear.Visible = false;
        }

        private void ucCalendarNotes_Week1_CloseClick(object sender, EventArgs e)
        {
            this.ucCalendarNotes_Week1.Visible = false;
        }

        private bool ucCalendarNotes_Week1_ClickNote(NoteEntity note)
        {
            if (ClickNote != null)
            {
                return ClickNote(note);
            }
            return default(bool);
        }

        private void ucCalendarNotes_Week1_AddClick(DateTime beginTime)
        {
            if (AddClick != null)
                AddClick(beginTime);
        }

    }
    [Serializable]
    public class NoteEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 备忘开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 备忘开始日期字符串
        /// </summary>
        public string BeginTimeStr
        {
            get
            {
                return BeginTime.ToString("yyyy-MM-dd");
            }
        }
        DateTime? endTime;
        /// <summary>
        /// 备忘结束时间
        /// </summary>
        public DateTime? EndTime
        {
            get
            {
                return endTime ?? BeginTime.AddHours(1);
            }
            set { endTime = value; }
        }
        /// <summary>
        /// 备忘结束日期字符串
        /// </summary>
        public string EndTimeStr
        {
            get
            {
                return (EndTime ?? BeginTime.AddHours(1)).ToString("yyyy-MM-dd");
            }
        }
        private Color _noteColor = Color.FromArgb(150, Color.Orange);
        /// <summary>
        /// 备忘颜色
        /// </summary>
        public Color NoteColor { get { return _noteColor; } set { _noteColor = value; } }

        private Color _noteLeftLineColor = Color.Green;
        /// <summary>
        /// 备忘左侧线条颜色
        /// </summary>
        public Color NoteLeftLineColor
        {
            get { return _noteLeftLineColor; }
            set { _noteLeftLineColor = value; }
        }

        private Color noteForeColor = Color.Black;
        /// <summary>
        /// 备忘文字颜色
        /// </summary>
        public Color NoteForeColor
        {
            get { return noteForeColor; }
            set { noteForeColor = value; }
        }
        /// <summary>
        /// 备忘标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 备忘内容
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 关联数据
        /// </summary>
        public object DataSource { get; set; }

    }
}
