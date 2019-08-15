// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCTextBoxEx.cs
// 创建日期：2019-08-15 16:03:58
// 功能描述：TextBox
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace HZH_Controls.Controls
{
    [DefaultEvent("TextChanged")]
    public partial class UCTextBoxEx : UCControlBase
    {
        private bool m_isShowClearBtn = true;
        int m_intSelectionStart = 0;
        int m_intSelectionLength = 0;
        /// <summary>
        /// 功能描述:是否显示清理按钮
        /// 作　　者:HZH
        /// 创建日期:2019-02-28 16:13:52
        /// </summary>        
        [Description("是否显示清理按钮"), Category("自定义")]
        public bool IsShowClearBtn
        {
            get { return m_isShowClearBtn; }
            set
            {
                m_isShowClearBtn = value;
                if (value)
                {
                    btnClear.Visible = !(txtInput.Text == "\r\n") && !string.IsNullOrEmpty(txtInput.Text);
                }
                else
                {
                    btnClear.Visible = false;
                }
            }
        }

        private bool m_isShowSearchBtn = false;
        /// <summary>
        /// 是否显示查询按钮
        /// </summary>

        [Description("是否显示查询按钮"), Category("自定义")]
        public bool IsShowSearchBtn
        {
            get { return m_isShowSearchBtn; }
            set
            {
                m_isShowSearchBtn = value;
                btnSearch.Visible = value;
            }
        }

        [Description("是否显示键盘"), Category("自定义")]
        public bool IsShowKeyboard
        {
            get
            {
                return btnKeybord.Visible;
            }
            set
            {
                btnKeybord.Visible = value;
            }
        }
        [Description("字体"), Category("自定义")]
        public new Font Font
        {
            get
            {
                return this.txtInput.Font;
            }
            set
            {
                this.txtInput.Font = value;
            }
        }

        [Description("输入类型"), Category("自定义")]
        public TextInputType InputType
        {
            get { return txtInput.InputType; }
            set { txtInput.InputType = value; }
        }

        /// <summary>
        /// 水印文字
        /// </summary>
        [Description("水印文字"), Category("自定义")]
        public string PromptText
        {
            get
            {
                return this.txtInput.PromptText;
            }
            set
            {
                this.txtInput.PromptText = value;
            }
        }

        [Description("水印字体"), Category("自定义")]
        public Font PromptFont
        {
            get
            {
                return this.txtInput.PromptFont;
            }
            set
            {
                this.txtInput.PromptFont = value;
            }
        }

        [Description("水印颜色"), Category("自定义")]
        public Color PromptColor
        {
            get
            {
                return this.txtInput.PromptColor;
            }
            set
            {
                this.txtInput.PromptColor = value;
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
                return this.txtInput.RegexPattern;
            }
            set
            {
                this.txtInput.RegexPattern = value;
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
                return this.txtInput.MaxValue;
            }
            set
            {
                this.txtInput.MaxValue = value;
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
                return this.txtInput.MinValue;
            }
            set
            {
                this.txtInput.MinValue = value;
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
                return this.txtInput.DecLength;
            }
            set
            {
                this.txtInput.DecLength = value;
            }
        }

        private KeyBoardType keyBoardType = KeyBoardType.UCKeyBorderAll_EN;
        [Description("键盘打开样式"), Category("自定义")]
        public KeyBoardType KeyBoardType
        {
            get { return keyBoardType; }
            set { keyBoardType = value; }
        }
        [Description("查询按钮点击事件"), Category("自定义")]
        public event EventHandler SearchClick;

        [Description("文本改变事件"), Category("自定义")]
        public new event EventHandler TextChanged;
        [Description("键盘按钮点击事件"), Category("自定义")]
        public event EventHandler KeyboardClick;

        [Description("文本"), Category("自定义")]
        public string InputText
        {
            get
            {
                return txtInput.Text;
            }
            set
            {
                txtInput.Text = value;
            }
        }

        private bool isFocusColor = true;
        [Description("获取焦点是否变色"), Category("自定义")]
        public bool IsFocusColor
        {
            get { return isFocusColor; }
            set { isFocusColor = value; }
        }
        private Color _FillColor;
        public new Color FillColor
        {
            get
            {
                return _FillColor;
            }
            set
            {
                _FillColor = value;
                base.FillColor = value;
                this.txtInput.BackColor = value;
            }
        }
        public UCTextBoxEx()
        {
            InitializeComponent();
            txtInput.SizeChanged += UCTextBoxEx_SizeChanged;
            this.SizeChanged += UCTextBoxEx_SizeChanged;
            txtInput.GotFocus += (a, b) =>
            {
                if (isFocusColor)
                    this.RectColor = Color.FromArgb(78, 169, 255);
            };
            txtInput.LostFocus += (a, b) =>
            {
                if (isFocusColor)
                    this.RectColor = Color.FromArgb(220, 220, 220);
            };
        }

        void UCTextBoxEx_SizeChanged(object sender, EventArgs e)
        {
            this.txtInput.Location = new Point(this.txtInput.Location.X, (this.Height - txtInput.Height) / 2);
        }


        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (m_isShowClearBtn)
            {
                btnClear.Visible = !(txtInput.Text == "\r\n") && !string.IsNullOrEmpty(txtInput.Text);
            }
            if (TextChanged != null)
            {
                TextChanged(sender, e);
            }
        }

        private void btnClear_MouseDown(object sender, MouseEventArgs e)
        {
            txtInput.Clear();
            txtInput.Focus();
        }

        private void btnSearch_MouseDown(object sender, MouseEventArgs e)
        {
            if (SearchClick != null)
            {
                SearchClick(sender, e);
            }
        }
        Forms.FrmAnchor m_frmAnchor;
        private void btnKeybord_MouseDown(object sender, MouseEventArgs e)
        {
            m_intSelectionStart = this.txtInput.SelectionStart;
            m_intSelectionLength = this.txtInput.SelectionLength;
            this.FindForm().ActiveControl = this;
            this.FindForm().ActiveControl = this.txtInput;
            switch (keyBoardType)
            {
                case KeyBoardType.UCKeyBorderAll_EN:
                    if (m_frmAnchor == null)
                    {
                        if (m_frmAnchor == null)
                        {
                            UCKeyBorderAll key = new UCKeyBorderAll();
                            key.CharType = KeyBorderCharType.CHAR;
                            key.RetractClike += (a, b) =>
                            {
                                m_frmAnchor.Hide();
                            };
                            m_frmAnchor = new Forms.FrmAnchor(this, key);
                            m_frmAnchor.VisibleChanged += (a, b) =>
                            {
                                if (m_frmAnchor.Visible)
                                {
                                    this.txtInput.SelectionStart = m_intSelectionStart;
                                    this.txtInput.SelectionLength = m_intSelectionLength;
                                }
                            };
                        }
                    }
                    break;
                case KeyBoardType.UCKeyBorderAll_Num:

                    if (m_frmAnchor == null)
                    {
                        UCKeyBorderAll key = new UCKeyBorderAll();
                        key.CharType = KeyBorderCharType.NUMBER;
                        key.RetractClike += (a, b) =>
                        {
                            m_frmAnchor.Hide();
                        };
                        m_frmAnchor = new Forms.FrmAnchor(this, key);
                        m_frmAnchor.VisibleChanged += (a, b) =>
                        {
                            if (m_frmAnchor.Visible)
                            {
                                this.txtInput.SelectionStart = m_intSelectionStart;
                                this.txtInput.SelectionLength = m_intSelectionLength;
                            }
                        };
                    }

                    break;
                case KeyBoardType.UCKeyBorderNum:
                    if (m_frmAnchor == null)
                    {
                        UCKeyBorderNum key = new UCKeyBorderNum();
                        m_frmAnchor = new Forms.FrmAnchor(this, key);
                        m_frmAnchor.VisibleChanged += (a, b) =>
                        {
                            if (m_frmAnchor.Visible)
                            {
                                this.txtInput.SelectionStart = m_intSelectionStart;
                                this.txtInput.SelectionLength = m_intSelectionLength;
                            }
                        };
                    }
                    break;
                case HZH_Controls.Controls.KeyBoardType.UCKeyBorderHand:

                    m_frmAnchor = new Forms.FrmAnchor(this, new Size(504, 361));
                    m_frmAnchor.VisibleChanged += m_frmAnchor_VisibleChanged;
                    m_frmAnchor.Disposed += m_frmAnchor_Disposed;
                    Panel p = new Panel();
                    p.Dock = DockStyle.Fill;
                    p.Name = "keyborder";
                    m_frmAnchor.Controls.Add(p);

                    UCBtnExt btnDelete = new UCBtnExt();
                    btnDelete.Name = "btnDelete";
                    btnDelete.Size = new Size(80, 28);
                    btnDelete.FillColor = Color.White;
                    btnDelete.IsRadius = false;
                    btnDelete.ConerRadius = 1;
                    btnDelete.IsShowRect = true;
                    btnDelete.RectColor = Color.FromArgb(189, 197, 203);
                    btnDelete.Location = new Point(198, 332);
                    btnDelete.BtnFont = new System.Drawing.Font("微软雅黑", 8);
                    btnDelete.BtnText = "删除";
                    btnDelete.BtnClick += (a, b) =>
                    {
                        SendKeys.Send("{BACKSPACE}");
                    };
                    m_frmAnchor.Controls.Add(btnDelete);
                    btnDelete.BringToFront();

                    UCBtnExt btnEnter = new UCBtnExt();
                    btnEnter.Name = "btnEnter";
                    btnEnter.Size = new Size(82, 28);
                    btnEnter.FillColor = Color.White;
                    btnEnter.IsRadius = false;
                    btnEnter.ConerRadius = 1;
                    btnEnter.IsShowRect = true;
                    btnEnter.RectColor = Color.FromArgb(189, 197, 203);
                    btnEnter.Location = new Point(278, 332);
                    btnEnter.BtnFont = new System.Drawing.Font("微软雅黑", 8);
                    btnEnter.BtnText = "确定";
                    btnEnter.BtnClick += (a, b) =>
                    {
                        SendKeys.Send("{ENTER}");
                        m_frmAnchor.Hide();
                    };
                    m_frmAnchor.Controls.Add(btnEnter);
                    btnEnter.BringToFront();
                    m_frmAnchor.VisibleChanged += (a, b) =>
                    {
                        if (m_frmAnchor.Visible)
                        {
                            this.txtInput.SelectionStart = m_intSelectionStart;
                            this.txtInput.SelectionLength = m_intSelectionLength;
                        }
                    };
                    break;
            }
            if (!m_frmAnchor.Visible)
                m_frmAnchor.Show(this.FindForm());
            if (KeyboardClick != null)
            {
                KeyboardClick(sender, e);
            }
        }

        void m_frmAnchor_Disposed(object sender, EventArgs e)
        {
            if (m_HandAppWin != IntPtr.Zero)
            {
                if (m_HandPWin != null && !m_HandPWin.HasExited)
                    m_HandPWin.Kill();
                m_HandPWin = null;
                m_HandAppWin = IntPtr.Zero;
            }
        }


        IntPtr m_HandAppWin;
        Process m_HandPWin = null;
        string m_HandExeName = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "HandInput\\handinput.exe");

        void m_frmAnchor_VisibleChanged(object sender, EventArgs e)
        {
            if (m_frmAnchor.Visible)
            {
                var lstP = Process.GetProcessesByName("handinput");
                if (lstP.Length > 0)
                {
                    foreach (var item in lstP)
                    {
                        item.Kill();
                    }
                }
                m_HandAppWin = IntPtr.Zero;

                if (m_HandPWin == null)
                {
                    m_HandPWin = null;

                    m_HandPWin = System.Diagnostics.Process.Start(this.m_HandExeName);
                    m_HandPWin.WaitForInputIdle();
                }
                while (m_HandPWin.MainWindowHandle == IntPtr.Zero)
                {
                    Thread.Sleep(10);
                }
                m_HandAppWin = m_HandPWin.MainWindowHandle;
                Control p = m_frmAnchor.Controls.Find("keyborder", false)[0];
                SetParent(m_HandAppWin, p.Handle);
                ControlHelper.SetForegroundWindow(this.FindForm().Handle);
                MoveWindow(m_HandAppWin, -111, -41, 626, 412, true);
                //this.txtInput.SelectionStart = m_intSelectionStart;
                //this.txtInput.SelectionLength = m_intSelectionLength;
            }
            else
            {
                if (m_HandAppWin != IntPtr.Zero)
                {
                    if (m_HandPWin != null && !m_HandPWin.HasExited)
                        m_HandPWin.Kill();
                    m_HandPWin = null;
                    m_HandAppWin = IntPtr.Zero;
                }
            }
        }

        private void UCTextBoxEx_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = txtInput;
        }

        private void UCTextBoxEx_Load(object sender, EventArgs e)
        {
            if (!Enabled)
            {
                base.FillColor = Color.FromArgb(240, 240, 240);
                txtInput.BackColor = Color.FromArgb(240, 240, 240);
            }
            else
            {
                FillColor = _FillColor;
                txtInput.BackColor = _FillColor;
            }
        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);
        private const int GWL_STYLE = -16;
        private const int WS_CHILD = 0x40000000;//设置窗口属性为child

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private extern static IntPtr SetActiveWindow(IntPtr handle);
    }
}
