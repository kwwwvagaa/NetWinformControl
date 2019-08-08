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
    public partial class FrmDialog : FrmBase
    {
        bool blnEnterClose = true;
        private FrmDialog(
            string strMessage,
            string strTitle,
            bool blnShowCancel = false,
            bool blnShowClose = false,
            bool blnisEnterClose = true)
        {
            InitializeComponent();
            if (!string.IsNullOrWhiteSpace(strTitle))
                lblTitle.Text = strTitle;
            lblMsg.Text = strMessage;
            if (blnShowCancel)
            {
                this.tableLayoutPanel1.ColumnStyles[1].Width = 1;
                this.tableLayoutPanel1.ColumnStyles[2].Width = 50;
            }
            else
            {
                this.tableLayoutPanel1.ColumnStyles[1].Width = 0;
                this.tableLayoutPanel1.ColumnStyles[2].Width = 0;
            }
            //btnCancel.Visible = blnShowCancel;
            //ucSplitLine_V1.Visible = blnShowCancel;
            btnClose.Visible = blnShowClose;
            blnEnterClose = blnisEnterClose;
            //if (blnShowCancel)
            //{
            //    btnOK.BtnForeColor = Color.FromArgb(255, 85, 51);
            //}
        }

        #region 显示一个模式信息框
        /// <summary>
        /// 功能描述:显示一个模式信息框
        /// 作　　者:HZH
        /// 创建日期:2019-03-04 15:49:48
        /// 任务编号:POS
        /// </summary>
        /// <param name="owner">owner</param>
        /// <param name="strMessage">strMessage</param>
        /// <param name="strTitle">strTitle</param>
        /// <param name="blnShowCancel">blnShowCancel</param>
        /// <param name="isShowMaskDialog">isShowMaskDialog</param>
        /// <param name="blnShowClose">blnShowClose</param>
        /// <param name="isEnterClose">isEnterClose</param>
        /// <returns>返回值</returns>
        public static DialogResult ShowDialog(
            IWin32Window owner,
            string strMessage,
            string strTitle = "提示",
            bool blnShowCancel = false,
            bool isShowMaskDialog = true,
            bool blnShowClose = false,
            bool blnIsEnterClose = true)
        {
            DialogResult result = DialogResult.Cancel;
            if (owner == null || (owner is Control && (owner as Control).IsDisposed))
            {
                result = new FrmDialog(strMessage, strTitle, blnShowCancel, blnShowClose, blnIsEnterClose)
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    IsShowMaskDialog = isShowMaskDialog,
                    TopMost = true
                }.ShowDialog();
            }
            else
            {
                if (owner is Control)
                {
                    owner = (owner as Control).FindForm();
                }
                result = new FrmDialog(strMessage, strTitle, blnShowCancel, blnShowClose, blnIsEnterClose)
                {
                    StartPosition = (owner != null) ? FormStartPosition.CenterParent : FormStartPosition.CenterScreen,
                    IsShowMaskDialog = isShowMaskDialog,
                    TopMost = true
                }.ShowDialog(owner);
            }
            return result;
        }
        #endregion

        private void btnOK_BtnClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_BtnClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        protected override void DoEnter()
        {
            if (blnEnterClose)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmDialog_VisibleChanged(object sender, EventArgs e)
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
