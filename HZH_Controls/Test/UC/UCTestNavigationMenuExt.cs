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
    public partial class UCTestNavigationMenuExt : UserControl
    {
        public UCTestNavigationMenuExt()
        {
            InitializeComponent();
        }

        private void UCTestNavigationMenuExt_Load(object sender, EventArgs e)
        {
            
            foreach (var item in this.ucNavigationMenuExt1.Items)
            {
                Control panel1 = CreatePanel(this.ucNavigationMenuExt1.BackColor);
                item.ShowControl = panel1;
            }

            this.ucNavigationMenuExt1.Items[0].ShowControl = null;

            foreach (var item in this.ucNavigationMenuExt2.Items)
            {
                Control panel2 = CreatePanel(this.ucNavigationMenuExt2.BackColor);
                item.ShowControl = panel2;
            }

            foreach (var item in this.ucNavigationMenuExt3.Items)
            {
                Control panel3 = CreatePanel(this.ucNavigationMenuExt3.BackColor);
                item.ShowControl = panel3;
            }

            foreach (var item in this.ucNavigationMenuExt4.Items)
            {
                Control panel4 = CreatePanel(this.ucNavigationMenuExt4.BackColor);
                item.ShowControl = panel4;
            }

        }

        private Control CreatePanel(Color color)
        {
            UCControlBase c = new UCControlBase();
            c.IsRadius = true;
            c.ConerRadius = 5;
            c.IsShowRect = true;
            c.FillColor = color;
            c.BackColor = Color.Transparent;
            c.Size = new Size(130, 180);
            Label lbl = new Label();
            lbl.AutoSize = false;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Text = "这是一个自定义的弹出内容，你可以根据自己需求进行扩展\r\n"+Guid.NewGuid().ToString();
            lbl.ForeColor = Color.White;
            c.Controls.Add(lbl);
            return c;
        }
    }
}
