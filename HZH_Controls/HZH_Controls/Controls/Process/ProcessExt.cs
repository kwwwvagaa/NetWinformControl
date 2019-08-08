using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    public partial class ProcessExt : UCControlBase
    {
        private int _value = 0;

        public int Value
        {
            get { return this._value; }
            set
            {
                if (value < 0)
                    return;
                this._value = value;
                SetValue();
            }
        }

        private int maxValue = 100;

        public int MaxValue
        {
            get { return maxValue; }
            set
            {
                if (value <= 0)
                    return;
                maxValue = value;
                SetValue();
            }
        }

        private void SetValue()
        {
            double dbl = (double)_value / (double)maxValue;
            this.panel1.Width = (int)(this.Width * dbl);
        }

        public ProcessExt()
        {
            InitializeComponent();
        }

        private void ProcessExt_SizeChanged(object sender, EventArgs e)
        {
            SetValue();
        }

        public void Step()
        {
            Value++;
        }
    }
}
