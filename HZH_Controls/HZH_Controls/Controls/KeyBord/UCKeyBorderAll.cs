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
    [DefaultEvent("KeyDown")]
    public partial class UCKeyBorderAll : UserControl
    {
        private KeyBorderCharType _charType = KeyBorderCharType.CHAR;

        [Description("默认显示样式"), Category("自定义")]
        public KeyBorderCharType CharType
        {
            get { return _charType; }
            set
            {
                _charType = value;
                if (value == KeyBorderCharType.CHAR)
                {
                    if (label37.Text.ToLower() == "abc.")
                    {
                        CharOrNum();
                    }
                }
                else
                {
                    if (label37.Text.ToLower() == "?123")
                    {
                        CharOrNum();
                    }
                }
            }
        }
        [Description("按键点击事件"), Category("自定义")]
        public event EventHandler KeyClick;
        [Description("回车点击事件"), Category("自定义")]
        public event EventHandler EnterClick;
        [Description("删除点击事件"), Category("自定义")]
        public event EventHandler BackspaceClike;
        [Description("收起点击事件"), Category("自定义")]
        public event EventHandler RetractClike;
        public UCKeyBorderAll()
        {
            InitializeComponent();
        }

        private void KeyDown_MouseDown(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            if (string.IsNullOrEmpty(lbl.Text))
            {
                return;
            }
            if (lbl.Text == "大写")
            {
                ToUper(true);
                lbl.Text = "小写";
            }
            else if (lbl.Text == "小写")
            {
                ToUper(false);
                lbl.Text = "大写";
            }
            else if (lbl.Text == "?123" || lbl.Text == "abc.")
            {
                CharOrNum();
            }
            else if (lbl.Text == "空格")
            {
                SendKeys.Send(" ");
            }
            else if (lbl.Text == "删除")
            {
                SendKeys.Send("{BACKSPACE}");
                if (BackspaceClike != null)
                    BackspaceClike(sender, e);
            }
            else if (lbl.Text == "回车")
            {
                SendKeys.Send("{ENTER}");
                if (EnterClick != null)
                    EnterClick(sender, e);
            }
            else if (lbl.Text == "收起")
            {
                if (RetractClike != null)
                    RetractClike(sender, e);
            }
            else
            {
                SendKeys.Send(lbl.Text);
            }
            if (KeyClick != null)
                KeyClick(sender, e);
        }

        private void ToUper(bool bln)
        {
            foreach (Control item in this.tableLayoutPanel2.Controls)
            {
                if (item is Panel)
                {
                    foreach (Control pc in item.Controls)
                    {
                        if (pc is Label)
                        {
                            if (pc.Text == "abc.")
                                break;
                            if (bln)
                            {
                                pc.Text = pc.Text.ToUpper();
                            }
                            else
                            {
                                pc.Text = pc.Text.ToLower();
                            }
                            break;
                        }
                    }                   
                }
            }
        }

        private void CharOrNum()
        {
            foreach (Control item in this.tableLayoutPanel2.Controls)
            {
                if (item is Panel)
                {
                    foreach (Control pc in item.Controls)
                    {
                        if (pc is Label)
                        {
                            string strTag = pc.Text;
                            pc.Text = pc.Tag.ToString();
                            pc.Tag = strTag;
                            break;
                        }
                    }                   
                }
            }
        }
    }
    public enum KeyBorderCharType
    {
        CHAR = 1,
        NUMBER = 2
    }
}
