// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCBtnFillet.cs
// 创建日期：2019-08-15 15:58:03
// 功能描述：按钮
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
