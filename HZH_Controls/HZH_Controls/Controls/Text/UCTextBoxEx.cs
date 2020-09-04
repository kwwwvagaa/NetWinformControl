// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="UCTextBoxEx.cs">
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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCTextBoxEx.
    /// Implements the <see cref="HZH_Controls.Controls.UCControlBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.UCControlBase" />
    [DefaultEvent("TextChanged")]
    public partial class UCTextBoxEx : UCControlBase
    {
        /// <summary>
        /// The m is show clear BTN
        /// </summary>
        private bool m_isShowClearBtn = true;
        /// <summary>
        /// The m int selection start
        /// </summary>
        int m_intSelectionStart = 0;
        /// <summary>
        /// The m int selection length
        /// </summary>
        int m_intSelectionLength = 0;
        /// <summary>
        /// 功能描述:是否显示清理按钮
        /// 作　　者:HZH
        /// 创建日期:2019-02-28 16:13:52
        /// </summary>
        /// <value><c>true</c> if this instance is show clear BTN; otherwise, <c>false</c>.</value>
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

        /// <summary>
        /// The m is show search BTN
        /// </summary>
        private bool m_isShowSearchBtn = false;
        /// <summary>
        /// 是否显示查询按钮
        /// </summary>
        /// <value><c>true</c> if this instance is show search BTN; otherwise, <c>false</c>.</value>

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

        /// <summary>
        /// Gets or sets a value indicating whether this instance is show keyboard.
        /// </summary>
        /// <value><c>true</c> if this instance is show keyboard; otherwise, <c>false</c>.</value>
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

        [Description("获取或设置一个字符，该值指示文本框中的密码。")]
        public char PasswordChar
        {
            get
            {
                return txtInput.PasswordChar;
            }
            set
            {
                txtInput.PasswordChar = value;
            }
        }
        /// <summary>
        /// 获取或设置控件显示的文字的字体。
        /// </summary>
        /// <value>The font.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
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

        /// <summary>
        /// Gets or sets the type of the input.
        /// </summary>
        /// <value>The type of the input.</value>
        [Description("输入类型"), Category("自定义")]
        public TextInputType InputType
        {
            get { return txtInput.InputType; }
            set { txtInput.InputType = value; }
        }

        /// <summary>
        /// 水印文字
        /// </summary>
        /// <value>The prompt text.</value>
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

        /// <summary>
        /// Gets or sets the prompt font.
        /// </summary>
        /// <value>The prompt font.</value>
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

        /// <summary>
        /// Gets or sets the color of the prompt.
        /// </summary>
        /// <value>The color of the prompt.</value>
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
        /// <value>The regex pattern.</value>
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
        /// <value>The maximum value.</value>
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
        /// <value>The minimum value.</value>
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
        /// <value>The length of the decimal.</value>
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

        /// <summary>
        /// The key board type
        /// </summary>
        private KeyBoardType keyBoardType = KeyBoardType.UCKeyBorderAll_EN;
        /// <summary>
        /// Gets or sets the type of the key board.
        /// </summary>
        /// <value>The type of the key board.</value>
        [Description("键盘打开样式"), Category("自定义")]
        public KeyBoardType KeyBoardType
        {
            get { return keyBoardType; }
            set { keyBoardType = value; }
        }
        /// <summary>
        /// Occurs when [search click].
        /// </summary>
        [Description("查询按钮点击事件"), Category("自定义")]
        public event EventHandler SearchClick;

        /// <summary>
        /// Occurs when [text changed].
        /// </summary>
        [Description("文本改变事件"), Category("自定义")]
        public new event EventHandler TextChanged;
        /// <summary>
        /// Occurs when [keyboard click].
        /// </summary>
        [Description("键盘按钮点击事件"), Category("自定义")]
        public event EventHandler KeyboardClick;

        /// <summary>
        /// Gets or sets the input text.
        /// </summary>
        /// <value>The input text.</value>
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

        /// <summary>
        /// The focus border color
        /// </summary>
        private Color focusBorderColor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the color of the focus border.
        /// </summary>
        /// <value>The color of the focus border.</value>
        [Description("获取焦点时边框颜色，当IsFocusColor=true有效"), Category("自定义")]
        public Color FocusBorderColor
        {
            get { return focusBorderColor; }
            set { focusBorderColor = value; }
        }

        /// <summary>
        /// The is focus color
        /// </summary>
        private bool isFocusColor = true;
        /// <summary>
        /// Gets or sets a value indicating whether this instance is focus color.
        /// </summary>
        /// <value><c>true</c> if this instance is focus color; otherwise, <c>false</c>.</value>
        [Description("获取焦点是否变色"), Category("自定义")]
        public bool IsFocusColor
        {
            get { return isFocusColor; }
            set { isFocusColor = value; }
        }
        /// <summary>
        /// The fill color
        /// </summary>
        private Color _FillColor;
        /// <summary>
        /// 当使用边框时填充颜色，当值为背景色或透明色或空值则不填充
        /// </summary>
        /// <value>The color of the fill.</value>
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
        /// <summary>
        /// Initializes a new instance of the <see cref="UCTextBoxEx" /> class.
        /// </summary>
        public UCTextBoxEx()
        {
            InitializeComponent();
            txtInput.SizeChanged += UCTextBoxEx_SizeChanged;
            this.SizeChanged += UCTextBoxEx_SizeChanged;
            txtInput.GotFocus += (a, b) =>
            {
                if (isFocusColor)
                    this.RectColor = focusBorderColor;
            };
            txtInput.LostFocus += (a, b) =>
            {
                if (isFocusColor)
                    this.RectColor = Color.FromArgb(220, 220, 220);
            };
        }

        /// <summary>
        /// Handles the SizeChanged event of the UCTextBoxEx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void UCTextBoxEx_SizeChanged(object sender, EventArgs e)
        {
            this.txtInput.Location = new Point(this.txtInput.Location.X, (this.Height - txtInput.Height) / 2);
        }


        /// <summary>
        /// Handles the TextChanged event of the txtInput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the MouseDown event of the btnClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void btnClear_MouseDown(object sender, MouseEventArgs e)
        {
            txtInput.Clear();
            txtInput.Focus();
        }

        /// <summary>
        /// Handles the MouseDown event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void btnSearch_MouseDown(object sender, MouseEventArgs e)
        {
            if (SearchClick != null)
            {
                SearchClick(sender, e);
            }
        }
        /// <summary>
        /// The m FRM anchor
        /// </summary>
        Forms.FrmAnchor m_frmAnchor;
        /// <summary>
        /// Handles the MouseDown event of the btnKeybord control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void btnKeybord_MouseDown(object sender, MouseEventArgs e)
        {
            if (keyBoardType == HZH_Controls.Controls.KeyBoardType.Null)
                return;
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
                        key.EnterClick += (a, b) =>
                        {
                            m_frmAnchor.Hide();
                        };
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

        /// <summary>
        /// Handles the Disposed event of the m_frmAnchor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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


        /// <summary>
        /// The m hand application win
        /// </summary>
        IntPtr m_HandAppWin;
        /// <summary>
        /// The m hand p win
        /// </summary>
        Process m_HandPWin = null;
        /// <summary>
        /// The m hand executable name
        /// </summary>
        string m_HandExeName = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "HandInput\\handinput.exe");

        /// <summary>
        /// Handles the VisibleChanged event of the m_frmAnchor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the MouseDown event of the UCTextBoxEx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void UCTextBoxEx_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = txtInput;
        }

        /// <summary>
        /// Handles the Load event of the UCTextBoxEx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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
        /// <summary>
        /// Sets the parent.
        /// </summary>
        /// <param name="hWndChild">The h WND child.</param>
        /// <param name="hWndNewParent">The h WND new parent.</param>
        /// <returns>System.Int64.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        /// <summary>
        /// Moves the window.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="cx">The cx.</param>
        /// <param name="cy">The cy.</param>
        /// <param name="repaint">if set to <c>true</c> [repaint].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);
        /// <summary>
        /// Shows the window.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="nCmdShow">The n command show.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        /// <summary>
        /// Sets the window position.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="hWndlnsertAfter">The h wndlnsert after.</param>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="cx">The cx.</param>
        /// <param name="cy">The cy.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);
        /// <summary>
        /// The GWL style
        /// </summary>
        private const int GWL_STYLE = -16;
        /// <summary>
        /// The ws child
        /// </summary>
        private const int WS_CHILD = 0x40000000;//设置窗口属性为child

        /// <summary>
        /// Gets the window long.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="nIndex">Index of the n.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        /// <summary>
        /// Sets the window long.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="nIndex">Index of the n.</param>
        /// <param name="dwNewLong">The dw new long.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

        /// <summary>
        /// Sets the active window.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        private extern static IntPtr SetActiveWindow(IntPtr handle);
    }
}
