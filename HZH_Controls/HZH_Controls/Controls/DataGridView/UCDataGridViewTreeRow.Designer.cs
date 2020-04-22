// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-23-2019
//
// ***********************************************************************
// <copyright file="UCDataGridViewTreeRow.Designer.cs">
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
    /// Class UCDataGridViewTreeRow.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    partial class UCDataGridViewTreeRow
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
            this.panCells = new System.Windows.Forms.TableLayoutPanel();
            this.panLeft = new System.Windows.Forms.Panel();
            this.panMain = new System.Windows.Forms.Panel();
            this.ucSplitLine_H1 = new HZH_Controls.Controls.UCSplitLine_H();
            this.ucSplitLine_V1 = new HZH_Controls.Controls.UCSplitLine_V();
            this.panMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panCells
            // 
            this.panCells.ColumnCount = 1;
            this.panCells.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panCells.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panCells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panCells.Location = new System.Drawing.Point(24, 0);
            this.panCells.Name = "panCells";
            this.panCells.RowCount = 1;
            this.panCells.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panCells.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.panCells.Size = new System.Drawing.Size(636, 64);
            this.panCells.TabIndex = 2;
            // 
            // panLeft
            // 
            this.panLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panLeft.Location = new System.Drawing.Point(0, 0);
            this.panLeft.Name = "panLeft";
            this.panLeft.Size = new System.Drawing.Size(24, 64);
            this.panLeft.TabIndex = 0;
            this.panLeft.Tag = "0";
            this.panLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panLeft_MouseDown);
            // 
            // panMain
            // 
            this.panMain.Controls.Add(this.panCells);
            this.panMain.Controls.Add(this.panLeft);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(1, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(660, 64);
            this.panMain.TabIndex = 0;
            // 
            // ucSplitLine_H1
            // 
            this.ucSplitLine_H1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ucSplitLine_H1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucSplitLine_H1.Location = new System.Drawing.Point(1, 64);
            this.ucSplitLine_H1.Name = "ucSplitLine_H1";
            this.ucSplitLine_H1.Size = new System.Drawing.Size(660, 1);
            this.ucSplitLine_H1.TabIndex = 1;
            this.ucSplitLine_H1.TabStop = false;
            // 
            // ucSplitLine_V1
            // 
            this.ucSplitLine_V1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ucSplitLine_V1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucSplitLine_V1.Location = new System.Drawing.Point(0, 0);
            this.ucSplitLine_V1.Name = "ucSplitLine_V1";
            this.ucSplitLine_V1.Size = new System.Drawing.Size(1, 65);
            this.ucSplitLine_V1.TabIndex = 0;
            this.ucSplitLine_V1.TabStop = false;
            this.ucSplitLine_V1.Visible = false;
            // 
            // UCDataGridViewTreeRow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.ucSplitLine_H1);
            this.Controls.Add(this.ucSplitLine_V1);
            this.Name = "UCDataGridViewTreeRow";
            this.Size = new System.Drawing.Size(661, 65);
            this.panMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The pan cells
        /// </summary>
        private System.Windows.Forms.TableLayoutPanel panCells;
        /// <summary>
        /// The uc split line h1
        /// </summary>
        private UCSplitLine_H ucSplitLine_H1;
        /// <summary>
        /// The pan left
        /// </summary>
        private System.Windows.Forms.Panel panLeft;
        /// <summary>
        /// The pan main
        /// </summary>
        private System.Windows.Forms.Panel panMain;
        private UCSplitLine_V ucSplitLine_V1;
    }
}
