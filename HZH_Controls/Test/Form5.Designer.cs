namespace Test
{
    partial class Form5
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
            this.ucMindMappingPanel1 = new HZH_Controls.Controls.UCMindMappingPanel();
            this.SuspendLayout();
            // 
            // ucMindMappingPanel1
            // 
            this.ucMindMappingPanel1.AutoScroll = true;
            this.ucMindMappingPanel1.BackColor = System.Drawing.Color.White;
            this.ucMindMappingPanel1.DataSource = null;
            this.ucMindMappingPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMindMappingPanel1.Location = new System.Drawing.Point(0, 0);
            this.ucMindMappingPanel1.Name = "ucMindMappingPanel1";
            this.ucMindMappingPanel1.Size = new System.Drawing.Size(654, 566);
            this.ucMindMappingPanel1.TabIndex = 0;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 566);
            this.Controls.Add(this.ucMindMappingPanel1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCMindMappingPanel ucMindMappingPanel1;
    }
}