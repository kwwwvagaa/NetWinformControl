// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 09-02-2019
//
// ***********************************************************************
// <copyright file="UCLEDData.Designer.cs">
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
    /// Class UCLEDData.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    partial class UCLEDData
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.D1 = new HZH_Controls.Controls.UCLEDNum();
            this.D2 = new HZH_Controls.Controls.UCLEDNum();
            this.D3 = new HZH_Controls.Controls.UCLEDNum();
            this.D4 = new HZH_Controls.Controls.UCLEDNum();
            this.D5 = new HZH_Controls.Controls.UCLEDNum();
            this.D6 = new HZH_Controls.Controls.UCLEDNum();
            this.D7 = new HZH_Controls.Controls.UCLEDNum();
            this.D8 = new HZH_Controls.Controls.UCLEDNum();
            this.D9 = new HZH_Controls.Controls.UCLEDNum();
            this.D10 = new HZH_Controls.Controls.UCLEDNum();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.D1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.D2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.D3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.D4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.D5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.D6, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.D7, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.D8, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.D9, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.D10, 9, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 58);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // D1
            // 
            this.D1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.D1.LineWidth = 8;
            this.D1.Location = new System.Drawing.Point(3, 3);
            this.D1.Name = "D1";
            this.D1.Size = new System.Drawing.Size(30, 52);
            this.D1.TabIndex = 0;
            this.D1.Value = '2';
            // 
            // D2
            // 
            this.D2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.D2.LineWidth = 8;
            this.D2.Location = new System.Drawing.Point(39, 3);
            this.D2.Name = "D2";
            this.D2.Size = new System.Drawing.Size(30, 52);
            this.D2.TabIndex = 1;
            this.D2.Value = '0';
            // 
            // D3
            // 
            this.D3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.D3.LineWidth = 8;
            this.D3.Location = new System.Drawing.Point(75, 3);
            this.D3.Name = "D3";
            this.D3.Size = new System.Drawing.Size(30, 52);
            this.D3.TabIndex = 2;
            this.D3.Value = '1';
            // 
            // D4
            // 
            this.D4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.D4.LineWidth = 8;
            this.D4.Location = new System.Drawing.Point(111, 3);
            this.D4.Name = "D4";
            this.D4.Size = new System.Drawing.Size(30, 52);
            this.D4.TabIndex = 3;
            this.D4.Value = '9';
            // 
            // D5
            // 
            this.D5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.D5.LineWidth = 8;
            this.D5.Location = new System.Drawing.Point(147, 3);
            this.D5.Name = "D5";
            this.D5.Size = new System.Drawing.Size(30, 52);
            this.D5.TabIndex = 4;
            this.D5.Value = '-';
            // 
            // D6
            // 
            this.D6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.D6.LineWidth = 8;
            this.D6.Location = new System.Drawing.Point(183, 3);
            this.D6.Name = "D6";
            this.D6.Size = new System.Drawing.Size(30, 52);
            this.D6.TabIndex = 5;
            this.D6.Value = '0';
            // 
            // D7
            // 
            this.D7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.D7.LineWidth = 8;
            this.D7.Location = new System.Drawing.Point(219, 3);
            this.D7.Name = "D7";
            this.D7.Size = new System.Drawing.Size(30, 52);
            this.D7.TabIndex = 6;
            this.D7.Value = '8';
            // 
            // D8
            // 
            this.D8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.D8.LineWidth = 8;
            this.D8.Location = new System.Drawing.Point(255, 3);
            this.D8.Name = "D8";
            this.D8.Size = new System.Drawing.Size(30, 52);
            this.D8.TabIndex = 7;
            this.D8.Value = '-';
            // 
            // D9
            // 
            this.D9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.D9.LineWidth = 8;
            this.D9.Location = new System.Drawing.Point(291, 3);
            this.D9.Name = "D9";
            this.D9.Size = new System.Drawing.Size(30, 52);
            this.D9.TabIndex = 8;
            this.D9.Value = '0';
            // 
            // D10
            // 
            this.D10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.D10.LineWidth = 8;
            this.D10.Location = new System.Drawing.Point(327, 3);
            this.D10.Name = "D10";
            this.D10.Size = new System.Drawing.Size(30, 52);
            this.D10.TabIndex = 9;
            this.D10.Value = '1';
            // 
            // UCLEDData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCLEDData";
            this.Size = new System.Drawing.Size(360, 58);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The table layout panel1
        /// </summary>
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        /// <summary>
        /// The d1
        /// </summary>
        private UCLEDNum D1;
        /// <summary>
        /// The d2
        /// </summary>
        private UCLEDNum D2;
        /// <summary>
        /// The d3
        /// </summary>
        private UCLEDNum D3;
        /// <summary>
        /// The d4
        /// </summary>
        private UCLEDNum D4;
        /// <summary>
        /// The d5
        /// </summary>
        private UCLEDNum D5;
        /// <summary>
        /// The d6
        /// </summary>
        private UCLEDNum D6;
        /// <summary>
        /// The d7
        /// </summary>
        private UCLEDNum D7;
        /// <summary>
        /// The d8
        /// </summary>
        private UCLEDNum D8;
        /// <summary>
        /// The d9
        /// </summary>
        private UCLEDNum D9;
        /// <summary>
        /// The D10
        /// </summary>
        private UCLEDNum D10;

    }
}
