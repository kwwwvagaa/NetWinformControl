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
            this.ucProcessWave1.Value++;
            this.ucProcessWave2.Value++;

            if (this.ucProcessEllipse1.Value == 100)
                this.ucProcessEllipse1.Value = 0;
            if (this.ucProcessEllipse2.Value == 100)
                this.ucProcessEllipse2.Value = 0;          
            if (this.ucProcessLine1.Value >= this.ucProcessLine1.MaxValue)
                this.ucProcessLine1.Value = 0;
            if (this.ucProcessLineExt1.Value >= this.ucProcessLineExt1.MaxValue)
                this.ucProcessLineExt1.Value = 0;
            if (this.ucProcessWave1.Value >= this.ucProcessWave1.MaxValue)
                this.ucProcessWave1.Value = 0;
            if (this.ucProcessWave2.Value >= this.ucProcessWave1.MaxValue)
                this.ucProcessWave2.Value = 0;

            Random r = new Random();
            int i = r.Next(100, 1000);
            this.ucWaveWithSource1.AddSource(i.ToString(), i);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.ucWave1.WaveSleep = trackBar1.Value;

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            this.ucWave1.WaveHeight = trackBar2.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            this.ucWave1.WaveWidth = trackBar3.Value;
        }
    }
}
