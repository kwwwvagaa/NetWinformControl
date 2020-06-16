// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-09-2019
//
// ***********************************************************************
// <copyright file="UCDataGridView.Designer.cs">
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
    /// Class UCDataGridView.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    partial class UCDataGridView
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
            this.panHead = new System.Windows.Forms.Panel();
            this.panColumns = new System.Windows.Forms.TableLayoutPanel();
            this.panHeadLeft = new System.Windows.Forms.Panel();
            this.panRow = new System.Windows.Forms.FlowLayoutPanel();
            this.ucSplitLine_H1 = new HZH_Controls.Controls.UCSplitLine_H();
            this.panHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // panHead
            // 
            this.panHead.Controls.Add(this.panColumns);
            this.panHead.Controls.Add(this.panHeadLeft);
            this.panHead.Controls.Add(this.ucSplitLine_H1);
            this.panHead.Location = new System.Drawing.Point(0, 0);
            this.panHead.Name = "panHead";
            this.panHead.Size = new System.Drawing.Size(1061, 40);
            this.panHead.TabIndex = 0;
            // 
            // panColumns
            // 
            this.panColumns.ColumnCount = 1;
            this.panColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panColumns.Location = new System.Drawing.Point(0, 0);
            this.panColumns.Name = "panColumns";
            this.panColumns.RowCount = 1;
            this.panColumns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panColumns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panColumns.Size = new System.Drawing.Size(1061, 39);
            this.panColumns.TabIndex = 1;
            // 
            // panHeadLeft
            // 
            this.panHeadLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panHeadLeft.Location = new System.Drawing.Point(0, 0);
            this.panHeadLeft.Name = "panHeadLeft";
            this.panHeadLeft.Size = new System.Drawing.Size(0, 39);
            this.panHeadLeft.TabIndex = 2;
            // 
            // panRow
            // 
            this.panRow.AutoScroll = true;
            this.panRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRow.Location = new System.Drawing.Point(0, 40);
            this.panRow.Name = "panRow";
            this.panRow.Size = new System.Drawing.Size(317, 225);
            this.panRow.TabIndex = 1;
            this.panRow.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panRow_Scroll);
            // 
            // ucSplitLine_H1
            // 
            this.ucSplitLine_H1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ucSplitLine_H1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucSplitLine_H1.Location = new System.Drawing.Point(0, 39);
            this.ucSplitLine_H1.Name = "ucSplitLine_H1";
            this.ucSplitLine_H1.Size = new System.Drawing.Size(1061, 1);
            this.ucSplitLine_H1.TabIndex = 0;
            this.ucSplitLine_H1.TabStop = false;
            // 
            // UCDataGridView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panRow);
            this.Controls.Add(this.panHead);
            this.Name = "UCDataGridView";
            this.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.Size = new System.Drawing.Size(317, 265);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.UCDataGridView_Scroll);
            this.SizeChanged += new System.EventHandler(this.UCDataGridView_SizeChanged);
            this.panHead.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The pan head
        /// </summary>
        private System.Windows.Forms.Panel panHead;
        /// <summary>
        /// The pan columns
        /// </summary>
        private System.Windows.Forms.TableLayoutPanel panColumns;
        /// <summary>
        /// The uc split line h1
        /// </summary>
        private UCSplitLine_H ucSplitLine_H1;
        /// <summary>
        /// The pan head left
        /// </summary>
        private System.Windows.Forms.Panel panHeadLeft;
        private System.Windows.Forms.FlowLayoutPanel panRow;

    }
}
