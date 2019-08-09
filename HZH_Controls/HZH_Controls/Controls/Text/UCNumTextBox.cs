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
    [DefaultEvent("NumChanged")]
    public partial class UCNumTextBox : UserControl
    {
        [Description("弹出输入键盘时发生"), Category("自定义")]
        public event EventHandler ShowKeyBorderEvent;
        [Description("关闭输入键盘时发生"), Category("自定义")]
        public event EventHandler HideKeyBorderEvent;
        [Description("数字改变时发生"), Category("自定义")]
        public event EventHandler NumChanged;
        /// <summary>
        /// 输入类型
        /// </summary>
        [Description("输入类型"), Category("自定义")]
        public TextInputType InputType
        {
            get
            {
                return txtNum.InputType;
            }
            set
            {
                if (value == TextInputType.NotControl)
                {
                    return;
                }
                txtNum.InputType = value;
            }
        }

        [Description("数字是否可手动编辑"), Category("自定义")]
        public bool IsNumCanInput
        {
            get
            {
                return txtNum.Enabled;
            }
            set
            {
                txtNum.Enabled = value;
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
                return this.txtNum.MaxValue;
            }
            set
            {
                this.txtNum.MaxValue = value;
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
                return this.txtNum.MinValue;
            }
            set
            {
                this.txtNum.MinValue = value;
            }
        }
        private KeyBoardType keyBoardType = KeyBoardType.UCKeyBorderNum;
        [Description("键盘样式"), Category("自定义")]
        public KeyBoardType KeyBoardType
        {
            get { return keyBoardType; }
            set { keyBoardType = value; }
        }

        [Description("数值"), Category("自定义")]
        public decimal Num
        {
            get { return txtNum.Text.ToDecimal(); }
            set { txtNum.Text = value.ToString(); }
        }
        [Description("字体"), Category("自定义")]
        public new Font Font
        {
            get
            {
                return txtNum.Font;
            }
            set
            {
                txtNum.Font = value;
            }
        }

        [Description("增加按钮点击事件"), Category("自定义")]
        public event EventHandler AddClick;
        [Description("减少按钮点击事件"), Category("自定义")]
        public event EventHandler MinusClick;
        public UCNumTextBox()
        {
            InitializeComponent();
            txtNum.TextChanged += txtNum_TextChanged;
        }

        void txtNum_TextChanged(object sender, EventArgs e)
        {
            if (NumChanged != null)
            {
                NumChanged(txtNum.Text.ToString(), e);
            }
        }
        Forms.FrmAnchor m_frmAnchor;
        private void txtNum_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsNumCanInput)
            {
                if (KeyBoardType != HZH_Controls.Controls.KeyBoardType.Null)
                {
                    switch (keyBoardType)
                    {
                        case KeyBoardType.UCKeyBorderAll_EN:

                            UCKeyBorderAll keyAll = new UCKeyBorderAll();
                            keyAll.RetractClike += (a, b) => { m_frmAnchor.Hide(); };
                            keyAll.EnterClick += (a, b) => { m_frmAnchor.Hide(); };
                            m_frmAnchor = new Forms.FrmAnchor(this, keyAll);
                            m_frmAnchor.VisibleChanged += m_frmAnchor_VisibleChanged;

                            m_frmAnchor.Show(this.FindForm());
                            break;
                        case KeyBoardType.UCKeyBorderNum:

                            UCKeyBorderNum keyNum = new UCKeyBorderNum();
                            keyNum.EnterClick += (a, b) => { m_frmAnchor.Hide(); };
                            m_frmAnchor = new Forms.FrmAnchor(this, keyNum);
                            m_frmAnchor.VisibleChanged += m_frmAnchor_VisibleChanged;
                            m_frmAnchor.Show(this.FindForm());
                            break;
                    }
                }
            }
        }

        void m_frmAnchor_VisibleChanged(object sender, EventArgs e)
        {
            if (m_frmAnchor.Visible)
            {
                if (ShowKeyBorderEvent != null)
                {
                    ShowKeyBorderEvent(this, null);
                }
            }
            else
            {
                if (HideKeyBorderEvent != null)
                {
                    HideKeyBorderEvent(this, null);
                }
            }
        }

        public void NumAddClick()
        {
            btnAdd_MouseDown(null, null);
        }

        public void NumMinusClick()
        {
            btnMinus_MouseDown(null, null);
        }

        private void btnAdd_MouseDown(object sender, MouseEventArgs e)
        {
            if (AddClick != null)
            {
                AddClick(this, e);
            }
            decimal dec = this.txtNum.Text.ToDecimal();
            dec++;
            txtNum.Text = dec.ToString();

        }

        private void btnMinus_MouseDown(object sender, MouseEventArgs e)
        {
            if (MinusClick != null)
            {
                MinusClick(this, e);
            }
            decimal dec = this.txtNum.Text.ToDecimal();
            dec--;
            txtNum.Text = dec.ToString();
        }

        private void UCNumTextBox_Load(object sender, EventArgs e)
        {
            this.txtNum.BackColor = this.BackColor;
        }

        private void txtNum_FontChanged(object sender, EventArgs e)
        {
            txtNum.Location = new Point(txtNum.Location.X, (this.Height - txtNum.Height) / 2);
        }

        private void UCNumTextBox_BackColorChanged(object sender, EventArgs e)
        {
            Color c = this.BackColor;
            Control control = this;
            while (c == Color.Transparent)
            {
                control = control.Parent;
                if (control == null)
                    break;
                c = control.BackColor;
            }
            if (c == Color.Transparent)
                return;
            txtNum.BackColor = c;
        }
    }
}
