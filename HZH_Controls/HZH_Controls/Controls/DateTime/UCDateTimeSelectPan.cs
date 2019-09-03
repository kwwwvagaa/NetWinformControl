// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="UCDateTimeSelectPan.cs">
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
    /// Class UCDateTimeSelectPan.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public partial class UCDateTimeSelectPan : UserControl
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
        /// The automatic select next
        /// </summary>
        private bool autoSelectNext = true;
        /// <summary>
        /// Gets or sets a value indicating whether [automatic select next].
        /// </summary>
        /// <value><c>true</c> if [automatic select next]; otherwise, <c>false</c>.</value>
        [Description("自动选中下一级"), Category("自定义")]
        public bool AutoSelectNext
        {
            get { return autoSelectNext; }
            set { autoSelectNext = value; }
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
        /// <summary>
        /// The m this BTN
        /// </summary>
        UCBtnExt m_thisBtn = null;

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
            set { m_type = value; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UCDateTimeSelectPan" /> class.
        /// </summary>
        public UCDateTimeSelectPan()
        {
            InitializeComponent();
            panTime.SelectSourceEvent += panTime_SelectSourceEvent;
            this.TabStop = false;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UCDateTimeSelectPan" /> class.
        /// </summary>
        /// <param name="dt">The dt.</param>
        public UCDateTimeSelectPan(DateTime dt)
        {
            m_dt = dt;
            InitializeComponent();
            panTime.SelectSourceEvent += panTime_SelectSourceEvent;
            this.TabStop = false;
        }

        /// <summary>
        /// Handles the SelectSourceEvent event of the panTime control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void panTime_SelectSourceEvent(object sender, EventArgs e)
        {
            string strKey = sender.ToString();
            if (m_thisBtn == btnYear)
            {
                m_dt = (strKey + "-" + m_dt.Month + "-" + m_dt.Day + " " + m_dt.Hour + ":" + m_dt.Minute).ToDate();
            }
            else if (m_thisBtn == btnMonth)
            {
                m_dt = (m_dt.Year + "-" + strKey + "-" + m_dt.Day + " " + m_dt.Hour + ":" + m_dt.Minute).ToDate();
            }
            else if (m_thisBtn == btnDay)
            {
                m_dt = (m_dt.Year + "-" + m_dt.Month + "-" + strKey + " " + m_dt.Hour + ":" + m_dt.Minute).ToDate();
            }
            else if (m_thisBtn == btnHour)
            {
                m_dt = (m_dt.Year + "-" + m_dt.Month + "-" + m_dt.Day + " " + strKey + ":" + m_dt.Minute).ToDate();
            }
            else if (m_thisBtn == btnMinute)
            {
                m_dt = (m_dt.Year + "-" + m_dt.Month + "-" + m_dt.Day + " " + m_dt.Hour + ":" + strKey).ToDate();
            }
            SetTimeToControl();
            if (this.Visible)
            {
                if (autoSelectNext)
                {
                    if (m_thisBtn == btnYear)
                    {
                        SetSelectType(btnMonth);
                    }
                    else if (m_thisBtn == btnMonth)
                    {
                        SetSelectType(btnDay);
                    }
                    else if (m_thisBtn == btnDay)
                    {
                        if (m_type == DateTimePickerType.DateTime || m_type == DateTimePickerType.Time)
                            SetSelectType(btnHour);
                    }
                    else if (m_thisBtn == btnHour)
                    {
                        SetSelectType(btnMinute);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Load event of the UCDateTimePickerExt control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void UCDateTimePickerExt_Load(object sender, EventArgs e)
        {
            SetTimeToControl();

            if (m_type == DateTimePickerType.Date)
            {
                btnHour.Visible = false;
                btnMinute.Visible = false;
            }
            else if (m_type == DateTimePickerType.Time)
            {
                btnYear.Visible = false;
                btnMonth.Visible = false;
                btnDay.Visible = false;
                sp1.Visible = false;
                sp2.Visible = false;
                sp3.Visible = false;
            }
            if ((int)m_type <= 2)
            {
                SetSelectType(btnYear);
            }
            else
            {
                SetSelectType(btnHour);
            }
        }

        /// <summary>
        /// Sets the time to control.
        /// </summary>
        private void SetTimeToControl()
        {
            btnYear.Tag = m_dt.Year;
            btnYear.BtnText = m_dt.Year + "年";
            btnMonth.Tag = m_dt.Month;
            btnMonth.BtnText = m_dt.Month.ToString().PadLeft(2, '0') + "月";
            btnDay.Tag = m_dt.Day;
            btnDay.BtnText = m_dt.Day.ToString().PadLeft(2, '0') + "日";
            btnHour.Tag = m_dt.Hour;
            btnHour.BtnText = m_dt.Hour.ToString().PadLeft(2, '0') + "时";
            btnMinute.Tag = m_dt.Minute;
            btnMinute.BtnText = m_dt.Minute.ToString().PadLeft(2, '0') + "分";
        }

        /// <summary>
        /// Sets the type of the select.
        /// </summary>
        /// <param name="btn">The BTN.</param>
        private void SetSelectType(UCBtnExt btn)
        {
            try
            {
                ControlHelper.FreezeControl(this, true);
                if (m_thisBtn != null)
                {
                    m_thisBtn.FillColor = Color.White;
                    m_thisBtn.BtnForeColor = Color.FromArgb(255, 77, 59);
                }
                m_thisBtn = btn;
                if (m_thisBtn != null)
                {
                    m_thisBtn.FillColor = Color.FromArgb(255, 77, 59);
                    m_thisBtn.BtnForeColor = Color.White;

                    List<KeyValuePair<string, string>> lstSource = new List<KeyValuePair<string, string>>();
                    panTime.SuspendLayout();

                    if (btn == btnYear)
                    {
                        panLeft.Visible = true;
                        panRight.Visible = true;
                    }
                    else
                    {
                        panLeft.Visible = false;
                        panRight.Visible = false;
                    }

                    if (btn == btnYear)
                    {
                        panTime.Row = 5;
                        panTime.Column = 6;
                        int intYear = m_dt.Year - m_dt.Year % 30;
                        for (int i = 0; i < 30; i++)
                        {
                            lstSource.Add(new KeyValuePair<string, string>((intYear + i).ToString(), (intYear + i).ToString()));
                        }
                    }
                    else if (btn == btnMonth)
                    {
                        panTime.Row = 3;
                        panTime.Column = 4;
                        for (int i = 1; i <= 12; i++)
                        {
                            lstSource.Add(new KeyValuePair<string, string>(i.ToString(), i.ToString().PadLeft(2, '0') + "月\r\n" + (("2019-" + i + "-01").ToDate().ToString("MMM", System.Globalization.CultureInfo.CreateSpecificCulture("en-GB")))));
                        }
                    }
                    else if (btn == btnDay)
                    {
                        panTime.Column = 7;
                        int intDayCount = DateTime.DaysInMonth(m_dt.Year, m_dt.Month);
                        int intIndex = (int)(m_dt.DayOfWeek);
                        panTime.Row = (intDayCount + intIndex) / 7 + ((intDayCount + intIndex) % 7 != 0 ? 1 : 0);
                        for (int i = 0; i < intIndex; i++)
                        {
                            lstSource.Add(new KeyValuePair<string, string>("", ""));
                        }
                        for (int i = 1; i <= intDayCount; i++)
                        {
                            lstSource.Add(new KeyValuePair<string, string>(i.ToString(), i.ToString().PadLeft(2, '0')));
                        }
                    }
                    else if (btn == btnHour)
                    {
                        panTime.Row = 4;
                        panTime.Column = 6;
                        for (int i = 0; i <= 24; i++)
                        {
                            lstSource.Add(new KeyValuePair<string, string>(i.ToString(), i.ToString() + "时"));
                        }
                    }
                    else if (btn == btnMinute)
                    {
                        panTime.Row = 5;
                        panTime.Column = 12;
                        for (int i = 0; i <= 60; i++)
                        {
                            lstSource.Add(new KeyValuePair<string, string>(i.ToString(), i.ToString().PadLeft(2, '0')));
                        }
                    }
                    panTime.Source = lstSource;
                    panTime.SetSelect(btn.Tag.ToStringExt());
                    panTime.ResumeLayout(true);

                    // panTime.Enabled = true;
                }
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }

        /// <summary>
        /// Handles the BtnClick event of the btnTime control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnTime_BtnClick(object sender, EventArgs e)
        {
            SetSelectType((UCBtnExt)sender);
        }

        /// <summary>
        /// Handles the MouseDown event of the panLeft control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void panLeft_MouseDown(object sender, MouseEventArgs e)
        {
            List<KeyValuePair<string, string>> lstSource = new List<KeyValuePair<string, string>>();
            int intYear = this.panTime.Source[0].Key.ToInt() - this.panTime.Source[0].Key.ToInt() % 30 - 30;
            panTime.SuspendLayout();
            panTime.Row = 5;
            panTime.Column = 6;
            for (int i = 0; i < 30; i++)
            {
                lstSource.Add(new KeyValuePair<string, string>((intYear + i).ToString(), (intYear + i).ToString()));
            }
            panTime.Source = lstSource;
            panTime.SetSelect(btnYear.Tag.ToStringExt());
            panTime.ResumeLayout(true);
        }

        /// <summary>
        /// Handles the MouseDown event of the panRight control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void panRight_MouseDown(object sender, MouseEventArgs e)
        {
            List<KeyValuePair<string, string>> lstSource = new List<KeyValuePair<string, string>>();
            int intYear = this.panTime.Source[0].Key.ToInt() - this.panTime.Source[0].Key.ToInt() % 30 + 30;
            panTime.SuspendLayout();
            panTime.Row = 5;
            panTime.Column = 6;
            for (int i = 0; i < 30; i++)
            {
                lstSource.Add(new KeyValuePair<string, string>((intYear + i).ToString(), (intYear + i).ToString()));
            }
            panTime.Source = lstSource;
            panTime.SetSelect(btnYear.Tag.ToStringExt());
            panTime.ResumeLayout(true);
        }

        /// <summary>
        /// Handles the BtnClick event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnOk_BtnClick(object sender, EventArgs e)
        {
            if (SelectedTimeEvent != null)
                SelectedTimeEvent(m_dt, null);
        }

        /// <summary>
        /// Handles the BtnClick event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnCancel_BtnClick(object sender, EventArgs e)
        {
            if (CancelTimeEvent != null)
            {
                CancelTimeEvent(null, null);
            }
        }
    }
}
