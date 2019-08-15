// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：FrmWithTitle.cs
// 创建日期：2019-08-15 16:05:30
// 功能描述：FrmWithTitle
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Forms
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))]
    public partial class FrmWithTitle : FrmBase
    {
        [Description("窗体标题"), Category("自定义")]
        public string Title
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }
        private bool _isShowCloseBtn = false;
        [Description("是否显示右上角关闭按钮"), Category("自定义")]
        public bool IsShowCloseBtn
        {
            get
            {
                return _isShowCloseBtn;
            }
            set
            {
                _isShowCloseBtn = value;
                btnClose.Visible = value;
                if (value)
                {
                    btnClose.Location = new Point(this.Width - btnClose.Width - 10, 0);
                    btnClose.BringToFront();
                }
            }
        }

        public FrmWithTitle()
        {
            InitializeComponent();
        }

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void FrmWithTitle_Shown(object sender, EventArgs e)
        {
            if (IsShowCloseBtn)
            {
                btnClose.Location = new Point(this.Width - btnClose.Width - 10, 0);
                btnClose.BringToFront();
            }
        }

        private void btnClose_MouseDown_1(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void FrmWithTitle_VisibleChanged(object sender, EventArgs e)
        {
            //if (this.Visible)
            //{
            //    ControlHelper.AnimateWindow(this.Handle, 100, ControlHelper.AW_CENTER);
            //}
            //else
            //{
            //    ControlHelper.AnimateWindow(this.Handle, 100, ControlHelper.AW_CENTER | ControlHelper.AW_HIDE);
            //}
        }
    }
}
