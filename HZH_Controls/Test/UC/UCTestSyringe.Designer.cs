namespace Test.UC
{
    partial class UCTestSyringe
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
            this.ucSyringe_Horizontal2 = new HZH_Controls.Controls.FactoryControls.Syringe.UCSyringe_Horizontal();
            this.ucSyringe_Horizontal1 = new HZH_Controls.Controls.FactoryControls.Syringe.UCSyringe_Horizontal();
            this.ucSyringe1 = new HZH_Controls.Controls.UCSyringe();
            this.SuspendLayout();
            // 
            // ucSyringe_Horizontal2
            // 
            this.ucSyringe_Horizontal2.Animation = true;
            this.ucSyringe_Horizontal2.BackColor = System.Drawing.Color.Transparent;
            this.ucSyringe_Horizontal2.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ucSyringe_Horizontal2.LeftOrRight = false;
            this.ucSyringe_Horizontal2.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(206)))), ((int)(((byte)(235)))));
            this.ucSyringe_Horizontal2.Location = new System.Drawing.Point(224, 265);
            this.ucSyringe_Horizontal2.MoveValue = 40;
            this.ucSyringe_Horizontal2.Name = "ucSyringe_Horizontal2";
            this.ucSyringe_Horizontal2.Size = new System.Drawing.Size(322, 67);
            this.ucSyringe_Horizontal2.SplitMove = 10;
            this.ucSyringe_Horizontal2.SplitTime = 100;
            this.ucSyringe_Horizontal2.SubjectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ucSyringe_Horizontal2.TabIndex = 1;
            // 
            // ucSyringe_Horizontal1
            // 
            this.ucSyringe_Horizontal1.Animation = true;
            this.ucSyringe_Horizontal1.BackColor = System.Drawing.Color.Transparent;
            this.ucSyringe_Horizontal1.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ucSyringe_Horizontal1.LeftOrRight = true;
            this.ucSyringe_Horizontal1.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(206)))), ((int)(((byte)(235)))));
            this.ucSyringe_Horizontal1.Location = new System.Drawing.Point(224, 103);
            this.ucSyringe_Horizontal1.MoveValue = 40;
            this.ucSyringe_Horizontal1.Name = "ucSyringe_Horizontal1";
            this.ucSyringe_Horizontal1.Size = new System.Drawing.Size(322, 67);
            this.ucSyringe_Horizontal1.SplitMove = 10;
            this.ucSyringe_Horizontal1.SplitTime = 100;
            this.ucSyringe_Horizontal1.SubjectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ucSyringe_Horizontal1.TabIndex = 1;
            // 
            // ucSyringe1
            // 
            this.ucSyringe1.Animation = true;
            this.ucSyringe1.BackColor = System.Drawing.Color.Transparent;
            this.ucSyringe1.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ucSyringe1.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(206)))), ((int)(((byte)(235)))));
            this.ucSyringe1.Location = new System.Drawing.Point(67, 74);
            this.ucSyringe1.MinimumSize = new System.Drawing.Size(0, 100);
            this.ucSyringe1.MoveValue = 80;
            this.ucSyringe1.Name = "ucSyringe1";
            this.ucSyringe1.Size = new System.Drawing.Size(76, 290);
            this.ucSyringe1.SplitMove = 10;
            this.ucSyringe1.SplitTime = 100;
            this.ucSyringe1.SubjectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ucSyringe1.TabIndex = 0;
            // 
            // UCTestSyringe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucSyringe_Horizontal2);
            this.Controls.Add(this.ucSyringe_Horizontal1);
            this.Controls.Add(this.ucSyringe1);
            this.Name = "UCTestSyringe";
            this.Size = new System.Drawing.Size(618, 671);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCSyringe ucSyringe1;
        private HZH_Controls.Controls.FactoryControls.Syringe.UCSyringe_Horizontal ucSyringe_Horizontal1;
        private HZH_Controls.Controls.FactoryControls.Syringe.UCSyringe_Horizontal ucSyringe_Horizontal2;
    }
}
