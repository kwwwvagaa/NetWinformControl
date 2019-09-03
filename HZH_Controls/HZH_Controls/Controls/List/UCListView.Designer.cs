// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-22-2019
//
// ***********************************************************************
// <copyright file="UCListView.Designer.cs">
//     Copyright by Huang Zhenghui(黄正辉) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub：https://github.com/kwwwvagaa/NetWinformControl
// gitee：https://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCListView.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    partial class UCListView
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panPage = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panMain
            // 
            this.panMain.AutoScroll = true;
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(0, 0);
            this.panMain.Margin = new System.Windows.Forms.Padding(0);
            this.panMain.Name = "panMain";
            this.panMain.Padding = new System.Windows.Forms.Padding(5);
            this.panMain.Size = new System.Drawing.Size(462, 319);
            this.panMain.TabIndex = 1;
            this.panMain.Resize += new System.EventHandler(this.panMain_Resize);
            // 
            // panPage
            // 
            this.panPage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panPage.Location = new System.Drawing.Point(0, 319);
            this.panPage.Name = "panPage";
            this.panPage.Size = new System.Drawing.Size(462, 44);
            this.panPage.TabIndex = 0;
            this.panPage.Visible = false;
            // 
            // UCListView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.panPage);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCListView";
            this.Size = new System.Drawing.Size(462, 363);
            this.Load += new System.EventHandler(this.UCListView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The pan main
        /// </summary>
        private System.Windows.Forms.FlowLayoutPanel panMain;
        /// <summary>
        /// The pan page
        /// </summary>
        private System.Windows.Forms.Panel panPage;
    }
}
