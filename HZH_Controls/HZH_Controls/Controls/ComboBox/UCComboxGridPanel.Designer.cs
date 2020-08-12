// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-28-2019
//
// ***********************************************************************
// <copyright file="UCComboxGridPanel.Designer.cs">
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
    /// Class UCComboxGridPanel.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    partial class UCComboxGridPanel
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucControlBase1 = new HZH_Controls.Controls.UCControlBase();
            this.ucDataGridView1 = new HZH_Controls.Controls.UCDataGridView();
            this.m_page = new HZH_Controls.Controls.UCPagerControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearch = new HZH_Controls.Controls.UCTextBoxEx();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ucSplitLine_V2 = new HZH_Controls.Controls.UCSplitLine_V();
            this.ucSplitLine_V1 = new HZH_Controls.Controls.UCSplitLine_V();
            this.ucSplitLine_H2 = new HZH_Controls.Controls.UCSplitLine_H();
            this.ucSplitLine_H1 = new HZH_Controls.Controls.UCSplitLine_H();
            this.panel1.SuspendLayout();
            this.ucControlBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucControlBase1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(447, 333);
            this.panel1.TabIndex = 4;
            // 
            // ucControlBase1
            // 
            this.ucControlBase1.ConerRadius = 5;
            this.ucControlBase1.Controls.Add(this.ucDataGridView1);
            this.ucControlBase1.Controls.Add(this.m_page);
            this.ucControlBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucControlBase1.FillColor = System.Drawing.Color.Transparent;
            this.ucControlBase1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucControlBase1.IsRadius = false;
            this.ucControlBase1.IsShowRect = true;
            this.ucControlBase1.Location = new System.Drawing.Point(5, 62);
            this.ucControlBase1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucControlBase1.Name = "ucControlBase1";
            this.ucControlBase1.Padding = new System.Windows.Forms.Padding(5);
            this.ucControlBase1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucControlBase1.RectWidth = 1;
            this.ucControlBase1.Size = new System.Drawing.Size(437, 266);
            this.ucControlBase1.TabIndex = 2;
            this.ucControlBase1.TabStop = false;
            // 
            // ucDataGridView1
            // 
            this.ucDataGridView1.BackColor = System.Drawing.Color.White;
            this.ucDataGridView1.Columns = null;
            this.ucDataGridView1.DataSource = null;
            this.ucDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataGridView1.HeadFont = new System.Drawing.Font("微软雅黑", 12F);
            this.ucDataGridView1.HeadHeight = 40;
            this.ucDataGridView1.HeadPadingLeft = 0;
            this.ucDataGridView1.HeadTextColor = System.Drawing.Color.Black;
            this.ucDataGridView1.IsShowCheckBox = false;
            this.ucDataGridView1.IsShowHead = true;
            this.ucDataGridView1.Location = new System.Drawing.Point(5, 5);
            this.ucDataGridView1.Name = "ucDataGridView1";
            this.ucDataGridView1.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.ucDataGridView1.RowHeight = 30;
            this.ucDataGridView1.RowType = typeof(HZH_Controls.Controls.UCDataGridViewRow);
            this.ucDataGridView1.Size = new System.Drawing.Size(427, 223);
            this.ucDataGridView1.TabIndex = 0;
            this.ucDataGridView1.TabStop = false;
            // 
            // m_page
            // 
            this.m_page.DataSource = null;
            this.m_page.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_page.Location = new System.Drawing.Point(5, 228);
            this.m_page.Name = "m_page";
            this.m_page.PageCount = 0;
            this.m_page.PageIndex = 1;
            this.m_page.PageModel = HZH_Controls.Controls.PageModel.Soure;
            this.m_page.PageSize = 10;
            this.m_page.Size = new System.Drawing.Size(427, 33);
            this.m_page.StartIndex = 0;
            this.m_page.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(437, 15);
            this.panel2.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.ConerRadius = 5;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DecLength = 2;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.FillColor = System.Drawing.Color.Empty;
            this.txtSearch.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.txtSearch.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearch.InputText = "";
            this.txtSearch.InputType = HZH_Controls.TextInputType.NotControl;
            this.txtSearch.IsFocusColor = true;
            this.txtSearch.IsRadius = true;
            this.txtSearch.IsShowClearBtn = true;
            this.txtSearch.IsShowKeyboard = false;
            this.txtSearch.IsShowRect = true;
            this.txtSearch.IsShowSearchBtn = false;
            this.txtSearch.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.txtSearch.Location = new System.Drawing.Point(5, 5);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtSearch.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(5);
            this.txtSearch.PromptColor = System.Drawing.Color.Gray;
            this.txtSearch.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearch.PromptText = "输入内容模糊搜索";
            this.txtSearch.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtSearch.RectWidth = 1;
            this.txtSearch.RegexPattern = "";
            this.txtSearch.Size = new System.Drawing.Size(437, 42);
            this.txtSearch.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucSplitLine_V2
            // 
            this.ucSplitLine_V2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ucSplitLine_V2.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucSplitLine_V2.Location = new System.Drawing.Point(448, 1);
            this.ucSplitLine_V2.Name = "ucSplitLine_V2";
            this.ucSplitLine_V2.Size = new System.Drawing.Size(1, 333);
            this.ucSplitLine_V2.TabIndex = 3;
            this.ucSplitLine_V2.TabStop = false;
            // 
            // ucSplitLine_V1
            // 
            this.ucSplitLine_V1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ucSplitLine_V1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucSplitLine_V1.Location = new System.Drawing.Point(0, 1);
            this.ucSplitLine_V1.Name = "ucSplitLine_V1";
            this.ucSplitLine_V1.Size = new System.Drawing.Size(1, 333);
            this.ucSplitLine_V1.TabIndex = 2;
            this.ucSplitLine_V1.TabStop = false;
            // 
            // ucSplitLine_H2
            // 
            this.ucSplitLine_H2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ucSplitLine_H2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucSplitLine_H2.Location = new System.Drawing.Point(0, 334);
            this.ucSplitLine_H2.Name = "ucSplitLine_H2";
            this.ucSplitLine_H2.Size = new System.Drawing.Size(449, 1);
            this.ucSplitLine_H2.TabIndex = 1;
            this.ucSplitLine_H2.TabStop = false;
            // 
            // ucSplitLine_H1
            // 
            this.ucSplitLine_H1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ucSplitLine_H1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitLine_H1.Location = new System.Drawing.Point(0, 0);
            this.ucSplitLine_H1.Name = "ucSplitLine_H1";
            this.ucSplitLine_H1.Size = new System.Drawing.Size(449, 1);
            this.ucSplitLine_H1.TabIndex = 0;
            this.ucSplitLine_H1.TabStop = false;
            // 
            // UCComboxGridPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucSplitLine_V2);
            this.Controls.Add(this.ucSplitLine_V1);
            this.Controls.Add(this.ucSplitLine_H2);
            this.Controls.Add(this.ucSplitLine_H1);
            this.Name = "UCComboxGridPanel";
            this.Size = new System.Drawing.Size(449, 335);
            this.Load += new System.EventHandler(this.UCComboxGridPanel_Load);
            this.panel1.ResumeLayout(false);
            this.ucControlBase1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The uc split line h1
        /// </summary>
        private UCSplitLine_H ucSplitLine_H1;
        /// <summary>
        /// The uc split line h2
        /// </summary>
        private UCSplitLine_H ucSplitLine_H2;
        /// <summary>
        /// The uc split line v1
        /// </summary>
        private UCSplitLine_V ucSplitLine_V1;
        /// <summary>
        /// The uc split line v2
        /// </summary>
        private UCSplitLine_V ucSplitLine_V2;
        /// <summary>
        /// The panel1
        /// </summary>
        private System.Windows.Forms.Panel panel1;
        /// <summary>
        /// The uc control base1
        /// </summary>
        private UCControlBase ucControlBase1;
        /// <summary>
        /// The uc data grid view1
        /// </summary>
        private UCDataGridView ucDataGridView1;
        /// <summary>
        /// The panel2
        /// </summary>
        private System.Windows.Forms.Panel panel2;
        /// <summary>
        /// The timer1
        /// </summary>
        private System.Windows.Forms.Timer timer1;
        /// <summary>
        /// The text search
        /// </summary>
        private UCTextBoxEx txtSearch;
        private UCPagerControl m_page;
    }
}
