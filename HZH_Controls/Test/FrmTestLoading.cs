using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Forms;

namespace Test
{
    public partial class FrmTestLoading : FrmLoading
    {
        public FrmTestLoading()
        {
            InitializeComponent();
        }
        protected override void BindingProcessMsg(string strText, int intValue)
        {
            label1.Text = strText;
            this.ucProcessLineExt1.Value = intValue;
        }
    }
}
