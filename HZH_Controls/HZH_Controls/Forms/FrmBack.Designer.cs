// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="FrmBack.Designer.cs">
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
    /// Class FrmBack.
    /// Implements the <see cref="HZH_Controls.Forms.FrmBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Forms.FrmBase" />
    partial class FrmBack
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBack));
            this.panTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack1 = new HZH_Controls.Controls.UCBtnImg();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ucSplitLine_H1 = new HZH_Controls.Controls.UCSplitLine_H();
            this.panTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.label1);
            this.panTop.Controls.Add(this.btnBack1);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(679, 60);
            this.panTop.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Image = global::HZH_Controls.Properties.Resources.help;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(612, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 60);
            this.label1.TabIndex = 1;
            this.label1.Text = "帮助";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // btnBack1
            // 
            this.btnBack1.BackColor = System.Drawing.Color.Transparent;
            this.btnBack1.BtnBackColor = System.Drawing.Color.Transparent;
            this.btnBack1.BtnFont = new System.Drawing.Font("微软雅黑", 17F);
            this.btnBack1.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnBack1.BtnText = "   自定义按钮";
            this.btnBack1.ConerRadius = 5;
            this.btnBack1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack1.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBack1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnBack1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnBack1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnBack1.Image = ((System.Drawing.Image)(resources.GetObject("btnBack1.Image")));
            this.btnBack1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack1.ImageFontIcons = null;
            this.btnBack1.IsRadius = true;
            this.btnBack1.IsShowRect = true;
            this.btnBack1.IsShowTips = false;
            this.btnBack1.Location = new System.Drawing.Point(0, 0);
            this.btnBack1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack1.Name = "btnBack1";
            this.btnBack1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnBack1.RectWidth = 1;
            this.btnBack1.Size = new System.Drawing.Size(200, 60);
            this.btnBack1.TabIndex = 0;
            this.btnBack1.TabStop = false;
            this.btnBack1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack1.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnBack1.TipsText = "";
            this.btnBack1.BtnClick += new System.EventHandler(this.btnBack1_btnClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "help.png");
            // 
            // ucSplitLine_H1
            // 
            this.ucSplitLine_H1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ucSplitLine_H1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitLine_H1.Location = new System.Drawing.Point(0, 60);
            this.ucSplitLine_H1.MaximumSize = new System.Drawing.Size(0, 1);
            this.ucSplitLine_H1.Name = "ucSplitLine_H1";
            this.ucSplitLine_H1.Size = new System.Drawing.Size(679, 1);
            this.ucSplitLine_H1.TabIndex = 0;
            this.ucSplitLine_H1.TabStop = false;
            // 
            // FrmBack
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(679, 477);
            this.Controls.Add(this.ucSplitLine_H1);
            this.Controls.Add(this.panTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBack";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmTemp1";
            this.panTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The BTN back1
        /// </summary>
        private Controls.UCBtnImg btnBack1;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The image list1
        /// </summary>
        private System.Windows.Forms.ImageList imageList1;
        /// <summary>
        /// The uc split line h1
        /// </summary>
        private Controls.UCSplitLine_H ucSplitLine_H1;
        /// <summary>
        /// The pan top
        /// </summary>
        private System.Windows.Forms.Panel panTop;
    }
}