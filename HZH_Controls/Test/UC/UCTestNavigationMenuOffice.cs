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
    public partial class UCTestNavigationMenuOffice : UserControl
    {
        public UCTestNavigationMenuOffice()
        {
            InitializeComponent();
        }

        private void UCTestNavigationMenuOffice_Load(object sender, EventArgs e)
        {
            foreach (NavigationMenuItemExt item in this.ucNavigationMenuOffice1.Items)
            {
                Control panel1 =new UCTestNavigationMenuOfficeItem( item.Text);
                item.ShowControl = panel1;
            }
            this.ucNavigationMenuOffice1.ResetChildControl();

            foreach (NavigationMenuItemExt item in this.ucNavigationMenuOffice2.Items)
            {
                Control panel1 = new UCTestNavigationMenuOfficeItem(item.Text);
                item.ShowControl = panel1;
            }
            this.ucNavigationMenuOffice2.ResetChildControl();

            foreach (NavigationMenuItemExt item in this.ucNavigationMenuOffice3.Items)
            {
                Control panel1 = new UCTestNavigationMenuOfficeItem(item.Text);
                item.ShowControl = panel1;
            }
            this.ucNavigationMenuOffice3.ResetChildControl();

            foreach (NavigationMenuItemExt item in this.ucNavigationMenuOffice4.Items)
            {
                Control panel1 = new UCTestNavigationMenuOfficeItem(item.Text);
                item.ShowControl = panel1;
            }
            this.ucNavigationMenuOffice4.ResetChildControl();
        }

      
    }
}
