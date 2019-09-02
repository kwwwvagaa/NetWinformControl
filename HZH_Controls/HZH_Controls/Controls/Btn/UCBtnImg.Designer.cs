namespace HZH_Controls.Controls
{
    partial class UCBtnImg
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
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.Image = global::HZH_Controls.Properties.Resources.back;
            this.lbl.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            // 
            // UCBtnImg
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.IsShowTips = true;
            this.Name = "UCBtnImg";
            this.ResumeLayout(false);

        }

        #endregion

    }
}
