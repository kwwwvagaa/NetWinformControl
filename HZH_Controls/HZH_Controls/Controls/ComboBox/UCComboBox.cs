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
    [DefaultEvent("SelectedChangedEvent")]
    public partial class UCComboBox : UCControlBase
    {
        Color _ForeColor = Color.FromArgb(64, 64, 64);
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

        public event EventHandler SelectedChangedEvent;
        public event EventHandler TextChangedEvent;

        private ComboBoxStyle _BoxStyle = ComboBoxStyle.DropDown;

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

        private Font _Font = new Font("微软雅黑", 12);
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


        [Obsolete("不再可用的属性")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        private new Color FillColor
        {
            get;
            set;
        }

        [Obsolete("不再可用的属性")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        private new Color RectColor
        {
            get;
            set;
        }

        private string _TextValue;

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

        private List<KeyValuePair<string, string>> _source = null;

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

        private KeyValuePair<string, string> _selectedItem = new KeyValuePair<string, string>();

        private int _selectedIndex = -1;

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

        private string _selectedValue = "";

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

        private string _selectedText = "";

        public string SelectedText
        {
            get { return _selectedText; }
            private set
            {
                //if (_source == null || _source.Count <= 0)
                //{
                //    _selectText = "";
                //    _selectValue = "";
                //    _selectIndex = -1;
                //    _selectItem = new KeyValuePair<string, string>();
                //}
                //else
                //{
                //    _selectText = "";
                //    _selectValue = "";
                //    _selectIndex = -1;
                //    _selectItem = new KeyValuePair<string, string>();
                //    for (int i = 0; i < _source.Count; i++)
                //    {
                //        if (_source[i].Value == value)
                //        {
                //            _selectText = value;
                //            _selectValue = _source[i].Key;
                //            _selectIndex = i;
                //            _selectItem = _source[i];
                //            break;
                //        }
                //    }
                //}
                _selectedText = value;
                lblInput.Text = _selectedText;
                txtInput.Text = _selectedText;
                if (SelectedChangedEvent != null)
                {
                    SelectedChangedEvent(this, null);
                }
            }
        }

        private int _ItemWidth = 70;

        public int ItemWidth
        {
            get { return _ItemWidth; }
            set { _ItemWidth = value; }
        }

        private int _dropPanelHeight = -1;

        public int DropPanelHeight
        {
            get { return _dropPanelHeight; }
            set { _dropPanelHeight = value; }
        }
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

        private Color _BackColor = Color.FromArgb(240, 240, 240);

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

        public UCComboBox()
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

        private void UCComboBox_SizeChanged(object sender, EventArgs e)
        {
            this.txtInput.Location = new Point(this.txtInput.Location.X, (this.Height - txtInput.Height) / 2);
            this.lblInput.Location = new Point(this.lblInput.Location.X, (this.Height - lblInput.Height) / 2);
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            TextValue = txtInput.Text;
            if (TextChangedEvent != null)
            {
                TextChangedEvent(this, null);
            }
        }

        private void click_MouseDown(object sender, MouseEventArgs e)
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
                Size size= new Size(intCom * intWidth, intRow * 50);
                ucTime.Size =size;
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


        Forms.FrmAnchor _frmAnchor;
        void ucTime_SelectSourceEvent(object sender, EventArgs e)
        {
            if (_frmAnchor != null && !_frmAnchor.IsDisposed && _frmAnchor.Visible)
            {
                SelectedValue = sender.ToString();
                _frmAnchor.Close();
            }
        }

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

            //if (this.Parent != null && BackColor == Color.Transparent)
            //{
            //    Control c = this;
            //    while (true)
            //    {
            //        if (c.BackColor == Color.Transparent)
            //        {
            //            c = c.Parent;
            //        }
            //        else
            //        {
            //            txtInput.BackColor = c.BackColor;
            //            base.FillColor = c.BackColor;
            //            base.RectColor = c.BackColor;
            //            break;
            //        }
            //    }
            //}
        }
    }
}
