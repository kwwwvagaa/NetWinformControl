// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCDatePickerExt.cs
// 创建日期：2019-08-15 15:59:46
// 功能描述：DateTime
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
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
    public partial class UCDatePickerExt : UCControlBase
    {
        Forms.FrmAnchor m_frmAnchor;
        UCDateTimeSelectPan m_selectPan = null;
        DateTimePickerType m_type = DateTimePickerType.DateTime;
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

        private DateTime currentTime = DateTime.Now;

        private int timeFontSize = 20;
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

        [Description("时间"), Category("自定义")]
        public DateTime CurrentTime
        {
            get { return currentTime; }
            set
            {
                currentTime = value;
                SetTimeToControl();
            }
        }

        private void SetTimeToControl()
        {
            this.txtYear.Text = currentTime.Year.ToString();
            this.txtMonth.Text = currentTime.Month.ToString().PadLeft(2, '0');
            this.txtDay.Text = currentTime.Day.ToString().PadLeft(2, '0');
            this.txtHour.Text = currentTime.Hour.ToString().PadLeft(2, '0');
            this.txtMinute.Text = currentTime.Minute.ToString().PadLeft(2, '0');
        }
        public UCDatePickerExt()
        {
            InitializeComponent();
        }

        private void UCDatePickerExt_Load(object sender, EventArgs e)
        {
            SetTimeToControl();
            panel1.Height = this.txtDay.Height;
            panel1.Height = this.txtHour.Height;
            SetEvent(this);
        }

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

        void c_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_selectPan == null)
            {
                m_selectPan = new UCDateTimeSelectPan();
                m_selectPan.SelectedTimeEvent += uc_SelectedTimeEvent;
                m_selectPan.CancelTimeEvent += m_selectPan_CancelTimeEvent;
            }
            m_selectPan.CurrentTime = currentTime;
            m_selectPan.TimeType = m_type;
            m_frmAnchor = new Forms.FrmAnchor(this, m_selectPan);
            m_frmAnchor.Show(this.FindForm());
        }

        void m_selectPan_CancelTimeEvent(object sender, EventArgs e)
        {
            m_frmAnchor.Hide();
        }

        void uc_SelectedTimeEvent(object sender, EventArgs e)
        {
            CurrentTime = m_selectPan.CurrentTime;
            m_frmAnchor.Hide();
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (txtYear.Text.Length == 4)
                this.ActiveControl = txtMonth;
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            if (txtMonth.Text.Length == 2 || txtMonth.Text.ToInt() >= 3)
            {
                this.ActiveControl = txtDay;
            }
        }

        private void txtDay_TextChanged(object sender, EventArgs e)
        {
            if (m_type == DateTimePickerType.Date)
                return;
            if (txtDay.Text.Length == 2 || txtDay.Text.ToInt() >= 4)
            {
                this.ActiveControl = txtHour;
            }
        }

        private void txtHour_TextChanged(object sender, EventArgs e)
        {
            if (txtHour.Text.Length == 2 || txtHour.Text.ToInt() >= 3)
            {
                this.ActiveControl = txtMinute;
            }
        }

        private void txtYear_Leave(object sender, EventArgs e)
        {
            if (txtYear.Text.ToInt() < 1990)
            {
                txtYear.Text = currentTime.Year.ToString();
            }
            currentTime = (txtYear.Text + currentTime.ToString("-MM-dd HH:mm:ss")).ToDate();
        }

        private void txtMonth_Leave(object sender, EventArgs e)
        {
            if (txtMonth.Text.ToInt() < 1)
            {
                txtMonth.Text = currentTime.Month.ToString().PadLeft(2, '0');
            }
            txtMonth.Text = txtMonth.Text.PadLeft(2, '0');
            currentTime = (currentTime.ToString("yyyy-" + txtMonth.Text + "-dd HH:mm:ss")).ToDate();
        }

        private void txtDay_Leave(object sender, EventArgs e)
        {
            if (txtDay.Text.ToInt() < 1 || txtDay.Text.ToInt() > DateTime.DaysInMonth(currentTime.Year, currentTime.Month))
            {
                txtDay.Text = currentTime.Day.ToString().PadLeft(2, '0');
            }
            txtDay.Text = txtDay.Text.PadLeft(2, '0');
            currentTime = (currentTime.ToString("yyyy-MM-" + txtDay.Text + " HH:mm:ss")).ToDate();
        }

        private void txtHour_Leave(object sender, EventArgs e)
        {
            if (txtHour.Text.ToInt() < 1)
            {
                txtHour.Text = currentTime.Hour.ToString().PadLeft(2, '0');
            }
            txtHour.Text = txtHour.Text.PadLeft(2, '0');
            currentTime = (currentTime.ToString("yyyy-MM-dd " + txtHour.Text + ":mm:ss")).ToDate();
        }

        private void txtMinute_Leave(object sender, EventArgs e)
        {
            if (txtMinute.Text.ToInt() < 1)
            {
                txtMinute.Text = currentTime.Minute.ToString().PadLeft(2, '0');
            }
            txtMinute.Text = txtMinute.Text.PadLeft(2, '0');
            currentTime = (currentTime.ToString("yyyy-MM-dd HH:" + txtMinute.Text + ":ss")).ToDate();
        }

        private void txt_SizeChanged(object sender, EventArgs e)
        {
            panel1.Height = (sender as TextBoxEx).Height;
        }
    }
}
