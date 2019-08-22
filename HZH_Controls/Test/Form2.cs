using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ucStep1.StepIndex = 3;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.ucProcessEllipse1.Value++;
            this.ucProcessEllipse2.Value++;
            this.ucProcessLine1.Value++;
            ucProcessLineExt1.Value++;

            if (this.ucProcessEllipse1.Value == 100)
                this.ucProcessEllipse1.Value = 0;
            if (this.ucProcessEllipse2.Value == 100)
                this.ucProcessEllipse2.Value = 0;
            if (this.ucProcessLine1.Value >= this.ucProcessLine1.MaxValue)
                this.ucProcessLine1.Value = 0;
            if (this.ucProcessLineExt1.Value >= this.ucProcessLineExt1.MaxValue)
                this.ucProcessLineExt1.Value = 0;
        }
    }
}
