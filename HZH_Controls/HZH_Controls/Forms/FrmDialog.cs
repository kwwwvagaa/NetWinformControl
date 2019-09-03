// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="FrmDialog.cs">
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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Forms
{
    /// <summary>
    /// Class FrmDialog.
    /// Implements the <see cref="HZH_Controls.Forms.FrmBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Forms.FrmBase" />
    public partial class FrmDialog : FrmBase
    {
        /// <summary>
        /// The BLN enter close
        /// </summary>
        bool blnEnterClose = true;
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmDialog" /> class.
        /// </summary>
        /// <param name="strMessage">The string message.</param>
        /// <param name="strTitle">The string title.</param>
        /// <param name="blnShowCancel">if set to <c>true</c> [BLN show cancel].</param>
        /// <param name="blnShowClose">if set to <c>true</c> [BLN show close].</param>
        /// <param name="blnisEnterClose">if set to <c>true</c> [blnis enter close].</param>
        private FrmDialog(
            string strMessage,
            string strTitle,
            bool blnShowCancel = false,
            bool blnShowClose = false,
            bool blnisEnterClose = true)
        {
            InitializeComponent();
            InitFormMove(this.lblTitle);
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
        /// <param name="blnIsEnterClose">if set to <c>true</c> [BLN is enter close].</param>
        /// <param name="deviationSize">大小偏移，当默认大小过大或过小时，可以进行调整（增量）</param>
        /// <returns>返回值</returns>
        public static DialogResult ShowDialog(
            IWin32Window owner,
            string strMessage,
            string strTitle = "提示",
            bool blnShowCancel = false,
            bool isShowMaskDialog = true,
            bool blnShowClose = false,
            bool blnIsEnterClose = true,
            Size? deviationSize = null)
        {
            DialogResult result = DialogResult.Cancel;
            if (owner == null || (owner is Control && (owner as Control).IsDisposed))
            {
                var frm = new FrmDialog(strMessage, strTitle, blnShowCancel, blnShowClose, blnIsEnterClose)
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    IsShowMaskDialog = isShowMaskDialog,
                    TopMost = true
                };
                if (deviationSize != null)
                {
                    frm.Width += deviationSize.Value.Width;
                    frm.Height += deviationSize.Value.Height;
                }
                result = frm.ShowDialog();
            }
            else
            {
                if (owner is Control)
                {
                    owner = (owner as Control).FindForm();
                }
                var frm = new FrmDialog(strMessage, strTitle, blnShowCancel, blnShowClose, blnIsEnterClose)
                {
                    StartPosition = (owner != null) ? FormStartPosition.CenterParent : FormStartPosition.CenterScreen,
                    IsShowMaskDialog = isShowMaskDialog,
                    TopMost = true
                };
                if (deviationSize != null)
                {
                    frm.Width += deviationSize.Value.Width;
                    frm.Height += deviationSize.Value.Height;
                }
                result = frm.ShowDialog(owner);
            }
            return result;
        }
        #endregion

        /// <summary>
        /// Handles the BtnClick event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnOK_BtnClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Handles the BtnClick event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnCancel_BtnClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the MouseDown event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// Does the enter.
        /// </summary>
        protected override void DoEnter()
        {
            if (blnEnterClose)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Handles the VisibleChanged event of the FrmDialog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmDialog_VisibleChanged(object sender, EventArgs e)
        {
            
        }
    }
}
