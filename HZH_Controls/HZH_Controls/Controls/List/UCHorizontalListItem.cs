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
    [ToolboxItem(false)]
    public partial class UCHorizontalListItem : UserControl
    {
        public event EventHandler SelectedItem;
        private KeyValuePair<string, string> _DataSource = new KeyValuePair<string, string>();
        public KeyValuePair<string, string> DataSource
        {
            get { return _DataSource; }
            set
            {
                _DataSource = value;
                int intWidth = ControlHelper.GetStringWidth(value.Value, lblTitle.CreateGraphics(), lblTitle.Font);
                if (intWidth < 50)
                    intWidth = 50;
                this.Width = intWidth +20;
                lblTitle.Text = value.Value;
                SetSelect(false);
            }
        }
        public UCHorizontalListItem()
        {
            InitializeComponent();
            this.Dock = DockStyle.Right;
            this.MouseDown += Item_MouseDown;
            this.lblTitle.MouseDown += Item_MouseDown;
            this.ucSplitLine_H1.MouseDown += Item_MouseDown;
        }

        void Item_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null)
                SelectedItem(this, e);
        }

        public void SetSelect(bool bln)
        {
            if (bln)
            {
                lblTitle.ForeColor = Color.FromArgb(255, 77, 59);
                ucSplitLine_H1.Visible = true;
                this.lblTitle.Padding = new Padding(0, 0, 0, 5);
            }
            else
            {
                lblTitle.ForeColor = Color.FromArgb(64,64,64);
                ucSplitLine_H1.Visible = false;
                this.lblTitle.Padding = new Padding(0, 0, 0, 0);
            }
        }
    }
}
