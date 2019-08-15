// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：TextBoxEx.cs
// 创建日期：2019-08-15 16:03:44
// 功能描述：TextBox
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    public partial class TextBoxEx : TextBox
    {
        private bool blnFocus = false;

        private string _promptText = string.Empty;

        private Font _promptFont = new Font("微软雅黑", 15f, FontStyle.Regular, GraphicsUnit.Pixel);

        private Color _promptColor = Color.Gray;

        private Rectangle _myRectangle = Rectangle.FromLTRB(1, 3, 1000, 3);

        private TextInputType _inputType = TextInputType.NotControl;

        private string _regexPattern = "";

        private string m_strOldValue = string.Empty;

        private decimal _maxValue = 1000000m;

        private decimal _minValue = -1000000m;

        private int _decLength = 2;

        /// <summary>
        /// 水印文字
        /// </summary>
        [Description("水印文字"), Category("自定义")]
        public string PromptText
        {
            get
            {
                return this._promptText;
            }
            set
            {
                this._promptText = value;
                this.OnPaint(null);
            }
        }

        [Description("水印字体"), Category("自定义")]
        public Font PromptFont
        {
            get
            {
                return this._promptFont;
            }
            set
            {
                this._promptFont = value;
            }
        }

        [Description("水印颜色"), Category("自定义")]
        public Color PromptColor
        {
            get
            {
                return this._promptColor;
            }
            set
            {
                this._promptColor = value;
            }
        }

        public Rectangle MyRectangle
        {
            get;
            set;
        }

        public string OldText
        {
            get;
            set;
        }

        [Description("获取或设置一个值，该值指示文本框中的文本输入类型。")]
        public TextInputType InputType
        {
            get
            {
                return this._inputType;
            }
            set
            {
                this._inputType = value;
                if (value != TextInputType.NotControl)
                {
                    TextChanged -= new EventHandler(this.TextBoxEx_TextChanged);
                    TextChanged += new EventHandler(this.TextBoxEx_TextChanged);
                }
                else
                {
                    TextChanged -= new EventHandler(this.TextBoxEx_TextChanged);
                }
            }
        }
        /// <summary>
        /// 获取或设置一个值，该值指示当输入类型InputType=Regex时，使用的正则表达式。
        /// </summary>
        [Description("获取或设置一个值，该值指示当输入类型InputType=Regex时，使用的正则表达式。")]
        public string RegexPattern
        {
            get
            {
                return this._regexPattern;
            }
            set
            {
                this._regexPattern = value;
            }
        }
        /// <summary>
        /// 当InputType为数字类型时，能输入的最大值
        /// </summary>
        [Description("当InputType为数字类型时，能输入的最大值。")]
        public decimal MaxValue
        {
            get
            {
                return this._maxValue;
            }
            set
            {
                this._maxValue = value;
            }
        }
        /// <summary>
        /// 当InputType为数字类型时，能输入的最小值
        /// </summary>
        [Description("当InputType为数字类型时，能输入的最小值。")]
        public decimal MinValue
        {
            get
            {
                return this._minValue;
            }
            set
            {
                this._minValue = value;
            }
        }
        /// <summary>
        /// 当InputType为数字类型时，能输入的最小值
        /// </summary>
        [Description("当InputType为数字类型时，小数位数。")]
        public int DecLength
        {
            get
            {
                return this._decLength;
            }
            set
            {
                this._decLength = value;
            }
        }

        public TextBoxEx()
        {
            this.InitializeComponent();
            base.GotFocus += new EventHandler(this.TextBoxEx_GotFocus);
            base.MouseUp += new MouseEventHandler(this.TextBoxEx_MouseUp);
            base.KeyPress += TextBoxEx_KeyPress;
        }

        void TextBoxEx_KeyPress(object sender, KeyPressEventArgs e)
        {
            //以下代码  取消按下回车或esc的“叮”声
            if (e.KeyChar == System.Convert.ToChar(13) || e.KeyChar == System.Convert.ToChar(27))
            {
                e.Handled = true;
            }
        }

        private void TextBoxEx_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.blnFocus)
            {
                base.SelectAll();
                this.blnFocus = false;
            }
        }

        private void TextBoxEx_GotFocus(object sender, EventArgs e)
        {
            this.blnFocus = true;
            base.SelectAll();
        }

        private void TextBoxEx_TextChanged(object sender, EventArgs e)
        {
            if (this.Text == "")
            {
                this.m_strOldValue = this.Text;
            }
            else if (this.m_strOldValue != this.Text)
            {
                if (!ControlHelper.CheckInputType(this.Text, this._inputType, this._maxValue, this._minValue, this._decLength, this._regexPattern))
                {
                    int num = base.SelectionStart;
                    if (this.m_strOldValue.Length < this.Text.Length)
                    {
                        num--;
                    }
                    else
                    {
                        num++;
                    }
                    base.TextChanged -= new EventHandler(this.TextBoxEx_TextChanged);
                    this.Text = this.m_strOldValue;
                    base.TextChanged += new EventHandler(this.TextBoxEx_TextChanged);
                    if (num < 0)
                    {
                        num = 0;
                    }
                    base.SelectionStart = num;
                }
                else
                {
                    this.m_strOldValue = this.Text;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (string.IsNullOrEmpty(this.Text) && !string.IsNullOrEmpty(this._promptText))
            {
                if (e == null)
                {
                    using (Graphics graphics = Graphics.FromHwnd(base.Handle))
                    {
                        if (this.Text.Length == 0 && !string.IsNullOrEmpty(this.PromptText))
                        {
                            TextFormatFlags textFormatFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter;
                            if (this.RightToLeft == RightToLeft.Yes)
                            {
                                textFormatFlags |= (TextFormatFlags.Right | TextFormatFlags.RightToLeft);
                            }
                            TextRenderer.DrawText(graphics, this.PromptText, this._promptFont, base.ClientRectangle, this._promptColor, textFormatFlags);
                        }
                    }
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 15 || m.Msg == 7 || m.Msg == 8)
            {
                this.OnPaint(null);
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            base.Invalidate();
        }
    }
}
