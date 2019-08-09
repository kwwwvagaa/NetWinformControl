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
    [DefaultEvent("BtnClick")]
    public partial class UCBtnFillet : UCControlBase
    {
        [Description("按钮点击事件"), Category("自定义")]
        public event EventHandler BtnClick;
        [Description("按钮图片"), Category("自定义")]
        public Image BtnImage
        {
            get
            {
                return lbl.Image;
            }
            set
            {
                lbl.Image = value;
            }
        }
        /// <summary>
        /// 按钮文字
        /// </summary>
        [Description("按钮文字"), Category("自定义")]
        public string BtnText
        {
            get { return lbl.Text; }
            set
            {
                lbl.Text = value;
            }
        }
        public UCBtnFillet()
        {
            InitializeComponent();
        }

        private void lbl_MouseDown(object sender, MouseEventArgs e)
        {
            if (BtnClick != null)
                BtnClick(this, e);
        }
    }
}
