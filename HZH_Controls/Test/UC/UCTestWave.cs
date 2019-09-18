using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.UC
{
    [ToolboxItem(false)]
    public partial class UCTestWave : UserControl
    {
        public UCTestWave()
        {
            InitializeComponent();
        }

        private void ucTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.ucWave1.WaveSleep = (int)ucTrackBar1.Value;
            this.ucWave2.WaveSleep = (int)ucTrackBar1.Value;
        }

        private void ucTrackBar2_ValueChanged(object sender, EventArgs e)
        {
            this.ucWave1.WaveHeight = (int)ucTrackBar2.Value;
            this.ucWave2.WaveHeight = (int)ucTrackBar2.Value;
        }

        private void ucTrackBar3_ValueChanged(object sender, EventArgs e)
        {
            this.ucWave1.WaveWidth = (int)ucTrackBar3.Value;
            this.ucWave2.WaveWidth = (int)ucTrackBar3.Value;
        }
    }
}
