// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCBtnImg.cs
// 创建日期：2019-08-15 15:58:07
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
    /// <summary>
    /// 
    /// </summary>
    public partial class UCBtnImg : UCBtnExt
    {
        private string _btnText = "自定义按钮";
        /// <summary>
        /// 按钮文字
        /// </summary>
        [Description("按钮文字"), Category("自定义")]
        public new string BtnText
        {
            get { return _btnText; }
            set
            {
                _btnText = value;
                lbl.Text = "    " + value;
                lbl.Refresh();
            }
        }
        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片"), Category("自定义")]
        public Image Image
        {
            get
            {
                return this.imageList1.Images[0];
            }
            set
            {
                this.imageList1.Images.Clear();
                this.imageList1.Images.Add(value);
                this.lbl.ImageIndex = 0;
            }
        }

        public UCBtnImg()
        {
            InitializeComponent();
            base.BtnForeColor = ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            base.BtnFont = new System.Drawing.Font("微软雅黑", 17F);
            base.BtnText = "    自定义按钮";
        }
    }
}
