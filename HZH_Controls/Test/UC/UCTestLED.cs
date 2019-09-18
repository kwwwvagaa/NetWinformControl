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
    public partial class UCTestLED : UserControl
    {
        public UCTestLED()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ucledDataTime1.Value = DateTime.Now;
            ucledTime2.Value = DateTime.Now;
            Random r = new Random();
            int i = r.Next(1, 10000);
            double dbl = ((double)i) / 100.0000;
            string str = dbl.ToString("0.000");
            this.ucledNums1.Value = str;
            this.ucledNums2.Value = str;
        }

    }
}
