// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="UCCombox.cs">
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
using System.Drawing.Drawing2D;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCCombox.
    /// Implements the <see cref="HZH_Controls.Controls.UCControlBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.UCControlBase" />
    [DefaultEvent("SelectedChangedEvent")]
    public partial class UCCombox : UCControlBase
    {
        /// <summary>
        /// The fore color
        /// </summary>
        Color _ForeColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 文字颜色
        /// </summary>
        /// <value>The color of the fore.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [Description("文字颜色"), Category("自定义")]
        public override Color ForeColor
        {
            get
            {
                return _ForeColor;
            }
            set
            {
                _ForeColor = value;
                lblInput.ForeColor = value;
                txtInput.ForeColor = value;
            }
        }
        /// <summary>
        /// 选中事件
        /// </summary>
        [Description("选中事件"), Category("自定义")]
        public event EventHandler SelectedChangedEvent;
        /// <summary>
        /// 文本改变事件
        /// </summary>
        [Description("文本改变事件"), Category("自定义")]
        public event EventHandler TextChangedEvent;

        /// <summary>
        /// The box style
        /// </summary>
        private ComboBoxStyle _BoxStyle = ComboBoxStyle.DropDown;
        /// <summary>
        /// 控件样式
        /// </summary>
        /// <value>The box style.</value>
        [Description("控件样式"), Category("自定义")]
        public ComboBoxStyle BoxStyle
        {
            get { return _BoxStyle; }
            set
            {
                _BoxStyle = value;
                if (value == ComboBoxStyle.DropDownList)
                {
                    lblInput.Visible = true;
                    txtInput.Visible = false;
                }
                else
                {
                    lblInput.Visible = false;
                    txtInput.Visible = true;
                }

                if (this._BoxStyle == ComboBoxStyle.DropDownList)
                {
                    txtInput.BackColor = _BackColor;
                    base.FillColor = _BackColor;
                    base.RectColor = _BackColor;
                }
                else
                {
                    txtInput.BackColor = Color.White;
                    base.FillColor = Color.White;
                    base.RectColor = Color.FromArgb(220, 220, 220);
                }
            }
        }

        /// <summary>
        /// The font
        /// </summary>
        private Font _Font = new Font("微软雅黑", 12);
        /// <summary>
        /// 字体
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
            get { return _Font; }
            set
            {
                _Font = value;
                lblInput.Font = value;
                txtInput.Font = value;
                txtInput.PromptFont = value;
                this.txtInput.Location = new Point(this.txtInput.Location.X, (this.Height - txtInput.Height) / 2);
                this.lblInput.Location = new Point(this.lblInput.Location.X, (this.Height - lblInput.Height) / 2);
            }
        }


        /// <summary>
        /// 当使用边框时填充颜色，当值为背景色或透明色或空值则不填充
        /// </summary>
        /// <value>The color of the fill.</value>
        [Obsolete("不再可用的属性")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        private new Color FillColor
        {
            get;
            set;
        }

        /// <summary>
        /// 边框颜色
        /// </summary>
        /// <value>The color of the rect.</value>
        [Obsolete("不再可用的属性")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        private new Color RectColor
        {
            get;
            set;
        }

        /// <summary>
        /// The text value
        /// </summary>
        private string _TextValue;
        /// <summary>
        /// 文字
        /// </summary>
        /// <value>The text value.</value>
        [Description("文字"), Category("自定义")]
        public string TextValue
        {
            get { return _TextValue; }
            set
            {
                _TextValue = value;
                if (lblInput.Text != value)
                    lblInput.Text = value;
                if (txtInput.Text != value)
                    txtInput.Text = value;
            }
        }

        /// <summary>
        /// The source
        /// </summary>
        private List<KeyValuePair<string, string>> _source = null;
        /// <summary>
        /// 数据源
        /// </summary>
        /// <value>The source.</value>
        [Description("数据源"), Category("自定义")]
        public List<KeyValuePair<string, string>> Source
        {
            get { return _source; }
            set
            {
                _source = value;
                _selectedIndex = -1;
                _selectedValue = "";
                _selectedItem = new KeyValuePair<string, string>();
                _selectedText = "";
                lblInput.Text = "";
                txtInput.Text = "";
            }
        }

        /// <summary>
        /// The selected item
        /// </summary>
        private KeyValuePair<string, string> _selectedItem = new KeyValuePair<string, string>();

        /// <summary>
        /// The selected index
        /// </summary>
        private int _selectedIndex = -1;
        /// <summary>
        /// 选中的数据下标
        /// </summary>
        /// <value>The index of the selected.</value>
        [Description("选中的数据下标"), Category("自定义")]
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                if (value < 0 || _source == null || _source.Count <= 0 || value >= _source.Count)
                {
                    _selectedIndex = -1;
                    _selectedValue = "";
                    _selectedItem = new KeyValuePair<string, string>();
                    SelectedText = "";
                }
                else
                {
                    _selectedIndex = value;
                    _selectedItem = _source[value];
                    _selectedValue = _source[value].Key;
                    SelectedText = _source[value].Value;
                }
            }
        }

        /// <summary>
        /// The selected value
        /// </summary>
        private string _selectedValue = "";
        /// <summary>
        /// 选中的值
        /// </summary>
        /// <value>The selected value.</value>
        [Description("选中的值"), Category("自定义")]
        public string SelectedValue
        {
            get
            {
                return _selectedValue;
            }
            set
            {
                if (_source == null || _source.Count <= 0)
                {
                    SelectedText = "";
                    _selectedValue = "";
                    _selectedIndex = -1;
                    _selectedItem = new KeyValuePair<string, string>();
                }
                else
                {
                    for (int i = 0; i < _source.Count; i++)
                    {
                        if (_source[i].Key == value)
                        {
                            _selectedValue = value;
                            _selectedIndex = i;
                            _selectedItem = _source[i];
                            SelectedText = _source[i].Value;
                            return;
                        }
                    }
                    _selectedValue = "";
                    _selectedIndex = -1;
                    _selectedItem = new KeyValuePair<string, string>();
                    SelectedText = "";
                }
            }
        }

        /// <summary>
        /// The selected text
        /// </summary>
        private string _selectedText = "";
        /// <summary>
        /// 选中的文本
        /// </summary>
        /// <value>The selected text.</value>
        [Description("选中的文本"), Category("自定义")]
        public string SelectedText
        {
            get { return _selectedText; }
            private set
            {
                _selectedText = value;
                lblInput.Text = _selectedText;
                txtInput.Text = _selectedText;
                if (SelectedChangedEvent != null)
                {
                    SelectedChangedEvent(this, null);
                }
            }
        }

        /// <summary>
        /// The item width
        /// </summary>
        private int _ItemWidth = 70;
        /// <summary>
        /// 项宽度
        /// </summary>
        /// <value>The width of the item.</value>
        [Description("项宽度"), Category("自定义")]
        public int ItemWidth
        {
            get { return _ItemWidth; }
            set { _ItemWidth = value; }
        }

        /// <summary>
        /// The drop panel height
        /// </summary>
        private int _dropPanelHeight = -1;
        /// <summary>
        /// 下拉面板高度
        /// </summary>
        /// <value>The height of the drop panel.</value>
        [Description("下拉面板高度"), Category("自定义")]
        public int DropPanelHeight
        {
            get { return _dropPanelHeight; }
            set { _dropPanelHeight = value; }
        }
        /// <summary>
        /// 获取或设置控件的背景色。
        /// </summary>
        /// <value>The color of the back.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [Obsolete("不再可用的属性,如需要改变背景色，请使用BackColorExt")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        private new Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = Color.Transparent;
            }
        }

        /// <summary>
        /// The back color
        /// </summary>
        private Color _BackColor = Color.FromArgb(240, 240, 240);
        /// <summary>
        /// 背景色
        /// </summary>
        /// <value>The back color ext.</value>
        [Description("背景色"), Category("自定义")]
        public Color BackColorExt
        {
            get
            {
                return _BackColor;
            }
            set
            {
                if (value == Color.Transparent)
                    return;
                _BackColor = value;
                lblInput.BackColor = value;

                if (this._BoxStyle == ComboBoxStyle.DropDownList)
                {
                    txtInput.BackColor = value;
                    base.FillColor = value;
                    base.RectColor = value;
                }
                else
                {
                    txtInput.BackColor = Color.White;
                    base.FillColor = Color.White;
                    base.RectColor = Color.FromArgb(220, 220, 220);
                }
            }
        }

        /// <summary>
        /// The triangle color
        /// </summary>
        private Color triangleColor = Color.FromArgb(255, 77, 59);
        /// <summary>
        /// 三角颜色
        /// </summary>
        /// <value>The color of the triangle.</value>
        [Description("三角颜色"), Category("自定义")]
        public Color TriangleColor
        {
            get { return triangleColor; }
            set
            {
                triangleColor = value;
                Bitmap bit = new Bitmap(12, 10);
                Graphics g = Graphics.FromImage(bit);
                g.SetGDIHigh();
                GraphicsPath path = new GraphicsPath();
                path.AddLines(new Point[] 
                {
                    new Point(1,1),
                    new Point(11,1),
                    new Point(6,10),
                    new Point(1,1)
                });
                g.FillPath(new SolidBrush(value), path);
                g.Dispose();
                panel1.BackgroundImage = bit;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCCombox" /> class.
        /// </summary>
        public UCCombox()
        {
            InitializeComponent();
            lblInput.BackColor = _BackColor;
            if (this._BoxStyle == ComboBoxStyle.DropDownList)
            {
                txtInput.BackColor = _BackColor;
                base.FillColor = _BackColor;
                base.RectColor = _BackColor;
            }
            else
            {
                txtInput.BackColor = Color.White;
                base.FillColor = Color.White;
                base.RectColor = Color.FromArgb(220, 220, 220);
            }
            base.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Handles the SizeChanged event of the UCComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void UCComboBox_SizeChanged(object sender, EventArgs e)
        {
            this.txtInput.Location = new Point(this.txtInput.Location.X, (this.Height - txtInput.Height) / 2);
            this.lblInput.Location = new Point(this.lblInput.Location.X, (this.Height - lblInput.Height) / 2);
        }

        /// <summary>
        /// Handles the TextChanged event of the txtInput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            TextValue = txtInput.Text;
            if (TextChangedEvent != null)
            {
                TextChangedEvent(this, null);
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        protected virtual void click_MouseDown(object sender, MouseEventArgs e)
        {
            if (_frmAnchor == null || _frmAnchor.IsDisposed || _frmAnchor.Visible == false)
            {

                if (this.Source != null && this.Source.Count > 0)
                {
                    int intRow = 0;
                    int intCom = 1;
                    var p = this.PointToScreen(this.Location);
                    while (true)
                    {
                        int intScreenHeight = Screen.PrimaryScreen.Bounds.Height;
                        if ((p.Y + this.Height + this.Source.Count / intCom * 50 < intScreenHeight || p.Y - this.Source.Count / intCom * 50 > 0)
                            && (_dropPanelHeight <= 0 ? true : (this.Source.Count / intCom * 50 <= _dropPanelHeight)))
                        {
                            intRow = this.Source.Count / intCom + (this.Source.Count % intCom != 0 ? 1 : 0);
                            break;
                        }
                        intCom++;
                    }
                    UCTimePanel ucTime = new UCTimePanel();
                    ucTime.IsShowBorder = true;
                    int intWidth = this.Width / intCom;
                    if (intWidth < _ItemWidth)
                        intWidth = _ItemWidth;
                    Size size = new Size(intCom * intWidth, intRow * 50);
                    ucTime.Size = size;
                    ucTime.FirstEvent = true;
                    ucTime.SelectSourceEvent += ucTime_SelectSourceEvent;
                    ucTime.Row = intRow;
                    ucTime.Column = intCom;
                    List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();
                    foreach (var item in this.Source)
                    {
                        lst.Add(new KeyValuePair<string, string>(item.Key, item.Value));
                    }
                    ucTime.Source = lst;

                    ucTime.SetSelect(_selectedValue);

                    _frmAnchor = new Forms.FrmAnchor(this, ucTime);
                    _frmAnchor.Load += (a, b) => { (a as Form).Size = size; };

                    _frmAnchor.Show(this.FindForm());

                }
            }
            else
            {
                _frmAnchor.Close();
            }
        }


        /// <summary>
        /// The FRM anchor
        /// </summary>
        Forms.FrmAnchor _frmAnchor;
        /// <summary>
        /// Handles the SelectSourceEvent event of the ucTime control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void ucTime_SelectSourceEvent(object sender, EventArgs e)
        {
            if (_frmAnchor != null && !_frmAnchor.IsDisposed && _frmAnchor.Visible)
            {
                SelectedValue = sender.ToString();
                _frmAnchor.Close();
            }
        }

        /// <summary>
        /// Handles the Load event of the UCComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void UCComboBox_Load(object sender, EventArgs e)
        {
            if (this._BoxStyle == ComboBoxStyle.DropDownList)
            {
                txtInput.BackColor = _BackColor;
                base.FillColor = _BackColor;
                base.RectColor = _BackColor;
            }
            else
            {
                txtInput.BackColor = Color.White;
                base.FillColor = Color.White;
                base.RectColor = Color.FromArgb(220, 220, 220);
            }
        }
    }
}
