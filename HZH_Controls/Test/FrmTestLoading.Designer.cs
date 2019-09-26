namespace Test
{
    partial class FrmTestLoading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucProcessLineExt1 = new HZH_Controls.Controls.UCProcessLineExt();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucProcessLineExt1
            // 
            this.ucProcessLineExt1.BackColor = System.Drawing.Color.Transparent;
            this.ucProcessLineExt1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.ucProcessLineExt1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucProcessLineExt1.Location = new System.Drawing.Point(27, 87);
            this.ucProcessLineExt1.MaxValue = 100;
            this.ucProcessLineExt1.Name = "ucProcessLineExt1";
            this.ucProcessLineExt1.Size = new System.Drawing.Size(434, 50);
            this.ucProcessLineExt1.TabIndex = 0;
            this.ucProcessLineExt1.Value = 0;
            this.ucProcessLineExt1.ValueBGColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.ucProcessLineExt1.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(45, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 41);
            this.label1.TabIndex = 1;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(45, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(397, 41);
            this.label2.TabIndex = 1;
            this.label2.Text = "模拟系统启动时资源加载";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmTestLoading
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(489, 225);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucProcessLineExt1);
            this.IsShowRegion = true;
            this.Name = "FrmTestLoading";
            this.Redraw = true;
            this.Text = "FrmTestLoading";
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCProcessLineExt ucProcessLineExt1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}