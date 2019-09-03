// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-15-2019
//
// ***********************************************************************
// <copyright file="UCPagerControl2.Designer.cs">
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
    /// Class UCPagerControl2.
    /// Implements the <see cref="HZH_Controls.Controls.UCPagerControlBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.UCPagerControlBase" />
    partial class UCPagerControl2
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
            this.btnFirst = new HZH_Controls.Controls.UCBtnExt();
            this.btnPrevious = new HZH_Controls.Controls.UCBtnExt();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.p9 = new HZH_Controls.Controls.UCBtnExt();
            this.p1 = new HZH_Controls.Controls.UCBtnExt();
            this.btnToPage = new HZH_Controls.Controls.UCBtnExt();
            this.btnEnd = new HZH_Controls.Controls.UCBtnExt();
            this.btnNext = new HZH_Controls.Controls.UCBtnExt();
            this.p8 = new HZH_Controls.Controls.UCBtnExt();
            this.p7 = new HZH_Controls.Controls.UCBtnExt();
            this.p6 = new HZH_Controls.Controls.UCBtnExt();
            this.p5 = new HZH_Controls.Controls.UCBtnExt();
            this.p4 = new HZH_Controls.Controls.UCBtnExt();
            this.p3 = new HZH_Controls.Controls.UCBtnExt();
            this.p2 = new HZH_Controls.Controls.UCBtnExt();
            this.txtPage = new HZH_Controls.Controls.UCTextBoxEx();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.White;
            this.btnFirst.BtnBackColor = System.Drawing.Color.White;
            this.btnFirst.BtnFont = new System.Drawing.Font("微软雅黑", 9F);
            this.btnFirst.BtnForeColor = System.Drawing.Color.Gray;
            this.btnFirst.BtnText = "<<";
            this.btnFirst.ConerRadius = 5;
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFirst.FillColor = System.Drawing.Color.White;
            this.btnFirst.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnFirst.IsRadius = true;
            this.btnFirst.IsShowRect = true;
            this.btnFirst.IsShowTips = false;
            this.btnFirst.Location = new System.Drawing.Point(5, 5);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(5);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnFirst.RectWidth = 1;
            this.btnFirst.Size = new System.Drawing.Size(30, 30);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.TabStop = false;
            this.btnFirst.TipsText = "";
            this.btnFirst.BtnClick += new System.EventHandler(this.btnFirst_BtnClick);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.White;
            this.btnPrevious.BtnBackColor = System.Drawing.Color.White;
            this.btnPrevious.BtnFont = new System.Drawing.Font("微软雅黑", 9F);
            this.btnPrevious.BtnForeColor = System.Drawing.Color.Gray;
            this.btnPrevious.BtnText = "<";
            this.btnPrevious.ConerRadius = 5;
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrevious.FillColor = System.Drawing.Color.White;
            this.btnPrevious.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnPrevious.IsRadius = true;
            this.btnPrevious.IsShowRect = true;
            this.btnPrevious.IsShowTips = false;
            this.btnPrevious.Location = new System.Drawing.Point(45, 5);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(5);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrevious.RectWidth = 1;
            this.btnPrevious.Size = new System.Drawing.Size(30, 30);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.TabStop = false;
            this.btnPrevious.TipsText = "";
            this.btnPrevious.BtnClick += new System.EventHandler(this.btnPrevious_BtnClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel1.ColumnCount = 15;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Controls.Add(this.p9, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.p1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnToPage, 14, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEnd, 12, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNext, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.p8, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.p7, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.p6, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.p5, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.p4, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.p3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.p2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPrevious, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFirst, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPage, 13, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(129, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(662, 40);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // p9
            // 
            this.p9.BackColor = System.Drawing.Color.White;
            this.p9.BtnBackColor = System.Drawing.Color.White;
            this.p9.BtnFont = new System.Drawing.Font("微软雅黑", 9F);
            this.p9.BtnForeColor = System.Drawing.Color.Gray;
            this.p9.BtnText = "9";
            this.p9.ConerRadius = 5;
            this.p9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p9.FillColor = System.Drawing.Color.White;
            this.p9.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p9.IsRadius = true;
            this.p9.IsShowRect = true;
            this.p9.IsShowTips = false;
            this.p9.Location = new System.Drawing.Point(402, 5);
            this.p9.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p9.Name = "p9";
            this.p9.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.p9.RectWidth = 1;
            this.p9.Size = new System.Drawing.Size(36, 30);
            this.p9.TabIndex = 17;
            this.p9.TabStop = false;
            this.p9.TipsText = "";
            this.p9.BtnClick += new System.EventHandler(this.page_BtnClick);
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.White;
            this.p1.BtnBackColor = System.Drawing.Color.White;
            this.p1.BtnFont = new System.Drawing.Font("微软雅黑", 9F);
            this.p1.BtnForeColor = System.Drawing.Color.Gray;
            this.p1.BtnText = "1";
            this.p1.ConerRadius = 5;
            this.p1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p1.FillColor = System.Drawing.Color.White;
            this.p1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p1.IsRadius = true;
            this.p1.IsShowRect = true;
            this.p1.IsShowTips = false;
            this.p1.Location = new System.Drawing.Point(82, 5);
            this.p1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p1.Name = "p1";
            this.p1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.p1.RectWidth = 1;
            this.p1.Size = new System.Drawing.Size(36, 30);
            this.p1.TabIndex = 16;
            this.p1.TabStop = false;
            this.p1.TipsText = "";
            this.p1.BtnClick += new System.EventHandler(this.page_BtnClick);
            // 
            // btnToPage
            // 
            this.btnToPage.BackColor = System.Drawing.Color.White;
            this.btnToPage.BtnBackColor = System.Drawing.Color.White;
            this.btnToPage.BtnFont = new System.Drawing.Font("微软雅黑", 11F);
            this.btnToPage.BtnForeColor = System.Drawing.Color.Gray;
            this.btnToPage.BtnText = "跳转";
            this.btnToPage.ConerRadius = 5;
            this.btnToPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToPage.FillColor = System.Drawing.Color.White;
            this.btnToPage.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnToPage.IsRadius = true;
            this.btnToPage.IsShowRect = true;
            this.btnToPage.IsShowTips = false;
            this.btnToPage.Location = new System.Drawing.Point(595, 5);
            this.btnToPage.Margin = new System.Windows.Forms.Padding(5);
            this.btnToPage.Name = "btnToPage";
            this.btnToPage.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnToPage.RectWidth = 1;
            this.btnToPage.Size = new System.Drawing.Size(62, 30);
            this.btnToPage.TabIndex = 15;
            this.btnToPage.TabStop = false;
            this.btnToPage.TipsText = "";
            this.btnToPage.BtnClick += new System.EventHandler(this.btnToPage_BtnClick);
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.White;
            this.btnEnd.BtnBackColor = System.Drawing.Color.White;
            this.btnEnd.BtnFont = new System.Drawing.Font("微软雅黑", 9F);
            this.btnEnd.BtnForeColor = System.Drawing.Color.Gray;
            this.btnEnd.BtnText = ">>";
            this.btnEnd.ConerRadius = 5;
            this.btnEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnd.FillColor = System.Drawing.Color.White;
            this.btnEnd.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnEnd.IsRadius = true;
            this.btnEnd.IsShowRect = true;
            this.btnEnd.IsShowTips = false;
            this.btnEnd.Location = new System.Drawing.Point(485, 5);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(5);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnEnd.RectWidth = 1;
            this.btnEnd.Size = new System.Drawing.Size(30, 30);
            this.btnEnd.TabIndex = 13;
            this.btnEnd.TabStop = false;
            this.btnEnd.TipsText = "";
            this.btnEnd.BtnClick += new System.EventHandler(this.btnEnd_BtnClick);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.BtnBackColor = System.Drawing.Color.White;
            this.btnNext.BtnFont = new System.Drawing.Font("微软雅黑", 9F);
            this.btnNext.BtnForeColor = System.Drawing.Color.Gray;
            this.btnNext.BtnText = ">";
            this.btnNext.ConerRadius = 5;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNext.FillColor = System.Drawing.Color.White;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnNext.IsRadius = true;
            this.btnNext.IsShowRect = true;
            this.btnNext.IsShowTips = false;
            this.btnNext.Location = new System.Drawing.Point(445, 5);
            this.btnNext.Margin = new System.Windows.Forms.Padding(5);
            this.btnNext.Name = "btnNext";
            this.btnNext.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnNext.RectWidth = 1;
            this.btnNext.Size = new System.Drawing.Size(30, 30);
            this.btnNext.TabIndex = 12;
            this.btnNext.TabStop = false;
            this.btnNext.TipsText = "";
            this.btnNext.BtnClick += new System.EventHandler(this.btnNext_BtnClick);
            // 
            // p8
            // 
            this.p8.BackColor = System.Drawing.Color.White;
            this.p8.BtnBackColor = System.Drawing.Color.White;
            this.p8.BtnFont = new System.Drawing.Font("微软雅黑", 9F);
            this.p8.BtnForeColor = System.Drawing.Color.Gray;
            this.p8.BtnText = "8";
            this.p8.ConerRadius = 5;
            this.p8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p8.FillColor = System.Drawing.Color.White;
            this.p8.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p8.IsRadius = true;
            this.p8.IsShowRect = true;
            this.p8.IsShowTips = false;
            this.p8.Location = new System.Drawing.Point(362, 5);
            this.p8.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p8.Name = "p8";
            this.p8.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.p8.RectWidth = 1;
            this.p8.Size = new System.Drawing.Size(36, 30);
            this.p8.TabIndex = 8;
            this.p8.TabStop = false;
            this.p8.TipsText = "";
            this.p8.BtnClick += new System.EventHandler(this.page_BtnClick);
            // 
            // p7
            // 
            this.p7.BackColor = System.Drawing.Color.White;
            this.p7.BtnBackColor = System.Drawing.Color.White;
            this.p7.BtnFont = new System.Drawing.Font("微软雅黑", 9F);
            this.p7.BtnForeColor = System.Drawing.Color.Gray;
            this.p7.BtnText = "7";
            this.p7.ConerRadius = 5;
            this.p7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p7.FillColor = System.Drawing.Color.White;
            this.p7.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p7.IsRadius = true;
            this.p7.IsShowRect = true;
            this.p7.IsShowTips = false;
            this.p7.Location = new System.Drawing.Point(322, 5);
            this.p7.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p7.Name = "p7";
            this.p7.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.p7.RectWidth = 1;
            this.p7.Size = new System.Drawing.Size(36, 30);
            this.p7.TabIndex = 7;
            this.p7.TabStop = false;
            this.p7.TipsText = "";
            this.p7.BtnClick += new System.EventHandler(this.page_BtnClick);
            // 
            // p6
            // 
            this.p6.BackColor = System.Drawing.Color.White;
            this.p6.BtnBackColor = System.Drawing.Color.White;
            this.p6.BtnFont = new System.Drawing.Font("微软雅黑", 9F);
            this.p6.BtnForeColor = System.Drawing.Color.Gray;
            this.p6.BtnText = "6";
            this.p6.ConerRadius = 5;
            this.p6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p6.FillColor = System.Drawing.Color.White;
            this.p6.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p6.IsRadius = true;
            this.p6.IsShowRect = true;
            this.p6.IsShowTips = false;
            this.p6.Location = new System.Drawing.Point(282, 5);
            this.p6.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p6.Name = "p6";
            this.p6.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.p6.RectWidth = 1;
            this.p6.Size = new System.Drawing.Size(36, 30);
            this.p6.TabIndex = 6;
            this.p6.TabStop = false;
            this.p6.TipsText = "";
            this.p6.BtnClick += new System.EventHandler(this.page_BtnClick);
            // 
            // p5
            // 
            this.p5.BackColor = System.Drawing.Color.White;
            this.p5.BtnBackColor = System.Drawing.Color.White;
            this.p5.BtnFont = new System.Drawing.Font("微软雅黑", 9F);
            this.p5.BtnForeColor = System.Drawing.Color.Gray;
            this.p5.BtnText = "5";
            this.p5.ConerRadius = 5;
            this.p5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p5.FillColor = System.Drawing.Color.White;
            this.p5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p5.IsRadius = true;
            this.p5.IsShowRect = true;
            this.p5.IsShowTips = false;
            this.p5.Location = new System.Drawing.Point(242, 5);
            this.p5.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p5.Name = "p5";
            this.p5.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.p5.RectWidth = 1;
            this.p5.Size = new System.Drawing.Size(36, 30);
            this.p5.TabIndex = 5;
            this.p5.TabStop = false;
            this.p5.TipsText = "";
            this.p5.BtnClick += new System.EventHandler(this.page_BtnClick);
            // 
            // p4
            // 
            this.p4.BackColor = System.Drawing.Color.White;
            this.p4.BtnBackColor = System.Drawing.Color.White;
            this.p4.BtnFont = new System.Drawing.Font("微软雅黑", 9F);
            this.p4.BtnForeColor = System.Drawing.Color.Gray;
            this.p4.BtnText = "4";
            this.p4.ConerRadius = 5;
            this.p4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p4.FillColor = System.Drawing.Color.White;
            this.p4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p4.IsRadius = true;
            this.p4.IsShowRect = true;
            this.p4.IsShowTips = false;
            this.p4.Location = new System.Drawing.Point(202, 5);
            this.p4.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p4.Name = "p4";
            this.p4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.p4.RectWidth = 1;
            this.p4.Size = new System.Drawing.Size(36, 30);
            this.p4.TabIndex = 4;
            this.p4.TabStop = false;
            this.p4.TipsText = "";
            this.p4.BtnClick += new System.EventHandler(this.page_BtnClick);
            // 
            // p3
            // 
            this.p3.BackColor = System.Drawing.Color.White;
            this.p3.BtnBackColor = System.Drawing.Color.White;
            this.p3.BtnFont = new System.Drawing.Font("微软雅黑", 9F);
            this.p3.BtnForeColor = System.Drawing.Color.Gray;
            this.p3.BtnText = "3";
            this.p3.ConerRadius = 5;
            this.p3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p3.FillColor = System.Drawing.Color.White;
            this.p3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p3.IsRadius = true;
            this.p3.IsShowRect = true;
            this.p3.IsShowTips = false;
            this.p3.Location = new System.Drawing.Point(162, 5);
            this.p3.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p3.Name = "p3";
            this.p3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.p3.RectWidth = 1;
            this.p3.Size = new System.Drawing.Size(36, 30);
            this.p3.TabIndex = 3;
            this.p3.TabStop = false;
            this.p3.TipsText = "";
            this.p3.BtnClick += new System.EventHandler(this.page_BtnClick);
            // 
            // p2
            // 
            this.p2.BackColor = System.Drawing.Color.White;
            this.p2.BtnBackColor = System.Drawing.Color.White;
            this.p2.BtnFont = new System.Drawing.Font("微软雅黑", 9F);
            this.p2.BtnForeColor = System.Drawing.Color.Gray;
            this.p2.BtnText = "2";
            this.p2.ConerRadius = 5;
            this.p2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p2.FillColor = System.Drawing.Color.White;
            this.p2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p2.IsRadius = true;
            this.p2.IsShowRect = true;
            this.p2.IsShowTips = false;
            this.p2.Location = new System.Drawing.Point(122, 5);
            this.p2.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.p2.Name = "p2";
            this.p2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.p2.RectWidth = 1;
            this.p2.Size = new System.Drawing.Size(36, 30);
            this.p2.TabIndex = 2;
            this.p2.TabStop = false;
            this.p2.TipsText = "";
            this.p2.BtnClick += new System.EventHandler(this.page_BtnClick);
            // 
            // txtPage
            // 
            this.txtPage.BackColor = System.Drawing.Color.Transparent;
            this.txtPage.ConerRadius = 5;
            this.txtPage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPage.DecLength = 2;
            this.txtPage.FillColor = System.Drawing.Color.Empty;
            this.txtPage.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPage.ForeColor = System.Drawing.Color.Gray;
            this.txtPage.InputText = "";
            this.txtPage.InputType = HZH_Controls.TextInputType.PositiveInteger;
            this.txtPage.IsFocusColor = true;
            this.txtPage.IsRadius = true;
            this.txtPage.IsShowClearBtn = false;
            this.txtPage.IsShowKeyboard = false;
            this.txtPage.IsShowRect = true;
            this.txtPage.IsShowSearchBtn = false;
            this.txtPage.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.txtPage.Location = new System.Drawing.Point(524, 5);
            this.txtPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPage.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtPage.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.txtPage.Name = "txtPage";
            this.txtPage.Padding = new System.Windows.Forms.Padding(5);
            this.txtPage.PromptColor = System.Drawing.Color.Silver;
            this.txtPage.PromptFont = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPage.PromptText = "页码";
            this.txtPage.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtPage.RectWidth = 1;
            this.txtPage.RegexPattern = "";
            this.txtPage.Size = new System.Drawing.Size(62, 30);
            this.txtPage.TabIndex = 14;
            // 
            // UCPagerControl2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCPagerControl2";
            this.Size = new System.Drawing.Size(921, 41);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The BTN first
        /// </summary>
        private UCBtnExt btnFirst;
        /// <summary>
        /// The BTN previous
        /// </summary>
        private UCBtnExt btnPrevious;
        /// <summary>
        /// The table layout panel1
        /// </summary>
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        /// <summary>
        /// The BTN end
        /// </summary>
        private UCBtnExt btnEnd;
        /// <summary>
        /// The BTN next
        /// </summary>
        private UCBtnExt btnNext;
        /// <summary>
        /// The p8
        /// </summary>
        private UCBtnExt p8;
        /// <summary>
        /// The p7
        /// </summary>
        private UCBtnExt p7;
        /// <summary>
        /// The p6
        /// </summary>
        private UCBtnExt p6;
        /// <summary>
        /// The p5
        /// </summary>
        private UCBtnExt p5;
        /// <summary>
        /// The p4
        /// </summary>
        private UCBtnExt p4;
        /// <summary>
        /// The p3
        /// </summary>
        private UCBtnExt p3;
        /// <summary>
        /// The p2
        /// </summary>
        private UCBtnExt p2;
        /// <summary>
        /// The BTN to page
        /// </summary>
        private UCBtnExt btnToPage;
        /// <summary>
        /// The text page
        /// </summary>
        private UCTextBoxEx txtPage;
        /// <summary>
        /// The p9
        /// </summary>
        private UCBtnExt p9;
        /// <summary>
        /// The p1
        /// </summary>
        private UCBtnExt p1;
    }
}
