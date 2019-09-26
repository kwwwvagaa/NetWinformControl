// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-26
//
// ***********************************************************************
// <copyright file="FrmLoading.cs">
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
using System.Threading;
using System.Windows.Forms;

namespace HZH_Controls.Forms
{
    /// <summary>
    /// Class FrmLoading.
    /// Implements the <see cref="HZH_Controls.Forms.FrmBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Forms.FrmBase" />
    public partial class FrmLoading : FrmBase
    {
        /// <summary>
        /// The update database worker
        /// </summary>
        BackgroundWorker updateDBWorker = new BackgroundWorker();
        /// <summary>
        /// 获取或设置加载任务
        /// </summary>
        /// <value>The background work action.</value>
        public Action BackgroundWorkAction
        {
            get;
            set;
        }
        /// <summary>
        /// 设置当前执行进度及任务名称，key:任务进度，取值0-100  value：当前任务名称
        /// </summary>
        /// <value>The current MSG.</value>
        public KeyValuePair<int, string> CurrentMsg
        {
            set
            {
                this.updateDBWorker.ReportProgress(value.Key, value.Value);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmLoading"/> class.
        /// </summary>
        public FrmLoading()
        {
            InitializeComponent();
            this.updateDBWorker.WorkerReportsProgress = true;
            this.updateDBWorker.WorkerSupportsCancellation = true;
            this.updateDBWorker.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.updateDBWorker.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
        }
        /// <summary>
        /// 设置进度信息，重写此函数可以处理界面信息绑定
        /// </summary>
        /// <param name="strText">进度任务名称</param>
        /// <param name="intValue">进度值</param>
        protected virtual void BindingProcessMsg(string strText, int intValue)
        {

        }

        /// <summary>
        /// Sets the message.
        /// </summary>
        /// <param name="strText">The string text.</param>
        /// <param name="intValue">The int value.</param>
        private void SetMessage(string strText, int intValue)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { SetMessage(strText, intValue); }));
            }
            else
            {
                BindingProcessMsg(strText, intValue);
            }
        }

        /// <summary>
        /// Handles the Load event of the FrmLoading control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmLoading_Load(object sender, EventArgs e)
        {
            if (ControlHelper.IsDesignMode())
                return;
            this.updateDBWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Handles the DoWork event of the backgroundWorker1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.BackgroundWorkAction != null)
            {
                this.BackgroundWorkAction();
            }
            Thread.Sleep(100);
            if (base.InvokeRequired)
            {
                base.BeginInvoke(new MethodInvoker(delegate
                {
                    base.Close();
                }));
            }
            else
            {
                base.Close();
            }
        }

        /// <summary>
        /// Handles the ProgressChanged event of the backgroundWorker1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetMessage((e.UserState == null) ? "" : e.UserState.ToString(), e.ProgressPercentage);
        }
    }
}
