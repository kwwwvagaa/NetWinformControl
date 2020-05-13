using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Controls;

namespace Test.UC
{
    public partial class UCTestTurntable : UserControl
    {
        public UCTestTurntable()
        {
            InitializeComponent();
        }

        private void UCTestTurntable_Load(object sender, EventArgs e)
        {
            Dictionary<int, UCBottle> lst = new Dictionary<int, UCBottle>();
            for (int i = 0; i < 5; i++)
            {
                lst[i] = new UCBottle() { Direction = Direction.Up, NO = "#" + i };
            }
            this.ucTurntable1.SetItems(lst);
        }

        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
        {
            this.ucTurntable1.LeftItem();
        }

        private void ucBtnExt2_BtnClick(object sender, EventArgs e)
        {
            this.ucTurntable1.RightItem();
        }
    }
}
