namespace Test
{
    partial class FrmTestListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTestListView));
            this.ucListView1 = new HZH_Controls.Controls.UCListView();
            this.SuspendLayout();
            // 
            // ucListView1
            // 
            this.ucListView1.BackColor = System.Drawing.Color.White;
            this.ucListView1.DataSource = ((object)(resources.GetObject("ucListView1.DataSource")));
            this.ucListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucListView1.IsMultiple = false;
            this.ucListView1.ItemType = typeof(HZH_Controls.Controls.UCListViewItem);
            this.ucListView1.Location = new System.Drawing.Point(0, 61);
            this.ucListView1.Margin = new System.Windows.Forms.Padding(0);
            this.ucListView1.Name = "ucListView1";
            this.ucListView1.Page = null;
            this.ucListView1.SelectedSource = ((System.Collections.Generic.List<object>)(resources.GetObject("ucListView1.SelectedSource")));
            this.ucListView1.Size = new System.Drawing.Size(679, 416);
            this.ucListView1.TabIndex = 3;
            // 
            // FrmTestListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 477);
            this.Controls.Add(this.ucListView1);
            this.FrmTitle = "测试Listview";
            this.IsFullSize = false;
            this.Name = "FrmTestListView";
            this.Text = "FrmTestListView";
            this.Load += new System.EventHandler(this.FrmTestListView_Load);
            this.Controls.SetChildIndex(this.ucListView1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCListView ucListView1;
    }
}