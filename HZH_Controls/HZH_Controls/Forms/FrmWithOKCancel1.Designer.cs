// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="FrmWithOKCancel1.Designer.cs">
//     Copyright by Huang Zhenghui(黄正辉) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub：https://github.com/kwwwvagaa/NetWinformControl
// gitee：https://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
namespace HZH_Controls.Forms
{
    /// <summary>
    /// Class FrmWithOKCancel1.
    /// Implements the <see cref="HZH_Controls.Forms.FrmWithTitle" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Forms.FrmWithTitle" />
    partial class FrmWithOKCancel1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWithOKCancel1));
            this.btnOK = new HZH_Controls.Controls.UCBtnExt();
            this.btnCancel = new HZH_Controls.Controls.UCBtnExt();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ucSplitLine_V1 = new HZH_Controls.Controls.UCSplitLine_V();
            this.ucSplitLine_H2 = new HZH_Controls.Controls.UCSplitLine_H();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BtnBackColor = System.Drawing.Color.Transparent;
            this.btnOK.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(51)))));
            this.btnOK.BtnText = "确定";
            this.btnOK.ConerRadius = 5;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.FillColor = System.Drawing.Color.White;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnOK.IsRadius = false;
            this.btnOK.IsShowRect = false;
            this.btnOK.IsShowTips = false;
            this.btnOK.Location = new System.Drawing.Point(0, 0);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnOK.RectWidth = 1;
            this.btnOK.Size = new System.Drawing.Size(213, 62);
            this.btnOK.TabIndex = 0;
            this.btnOK.TabStop = false;
            this.btnOK.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnOK.TipsText = "";
            this.btnOK.BtnClick += new System.EventHandler(this.btnOK_BtnClick);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BtnBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            this.btnCancel.BtnText = "取消";
            this.btnCancel.ConerRadius = 5;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnCancel.IsRadius = false;
            this.btnCancel.IsShowRect = false;
            this.btnCancel.IsShowTips = false;
            this.btnCancel.Location = new System.Drawing.Point(214, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnCancel.RectWidth = 1;
            this.btnCancel.Size = new System.Drawing.Size(213, 62);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnCancel.TipsText = "";
            this.btnCancel.BtnClick += new System.EventHandler(this.btnCancel_BtnClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(427, 186);
            this.panel3.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ucSplitLine_V1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 248);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(427, 62);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // ucSplitLine_V1
            // 
            this.ucSplitLine_V1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ucSplitLine_V1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSplitLine_V1.Location = new System.Drawing.Point(213, 15);
            this.ucSplitLine_V1.Margin = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.ucSplitLine_V1.Name = "ucSplitLine_V1";
            this.ucSplitLine_V1.Size = new System.Drawing.Size(1, 32);
            this.ucSplitLine_V1.TabIndex = 0;
            this.ucSplitLine_V1.TabStop = false;
            // 
            // ucSplitLine_H2
            // 
            this.ucSplitLine_H2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ucSplitLine_H2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucSplitLine_H2.Location = new System.Drawing.Point(0, 247);
            this.ucSplitLine_H2.Name = "ucSplitLine_H2";
            this.ucSplitLine_H2.Size = new System.Drawing.Size(427, 1);
            this.ucSplitLine_H2.TabIndex = 0;
            this.ucSplitLine_H2.TabStop = false;
            // 
            // FrmWithOKCancel1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(427, 310);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ucSplitLine_H2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmWithOKCancel1";
            this.Text = "FrmWithOKCancel";
            this.VisibleChanged += new System.EventHandler(this.FrmWithOKCancel1_VisibleChanged);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.ucSplitLine_H2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The BTN ok
        /// </summary>
        private Controls.UCBtnExt btnOK;
        /// <summary>
        /// The BTN cancel
        /// </summary>
        private Controls.UCBtnExt btnCancel;
        /// <summary>
        /// The panel3
        /// </summary>
        public System.Windows.Forms.Panel panel3;
        /// <summary>
        /// The table layout panel1
        /// </summary>
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        /// <summary>
        /// The uc split line h2
        /// </summary>
        private Controls.UCSplitLine_H ucSplitLine_H2;
        /// <summary>
        /// The uc split line v1
        /// </summary>
        private Controls.UCSplitLine_V ucSplitLine_V1;

    }
}