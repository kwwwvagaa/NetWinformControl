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
