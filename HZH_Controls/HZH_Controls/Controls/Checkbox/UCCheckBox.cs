// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCCheckBox.cs
// 创建日期：2019-08-15 15:58:34
// 功能描述：CheckBox
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
    [DefaultEvent("CheckedChangeEvent")]
    public partial class UCCheckBox : UserControl
    {
        [Description("选中改变事件"), Category("自定义")]
        public event EventHandler CheckedChangeEvent;

        [Description("字体"), Category("自定义")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
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
        private string _Text = "复选框";
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
                            panel1.BackgroundImage = Properties.Resources.checkbox1;
                        }
                        else
                        {
                            panel1.BackgroundImage = Properties.Resources.checkbox0;
                        }
                    }
                    else
                    {
                        if (_checked)
                        {
                            panel1.BackgroundImage = Properties.Resources.checkbox10;
                        }
                        else
                        {
                            panel1.BackgroundImage = Properties.Resources.checkbox00;
                        }
                    }

                    if (CheckedChangeEvent != null)
                    {
                        CheckedChangeEvent(this, null);
                    }
                }
            }
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
                        panel1.BackgroundImage = Properties.Resources.checkbox1;
                    }
                    else
                    {
                        panel1.BackgroundImage = Properties.Resources.checkbox0;
                    }
                }
                else
                {
                    if (_checked)
                    {
                        panel1.BackgroundImage = Properties.Resources.checkbox10;
                    }
                    else
                    {
                        panel1.BackgroundImage = Properties.Resources.checkbox00;
                    }
                }
            }
        }
        public UCCheckBox()
        {
            InitializeComponent();
        }

        private void CheckBox_MouseDown(object sender, MouseEventArgs e)
        {
            Checked = !Checked;
        }
    }
}
