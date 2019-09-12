// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="UCBtnImg.cs">
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

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCBtnImg.
    /// Implements the <see cref="HZH_Controls.Controls.UCBtnExt" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.UCBtnExt" />
    public partial class UCBtnImg : UCBtnExt
    {
        /// <summary>
        /// The BTN text
        /// </summary>
        private string _btnText = "自定义按钮";
        /// <summary>
        /// 按钮文字
        /// </summary>
        /// <value>The BTN text.</value>
        [Description("按钮文字"), Category("自定义")]
        public override string BtnText
        {
            get { return _btnText; }
            set
            {
                _btnText = value;
                lbl.Text = value;
                lbl.Refresh();
            }
        }
        /// <summary>
        /// 图片
        /// </summary>
        /// <value>The image.</value>
        [Description("图片"), Category("自定义")]
        public virtual Image Image
        {
            get
            {
                return this.lbl.Image;
            }
            set
            {
                this.lbl.Image = value;
            }
        }

        private object imageFontIcons;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Editor(typeof(ImagePropertyEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public object ImageFontIcons
        {
            get { return imageFontIcons; }
            set
            {
                if (value == null || value is Image)
                {
                    imageFontIcons = value;
                    if (value != null)
                    {
                        Image = (Image)value;
                    }
                }
            }
        }

        /// <summary>
        /// 图片位置
        /// </summary>
        /// <value>The image align.</value>
        [Description("图片位置"), Category("自定义")]
        public virtual ContentAlignment ImageAlign
        {
            get { return this.lbl.ImageAlign; }
            set { lbl.ImageAlign = value; }
        }
        /// <summary>
        /// 文字位置
        /// </summary>
        /// <value>The text align.</value>
        [Description("文字位置"), Category("自定义")]
        public virtual ContentAlignment TextAlign
        {
            get { return this.lbl.TextAlign; }
            set { lbl.TextAlign = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCBtnImg" /> class.
        /// </summary>
        public UCBtnImg()
        {
            InitializeComponent();
            IsShowTips = false;
            base.BtnForeColor = ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            base.BtnFont = new System.Drawing.Font("微软雅黑", 17F);
            base.BtnText = "自定义按钮";
        }
    }
}
