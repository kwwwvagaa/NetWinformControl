namespace HZH_Controls.Controls
{
    partial class UCNumTextBox
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
            this.txtNum = new HZH_Controls.Controls.TextBoxEx();
            this.btnMinus = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtNum
            // 
            this.txtNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.txtNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNum.DecLength = 3;
            this.txtNum.Font = new System.Drawing.Font("Arial Unicode MS", 15F);
            this.txtNum.InputType = TextInputType.Number;
            this.txtNum.Location = new System.Drawing.Point(37, 11);
            this.txtNum.Margin = new System.Windows.Forms.Padding(0);
            this.txtNum.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtNum.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNum.MyRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtNum.Name = "txtNum";
            this.txtNum.OldText = null;
            this.txtNum.PromptColor = System.Drawing.Color.Gray;
            this.txtNum.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtNum.PromptText = "";
            this.txtNum.RegexPattern = "";
            this.txtNum.Size = new System.Drawing.Size(78, 27);
            this.txtNum.TabIndex = 9;
            this.txtNum.Text = "1";
            this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNum.FontChanged += new System.EventHandler(this.txtNum_FontChanged);
            this.txtNum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtNum_MouseDown);
            // 
            // btnMinus
            // 
            this.btnMinus.BackColor = System.Drawing.Color.Transparent;
            this.btnMinus.BackgroundImage = global::HZH_Controls.Properties.Resources.ic_remove_black_18dp;
            this.btnMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMinus.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMinus.Location = new System.Drawing.Point(2, 2);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(32, 40);
            this.btnMinus.TabIndex = 6;
            this.btnMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMinus_MouseDown);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BackgroundImage = global::HZH_Controls.Properties.Resources.ic_add_black_18dp;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd.Location = new System.Drawing.Point(118, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 40);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAdd_MouseDown);
            // 
            // UCNumTextBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnAdd);
            this.Name = "UCNumTextBox";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(152, 44);
            this.Load += new System.EventHandler(this.UCNumTextBox_Load);
            this.BackColorChanged += new System.EventHandler(this.UCNumTextBox_BackColorChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel btnAdd;
        private System.Windows.Forms.Panel btnMinus;
        private TextBoxEx txtNum;
    }
}
