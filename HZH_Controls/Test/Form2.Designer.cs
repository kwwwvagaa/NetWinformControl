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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ucSwitch1 = new HZH_Controls.Controls.UCSwitch();
            this.ucCrumbNavigation1 = new HZH_Controls.Controls.UCCrumbNavigation();
            this.ucProcessEllipse1 = new HZH_Controls.Controls.UCProcessEllipse();
            this.ucPanelTitle1 = new HZH_Controls.Controls.UCPanelTitle();
            this.ucStep1 = new HZH_Controls.Controls.UCStep();
            this.ucSwitch2 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch3 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch4 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch5 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch6 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch7 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch8 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch9 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch10 = new HZH_Controls.Controls.UCSwitch();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucSwitch1
            // 
            this.ucSwitch1.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch1.Checked = true;
            this.ucSwitch1.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch1.Location = new System.Drawing.Point(12, 503);
            this.ucSwitch1.Name = "ucSwitch1";
            this.ucSwitch1.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch1.SwitchType = HZH_Controls.Controls.SwitchType.Line;
            this.ucSwitch1.TabIndex = 4;
            this.ucSwitch1.Texts = new string[0];
            this.ucSwitch1.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(163)))), ((int)(((byte)(169)))));
            // 
            // ucCrumbNavigation1
            // 
            this.ucCrumbNavigation1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucCrumbNavigation1.ForeColor = System.Drawing.Color.White;
            this.ucCrumbNavigation1.Location = new System.Drawing.Point(177, 159);
            this.ucCrumbNavigation1.MinimumSize = new System.Drawing.Size(0, 25);
            this.ucCrumbNavigation1.Name = "ucCrumbNavigation1";
            this.ucCrumbNavigation1.NavColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ucCrumbNavigation1.Navigations = new string[] {
        "目录1",
        "目录2",
        "目录3",
        "目录4"};
            this.ucCrumbNavigation1.Size = new System.Drawing.Size(222, 25);
            this.ucCrumbNavigation1.TabIndex = 3;
            // 
            // ucProcessEllipse1
            // 
            this.ucProcessEllipse1.BackEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.ucProcessEllipse1.CoreEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ucProcessEllipse1.IsShowCoreEllipseBorder = true;
            this.ucProcessEllipse1.Location = new System.Drawing.Point(12, 173);
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
            this.ucStep1.ImgCompleted = ((System.Drawing.Image)(resources.GetObject("ucStep1.ImgCompleted")));
            this.ucStep1.LineWidth = 10;
            this.ucStep1.Location = new System.Drawing.Point(12, 12);
            this.ucStep1.Name = "ucStep1";
            this.ucStep1.Size = new System.Drawing.Size(360, 130);
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
            // ucSwitch2
            // 
            this.ucSwitch2.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch2.Checked = false;
            this.ucSwitch2.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch2.Location = new System.Drawing.Point(126, 503);
            this.ucSwitch2.Name = "ucSwitch2";
            this.ucSwitch2.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch2.SwitchType = HZH_Controls.Controls.SwitchType.Line;
            this.ucSwitch2.TabIndex = 4;
            this.ucSwitch2.Texts = new string[0];
            this.ucSwitch2.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(163)))), ((int)(((byte)(169)))));
            // 
            // ucSwitch3
            // 
            this.ucSwitch3.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch3.Checked = true;
            this.ucSwitch3.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch3.Location = new System.Drawing.Point(12, 337);
            this.ucSwitch3.Name = "ucSwitch3";
            this.ucSwitch3.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch3.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
            this.ucSwitch3.TabIndex = 4;
            this.ucSwitch3.Texts = new string[0];
            this.ucSwitch3.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(163)))), ((int)(((byte)(169)))));
            // 
            // ucSwitch4
            // 
            this.ucSwitch4.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch4.Checked = false;
            this.ucSwitch4.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch4.Location = new System.Drawing.Point(12, 377);
            this.ucSwitch4.Name = "ucSwitch4";
            this.ucSwitch4.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch4.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
            this.ucSwitch4.TabIndex = 4;
            this.ucSwitch4.Texts = new string[0];
            this.ucSwitch4.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(163)))), ((int)(((byte)(169)))));
            // 
            // ucSwitch5
            // 
            this.ucSwitch5.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch5.Checked = true;
            this.ucSwitch5.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch5.Location = new System.Drawing.Point(126, 337);
            this.ucSwitch5.Name = "ucSwitch5";
            this.ucSwitch5.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch5.SwitchType = HZH_Controls.Controls.SwitchType.Quadrilateral;
            this.ucSwitch5.TabIndex = 4;
            this.ucSwitch5.Texts = new string[0];
            this.ucSwitch5.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(163)))), ((int)(((byte)(169)))));
            // 
            // ucSwitch6
            // 
            this.ucSwitch6.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch6.Checked = false;
            this.ucSwitch6.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch6.Location = new System.Drawing.Point(126, 377);
            this.ucSwitch6.Name = "ucSwitch6";
            this.ucSwitch6.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch6.SwitchType = HZH_Controls.Controls.SwitchType.Quadrilateral;
            this.ucSwitch6.TabIndex = 4;
            this.ucSwitch6.Texts = new string[0];
            this.ucSwitch6.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(163)))), ((int)(((byte)(169)))));
            // 
            // ucSwitch7
            // 
            this.ucSwitch7.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch7.Checked = true;
            this.ucSwitch7.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch7.Location = new System.Drawing.Point(12, 423);
            this.ucSwitch7.Name = "ucSwitch7";
            this.ucSwitch7.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch7.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
            this.ucSwitch7.TabIndex = 4;
            this.ucSwitch7.Texts = new string[] {
        "确定",
        "取消"};
            this.ucSwitch7.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(163)))), ((int)(((byte)(169)))));
            // 
            // ucSwitch8
            // 
            this.ucSwitch8.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch8.Checked = false;
            this.ucSwitch8.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch8.Location = new System.Drawing.Point(12, 463);
            this.ucSwitch8.Name = "ucSwitch8";
            this.ucSwitch8.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch8.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
            this.ucSwitch8.TabIndex = 4;
            this.ucSwitch8.Texts = new string[] {
        "确定",
        "取消"};
            this.ucSwitch8.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(163)))), ((int)(((byte)(169)))));
            // 
            // ucSwitch9
            // 
            this.ucSwitch9.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch9.Checked = true;
            this.ucSwitch9.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch9.Location = new System.Drawing.Point(126, 423);
            this.ucSwitch9.Name = "ucSwitch9";
            this.ucSwitch9.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch9.SwitchType = HZH_Controls.Controls.SwitchType.Quadrilateral;
            this.ucSwitch9.TabIndex = 4;
            this.ucSwitch9.Texts = new string[] {
        "确定",
        "取消"};
            this.ucSwitch9.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(163)))), ((int)(((byte)(169)))));
            // 
            // ucSwitch10
            // 
            this.ucSwitch10.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch10.Checked = false;
            this.ucSwitch10.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch10.Location = new System.Drawing.Point(126, 463);
            this.ucSwitch10.Name = "ucSwitch10";
            this.ucSwitch10.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch10.SwitchType = HZH_Controls.Controls.SwitchType.Quadrilateral;
            this.ucSwitch10.TabIndex = 4;
            this.ucSwitch10.Texts = new string[] {
        "确定",
        "取消"};
            this.ucSwitch10.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(163)))), ((int)(((byte)(169)))));
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(825, 594);
            this.Controls.Add(this.ucSwitch10);
            this.Controls.Add(this.ucSwitch9);
            this.Controls.Add(this.ucSwitch6);
            this.Controls.Add(this.ucSwitch8);
            this.Controls.Add(this.ucSwitch5);
            this.Controls.Add(this.ucSwitch7);
            this.Controls.Add(this.ucSwitch4);
            this.Controls.Add(this.ucSwitch3);
            this.Controls.Add(this.ucSwitch2);
            this.Controls.Add(this.ucSwitch1);
            this.Controls.Add(this.ucCrumbNavigation1);
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
        private HZH_Controls.Controls.UCCrumbNavigation ucCrumbNavigation1;
        private HZH_Controls.Controls.UCSwitch ucSwitch1;
        private HZH_Controls.Controls.UCSwitch ucSwitch2;
        private HZH_Controls.Controls.UCSwitch ucSwitch3;
        private HZH_Controls.Controls.UCSwitch ucSwitch4;
        private HZH_Controls.Controls.UCSwitch ucSwitch5;
        private HZH_Controls.Controls.UCSwitch ucSwitch6;
        private HZH_Controls.Controls.UCSwitch ucSwitch7;
        private HZH_Controls.Controls.UCSwitch ucSwitch8;
        private HZH_Controls.Controls.UCSwitch ucSwitch9;
        private HZH_Controls.Controls.UCSwitch ucSwitch10;
    }
}