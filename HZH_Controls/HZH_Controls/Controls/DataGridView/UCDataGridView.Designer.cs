namespace HZH_Controls.Controls
{
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
            this.ucSplitLine_H1 = new HZH_Controls.Controls.UCSplitLine_H();
            this.panRow = new System.Windows.Forms.Panel();
            this.panPage = new System.Windows.Forms.Panel();
            this.panHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // panHead
            // 
            this.panHead.Controls.Add(this.panColumns);
            this.panHead.Controls.Add(this.ucSplitLine_H1);
            this.panHead.Dock = System.Windows.Forms.DockStyle.Top;
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
            // panRow
            // 
            this.panRow.AutoScroll = true;
            this.panRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRow.Location = new System.Drawing.Point(0, 40);
            this.panRow.Name = "panRow";
            this.panRow.Size = new System.Drawing.Size(1061, 481);
            this.panRow.TabIndex = 1;
            // 
            // panPage
            // 
            this.panPage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panPage.Location = new System.Drawing.Point(0, 521);
            this.panPage.Name = "panPage";
            this.panPage.Size = new System.Drawing.Size(1061, 44);
            this.panPage.TabIndex = 0;
            this.panPage.Visible = false;
            // 
            // UCDataGridView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panRow);
            this.Controls.Add(this.panPage);
            this.Controls.Add(this.panHead);
            this.Name = "UCDataGridView";
            this.Size = new System.Drawing.Size(1061, 565);
            this.Resize += new System.EventHandler(this.UCDataGridView_Resize);
            this.panHead.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panHead;
        private System.Windows.Forms.TableLayoutPanel panColumns;
        private UCSplitLine_H ucSplitLine_H1;
        private System.Windows.Forms.Panel panRow;
        private System.Windows.Forms.Panel panPage;

    }
}
