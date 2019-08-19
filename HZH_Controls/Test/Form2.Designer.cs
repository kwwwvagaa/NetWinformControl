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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ucProcessEllipse1 = new HZH_Controls.Controls.UCProcessEllipse();
            this.ucPanelTitle1 = new HZH_Controls.Controls.UCPanelTitle();
            this.ucStep1 = new HZH_Controls.Controls.UCStep();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucProcessEllipse1
            // 
            this.ucProcessEllipse1.BackEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.ucProcessEllipse1.CoreEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ucProcessEllipse1.IsShowCoreEllipseBorder = true;
            this.ucProcessEllipse1.Location = new System.Drawing.Point(90, 288);
            this.ucProcessEllipse1.MaxValue = 100;
            this.ucProcessEllipse1.Name = "ucProcessEllipse1";
            this.ucProcessEllipse1.ShowType = HZH_Controls.Controls.ShowType.Ring;
            this.ucProcessEllipse1.Size = new System.Drawing.Size(150, 150);
            this.ucProcessEllipse1.TabIndex = 2;
            this.ucProcessEllipse1.Value = 0;
            this.ucProcessEllipse1.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucProcessEllipse1.ValueMargin = 0;
            this.ucProcessEllipse1.ValueType = HZH_Controls.Controls.ValueType.Percent;
            this.ucProcessEllipse1.ValueWidth = 30;
            // 
            // ucPanelTitle1
            // 
            this.ucPanelTitle1.BackColor = System.Drawing.Color.Transparent;
            this.ucPanelTitle1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.ucPanelTitle1.ConerRadius = 10;
            this.ucPanelTitle1.FillColor = System.Drawing.Color.White;
            this.ucPanelTitle1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucPanelTitle1.IsRadius = true;
            this.ucPanelTitle1.IsShowRect = true;
            this.ucPanelTitle1.Location = new System.Drawing.Point(406, 14);
            this.ucPanelTitle1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucPanelTitle1.Name = "ucPanelTitle1";
            this.ucPanelTitle1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.ucPanelTitle1.RectWidth = 1;
            this.ucPanelTitle1.Size = new System.Drawing.Size(316, 182);
            this.ucPanelTitle1.TabIndex = 1;
            this.ucPanelTitle1.Title = "面板标题";
            // 
            // ucStep1
            // 
            this.ucStep1.BackColor = System.Drawing.Color.Transparent;
            this.ucStep1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucStep1.LineWidth = 10;
            this.ucStep1.Location = new System.Drawing.Point(12, 12);
            this.ucStep1.Name = "ucStep1";
            this.ucStep1.Size = new System.Drawing.Size(360, 172);
            this.ucStep1.StepBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ucStep1.StepFontColor = System.Drawing.Color.White;
            this.ucStep1.StepForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(184)))), ((int)(((byte)(255)))));
            this.ucStep1.StepIndex = 2;
            this.ucStep1.Steps = new string[] {
        "step1",
        "step2",
        "step3",
        "step4",
        "step5"};
            this.ucStep1.StepWidth = 50;
            this.ucStep1.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(825, 594);
            this.Controls.Add(this.ucProcessEllipse1);
            this.Controls.Add(this.ucPanelTitle1);
            this.Controls.Add(this.ucStep1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCStep ucStep1;
        private HZH_Controls.Controls.UCPanelTitle ucPanelTitle1;
        private HZH_Controls.Controls.UCProcessEllipse ucProcessEllipse1;
        private System.Windows.Forms.Timer timer1;
    }
}