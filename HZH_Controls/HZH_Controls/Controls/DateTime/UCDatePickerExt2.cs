// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2020-07-11
//
// ***********************************************************************
// <copyright file="UCDatePickerExt2.cs">
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
    public partial class UCDatePickerExt2 : UCControlBase
    {
        /// <summary>
        /// The m FRM anchor
        /// </summary>
        Forms.FrmAnchor m_frmAnchor;
        UCDateTimeSelectPan2 m_selectPan = null;
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
                if (value == DateTimePickerType.DateTime)
                {
                    txtYear.Visible = true;
                    label1.Visible = true;
                    txtMonth.Visible = true;
                    label2.Visible = true;
                    txtDay.Visible = true;
                    label3.Visible = true;
                    txtHour.Visible = true;
                    label4.Visible = true;
                    txtMinute.Visible = true;
                    label5.Visible = true;
                }
                else if (value == DateTimePickerType.Date)
                {
                    txtYear.Visible = true;
                    label1.Visible = true;
                    txtMonth.Visible = true;
                    label2.Visible = true;
                    txtDay.Visible = true;
                    label3.Visible = true;
                    txtHour.Visible = false;
                    label4.Visible = false;
                    txtMinute.Visible = false;
                    label5.Visible = false;
                }
                else
                {
                    txtYear.Visible = false;
                    label1.Visible = false;
                    txtMonth.Visible = false;
                    label2.Visible = false;
                    txtDay.Visible = false;
                    label3.Visible = false;
                    txtHour.Visible = true;
                    label4.Visible = true;
                    txtMinute.Visible = true;
                    label5.Visible = true;
                }
            }
        }

        /// <summary>
        /// The current time
        /// </summary>
        private DateTime currentTime = DateTime.Now;

        /// <summary>
        /// The time font size
        /// </summary>
        private int timeFontSize = 20;
        /// <summary>
        /// Gets or sets the size of the time font.
        /// </summary>
        /// <value>The size of the time font.</value>
        [Description("时间字体大小"), Category("自定义")]
        public int TimeFontSize
        {
            get { return timeFontSize; }
            set
            {
                if (timeFontSize != value)
                {
                    timeFontSize = value;
                    foreach (Control c in panel1.Controls)
                    {
                        c.Font = new Font(c.Font.Name, value);
                    }
                }
            }
        }
        /// <summary>
        /// Gets or sets the current time.
        /// </summary>
        /// <value>The current time.</value>
        [Description("时间"), Category("自定义")]
        [Localizable(true)]
        public DateTime CurrentTime
        {
            get { return currentTime; }
            set
            {
                currentTime = value;
                SetTimeToControl();
            }
        }
        private Color selectColor = Color.FromArgb(255, 77, 59);
        /// <summary>
        /// 选中颜色
        /// </summary>
        public Color SelectColor
        {
            get { return selectColor; }
            set { selectColor = value; }
        }
        public UCDatePickerExt2()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Sets the time to control.
        /// </summary>
        private void SetTimeToControl()
        {
            var y = CurrentTime.Year;
            var M = CurrentTime.Month;
            var d = CurrentTime.Day;
            var h = CurrentTime.Hour;
            var m = CurrentTime.Minute;
            this.txtYear.Text = y.ToString();
            this.txtMonth.Text = M.ToString().PadLeft(2, '0');
            this.txtDay.Text = d.ToString().PadLeft(2, '0');
            this.txtHour.Text = h.ToString().PadLeft(2, '0');
            this.txtMinute.Text = m.ToString().PadLeft(2, '0');
        }

        private void UCDatePickerExt2_Load(object sender, EventArgs e)
        {
            SetTimeToControl();
            panel1.Height = this.txtDay.Height;

            panel1.Width = this.Width - 6;
            SetEvent(this);
        }

        /// <summary>
        /// Sets the event.
        /// </summary>
        /// <param name="c">The c.</param>
        private void SetEvent(Control c)
        {
            if (c != null)
            {
                c.MouseDown += c_MouseDown;
                foreach (Control item in c.Controls)
                {
                    SetEvent(item);
                }
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the c control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        void c_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_selectPan == null)
            {
                m_selectPan = new UCDateTimeSelectPan2();
                m_selectPan.SelectedTimeEvent += uc_SelectedTimeEvent;
                m_selectPan.CancelTimeEvent += m_selectPan_CancelTimeEvent;
                m_selectPan.SelectColor = selectColor;
            }
            m_selectPan.CurrentTime = currentTime;
            m_selectPan.TimeType = m_type;
            m_frmAnchor = new Forms.FrmAnchor(this, m_selectPan);
            m_frmAnchor.Show(this.FindForm());
        }
        /// <summary>
        /// Handles the CancelTimeEvent event of the m_selectPan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void m_selectPan_CancelTimeEvent(object sender, EventArgs e)
        {
            m_frmAnchor.Hide();
        }

        /// <summary>
        /// Handles the SelectedTimeEvent event of the uc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void uc_SelectedTimeEvent(object sender, EventArgs e)
        {
            CurrentTime = m_selectPan.CurrentTime;
            m_frmAnchor.Hide();
        }
        /// <summary>
        /// Handles the TextChanged event of the txtYear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (txtYear.Text.Length == 4)
                this.ActiveControl = txtMonth;
        }

        /// <summary>
        /// Handles the TextChanged event of the txtMonth control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            if (txtMonth.Text.Length == 2 || txtMonth.Text.ToInt() >= 3)
            {
                this.ActiveControl = txtDay;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtDay control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtDay_TextChanged(object sender, EventArgs e)
        {
            if (m_type == DateTimePickerType.Date)
                return;
            if (txtDay.Text.Length == 2 || txtDay.Text.ToInt() >= 4)
            {
                this.ActiveControl = txtHour;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtHour control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtHour_TextChanged(object sender, EventArgs e)
        {
            if (txtHour.Text.Length == 2 || txtHour.Text.ToInt() >= 3)
            {
                this.ActiveControl = txtMinute;
            }
        }

        /// <summary>
        /// Handles the Leave event of the txtYear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtYear_Leave(object sender, EventArgs e)
        {
            if (txtYear.Text.ToInt() < 1990)
            {
                txtYear.Text = currentTime.Year.ToString();
            }
            currentTime = (txtYear.Text + currentTime.ToString("-MM-dd HH:mm:ss")).ToDate();
        }

        /// <summary>
        /// Handles the Leave event of the txtMonth control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtMonth_Leave(object sender, EventArgs e)
        {
            if (txtMonth.Text.ToInt() < 1)
            {
                txtMonth.Text = currentTime.Month.ToString().PadLeft(2, '0');
            }
            txtMonth.Text = txtMonth.Text.PadLeft(2, '0');
            currentTime = (currentTime.ToString("yyyy-" + txtMonth.Text + "-dd HH:mm:ss")).ToDate();
        }

        /// <summary>
        /// Handles the Leave event of the txtDay control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtDay_Leave(object sender, EventArgs e)
        {
            if (txtDay.Text.ToInt() < 1 || txtDay.Text.ToInt() > DateTime.DaysInMonth(currentTime.Year, currentTime.Month))
            {
                txtDay.Text = currentTime.Day.ToString().PadLeft(2, '0');
            }
            txtDay.Text = txtDay.Text.PadLeft(2, '0');
            currentTime = (currentTime.ToString("yyyy-MM-" + txtDay.Text + " HH:mm:ss")).ToDate();
        }

        /// <summary>
        /// Handles the Leave event of the txtHour control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtHour_Leave(object sender, EventArgs e)
        {
            if (txtHour.Text.ToInt() < 1)
            {
                txtHour.Text = currentTime.Hour.ToString().PadLeft(2, '0');
            }
            txtHour.Text = txtHour.Text.PadLeft(2, '0');
            currentTime = (currentTime.ToString("yyyy-MM-dd " + txtHour.Text + ":mm:ss")).ToDate();
        }

        /// <summary>
        /// Handles the Leave event of the txtMinute control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtMinute_Leave(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the SizeChanged event of the txt control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txt_SizeChanged(object sender, EventArgs e)
        {
            panel1.Height = (sender as TextBoxEx).Height;
        }
    }
}
