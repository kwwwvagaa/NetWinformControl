namespace Test
{
    partial class Form2
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
            this.button1 = new System.Windows.Forms.Button();
            this.ucStep1 = new HZH_Controls.Controls.UCStep();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucStep1
            // 
            this.ucStep1.BackColor = System.Drawing.Color.Transparent;
            this.ucStep1.Location = new System.Drawing.Point(12, 12);
            this.ucStep1.Name = "ucStep1";
            this.ucStep1.Size = new System.Drawing.Size(361, 76);
            this.ucStep1.StepBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ucStep1.StepFontColor = System.Drawing.Color.White;
            this.ucStep1.StepForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(51)))));
            this.ucStep1.StepIndex = 1;
            this.ucStep1.Steps = new string[] {
        "step1",
        "step2",
        "step3",
        "step4",
        "step5"};
            this.ucStep1.StepWidth = 35;
            this.ucStep1.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(825, 594);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ucStep1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCStep ucStep1;
        private System.Windows.Forms.Button button1;
    }
}