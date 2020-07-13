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
    public partial class UCDateTimeSelectPan2 : UserControl
    {
        /// <summary>
        /// Occurs when [selected time event].
        /// </summary>
        [Description("确定事件"), Category("自定义")]
        public event EventHandler SelectedTimeEvent;
        /// <summary>
        /// Occurs when [cancel time event].
        /// </summary>
        [Description("取消事件"), Category("自定义")]
        public event EventHandler CancelTimeEvent;
        /// <summary>
        /// The m type
        /// </summary>
        DateTimePickerType m_type = DateTimePickerType.DateTime;
        /// <summary>
        /// Gets or sets the type of the time.
        /// </summary>
        /// <value>The type of the time.</value>
        [Description("时间类型"), Category("自定义")]
        public DateTimePickerType TimeType
        {
            get { return m_type; }
            set
            {
                m_type = value;
                panTime.Visible = value != DateTimePickerType.Date;
            }
        }
        /// <summary>
        /// The m dt
        /// </summary>
        DateTime m_dt = DateTime.Now;

        /// <summary>
        /// Gets or sets the current time.
        /// </summary>
        /// <value>The current time.</value>
        public DateTime CurrentTime
        {
            get { return m_dt; }
            set
            {
                m_dt = value;
                SetTimeToControl();
            }
        }

        private Color selectColor = Color.FromArgb(255, 77, 59);

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
                foreach (Control item in panTime.Controls)
                {
                    if (item is Label)
                    {
                        item.ForeColor = value;
                    }
                }

                foreach (var item in panBtns.Controls)
                {
                    if (item is UCBtnExt)
                    {
                        ((UCBtnExt)item).BtnForeColor = value;
                    }
                }
                foreach (Control item in panSelectHourList.Controls)
                {
                    item.ForeColor = value;
                }
                foreach (Control item in panSelectMinuteList.Controls)
                {
                    item.ForeColor = value;
                }
                foreach (Control item in panSelectSecondList.Controls)
                {
                    item.ForeColor = value;
                }
                panSelectYear.BackColor = value;
                panSelectMonth.BackColor = value;
                ucSplitLine_H2.BackColor = value;
                ucSplitLine_V4.BackColor = value;
                ucSplitLine_V5.BackColor = value;
            }
        }
        public UCDateTimeSelectPan2()
        {
            InitializeComponent();
            foreach (Label lblDay in panDay.Controls)
            {
                lblDay.MouseClick += lblDay_MouseClick;
            }
            foreach (Label lblMonthItem in panSelectMonthList.Controls)
            {
                lblMonthItem.MouseClick += lblMonthItem_MouseClick;
            }
            foreach (Label lblYearItem in panSelectYearList.Controls)
            {
                lblYearItem.MouseClick += lblYearItem_MouseClick;
            }
            for (int i = 0; i < 24; i++)
            {
                Label lblHourItem = new Label();
                lblHourItem.AutoSize = false;
                lblHourItem.Dock = DockStyle.Fill;
                lblHourItem.ForeColor = selectColor;
                lblHourItem.Font = new Font("微软雅黑", 9);
                lblHourItem.Text = i.ToString();
                lblHourItem.TextAlign = ContentAlignment.MiddleCenter;
                lblHourItem.MouseClick += lblHourItem_MouseClick;
                lblHourItem.Margin = new Padding(0);
                this.panSelectHourList.Controls.Add(lblHourItem, i % 5, i / 5);
            }
            for (int i = 0; i < 60; i++)
            {
                Label lblMinuteItem = new Label();
                lblMinuteItem.AutoSize = false;
                lblMinuteItem.Dock = DockStyle.Fill;
                lblMinuteItem.ForeColor = selectColor;
                lblMinuteItem.Font = new Font("微软雅黑", 8);
                lblMinuteItem.Text = i.ToString();
                lblMinuteItem.TextAlign = ContentAlignment.MiddleCenter;
                lblMinuteItem.MouseClick += lblMinuteItem_MouseClick;
                lblMinuteItem.Margin = new Padding(0);
                this.panSelectMinuteList.Controls.Add(lblMinuteItem, i % 10, i / 10);
            }
            for (int i = 0; i < 60; i++)
            {
                Label lblSecondItem = new Label();
                lblSecondItem.AutoSize = false;
                lblSecondItem.Dock = DockStyle.Fill;
                lblSecondItem.ForeColor = selectColor;
                lblSecondItem.Font = new Font("微软雅黑", 8);
                lblSecondItem.Text = i.ToString();
                lblSecondItem.TextAlign = ContentAlignment.MiddleCenter;
                lblSecondItem.MouseClick += lblSecondItem_MouseClick;
                lblSecondItem.Margin = new Padding(0);
                this.panSelectSecondList.Controls.Add(lblSecondItem, i % 10, i / 10);
            }
        }

        void lblSecondItem_MouseClick(object sender, MouseEventArgs e)
        {
            panSelectSecond.Visible = false;
            CurrentTime = DateTime.Parse(m_dt.ToString("yyyy-MM-dd HH:mm") + ":" + ((Label)sender).Text);
        }

        void lblMinuteItem_MouseClick(object sender, MouseEventArgs e)
        {
            panSelectMinute.Visible = false;
            CurrentTime = DateTime.Parse(m_dt.ToString("yyyy-MM-dd") + " " + m_dt.Hour + ":" + ((Label)sender).Text + ":" + m_dt.Second);
        }

        void lblHourItem_MouseClick(object sender, MouseEventArgs e)
        {
            panSelectHour.Visible = false;
            CurrentTime = DateTime.Parse(m_dt.ToString("yyyy-MM-dd") + " " + ((Label)sender).Text + ":" + m_dt.ToString("mm:ss"));
        }

        void lblYearItem_MouseClick(object sender, MouseEventArgs e)
        {
            panSelectYear.Visible = false;
            CurrentTime = DateTime.Parse(((Label)sender).Tag + "-" + m_dt.Month + "-" + m_dt.Day + " " + m_dt.ToString("HH:mm:ss"));
        }

        void lblMonthItem_MouseClick(object sender, MouseEventArgs e)
        {
            panSelectMonth.Visible = false;
            CurrentTime = DateTime.Parse(m_dt.Year + "-" + ((Label)sender).Tag + "-" + m_dt.Day + " " + m_dt.ToString("HH:mm:ss"));
        }

        void lblDay_MouseClick(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            if (m_dt.Month + "-" + m_dt.Day != lbl.Tag.ToString())
            {
                CurrentTime = DateTime.Parse(m_dt.Year + "-" + lbl.Tag + " " + m_dt.ToString("HH:mm:ss"));
            }
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

            if (lblHour.Tag.ToInt() != m_dt.Hour)
            {
                lblHour.Tag = m_dt.Hour;
                lblHour.Text = m_dt.Hour.ToString().PadLeft(2, '0');
            }
            if (lblMinute.Tag.ToInt() != m_dt.Minute)
            {
                lblMinute.Tag = m_dt.Minute;
                lblMinute.Text = m_dt.Minute.ToString().PadLeft(2, '0');
            }
            if (lblSecond.Tag.ToInt() != m_dt.Second)
            {
                lblSecond.Tag = m_dt.Second;
                lblSecond.Text = m_dt.Second.ToString().PadLeft(2, '0');
            }
        }

        private void lblMouth_TextChanged(object sender, EventArgs e)
        {
            int mouth = ((Label)sender).Tag.ToInt();
            CurrentTime = DateTime.Parse(m_dt.Year + "-" + mouth + "-" + m_dt.Day + " " + m_dt.ToString("HH:mm:ss"));
            int intDayCount = DateTime.DaysInMonth(m_dt.Year, m_dt.Month);
            DateTime dtlastMonth = m_dt.AddMonths(-1);
            int intlasyMonthDayCount = DateTime.DaysInMonth(dtlastMonth.Year, dtlastMonth.Month);
            DateTime dt1 = DateTime.Parse(m_dt.Year + "-" + m_dt.Month + "-01 00:00:01");
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

        private void lblYear_TextChanged(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Parse(lblYear.Tag + "-" + m_dt.ToString("MM-dd HH:mm:ss"));
            lblMouth_TextChanged(lblMouth, null);
        }

        private void btnOK_BtnClick(object sender, EventArgs e)
        {
            if (SelectedTimeEvent != null)
            {
                SelectedTimeEvent(null, null);
            }
        }

        private void btbMouthLast_BtnClick(object sender, EventArgs e)
        {
            panSelectYear.Visible = false;
            panSelectMonth.Visible = false;
            CurrentTime = CurrentTime.AddMonths(-1);
        }

        private void btnMouthNext_BtnClick(object sender, EventArgs e)
        {
            panSelectYear.Visible = false;
            panSelectMonth.Visible = false;
            CurrentTime = CurrentTime.AddMonths(1);
        }

        private void btnYearNext_BtnClick(object sender, EventArgs e)
        {
            panSelectYear.Visible = false;
            panSelectMonth.Visible = false;
            CurrentTime = CurrentTime.AddYears(1);
        }

        private void btnYearLast_BtnClick(object sender, EventArgs e)
        {
            panSelectYear.Visible = false;
            panSelectMonth.Visible = false;
            CurrentTime = CurrentTime.AddYears(-1);
        }

        private void lblMouth_Click(object sender, EventArgs e)
        {
            panSelectHour.Visible = false;
            panSelectMonth.Visible = !panSelectMonth.Visible;
            panSelectYear.Visible = false;
            panSelectMinute.Visible = false;
            panSelectSecond.Visible = false;
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

        private void lblYear_Click(object sender, EventArgs e)
        {
            panSelectHour.Visible = false;
            panSelectMonth.Visible = false;
            panSelectYear.Visible = !panSelectYear.Visible;
            panSelectMinute.Visible = false;
            panSelectSecond.Visible = false;
        }

        private void btnNow_BtnClick(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now;
            btnOK_BtnClick(null, null);
        }

        private void UCDateTimeSelectPan2_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                panSelectMonth.Visible = false;
                panSelectYear.Visible = false;
                panSelectHour.Visible = false;
                panSelectMinute.Visible = false;
                panSelectSecond.Visible = false;
            }
        }

        private void lblHour_Click(object sender, EventArgs e)
        {
            panSelectHour.Visible = !panSelectHour.Visible;
            panSelectMonth.Visible = false;
            panSelectYear.Visible = false;
            panSelectMinute.Visible = false;
            panSelectSecond.Visible = false;
        }

        private void label74_Click(object sender, EventArgs e)
        {
            panSelectHour.Visible = false;
        }

        private void panSelectHour_VisibleChanged(object sender, EventArgs e)
        {
            if (panSelectHour.Visible)
            {
                foreach (Label item in panSelectHourList.Controls)
                {
                    if (item.Text == m_dt.Hour.ToString())
                    {
                        item.BackColor = selectColor;
                        item.ForeColor = Color.White;
                    }
                    else
                    {
                        item.BackColor = Color.White;
                        item.ForeColor = selectColor;
                    }
                }
            }
        }

        private void panSelectMinute_VisibleChanged(object sender, EventArgs e)
        {
            if (panSelectMinute.Visible)
            {
                foreach (Label item in panSelectMinuteList.Controls)
                {
                    if (item.Text == m_dt.Minute.ToString())
                    {
                        item.BackColor = selectColor;
                        item.ForeColor = Color.White;
                    }
                    else
                    {
                        item.BackColor = Color.White;
                        item.ForeColor = selectColor;
                    }
                }
            }
        }

        private void lblMinute_Click(object sender, EventArgs e)
        {
            panSelectHour.Visible = false;
            panSelectMonth.Visible = false;
            panSelectYear.Visible = false;
            panSelectMinute.Visible = !panSelectMinute.Visible;
            panSelectSecond.Visible = false;
        }

        private void label76_Click(object sender, EventArgs e)
        {
            panSelectMinute.Visible = false;
        }

        private void lblSecond_Click(object sender, EventArgs e)
        {
            panSelectHour.Visible = false;
            panSelectMonth.Visible = false;
            panSelectYear.Visible = false;
            panSelectMinute.Visible = false;
            panSelectSecond.Visible = !panSelectSecond.Visible;
        }

        private void label77_Click(object sender, EventArgs e)
        {
            panSelectSecond.Visible = false;
        }

        private void panSelectSecond_VisibleChanged(object sender, EventArgs e)
        {
            if (panSelectSecond.Visible)
            {
                foreach (Label item in panSelectSecondList.Controls)
                {
                    if (item.Text == m_dt.Second.ToString())
                    {
                        item.BackColor = selectColor;
                        item.ForeColor = Color.White;
                    }
                    else
                    {
                        item.BackColor = Color.White;
                        item.ForeColor = selectColor;
                    }
                }
            }
        }

        private void btnClear_BtnClick(object sender, EventArgs e)
        {
            if (CancelTimeEvent != null)
            {
                CancelTimeEvent(this, null);
            }
        }

        private void lblYearLastList_Click(object sender, EventArgs e)
        {
            int year = this.panSelectYearList.Controls[6].Tag.ToInt();
            year -= 14;
            if (year - 7 < 1990)
                year = 1990 + 7;
            BindYearList(year);
        }

        private void lblYearNextList_Click(object sender, EventArgs e)
        {
            int year = this.panSelectYearList.Controls[6].Tag.ToInt();
            year += 14;
            if (year + 6 > 2099)
                year = 2099 - 6;
            BindYearList(year);
        }
    }
}
