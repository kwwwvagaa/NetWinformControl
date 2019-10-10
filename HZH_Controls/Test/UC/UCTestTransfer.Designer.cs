namespace Test.UC
{
    partial class UCTestTransfer
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
            this.ucTransfer1 = new HZH_Controls.Controls.UCTransfer();
            this.SuspendLayout();
            // 
            // ucTransfer1
            // 
            this.ucTransfer1.BackColor = System.Drawing.Color.White;
            this.ucTransfer1.LeftColumns = new HZH_Controls.Controls.DataGridViewColumnEntity[0];
            this.ucTransfer1.LeftDataSource = new object[0];
            this.ucTransfer1.Location = new System.Drawing.Point(22, 22);
            this.ucTransfer1.Name = "ucTransfer1";
            this.ucTransfer1.RightDataSource = new object[0];
            this.ucTransfer1.Size = new System.Drawing.Size(451, 397);
            this.ucTransfer1.TabIndex = 0;
            // 
            // UCTestTransfer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucTransfer1);
            this.Name = "UCTestTransfer";
            this.Size = new System.Drawing.Size(619, 573);
            this.Load += new System.EventHandler(this.UCTestTransfer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCTransfer ucTransfer1;
    }
}
