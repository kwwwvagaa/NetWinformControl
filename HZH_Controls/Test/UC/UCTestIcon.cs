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
    public partial class UCTestIcon : UserControl
    {
        public UCTestIcon()
        {
            InitializeComponent();
        }

        private void UCTestIcon_Load(object sender, EventArgs e)
        {
            try
            {
                HZH_Controls.ControlHelper.FreezeControl(this, true);
                string[] nameList = System.Enum.GetNames(typeof(HZH_Controls.FontIcons));
                var lst = nameList.ToList();
                lst.Sort();
                foreach (var item in lst)
                {
                    HZH_Controls.FontIcons icon = (HZH_Controls.FontIcons)Enum.Parse(typeof(HZH_Controls.FontIcons), item);
                    Label lbl = new Label();
                    lbl.AutoSize = false;
                    lbl.Size = new System.Drawing.Size(300, 35);
                    lbl.ForeColor = Color.FromArgb(255, 77, 59);
                    lbl.TextAlign = ContentAlignment.MiddleLeft;
                    lbl.Margin = new System.Windows.Forms.Padding(5);
                    lbl.DoubleClick += lbl_DoubleClick;
                    string s = char.ConvertFromUtf32((int)icon);
                    lbl.Text = "       " + item;
                    lbl.Image = HZH_Controls.FontImages.GetImage(icon, 32, Color.FromArgb(255, 77, 59));
                    lbl.ImageAlign = ContentAlignment.MiddleLeft;
                    lbl.Font = new Font("微软雅黑", 12);
                    if (item.StartsWith("A_"))
                    {
                        flowLayoutPanel1.Controls.Add(lbl);
                    }
                    else
                    {
                        flowLayoutPanel2.Controls.Add(lbl);
                    }
                }
                this.ActiveControl = this.flowLayoutPanel1;
            }
            finally
            {
                HZH_Controls.ControlHelper.FreezeControl(this, false);
            }
            HZH_Controls.Forms.FrmTips.ShowTipsSuccess(this.FindForm(), "双击复制对应的值");

        }
        void lbl_DoubleClick(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            string text = System.Text.RegularExpressions.Regex.Split(lbl.Text, "\\s+")[1];
            Clipboard.SetDataObject(text);
            HZH_Controls.Forms.FrmTips.ShowTipsSuccess(this.FindForm(), "已复制  " + text);
        }

        private void tabControlExt1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlExt1.SelectedIndex == 0)
                this.ActiveControl = this.flowLayoutPanel1;
            else
                this.ActiveControl = this.flowLayoutPanel2;

        }
    }
}
