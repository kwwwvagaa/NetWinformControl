// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="UCDateTimeSelectPan.Designer.cs">
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
    /// Class UCDateTimeSelectPan.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class UCDateTimeSelectPan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinute = new HZH_Controls.Controls.UCBtnExt();
            this.sp4 = new System.Windows.Forms.Panel();
            this.btnHour = new HZH_Controls.Controls.UCBtnExt();
            this.sp3 = new System.Windows.Forms.Panel();
            this.btnDay = new HZH_Controls.Controls.UCBtnExt();
            this.sp2 = new System.Windows.Forms.Panel();
            this.btnMonth = new HZH_Controls.Controls.UCBtnExt();
            this.sp1 = new System.Windows.Forms.Panel();
            this.btnYear = new HZH_Controls.Controls.UCBtnExt();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new HZH_Controls.Controls.UCBtnExt();
            this.btnOk = new HZH_Controls.Controls.UCBtnExt();
            this.panMian = new System.Windows.Forms.Panel();
            this.panTime = new HZH_Controls.Controls.UCTimePanel();
            this.panRight = new System.Windows.Forms.Panel();
            this.panLeft = new System.Windows.Forms.Panel();
            this.ucSplitLine_H2 = new HZH_Controls.Controls.UCSplitLine_H();
            this.ucSplitLine_H1 = new HZH_Controls.Controls.UCSplitLine_H();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panMian.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMinute);
            this.panel1.Controls.Add(this.sp4);
            this.panel1.Controls.Add(this.btnHour);
            this.panel1.Controls.Add(this.sp3);
            this.panel1.Controls.Add(this.btnDay);
            this.panel1.Controls.Add(this.sp2);
            this.panel1.Controls.Add(this.btnMonth);
            this.panel1.Controls.Add(this.sp1);
            this.panel1.Controls.Add(this.btnYear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.panel1.Size = new System.Drawing.Size(497, 45);
            this.panel1.TabIndex = 0;
            // 
            // btnMinute
            // 
            this.btnMinute.BackColor = System.Drawing.Color.Transparent;
            this.btnMinute.BtnBackColor = System.Drawing.Color.Transparent;
            this.btnMinute.BtnFont = new System.Drawing.Font("微软雅黑", 12F);
            this.btnMinute.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnMinute.BtnText = "30分";
            this.btnMinute.ConerRadius = 5;
            this.btnMinute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinute.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMinute.FillColor = System.Drawing.Color.White;
            this.btnMinute.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnMinute.IsRadius = true;
            this.btnMinute.IsShowRect = true;
            this.btnMinute.IsShowTips = false;
            this.btnMinute.Location = new System.Drawing.Point(406, 7);
            this.btnMinute.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnMinute.Name = "btnMinute";
            this.btnMinute.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnMinute.RectWidth = 1;
            this.btnMinute.Size = new System.Drawing.Size(80, 31);
            this.btnMinute.TabIndex = 1;
            this.btnMinute.TabStop = false;
            this.btnMinute.TipsText = "";
            this.btnMinute.BtnClick += new System.EventHandler(this.btnTime_BtnClick);
            // 
            // sp4
            // 
            this.sp4.Dock = System.Windows.Forms.DockStyle.Left;
            this.sp4.Location = new System.Drawing.Point(387, 7);
            this.sp4.Name = "sp4";
            this.sp4.Size = new System.Drawing.Size(19, 31);
            this.sp4.TabIndex = 5;
            // 
            // btnHour
            // 
            this.btnHour.BackColor = System.Drawing.Color.Transparent;
            this.btnHour.BtnBackColor = System.Drawing.Color.Transparent;
            this.btnHour.BtnFont = new System.Drawing.Font("微软雅黑", 12F);
            this.btnHour.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnHour.BtnText = "12时";
            this.btnHour.ConerRadius = 5;
            this.btnHour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHour.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHour.FillColor = System.Drawing.Color.White;
            this.btnHour.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnHour.IsRadius = true;
            this.btnHour.IsShowRect = true;
            this.btnHour.IsShowTips = false;
            this.btnHour.Location = new System.Drawing.Point(307, 7);
            this.btnHour.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnHour.Name = "btnHour";
            this.btnHour.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnHour.RectWidth = 1;
            this.btnHour.Size = new System.Drawing.Size(80, 31);
            this.btnHour.TabIndex = 1;
            this.btnHour.TabStop = false;
            this.btnHour.TipsText = "";
            this.btnHour.BtnClick += new System.EventHandler(this.btnTime_BtnClick);
            // 
            // sp3
            // 
            this.sp3.Dock = System.Windows.Forms.DockStyle.Left;
            this.sp3.Location = new System.Drawing.Point(288, 7);
            this.sp3.Name = "sp3";
            this.sp3.Size = new System.Drawing.Size(19, 31);
            this.sp3.TabIndex = 4;
            // 
            // btnDay
            // 
            this.btnDay.BackColor = System.Drawing.Color.Transparent;
            this.btnDay.BtnBackColor = System.Drawing.Color.Transparent;
            this.btnDay.BtnFont = new System.Drawing.Font("微软雅黑", 12F);
            this.btnDay.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnDay.BtnText = "30日";
            this.btnDay.ConerRadius = 5;
            this.btnDay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDay.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDay.FillColor = System.Drawing.Color.White;
            this.btnDay.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnDay.IsRadius = true;
            this.btnDay.IsShowRect = true;
            this.btnDay.IsShowTips = false;
            this.btnDay.Location = new System.Drawing.Point(208, 7);
            this.btnDay.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnDay.Name = "btnDay";
            this.btnDay.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnDay.RectWidth = 1;
            this.btnDay.Size = new System.Drawing.Size(80, 31);
            this.btnDay.TabIndex = 1;
            this.btnDay.TabStop = false;
            this.btnDay.TipsText = "";
            this.btnDay.BtnClick += new System.EventHandler(this.btnTime_BtnClick);
            // 
            // sp2
            // 
            this.sp2.Dock = System.Windows.Forms.DockStyle.Left;
            this.sp2.Location = new System.Drawing.Point(189, 7);
            this.sp2.Name = "sp2";
            this.sp2.Size = new System.Drawing.Size(19, 31);
            this.sp2.TabIndex = 3;
            // 
            // btnMonth
            // 
            this.btnMonth.BackColor = System.Drawing.Color.Transparent;
            this.btnMonth.BtnBackColor = System.Drawing.Color.Transparent;
            this.btnMonth.BtnFont = new System.Drawing.Font("微软雅黑", 12F);
            this.btnMonth.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnMonth.BtnText = "12月";
            this.btnMonth.ConerRadius = 5;
            this.btnMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMonth.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMonth.FillColor = System.Drawing.Color.White;
            this.btnMonth.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnMonth.IsRadius = true;
            this.btnMonth.IsShowRect = true;
            this.btnMonth.IsShowTips = false;
            this.btnMonth.Location = new System.Drawing.Point(109, 7);
            this.btnMonth.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnMonth.RectWidth = 1;
            this.btnMonth.Size = new System.Drawing.Size(80, 31);
            this.btnMonth.TabIndex = 1;
            this.btnMonth.TabStop = false;
            this.btnMonth.TipsText = "";
            this.btnMonth.BtnClick += new System.EventHandler(this.btnTime_BtnClick);
            // 
            // sp1
            // 
            this.sp1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sp1.Location = new System.Drawing.Point(90, 7);
            this.sp1.Name = "sp1";
            this.sp1.Size = new System.Drawing.Size(19, 31);
            this.sp1.TabIndex = 2;
            // 
            // btnYear
            // 
            this.btnYear.BackColor = System.Drawing.Color.Transparent;
            this.btnYear.BtnBackColor = System.Drawing.Color.Transparent;
            this.btnYear.BtnFont = new System.Drawing.Font("微软雅黑", 12F);
            this.btnYear.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnYear.BtnText = "2019年";
            this.btnYear.ConerRadius = 5;
            this.btnYear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnYear.FillColor = System.Drawing.Color.White;
            this.btnYear.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnYear.IsRadius = true;
            this.btnYear.IsShowRect = true;
            this.btnYear.IsShowTips = false;
            this.btnYear.Location = new System.Drawing.Point(10, 7);
            this.btnYear.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnYear.Name = "btnYear";
            this.btnYear.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnYear.RectWidth = 1;
            this.btnYear.Size = new System.Drawing.Size(80, 31);
            this.btnYear.TabIndex = 1;
            this.btnYear.TabStop = false;
            this.btnYear.TipsText = "";
            this.btnYear.BtnClick += new System.EventHandler(this.btnTime_BtnClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(9, 300);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(497, 54);
            this.panel2.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BtnBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BtnFont = new System.Drawing.Font("微软雅黑", 13F);
            this.btnCancel.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnCancel.BtnText = "取   消";
            this.btnCancel.ConerRadius = 5;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnCancel.IsRadius = true;
            this.btnCancel.IsShowRect = true;
            this.btnCancel.IsShowTips = false;
            this.btnCancel.Location = new System.Drawing.Point(89, 9);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnCancel.RectWidth = 1;
            this.btnCancel.Size = new System.Drawing.Size(129, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.TipsText = "";
            this.btnCancel.BtnClick += new System.EventHandler(this.btnCancel_BtnClick);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.BtnBackColor = System.Drawing.Color.Transparent;
            this.btnOk.BtnFont = new System.Drawing.Font("微软雅黑", 13F);
            this.btnOk.BtnForeColor = System.Drawing.Color.White;
            this.btnOk.BtnText = "确  定";
            this.btnOk.ConerRadius = 5;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnOk.IsRadius = true;
            this.btnOk.IsShowRect = true;
            this.btnOk.IsShowTips = false;
            this.btnOk.Location = new System.Drawing.Point(307, 9);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnOk.RectWidth = 1;
            this.btnOk.Size = new System.Drawing.Size(129, 36);
            this.btnOk.TabIndex = 1;
            this.btnOk.TabStop = false;
            this.btnOk.TipsText = "";
            this.btnOk.BtnClick += new System.EventHandler(this.btnOk_BtnClick);
            // 
            // panMian
            // 
            this.panMian.Controls.Add(this.panTime);
            this.panMian.Controls.Add(this.panRight);
            this.panMian.Controls.Add(this.panLeft);
            this.panMian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMian.Location = new System.Drawing.Point(9, 55);
            this.panMian.Name = "panMian";
            this.panMian.Size = new System.Drawing.Size(497, 244);
            this.panMian.TabIndex = 4;
            // 
            // panTime
            // 
            this.panTime.BackColor = System.Drawing.Color.White;
            this.panTime.Column = 0;
            this.panTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTime.FirstEvent = false;
            this.panTime.Location = new System.Drawing.Point(48, 0);
            this.panTime.Name = "panTime";
            this.panTime.Row = 0;
            this.panTime.SelectBtn = null;
            this.panTime.Size = new System.Drawing.Size(401, 244);
            this.panTime.Source = null;
            this.panTime.TabIndex = 0;
            // 
            // panRight
            // 
            this.panRight.BackgroundImage = global::HZH_Controls.Properties.Resources.dateRight;
            this.panRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panRight.Location = new System.Drawing.Point(449, 0);
            this.panRight.Name = "panRight";
            this.panRight.Size = new System.Drawing.Size(48, 244);
            this.panRight.TabIndex = 2;
            this.panRight.Visible = false;
            this.panRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panRight_MouseDown);
            // 
            // panLeft
            // 
            this.panLeft.BackgroundImage = global::HZH_Controls.Properties.Resources.datetLeft;
            this.panLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panLeft.Location = new System.Drawing.Point(0, 0);
            this.panLeft.Name = "panLeft";
            this.panLeft.Size = new System.Drawing.Size(48, 244);
            this.panLeft.TabIndex = 1;
            this.panLeft.Visible = false;
            this.panLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panLeft_MouseDown);
            // 
            // ucSplitLine_H2
            // 
            this.ucSplitLine_H2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ucSplitLine_H2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucSplitLine_H2.Location = new System.Drawing.Point(9, 299);
            this.ucSplitLine_H2.Name = "ucSplitLine_H2";
            this.ucSplitLine_H2.Size = new System.Drawing.Size(497, 1);
            this.ucSplitLine_H2.TabIndex = 3;
            this.ucSplitLine_H2.TabStop = false;
            // 
            // ucSplitLine_H1
            // 
            this.ucSplitLine_H1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ucSplitLine_H1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitLine_H1.Location = new System.Drawing.Point(9, 54);
            this.ucSplitLine_H1.Name = "ucSplitLine_H1";
            this.ucSplitLine_H1.Size = new System.Drawing.Size(497, 1);
            this.ucSplitLine_H1.TabIndex = 1;
            this.ucSplitLine_H1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panMian);
            this.panel3.Controls.Add(this.ucSplitLine_H2);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.ucSplitLine_H1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(9);
            this.panel3.Size = new System.Drawing.Size(515, 363);
            this.panel3.TabIndex = 5;
            // 
            // UCDateTimeSelectPan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.panel3);
            this.Name = "UCDateTimeSelectPan";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(517, 365);
            this.Load += new System.EventHandler(this.UCDateTimePickerExt_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panMian.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The panel1
        /// </summary>
        private System.Windows.Forms.Panel panel1;
        /// <summary>
        /// The uc split line h1
        /// </summary>
        private UCSplitLine_H ucSplitLine_H1;
        /// <summary>
        /// The panel2
        /// </summary>
        private System.Windows.Forms.Panel panel2;
        /// <summary>
        /// The uc split line h2
        /// </summary>
        private UCSplitLine_H ucSplitLine_H2;
        /// <summary>
        /// The pan mian
        /// </summary>
        private System.Windows.Forms.Panel panMian;
        /// <summary>
        /// The BTN minute
        /// </summary>
        private UCBtnExt btnMinute;
        /// <summary>
        /// The BTN day
        /// </summary>
        private UCBtnExt btnDay;
        /// <summary>
        /// The BTN hour
        /// </summary>
        private UCBtnExt btnHour;
        /// <summary>
        /// The BTN month
        /// </summary>
        private UCBtnExt btnMonth;
        /// <summary>
        /// The BTN year
        /// </summary>
        private UCBtnExt btnYear;
        /// <summary>
        /// The pan time
        /// </summary>
        private UCTimePanel panTime;
        /// <summary>
        /// The BTN cancel
        /// </summary>
        private UCBtnExt btnCancel;
        /// <summary>
        /// The BTN ok
        /// </summary>
        private UCBtnExt btnOk;
        /// <summary>
        /// The pan right
        /// </summary>
        private System.Windows.Forms.Panel panRight;
        /// <summary>
        /// The pan left
        /// </summary>
        private System.Windows.Forms.Panel panLeft;
        /// <summary>
        /// The SP4
        /// </summary>
        private System.Windows.Forms.Panel sp4;
        /// <summary>
        /// The SP3
        /// </summary>
        private System.Windows.Forms.Panel sp3;
        /// <summary>
        /// The SP2
        /// </summary>
        private System.Windows.Forms.Panel sp2;
        /// <summary>
        /// The SP1
        /// </summary>
        private System.Windows.Forms.Panel sp1;
        /// <summary>
        /// The panel3
        /// </summary>
        private System.Windows.Forms.Panel panel3;

    }
}
