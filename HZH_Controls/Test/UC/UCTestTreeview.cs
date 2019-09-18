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
    public partial class UCTestTreeview : UserControl
    {
        public UCTestTreeview()
        {
            InitializeComponent();

        }

        private void UCTestTreeview_Load(object sender, EventArgs e)
        {
            string[] nameList = System.Enum.GetNames(typeof(HZH_Controls.FontIcons));
            var lst = nameList.ToList();
            lst.Sort();
            for (int i = 0; i < 100; i++)
            {
                HZH_Controls.FontIcons icon = (HZH_Controls.FontIcons)Enum.Parse(typeof(HZH_Controls.FontIcons), nameList[i]);

                imageList1.Images.Add(HZH_Controls.FontImages.GetImage(icon, 24, Color.FromArgb(255, 77, 59)));
            }

            Random r = new Random();
            int intMax1 = r.Next(5, 10);
            for (int i = 0; i < intMax1; i++)
            {
                int intMax2 = r.Next(5, 10);
                var tn = new TreeNode("父节点" + i);
                tn.ImageIndex = r.Next(0, imageList1.Images.Count);
                for (int j = 0; j < intMax2; j++)
                {
                    var tn1 = new TreeNode("子节点" + j);
                    tn1.ImageIndex = r.Next(0, imageList1.Images.Count);
                    tn.Nodes.Add(tn1);
                }
                treeViewEx6.Nodes.Add(tn);
            }

            for (int i = 0; i < intMax1; i++)
            {
                int intMax2 = r.Next(5, 10);
                var tn = new TreeNode("父节点" + i);
                tn.ImageIndex = r.Next(0, imageList1.Images.Count);
                for (int j = 0; j < intMax2; j++)
                {
                    var tn1 = new TreeNode("子节点" + j);
                    tn1.ImageIndex = r.Next(0, imageList1.Images.Count);
                    tn.Nodes.Add(tn1);
                }
                treeViewEx5.Nodes.Add(tn);
            }
        }
    }
}
