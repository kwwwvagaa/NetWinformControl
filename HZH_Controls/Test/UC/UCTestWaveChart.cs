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
    public partial class UCTestWaveChart : UserControl
    {
        public UCTestWaveChart()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int i = r.Next(100, 200);
            this.ucWaveChart1.AddSource(i.ToString(), i);
            this.ucWaveChart2.AddSource(i.ToString(), i);
        }
    }
}
