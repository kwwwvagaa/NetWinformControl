// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：FrmWithOKCancel1.cs
// 创建日期：2019-08-15 16:05:16
// 功能描述：FrmWithOKCancel1
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
    public partial class FrmWithOKCancel1 : FrmWithTitle
    {
        public FrmWithOKCancel1()
        {
            InitializeComponent();
        }

        private void btnOK_BtnClick(object sender, EventArgs e)
        {
            DoEnter();
        }

        private void btnCancel_BtnClick(object sender, EventArgs e)
        {
            DoEsc();
        }

        protected override void DoEnter()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void FrmWithOKCancel1_VisibleChanged(object sender, EventArgs e)
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
