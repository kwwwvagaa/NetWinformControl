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
    public partial class UCTestDialAisle : UserControl
    {
        public UCTestDialAisle()
        {
            InitializeComponent();
        }

        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
        {
            this.ucDialAisle1.AddLink(new Random().Next(0, 10));
        }

        private void ucBtnExt2_BtnClick(object sender, EventArgs e)
        {
            this.ucDialAisle1.ClearAllLink();
        }
    }
}
