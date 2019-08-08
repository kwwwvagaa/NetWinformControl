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
    [DefaultEvent("CheckedChangeEvent")]
    public partial class UCRadioButton : UserControl
    {
        [Description("选中改变事件"), Category("自定义")]
        public event EventHandler CheckedChangeEvent;

        private Font _Font = new Font("微软雅黑", 12);
        [Description("字体"), Category("自定义")]
        public new Font Font
        {
            get { return _Font; }
            set
            {
                _Font = value;
                label1.Font = value;
            }
        }

        private Color _ForeColor = Color.FromArgb(62, 62, 62);
        [Description("字体颜色"), Category("自定义")]
        public new Color ForeColor
        {
            get { return _ForeColor; }
            set
            {
                label1.ForeColor = value;
                _ForeColor = value;
            }
        }
        private string _Text = "单选按钮";
        [Description("文本"), Category("自定义")]
        public string TextValue
        {
            get { return _Text; }
            set
            {
                label1.Text = value;
                _Text = value;
            }
        }
        private bool _checked = false;
        [Description("是否选中"), Category("自定义")]
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                if (_checked != value)
                {
                    _checked = value;
                    if (base.Enabled)
                    {
                        if (_checked)
                        {
                            panel1.BackgroundImage = Properties.Resources.radioButton1;
                        }
                        else
                        {
                            panel1.BackgroundImage = Properties.Resources.radioButton0;
                        }
                    }
                    else
                    {
                        if (_checked)
                        {
                            panel1.BackgroundImage = Properties.Resources.radioButton10;
                        }
                        else
                        {
                            panel1.BackgroundImage = Properties.Resources.radioButton00;
                        }
                    }
                    SetCheck(value);

                    if (CheckedChangeEvent != null)
                    {
                        CheckedChangeEvent(this, null);
                    }
                }
            }
        }

        private string _groupName;

        [Description("分组名称"), Category("自定义")]
        public string GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
                if (value)
                {
                    if (_checked)
                    {
                        panel1.BackgroundImage = Properties.Resources.radioButton1;
                    }
                    else
                    {
                        panel1.BackgroundImage = Properties.Resources.radioButton0;
                    }
                }
                else
                {
                    if (_checked)
                    {
                        panel1.BackgroundImage = Properties.Resources.radioButton10;
                    }
                    else
                    {
                        panel1.BackgroundImage = Properties.Resources.radioButton00;
                    }
                }
            }
        }
        public UCRadioButton()
        {
            InitializeComponent();
        }

        private void SetCheck(bool bln)
        {
            if (!bln)
                return;
            if (this.Parent != null)
            {
                foreach (Control c in this.Parent.Controls)
                {
                    if (c is UCRadioButton && c != this)
                    {
                        UCRadioButton uc = (UCRadioButton)c;
                        if (_groupName == uc.GroupName && uc.Checked)
                        {
                            uc.Checked = false;
                            return;
                        }
                    }
                }
            }
        }

        private void Radio_MouseDown(object sender, MouseEventArgs e)
        {
            this.Checked = true;
        }

        private void UCRadioButton_Load(object sender, EventArgs e)
        {
            if (this.Parent != null&&this._checked)
            {
                foreach (Control c in this.Parent.Controls)
                {
                    if (c is UCRadioButton && c != this)
                    {
                        UCRadioButton uc = (UCRadioButton)c;
                        if (_groupName == uc.GroupName && uc.Checked)
                        {
                            Checked = false;
                            return;
                        }
                    }
                }
            }
        }
    }
}
