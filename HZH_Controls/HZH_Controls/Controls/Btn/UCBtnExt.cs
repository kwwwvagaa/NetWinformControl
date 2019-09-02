// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCBtnExt.cs
// 创建日期：2019-08-15 15:57:36
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

    public partial class UCBtnExt : UCControlBase
    {
        #region 字段属性
        [Description("是否显示角标"), Category("自定义")]
        public bool IsShowTips
        {
            get
            {
                return this.lblTips.Visible;
            }
            set
            {
                this.lblTips.Visible = value;
            }
        }

        [Description("角标文字"), Category("自定义")]
        public string TipsText
        {
            get
            {
                return this.lblTips.Text;
            }
            set
            {
                this.lblTips.Text = value;
            }
        }

        private Color _btnBackColor = Color.White;
        [Description("按钮背景色"), Category("自定义")]
        public Color BtnBackColor
        {
            get { return _btnBackColor; }
            set
            {
                _btnBackColor = value;
                this.BackColor = value;
            }
        }

        private Color _btnForeColor = Color.White;
        /// <summary>
        /// 按钮字体颜色
        /// </summary>
        [Description("按钮字体颜色"), Category("自定义")]
        public virtual Color BtnForeColor
        {
            get { return _btnForeColor; }
            set
            {
                _btnForeColor = value;
                this.lbl.ForeColor = value;
            }
        }

        private Font _btnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        /// <summary>
        /// 按钮字体
        /// </summary>
        [Description("按钮字体"), Category("自定义")]
        public Font BtnFont
        {
            get { return _btnFont; }
            set
            {
                _btnFont = value;
                this.lbl.Font = value;
            }
        }

        /// <summary>
        /// 按钮点击事件
        /// </summary>
        [Description("按钮点击事件"), Category("自定义")]
        public event EventHandler BtnClick;

        private string _btnText;
        /// <summary>
        /// 按钮文字
        /// </summary>
        [Description("按钮文字"), Category("自定义")]
        public virtual string BtnText
        {
            get { return _btnText; }
            set
            {
                _btnText = value;
                lbl.Text = value;
            }
        }

        private Color m_tipsColor = Color.FromArgb(232, 30, 99);

        [Description("角标颜色"), Category("自定义")]
        public Color TipsColor
        {
            get { return m_tipsColor; }
            set { m_tipsColor = value; }
        }
        #endregion
        public UCBtnExt()
        {
            InitializeComponent();
            this.TabStop = false;
            lblTips.Paint += lblTips_Paint;
        }

        void lblTips_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetGDIHigh();
            e.Graphics.FillEllipse(new SolidBrush(m_tipsColor), new Rectangle(0, 0, lblTips.Width - 1, lblTips.Height - 1));
            System.Drawing.SizeF sizeEnd = e.Graphics.MeasureString(TipsText, lblTips.Font);

            e.Graphics.DrawString(TipsText, lblTips.Font, new SolidBrush(lblTips.ForeColor), new PointF((lblTips.Width - sizeEnd.Width) / 2, (lblTips.Height - sizeEnd.Height) / 2 + 1));
        }

        private void lbl_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.BtnClick != null)
                BtnClick(this, e);
        }
    }
}
