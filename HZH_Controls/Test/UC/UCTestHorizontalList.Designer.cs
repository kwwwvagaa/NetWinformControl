namespace Test.UC
{
    partial class UCTestHorizontalList
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
            this.ucHorizontalList1 = new HZH_Controls.Controls.UCHorizontalList();
            this.ucHorizontalList2 = new HZH_Controls.Controls.UCHorizontalList();
            this.SuspendLayout();
            // 
            // ucHorizontalList1
            // 
            this.ucHorizontalList1.DataSource = null;
            this.ucHorizontalList1.IsAutoSelectFirst = true;
            this.ucHorizontalList1.Location = new System.Drawing.Point(24, 32);
            this.ucHorizontalList1.Name = "ucHorizontalList1";
            this.ucHorizontalList1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucHorizontalList1.SelectedItem = null;
            this.ucHorizontalList1.Size = new System.Drawing.Size(473, 53);
            this.ucHorizontalList1.TabIndex = 1;
            // 
            // ucHorizontalList2
            // 
            this.ucHorizontalList2.DataSource = null;
            this.ucHorizontalList2.IsAutoSelectFirst = true;
            this.ucHorizontalList2.Location = new System.Drawing.Point(24, 125);
            this.ucHorizontalList2.Name = "ucHorizontalList2";
            this.ucHorizontalList2.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ucHorizontalList2.SelectedItem = null;
            this.ucHorizontalList2.Size = new System.Drawing.Size(473, 53);
            this.ucHorizontalList2.TabIndex = 1;
            // 
            // UCTestHorizontalList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucHorizontalList2);
            this.Controls.Add(this.ucHorizontalList1);
            this.Name = "UCTestHorizontalList";
            this.Size = new System.Drawing.Size(817, 347);
            this.Load += new System.EventHandler(this.UCTestHorizontalList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCHorizontalList ucHorizontalList1;
        private HZH_Controls.Controls.UCHorizontalList ucHorizontalList2;
    }
}
