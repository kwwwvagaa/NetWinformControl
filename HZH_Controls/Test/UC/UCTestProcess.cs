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
    public partial class UCTestProcess : UserControl
    {
        public UCTestProcess()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.ucProcessEllipse1.Value++;
            this.ucProcessEllipse2.Value++;
            this.ucProcessEllipse3.Value++;
            this.ucProcessEllipse4.Value++;

            this.ucProcessLine1.Value++;
            this.ucProcessLine2.Value++;

            ucProcessLineExt1.Value++;
            ucProcessLineExt2.Value++;

            this.ucProcessWave1.Value++;
            this.ucProcessWave2.Value++;
            this.ucProcessWave3.Value++;
            this.ucProcessWave4.Value++;
            this.ucProcessWave5.Value++;
            this.ucProcessWave6.Value++;

            if (this.ucProcessEllipse1.Value == this.ucProcessEllipse1.MaxValue)
                this.ucProcessEllipse1.Value = 0;
            if (this.ucProcessEllipse2.Value == this.ucProcessEllipse2.MaxValue)
                this.ucProcessEllipse2.Value = 0;
            if (this.ucProcessEllipse3.Value == this.ucProcessEllipse3.MaxValue)
                this.ucProcessEllipse3.Value = 0;
            if (this.ucProcessEllipse4.Value == this.ucProcessEllipse4.MaxValue)
                this.ucProcessEllipse4.Value = 0;

            if (this.ucProcessLine1.Value >= this.ucProcessLine1.MaxValue)
                this.ucProcessLine1.Value = 0;
            if (this.ucProcessLine2.Value >= this.ucProcessLine2.MaxValue)
                this.ucProcessLine2.Value = 0;

            if (this.ucProcessLineExt1.Value >= this.ucProcessLineExt1.MaxValue)
                this.ucProcessLineExt1.Value = 0;
            if (this.ucProcessLineExt2.Value >= this.ucProcessLineExt2.MaxValue)
                this.ucProcessLineExt2.Value = 0;

            if (this.ucProcessWave1.Value >= this.ucProcessWave1.MaxValue)
                this.ucProcessWave1.Value = 0;
            if (this.ucProcessWave2.Value >= this.ucProcessWave1.MaxValue)
                this.ucProcessWave2.Value = 0;
            if (this.ucProcessWave3.Value >= this.ucProcessWave3.MaxValue)
                this.ucProcessWave3.Value = 0;
            if (this.ucProcessWave4.Value >= this.ucProcessWave4.MaxValue)
                this.ucProcessWave4.Value = 0;
            if (this.ucProcessWave5.Value >= this.ucProcessWave5.MaxValue)
                this.ucProcessWave5.Value = 0;
            if (this.ucProcessWave6.Value >= this.ucProcessWave6.MaxValue)
                this.ucProcessWave6.Value = 0;
        }
    }
}
