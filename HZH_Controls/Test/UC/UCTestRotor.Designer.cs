namespace Test.UC
{
    partial class UCTestRotor
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
            this.ucRotor1 = new HZH_Controls.Controls.UCRotor();
            this.ucRotor2 = new HZH_Controls.Controls.UCRotor();
            this.ucRotor3 = new HZH_Controls.Controls.UCRotor();
            this.SuspendLayout();
            // 
            // ucRotor1
            // 
            this.ucRotor1.Location = new System.Drawing.Point(29, 17);
            this.ucRotor1.Name = "ucRotor1";
            this.ucRotor1.RotorAround = HZH_Controls.Controls.RotorAround.Counterclockwise;
            this.ucRotor1.RotorColor = System.Drawing.Color.Green;
            this.ucRotor1.Size = new System.Drawing.Size(138, 130);
            this.ucRotor1.Speed = 100;
            this.ucRotor1.TabIndex = 0;
            // 
            // ucRotor2
            // 
            this.ucRotor2.Location = new System.Drawing.Point(185, 17);
            this.ucRotor2.Name = "ucRotor2";
            this.ucRotor2.RotorAround = HZH_Controls.Controls.RotorAround.Clockwise;
            this.ucRotor2.RotorColor = System.Drawing.Color.Black;
            this.ucRotor2.Size = new System.Drawing.Size(138, 130);
            this.ucRotor2.Speed = 100;
            this.ucRotor2.TabIndex = 0;
            // 
            // ucRotor3
            // 
            this.ucRotor3.Location = new System.Drawing.Point(361, 17);
            this.ucRotor3.Name = "ucRotor3";
            this.ucRotor3.RotorAround = HZH_Controls.Controls.RotorAround.None;
            this.ucRotor3.RotorColor = System.Drawing.Color.Red;
            this.ucRotor3.Size = new System.Drawing.Size(138, 130);
            this.ucRotor3.Speed = 100;
            this.ucRotor3.TabIndex = 0;
            // 
            // UCTestRotor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucRotor3);
            this.Controls.Add(this.ucRotor2);
            this.Controls.Add(this.ucRotor1);
            this.Name = "UCTestRotor";
            this.Size = new System.Drawing.Size(654, 472);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCRotor ucRotor1;
        private HZH_Controls.Controls.UCRotor ucRotor2;
        private HZH_Controls.Controls.UCRotor ucRotor3;


    }
}
